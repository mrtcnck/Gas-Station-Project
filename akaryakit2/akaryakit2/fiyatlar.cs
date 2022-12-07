using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace akaryakit2
{
    public partial class fiyatlar : Form
    {
        public fiyatlar()
        {
            InitializeComponent();

        }

        public static void fiyatyenile(string tur, object txtbx)
        {
            string server = "Data Source=localhost;Initial Catalog=akaryakit;Integrated Security=True";
            SqlConnection conn = new SqlConnection(server);
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                string fiyat = "SELECT '" + tur + "' FROM fiyatlar";
                SqlCommand cmd = new SqlCommand(fiyat, conn);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr != null)
                {
                    while (dr.Read())
                    {
                        txtbx = dr[""+tur+""].ToString();
                    }
                }
                dr.Close();
                dr.Dispose();
                conn.Close();
            }
            catch (Exception hata)
            {
                MessageBox.Show("Bir hata ile karşılaşıldı! " + hata.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void baglan()
        {

        }

        public void panel9_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lbl_benzin_TextChanged(object sender, EventArgs e)
        {

        }

        private void lbl_pdiesel_TextChanged(object sender, EventArgs e)
        {

        }

        private void fiyatlar_Load(object sender, EventArgs e)
        {
            string server = "Data Source=localhost;Initial Catalog=akaryakit;Integrated Security=True";
            SqlConnection conn = new SqlConnection(server);
            try
                {
                    if (conn.State == ConnectionState.Closed)
                        conn.Open();
                    string benzinfiyat = "SELECT benzin FROM fiyatlar";
                    SqlCommand cmd = new SqlCommand(benzinfiyat, conn);
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr!=null)
                    {
                        while (dr.Read())
                        {
                            lbl_benzin.Text = dr["benzin"].ToString();
                        }
                    }
                    dr.Close();
                    dr.Dispose();
                    conn.Close();
                    }
                catch (Exception hata)
                {
                    MessageBox.Show("Bir hata ile karşılaşıldı! " + hata.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                string mdieselfiyat = "SELECT mdiesel FROM fiyatlar";
                SqlCommand cmd = new SqlCommand(mdieselfiyat, conn);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr != null)
                {
                    while (dr.Read())
                    {
                        lbl_mdiesel.Text = dr["mdiesel"].ToString();
                    }
                }
                dr.Close();
                dr.Dispose();
                conn.Close();
            }
            catch (Exception hata)
            {
                MessageBox.Show("Bir hata ile karşılaşıldı! " + hata.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                string pdieselfiyat = "SELECT pdiesel FROM fiyatlar";
                SqlCommand cmd = new SqlCommand(pdieselfiyat, conn);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr != null)
                {
                    while (dr.Read())
                    {
                        lbl_pdiesel.Text = dr["pdiesel"].ToString();
                    }
                }
                dr.Close();
                dr.Dispose();
                conn.Close();
            }
            catch (Exception hata)
            {
                MessageBox.Show("Bir hata ile karşılaşıldı! " + hata.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                string gazfiyat = "SELECT gaz FROM fiyatlar";
                SqlCommand cmd = new SqlCommand(gazfiyat, conn);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr != null)
                {
                    while (dr.Read())
                    {
                        lbl_gaz.Text = dr["gaz"].ToString();
                    }
                }
                dr.Close();
                dr.Dispose();
                conn.Close();
            }
            catch (Exception hata)
            {
                MessageBox.Show("Bir hata ile karşılaşıldı! " + hata.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
