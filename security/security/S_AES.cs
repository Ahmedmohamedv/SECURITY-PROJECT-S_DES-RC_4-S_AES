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
    public partial class S_AES : Form
    {
        public S_AES()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string key = textBox4.Text;
            string plaintext = textBox5.Text;
            string[] w0 = new string[8];
            string[] w1 = new string[8];
            int[] w2 = new int[8];
            int[] w3 = new int[8];
            int[] w4 = new int[8];
            int[] w5 = new int[8];
            int j = 0;
            int k = 0;
            string[] RN = new string[8];
            int[] RC = new int[] { 1, 0, 0, 0, 0, 0, 0, 0 };
            int[] temp = new int[8];
            int[] RCC = new int[] { 0, 0, 1, 1, 0, 0, 0, 0 };
            int x1 = 0;
            int x2 = 0;
            int x3 = 0;
            int x4 = 0;
            for (int i = 0; i < key.Length; i++)
            {
                if (i < 8)
                {
                    w0[j] = key[i].ToString();
                    j++;
                }
                else
                {
                    w1[k] = key[i].ToString();
                    k++;
                }
            }
            k = 0;
            for (int i = 0; i < RN.Length; i++)
            {
                if (i < 4)
                {
                    RN[i] = w1[i + 4];
                }
                else
                {
                    RN[i] = w1[k];
                    k++;
                }
            }
            string x = "";
            for (int i = 0; i < 4; i++)
            {
                x += RN[i].ToString();
            }
            string y = "";
            for (int i = 4; i < 8; i++)
            {
                y += RN[i].ToString();
            }
            int[] SN0 = new int[] { 0000, 0001, 0010, 0011, 0100, 0101, 0110, 0111, 1000, 1001, 1010, 1011, 1100, 1101, 1110, 1111 };
            string[] sbox = new string[] { "1001", "0100", "1010", "1011", "1101", "0001", "1000", "0101", "0110", "0010", "0000", "0011", "1100", "1110", "1111", "0111" };
            for (int i = 0; i < SN0.Length; i++)
            {
                if (SN0[i] == Int32.Parse(x))
                {
                    x1 = i;
                }
                if (SN0[i] == Int32.Parse(y))
                {
                    x2 = i;
                }
            }
            x = sbox[x1].ToString();
            y = sbox[x2].ToString();
            string[] SN = new string[8];
            j = 0;
            for (int i = 0; i < SN.Length; i++)
            {
                if (i < 4)
                {
                    SN[i] = x[i].ToString();
                }
                else
                {
                    SN[i] = y[j].ToString();
                    j++;
                }
            }
            for (int i = 0; i < SN.Length; i++)
            {
                if (SN[i] == RC[i].ToString())
                {
                    temp[i] = 0;
                }
                if (SN[i] != RC[i].ToString())
                {
                    temp[i] = 1;
                }
            }
            for (int i = 0; i < temp.Length; i++)
            {
                if (temp[i] == Int32.Parse(w0[i]))
                {
                    w2[i] = 0;
                }
                if (temp[i] != Int32.Parse(w0[i]))
                {
                    w2[i] = 1;
                }
            }
            for (int i = 0; i < SN.Length; i++)
            {
                if (w1[i] == w2[i].ToString())
                {
                    w3[i] = 0;
                }
                if (w1[i] != w2[i].ToString())
                {
                    w3[i] = 1;
                }
            }
            k = 0;
            RN = new string[8];
            for (int i = 0; i < RN.Length; i++)
            {
                if (i < 4)
                {
                    RN[i] = w3[i + 4].ToString();
                }
                else
                {
                    RN[i] = w3[k].ToString();
                    k++;
                }
            }
            string z = "";
            for (int i = 0; i < 4; i++)
            {
                z += RN[i].ToString();
            }
            string xx = "";
            for (int i = 4; i < 8; i++)
            {
                xx += RN[i].ToString();
            }
            for (int i = 0; i < SN0.Length; i++)
            {
                if (SN0[i] == Int32.Parse(z))
                {
                    x3 = i;
                }
                if (SN0[i] == Int32.Parse(xx))
                {
                    x4 = i;
                }
            }
            z = sbox[x3].ToString();
            xx = sbox[x4].ToString();
            SN = new string[8];
            j = 0;
            for (int i = 0; i < SN.Length; i++)
            {
                if (i < 4)
                {
                    SN[i] = z[i].ToString();
                }
                else
                {
                    SN[i] = xx[j].ToString();
                    j++;
                }
            }

            for (int i = 0; i < SN.Length; i++)
            {
                if (SN[i] == RCC[i].ToString())
                {
                    temp[i] = 0;
                }
                if (SN[i] != RCC[i].ToString())
                {
                    temp[i] = 1;
                }
            }
            for (int i = 0; i < temp.Length; i++)
            {
                if (temp[i] == w2[i])
                {
                    w4[i] = 0;
                }
                if (temp[i] != w2[i])
                {
                    w4[i] = 1;
                }
            }

            for (int i = 0; i < w4.Length; i++)
            {
                if (w4[i] == w3[i])
                {
                    w5[i] = 0;
                }
                if (w4[i] != w3[i])
                {
                    w5[i] = 1;
                }
            }

            for (int i = 0; i < w0.Length; i++)
            {
                textBox1.Text += w0[i];
            }
            for (int i = 0; i < w1.Length; i++)
            {
                textBox1.Text += w1[i];
            }
            for (int i = 0; i < w2.Length; i++)
            {
                textBox2.Text += w2[i];
            }
            for (int i = 0; i < w3.Length; i++)
            {
                textBox2.Text += w3[i];
            }
            for (int i = 0; i < w4.Length; i++)
            {
                textBox3.Text += w4[i];
            }
            for (int i = 0; i < w5.Length; i++)
            {
                textBox3.Text += w5[i];
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
