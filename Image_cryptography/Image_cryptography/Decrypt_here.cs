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
    public partial class Decrypt_here : Form
    {

        //creating strings for d and n
        static string cipher_load = "";
        static int d = 0;
        static int n = 0;

       
        public Decrypt_here()
        {
            InitializeComponent();
        }

        private void button10_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {

        }

        private void Decrypt_here_Load(object sender, EventArgs e)
        {
            //enable all the buttons and textboxes on the form load
            button6.Enabled = true;
            button9.Enabled = true;
            button8.Enabled = true;
            button7.Enabled = true;
            textBox6.Enabled = true;
            progressBar2.Enabled = true;

        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            //creating a object of dialog box
            SaveFileDialog s1 = new SaveFileDialog();
            //setting the format of picture
            s1.Filter = "JPG|*.JPG";
            //if the dialogbox is ok then display the filename in the textbox
            if (s1.ShowDialog() == DialogResult.OK)
            {
                textBox6.Text = s1.FileName;
                button6.Enabled = true;
            }
            else
            {
                textBox6.Text = "";
                button6.Enabled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //if click on quit  destry the form
            this.Hide();

        }

        private void button10_Click_1(object sender, EventArgs e)
        {
            //open the file dialog box
            OpenFileDialog o1 = new OpenFileDialog();
            //format be in the form of text
            o1.Filter = "TEXT|*.txt";
            if (o1.ShowDialog() == DialogResult.OK)
            {
                textBox7.Text = o1.FileName;
                button9.Enabled = true;
            }
            else
            {
                textBox7.Text = "";
                button9.Enabled = false;
            }
        }

        private void button9_Click_1(object sender, EventArgs e)
        {
            //load the file  which  have the encrypted cipher text
            cipher_load = File.ReadAllText(textBox7.Text);
            MessageBox.Show("Cipher file Loaded Successfully");
            groupBox5.Enabled = true;
        
        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            //if clicking on set details if the textbox is empty display msg that incoorect rsa details
            if (button8.Text == "Set Details")
            {
                if (textBox9.Text == "" || textBox8.Text == "")
                {
                    MessageBox.Show("Incorrect RSA details", "ERROR");
                }
                else
                {
                    if (Convert.ToInt16(textBox9.Text) > 0)
                    {
                        //convert the value of textbox  into integer
                        d = Convert.ToInt16(textBox9.Text);
                    }
                    else
                    {    //if the textbox is empty display msgbox  enter valid number
                        textBox9.Text = "";
                        MessageBox.Show("Enter Valid Number");
                        return;
                    }
                    if (Convert.ToInt16(textBox8.Text) > 0)
                    {
                        //convert the textbox value in integre
                        n = Convert.ToInt16(textBox8.Text);
                    }
                    else
                    {  //if value is empty then display enter valid number
                        textBox8.Text = "";
                        MessageBox.Show("Enter Valid Number");
                        return;
                    }
                    //if the details are set show message box details has been set and disable the textboxes
                    textBox9.Enabled = false;
                    textBox8.Enabled = false;
                    MessageBox.Show("Details has been set!");
                    button8.Text = "ReSet Details";
                    button7.Enabled = true;

                }
            }
            else
            {  //otherwise enable the textboxes
                textBox9.Text = "";
                textBox8.Text = "";
                textBox9.Enabled = true;
                textBox8.Enabled = true;
                button8.Text = "Set Details";
                button7.Enabled = false;
            }
       
        }
        //this function is for decryption and image cipher text is passed in this function
        public string decrypt(String imageToDecrypt)
        { 
            //the cipher text is converted into charcter array
            char[] arr = imageToDecrypt.ToCharArray();
            int i = 0, j = 0;
            string c = "", dc = "";
            progressBar2.Maximum = arr.Length;
            try
            {
                for (; i < arr.Length; i++)
                {
                    Application.DoEvents();
                    c = "";
                    progressBar2.Value = i;
                    //then the each letter disphers according to RSA 
                    for (j = i; arr[j] != '-'; j++)
                        c = c + arr[j];
                    i = j;
                    //then the decipher value is now convert into the orginial value
                    int xx = Convert.ToInt32(c);
                    dc = dc + ((char)Image_cryptography.RSA.mod(xx, d, n)).ToString();
                }
            }
            catch (Exception ex) { }
            ///and then return the string
            return dc;
        
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            //form1 object
            Form1 f = new Form1();

            button10.Enabled = false;
            
            String cipher_to_Decrypt = decrypt(cipher_load);
            f.pictureBox1.Image = Image_cryptography.main_img_convert.byte_to_img(Image_cryptography.main_img_convert.DecodeHex(cipher_to_Decrypt));
            MessageBox.Show("Successfully Decrypted");
            f.pictureBox1.Image.Save(textBox6.Text, System.Drawing.Imaging.ImageFormat.Jpeg);
            MessageBox.Show("Image Saved");
            button10.Enabled = true;
                   }
    }
}
