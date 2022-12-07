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
    public partial class adminekle : Form
    {
        public adminekle()
        {
            InitializeComponent();
        }

        SqlConnection conn = new SqlConnection("Data Source=localhost;Initial Catalog=akaryakit;Integrated Security=True");

        private void button2_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txt_adminadsoyad.Text) || String.IsNullOrEmpty(txt_adminkad.Text) || String.IsNullOrEmpty(txt_adminpsw.Text))
            {
                MessageBox.Show("Lütfen tüm bilgileri giriniz!", "Bilgileri Kontrol Edin!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                    try
                    {
                        int kullanici = 1, bakiye= 0;
                        if (conn.State == ConnectionState.Closed)
                            conn.Open();
                        string kayit = "insert into firmalar (kullanici_adi,firma_adi,kullanici_sifre,kullanici_tipi,bakiye,eposta) values(@kullanici_adi,@firma_adi,@kullanici_sifre,@kullanici_tipi,@bakiye,@eposta)";
                        SqlCommand cmd = new SqlCommand(kayit, conn);

                        cmd.Parameters.AddWithValue("@kullanici_adi", txt_adminkad.Text);
                        cmd.Parameters.AddWithValue("@firma_adi", txt_adminadsoyad.Text);
                        cmd.Parameters.AddWithValue("@kullanici_sifre", txt_adminpsw.Text);
                        cmd.Parameters.AddWithValue("@kullanici_tipi", kullanici);
                        cmd.Parameters.AddWithValue("@bakiye", bakiye);
                        cmd.Parameters.AddWithValue("@eposta", txt_adminmail.Text);
                        cmd.ExecuteNonQuery();
                        conn.Close();
                        MessageBox.Show("Admin kaydı başarıyla eklendi!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txt_adminadsoyad.Clear();
                        txt_adminkad.Clear();
                        txt_adminmail.Clear();
                        txt_adminpsw.Clear();
                    }
                    catch (Exception hata)
                    {
                        MessageBox.Show("Kayıt sırasında bir hata ile karşılaşıldı! " + hata.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
            }
        }

        private void txt_adminpsw_TextChanged(object sender, EventArgs e)
        {
            txt_adminpsw.MaxLength = 16;
        }

        private void admincikarbutton_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txt_adminid.Text))
            {
                MessageBox.Show("Lütfen admin ID giriniz!", "Bilgileri Kontrol Edin!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    string id = txt_adminid.Text;
                    if (conn.State == ConnectionState.Closed)
                        conn.Open();
                    string cikar = "DELETE FROM firmalar WHERE id='" + id + "'";
                    SqlCommand cmd = new SqlCommand(cikar, conn);

                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Admin kaydı başarıyla silindi!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception hata)
                {
                    MessageBox.Show("Silme sırasında bir hata ile karşılaşıldı! " + hata.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void kullanicicikarbutton_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txt_kullaniciid.Text))
            {
                MessageBox.Show("Lütfen kullanıcı ID giriniz!", "Bilgileri Kontrol Edin!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    string id = txt_kullaniciid.Text;
                    if (conn.State == ConnectionState.Closed)
                        conn.Open();
                    string cikar = "DELETE FROM firmalar WHERE id='" + id + "'";
                    SqlCommand cmd = new SqlCommand(cikar, conn);

                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Kullanıcı kaydı başarıyla silindi!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception hata)
                {
                    MessageBox.Show("Silme sırasında bir hata ile karşılaşıldı! " + hata.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
