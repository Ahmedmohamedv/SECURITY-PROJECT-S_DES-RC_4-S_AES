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
    public partial class S_DES : Form
    {
        public S_DES()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int[] p10 = new int[] { 3, 5, 2, 7, 4, 10, 1, 9, 8, 6 };
            int[] p8 = new int[] { 6, 3, 7, 4, 8, 5, 10, 9 };
            int[] p4 = new int[] { 2, 4, 3, 1 };
            int[] ip = new int[] { 2, 6, 3, 1, 4, 8, 5, 7 };
            int[] ip_inv = new int[] { 1, 4, 3, 5, 7, 2, 8, 6 };
            int[] EP = new int[] { 4, 1, 2, 3, 2, 3, 4, 1 };

            string key = textBox1.Text;
            string[] Stringkey = new string[key.Length];
            for (int i = 0; i <= 9; i++)
            {
                Stringkey[i] += key[i].ToString();
            }

            string[] Stringp10 = new string[10];
            for (int i = 0; i < Stringkey.Length; i++)
            {
                Stringp10[i] = Stringkey[p10[i] - 1];
            }

            string[] firsthalf = new string[5];
            string[] secondhalf = new string[5];
            for (int i = 0; i < Stringkey.Length; i++)
            {

                Stringkey[i] = Stringp10[i];
                if (i >= 0 && i < 5)
                {
                    firsthalf[i] = Stringkey[i];
                }
                else if (i >= 5 && i < 10)
                {
                    secondhalf[i - 5] = Stringkey[i];
                }
            }

            string[] firstLshift = new string[5];
            string[] firstRshift = new string[5];
            for (int i = 0; i < firsthalf.Length; i++)
            {
                if (i == 0)
                {
                    firstLshift[firstLshift.Length - 1] = firsthalf[i];
                }
                else
                {
                    firstLshift[i - 1] = firsthalf[i];
                }
            }
            for (int i = 0; i <= 4; i++)
            {
                Stringkey[i] = firstLshift[i];
            }

            for (int i = 0; i < secondhalf.Length; i++)
            {
                if (i == 0)
                {
                    firstRshift[firstRshift.Length - 1] = secondhalf[i];
                }
                else
                {
                    firstRshift[i - 1] = secondhalf[i];
                }
            }
            for (int i = 5; i <= 9; i++)
            {
                Stringkey[i] = firstRshift[i - 5];
            }

            string[] key1 = new string[8];
            for (int i = 0; i < p8.Length; i++)
            {
                key1[i] = Stringkey[p8[i] - 1];
            }

            string[] secondLshift = new string[5];
            string[] secondRshift = new string[5];
            for (int i = 1; i < secondLshift.Length; i++)
            {
                if (i == 1)
                {
                    secondLshift[secondLshift.Length - 2] = firstLshift[0];
                    secondLshift[secondLshift.Length - 1] = firstLshift[1];
                }
                else
                {
                    secondLshift[i - 2] = firstLshift[i];
                }
            }
            for (int i = 0; i <= 4; i++)
            {
                Stringkey[i] = secondLshift[i];
            }

            for (int i = 1; i < secondRshift.Length; i++)
            {
                if (i == 1)
                {
                    secondRshift[secondRshift.Length - 2] = firstRshift[0];
                    secondRshift[secondRshift.Length - 1] = firstRshift[1];
                }
                else
                {
                    secondRshift[i - 2] = firstRshift[i];
                }
            }
            for (int i = 5; i <= 9; i++)
            {
                Stringkey[i] = secondRshift[i - 5];
            }

            string[] key2 = new string[8];
            for (int i = 0; i < p8.Length; i++)
            {
                key2[i] = Stringkey[p8[i] - 1];
            }

            string plain = textBox2.Text;
            string[] Stringplain = new string[plain.Length];
            for (int i = 0; i <= 7; i++)
            {
                Stringplain[i] += plain[i].ToString();
            }
            string[] StringIp = new string[8];
            for (int i = 0; i < Stringplain.Length; i++)
            {
                StringIp[i] = Stringplain[ip[i] - 1];
            }

            string[] Left = new string[4];
            string[] Right = new string[4];
            string[] Down = new string[4];
            for (int i = 0; i < ip.Length; i++)
            {
                if (i <= 3)
                {
                    Left[i] = Stringplain[ip[i] - 1];
                }
                else
                {
                    Right[i - 4] = Stringplain[ip[i] - 1];
                    Down[i - 4] = Stringplain[ip[i] - 1];
                }
            }

            for (int i = 0; i < EP.Length; i++)
            {
                Stringplain[i] = Down[EP[i] - 1];
            }

            int[] Xor = new int[8];
            int[] Leftd = new int[4];
            int[] Rightd = new int[4];
            for (int i = 0; i < key1.Length; i++)
            {
                if (key1[i] == Stringplain[i])
                {
                    Xor[i] = 0;
                }
                else
                {
                    Xor[i] = 1;
                }
                if (i <= 3)
                {
                    Leftd[i] = Xor[i];
                }
                else
                {
                    Rightd[i - 4] = Xor[i];
                }
            }
            int[,] s0 = new int[4, 4] { { 1, 0, 3, 2 }, { 3, 2, 1, 0 }, { 0, 2, 1, 3 }, { 3, 1, 3, 2 } };
            int[,] s1 = new int[4, 4] { { 0, 1, 2, 3, }, { 2, 0, 1, 3 }, { 3, 0, 1, 0 }, { 2, 1, 0, 3 } };
            int b1;
            int b2;
            int sb1;
            int tb2;
            int r = 0;
            int c = 0;
            int b3;
            int b4;
            int sb3;
            int tb4;
            int c2 = 0;
            int r2 = 0;
            b1 = Leftd[0];
            b2 = Leftd[3];
            sb1 = Leftd[1];
            tb2 = Leftd[2];
            b3 = Rightd[0];
            b4 = Rightd[3];
            sb3 = Rightd[1];
            tb4 = Rightd[2];

            if (b1 == 0 && b2 == 0)
            {
                r = 0;
            }
            if (b1 == 0 && b2 == 1)
            {
                r = 1;
            }
            if (b1 == 1 && b2 == 0)
            {
                r = 2;
            }
            if (b1 == 1 && b2 == 1)
            {
                r = 3;
            }
            if (sb1 == 0 && tb2 == 0)
            {
                c = 0;
            }
            if (sb1 == 0 && tb2 == 1)
            {
                c = 1;
            }
            if (sb1 == 1 && tb2 == 0)
            {
                c = 2;
            }
            if (sb1 == 1 && tb2 == 1)
            {
                c = 3;
            }
            if (b3 == 0 && b4 == 0)
            {
                r2 = 0;
            }
            if (b3 == 0 && b4 == 1)
            {
                r2 = 1;
            }
            if (b3 == 1 && b4 == 0)
            {
                r2 = 2;
            }
            if (b3 == 1 && b4 == 1)
            {
                r2 = 3;
            }
            if (sb3 == 0 && tb4 == 0)
            {
                c2 = 0;
            }
            if (sb3 == 0 && tb4 == 1)
            {
                c2 = 1;
            }
            if (sb3 == 1 && tb4 == 0)
            {
                c2 = 2;
            }
            if (sb3 == 1 && tb4 == 1)
            {
                c2 = 3;
            }

            int Decs0 = s0[r, c];
            int Decs1 = s1[r2, c2];
            int[] binaryLeft = new int[2];
            int[] binaryRight = new int[2];
            if (Decs0 == 0)
            {
                binaryLeft[0] = 0;
                binaryLeft[1] = 0;
            }
            else if (Decs0 == 1)
            {
                binaryLeft[0] = 0;
                binaryLeft[1] = 1;
            }
            else if (Decs0 == 2)
            {
                binaryLeft[0] = 1;
                binaryLeft[1] = 0;
            }
            else if (Decs0 == 3)
            {
                binaryLeft[0] = 1;
                binaryLeft[1] = 1;
            }

            if (Decs1 == 0)
            {
                binaryRight[0] = 0;
                binaryRight[1] = 0;
            }
            else if (Decs1 == 1)
            {
                binaryRight[0] = 0;
                binaryRight[1] = 1;
            }
            else if (Decs1 == 2)
            {
                binaryRight[0] = 1;
                binaryRight[1] = 0;
            }
            else if (Decs1 == 3)
            {
                binaryRight[0] = 1;
                binaryRight[1] = 1;
            }
            int[] swapt = new int[4];
            swapt[0] = binaryLeft[0];
            swapt[1] = binaryLeft[1];
            swapt[2] = binaryRight[0];
            swapt[3] = binaryRight[1];

            int[] swapt1 = new int[4];
            for (int i = 0; i < swapt.Length; i++)
            {
                swapt1[i] = swapt[p4[i] - 1];
            }

            int[] swap = new int[4];
            for (int i = 0; i < swapt1.Length; i++)
            {
                if (swapt1[i] == Int32.Parse(Left[i]))
                {
                    swap[i] = 0;
                }
                else
                {
                    swap[i] = 1;
                }

            }

            int[] message = new int[8];
            for (int i = 0; i < EP.Length; i++)
            {
                message[i] = swap[EP[i] - 1];
            }

            for (int i = 0; i < key2.Length; i++)
            {
                if (Int32.Parse(key2[i]) == message[i])
                {
                    Xor[i] = 0;
                }
                else
                {
                    Xor[i] = 1;
                }
                if (i <= 3)
                {
                    Leftd[i] = Xor[i];
                }
                else
                {
                    Rightd[i - 4] = Xor[i];
                }
            }
            b1 = Leftd[0];
            b1 = Leftd[3];
            sb1 = Leftd[1];
            tb2 = Leftd[2];
            b3 = Rightd[0];
            b4 = Rightd[3];
            sb3 = Rightd[1];
            tb4 = Rightd[2];
            if (b1 == 0 && b1 == 0)
            {
                r = 0;
            }
            if (b1 == 0 && b1 == 1)
            {
                r = 1;
            }
            if (b1 == 1 && b1 == 0)
            {
                r = 2;
            }
            if (b1 == 1 && b1 == 1)
            {
                r = 3;
            }
            if (sb1 == 0 && tb2 == 0)
            {
                c = 0;
            }
            if (sb1 == 0 && tb2 == 1)
            {
                c = 1;
            }
            if (sb1 == 1 && tb2 == 0)
            {
                c = 2;
            }
            if (sb1 == 1 && tb2 == 1)
            {
                c = 3;
            }

            if (b3 == 0 && b4 == 0)
            {
                r2 = 0;
            }
            if (b3 == 0 && b4 == 1)
            {
                r2 = 1;
            }
            if (b3 == 1 && b4 == 0)
            {
                r2 = 2;
            }
            if (b3 == 1 && b4 == 1)
            {
                r2 = 3;
            }

            if (sb3 == 0 && tb4 == 0)
            {
                c2 = 0;
            }
            if (sb3 == 0 && tb4 == 1)
            {
                c2 = 1;
            }
            if (sb3 == 1 && tb4 == 0)
            {
                c2 = 2;
            }
            if (sb3 == 1 && tb4 == 1)
            {
                c2 = 3;
            }

            Decs0 = s0[r, c];
            Decs1 = s1[r2, c2];
            binaryLeft = new int[2];
            binaryRight = new int[2];
            if (Decs0 == 0)
            {
                binaryLeft[0] = 0;
                binaryLeft[1] = 0;
            }
            else if (Decs0 == 1)
            {
                binaryLeft[0] = 0;
                binaryLeft[1] = 1;
            }
            else if (Decs0 == 2)
            {
                binaryLeft[0] = 1;
                binaryLeft[1] = 0;
            }
            else if (Decs0 == 3)
            {
                binaryLeft[0] = 1;
                binaryLeft[1] = 1;
            }

            if (Decs1 == 0)
            {
                binaryRight[0] = 0;
                binaryRight[1] = 0;
            }
            if (Decs1 == 1)
            {
                binaryRight[0] = 0;
                binaryRight[1] = 1;
            }
            if (Decs1 == 2)
            {
                binaryRight[0] = 1;
                binaryRight[1] = 0;
            }
            if (Decs1 == 3)
            {
                binaryRight[0] = 1;
                binaryRight[1] = 1;
            }
            swapt = new int[4];
            swapt[0] = binaryLeft[0];
            swapt[1] = binaryLeft[1];
            swapt[2] = binaryRight[0];
            swapt[3] = binaryRight[1];

            swapt1 = new int[4];
            for (int i = 0; i < swapt.Length; i++)
            {
                swapt1[i] = swapt[p4[i] - 1];
            }

            int[] Xor2 = new int[4];
            for (int i = 0; i < swapt1.Length; i++)
            {
                if (swapt1[i] == Int32.Parse(Down[i]))
                {
                    Xor2[i] = 0;
                    Xor[i] = Xor2[i];
                }
                else
                {
                    Xor2[i] = 1;
                    Xor[i] = Xor2[i];
                }

            }
            for (int i = 4; i < Xor.Length; i++)
            {
                Xor[i] = swap[i - 4];
            }
            int[] ciphertext = new int[8];
            for (int i = 0; i < Xor.Length; i++)
            {
                ciphertext[i] = Xor[ip_inv[i] - 1];

            }
            textBox3.Text = "";
            for (int i = 0; i < ciphertext.Length; i++)
            {
                textBox3.Text += ciphertext[i];
            }






        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int[] p10 = new int[] { 3, 5, 2, 7, 4, 10, 1, 9, 8, 6 };
            int[] p8 = new int[] { 6, 3, 7, 4, 8, 5, 10, 9 };
            int[] p4 = new int[] { 2, 4, 3, 1 };
            int[] ip = new int[] { 2, 6, 3, 1, 4, 8, 5, 7 };
            int[] ip_inv = new int[] { 1, 4, 3, 5, 7, 2, 8, 6 };
            int[] EP = new int[] { 4, 1, 2, 3, 2, 3, 4, 1 };

            string key = textBox1.Text;
            string[] Stringkey = new string[key.Length];
            for (int i = 0; i <= 9; i++)
            {
                Stringkey[i] += key[i].ToString();
            }

            string[] Stringp10 = new string[10];
            for (int i = 0; i < Stringkey.Length; i++)
            {
                Stringp10[i] = Stringkey[p10[i] - 1];
            }

            string[] firsthalf = new string[5];
            string[] secondhalf = new string[5];
            for (int i = 0; i < Stringkey.Length; i++)
            {

                Stringkey[i] = Stringp10[i];
                if (i >= 0 && i < 5)
                {
                    firsthalf[i] = Stringkey[i];
                }
                else if (i >= 5 && i < 10)
                {
                    secondhalf[i - 5] = Stringkey[i];
                }
            }

            string[] firstLshift = new string[5];
            string[] firstRshift = new string[5];
            for (int i = 0; i < firsthalf.Length; i++)
            {
                if (i == 0)
                {
                    firstLshift[firstLshift.Length - 1] = firsthalf[i];
                }
                else
                {
                    firstLshift[i - 1] = firsthalf[i];
                }
            }
            for (int i = 0; i <= 4; i++)
            {
                Stringkey[i] = firstLshift[i];
            }

            for (int i = 0; i < secondhalf.Length; i++)
            {
                if (i == 0)
                {
                    firstRshift[firstRshift.Length - 1] = secondhalf[i];
                }
                else
                {
                    firstRshift[i - 1] = secondhalf[i];
                }
            }
            for (int i = 5; i <= 9; i++)
            {
                Stringkey[i] = firstRshift[i - 5];
            }

            string[] key1 = new string[8];
            for (int i = 0; i < p8.Length; i++)
            {
                key1[i] = Stringkey[p8[i] - 1];
            }

            string[] secondLshift = new string[5];
            string[] secondRshift = new string[5];
            for (int i = 1; i < secondLshift.Length; i++)
            {
                if (i == 1)
                {
                    secondLshift[secondLshift.Length - 2] = firstLshift[0];
                    secondLshift[secondLshift.Length - 1] = firstLshift[1];
                }
                else
                {
                    secondLshift[i - 2] = firstLshift[i];
                }
            }
            for (int i = 0; i <= 4; i++)
            {
                Stringkey[i] = secondLshift[i];
            }

            for (int i = 1; i < secondRshift.Length; i++)
            {
                if (i == 1)
                {
                    secondRshift[secondRshift.Length - 2] = firstRshift[0];
                    secondRshift[secondRshift.Length - 1] = firstRshift[1];
                }
                else
                {
                    secondRshift[i - 2] = firstRshift[i];
                }
            }
            for (int i = 5; i <= 9; i++)
            {
                Stringkey[i] = secondRshift[i - 5];
            }

            string[] key2 = new string[8];
            for (int i = 0; i < p8.Length; i++)
            {
                key2[i] = Stringkey[p8[i] - 1];
            }

            string plain = textBox2.Text;
            string[] Stringplain = new string[plain.Length];
            for (int i = 0; i <= 7; i++)
            {
                Stringplain[i] += plain[i].ToString();
            }
            string[] StringIp = new string[8];
            for (int i = 0; i < Stringplain.Length; i++)
            {
                StringIp[i] = Stringplain[ip[i] - 1];
            }

            string[] Left = new string[4];
            string[] Right = new string[4];
            string[] Down = new string[4];
            for (int i = 0; i < ip.Length; i++)
            {
                if (i <= 3)
                {
                    Left[i] = Stringplain[ip[i] - 1];
                }
                else
                {
                    Right[i - 4] = Stringplain[ip[i] - 1];
                    Down[i - 4] = Stringplain[ip[i] - 1];
                }
            }

            for (int i = 0; i < EP.Length; i++)
            {
                Stringplain[i] = Down[EP[i] - 1];
            }

            int[] Xor = new int[8];
            int[] Leftd = new int[4];
            int[] Rightd = new int[4];
            for (int i = 0; i < key1.Length; i++)
            {
                if (key1[i] == Stringplain[i])
                {
                    Xor[i] = 0;
                }
                else
                {
                    Xor[i] = 1;
                }
                if (i <= 3)
                {
                    Leftd[i] = Xor[i];
                }
                else
                {
                    Rightd[i - 4] = Xor[i];
                }
            }
            int[,] s0 = new int[4, 4] { { 1, 0, 3, 2 }, { 3, 2, 1, 0 }, { 0, 2, 1, 3 }, { 3, 1, 3, 2 } };
            int[,] s1 = new int[4, 4] { { 0, 1, 2, 3, }, { 2, 0, 1, 3 }, { 3, 0, 1, 0 }, { 2, 1, 0, 3 } };
            int b1;
            int b2;
            int sb1;
            int tb2;
            int r = 0;
            int c = 0;
            int b3;
            int b4;
            int sb3;
            int tb4;
            int c2 = 0;
            int r2 = 0;
            b1 = Leftd[0];
            b2 = Leftd[3];
            sb1 = Leftd[1];
            tb2 = Leftd[2];
            b3 = Rightd[0];
            b4 = Rightd[3];
            sb3 = Rightd[1];
            tb4 = Rightd[2];

            if (b1 == 0 && b2 == 0)
            {
                r = 0;
            }
            if (b1 == 0 && b2 == 1)
            {
                r = 1;
            }
            if (b1 == 1 && b2 == 0)
            {
                r = 2;
            }
            if (b1 == 1 && b2 == 1)
            {
                r = 3;
            }
            if (sb1 == 0 && tb2 == 0)
            {
                c = 0;
            }
            if (sb1 == 0 && tb2 == 1)
            {
                c = 1;
            }
            if (sb1 == 1 && tb2 == 0)
            {
                c = 2;
            }
            if (sb1 == 1 && tb2 == 1)
            {
                c = 3;
            }
            if (b3 == 0 && b4 == 0)
            {
                r2 = 0;
            }
            if (b3 == 0 && b4 == 1)
            {
                r2 = 1;
            }
            if (b3 == 1 && b4 == 0)
            {
                r2 = 2;
            }
            if (b3 == 1 && b4 == 1)
            {
                r2 = 3;
            }
            if (sb3 == 0 && tb4 == 0)
            {
                c2 = 0;
            }
            if (sb3 == 0 && tb4 == 1)
            {
                c2 = 1;
            }
            if (sb3 == 1 && tb4 == 0)
            {
                c2 = 2;
            }
            if (sb3 == 1 && tb4 == 1)
            {
                c2 = 3;
            }

            int Decs0 = s0[r, c];
            int Decs1 = s1[r2, c2];
            int[] binaryLeft = new int[2];
            int[] binaryRight = new int[2];
            if (Decs0 == 0)
            {
                binaryLeft[0] = 0;
                binaryLeft[1] = 0;
            }
            else if (Decs0 == 1)
            {
                binaryLeft[0] = 0;
                binaryLeft[1] = 1;
            }
            else if (Decs0 == 2)
            {
                binaryLeft[0] = 1;
                binaryLeft[1] = 0;
            }
            else if (Decs0 == 3)
            {
                binaryLeft[0] = 1;
                binaryLeft[1] = 1;
            }

            if (Decs1 == 0)
            {
                binaryRight[0] = 0;
                binaryRight[1] = 0;
            }
            else if (Decs1 == 1)
            {
                binaryRight[0] = 0;
                binaryRight[1] = 1;
            }
            else if (Decs1 == 2)
            {
                binaryRight[0] = 1;
                binaryRight[1] = 0;
            }
            else if (Decs1 == 3)
            {
                binaryRight[0] = 1;
                binaryRight[1] = 1;
            }
            int[] swapt = new int[4];
            swapt[0] = binaryLeft[0];
            swapt[1] = binaryLeft[1];
            swapt[2] = binaryRight[0];
            swapt[3] = binaryRight[1];

            int[] swapt1 = new int[4];
            for (int i = 0; i < swapt.Length; i++)
            {
                swapt1[i] = swapt[p4[i] - 1];
            }

            int[] swap = new int[4];
            for (int i = 0; i < swapt1.Length; i++)
            {
                if (swapt1[i] == Int32.Parse(Left[i]))
                {
                    swap[i] = 0;
                }
                else
                {
                    swap[i] = 1;
                }

            }

            int[] message = new int[8];
            for (int i = 0; i < EP.Length; i++)
            {
                message[i] = swap[EP[i] - 1];
            }

            for (int i = 0; i < key2.Length; i++)
            {
                if (Int32.Parse(key2[i]) == message[i])
                {
                    Xor[i] = 0;
                }
                else
                {
                    Xor[i] = 1;
                }
                if (i <= 3)
                {
                    Leftd[i] = Xor[i];
                }
                else
                {
                    Rightd[i - 4] = Xor[i];
                }
            }
            b1 = Leftd[0];
            b1 = Leftd[3];
            sb1 = Leftd[1];
            tb2 = Leftd[2];
            b3 = Rightd[0];
            b4 = Rightd[3];
            sb3 = Rightd[1];
            tb4 = Rightd[2];
            if (b1 == 0 && b1 == 0)
            {
                r = 0;
            }
            if (b1 == 0 && b1 == 1)
            {
                r = 1;
            }
            if (b1 == 1 && b1 == 0)
            {
                r = 2;
            }
            if (b1 == 1 && b1 == 1)
            {
                r = 3;
            }
            if (sb1 == 0 && tb2 == 0)
            {
                c = 0;
            }
            if (sb1 == 0 && tb2 == 1)
            {
                c = 1;
            }
            if (sb1 == 1 && tb2 == 0)
            {
                c = 2;
            }
            if (sb1 == 1 && tb2 == 1)
            {
                c = 3;
            }

            if (b3 == 0 && b4 == 0)
            {
                r2 = 0;
            }
            if (b3 == 0 && b4 == 1)
            {
                r2 = 1;
            }
            if (b3 == 1 && b4 == 0)
            {
                r2 = 2;
            }
            if (b3 == 1 && b4 == 1)
            {
                r2 = 3;
            }

            if (sb3 == 0 && tb4 == 0)
            {
                c2 = 0;
            }
            if (sb3 == 0 && tb4 == 1)
            {
                c2 = 1;
            }
            if (sb3 == 1 && tb4 == 0)
            {
                c2 = 2;
            }
            if (sb3 == 1 && tb4 == 1)
            {
                c2 = 3;
            }

            Decs0 = s0[r, c];
            Decs1 = s1[r2, c2];
            binaryLeft = new int[2];
            binaryRight = new int[2];
            if (Decs0 == 0)
            {
                binaryLeft[0] = 0;
                binaryLeft[1] = 0;
            }
            else if (Decs0 == 1)
            {
                binaryLeft[0] = 0;
                binaryLeft[1] = 1;
            }
            else if (Decs0 == 2)
            {
                binaryLeft[0] = 1;
                binaryLeft[1] = 0;
            }
            else if (Decs0 == 3)
            {
                binaryLeft[0] = 1;
                binaryLeft[1] = 1;
            }

            if (Decs1 == 0)
            {
                binaryRight[0] = 0;
                binaryRight[1] = 0;
            }
            if (Decs1 == 1)
            {
                binaryRight[0] = 0;
                binaryRight[1] = 1;
            }
            if (Decs1 == 2)
            {
                binaryRight[0] = 1;
                binaryRight[1] = 0;
            }
            if (Decs1 == 3)
            {
                binaryRight[0] = 1;
                binaryRight[1] = 1;
            }
            swapt = new int[4];
            swapt[0] = binaryLeft[0];
            swapt[1] = binaryLeft[1];
            swapt[2] = binaryRight[0];
            swapt[3] = binaryRight[1];

            swapt1 = new int[4];
            for (int i = 0; i < swapt.Length; i++)
            {
                swapt1[i] = swapt[p4[i] - 1];
            }

            int[] Xor2 = new int[4];
            for (int i = 0; i < swapt1.Length; i++)
            {
                if (swapt1[i] == Int32.Parse(Down[i]))
                {
                    Xor2[i] = 0;
                    Xor[i] = Xor2[i];
                }
                else
                {
                    Xor2[i] = 1;
                    Xor[i] = Xor2[i];
                }

            }
         
            int[] ciphertext = new int[8];
            for (int i = 0; i < Xor.Length; i++)
            {
                ciphertext[i] = Xor[ip_inv[i] - 1];

            }
            textBox3.Text = "";
            for (int i = 0; i < ciphertext.Length; i++)
            {
                textBox5.Text += ciphertext[i];
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
