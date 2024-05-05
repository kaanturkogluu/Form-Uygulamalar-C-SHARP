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
    public partial class Sube_Liste : Form
    {
        public Sube_Liste()
        {
            InitializeComponent();
        }
        VeriTabaniSube vt_sube = new VeriTabaniSube();
        private void Sube_Liste_Load(object sender, EventArgs e)
        {
            dtgrid_sube_liste.DataSource = vt_sube.aktifSubeListeleTable();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            dtgrid_sube_liste.DataSource = vt_sube.subeFiltrele(textBox1.Text); 
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked==true)
            {
                dtgrid_sube_liste.DataSource = vt_sube.tumSubeListeleTable();

            }
            else
            {
                dtgrid_sube_liste.DataSource = vt_sube.aktifSubeListeleTable();
            }

        }
    }
}
