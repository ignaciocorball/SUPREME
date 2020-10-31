using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Supreme.Forms
{
    public partial class FormConfig : Form
    {
        public FormConfig()
        {
            InitializeComponent();
        }
        private void FormConfig_Load(object sender, EventArgs e)
        {
            int OpacityIntergerValue = (int)Math.Round(Properties.Settings.Default.Opacity * 100);
            FormsOpacity = Properties.Settings.Default.Opacity;
            trackBar.Value = OpacityIntergerValue;
            label6.Text = trackBar.Value + "%";
            LanguageMenuStrip.TopLevel = false;
            LanguageMenuStrip.Parent = panel1;
            LanguageMenuStrip.Dock = DockStyle.Fill;
            language = Properties.Settings.Default.Language;
            switch (language)
            {
                case 0:
                    label4.Text = "English";
                    break;
                case 1:
                    label4.Text = "Español";
                    break;
                case 2:
                    label4.Text = "Portugues";
                    break;
            }
            //If profilePic exists, load data. Else Get data
            if(File.Exists(oPath))
            {
                txtProfile.Enabled = false;
                txtProfile.Text = "https://steamcommunity.com/profiles/" + Properties.Settings.Default.SteamID64;
                btnVerify.Visible = false;
                lblUsername.Text = Properties.Settings.Default.SteamUsername;
                lblSteamID.Text = Properties.Settings.Default.SteamID64;
                lblUsername.Visible = true;
                lblSteamID.Visible = true;
                picProfile.Visible = true;
                picProfile.ImageLocation = oPath;
            }
            else
            {
                txtProfile.Enabled = true;
                txtProfile.Text = "http://steamcommunity.com/profiles/XXXXXXXXXXXXXXXXX";
                btnVerify.Visible = true;
                lblUsername.Visible = false;
                lblSteamID.Visible = false;
                picProfile.Visible = false;
            }
        }


        #region METHODS & TIMERS
        private void getSteamProfileData(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            foreach (HtmlElement tag in BlackPearl.Document.All)
            {
                if (tag.GetAttribute("classname").Contains("panel-body"))
                {
                    if (tag != null)
                    {
                        try
                        {
                            int first = tag.InnerText.IndexOf("name ") + 4;
                            int last = tag.InnerText.LastIndexOf("real name ");
                            string json2 = tag.InnerText.Substring(first, last - first);
                            steamUser = json2;
                            picProfile.ImageLocation = BlackPearl.Document.GetElementsByTagName("img")[1].GetAttribute("src");
                            timer2.Enabled = true;
                            timer2.Start();
                        }
                        catch { }
                    }
                }
            }

        }
        private void saveProfilePic()
        {
            Properties.Settings.Default.configProfileLoaded = true;
            picProfile.Image.Save(oPath, ImageFormat.Jpeg);
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            label10.Visible = false;
            timer1.Stop();
            timer1.Enabled = false;
        }
        private void timer2_Tick(object sender, EventArgs e)
        {
            if (loadBar.Width < 456)
            {
                loadBar.Width += 2;
            }
            else
            {
                lblUsername.Text = steamUser;
                lblSteamID.Text = steamID64;
                Properties.Settings.Default.SteamID64 = steamID64;
                Properties.Settings.Default.SteamUsername = steamUser;
                timer2.Enabled = false;
                timer2.Stop();
                loadBar.Visible = false;
                lblUsername.Visible = true;
                lblSteamID.Visible = true;
                picProfile.Visible = true;
            }
        }
        #endregion

        #region BUTTONS, PICTUREBOX & ITEMS
        private void trackBar_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                float trackBarFloatValue = (trackBar.Value);
                trackBarFloatValue /= 100;
                label6.Text = trackBar.Value + "%";
                Properties.Settings.Default.Opacity = trackBarFloatValue;
                Opacity = trackBarFloatValue;
            }
            catch { }
        }
        private void EnglishToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Language = 0;
            label4.Text = "English";
        }
        private void españolToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Language = 1;
            label4.Text = "Español";
        }
        private void portuguesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Language = 2;
            label4.Text = "Portugues";
        }
        private void LanguageMenuStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            LanguageMenuStrip.Visible = false;
        }
        private void label4_Click(object sender, EventArgs e)
        {
            if (LanguageMenuStrip.Visible)
            {
                LanguageMenuStrip.Hide();
            }
            else
            {
                LanguageMenuStrip.Show();
            }
        }
        private void label6_Click(object sender, EventArgs e)
        {
            if (trackBar.Visible == true)
            {
                trackBar.Visible = false;
            }
            else
            {
                trackBar.Visible = true;
            }
        }
        private void label9_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://steamidfinder.com");
        }
        private void label7_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(this.label7, giveawayENG);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (txtProfile.Text.Contains("https://steamcommunity.com/profiles/") || txtProfile.Text.Contains("http://steamcommunity.com/profiles/"))
            {
                if (txtProfile.Text != "http://steamcommunity.com/profiles/XXXXXXXXXXXXXXXXX")
                {
                    if (txtProfile.Text != "")
                    {
                        txtProfile.ForeColor = Color.White;
                        char chartoTrim = '/';
                        string stringToReplace = "https://steamcommunity.com/profiles/";
                        string stringToReplace2 = "http://steamcommunity.com/profiles/";
                        //Clear the URL
                        profileSteamLink = txtProfile.Text;
                        steamID64 = profileSteamLink.Trim(chartoTrim);
                        steamID64 = steamID64.Replace(stringToReplace, "");
                        steamID64 = steamID64.Replace(stringToReplace2, "");
                        //Check the URL to fill data
                        BlackPearl.ScriptErrorsSuppressed = true;
                        BlackPearl.Navigate(steamIdFinderURL + steamID64);
                        BlackPearl.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(getSteamProfileData);
                    }
                    else
                    {
                        //Show Message for change the SteamID
                        label10.Text = "Remember put your link below!";
                        label10.Visible = true;
                        timer1.Enabled = true;
                        timer1.Start();
                    }
                }
                else
                {
                    //Show Message for change the SteamID
                    label10.Text = "Remember put your link below!";
                    label10.Visible = true;
                    timer1.Enabled = true;
                    timer1.Start();
                }
            }
            else
            {
                //Show Message for change the SteamID
                label10.Text = "Link not valid!";
                label10.Visible = true;
                timer1.Enabled = true;
                timer1.Start();
            }

        }
        private void txtProfile_Click(object sender, EventArgs e)
        {
            if (txtProfile.Text == "http://steamcommunity.com/profiles/XXXXXXXXXXXXXXXXX")
            {
                txtProfile.ForeColor = Color.White;
                txtProfile.Text = "";
            }

        }
        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
            ToolTip tt1 = new ToolTip
            {
                AutoPopDelay = 15000,
                InitialDelay = 500
            };
            switch (Properties.Settings.Default.Language)
            {
                case 0:
                    tt1.SetToolTip(pictureBox1, "You can have only one account per HWID and IP");
                    break;
                case 1:
                    tt1.SetToolTip(pictureBox1, "Puedes tener solo una cuenta por HWID e IP");
                    break;
                case 2:
                    tt1.SetToolTip(pictureBox1, "Este botão adicionar a bind selecionada ao arquivo 'autoexec.cfg' dentro da pasta cfg do csgo." + Environment.NewLine + "Se não existir, será criado automaticamente." + Environment.NewLine + "Adicione o parâmetro '+exec autoexec.cfg' aos parâmetros de inicialização para carregar a configuração :)");
                    break;
            }
        }
        private void FormConfig_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        private void pictureBox2_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void pictureBox4_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        //SAVE CANCEL BUTTON'S
        private void btnCancel_Click(object sender, EventArgs e)
        {
            if(Properties.Settings.Default.Opacity == FormsOpacity && Properties.Settings.Default.Language == language)
            {
                Close();
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("Your changes has not been saved." + Environment.NewLine + "You want discard the changes?", "~SUPREME", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialogResult == DialogResult.Yes)
                {
                    Properties.Settings.Default.Opacity = FormsOpacity;
                    Properties.Settings.Default.Language = language;
                    Close();
                }
            }

        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if(Properties.Settings.Default.configProfileLoaded == false)
            {
                if (picProfile.Visible == true)
                {
                    saveProfilePic();
                }
            }
            Properties.Settings.Default.Save();
            Close();
        }
        #endregion

        #region VARIABLES & IMPORTS
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(IntPtr hwnd, int wmsg, int wparam, int lparam);
        WebBrowser BlackPearl = new WebBrowser();
        string steamID64;
        string steamIdFinderURL = "https://steamidfinder.com/lookup/";
        string steamUser;
        string oPath = Properties.Settings.Default.Supreme_Path + "\\Resources\\profilePic.jpg";
        float FormsOpacity;
        int language;
        string giveawayENG = "If you want to be part of the next SUPREME Giveaways. You only need to give us your Steam Link in order to send the prize if you are a winner!";
        string profileSteamLink;
        #endregion
    }
}
