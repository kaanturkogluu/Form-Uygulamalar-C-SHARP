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
    public partial class Personel : Form
    {
        int admindegr;
        public Personel(int admindeger)
        {

            admindeger = admindeger; 
            InitializeComponent();
        }

        private void Personel_Load(object sender, EventArgs e)
        {
            stokListele();
        }

        private void çıkışToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
        }
        VeriTabaniSatisIslemleri vt_satis = new VeriTabaniSatisIslemleri();
        public void stokListele()
        {
            dtgrid_stok.DataSource = vt_satis.stokListele();
        }
        VeriTabaniAdmin vt_admin = new VeriTabaniAdmin();
        private void yedekAlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            vt_admin.VeritabaniYedekle();
        }

        private void dtgrid_stok_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Sadece satırın üzerine tıklanmışsa devam et
            {
                DataGridViewRow selectedRow = dtgrid_stok.Rows[e.RowIndex];
                // id stununu diğer forma aktarmak için alioz
                int selectedId = Convert.ToInt32(selectedRow.Cells["TelefonId"].Value);

                // Yeni formu açmak ve Id değerini iletmek için kodu buraya ekleyin
                Telefon_Bilgileri yeniForm = new Telefon_Bilgileri(selectedId,lbl_isAdmin.Text);
                yeniForm.ShowDialog();
            }
        }

        private void müşteriListesiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Musteri_Islemleri musteri = new Musteri_Islemleri(admindegr);
            musteri.ShowDialog();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            dtgrid_stok.DataSource= vt_satis.stokFiltrele(textBox1.Text);
        }

        private void btn_Refresh_Click(object sender, EventArgs e)
        {
            stokListele();
            textBox1.Clear(); 
        }

        private void geçmişSatışlarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GecmisSatıslar gecmisSatıslar = new GecmisSatıslar();
            gecmisSatıslar.ShowDialog(); 
        }

        private void girişEkranınaDönToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Giris grs = new Giris();
            this.Hide();
            grs.ShowDialog();
            
        }

        private void kapatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit(); 
        }
    }
}
