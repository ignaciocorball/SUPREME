using Newtonsoft.Json;
using Supreme;
using Supreme.Forms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Net;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;
/*
 * +====================================================================================+
 * |  [*][][][*] [*]    [*] [+][][][+] [+][][][+] [*][][][*]  [*][]   [][*] [*][][][*]  |
 * |  [*]        [*]    [*] [+]    [+] [+]    [+] [*]         [*]  [*]  [*] [*]         |
 * |  [*][][][*] [*]    [*] [+][][+]   [+][][+]   [*][][][*]  [*]       [*] [*][][][*]  |
 * |         [*] [*]    [*] [+]        [+]    [+] [*]         [*]       [*] [*]         |
 * |  [*][][][*] [+][][][+] [+]        [+]    [+] [*][][][*]  [*]       [*] [*][][][*]  |
 * |====================================================================================|
 * |                 DEVELOPED BY GhostY ©2019-2024 All rights reserved                 |
 * +====================================================================================+
 */
namespace formPrincipal
{
    public partial class formPrincipal : Form
    {
        public formPrincipal()
        {
            Supreme.Properties.Settings.Default.C_Assembly_Version = Assembly.GetExecutingAssembly().GetName().Version.ToString();
            Supreme.Properties.Settings.Default.Supreme_Path = Directory.GetCurrentDirectory();
            Supreme.Properties.Settings.Default.formLoaderIsReady = false;
            InitializeComponent();
            if (File.Exists(SupremeZIP))
            {
                File.Delete(SupremeZIP);
            }
            InitializeApp();
        }
        private void SupremePicker_Load(object sender, EventArgs e)
        {
            timerLoaderForm.Start();
            timerLoaderForm.Enabled = true;
            CssINCsharp();
            InitCustomLabelFont();
            timerMessage.Enabled = true;
            timerMessage.Start();
            switch (Supreme.Properties.Settings.Default.Language)
            {
                case 0:
                        int r = WMessageRnd.Next(WMessageEN.Count);
                        lblTester.Text = (string)WMessageEN[r];
                    break;
                case 1:
                        r = WMessageRnd.Next(WMessageES.Count);
                        lblTester.Text = (string)WMessageES[r];
                    break;
                case 2:
                        r = WMessageRnd.Next(WMessagePR.Count);
                        lblTester.Text = (string)WMessagePR[r];
                    break;
            }
            lblTester.AutoSize = true;
            lblTester.Location = new Point(920, 9);
            btnAutoOff_Click(sender, e);
        }

        #region EVENTS & METHODS
        private void InitializeApp()
        {
            if (CheckForInternetConnnection())
            {
                if (ServerStatusBy(Supreme.Properties.Settings.Default.serverDomain))
                {
                    DownloadJson();
                    LoadData();
                    string currentVersion = Supreme.Properties.Settings.Default.C_Assembly_Version.Replace(".", "");
                    string latestVersion = Supreme.Properties.Settings.Default.L_Assembly_Version.Replace(".", "");
                    int cv = Convert.ToInt32(currentVersion);
                    int lv = Convert.ToInt32(latestVersion);
                    SponsorBannerLoader();
                    if (cv >= lv)
                    {
                        lblAssembly.Text = Supreme.Properties.Settings.Default.C_Assembly_Version;
                        formLComponents fLC = new formLComponents();
                        fLC.Show();
                    }
                    else
                    {
                        Update fp = new Update();
                        fp.ShowDialog();
                        formLComponents fLC = new formLComponents();
                        fLC.Show();
                    }
                }
                else
                {
                    LoadData();
                    lblAssembly.Text = Supreme.Properties.Settings.Default.C_Assembly_Version;
                    lblTester.Text = "Server in maintenance. Dont worry! The app Works fine :)";
                    formLComponents fLC = new formLComponents();
                    fLC.Show();
                }
            }
            else
            {
                FormConnection fc = new FormConnection();
                fc.ShowDialog();
            }
        }
        private void CssINCsharp()
        {
            //Panel OVERVIEWS
            pictureBox4.Parent = pictureBox8;
            lblBlazing1.Parent = pictureBox8;
            lblPingOVCL.Parent = pictureBox8;
            label12.Parent = pictureBox8;
            label16.Parent = pictureBox8;
            label20.Parent = pictureBox8;
            label24.Parent = pictureBox8;
            lblPOverviews.Parent = pictureBox8;
            lblCOverviews.Parent = pictureBox8;
            lblSOverviews.Parent = pictureBox8;
            //Panel GAMERSCLUB
            pictureBox3.Parent = pictureBox9;
            label1.Parent = pictureBox9;
            label2.Parent = pictureBox9;
            label3.Parent = pictureBox9;
            label4.Parent = pictureBox9;
            label15.Parent = pictureBox9;
            label19.Parent = pictureBox9;
            label23.Parent = pictureBox9;
            lblPingGCBR.Parent = pictureBox9;
            lblPingGCAR.Parent = pictureBox9;
            lblPingGCCL.Parent = pictureBox9;
            label5.Parent = pictureBox9;
            label27.Parent = pictureBox9;
            label28.Parent = pictureBox9;
            //Panel FACEIT
            pictureBox5.Parent = pictureBox10;
            label10.Parent = pictureBox10;
            lblPingFCBR1.Parent = pictureBox10;
            label13.Parent = pictureBox10;
            label17.Parent = pictureBox10;
            label21.Parent = pictureBox10;
            label25.Parent = pictureBox10;
            lblFaceitPlatform.Parent = pictureBox10;
            lblFaceitServers.Parent = pictureBox10;
            lblFaceitAC.Parent = pictureBox10;
            //Panel VALVE
            pictureBox6.Parent = pictureBox11;
            label7.Parent = pictureBox11;
            label8.Parent = pictureBox11;
            label9.Parent = pictureBox11;
            label14.Parent = pictureBox11;
            label18.Parent = pictureBox11;
            label22.Parent = pictureBox11;
            label26.Parent = pictureBox11;
            lblValveBR.Parent = pictureBox11;
            lblValvePE.Parent = pictureBox11;
            lblValveCL.Parent = pictureBox11;
            lblValvePlatform.Parent = pictureBox11;
            lblValveClient.Parent = pictureBox11;
            lblValveServers.Parent = pictureBox11;
            //MISC
            btnAutoOn.Parent = picBackground;
            btnAutoOff.Parent = picBackground;

            GreenA1.Parent = picBackground;
            GreenA2.Parent = picBackground;
            GreenA3.Parent = picBackground;
            GreenA4.Parent = picBackground;
        }
        public static bool ServerStatusBy(string url)
        {
            try
            {
                Ping pingSender = new Ping();
                PingReply reply = pingSender.Send(url);
                if (reply.Status == IPStatus.Success)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }
        private void DownloadJson()
        {
            try
            {
                using (WebClient wc = new WebClient())
                {
                    ServicePointManager.Expect100Continue = true;
                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                    var json = wc.DownloadString(Supreme.Properties.Settings.Default.settings_json_url);
                    settings_json_string = json;
                }
                dynamic dynObj = JsonConvert.DeserializeObject(settings_json_string);
                foreach (var data in dynObj.supreme_settings)
                {
                    Supreme.Properties.Settings.Default.L_Assembly_Version = data.assembly_version;
                    Supreme.Properties.Settings.Default.Banner_URL = data.bannerurl;
                    Supreme.Properties.Settings.Default.Server_STATUS = data.server_status;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error DownloadJson Method: " + ex);
            }
        }
        private void InitCustomLabelFont()
        {
            try
            {
                byte[] fontData = Supreme.Properties.Resources.LEMONMILK_Bold;
                IntPtr fontPtr = Marshal.AllocCoTaskMem(fontData.Length);
                Marshal.Copy(fontData, 0, fontPtr, fontData.Length);
                uint dummy = 0;
                LEMONMILK_BOLD.AddMemoryFont(fontPtr, Supreme.Properties.Resources.LEMONMILK_Bold.Length);
                AddFontMemResourceEx(fontPtr, (uint)Supreme.Properties.Resources.LEMONMILK_Bold.Length, IntPtr.Zero, ref dummy);
                Marshal.FreeCoTaskMem(fontPtr);

                lblTest.Font = new Font(LEMONMILK_BOLD.Families[0], 10);
                lblAssembly.Font = new Font(LEMONMILK_BOLD.Families[0], 8);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error InitCustomLabelFont Method: " + ex);
            }
        }
        private bool RemoteFileExists(string url)
        {
            try
            {
                HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
                request.Method = "GET";
                HttpWebResponse response = request.GetResponse() as HttpWebResponse;
                response.Close();
                return (response.StatusCode == HttpStatusCode.OK);
            }
            catch
            {
                return false;
            }
        }
        private void SponsorBannerLoader()
        {
            if (RemoteFileExists(Supreme.Properties.Settings.Default.sponsorBannerGIF))
            {
                sponsorBanner.Load(Supreme.Properties.Settings.Default.sponsorBannerGIF);
            }
            else
            {
                sponsorBanner.Load(Supreme.Properties.Settings.Default.sponsorBannerPNG);
            }
        }
        private void LoadData()
        {
            GetSteamPlatformStatus();
            PerlaNegra.ScriptErrorsSuppressed = true;
            PerlaNegra.Navigate(Supreme.Properties.Settings.Default.FaceitPlatform);
            PerlaNegra.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(GetFaceitPlatformStatus);
            lblAssembly.Text = Supreme.Properties.Settings.Default.L_Assembly_Version;
        }
        public void GamersclubPing()
        {
            //Set up labels Gamersclub
            lblPingGCCL.Text = (MSGCCL + " ms");
            if (MSGCCL > 170) { lblPingGCCL.ForeColor = Color.Red; }
            if (MSGCCL <= 169) { lblPingGCCL.ForeColor = Color.Yellow; }
            if (MSGCCL <= 99) { lblPingGCCL.ForeColor = Color.Green; }
            if (MSGCCL < 49) { lblPingGCCL.ForeColor = Color.LimeGreen; }
            if (MSGCCL == 0) { lblPingGCCL.ForeColor = Color.Red; lblPingGCCL.Text = "timeout"; }

            lblPingGCBR.Text = (MSGCBR + " ms");
            if (MSGCBR > 170) { lblPingGCBR.ForeColor = Color.Red; }
            if (MSGCBR <= 169) { lblPingGCBR.ForeColor = Color.Yellow; }
            if (MSGCBR <= 99) { lblPingGCBR.ForeColor = Color.Green; }
            if (MSGCBR < 49) { lblPingGCBR.ForeColor = Color.LimeGreen; }
            if (MSGCBR == 0) { lblPingGCBR.ForeColor = Color.Red; lblPingGCBR.Text = "timeout"; }

            lblPingGCAR.Text = (MSGCAR + " ms");
            if (MSGCAR > 170) { lblPingGCAR.ForeColor = Color.Red; }
            if (MSGCAR <= 169) { lblPingGCAR.ForeColor = Color.Yellow; }
            if (MSGCAR <= 99) { lblPingGCAR.ForeColor = Color.Green; }
            if (MSGCAR < 49) { lblPingGCAR.ForeColor = Color.LimeGreen; }
            if (MSGCAR == 0) { lblPingGCAR.ForeColor = Color.Red; lblPingGCAR.Text = "timeout"; }

            //Panel Gamersclub colors
            if (lblPingGCCL.ForeColor == Color.Yellow && lblPingGCBR.ForeColor == Color.Yellow) { pictureBox9.BackColor = Color.Yellow; }
            if (lblPingGCAR.ForeColor == Color.Yellow && lblPingGCCL.ForeColor == Color.Yellow) { pictureBox9.BackColor = Color.Yellow; }
            if (lblPingGCBR.ForeColor == Color.Yellow && lblPingGCAR.ForeColor == Color.Yellow) { pictureBox9.BackColor = Color.Yellow; }

            if (lblPingGCCL.ForeColor == Color.Red && lblPingGCBR.ForeColor == Color.Red) { pictureBox9.BackColor = Color.Red; }
            if (lblPingGCAR.ForeColor == Color.Red && lblPingGCCL.ForeColor == Color.Red) { pictureBox9.BackColor = Color.Red; }
            if (lblPingGCBR.ForeColor == Color.Red && lblPingGCAR.ForeColor == Color.Red) { pictureBox9.BackColor = Color.Red; }

            if (lblPingGCCL.ForeColor == Color.Green && lblPingGCBR.ForeColor == Color.Green) { pictureBox9.BackColor = Color.Green; }
            if (lblPingGCAR.ForeColor == Color.Green && lblPingGCCL.ForeColor == Color.Green) { pictureBox9.BackColor = Color.Green; }
            if (lblPingGCBR.ForeColor == Color.Green && lblPingGCAR.ForeColor == Color.Green) { pictureBox9.BackColor = Color.Green; }

            if (lblPingGCCL.ForeColor == Color.LimeGreen && lblPingGCBR.ForeColor == Color.LimeGreen) { pictureBox9.BackColor = Color.LimeGreen; }
            if (lblPingGCAR.ForeColor == Color.LimeGreen && lblPingGCCL.ForeColor == Color.LimeGreen) { pictureBox9.BackColor = Color.LimeGreen; }
            if (lblPingGCBR.ForeColor == Color.LimeGreen && lblPingGCAR.ForeColor == Color.LimeGreen) { pictureBox9.BackColor = Color.LimeGreen; }

            if (lblPingGCCL.ForeColor == Color.LimeGreen && lblPingGCBR.ForeColor == Color.Green && lblPingGCAR.ForeColor == Color.Red) { pictureBox9.BackColor = Color.LimeGreen; }
            if (lblPingGCCL.ForeColor == Color.LimeGreen && lblPingGCBR.ForeColor == Color.Yellow) { pictureBox9.BackColor = Color.Green; }
            if (lblPingGCAR.ForeColor == Color.LimeGreen && lblPingGCCL.ForeColor == Color.Yellow) { pictureBox9.BackColor = Color.Green; }
            if (lblPingGCBR.ForeColor == Color.LimeGreen && lblPingGCAR.ForeColor == Color.Yellow) { pictureBox9.BackColor = Color.Green; }
            if (lblPingGCBR.ForeColor == Color.LimeGreen && lblPingGCCL.ForeColor == Color.Yellow) { pictureBox9.BackColor = Color.Green; }
            if (lblPingGCBR.ForeColor == Color.LimeGreen && lblPingGCCL.ForeColor == Color.Red) { pictureBox9.BackColor = Color.Green; }
            if (lblPingGCAR.ForeColor == Color.Green && lblPingGCCL.ForeColor == Color.Yellow) { pictureBox9.BackColor = Color.Green; }
            if (lblPingGCAR.ForeColor == Color.Green && lblPingGCCL.ForeColor == Color.Yellow) { pictureBox9.BackColor = Color.Green; }
            if (lblPingGCBR.ForeColor == Color.Red && lblPingGCAR.ForeColor == Color.Green) { pictureBox9.BackColor = Color.Yellow; }
            if (lblPingGCCL.ForeColor == Color.LimeGreen && lblPingGCBR.ForeColor == Color.Red && lblPingGCAR.ForeColor == Color.Green) { pictureBox9.BackColor = Color.Green; }

        }
        public void FaceitPing()
        {
            //Set up Faceit Labels
            lblPingFCBR1.Text = (MSFCBR1 + " ms");
            if (MSFCBR1 > 170) { lblPingFCBR1.ForeColor = Color.Red; }
            if (MSFCBR1 <= 169) { lblPingFCBR1.ForeColor = Color.Yellow; }
            if (MSFCBR1 <= 99) { lblPingFCBR1.ForeColor = Color.Green; }
            if (MSFCBR1 < 49) { lblPingFCBR1.ForeColor = Color.LimeGreen; }
            if (MSFCBR1 == 0) { lblPingFCBR1.ForeColor = Color.Red; lblPingFCBR1.Text = "timeout"; }

            //Panel Faceit colors
            if (lblPingFCBR1.ForeColor == Color.LimeGreen) { pictureBox10.BackColor = Color.LimeGreen; }
            if (lblPingFCBR1.ForeColor == Color.Green) { pictureBox10.BackColor = Color.Green; }
            if (lblPingFCBR1.ForeColor == Color.Yellow) { pictureBox10.BackColor = Color.Yellow; }
            if (lblPingFCBR1.ForeColor == Color.Red) { pictureBox10.BackColor = Color.Red; }
        }
        public void OverViewsPing()
        {
            //Labels OverViews colors
            if (MSOVCL != 0)
            {
                if (MSOVCL < 49) { lblPingOVCL.ForeColor = Color.LimeGreen; }
                else
                {
                    if (MSOVCL <= 99) { lblPingOVCL.ForeColor = Color.Green; }
                    else
                    {
                        if (MSOVCL <= 169) { lblPingOVCL.ForeColor = Color.Yellow; }
                        else { if (MSOVCL > 170) { lblPingOVCL.ForeColor = Color.Red; } }
                    }
                }

                lblPingOVCL.Text = (MSOVCL + " ms");
                if (MSOVCL == 0) { lblPingOVCL.ForeColor = Color.Red; lblPingOVCL.Text = "timeout"; }
            }

            //Panel OverViews colors
            if (MSOVCL > 161) { pictureBox8.BackColor = Color.Red; }
            if (MSOVCL <= 160) { pictureBox8.BackColor = Color.Yellow; }
            if (MSOVCL <= 99) { pictureBox8.BackColor = Color.Green; }
            if (MSOVCL <= 49) { pictureBox8.BackColor = Color.LimeGreen; }

        }
        public void ValvePing()
        {
            //Set up labels Valve
            if (MSVVLM1 != 0)
            {
                if (MSVVLM1 < 49) { lblValvePE.ForeColor = Color.LimeGreen; }
                else
                {
                    if (MSVVLM1 <= 99) { lblValvePE.ForeColor = Color.Green; }
                    else
                    {
                        if (MSVVLM1 <= 169) { lblValvePE.ForeColor = Color.Yellow; }
                        else { if (MSVVLM1 > 170) { lblValvePE.ForeColor = Color.Red; } }
                    }
                }
                lblValvePE.Text = (MSVVLM1 + " ms");
                if (MSVVLM1 == 0) { lblValvePE.ForeColor = Color.Red; lblValvePE.Text = "timeout"; }
            }

            if (MSVVBR1 != 0)
            {
                if (MSVVBR1 < 49) { lblValveBR.ForeColor = Color.LimeGreen; }
                else
                {
                    if (MSVVBR1 <= 99) { lblValveBR.ForeColor = Color.Green; }
                    else
                    {
                        if (MSVVBR1 <= 169) { lblValveBR.ForeColor = Color.Yellow; }
                        else { if (MSVVBR1 > 170) { lblValveBR.ForeColor = Color.Red; } }
                    }
                }
                lblValveBR.Text = (MSVVBR1 + " ms");
                if (MSVVBR1 == 0) { lblValveBR.ForeColor = Color.Red; lblValveBR.Text = "timeout"; }
            }

            if (MSVVCL1 != 0)
            {
                if (MSVVCL1 < 49) { lblValveCL.ForeColor = Color.LimeGreen; }
                else
                {
                    if (MSVVCL1 <= 99) { lblValveCL.ForeColor = Color.Green; }
                    else
                    {
                        if (MSVVCL1 <= 169) { lblValveCL.ForeColor = Color.Yellow; }
                        else { if (MSVVCL1 > 170) { lblValveCL.ForeColor = Color.Red; } }
                    }
                }
                lblValveCL.Text = (MSVVCL1 + " ms");
                if (MSVVCL1 == 0) { lblValveCL.ForeColor = Color.Red; lblValveCL.Text = "timeout"; }
            }

            //Draw Panels Colors
            if (lblValveBR.ForeColor == Color.Yellow && lblValvePE.ForeColor == Color.Yellow) { pictureBox11.BackColor = Color.Yellow; }
            if (lblValvePE.ForeColor == Color.Yellow && lblValveCL.ForeColor == Color.Yellow) { pictureBox11.BackColor = Color.Yellow; }
            if (lblValveCL.ForeColor == Color.Yellow && lblValveBR.ForeColor == Color.Yellow) { pictureBox11.BackColor = Color.Yellow; }
            if (lblValveBR.ForeColor == Color.Red && lblValvePE.ForeColor == Color.Red) { pictureBox11.BackColor = Color.Red; }
            if (lblValvePE.ForeColor == Color.Red && lblValveCL.ForeColor == Color.Red) { pictureBox11.BackColor = Color.Red; }
            if (lblValveCL.ForeColor == Color.Red && lblValveBR.ForeColor == Color.Red) { pictureBox11.BackColor = Color.Red; }
            if (lblValveBR.ForeColor == Color.Green && lblValvePE.ForeColor == Color.Green) { pictureBox11.BackColor = Color.Green; }
            if (lblValvePE.ForeColor == Color.Green && lblValveCL.ForeColor == Color.Green) { pictureBox11.BackColor = Color.Green; }
            if (lblValveCL.ForeColor == Color.Green && lblValveBR.ForeColor == Color.Green) { pictureBox11.BackColor = Color.Green; }
            if (lblValveBR.ForeColor == Color.LimeGreen && lblValvePE.ForeColor == Color.LimeGreen) { pictureBox11.BackColor = Color.LimeGreen; }
            if (lblValvePE.ForeColor == Color.LimeGreen && lblValveCL.ForeColor == Color.LimeGreen) { pictureBox11.BackColor = Color.LimeGreen; }
            if (lblValveCL.ForeColor == Color.LimeGreen && lblValveBR.ForeColor == Color.LimeGreen) { pictureBox11.BackColor = Color.LimeGreen; }
            if (lblValveBR.ForeColor == Color.Green && lblValvePE.ForeColor == Color.Yellow && lblValveCL.ForeColor == Color.Green) { pictureBox11.BackColor = Color.Green; }
            if (lblValveBR.ForeColor == Color.Red && lblValveCL.ForeColor == Color.LimeGreen) { pictureBox11.BackColor = Color.Yellow; }
            if (lblValveBR.ForeColor == Color.Red && lblValvePE.ForeColor == Color.Green && lblValveCL.ForeColor == Color.LimeGreen) { pictureBox11.BackColor = Color.Green; }
            if (lblValveBR.ForeColor == Color.LimeGreen && lblValvePE.ForeColor == Color.Yellow && lblValveCL.ForeColor == Color.Green) { pictureBox11.BackColor = Color.Green; }
            if (lblValveBR.ForeColor == Color.Green && lblValvePE.ForeColor == Color.Yellow && lblValveCL.ForeColor == Color.LimeGreen) { pictureBox11.BackColor = Color.Green; }
            if (lblValveBR.ForeColor == Color.Yellow && lblValvePE.ForeColor == Color.Green && lblValveCL.ForeColor == Color.LimeGreen) { pictureBox11.BackColor = Color.Green; }
            if (lblValveBR.ForeColor == Color.Yellow && lblValvePE.ForeColor == Color.Green && lblValveCL.ForeColor == Color.LimeGreen) { pictureBox11.BackColor = Color.Green; }
        }
        public void GetSteamPlatformStatus()
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            using (WebClient BlackPearl = new WebClient())
            {
                //Download Json File from SteamStatus
                BlackPearl.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; " +
                                  "Windows NT 5.2; .NET CLR 1.0.3705;)");
                var json = BlackPearl.DownloadString("https://crowbar.steamstat.us/gravity.json");
                string valueOriginal = Convert.ToString(json);

                //CSGO Client Status
                int first = json.IndexOf("community") + 14;
                int last = json.LastIndexOf("\"],[\"csgo\",");
                string json2 = json.Substring(first, last - first);
                if (json2 == "Normal")
                {
                    lblValveClient.Text = "Operational";
                    lblValveClient.ForeColor = Color.Lime;
                }
                else
                {
                    lblValveClient.Text = json2;
                    lblValveClient.ForeColor = Color.Yellow;
                }
                //CSGO Platform Status
                int first2 = json.IndexOf("cms") + 8;
                int last2 = json.LastIndexOf("\"],[\"community\",");
                string json3 = json.Substring(first2, last2 - first2);
                if (json3 == "Normal")
                {
                    lblValvePlatform.Text = "Operational";
                    lblValvePlatform.ForeColor = Color.Lime;
                }
                else
                {
                    lblValvePlatform.Text = json3;
                    lblValvePlatform.ForeColor = Color.Yellow;
                }

                //CSGO Servers Status
                int first3 = json.IndexOf("csgo_sessions") + 18;
                int last3 = json.LastIndexOf("\"],[\"csgo_singapore");
                string json4 = json.Substring(first3, last3 - first3);
                if (json4 == "Normal")
                {
                    lblValveServers.Text = "Operational";
                    lblValveServers.ForeColor = Color.Lime;
                }
                else
                {
                    lblValveServers.Text = json4;
                    lblValveServers.ForeColor = Color.Yellow;
                }
            }
        }
        public void GetFaceitPlatformStatus(object sender, EventArgs e)
        {
            foreach (HtmlElement etiqueta in PerlaNegra.Document.All)
            {
                if (etiqueta.GetAttribute("data-component-id").Contains("jxzw1p9yjrlc"))
                {
                    if (etiqueta.InnerText.Contains("Operational")) { lblFaceitPlatform.Text = "Operational"; lblFaceitPlatform.ForeColor = Color.Lime; }
                    else { lblFaceitPlatform.Text = "Maintenance"; lblFaceitPlatform.ForeColor = Color.Yellow; }
                }
            }
            foreach (HtmlElement etiqueta in PerlaNegra.Document.All)
            {
                if (etiqueta.GetAttribute("data-component-id").Contains("7qjbc4y9gr9r"))
                {
                    if (etiqueta.InnerText.Contains("Operational")) { lblFaceitServers.Text = "Operational"; lblFaceitServers.ForeColor = Color.Lime; }
                    else { lblFaceitServers.Text = "Maintenance"; lblFaceitServers.ForeColor = Color.Yellow; }
                }
            }
            foreach (HtmlElement etiqueta in PerlaNegra.Document.All)
            {
                if (etiqueta.GetAttribute("data-component-id").Contains("sc0r7wjsg4tv"))
                {
                    if (etiqueta.InnerText.Contains("Operational")) { lblFaceitAC.Text = "Operational"; lblFaceitAC.ForeColor = Color.Lime; }
                    else { lblFaceitAC.Text = "Maintenance"; lblFaceitAC.ForeColor = Color.Yellow; }
                }
            }
            PerlaNegra.Dispose();
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
        private async Task PlatformsPingAsync()
        {
            Ping ping = new Ping();
            //PINGS BLAZING
            try
            {
                PingReply pingReply4 =
                await ping.SendPingAsync("159.138.118.45");               //Overviews
                string converter1 = pingReply4.RoundtripTime.ToString();
                MSOVCL = Convert.ToInt32(converter1);
            }
            catch (Exception)
            {

            }
            //Pings GAMERSCLUB
            try
            {
                PingReply pingReply1 =
                await ping.SendPingAsync("168.195.130.10");
                string converter3 = pingReply1.RoundtripTime.ToString();   //Gamersclub Ping Chile
                MSGCCL = Convert.ToInt32(converter3);
                PingReply pingReply2 =
                await ping.SendPingAsync("45.164.124.103");                //Gamersclub Ping Brazil
                string converter4 = pingReply2.RoundtripTime.ToString();
                MSGCBR = Convert.ToInt32(converter4);
                PingReply pingReply3 =
                await ping.SendPingAsync("160.20.247.71");                 //Gamersclub Ping Argentina
                string converter5 = pingReply3.RoundtripTime.ToString();
                MSGCAR = Convert.ToInt32(converter5);
            }
            catch (Exception)
            {

            }
            //PINGS FACEIT
            try
            {
                PingReply pingReply6 =
                await ping.SendPingAsync("177.54.146.84");                  //Faceit Ping BR
                string converter6 = pingReply6.RoundtripTime.ToString();
                MSFCBR1 = Convert.ToInt32(converter6);
            }
            catch (Exception)
            {

            }
            //PINGS VALVE
            try
            {
                PingReply pingReply8 =
                await ping.SendPingAsync("190.217.33.34");                  //Valve Ping Peru
                string converter8 = pingReply8.RoundtripTime.ToString();
                MSVVLM1 = Convert.ToInt32(converter8);
                PingReply pingReply9 =
                await ping.SendPingAsync("205.185.194.34");                 //Valve Ping Brazil
                string converter9 = pingReply9.RoundtripTime.ToString();
                MSVVBR1 = Convert.ToInt32(converter9);
                PingReply pingReply10 =
                await ping.SendPingAsync("155.133.249.178");                 //Valve Ping Chile
                string converter10 = pingReply10.RoundtripTime.ToString();
                MSVVCL1 = Convert.ToInt32(converter10);

            }
            catch { }
            OverViewsPing();
            GamersclubPing();
            ValvePing();
            FaceitPing();
        }
        private void timerP_Tick(object sender, EventArgs e)
        {
            lblTest.ForeColor = Color.FromArgb(r.Next(0, 255), r.Next(0, 255), r.Next(0, 255));
            //LOAD GIF ANIMATION ON PANELS
            if (Supreme.Properties.Settings.Default.graphics == 1)
            {
                if (GreenA1.Visible == false)
                {
                    try
                    {
                        //OVERVIEWS
                        GreenA1.Visible = true;
                        //Green
                        if (pictureBox8.BackColor == Color.Green || pictureBox8.BackColor == Color.LimeGreen)
                        {
                            GreenA1.Load(Supreme.Properties.Settings.Default.Supreme_Path + "\\Resources\\GreenAnimation.gif");
                        }
                        //Yellow
                        if (pictureBox8.BackColor == Color.Yellow)
                        {
                            GreenA1.Load(Supreme.Properties.Settings.Default.Supreme_Path + "\\Resources\\YellowAnimation.gif");
                        }
                        //Red
                        if (pictureBox8.BackColor == Color.Red)
                        {
                            GreenA1.Load(Supreme.Properties.Settings.Default.Supreme_Path + "\\Resources\\RedAnimation.gif");
                        }

                        //GAMERSCLUB
                        GreenA2.Visible = true;
                        //Green
                        if (pictureBox9.BackColor == Color.Green || pictureBox9.BackColor == Color.LimeGreen)
                        {
                            GreenA2.Load(Supreme.Properties.Settings.Default.Supreme_Path + "\\Resources\\GreenAnimation.gif");
                        }
                        //Yellow
                        if (pictureBox9.BackColor == Color.Yellow)
                        {
                            GreenA2.Load(Supreme.Properties.Settings.Default.Supreme_Path + "\\Resources\\YellowAnimation.gif");
                        }
                        //Red
                        if (pictureBox9.BackColor == Color.Red)
                        {
                            GreenA2.Load(Supreme.Properties.Settings.Default.Supreme_Path + "\\Resources\\RedAnimation.gif");
                        }

                        //FACEIT
                        GreenA3.Visible = true;
                        //Green
                        if (pictureBox9.BackColor == Color.Green || pictureBox9.BackColor == Color.LimeGreen)
                        {
                            GreenA3.Load(Supreme.Properties.Settings.Default.Supreme_Path + "\\Resources\\GreenAnimation.gif");
                        }
                        //Yellow
                        if (pictureBox9.BackColor == Color.Yellow)
                        {
                            GreenA3.Load(Supreme.Properties.Settings.Default.Supreme_Path + "\\Resources\\YellowAnimation.gif");
                        }
                        //Red
                        if (pictureBox9.BackColor == Color.Red)
                        {
                            GreenA3.Load(Supreme.Properties.Settings.Default.Supreme_Path + "\\Resources\\RedAnimation.gif");
                        }

                        //VALVE
                        GreenA4.Visible = true;
                        //Green
                        if (pictureBox11.BackColor == Color.Green || pictureBox11.BackColor == Color.LimeGreen)
                        {
                            GreenA4.Load(Supreme.Properties.Settings.Default.Supreme_Path + "\\Resources\\GreenAnimation.gif");
                        }

                        //Yellow
                        if (pictureBox11.BackColor == Color.Yellow)
                        {
                            GreenA4.Load(Supreme.Properties.Settings.Default.Supreme_Path + "\\Resources\\YellowAnimation.gif");
                        }

                        //Red
                        if (pictureBox11.BackColor == Color.Red)
                        {
                            GreenA4.Load(Supreme.Properties.Settings.Default.Supreme_Path + "\\Resources\\RedAnimation.gif");
                        }

                    }
                    catch
                    {
                        MessageBox.Show("An error has been detected while trying to load resources files. Fix it using Graphics mode in NORMAL or try reinstall SUPREME");
                    }
                }
            }
            else
            {
                GreenA1.Visible = false;
                GreenA2.Visible = false;
                GreenA3.Visible = false;
                GreenA4.Visible = false;
            }
        }
        private void timer1_TickAsync(object sender, EventArgs e)
        {
            try
            {
                PlatformsPingAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error was found when try to receive ping in ms Format. (METHOD: timer1_TickAsync)" + Environment.NewLine + "Please send the next code error to: support@techcoy.xyz ~SUPREME" + Environment.NewLine + ex);
            }
        }
        private void timerAbout_Tick(object sender, EventArgs e)
        {
            //Open FormAbout
            Size = new Size(Width + 8, Height);
            Supreme.Properties.Settings.Default.formAboutIsOpen = 1;
            if (Size.Width == 1394)
            {
                panelAbout.Visible = false;
                panelAbout.Visible = true;
                timerAbout.Stop();
                timerAbout.Dispose();
            }
        }
        private void timerAbout2_Tick(object sender, EventArgs e)
        {
            //Close FormAbout
            Size = new Size(Width - 8, Height);
            Supreme.Properties.Settings.Default.formAboutIsOpen = 0;
            if (Size.Width == 994)
            {
                timerAbout2.Stop();
                timerAbout2.Dispose();
            }
        }
        private void timerMessage_Tick(object sender, EventArgs e)
        {
            lblTester.SetBounds(x, y, 1, 1);
            x--;
            switch (Supreme.Properties.Settings.Default.Language)
            {
                case 0:
                    if (x <= -700)
                    {
                        int r = WMessageRnd.Next(WMessageEN.Count);
                        lblTester.Text = (string)WMessageEN[r];
                        x = 920;
                    }
                    break;
                case 1:
                    if (x <= -700)
                    {
                        int r = WMessageRnd.Next(WMessageES.Count);
                        lblTester.Text = (string)WMessageES[r];
                        x = 920;
                    }
                    break;
                case 2:
                    if (x <= -700)
                    {
                        int r = WMessageRnd.Next(WMessagePR.Count);
                        lblTester.Text = (string)WMessagePR[r];
                        x = 920;
                    }
                    break;
            }
        }
        private void init_Tick(object sender, EventArgs e)
        {
            Opacity += .05;
            if (Opacity >= Supreme.Properties.Settings.Default.Opacity)
            {
                init.Stop();
                init.Enabled = false;
                tmrOpacity.Start();
                tmrOpacity.Enabled = true;
            }
        }
        private void timerLoaderForm_Tick(object sender, EventArgs e)
        {
            if (pictureBox10.BackColor != Color.Gray)
            {
                Supreme.Properties.Settings.Default.formLoaderIsReady = true;
                BringToFront();
                this.ShowInTaskbar = true;
                init.Enabled = true;
                init.Start();
                timerLoaderForm.Stop();
                timerLoaderForm.Enabled = false;
            }
        }
        private void tmrOpacity_Tick(object sender, EventArgs e)
        {
            if (Supreme.Properties.Settings.Default.formLoaderIsReady == true)
            {
                if (Opacity != Supreme.Properties.Settings.Default.Opacity)
                {
                    Opacity = Supreme.Properties.Settings.Default.Opacity;
                }
            }
        }
        #endregion

        #region Buttons, Panels & PictureBox
        private void btnAutoOn_Click(object sender, EventArgs e)
        {
            btnAutoOff.Visible = true;
            btnAutoOn.Visible = false;
            timer1.Enabled = false;
            timer1.Stop();
        }
        private void btnAutoOff_Click(object sender, EventArgs e)
        {
            btnAutoOn.Visible = true;
            btnAutoOff.Visible = false;
            timer1.Enabled = true;
            timer1.Start();
        }
        private void BtnBinds_Click(object sender, EventArgs e)
        {
            Hide();
            formBinds i = new formBinds
            {
                sponsorBannerPNG = sponsorBanner.Image
            };
            btnAutoOn_Click(sender, e);
            i.ShowDialog();
            InitCustomLabelFont();
            Show();
        }
        private void BtnBinds2_MouseLeave(object sender, EventArgs e)
        {
            btnBinds.Visible = true;
            btnBinds2.Visible = false;
        }
        private void BtnRadar2_Click(object sender, EventArgs e)
        {
            FormUnderContrPop FUCP = new FormUnderContrPop();
            FUCP.ShowDialog();
        }
        private void BtnRadar2_MouseLeave(object sender, EventArgs e)
        {
            btnRadar.Visible = true;
            btnRadar2.Visible = false;
        }
        private void BtnRadar_MouseEnter(object sender, EventArgs e)
        {
            btnRadar.Visible = false;
            btnRadar2.Visible = true;
        }
        private void BtnBinds_MouseEnter(object sender, EventArgs e)
        {
            btnBinds.Visible = false;
            btnBinds2.Visible = true;
        }
        private void BtnAbout_Click(object sender, EventArgs e)
        {
            BtnAbout2_Click(sender, e);
        }
        private void BtnAbout2_Click(object sender, EventArgs e)
        {
            try
            {
                if (Supreme.Properties.Settings.Default.formAboutIsOpen == 0)
                {
                    if (Size.Width >= 998)
                    {
                        Size = new Size(994, Height);
                        btnAbout.Visible = true;
                        btnAbout2.Visible = false;
                    }
                    else
                    {
                        btnAbout.Visible = false;
                        btnAbout2.Visible = true;
                        timerAbout.Enabled = true;
                        timerAbout.Start();
                    }
                }
                if (Supreme.Properties.Settings.Default.formAboutIsOpen == 1)
                {
                    if (Size.Width <= 1390)
                    {
                        Size = new Size(1394, Height);
                        btnAbout.Visible = false;
                        btnAbout2.Visible = true;
                    }
                    else
                    {
                        btnAbout.Visible = true;
                        btnAbout2.Visible = false;
                        timerAbout2.Enabled = true;
                        timerAbout2.Start();
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex);
            }

        }
        private void BtnBug_Click(object sender, EventArgs e)
        {
            FormConfig FConfig = new FormConfig();
            FConfig.ShowDialog();
        }
        private void BtnBug_MouseEnter(object sender, EventArgs e)
        {
            btnBug.Visible = false;
            btnBug2.Visible = true;
        }
        private void BtnBug2_MouseLeave(object sender, EventArgs e)
        {
            btnBug.Visible = true;
            btnBug2.Visible = false;
        }
        private void panelHerramientas_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        private void btnClose_MouseClick(object sender, MouseEventArgs e)
        {
            Application.Exit();
        }
        private void btnMinimize_MouseClick(object sender, MouseEventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            {
                WindowState = FormWindowState.Minimized;
            }
        }
        private void panelGamersClub_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, this.panelGamersClub.ClientRectangle, Color.White, ButtonBorderStyle.Solid);
        }
        private void panelBLAZING_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, this.panelOverviews.ClientRectangle, Color.White, ButtonBorderStyle.Solid);
        }
        private void panelFaceit_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, this.panelFaceit.ClientRectangle, Color.White, ButtonBorderStyle.Solid);
        }
        private void panelMatchmaking_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, this.panelMatchmaking.ClientRectangle, Color.White, ButtonBorderStyle.Solid);
        }
        private void btnClose_MouseEnter(object sender, EventArgs e)
        {
            btnClose.BackColor = Color.Red;
        }
        private void btnClose_MouseLeave(object sender, EventArgs e)
        {
            btnClose.BackColor = Color.FromArgb(11, 14, 21);
        }
        private void btnMinimize_MouseEnter(object sender, EventArgs e)
        {
            btnMinimize.BackColor = Color.FromArgb(31, 34, 41);
        }
        private void btnMinimize_MouseLeave(object sender, EventArgs e)
        {
            btnMinimize.BackColor = Color.FromArgb(11, 14, 21);
        }
        private void panelContenedor_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        private void sponsorBanner_Click(object sender, EventArgs e)
        {
            if (CheckForInternetConnnection())
            {
                System.Diagnostics.Process.Start(Supreme.Properties.Settings.Default.Banner_URL);
            }
            else
            {
                FormConnectionOffline i = new FormConnectionOffline();
                i.ShowDialog();
            }
        }
        private void pictureBox4_MouseClick(object sender, MouseEventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.overviews.cl");
        }
        private void pictureBox3_MouseClick(object sender, MouseEventArgs e)
        {
            System.Diagnostics.Process.Start("https://gamersclub.com.br/lobby");
        }
        private void pictureBox5_MouseClick(object sender, MouseEventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.faceit.com");
        }
        private void pictureBox6_MouseClick(object sender, MouseEventArgs e)
        {
            System.Diagnostics.Process.Start("https://steamcommunity.com");
        }
        private void pictureBox13_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        private void lblTester_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        private void panel5_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        private void lblValveClient_MouseHover(object sender, EventArgs e)
        {
            if (lblValveClient.ForeColor == Color.Yellow)
            {
                ToolTip tt1 = new ToolTip
                {
                    AutoPopDelay = 5000,
                    InitialDelay = 500
                };
                tt1.SetToolTip(lblValveClient, lblValveClient.Text);
            }
        }
        private void lblValvePlatform_MouseHover(object sender, EventArgs e)
        {
            if (lblValvePlatform.ForeColor == Color.Yellow)
            {
                ToolTip tt1 = new ToolTip
                {
                    AutoPopDelay = 5000,
                    InitialDelay = 500
                };
                tt1.SetToolTip(lblValvePlatform, lblValvePlatform.Text);
            }
        }
        private void lblValveServers_MouseHover(object sender, EventArgs e)
        {
            if (lblValveServers.ForeColor == Color.Yellow)
            {
                ToolTip tt1 = new ToolTip
                {
                    AutoPopDelay = 5000,
                    InitialDelay = 500
                };
                tt1.SetToolTip(lblValveServers, lblValveServers.Text);
            }
        }
        private void PictureBox17_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://steamcommunity.com/id/GhostyWP");
        }
        private void PictureBox18_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.facebook.com/GHOSTYWP");
        }
        private void PictureBox19_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://twitter.com/GhostyWP");
        }
        private void SteamChaz_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://steamcommunity.com/profiles/76561198217825303");
        }
        private void SteamKratzen_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://steamcommunity.com/profiles/76561198039334036");
        }
        private void SteamKrisian_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://steamcommunity.com/profiles/76561198450061202");
        }
        #endregion

        #region VARIABLES & IMPORTS
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(IntPtr hwnd, int wmsg, int wparam, int lparam);
        [DllImport("gdi32.dll")]
        private static extern IntPtr AddFontMemResourceEx(IntPtr pbFont, uint cbFont,
        IntPtr pdv, [In] ref uint pcFonts);
        private PrivateFontCollection LEMONMILK_BOLD = new PrivateFontCollection();
        string settings_json_string;
        readonly string SupremeZIP = Directory.GetCurrentDirectory() + @"\SUPREME.zip";
        public int MSOVCL;
        public int MSGCBR;
        public int MSGCCL;
        public int MSGCAR;
        public int MSFCBR1;
        public int MSVVBR1;
        public int MSVVLM1;
        public int MSVVCL1;
        public int x = 920;
        public readonly int y = 9;
        public readonly Random r = new Random();
        readonly System.Windows.Forms.WebBrowser PerlaNegra = new System.Windows.Forms.WebBrowser();
        static readonly Random WMessageRnd = new Random();
        #endregion

        readonly List<string> WMessageEN = new List<string>()
        {
              "SUPREME is powered by Github, Microsoft .NET Frameworks and Web Cloud Services",
              "Go Rush B?",
              "Check the ✯STAR if you want to be part of the survey",
              "S1mple: You want be better? Practice your aim, recoil and play a lot competitive platforms. Controls your emotions and fitness man, you always can change the game.",
              "Remember not buy helmet if you are CT and the TT are in full buy ;)",
              "If you want be donor or sponsor, click the ✯STAR button ;)",
              "SUPREME really appreciates you for using this tool <3",
              "CS:GO Competitive Platforms brings you a better experience that Valve Matchmaking"
        };
        readonly List<string> WMessageES = new List<string>()
        {
              "SUPREME funciona gracias a Github, Microsoft .NET Frameworks y Servicios web en la nube",
              "Go Rush B?",
              "Revisa la ✯Estrella si quieres ser parte de futuras encuestas y regalos",
              "S1mple: Buscas mejorar? Practica tu aim, recoil y juega mucho en plataformas competitivas. Controla tus emociones y tu estado fisico, siempre puedes cambiar el juego.",
              "Recuerda no comprar casco y chaleco kevlar si eres CT y los TT están en full buy ;)",
              "Si quieres ser donante o patrocinador, haz click en el botón de la ✯Estrella ;)",
              "El equipo de SUPREME realmente te agradece por usar esta herramienta <3",
              "Las plataformas competitivas de CS: GO le ofrece una mejor experiencia que el Matchmaking de Valve"
        };
        readonly List<string> WMessagePR = new List<string>()
        {
              "SUPREME funciona graças ao Github, Microsoft .NET Frameworks e Web Cloud Services",
              "Go Rush B?",
              "Marque a ✯Star se você quiser fazer parte de futuras pesquisas e presentes",
              "Lembre-se de não comprar capacete se você for CT e o TT estiver em full buy;)",
              "Se você deseja ser um doador ou patrocinador, clique no botão ✯STAR ;)",
              "A equipe do SUPREME realmente agradece por usar esta ferramenta <3",
              "As plataformas competitivas do CS: GO proporcionam uma experiência melhor que a Matchmaking do Valve"
        };


    }
}
