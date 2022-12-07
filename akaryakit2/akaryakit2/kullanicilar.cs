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
    public partial class kullanicilar : Form
    {
        public kullanicilar()
        {
            InitializeComponent();
        }

        SqlConnection con;
        SqlDataAdapter da;
        DataSet ds;

        void griddoldurkullanici()
        {
            con = new SqlConnection("Data Source=localhost;Initial Catalog=akaryakit;Integrated Security=True");
            da = new SqlDataAdapter("select [id],[kullanici_adi],[firma_adi],[eposta] from [akaryakit].[dbo].[firmalar] where kullanici_tipi='0'", con);
            ds = new DataSet();
            con.Open();
            da.Fill(ds, "firmalar");
            kullanicitable.DataSource = ds.Tables["firmalar"];
            con.Close();
        }

        void griddolduradmin()
        {
            con = new SqlConnection("Data Source=localhost;Initial Catalog=akaryakit;Integrated Security=True");
            da = new SqlDataAdapter("Select [id],[kullanici_adi],[firma_adi],[eposta] from [akaryakit].[dbo].[firmalar] where kullanici_tipi='1'", con);
            ds = new DataSet();
            con.Open();
            da.Fill(ds, "firmalar");
            admintable.DataSource = ds.Tables["firmalar"];
            con.Close();
        }

        private void admintable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void kullanicilar_Load(object sender, EventArgs e)
        {
            griddoldurkullanici();
            griddolduradmin();
        }
    }
}
