using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyPhongKham
{
    class LuotKhamDAO
    {
        public static bool addLuotKham(LuotKham lk)
        {
            bool res = false;
            using (var context = new DataModel())
            {
                if (getLuotKhamBaseOnDateAndPatient(lk.NgayKham, lk.BenhNhan) == null)
                {
                    try
                    {
                        context.LuotKhams.Add(lk);
                        context.SaveChanges();
                    }
                    catch(Exception e) { System.Windows.MessageBox.Show(e.InnerException.ToString()); }
                    res = true;
                }
            }
            return res;

        }
        public static bool removeLuotKham(int ID)
        {
            LuotKham lk = null;
            using (var context = new DataModel())
            {
                lk = context.LuotKhams.Find(ID);
                context.LuotKhams.Remove(lk);
                context.SaveChanges();
            }
            return lk == null;
        }

        public static void updateLuotKham(int ID, LuotKham lk)
        {
            if (ID != lk.ID) return;
            LuotKham l = null;
            using (var context = new DataModel())
            {
                l = context.LuotKhams.Find(ID);
                if (l == null)
                {
                    context.LuotKhams.Add(lk);
                }
                else context.Entry(l).CurrentValues.SetValues(lk);
                context.SaveChanges();
            }
        }
        public static LuotKham getLuotKham(int ID)
        {
            LuotKham lk = null;
            using (var context = new DataModel())
            {
                lk = context.LuotKhams
                    .Include("BenhNhan1")
                    .Include("LuotThuocs")
                    .Include("Benh1")
                    .Where(s => s.ID==ID).FirstOrDefault();
            }
            return lk;
        }
        public static int getLatestID()
        {
            int res = 0;
            using (var context = new DataModel())
            {
                if (context.LuotKhams.ToList().Any())
                {
                    res = context.LuotKhams.Max(item => item.ID);
                }
            }
            return res;
        }
        public static IList<LuotKham> getAllLuotKhamOfCurrentDay()
        {
            string date = DateTime.Now.ToString("dd/MM/yyyy");
            IList<LuotKham> res = new List<LuotKham>();
            using (var context = new DataModel())
            {
                try
                {
                    res = context.LuotKhams.Include("BenhNhan1").Where(s => s.NgayKham.Equals(date)).ToList();
                }
                catch(Exception ex) { System.Windows.MessageBox.Show(ex.ToString()); }
            }
            return res;
        }

        public static LuotKham getLuotKhamBaseOnDateAndPatient(String date,String CMND)
        {
            LuotKham lk = null;
            IList<LuotKham> list = new List<LuotKham>();
            using (var context = new DataModel())
            {
                list = context.LuotKhams
                    .Include("BenhNhan1")
                    .Include("LuotThuocs")
                    .Include("Benh1")
                    .Where(s => s.NgayKham.Equals(date) && s.BenhNhan.Equals(CMND))
                    .ToList();
                if (list.Any()) lk = list.FirstOrDefault();
            }
            return lk;
        }
        public static IList<LuotKham> getLuotKhamOfDate(string date)
        {
            IList<LuotKham> res = new List<LuotKham>();
            using (var context = new DataModel())
            {
                res = context.LuotKhams.Include("BenhNhan1")
                        .Where(s => s.NgayKham.Equals(date))
                        .ToList();
            }
            return res;
        }
        public static IList<LuotKham> getLuotKhamOfMonth(string month)
        {
            IList<LuotKham> res = new List<LuotKham>();
            using (var context = new DataModel())
            {
                res = context.LuotKhams.Where(s => s.NgayKham.Substring(3).Equals(month)).ToList();
            }
            return res;
        }
    }
}
