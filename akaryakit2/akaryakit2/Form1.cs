namespace akaryakit2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            giris girisekrani= new giris();
            girisekrani.Show();
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

        private void kayitbutton_Click(object sender, EventArgs e)
        {
            kayit kayitekrani= new kayit();
            kayitekrani.Show();
            this.Hide();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            dashboard dashboard = new dashboard();
            dashboard.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            adminpanel adminpanel = new adminpanel();
            adminpanel.Show();
            this.Hide();
        }
    }
}