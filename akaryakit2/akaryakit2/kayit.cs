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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace akaryakit2
{
    public partial class kayit : Form
    {
        public kayit()
        {
            InitializeComponent();
        }

        public int kayitara(string user)
        {
            int sonuc;
            string sorgu = "Select COUNT(*) from firmalar WHERE kullanici_adi='" + user + "'";
            SqlCommand cmd = new SqlCommand(sorgu, conn);
            conn.Open();
            sonuc = Convert.ToInt32(cmd.ExecuteScalar());
            conn.Close();
            return sonuc;
        }

        public int mailara(string mail)
        {
            int sonuc;
            string sorgu = "Select COUNT(*) from firmalar WHERE eposta='" + mail + "'";
            SqlCommand cmd = new SqlCommand(sorgu, conn);
            conn.Open();
            sonuc = Convert.ToInt32(cmd.ExecuteScalar());
            conn.Close();
            return sonuc;
        }

        SqlConnection conn = new SqlConnection("Data Source=localhost;Initial Catalog=akaryakit;Integrated Security=True");
        
        private void geridonbutton1_Click(object sender, EventArgs e)
        {
            giris giris = new giris();
            giris.Show();
            this.Hide();
        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void kayitbutton_Click(object sender, EventArgs e)
        {
            if(kayitara(txt_kkullaniciadi.Text) == 0)
            {
                if(mailara(txt_email.Text) == 0)
                {
                    if (String.IsNullOrEmpty(txt_kfirmaadi.Text) || String.IsNullOrEmpty(txt_kkullaniciadi.Text) || String.IsNullOrEmpty(txt_ksifre.Text) || String.IsNullOrEmpty(txt_kresifre.Text) || String.IsNullOrEmpty(txt_email.Text))
                    {
                        MessageBox.Show("Lütfen tüm bilgileri giriniz!", "Bilgileri Kontrol Edin!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        if (txt_ksifre.Text != txt_kresifre.Text)
                        {
                            MessageBox.Show("Girdiğiniz şifreler uyuşmuyor!", "Şifrelerinizi Kontrol Edin!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txt_ksifre.Focus();
                        }
                        else
                        {
                            try
                            {
                                int kullanici = 0, bakiye = 0;
                                if (conn.State == ConnectionState.Closed)
                                    conn.Open();
                                string kayit = "insert into firmalar (kullanici_adi,firma_adi,kullanici_sifre,kullanici_tipi,bakiye,eposta) values(@kullanici_adi,@firma_adi,@kullanici_sifre,@kullanici_tipi,@bakiye,@eposta)";
                                SqlCommand cmd = new SqlCommand(kayit, conn);

                                cmd.Parameters.AddWithValue("@kullanici_adi", txt_kkullaniciadi.Text);
                                cmd.Parameters.AddWithValue("@firma_adi", txt_kfirmaadi.Text);
                                cmd.Parameters.AddWithValue("@kullanici_sifre", txt_kresifre.Text);
                                cmd.Parameters.AddWithValue("@kullanici_tipi", kullanici);
                                cmd.Parameters.AddWithValue("@bakiye", bakiye);
                                cmd.Parameters.AddWithValue("@eposta", txt_email.Text);
                                cmd.ExecuteNonQuery();
                                conn.Close();
                                MessageBox.Show("Kaydınız başarıyla oluşturuldu!\nGiriş ekranına yönlendiriliyorsunuz.", "BAŞARILI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                giris giris = new giris();
                                giris.Show();
                                this.Hide();

                            }
                            catch (Exception hata)
                            {
                                MessageBox.Show("Kayıt sırasında bir hata ile karşılaşıldı!\n" + hata.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Bu e-posta zaten kullanılıyor! ", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txt_email.Text = "";
                    txt_email.Focus();
                }
            }
            else
            {
                MessageBox.Show("Bu kullanıcı adı zaten kullanılıyor! ", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_kkullaniciadi.Focus();
            }

            
        }

        private void txt_kresifre_TextChanged(object sender, EventArgs e)
        {
            txt_kresifre.MaxLength = 16;
        }

        private void txt_ksifre_TextChanged(object sender, EventArgs e)
        {
            txt_ksifre.MaxLength = 16;
        }

        private void pictureBox3_MouseMove(object sender, MouseEventArgs e)
        {
            txt_ksifre.UseSystemPasswordChar = false;
            txt_kresifre.UseSystemPasswordChar = false;
        }

        private void pictureBox3_MouseLeave(object sender, EventArgs e)
        {
            txt_ksifre.UseSystemPasswordChar = true;
            txt_kresifre.UseSystemPasswordChar = true;
        }

        private void pictureBox4_MouseMove(object sender, MouseEventArgs e)
        {
            txt_ksifre.UseSystemPasswordChar = false;
            txt_kresifre.UseSystemPasswordChar = false;
        }

        private void pictureBox4_MouseLeave(object sender, EventArgs e)
        {
            txt_ksifre.UseSystemPasswordChar = true;
            txt_kresifre.UseSystemPasswordChar = true;
        }

        private void kayit_Load(object sender, EventArgs e)
        {
            GC.Collect();
        }
    }
}
