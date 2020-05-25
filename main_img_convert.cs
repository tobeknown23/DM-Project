using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Image_cryptography
{
    class main_img_convert
    {
        public static Bitmap byte_to_img(byte[] b)
        {
            return (new Bitmap((Image.FromStream(new MemoryStream(b)))));
        }


        public static byte[] img_to_byte(Image img)
        {
            MemoryStream m = new MemoryStream();
            new Bitmap(img).Save(m, System.Drawing.Imaging.ImageFormat.Jpeg);
            byte[] h = new byte[] { 255, 216 };
            h = m.ToArray();
            return (h);
        }
       
        public static byte[] DecodeHex(string hextext)
        {
            String[] ar = hextext.Split('-');
            byte[] arr = new byte[ar.Length];
            for (int i = 0; i < ar.Length; i++)
                arr[i] = Convert.ToByte(ar[i], 16);
            return arr;
        }

        public static bool ch_prime(int num)
        {
            if (num < 2) return false;
            if (num % 2 == 0) return (num == 2);
            int root = (int)Math.Sqrt((double)num);
            for (int i = 3; i <= root; i += 2)
            {
                if (num % i == 0)
                    return false;
            }
            return true;
        }

    }
}
