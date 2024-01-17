using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projesozluk
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        WebBrowser ceviri= new WebBrowser();

        private void Form1_Load(object sender,EventArgs e)
        {
            try
            {
                //bing translateyi WebBrowser ile aç
                ceviri.Navigate("https://www.bing.com/translator/?from=tr&to=en");
                ceviri.ScriptErrorsSuppressed=true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //textBox1'e yazılırken çevir
            ceviri.Document.GetElementById("tta_input_ta").InnerText=textBox1.Text;
            timer1.Start();

        }
        
        int sayac= 0;
        private void timer1_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (sayac == 2) timer1.Stop();
                //çevirilen kelimeyi textBox2'ye getir
               textBox2.Text= ceviri.Document.GetElementById("tta_output_ta").InnerText;
                sayac++;
            }
            catch { }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                //girilen kelimeyi oku
                ceviri.Document.GetElementById("tta_playiconsrc").InvokeMember("Click");

            }
            catch { }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //çevirilen kelimeyi oku
            ceviri.Document.GetElementById("tta_playicontgt").InvokeMember("Click");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //dili değiştir
            if (label1.Text == "Türkçe") { label1.Text = "İngilizce"; label2.Text = "Türkçe"; }
            else { label2.Text = "İngilizce"; label1.Text = "Türkçe"; }
            ceviri.Document.GetElementById("tta_revIcon").InvokeMember("Click");

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
