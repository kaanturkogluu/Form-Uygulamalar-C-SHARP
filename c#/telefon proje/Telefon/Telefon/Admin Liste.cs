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
    public partial class Admin_Liste : Form
    {
        public Admin_Liste()
        {
            InitializeComponent();
        }
        VeriTabaniAdmin vt_admin = new VeriTabaniAdmin();
        private void txt_ara_TextChanged(object sender, EventArgs e)
        {
            dtgrid_admin_listesi.DataSource = vt_admin.adminFiltrele(txt_ara.Text);

        }

        private void dtgrid_admin_listesi_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void Admin_Liste_Load(object sender, EventArgs e)
        {
            dtgrid_admin_listesi.DataSource = vt_admin.adminListeleTable();

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked==true)
            {
                dtgrid_admin_listesi.DataSource = vt_admin.personeladminListeleTable();

            }
            else
            {
                dtgrid_admin_listesi.DataSource = vt_admin.adminListeleTable();
            }
          
        }
    }
}
