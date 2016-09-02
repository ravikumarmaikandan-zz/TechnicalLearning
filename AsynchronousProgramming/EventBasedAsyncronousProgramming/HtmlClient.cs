using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EventBasedAsyncronousProgramming
{
    public class HtmlClient: System.ComponentModel.Component
    {
        public HtmlClient()
        {
            //Implement Async
            InitializeCallbacks();
        }

        private void InitializeCallbacks()
        {
            DownloadHtmlCompletedCallBack = new SendOrPostCallback(InternalDownloadHtmlCompleted);
        }
        #region Callback

        private delegate void DownloadHtmlCallback(Uri address, AsyncOperation asyncOperation);

        private SendOrPostCallback DownloadHtmlCompletedCallBack;
        #endregion
        #region Event

        public event EventHandler<DownloadHtmlCompletedEventArgs> DownloadHtmlCompleted;

        protected virtual void OnDownloadHtmlCompleted(DownloadHtmlCompletedEventArgs e)
        {
            EventHandler<DownloadHtmlCompletedEventArgs> handler = DownloadHtmlCompleted;
            //If the handler is not null then call the invoke method
            //This is a null propogation 
            handler?.Invoke(this, e);
        }
#endregion
        #region Public Methods
        /// <summary>
        /// 
        /// </summary>
        public string DownloadHtml(Uri address)
        {
            return InternalDownloadHtml(address);
        }
        public string DownloadHtml(string address)
        {
            return DownloadHtml(new Uri(address));
        }

        public void DownloadHtmlAsync(Uri address)
        {
            AsyncOperation asyncOperation = AsyncOperationManager.CreateOperation(null);
            DownloadHtmlCallback callBack = new DownloadHtmlCallback(InternalDownloadHtmlAsync);
            callBack.BeginInvoke(address, asyncOperation, null, null);
        }
        public void DownloadHtmlAsync(string address)
        {
            DownloadHtmlAsync(new Uri(address));
        }

        #endregion
        #region Implementation
        private string InternalDownloadHtml(Uri address)
        {
            var request = HttpWebRequest.Create(address);
            var response = request.GetResponse();
            string html = string.Empty;
            using (var reader = new StreamReader(response.GetResponseStream()))
            {
                html = reader.ReadToEnd();
            }
            Thread.Sleep(5000);// long running task
            return html;
        }

        private void InternalDownloadHtmlAsync(Uri address, AsyncOperation asyncOperation)
        {
            string html = InternalDownloadHtml(address);
            DownloadHtmlCompletedEventArgs e = new DownloadHtmlCompletedEventArgs(null,false,html);
            asyncOperation.PostOperationCompleted(DownloadHtmlCompletedCallBack,e);
        }

        private void InternalDownloadHtmlCompleted(object state)
        {
            DownloadHtmlCompletedEventArgs e = (DownloadHtmlCompletedEventArgs) state;
            OnDownloadHtmlCompleted(e);
        }
#endregion
    }
}
