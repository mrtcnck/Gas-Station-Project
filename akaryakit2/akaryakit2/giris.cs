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
using System.Data.Sql;
using System.Linq.Expressions;
using System.Security.Policy;

namespace akaryakit2
{
    public partial class giris : Form
    {
        public giris()
        {
            InitializeComponent();
        }

        public static string kullanici;

        public void geridonbutton1_Click(object sender, EventArgs e)
        {
            kayit kayit = new kayit();
            kayit.Show();
            this.Hide();
        }

        private void closebutton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void minimizebutton2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        public void girisbutton_Click(object sender, EventArgs e)
        {
            kullanici=txt_gkullaniciadi.Text;
            
            try
            {
                SqlConnection conn;
                SqlCommand cmd;
                SqlDataReader dr;

                if (String.IsNullOrEmpty(txt_gkullaniciadi.Text) || String.IsNullOrEmpty(txt_gsifre.Text))
                {
                    MessageBox.Show("Boş kalan alanları doldurunuz!", "Bilgileri Kontrol Edin!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    string user = txt_gkullaniciadi.Text;
                    string password = txt_gsifre.Text;
                    int kullanici = 0;
                    string query = "SELECT * FROM dbo.firmalar where kullanici_adi='" + user + "'and kullanici_sifre='" + password + "'";

                    conn = new SqlConnection("Data Source=localhost;Initial Catalog=akaryakit;Integrated Security=True");
                    cmd = new SqlCommand();
                    cmd.Parameters.AddWithValue("@kullanici_tipi", kullanici);
                    conn.Open();
                    cmd.Connection = conn;
                    cmd.CommandText = query;
                    dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            if (dr["kullanici_tipi"].ToString() == "1")
                            {
                                adminpanel adminpanel = new adminpanel();
                                adminpanel.Show();
                                this.Hide();
                            }
                            else
                            {
                                dashboard dashboard = new dashboard();
                                dashboard.Show();
                                this.Hide();
                            }
                        }
                    }
                    else
                    {
                        dr.Close();
                        MessageBox.Show("Kullanıcı adı veya şifre yanlış!\nLütfen bilgilerinizi kontrol ediniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    conn.Close();
                    kayit kayit = new kayit();
                    kayit.Close();
                    sifremiunuttum sifremiunuttum = new sifremiunuttum();
                    sifremiunuttum.Close();
                }
            }
            catch (Exception hata)
            {
                MessageBox.Show("DataBaseye ulaşılamadı! " + hata.Message, "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void pictureBox3_MouseMove(object sender, MouseEventArgs e)
        {
            txt_gsifre.UseSystemPasswordChar = false;
        }

        private void pictureBox3_MouseLeave(object sender, EventArgs e)
        {
            txt_gsifre.UseSystemPasswordChar = true;
        }

        private void forgotbutton_Click(object sender, EventArgs e)
        {
            sifremiunuttum sifremiunuttum = new sifremiunuttum();
            sifremiunuttum.Show();
            this.Hide();
        }

        private void giris_Load(object sender, EventArgs e)
        {
            GC.Collect();
        }
    }
}
