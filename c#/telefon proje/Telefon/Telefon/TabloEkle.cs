using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Telefon
{
    public partial class TabloEkle : Form
    {
        string tabloadi;
        List<string> tabloadlari = new List<string>();   
        public TabloEkle(string tabloadlari,List<string> tabloadlarilistesi)
        {
            InitializeComponent();
            this.tabloadlari = tabloadlarilistesi;
            this.tabloadi = tabloadlari;
           
        }
        string tabloAdi()
        {
            VeriTabaiStok vt_stok = new VeriTabaiStok();
            string birlestir = "";
            for (int i = 0; i < tabloadi.Length; i++)
            {
               
                if (char.IsUpper(tabloadi[i]) && i > 0)
                {
                    birlestir += "_";
                }
                birlestir += tabloadi[i];
            }
            birlestir = string.Concat("Table_", birlestir);

            return birlestir; 

        }
        private void TabloEkle_Load(object sender, EventArgs e)
        {


            this.Text = tabloadi;
           
           
           

        }
     
        VeriTabaiStok vt_stok = new VeriTabaiStok(); 

        private void button1_Click(object sender, EventArgs e)
        {

                
                    if (DialogResult.OK == MessageBox.Show("Eklemeyi Onayla","Ekleme Onay",MessageBoxButtons.OKCancel))
                    {
                        vt_stok.tabloyaEkle(tabloAdi(), textBox1.Text);
                        
                      
                       
                    }
                    else
                    {
                        MessageBox.Show("İşlem İptal Edildi");
                    }
                

            
            textBox1.Clear();
            textBox1.Focus();
        }

        
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (string.Equals(tabloAdi(), "Table_Hat_Sayisi", StringComparison.OrdinalIgnoreCase))
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
            if (string.Equals(tabloAdi(), "Table_Hafiza_Karti_Destegi", StringComparison.OrdinalIgnoreCase))
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
            if (string.Equals(tabloAdi(), "Table_Cikis_Yili", StringComparison.OrdinalIgnoreCase))
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            }

        }

        private void TabloEkle_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1.PerformClick();
            }
        }
    }
}
