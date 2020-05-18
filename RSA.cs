using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ImageCryptography
{
    class RSA
    {
        public static long sqr(long sq)
        {
            return (sq *sq);
        }

        public static long mod(int p, int q, int r) 
        {
            if (p == 0)
                return 1;
            else if (p % 2 == 0)
                return sqr(mod(p, q / 2, r)) % r;
            else
                return ((p % r) * mod(p, q - 1, r)) % r;
        }

        public static int mul_of_prime(int p1, int p2)
        {
            return (p1 * p2);
        }

        public static int cal_phi(int p1, int p2)
        {
            return ((p1 - 1) * (p2 - 1));
        }

        public static Int32 privateKey(int a, int b, int c)
        {
            int x = 0;
            int RES = 0;

            for (c = 1; ; c++)
            {
                RES = (c * b) % a;
                if (RES == 1) break;
            }
            return c;
        }


    }
}
}
