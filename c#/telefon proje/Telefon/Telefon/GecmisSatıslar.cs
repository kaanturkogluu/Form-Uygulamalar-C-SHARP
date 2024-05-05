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
    public partial class GecmisSatıslar : Form
    {
        public GecmisSatıslar()
        {
            InitializeComponent();
        }

        private void GecmisSatıslar_Load(object sender, EventArgs e)
        {
            dtgrid_gecmis.DataSource = vt_satis.tarihFiltre(dateTimePicker1.Value.AddDays(-1), dateTimePicker2.Value);
            
          

        }
        VeriTabaniSatisIslemleri vt_satis = new VeriTabaniSatisIslemleri();
        void listele()
        {
           
            dtgrid_gecmis.DataSource= vt_satis.tarihFiltre(dateTimePicker1.Value, dateTimePicker2.Value);
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            listele();
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            listele();
        }
    }
}
