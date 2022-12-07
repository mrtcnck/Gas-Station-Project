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
    public partial class araclar : Form
    {
        public araclar()
        {
            InitializeComponent();
        }

        SqlConnection con;
        SqlDataAdapter da;
        DataSet ds;

        private void araclar_Load(object sender, EventArgs e)
        {
            plakagrid.BackgroundColor = Color.Black;
            con = new SqlConnection("Data Source=localhost;Initial Catalog=akaryakit;Integrated Security=True");
            da = new SqlDataAdapter("select [plakaid],[plaka] from [akaryakit].[dbo].[plakalar] where firmaid='" + plaka.id_al() + "'", con);
            ds = new DataSet();
            con.Open();
            da.Fill(ds, "plakalar");
            plakagrid.DataSource = ds.Tables["plakalar"];
            con.Close();
        }
    }
}
