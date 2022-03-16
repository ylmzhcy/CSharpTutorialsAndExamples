using System;
using System.Net;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace BtcStrategy
{
    public partial class Form1 : Form
    {

        string price;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            getPrices("BTC");
            getPrices("ETH");

        }

        void getPrices(string currencyCode)
        {
            string cryptoCurrencyCode = currencyCode;
            string countryCurrencyCode = "USD";
            string uri = string.Format("https://bitpay.com/rates/{0}/{1}", cryptoCurrencyCode, countryCurrencyCode);

            var client = new WebClient();
            client.UseDefaultCredentials = true;

            //Everything is returned inside of a "data" property, so let's select that token.
            string data = JObject.Parse(client.DownloadString(uri)).SelectToken("data").ToString();
            var rate = JsonConvert.DeserializeObject<RateModel>(data);

            price = cryptoCurrencyCode + " " + rate.Rate + " " + countryCurrencyCode;

            if (cryptoCurrencyCode == "BTC")
            {
                label2.Text = price;
            }
            else if (cryptoCurrencyCode == "ETH")
            {
                label1.Text = price;
            }


        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            getPrices("BTC");
            getPrices("ETH");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {



        }

        private void button1_Click(object sender, EventArgs e)
        {
            double calc = (Convert.ToDouble(textBox2.Text) / 100 * Convert.ToDouble(textBox1.Text) + Convert.ToDouble(textBox2.Text));
            textBox4.Text = calc.ToString();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                Form1.ActiveForm.TopMost = true;
            }
            else
            {
                Form1.ActiveForm.TopMost = false;

            }
        }
    }
}
