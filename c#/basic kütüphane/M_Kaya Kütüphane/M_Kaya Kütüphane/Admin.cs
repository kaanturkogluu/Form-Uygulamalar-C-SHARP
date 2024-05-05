using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace M_Kaya_Kütüphane
{
    public partial class AnaSayfa : Form

    {   
        public SqlConnection baglanti = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=Kütüphane;Integrated Security=True");
        Baglanti_İslemleri veriTabani = new Baglanti_İslemleri();
        
        public AnaSayfa()
        {
            InitializeComponent();
        }
        Admin_İslemleri adminislemleri = new Admin_İslemleri(); 
        
        private void çıkışToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Application.Exit();
        }
      
       
        private void btn_Giris_Click(object sender, EventArgs e)
        {

            
            try
            {
                if (baglanti.State == ConnectionState.Open)
                {
                    baglanti.Close();

                }
                Admin_İslemleri.Ad = txt_admin.Text;
                Admin_İslemleri.id = veriTabani.idAl(txt_admin.Text,"Admin"); 
                veriTabani.AdminGirisi(txt_admin.Text, txt_sifre.Text);


               
               


                if (baglanti.State == ConnectionState.Open)
                {
                    baglanti.Close();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }

        }

        private void ayarlarToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void tamDenetimToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Admin_Kayit admin_Kayit = new Admin_Kayit();
            admin_Kayit.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void şifreSıfırlaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void şifremiUnuttumToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Admin_Sifre_Yenile admin = new Admin_Sifre_Yenile();
            admin.Show();
            this.Hide();
        }

        private void kütüphaneSorumlusuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Kutuphane_Sorumlusu kutuphane = new Kutuphane_Sorumlusu();
            kutuphane.Show();
            this.Hide();
        }

        private void şifreyiDeğiştirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sifre_Degistir sifre_Degistir = new Sifre_Degistir();
            sifre_Degistir.Show();


        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            veriTabani.Sorumlu_Girisi(txt_ksorumlu.Text, txT_ksifre.Text);
        }
    }
}
