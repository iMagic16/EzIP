using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;

namespace EzIP
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            toolLbl.Text = "Click on an IP to copy to clipboard";
            init();
        }
        private void init()
        {
            lstBox.Items.Add("The IPs of all of your adapters");
            lstBox.Items.Add("Click on one to copy to clipboard");
            lstBox.Items.Add("-----------------------------------------------------------------------------------");

            runIPGrab();
        }
        private void runIPGrab()
        {

            try
            {
                lstBox.Items.Add("Hostname: " + Dns.GetHostName());
                lstBox.Items.Add("-----------------------------------------------------------------------------------");

                string ip;
                IPHostEntry host = default(IPHostEntry);
                string hostname;
                hostname = System.Environment.MachineName;
                host = Dns.GetHostEntry(hostname);
                foreach (IPAddress IP in host.AddressList)
                {
                    if (IP.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                    {
                        ip = Convert.ToString(IP);
                        lstBox.Items.Add(ip);
                        lstBox.Items.Add("-----------------------------------------------------------------------------------");
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }

        private void lstBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Clipboard.SetText(Convert.ToString(lstBox.SelectedItem));
                toolLbl.Text = ("Copied " + lstBox.SelectedItem + " to clipboard");
            }
            catch (Exception ex)
            {
                toolLbl.Text = ex.Message;
            }
        }
    }
}
