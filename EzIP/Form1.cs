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
        public static string line = "-----------------------------------------------------------------------------------";

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
            lstBox.Items.Add(line);

            runIPGrab();
        }
            private void runIPGrab()
            {

                try
                {
                    //Add the computers name to the listbox
                    lstBox.Items.Add("Hostname: " + Dns.GetHostName());
                    lstBox.Items.Add(line);

                    string ip;
                    IPHostEntry host = default(IPHostEntry); //host ip adapters
                    string hostname;
                    hostname = System.Environment.MachineName; //host's computer
                    host = Dns.GetHostEntry(hostname); //checking the dns entries on the computer
                    foreach (IPAddress IP in host.AddressList) //for every ip adapter in host computer...
                    {
                        if (IP.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork) //if the ip = ipv4
                        {
                            ip = Convert.ToString(IP); //store in a string
                            lstBox.Items.Add(ip); //output to listbox
                            lstBox.Items.Add(line);
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
                if (!(lstBox.SelectedItem as string == line)){
                Clipboard.SetText(Convert.ToString(lstBox.SelectedItem));
                toolLbl.Text = ("Copied " + lstBox.SelectedItem + " to clipboard");
                }
            }
            catch (Exception ex)
            {
                toolLbl.Text = ex.Message;
            }
        }
    }
}
