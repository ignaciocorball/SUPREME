using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace SUPREMEUPDATER
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            if (CheckForInternetConnnection())
            {
                UpdateProcess();
                timerDots.Start();
            }
            else
            {
                Hide();
                FormConn fc = new FormConn();
                fc.ShowDialog();
                Environment.Exit(0);
            }
        }
        public static bool CheckForInternetConnnection()
        {
            try
            {
                using (var client = new WebClient())
                {
                    using (var stream = client.OpenRead("https://www.google.com"))
                    {
                        return true;
                    }
                }
            }
            catch
            {
                return false;
            }
        }
        string getCurrentDirectory = Directory.GetCurrentDirectory();
        string DownloadLink = "https://techcoy.xyz/Supreme/Downloads/SUPREME_UPDATE.zip";
        int contador = 1;
        int cc = 0;
        private string GetShortcutInfo(string full_name)
        {
            string path = "";
            try
            {
                Shell32.Shell shell = new Shell32.Shell();
                string shortcut_path = full_name.Substring(0, full_name.LastIndexOf("\\"));
                string shortcut_name = full_name.Substring(full_name.LastIndexOf("\\") + 1);
                if (!shortcut_name.EndsWith(".lnk"))
                    shortcut_name += ".lnk";
                Shell32.Folder shortcut_folder = shell.NameSpace(shortcut_path);
                Shell32.FolderItem folder_item = shortcut_folder.Items().Item(shortcut_name);

                if (folder_item == null)

                    if (!folder_item.IsLink)
                        return "File '" + full_name + "' isn't a shortcut.";
                Shell32.ShellLinkObject lnk =
                    (Shell32.ShellLinkObject)folder_item.GetLink;
                path = lnk.Path;
                return path;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        private void UpdateProcess()
        {
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string inkPath = getCurrentDirectory + @"\SUPREME";
            if (getCurrentDirectory == desktopPath)
            {
                try
                {
                    string shortcutPath = GetShortcutInfo(inkPath);
                    string parser = shortcutPath.Replace("SUPREME.exe", @"\SUPREME_UPDATE.zip");
                    string SupremeZIPPath = parser;
                    WebClient wc2 = new WebClient();
                    wc2.DownloadFileCompleted += new AsyncCompletedEventHandler(CompletedDownload);
                    wc2.DownloadProgressChanged += new DownloadProgressChangedEventHandler(ProgressChanged);
                    wc2.DownloadFileAsync(new Uri(DownloadLink), SupremeZIPPath);
                }
                catch
                {
                    MessageBox.Show("Problem downloading the update. Server are in maintenance");
                    Environment.Exit(0);
                }
            }
            else
            {
                try
                {
                    string SupremeZIPPath = getCurrentDirectory + @"\SUPREME_UPDATE.zip";
                    WebClient wc2 = new WebClient();
                    wc2.DownloadFileCompleted += new AsyncCompletedEventHandler(CompletedDownload2);
                    wc2.DownloadProgressChanged += new DownloadProgressChangedEventHandler(ProgressChanged);
                    wc2.DownloadFileAsync(new Uri(DownloadLink), SupremeZIPPath);
                }
                catch
                {
                    MessageBox.Show("Problem downloading the update. Server are in maintenance");
                    Environment.Exit(0);
                }
            }
        }
        public void CompletedDownload(object sender, AsyncCompletedEventArgs e)
        {
            try
            {
                string inkPath = getCurrentDirectory + @"\SUPREME";
                string shortcutPath = GetShortcutInfo(inkPath);
                string parser = shortcutPath.Replace("SUPREME.exe", @"\helper_v2.exe");
                Process.Start(parser);
                Close();
            }
            catch
            {

            }

        }
        public void CompletedDownload2(object sender, AsyncCompletedEventArgs e)
        {
            try
            {
                Process.Start(getCurrentDirectory + @"\helper_v2.exe");
                Close();
            }
            catch
            {

            }

        }
        private void ProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            lblPercent.Text = e.ProgressPercentage.ToString() + "%";
            ProgressBar.Width = ((e.ProgressPercentage * ProgressBar.MaximumSize.Width) / 100);
            if (e.ProgressPercentage == 100)
            {
                lblPercent.Location = new System.Drawing.Point(190, 300);
                lblPercent.Text = "Installing...";
            }
        }

        /*
         * FRONT END CODE
         */
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);
        private void LoadingGif_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        private void timerDots_Tick(object sender, EventArgs e)
        {

            switch (contador)
            {
                case 4:
                    label1.Text = "UPDATING CLIENT...";
                    contador = 1;
                    break;
                case 3:
                    label1.Text = "UPDATING CLIENT..";
                    contador = 4;
                    break;
                case 2:
                    label1.Text = "UPDATING CLIENT.";
                    contador = 3;
                    break;
                case 1:
                    label1.Text = "UPDATING CLIENT";
                    contador = 2;
                    break;
            }

        }
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        private void LoadingGif_MouseDown_1(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
    }
}
