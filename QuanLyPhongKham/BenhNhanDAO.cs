using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyPhongKham
{
    class BenhNhanDAO
    {
        public static bool removeBenhNhan(String CMND)
        {
            BenhNhan benhnhan = null;
            using(var context=new PhongKhamEntities())
            {
                benhnhan = context.BenhNhans.Find(CMND);
                context.BenhNhans.Remove(benhnhan);
                context.SaveChanges();
            }
            return benhnhan==null;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="CMND"></param>
        /// <param name="benhnhan"></param>
        /// <returns>-1:loi, 0:update, 1:them</returns>
        public static int addOrUpdateBenhNhan(String CMND, BenhNhan benhnhan)
        {
            if (CMND != benhnhan.CMND) return -1;
            BenhNhan bn = null;
            int res = 0;
            using (var context = new PhongKhamEntities())
            {
                bn = context.BenhNhans.Find(CMND);
                if (bn == null)
                {
                    res = 1;
                    context.BenhNhans.Add(benhnhan);
                }
                else context.Entry(bn).CurrentValues.SetValues(benhnhan);
                context.SaveChanges();
            }
            return res;
        }
        public static BenhNhan getBenhNhan(String CMND)
        {
            BenhNhan bn = null;
            using (var context = new PhongKhamEntities())
            {
                bn = context.BenhNhans.Find(CMND);
            }
            return bn;
        }
    }
}
