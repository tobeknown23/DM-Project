using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;

namespace ImageCryptography
{
    class img_convert

    {
        public static Bitmap to_img(byte[] b) { 
        return (new Bitmap((Image.FromStream(new MemoryStream(b)))));}


        public static byte[] to_img(Image img) {
            MemoryStream m = new MemoryStream();
            new Bitmap(img).Save(m, System.Drawing.Imaging.ImageFormat.Jpeg);
            byte[] h=new byte[]{255,216};
            h = m.ToArray();
            return (h);
        }
       
    }
}
