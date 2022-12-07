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
    public partial class plaka : Form
    {
        public plaka()
        {
            InitializeComponent();
        }

        public static int id_al()
        {
            SqlConnection conn = new SqlConnection("Data Source=localhost;Initial Catalog=akaryakit;Integrated Security=True;MultipleActiveResultSets=true");
            int id=0;
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            string query = "select id from firmalar where kullanici_adi=@kullanici_adi";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@kullanici_adi",giris.kullanici.ToString());
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    id= Convert.ToInt32(dr["id"]);
                }
            }
            return id;
        }
        
        SqlConnection conn = new SqlConnection("Data Source=localhost;Initial Catalog=akaryakit;Integrated Security=True;MultipleActiveResultSets=true");

        private void button2_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txt_addplaka.Text))
            {
                MessageBox.Show("Lütfen plaka giriniz!", "Bilgileri Kontrol Edin!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    if (conn.State == ConnectionState.Closed)
                        conn.Open();
                    string ekle = "insert into plakalar (plaka,firmaid) values(@plaka,@firmaid)";
                    SqlCommand cmd = new SqlCommand(ekle, conn);
                    cmd.Parameters.AddWithValue("@plaka", txt_addplaka.Text);
                    cmd.Parameters.AddWithValue("@firmaid", id_al());
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Plaka eklendi!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception hata)
                {
                    MessageBox.Show("Ekleme sırasında bir hata ile karşılaşıldı!\n" + hata.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txt_plakacikar.Text))
            {
                MessageBox.Show("Lütfen plaka ID giriniz!", "Bilgileri Kontrol Edin!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    string id = txt_plakacikar.Text;
                    if (conn.State == ConnectionState.Closed)
                        conn.Open();
                    string sil = "DELETE FROM plakalar WHERE plakaid='" + id + "'";
                    SqlCommand cmd = new SqlCommand(sil, conn);

                    cmd.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Plaka başarıyla silindi!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception hata)
                {
                    MessageBox.Show("Silme sırasında bir hata ile karşılaşıldı! " + hata.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
  }
