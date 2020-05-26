# DM 103348:  Image Encryption and Decryption with RSA Algorithm 

### PROJECT MEMBERS:

StdID     |     Name
----------  | -------------
63583     | **Amta Nadeem**
63805     | Syed Abbas Raza Zaidi
63759     | Bushra Muneer
63758     | Ali Salman Hasan
63800     | Muhammed Ibrahim


## Project Description:

As we can guess by the name our project  is a working example of RSA Algorithm and the motive was to encrypt any image with the help of RSA and decypt it.
Acyually i (Abbas) got this idea from steganography which is basically a techinique to encode a image with a piece of information although the project is far away from that
 but it's just the beginning.
##### Image is based on user input and is done by using RSA . 
When image is taken as input its properties will be displayed i.e. image size, file name and image resolution. After this Hex function will extracts image Hex code and then
 it is going to convert in cipher text through RSA Algorithm. When this cipher text will be loaded and applied RSA Algorithm, it will decipher the text, and the image is loaded back.

#### PROCESS OF ENCRYPTION:
----------------------------------------
* Image input 
* Loading image
* Hex conversion 
* RSA algorithm to encrypt Cipher text 
* Stop

#### PROCESS OF DECRYPTION 
----------------------------------------
* Cipher Text 
* Input---> Loading cipher File 
* RSA algorithm to decrypt
* Hex conversion 
* Create a file 
* Stop

## Discrete Math Concepts Used:
* RSA Algorithm (Ron Rivest, Adi Shamir, and Leonard Adleman Algorithm)
In this project we have use the class RSA which we have used to multiple function such as calculating phi , Mod and value of n. 

* Cryptography: the image is encrypted using RSA and a cipher file is generated making it secure and unable to read with out the keys.

### Example 1: 
```C#
   public static int cal_phi(int p1, int p2)
        { 
            return ( (p1 - 1) * (p2- 1) );
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
 public static Int32 pvt_Key(int a, int b, int c)
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
//This method converts the image file into cipher text files
 public static int n_value(int p1, int p2) 
        {
            return( p1 * p2);
        }

```

## Problems Faced

### Problem 1: Conversion of Image in bytes:
this was the first time we were trying to convert image into bytes though we know that image consist of several pixels and each pixel has a different value we used the logic
to convert the image into bytes also we took help from internet from a website and also youtube refrences are mentioned below.

### Problem 2: Identifying Values of D and N:
identifying the value of D and N in Decyption was hard too so we took a help of a online calculator linked and process is also mentioned in the repository and below the document!.

### Problem 3: Communication and New platform:
Working with distances and in such a busy schedule wasn't easy but it is a part of student life also this was new for us but still we worked on this one 
we took help from internet we communicated n zoom meetings what'sapp group and made this project submitted begfore deadline.Github was a new platform was hard to used but still we made it through 
creadit goes to our teamwork and the way we helped each other with a plenty of effort.
Hope you Like it sir !.

## References:
- [refrence link1](https://www.codeproject.com/Articles/723175/Image-Cryptography-using-RSA-Algorithm-in-Csharp)
- [refrence link2](http://www.ijcset.net/docs/Volumes/volume5issue9/ijcset2015050902.pdf)
- [refrence link3](https://www.youtube.com/watch?v=sYGS80-Joi8)
- [refrence link4](http://csharpdocs.com/encryption-and-decryption-using-rsa-algorithm-in-c/)
