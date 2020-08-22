using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyPhongKham
{
    class ThuocDAO
    {
        public static bool removeThuoc(String ten)
        {
            Thuoc thuoc = null;
            using (var context = new DataModel())
            {
                thuoc = context.Thuocs.Find(ten);
                context.Thuocs.Remove(thuoc);
                context.SaveChanges();
            }
            return thuoc == null;
        }
        /// <summary>
        /// Them hoac update thuoc
        /// </summary>
        /// <param name="ten">ten thuoc</param>
        /// <param name="thuoc">Cac gia tri moi cua thuoc</param>
        /// <returns>-1: loi, 0: update, 1: them</returns>
        public static int addOrUpdateThuoc(String ten, Thuoc thuoc)
        {
            if (ten != thuoc.TenThuoc) return -1;
            Thuoc t = null;
            int res = 0;
            using (var context = new DataModel())
            {
                t = context.Thuocs.Find(ten);
                if (t == null)
                {
                    context.Thuocs.Add(thuoc);
                    res = 1;
                }
                else context.Entry(t).CurrentValues.SetValues(thuoc);
                context.SaveChanges();
            }
            return res;
        }
        public static Thuoc getThuoc(String ten)
        {
            Thuoc t = null;
            using (var context = new DataModel())
            {
                t = context.Thuocs.Find(ten);
            }
            return t;
        }

        public static IList<Thuoc> getAllList()
        {
            IList<Thuoc> result = new List<Thuoc>();
            using (var context = new DataModel())
            {
                result = context.Thuocs.ToList();
            }
            return result;
        }
    }
}
