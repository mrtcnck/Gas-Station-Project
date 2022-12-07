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
    public partial class dashboard : Form
    {

        public dashboard()
        {
            InitializeComponent();
        }




        public void formload(object Form)
        {
            foreach (Control control in centerpanel.Controls)
            {
                control.Dispose();
            }
            GC.Collect();
            centerpanel.Controls.Clear();
            Form f = Form as Form;
            f.TopLevel = false;
            f.FormBorderStyle = FormBorderStyle.None;
            this.centerpanel.Controls.Add(f);
            f.Show();
        }

        public static void bakiyeyenile(Button walletbutton)
        {
            string kullanici_adi = giris.kullanici;
            string server = "Data Source=localhost;Initial Catalog=akaryakit;Integrated Security=True";
            SqlConnection conn = new SqlConnection(server);
            int gecici = 0;
            try
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                string benzinfiyat = "SELECT bakiye FROM firmalar where kullanici_adi='" + kullanici_adi + "'";
                SqlCommand cmd = new SqlCommand(benzinfiyat, conn);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    gecici = Convert.ToInt32(dr["bakiye"]);
                }
                dr.Close();
                dr.Dispose();
                conn.Close();
                walletbutton.Text = "Bakiyem: " + gecici.ToString() + " ₺";
            }
            catch (Exception hata)
            {
                MessageBox.Show("Bir hata ile karşılaşıldı! " + hata.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void closebutton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void minimizebutton2_Click(object sender, EventArgs e)
        {
            this.WindowState= FormWindowState.Minimized;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            DialogResult res;
            res=MessageBox.Show("Çıkış yapmak istediğinizden emin misiniz?","Çıkış",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                MessageBox.Show("Çıkış başarıyla gerçekleşti!","Çıkış",MessageBoxButtons.OK,MessageBoxIcon.Information);
                Application.Exit();

            }
            else
            {
                this.Show();
            }
        }

        private void pricebutton_Click(object sender, EventArgs e)
        {
            formload(new fiyatlar());
        }

        private void balancebutton_Click(object sender, EventArgs e)
        {
            formload(new bakiye());
        }

        private void platebutton_Click(object sender, EventArgs e)
        {
            formload(new plaka());
        }

        private void vehiclebutton_Click(object sender, EventArgs e)
        {
            formload(new araclar());
        }

        private void stationbutton_Click(object sender, EventArgs e)
        {
            formload(new istasyonlar());
        }

        private void feedbackbutton_Click(object sender, EventArgs e)
        {
            formload(new feedback());
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void petrollerilabel_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void namebutton_Click(object sender, EventArgs e)
        {

        }

        private void walletbutton_Click(object sender, EventArgs e)
        {

        }

        private void centerpanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dashboard_Load(object sender, EventArgs e)
        {
            namebutton.Text = giris.kullanici;
            bakiyeyenile(walletbutton);
        }
    }
}
