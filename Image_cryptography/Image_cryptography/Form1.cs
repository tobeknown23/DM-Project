using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Image_cryptography
{
    public partial class Form1 : Form
    {
        // create a string for loading images
      public  static string img_load = "";
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {  //for opening dialog box to load picture
            OpenFileDialog o1 = new OpenFileDialog();
            //picture format
            o1.Filter = "JPG|*.JPG";
            if (o1.ShowDialog() == DialogResult.OK)
            {
                //image name show in textbox
                textBox2.Text = o1.FileName;
                //image show in textbox
                pictureBox1.Image = Image.FromFile(textBox2.Text);
                //creating object
                FileInfo fi = new FileInfo(textBox2.Text);
                //labels for file name,image resolution
                label9.Text = "File Name: " + fi.Name;
                label10.Text = "Image Resolution: " + pictureBox1.Image.PhysicalDimension.Height + " X " + pictureBox1.Image.PhysicalDimension.Width;

                double imgMB = ((fi.Length / 1024f) / 1024f);

                label11.Text = "Image Size: " + imgMB.ToString(".##") + "MB";
            }
            else
            {
                textBox2.Text = "";
                label9.Text = "File Name: ";
                label10.Text = "Image Resolution: ";
                label11.Text = "Image Size: ";

                pictureBox1.Image = Properties.Resources.blank;
               

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //image conversion img to byte (load image for encryption)
            img_load = BitConverter.ToString(Image_cryptography.main_img_convert.img_to_byte(pictureBox1.Image));
            MessageBox.Show("Successfully Image Loaded!");

            
        }
   
        private void button3_Click(object sender, EventArgs e)
        {
            //encrypt form open here
            encrypt_here eh = new encrypt_here();
            eh.Show();
            this.Hide();

        }

        private void button4_Click(object sender, EventArgs e)
        {
         //destory here
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //if we click on decrpyt button it will display the msg below
            MessageBox.Show("Sorry!"+"\n"+"Create the cipher file first");

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
