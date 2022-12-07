using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace akaryakit2
{
    public partial class adminpanel : Form
    {
        public adminpanel()
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

        private void cikisbutton_Click(object sender, EventArgs e)
        {
            DialogResult res;
            res = MessageBox.Show("Çıkış yapmak istediğinizden emin misiniz?", "Çıkış", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                MessageBox.Show("Çıkış başarıyla gerçekleşti!", "Çıkış", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Application.Exit();

            }
            else
            {
                this.Show();
            }
        }

        private void minimizebutton2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void admineklebutton_Click(object sender, EventArgs e)
        {
            formload(new adminekle());
        }

        private void usersbutton_Click(object sender, EventArgs e)
        {
            formload(new kullanicilar());
        }

        private void pricebutton_Click(object sender, EventArgs e)
        {
            formload(new adminfiyatlar());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            formload(new feedback2());
        }

        public void namebutton_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void adminpanel_Load(object sender, EventArgs e)
        {
            namebutton.Text = giris.kullanici;
        }

        private void namebutton_Click(object sender, EventArgs e)
        {

        }
    }
}
