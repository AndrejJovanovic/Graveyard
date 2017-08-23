// This script runs the actions from Form and runs main function
// that resolves hostname and writes data into text field

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
using System.Net.Sockets;
using ARSoft.Tools.Net.Dns;
using ARSoft.Tools.Net;

namespace Graveyard
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.Write("Button Clicked!");
            DoGetHostEntry(textBox1.Text);
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        
        }

        public void textBox2_TextChanged(object sender, EventArgs e)
        {
            
        }

        public void DoGetHostEntry(string hostname)
        {
            IDnsResolver resolver = new DnsStubResolver();

            RecordType mx = new RecordType();

            mx = RecordType.Mx;

            //IPHostEntry host;

            try
            {
                //host = Dns.GetHostEntry(hostname);

                // This block works but has a problem with parsing only IPs
                // becuase it has no AnswerRecords method so you can't filter
                // record. It comes with hostname and TTL

                List<DnsRecordBase> addresses = resolver.Resolve<DnsRecordBase>(hostname,mx);
                //Console.WriteLine("GetHostEntry({0}) returns:", hostname);

                // This Block Resolves IP adress depending on DnsClient class 
                // Has a problem with hostname beacuse it does not takes string
                // but a DnsHostname class

                /*var response = DnsClient.Default.Resolve(hostname,RecordType.Mx);
                var records = response.AnswerRecords.OfType<MxRecord>();
                foreach (var record in records)
                {
                    textBox2.Text = record.ExchangeDomainName.ToString();
                }
                */
          

                //Console.WriteLine("    {0}", ip);
                //textBox2.Text = ip.ToString();
                foreach (DnsRecordBase host in addresses)
                {
                    textBox2.Text = host.ToString();
                }
            }
            catch (SocketException e)
            {
                Console.WriteLine("SocketException caught!!!");
                Console.WriteLine("Source : " + e.Source);
                Console.WriteLine("Message : " + e.Message);
                textBox2.Text = "Not Found!";
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine("ArgumentNullException caught!!!");
                Console.WriteLine("Source : " + e.Source);
                Console.WriteLine("Message : " + e.Message);
                textBox2.Text = "Not Found!";
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception caught!!!");
                Console.WriteLine("Source : " + e.Source);
                Console.WriteLine("Message : " + e.Message);
                textBox2.Text = "Error!";
            }
        }
    }
}
