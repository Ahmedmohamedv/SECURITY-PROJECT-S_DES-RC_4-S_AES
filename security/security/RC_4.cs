using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace security
{
    public partial class RC_4 : Form
    {
        public RC_4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string key = textBox1.Text;
            string[] Stringt = new string[8];
            string plain = textBox3.Text;
            string[] Stringp = new string[plain.Length];
            string[] Stringpp = new string[plain.Length];

            string t = textBox2.Text;
            string[] Strings = new string[t.Length];

            //string[] Stringc = new string[t.Length];

            int[] cc = new int[13];
            int[] ck = new int[13];
            int[] cpp = new int[13];
            int[] J= new int[Stringt.Length];
            int n = 0;
            int i;
            string kk;
            for (i = 0; i < 8; i++)
            {
                Strings[i] += t[i].ToString();

            }
            for (i = 0; i < plain.Length; i++)
            {
                Stringp[i] += plain[i].ToString();
            }
            for (i = 0; i < key.Length; i++)
            {
                Stringt[i] += key[i].ToString();
                Stringt[i+4] += key[i].ToString();
             
            }
            int[] st = Array.ConvertAll(Stringt, int.Parse);
            int[] ss = Array.ConvertAll(Strings, int.Parse);
            int[] pp = Array.ConvertAll(Stringp, int.Parse);
            //int[] ppp = Array.ConvertAll(Stringpp, int.Parse);
            //int[] cc = Array.ConvertAll(Stringc, int.Parse);



            int j = 0;
            int x;
            // int[] j = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8 };
            for (int m = 0; m < Stringt.Length; m++)
            {

                J[m] = (st[m] + ss[m] + J[m]) % 8;
                x = J[m];
                J[m] = ss[m];
             
           
               


            }
            j = 0;
            int s = 0;
            int k = 0;
            int nk;
            int np;
            int c1;
            int c2;
            int c3;
            int c4;
            int c;


            for (i = 0; i < 4; i++)
            {
                i = (i + 1) % 8;
                J[i] = (J[i] + ss[i]) % 8;
                J[i] = (ss[i] + j) % 8;
                x = J[i];
                J[i] = ss[i];
                
               
                s = (ss[i] + J[i]) % 8;
                k = s;


                if (k == 0)
                {
                    for (int mm = 0; mm <=3; mm++)
                    {
                        ck[1] = 0;
                        ck[2] = 0;
                        ck[3] = 0;
                    }
                }
                if (k == 1)
                {
                    for (int mm = 0; mm <= 3; mm++)
                    {
                        ck[1] = 0;
                        ck[2] = 0;
                        ck[3] = 1;
                    }
                  
                }
                if (k == 2)
                {
                    for (int mm = 0; mm <=3; mm++)
                    {
                        ck[1] = 0;
                        ck[2] = 1;
                        ck[3] = 0;
                    }
                  
                }
                if (k == 3)
                {
                    for (int mm = 0; mm <=3; mm++)
                    {
                        ck[1] = 0;
                        ck[2] = 1;
                        ck[3] = 1;
                    }
                   
                }
                if (k == 4)
                {
                    for (int mm = 0; mm <= 3; mm++)
                    {
                        ck[1] = 1;
                        ck[2] = 0;
                        ck[3] = 0;
                    }
                   
                }
                if (k == 5)
                {
                    for (int mm = 0; mm <=3; mm++)
                    {
                        ck[1] = 1;
                        ck[2] = 0;
                        ck[3] = 1;
                    }
               
                }
                if (k == 6)
                {
                    for (int mm = 0; mm <= 3; mm++)
                    {
                        ck[1] = 1;
                        ck[2] = 1;
                        ck[3] = 0;
                    }
                  
                }
                if (k == 7)
                {
                    for (int mm = 0; mm <= 3; mm++)
                    {
                        ck[1] = 1;
                        ck[2] = 1;
                        ck[3] = 1;
                    }
                 }



                if (pp[i] == 0)
                {
                    for(int mmm=0;mmm<=3;mmm++)
                    {
                        cpp[0] = 0;
                        cpp[0] = 0;
                        cpp[0] = 0;

                    }
                   
                }
                if (pp[i] == 1)
                {
                    for (int mmm = 0; mmm <= 3; mmm++)
                    {
                        cpp[0] = 0;
                        cpp[0] = 0;
                        cpp[0] = 1;

                    }
                    
                }
                if (pp[i] == 2)
                {
                    for (int mmm = 0; mmm <= 3; mmm++)
                    {
                        cpp[0] = 0;
                        cpp[0] = 1;
                        cpp[0] = 0;

                    }
                    
                }
                if (pp[i] == 3)
                {
                    for (int mmm = 0; mmm <=3; mmm++)
                    {
                        cpp[0] = 0;
                        cpp[0] = 1;
                        cpp[0] = 1;

                    }
                   
                }
                if (pp[i] == 4)
                {
                    for (int mmm = 0; mmm <=3; mmm++)
                    {
                        cpp[0] = 1;
                        cpp[0] = 0;
                        cpp[0] = 0;

                    }
                  
                }
                if (pp[i] == 5)
                {
                    for (int mmm = 0; mmm <=3; mmm++)
                    {
                        cpp[0] = 1;
                        cpp[0] = 0;
                        cpp[0] = 1;

                    }
              
                }
                if (pp[i] == 6)
                {
                    for (int mmm = 0; mmm <= 3; mmm++)
                    {
                        cpp[0] = 1;
                        cpp[0] = 1;
                        cpp[0] = 0;

                    }
                  
                }
                if (pp[i] == 7)
                {
                    for (int mmm = 0; mmm <=3; mmm++)
                    {
                        cpp[0] = 1;
                        cpp[0] = 1;
                        cpp[0] = 1;

                    }
                }
                
                
                    
               for ( int cccc=0;cccc<3;cccc++)
                {
                    if(ck[cccc]==cpp[cccc])
                    {
                        cc[cccc] = 0;
                    }
                    else
                    {
                        cc[cccc] = 1;
                    }
                }
               






                textBox4.Text ="" ;
                for (i = 0; i < cc.Length; i++)
                {
                    textBox4.Text += cc[i];
                }
                for (i = 0; i < ck.Length; i++)
                {
                    textBox5.Text += ck[i];
                }

                for (i = 0; i < cpp.Length; i++)
                {
                    textBox6.Text += cpp[i];
                }


            }



        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
    }

}
    
