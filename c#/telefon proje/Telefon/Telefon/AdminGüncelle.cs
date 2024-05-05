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
    public partial class AdminGüncelle : Form
    {
        public AdminGüncelle()
        {
            InitializeComponent();
        }
        VeriTabaniAdmin vt_Admin = new VeriTabaniAdmin(); 

        //datagride veri çekme
        private void adminListele()
        {
            dtgrid_admin_guncelle.DataSource = vt_Admin.adminListeleTable();
        }

        private void AdminGüncelle_Load(object sender, EventArgs e)
        {

            adminListele();
        }

        private int id; 
        private void dtgrid_admin_guncelle_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // gridde seçilen değerlerin textboxlara aktarılması

            txt_ad.Text = dtgrid_admin_guncelle.CurrentRow.Cells["AD"].Value.ToString();
            id = int.Parse(dtgrid_admin_guncelle.CurrentRow.Cells["ID"].Value.ToString());
           
            txt_ref.Text = dtgrid_admin_guncelle.CurrentRow.Cells["REFERANS"].Value.ToString();

        }

        private void dtgrid_admin_guncelle_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Güncelleme İşlemini Onaylıyor musunuz? " , "Güncelleme Onay", MessageBoxButtons.YesNo);

            if (result==DialogResult.Yes)
            {
                // boslukları silerek karakter uzunluğu kontrolü
                if (txt_ref.Text.Trim().Length< 10)
                {
                    MessageBox.Show("Referans için 10 haneli sayı giriniz");
                }
                else
                {
                    vt_Admin.adminGuncelle(txt_ad.Text, txt_ref.Text, id);
                    adminListele();
                }
                


            }
            else
            {
                MessageBox.Show("İşlem İptal Edildi");
            }
            
        }

        private void txt_ref_TextChanged(object sender, EventArgs e)
        {
            // refereans textboxina max 10 karakter ataması
            txt_ref.MaxLength = 10;
           
        }

        private void txt_ara_TextChanged(object sender, EventArgs e)
        {
            //filtreleme işlemi için metottandönen dt ile datagridi doldurma 
            dtgrid_admin_guncelle.DataSource = vt_Admin.adminFiltrele(txt_ara.Text); 
        }
    }
}
