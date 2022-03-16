using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Number_Guessing
{
    public partial class Form1 : Form
    {
        Random rnd = new Random();
        int randomNum;
        int entryNum;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void CreateRandomNum(int firstNum,int secondNum)
        {
            randomNum = rnd.Next(firstNum, secondNum);
            //label2.Text = randomNum.ToString();
            label2.Text = "???";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtFirst.Text != "" && txtSecond.Text != "")
            {
                CreateRandomNum(Convert.ToInt32(txtFirst.Text), Convert.ToInt32(txtSecond.Text));
                btnStart.Enabled = false;
                txtFirst.Enabled = false;
                txtSecond.Enabled = false;
                btnTry.Enabled = true;
                label1.Text = "";
                txtEntry.Enabled = true;
                txtEntry.Text = "";
            }
            else
            {
                MessageBox.Show("Please Enter Numbers");
            }
        }

        private void btnTry_Click(object sender, EventArgs e)
        {
            if (txtEntry.Text != "")
            {
                entryNum = Convert.ToInt32(txtEntry.Text);

                if (entryNum <= randomNum)
                {
                    label1.Text = "Entry Num is Too Low!";
                }
                else if (entryNum >= randomNum)
                {
                    label1.Text = "Entry Num is Too High!";
                }
                
                if (entryNum == randomNum)
                {
                    label1.Text = "Correct !! You Win!";
                    label2.Text = randomNum.ToString();
                    btnStart.Enabled = true;
                    txtFirst.Enabled = true;
                    txtSecond.Enabled = true;
                    txtEntry.Enabled = false;
                    btnTry.Enabled = false;

                }
            }
            else
            {
                MessageBox.Show("Please enter Number");
            }
        }
    }
}
