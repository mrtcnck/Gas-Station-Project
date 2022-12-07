using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace akaryakit2
{
    public partial class feedback2 : Form
    {
        public feedback2()
        {
            InitializeComponent();
        }

        SqlConnection con;

        private void txt_kkullaniciadi_TextChanged(object sender, EventArgs e)
        {
            txt_sifreyenile.MaxLength = 16;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            txt_resifre.MaxLength = 16;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult res;
            res = MessageBox.Show("Şifrenizi değiştirmek istediğinizden emin misiniz?", "Şifre Yenileme", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                if (txt_sifreyenile.Text == txt_resifre.Text)
                {
                    string kullanici_adi = giris.kullanici;
                    string server = "Data Source=localhost;Initial Catalog=akaryakit;Integrated Security=True";
                    SqlConnection conn = new SqlConnection(server);
                    con = new SqlConnection("Data Source=localhost;Initial Catalog=akaryakit;Integrated Security=True");
                    SqlCommand cmd;
                    cmd = new SqlCommand();
                    con.Open();
                    cmd.Connection = con;
                    cmd.CommandText = "update firmalar set kullanici_sifre='" + txt_resifre.Text + "' where kullanici_adi='" + kullanici_adi + "'";
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Şifreniz değiştirildi.", "Onay", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txt_sifreyenile.Text = "";
                    txt_resifre.Text = "";
                }
                else
                {
                    MessageBox.Show("Girdiğiniz şifreler uyuşmuyor!", "Şifrelerinizi Kontrol Edin!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txt_sifreyenile.Text = "";
                    txt_resifre.Text = "";
                    txt_sifreyenile.Focus();
                }
            }
            else
            {
                this.Show();
            }
        }

        private void feedback2_Load(object sender, EventArgs e)
        {
            txt_kullanicadi.Text = giris.kullanici;
        }
    }
}
