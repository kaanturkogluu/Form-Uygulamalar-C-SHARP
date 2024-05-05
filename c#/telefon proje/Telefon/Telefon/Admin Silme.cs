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
    public partial class Admin_Silme : Form
    {
        public Admin_Silme()
        {
            InitializeComponent();
        }
        VeriTabaniAdmin vt_Admin = new VeriTabaniAdmin();
        DataTable data = new DataTable(); 
        private void Admin_Silme_Load(object sender, EventArgs e)
        {
           
            dtgrid_admin_sil.DataSource = vt_Admin.adminListeleTable(); 
            
        }
        private void adminListele()
        {
            dtgrid_admin_sil.DataSource = vt_Admin.adminListeleTable();

        }

        private void dtgrid_admin_sil_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dtgrid_admin_sil_CellClick(object sender, DataGridViewCellEventArgs e)
        {
         
            lbl_admin.Text = dtgrid_admin_sil.CurrentRow.Cells["AD"].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           DialogResult result =  MessageBox.Show("Eğer Seçim Yapmadıysanız İlk Kayıt Silinicektir \nSilme İşlemini Onaylıyor Musunuz?","Silme İşlemi Onayla", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                // Kullanıcı "Evet" düğmesine tıkladıysa yapılacak işlem buraya yazılır
                vt_Admin.adminSil(dtgrid_admin_sil.CurrentRow.Cells["AD"].Value.ToString());
                MessageBox.Show("Silme İslemi Basarılı");
                adminListele(); 
              
            }
            else if (result == DialogResult.No)
            {
                // Kullanıcı "Hayır" düğmesine tıkladıysa yapılacak işlem buraya yazılır
                MessageBox.Show("İşlem İptal Edildi ");
            }
          
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           dtgrid_admin_sil.DataSource= vt_Admin.adminFiltrele(textBox1.Text);
        }
    }
}
