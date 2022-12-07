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
    public partial class adminfiyatlar : Form
    {
        public adminfiyatlar()
        {
            InitializeComponent();
        }

        SqlConnection con;

        public void adminfiyatlar_Load(object sender, EventArgs e)
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
                if (dr != null)
                {
                    while (dr.Read())
                    {
                        lbl_benzin2.Text = dr["benzin"].ToString();
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
                        lbl_mdiesel2.Text = dr["mdiesel"].ToString();
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
                        lbl_pdiesel2.Text = dr["pdiesel"].ToString();
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
                        lbl_gaz2.Text = dr["gaz"].ToString();
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

        private void btn_benzin_Click(object sender, EventArgs e)
        {
            con = new SqlConnection("Data Source=localhost;Initial Catalog=akaryakit;Integrated Security=True");
            SqlCommand cmd;
            cmd = new SqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "update fiyatlar set benzin='" + txt_benzin.Text + "'";
            cmd.ExecuteNonQuery();
            con.Close();
            
            try
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();
                string benzinfiyat = "SELECT benzin FROM fiyatlar";
                cmd = new SqlCommand(benzinfiyat, con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr != null)
                {
                    while (dr.Read())
                    {
                        lbl_benzin2.Text = dr["benzin"].ToString();
                    }
                }
                dr.Close();
                dr.Dispose();
                con.Close();
            }
            catch (Exception hata)
            {
                MessageBox.Show("Bir hata ile karşılaşıldı! " + hata.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            txt_benzin.Text = "";
        }
        private void btn_mdiesel_Click(object sender, EventArgs e)
        {
            con = new SqlConnection("Data Source=localhost;Initial Catalog=akaryakit;Integrated Security=True");
            SqlCommand cmd;
            cmd = new SqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "update fiyatlar set mdiesel='" + txt_mdiesel.Text + "'";
            cmd.ExecuteNonQuery();
            con.Close();

            try
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();
                string mdieselfiyat = "SELECT mdiesel FROM fiyatlar";
                cmd = new SqlCommand(mdieselfiyat, con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr != null)
                {
                    while (dr.Read())
                    {
                        lbl_mdiesel2.Text = dr["mdiesel"].ToString();
                    }
                }
                dr.Close();
                dr.Dispose();
                con.Close();
            }
            catch (Exception hata)
            {
                MessageBox.Show("Bir hata ile karşılaşıldı! " + hata.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            txt_mdiesel.Text = "";
        }
        private void btn_pdiesel_Click(object sender, EventArgs e)
        {
            con = new SqlConnection("Data Source=localhost;Initial Catalog=akaryakit;Integrated Security=True");
            SqlCommand cmd;
            cmd = new SqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "update fiyatlar set pdiesel='" + txt_pdiesel.Text + "'";
            cmd.ExecuteNonQuery();
            con.Close();

            try
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();
                string pdieselfiyat = "SELECT pdiesel FROM fiyatlar";
                cmd = new SqlCommand(pdieselfiyat, con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr != null)
                {
                    while (dr.Read())
                    {
                        lbl_pdiesel2.Text = dr["pdiesel"].ToString();
                    }
                }
                dr.Close();
                dr.Dispose();
                con.Close();
            }
            catch (Exception hata)
            {
                MessageBox.Show("Bir hata ile karşılaşıldı! " + hata.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            txt_pdiesel.Text = "";
        }
        private void btn_gaz_Click(object sender, EventArgs e)
        {
            con = new SqlConnection("Data Source=localhost;Initial Catalog=akaryakit;Integrated Security=True");
            SqlCommand cmd;
            cmd = new SqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "update fiyatlar set gaz='" + txt_gaz.Text + "'";
            cmd.ExecuteNonQuery();
            con.Close();

            try
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();
                string gazfiyat = "SELECT gaz FROM fiyatlar";
                cmd = new SqlCommand(gazfiyat, con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr != null)
                {
                    while (dr.Read())
                    {
                        lbl_gaz2.Text = dr["gaz"].ToString();
                    }
                }
                dr.Close();
                dr.Dispose();
                con.Close();
            }
            catch (Exception hata)
            {
                MessageBox.Show("Bir hata ile karşılaşıldı! " + hata.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            txt_gaz.Text = "";
        }
    }
}
