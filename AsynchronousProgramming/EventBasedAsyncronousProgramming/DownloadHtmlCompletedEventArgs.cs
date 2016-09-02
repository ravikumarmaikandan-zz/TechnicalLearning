using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventBasedAsyncronousProgramming
{
    public class DownloadHtmlCompletedEventArgs: System.ComponentModel.AsyncCompletedEventArgs
    {
        public DownloadHtmlCompletedEventArgs(Exception error, bool cancelled,string html): 
            base(error,cancelled, null)
        {
            HTML = html;

        }

        public string HTML
        {
            get; private set;
        }
    }
}   
