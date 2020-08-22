using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyPhongKham
{
    class LuotThuocDAO
    {
        public static void addLuotThuoc(LuotThuoc lt)
        {
            using (var context = new DataModel())
            {
                context.LuotThuocs.Add(lt);
                context.SaveChanges();
            }

        }
        public static bool removeLuotThuoc(int ID)
        {
            LuotThuoc lt = null;
            using (var context = new DataModel())
            {
                lt = context.LuotThuocs.Find(ID);
                context.LuotThuocs.Remove(lt);
                context.SaveChanges();
            }
            return lt == null;
        }

        public static void updateLuotThuoc(int ID, LuotThuoc lt)
        {
            if (ID != lt.ID) return;
            LuotThuoc l = null;
            using (var context = new DataModel())
            {
                l = context.LuotThuocs.Find(ID);
                if (l == null)
                {
                    context.LuotThuocs.Add(lt);
                }
                else context.Entry(l).CurrentValues.SetValues(lt);
                context.SaveChanges();
            }
        }
        public static LuotThuoc getLuotThuoc(int ID)
        {
            LuotThuoc lt = null;
            using (var context = new DataModel())
            {
                lt = context.LuotThuocs.Include("LuotKham1")
                    .Include("Thuoc1").Where(s => s.ID==ID).FirstOrDefault();
            }
            return lt;
        }
        public static int getLatestID()
        {
            int res = 0;
            using (var context = new DataModel())
            {
                if (context.LuotThuocs.ToList().Any())
                {
                    res = context.LuotThuocs.Max(item => item.ID);
                }
            }
            return res;
        }
        public static IList<LuotThuoc> getLuotThuocOfMonth(string month)
        {
            IList<LuotThuoc> res = new List<LuotThuoc>();
            using (var context = new DataModel())
            {
                res = context.LuotThuocs.Include("LuotKham1")
                    .Include("Thuoc1").Where(s => s.LuotKham1.NgayKham.Substring(3).Equals(month)).ToList();
            }
            return res;
        }
    }
}
