using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AyseNurProje
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Application.Exit(); 
        }

        private void btn_genel_Click(object sender, EventArgs e)
        {
            Genel_islemler gnl = new Genel_islemler();
            gnl.ShowDialog();
           // this.Hide(); 
        }

        private void btn_satıs_Click(object sender, EventArgs e)
        {
            Satis_İslemlerş sts = new Satis_İslemlerş();
            sts.ShowDialog();
            this.Hide();
        }

        private void btn_stok_Click(object sender, EventArgs e)
        {
            Stok stok = new Stok();
            stok.Show();
            this.Hide();
        }
    }
}
