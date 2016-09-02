using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EventBasedAsyncronousProgramming
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void htmlClient_DownloadHtmlCompleted(object sender, DownloadHtmlCompletedEventArgs e)
        {
            string html = e.HTML;
            btnSync.Enabled = true;
            btnAsync.Enabled = true;

            progressBar1.Value = progressBar1.Maximum;
            progressBar1.Style = ProgressBarStyle.Blocks;

        }

        private void btnSync_Click(object sender, EventArgs e)
        {
            btnSync.Enabled = false;
            btnAsync.Enabled = false;

            progressBar1.Value = progressBar1.Minimum;
            progressBar1.Style = ProgressBarStyle.Marquee;

            string html = htmlClient.DownloadHtml("http://google.com");

            btnSync.Enabled = true;
            btnAsync.Enabled = true;

            progressBar1.Value = progressBar1.Maximum;
            progressBar1.Style = ProgressBarStyle.Blocks;
        }

        private void btnAsync_Click(object sender, EventArgs e)
        {
            btnSync.Enabled = false;
            btnAsync.Enabled = false;

            progressBar1.Value = progressBar1.Minimum;
            progressBar1.Style = ProgressBarStyle.Marquee;

            htmlClient.DownloadHtmlAsync("http://google.com");
        }
    }
}
