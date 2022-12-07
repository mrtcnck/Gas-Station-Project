using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace akaryakit2
{
    public partial class istasyonlar : Form
    {
        public istasyonlar()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ProcessStartInfo info = new ProcessStartInfo(@"C:\Program Files (x86)\Microsoft\Edge\Application\msedge.exe", "https://maps.app.goo.gl/Ag9D5wTUPY2mt8Xc7?g_st=iw");
            Process.Start(info);
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ProcessStartInfo info = new ProcessStartInfo(@"C:\Program Files (x86)\Microsoft\Edge\Application\msedge.exe", "https://maps.app.goo.gl/Qg6QoARe4c7VKDrUA?g_st=iw");
            Process.Start(info);
        }
    }
}
