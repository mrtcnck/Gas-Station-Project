using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace akaryakit2
{
    public partial class bakiye : Form
    {
        public bakiye()
        {
            InitializeComponent();
        }

        SqlConnection con;

        private void label5_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_kartno_TextChanged(object sender, EventArgs e)
        {

            txt_kartno.MaxLength = 16;
            TextBox tb = sender as TextBox;
            lbl_kartno.Text = tb.Text;
        }

        private void txt_kartsahibi_TextChanged(object sender, EventArgs e)
        {
            txt_kartsahibi.MaxLength = 30;
            TextBox tb = sender as TextBox;
            lbl_kartsahibi.Text = tb.Text;
        }

        private void txt_kartskt_TextChanged(object sender, EventArgs e)
        {
            txt_kartcvv.MaxLength = 5;
            TextBox tb = sender as TextBox;
            lbl_kartskt.Text = tb.Text;
        }

        private void txt_kartcvv_TextChanged(object sender, EventArgs e)
        {
            txt_kartcvv.MaxLength = 3;
            TextBox tb = sender as TextBox;
            lbl_kartcvv.Text = tb.Text;
        }

        private void txt_kartno_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txt_kartcvv_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txt_kartsahibi_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)
                && !char.IsSeparator(e.KeyChar);
        }

        private void txt_kartno_Enter(object sender, EventArgs e)
        {
           
        }

        private void btn_temizle_Click(object sender, EventArgs e)
        {
            txt_kartcvv.Text = "";
            txt_kartno.Text = "";
            txt_kartsahibi.Text = "";
            txt_kartskt.Text = "";
            txt_tutar.Text = "";
        }

        private void btn_bakiyeyukle_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txt_kartcvv.Text) || String.IsNullOrEmpty(txt_kartno.Text) || String.IsNullOrEmpty(txt_kartsahibi.Text) || String.IsNullOrEmpty(txt_kartskt.Text) || String.IsNullOrEmpty(txt_tutar.Text))
            {
                MessageBox.Show("Lütfen kart bilgilerini veya tutarı girdiğinizden emin olun!", "Bilgileri Kontrol Edin!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string kullanici_adi = giris.kullanici;
                con = new SqlConnection("Data Source=localhost;Initial Catalog=akaryakit;Integrated Security=True");
                SqlCommand cmd;
                cmd = new SqlCommand();
                int gecici = 0;
                try
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    string bakiye = "SELECT bakiye FROM firmalar where kullanici_adi='" + kullanici_adi + "'";
                    cmd = new SqlCommand(bakiye, con);
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        gecici = Convert.ToInt32(dr["bakiye"]);
                    }
                    dr.Close();
                    dr.Dispose();
                    con.Close();
                }
                catch (Exception hata)
                {
                    MessageBox.Show("Bir hata ile karşılaşıldı! " + hata.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                try
                {
                    int yeni_bakiye;
                    dashboard dashboard = Application.OpenForms["dashboard"] as dashboard;
                    yeni_bakiye = gecici + Convert.ToInt32(txt_tutar.Text);
                    con.Open();
                    cmd.Connection = con;
                    cmd.CommandText = "update firmalar set bakiye='" + yeni_bakiye + "' where kullanici_adi='" + kullanici_adi + "'";
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Bakiye başarıyla yüklendi!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dashboard.bakiyeyenile(dashboard.walletbutton);
                    txt_kartcvv.Text = "";
                    txt_kartno.Text = "";
                    txt_kartsahibi.Text = "";
                    txt_kartskt.Text = "";
                    txt_tutar.Text = "";
                }
                catch (Exception hata)
                {
                    MessageBox.Show("Bir hata ile karşılaşıldı! " + hata.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void txt_tutar_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
