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
    public partial class StokArttır : Form
    {
        public StokArttır()
        {
            InitializeComponent();
        }

        private void StokArttır_Load(object sender, EventArgs e)
        {

            listele();
        }
        void listele()
        {
            dtgrid_telefon.DataSource = vt_satis.stokListele(1);
        }
        VeriTabaniSatisIslemleri vt_satis = new VeriTabaniSatisIslemleri();
      

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            dtgrid_telefon.DataSource = vt_satis.stokFiltrele(textBox1.Text);
        }

        private void dtgrid_telefon_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }
      
      
       void yaz()
        {
            label6.Text = dtgrid_telefon.CurrentRow.Cells["Marka"].Value.ToString();
            label7.Text = dtgrid_telefon.CurrentRow.Cells["StokAdeti"].Value.ToString();
            label8.Text = dtgrid_telefon.CurrentRow.Cells["TelefonID"].Value.ToString();
            label9.Text = dtgrid_telefon.CurrentRow.Cells["Renk"].Value.ToString();
            label10.Text = dtgrid_telefon.CurrentRow.Cells["Fiyat"].Value.ToString();
            groupBox2.Text = dtgrid_telefon.CurrentRow.Cells["TelefonAdi"].Value.ToString();
        }
        private void dtgrid_telefon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            yaz();
           


        }
        VeriTabaiStok vt_stok = new VeriTabaiStok();
        private void button1_Click(object sender, EventArgs e)
        {

            if (label6.Text =="-")
            {
                MessageBox.Show("Gerekli Telefonu Listeden Seçiniz");
            }
            else
            {
                if (DialogResult.Yes == MessageBox.Show("Adet Yükseltmesini Onaylıyor msunuz?", "Adet Arttırma",MessageBoxButtons.YesNo))
                {
                    vt_stok.stokArttir(int.Parse(label8.Text), Convert.ToInt32(numericUpDown1.Value));

                    yaz();
                    listele();
                    string mesaj = groupBox2.Text + " Adlı Telefon " + label7.Text + " adetinden\n" + numericUpDown1.Value.ToString() + " tane Eklenerek " + (int.Parse(label7.Text) + Convert.ToInt32(numericUpDown1.Value)) + "adetine güncellenmiştir";

                    MessageBox.Show(mesaj);
                    numericUpDown1.Value = 1; 
                }
                else
                {
                    MessageBox.Show("işlem iptal edildi");
                }
             
            }
           
           
         
             
        }

        private void Dtgrid_telefon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
