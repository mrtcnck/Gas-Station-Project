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
using System.Net;
using System.Net.Mail;
using System.Drawing.Drawing2D;

namespace akaryakit2
{
    public partial class sifremiunuttum : Form
    {
        public sifremiunuttum()
        {
            InitializeComponent();
        }

        SqlConnection conn = new SqlConnection("Data Source=localhost;Initial Catalog=akaryakit;Integrated Security=True");

        public int karsilastir(string user, string mail)
        {
            conn.Open();
            int sonuc;
            string sorgu = "Select * from dbo.firmalar WHERE kullanici_adi='" + user + "' AND eposta='" + mail + "'";
            SqlCommand cmd = new SqlCommand(sorgu, conn);
            sonuc = Convert.ToInt32(cmd.ExecuteScalar());
            conn.Close();
            return sonuc;
        }

        private void backbutton_Click(object sender, EventArgs e)
        {
            giris giris = new giris();
            giris.Show();
            this.Hide();
        }

        private void sendbutton_Click(object sender, EventArgs e)
        {
            if (karsilastir(txt_kullaniciadi2.Text, txt_eposta2.Text) != 0)
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("Select * from firmalar where kullanici_adi=@kullanici_adi and eposta=@eposta", conn);
                cmd.Parameters.AddWithValue("kullanici_adi", txt_kullaniciadi2.Text);
                cmd.Parameters.AddWithValue("eposta", txt_eposta2.Text);
                SqlDataReader read = cmd.ExecuteReader();
                while (read.Read())
                {
                    try
                    {
                        if (conn.State == ConnectionState.Closed)
                        {
                            conn.Open();
                        }
                        SmtpClient smtpserver = new SmtpClient();
                        MailMessage mail = new MailMessage();
                        string date = DateTime.Now.ToShortDateString();
                        string mymail = ("isikpetrolleri@gmail.com");
                        string mailpsw = ("fnqztrzxaeycqfly");
                        string server = "smtp.gmail.com";
                        string towho = (read["eposta"].ToString());
                        string konu = ("IŞIK PETROLLERİ / ŞİFRE HATIRLATMA");
                        string message = ("Merhaba " + read["firma_adi"].ToString() + ",\n" + date + " tarihinde şifre hatırlatma talebinde bulundunuz." +
                            "\n\n" + "Şifreniz: " + read["kullanici_sifre"].ToString() + "\n\n" + "İyi günler dileriz. Sağlıcakla kalın.");
                        smtpserver.Credentials = new NetworkCredential(mymail, mailpsw);
                        smtpserver.Port = 587;
                        smtpserver.Host = server;
                        smtpserver.EnableSsl = true;
                        mail.From = new MailAddress(mymail);
                        mail.To.Add(towho);
                        mail.Subject = konu;
                        mail.Body = message;
                        smtpserver.Send(mail);
                        DialogResult bilgi = new DialogResult();
                        bilgi = MessageBox.Show("Şifreniz mailinize gönderilmiştir!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Hide();
                        giris giris = new giris();
                        giris.Show();
                        giris.txt_gkullaniciadi.Focus();
                    }
                    catch (Exception hata)
                    {
                        MessageBox.Show("Gönderim sırasında bir hata ile karşılaşıldı! " + hata.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Bu kullanıcı adı ve e-posta eşleşmiyor! ", "Bilgileri kontrol edin!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void sifremiunuttum_Load(object sender, EventArgs e)
        {
            GC.Collect();
        }
    }
}
