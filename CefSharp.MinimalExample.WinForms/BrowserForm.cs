using System;
using System.Diagnostics;
using System.Windows.Forms;
using CefSharp.MinimalExample.WinForms.Controls;
using CefSharp.WinForms;

namespace CefSharp.MinimalExample.WinForms
{
    public partial class BrowserForm : Form
    {
        private ChromiumWebBrowser browser;
        private string url = "";

        private void BrowserForm_Load(object sender, EventArgs e)
        {
            Init();
        }

        private async void Init()
        {
        
          
                url = "https://www.google.com/";
          

            browser = new ChromiumWebBrowser(url)
            {
                Dock = DockStyle.Fill
            };

            toolStripContainer.ContentPanel.Controls.Add(browser);

            browser.MenuHandler = new CustomMenuHandler();
            browser.IsBrowserInitializedChanged += OnIsBrowserInitializedChanged;
            browser.LoadingStateChanged += OnLoadingStateChanged;

            //DownloadHandler downer = new DownloadHandler(this);
            //browser.DownloadHandler = downer;
            //downer.OnBeforeDownloadFired += OnBeforeDownloadFired;
            //downer.OnDownloadUpdatedFired += OnDownloadUpdatedFired;
        }

        private void BrowserForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            browser.MenuHandler = null;
            browser.RequestHandler = null;
            browser.DownloadHandler = null;
            browser.IsBrowserInitializedChanged -= OnIsBrowserInitializedChanged;
            browser.LoadingStateChanged -= OnLoadingStateChanged;

            //try
            //{
            //    browser.Dispose();
            //    Cef.Shutdown();
            //}
            //catch (Exception ee)
            //{

            //    Console.WriteLine(ee.ToString());

            //}
        }


        public BrowserForm()
        {
            InitializeComponent();
        }

        private void OnIsBrowserInitializedChanged(object sender, EventArgs e)
        {
            //if (e.IsBrowserInitialized)
            //{
            //    var b = ((ChromiumWebBrowser)sender);

            //    this.InvokeOnUiThreadIfRequired(() => b.Focus());
            //}
        }

        private void OnBeforeDownloadFired(object sender, DownloadItem e)
        {
            //Text = $"T"
            //this.UpdateDownloadAction("OnBeforeDownload", e);
        }

        private void OnDownloadUpdatedFired(object sender, DownloadItem e)
        {
            //this.UpdateDownloadAction("OnDownloadUpdated", e);

            if (e.IsComplete)
                Process.Start(e.FullPath);

        }

        private void OnBrowserConsoleMessage(object sender, ConsoleMessageEventArgs args)
        {
            // DisplayOutput(string.Format("Line: {0}, Source: {1}, Message: {2}", args.Line, args.Source, args.Message));
        }

        private void OnBrowserStatusMessage(object sender, StatusMessageEventArgs args)
        {
            // this.InvokeOnUiThreadIfRequired(() => statusLabel.Text = args.Value);
        }

        private void OnLoadingStateChanged(object sender, LoadingStateChangedEventArgs args)
        {
            SetCanGoBack(args.CanGoBack);
            SetCanGoForward(args.CanGoForward);

            this.InvokeOnUiThreadIfRequired(() => progressBar1.Visible = !args.CanReload);
        }

        private void OnBrowserTitleChanged(object sender, TitleChangedEventArgs args)
        {
            this.InvokeOnUiThreadIfRequired(() => Text = args.Title);
        }



        private void SetCanGoBack(bool canGoBack)
        {
            // this.InvokeOnUiThreadIfRequired(() => btnBack.Enabled = canGoBack);
        }

        private void SetCanGoForward(bool canGoForward)
        {
            // this.InvokeOnUiThreadIfRequired(() => btnForward.Enabled = canGoForward);
        }



        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            browser.ShowDevTools();
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            Action close = () => this.Close();
            if (InvokeRequired)
                Invoke(close);
            else
                close();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            browser.Back();
        }

        private void btnForward_Click(object sender, EventArgs e)
        {
            browser.Forward();
        }

        private void btnMin_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            browser.Reload();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            browser.Load(url);
        }

    }
}
