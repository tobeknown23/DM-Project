THIS IS THE CODE FOR ENCRYPTION CLASS.


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
    public partial class encrypt_here : Form
    {
        //taking some integres here for prime no.1,prime no.2 and for the key
        static int rsa_prime1 = 0;
        static int rsa_prime2 = 0;
        static int rsa_enc_key = 0;
     
        static int n = 0;

        public encrypt_here()
        {
            InitializeComponent();
        }




//FOR SETTING THE DETAILS IN THE FORM LIKE TO ENTER THE D AND N(PRIME NUM):
 //if any of the textbox is empty show a message incorrect RSA details and error
            if (button3.Text == "Set Details")
            {
                if (textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "")
                {
                    MessageBox.Show("Incorrect RSA details", "ERROR");
                }

                else
                {    
                    //otherwise convert the textbox value into integer
                    if (Image_cryptography.main_img_convert.ch_prime(Convert.ToInt16(textBox2.Text)))
                    {
                        rsa_prime1 = Convert.ToInt16(textBox2.Text);
                    }
                    else
                    {
                        //if the textbox value is empty show the message box with enter prime number
                        textBox2.Text = "";
                        MessageBox.Show("Enter Prime Number");
                        return;
                    }

                    //convert textbox2 value into integer
                    if (Image_cryptography.main_img_convert.ch_prime(Convert.ToInt16(textBox3.Text)))
                    {
                        rsa_prime2 = Convert.ToInt16(textBox3.Text);
                    }
                    else
                    {
                        //if textbox is empty show messagebox to enter prime number
                        textBox3.Text = "";
                        MessageBox.Show("Enter Prime Number");
                        return;
                    }

                    rsa_enc_key = Convert.ToInt32(textBox4.Text);
                    //prime no.1 textbox disable
                    textBox2.Enabled = false;
                    //prime no. 2 textbox disable
                    textBox3.Enabled = false;
                    //enter key 'd' is disable
                    textBox4.Enabled = false;
                    //button for 'set' is enable
                    button4.Enabled = true;
                    //message box display that details are set when we press on set details
                    MessageBox.Show("Details has been set!");
                    //button for reset details
                    button3.Text = "ReSet Details";
                }
            }
            else
            {
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                //otherwise enable all the textboxes 
                textBox2.Enabled = true;
                textBox3.Enabled = true;
                textBox4.Enabled = true;
                //and disable the set details button
                button4.Enabled = false;
                button3.Text = "Set Details";
            }
        }
        
        
        
    
        //a method for encryption which passes a string
        public string encrypt(string imgToEncrypt)
        {
            //image hex code is passed in this
            
            string hex_code = imgToEncrypt;
            //then string converted into character array
            char[] array = hex_code.ToCharArray();
            String c = "";
            //this is for progress bar loading
            progressBar1.Maximum = array.Length;
            //in this whole loop each letter is cipher using RSA till the length of array and the cipher text is saved on textfile
            for (int i = 0; i < array.Length; i++)
            {
                Application.DoEvents();
                progressBar1.Value = i;
                //
                if (c == "")
                    c = c + Image_cryptography.RSA.mod(array[i], rsa_enc_key, n);
                else
                    c = c + "-" + Image_cryptography.RSA.mod(array[i], rsa_enc_key, n);
            }
            return c;
        }

        


//CLICK TO ENCRYPT:
 private void button5_Click_1(object sender, EventArgs e)
        {
            //n is the product of p and q means both prime number
            n = Image_cryptography.RSA.mul_of_prime(rsa_prime1,rsa_prime2);
              
            button1.Enabled = false;
            //for image load
            String enc_to_cipher = encrypt(Form1.img_load);
            //write in file 
            File.WriteAllText(textBox5.Text, enc_to_cipher);
            //then display msg box that successfully encrypt
            MessageBox.Show("Successfully Encrypted");
            button1.Enabled = true;
        }
        
        
        
        
        
  //QUIT BUTTON:
   private void button1_Click(object sender, EventArgs e)
        {
            //on quit this will destroy the form
            this.Close();
            
        }
        
        
        
        
   //ON THE LOAD OF ENCYRPT FORM:
   private void encrypt_here_Load(object sender, EventArgs e)
        {
            //here enabling all the group boxes,textboxes,progress bar and button
            groupBox4.Enabled = true;
            textBox5.Enabled = true;
            button3.Enabled = true;
                button4.Enabled = true;
                button5.Enabled = true;
                progressBar1.Enabled = true;
                button1.Enabled = true;
                button2.Enabled = true;
   
        }
        
        
        
        
        
        
    // TO STORE THE FILE FOR ENCYRPTION:
        private void button4_Click_1(object sender, EventArgs e)
        {
            //dialog box object creatng s1
            SaveFileDialog s1 = new SaveFileDialog();
            //setting format in the form of text
            s1.Filter = "TEXT|*.txt";
            //if the result is ok 
            if (s1.ShowDialog() == DialogResult.OK)
            {
                //then set the filename in textbox 
                textBox5.Text = s1.FileName;
                button5.Enabled = true;
            }
            else
            {
                textBox5.Text = "";
                button5.Enabled = false;
            }

        }
        
        
        
        
        
        //WHEN CLICK ON DECRYPT BUTTON:
        private void button2_Click_1(object sender, EventArgs e)
        {
            //if click on decrypt button open that and close the encrypt form
            Decrypt_here dc = new Decrypt_here();
            dc.Show();
            this.Hide();
        }


