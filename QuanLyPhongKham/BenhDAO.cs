using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyPhongKham
{
    class BenhDAO
    {
        public static bool removeBenh(String loai)
        {
            Benh benh = null;
            using (var context = new DataModel())
            {
                benh = context.Benhs.Find(loai);
                context.Benhs.Remove(benh);
                context.SaveChanges();
            }
            return benh == null;
        }
        /// <summary>
        /// Them hoac update benh
        /// </summary>
        /// <param name="loai">loai benh</param>
        /// <param name="benh">cac gia tri moi cua benh</param>
        /// <returns>-1: loi, 0:update, 1:them</returns>
        public static int addOrUpdateBenh(String loai, Benh benh)
        {
            if (loai != benh.LoaiBenh) return -1;
            Benh b = null;
            int res = 0;
            using (var context = new DataModel())
            {
                b = context.Benhs.Find(loai);
                if (b == null)
                {
                    res = 1;
                    context.Benhs.Add(benh);
                }
                else context.Entry(b).CurrentValues.SetValues(benh);
                context.SaveChanges();
            }
            return res;
        }
        public static Benh getBenh(String loai)
        {
            Benh b = null;
            using (var context = new DataModel())
            {
                b = context.Benhs.Find(loai);
            }
            return b;
        }
        public static IList<Benh> getAllList()
        {
            IList<Benh> result = new List<Benh>();
            using (var context = new DataModel())
            {
                result = context.Benhs.ToList();
            }
            return result;
        }

        public static bool containsSymptom(Benh benh,String trieuchung)
        {
            return benh.TrieuChung.Contains(trieuchung);
        }
    }
}
