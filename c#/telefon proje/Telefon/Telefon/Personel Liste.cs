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
    public partial class Personel_Liste : Form
    {
        public Personel_Liste()
        {
            InitializeComponent();
        }
        VeriTabaniPersonel vt_personel = new VeriTabaniPersonel(); 
        private void Personel_Liste_Load(object sender, EventArgs e)
        {


            dtgri_personel_liste.DataSource = vt_personel.personelListeleTable(); 
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            dtgri_personel_liste.DataSource = vt_personel.personelFiltrele(textBox1.Text); 
        }
        int id; 
        private void dtgri_personel_liste_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            id = int.Parse( dtgri_personel_liste.CurrentRow.Cells["Personelid"].Value.ToString());

        }
    }
}
