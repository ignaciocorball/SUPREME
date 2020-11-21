using Supreme.Forms;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Net;
using System.Runtime.InteropServices;
using System.Windows.Forms;

/*
 * +====================================================================================+
 * |  [*][][][*] [*]    [*] [+][][][+] [+][][][+] [*][][][*]  [*][]   [][*] [*][][][*]  |
 * |  [*]        [*]    [*] [+]    [+] [+]    [+] [*]         [*]  [*]  [*] [*]         |
 * |  [*][][][*] [*]    [*] [+][][+]   [+][][+]   [*][][][*]  [*]       [*] [*][][][*]  |
 * |         [*] [*]    [*] [+]        [+]    [+] [*]         [*]       [*] [*]         |
 * |  [*][][][*] [+][][][+] [+]        [+]    [+] [*][][][*]  [*]       [*] [*][][][*]  |
 * |                                                                                    |
 * |                 DEVELOPED BY GhostY ©2024 All rights reserved                      |
 * +====================================================================================+
 */

namespace Supreme
{
    public partial class formBinds : Form, IContract
    {
        readonly string SponsorBannerClick = "https://www.facebook.com/GHOSTYWP/";
        public Image sponsorBannerPNG { get; set; }
        public formBinds()
        {
            InitializeComponent();
        }

        private void formBinds_Load(object sender, EventArgs e)
        {
            sponsorBanner2.Image = sponsorBannerPNG;
            Opacity = Properties.Settings.Default.Opacity;
            Language();
            timerMessage.Enabled = true;
            timerMessage.Start();
            switch (Properties.Settings.Default.Language)
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
        }


        #region EVENTS & METHODS
        private void DoAllRed()
        {
            button1.ForeColor = Color.DarkRed;
            button5.ForeColor = Color.DarkRed;
            button2.ForeColor = Color.DarkRed;
            button6.ForeColor = Color.DarkRed;
            button4.ForeColor = Color.DarkRed;
            button3.ForeColor = Color.DarkRed;
            button8.ForeColor = Color.DarkRed;
            button7.ForeColor = Color.DarkRed;
        }
        private void Language()
        {
            try
            {
                //string files = File.ReadAllText(Languagepath + "\\language.txt");
                //string parser = files.Replace("language=", "");
                //strlanguage = Int32.Parse(parser);


            }
            catch{}

        }
        private void setUpBinds()
        {
            //Here we set app all config for show reproductor, hide images and show the components.
            try
            {
                if (button1.Parent == panelContainer)
                {
                    sponsorBanner2.Visible = false;
                    button1.Parent = panelBinds;
                    button1.Location = new Point(255, 23);
                    button1.Size = new Size(125, 27);
                    button1.FlatAppearance.BorderSize = 1;
                    button1.Font = new Font("Microsoft Sans Serif", 8);
                    button5.Parent = panelBinds;
                    button5.Location = new Point(255, 52);
                    button5.Size = new Size(185, 27);
                    button5.FlatAppearance.BorderSize = 1;
                    button5.Font = new Font("Microsoft Sans Serif", 8);
                    button2.Parent = panelBinds;
                    button2.Location = new Point(382, 23);
                    button2.Size = new Size(115, 27);
                    button2.FlatAppearance.BorderSize = 1;
                    button2.Font = new Font("Microsoft Sans Serif", 8);
                    button6.Parent = panelBinds;
                    button6.Location = new Point(442, 52);
                    button6.Size = new Size(95, 27);
                    button6.FlatAppearance.BorderSize = 1;
                    button6.Font = new Font("Microsoft Sans Serif", 8);
                    button4.Parent = panelBinds;
                    button4.Location = new Point(607, 23);
                    button4.Size = new Size(155, 27);
                    button4.FlatAppearance.BorderSize = 1;
                    button4.Font = new Font("Microsoft Sans Serif", 8);
                    button3.Parent = panelBinds;
                    button3.Location = new Point(499, 23);
                    button3.Size = new Size(106, 27);
                    button3.FlatAppearance.BorderSize = 1;
                    button3.Font = new Font("Microsoft Sans Serif", 8);
                    button8.Parent = panelBinds;
                    button8.Location = new Point(631, 52);
                    button8.Size = new Size(131, 27);
                    button8.FlatAppearance.BorderSize = 1;
                    button8.Font = new Font("Microsoft Sans Serif", 8);
                    button7.Parent = panelBinds;
                    button7.Location = new Point(539, 52);
                    button7.Size = new Size(90, 27);
                    button7.FlatAppearance.BorderSize = 1;
                    button7.Font = new Font("Microsoft Sans Serif", 8);
                    picLogoCSGO.Visible = false;
                }
                picContainerGreen.Visible = true;
                picGreenFrame.Visible = true;
                btnClipboard.Visible = true;

                btnAutoExec.Visible = false;
                picMessageHelper.Visible = false;

                lblDesc.Visible = true;
                lblDesc.MaximumSize = new Size(lblDesc.Width, 455);
                lblDesc.Parent = picContainerGreen;
                lblDesc.BackColor = Color.Transparent;
                lblDesc.Location = new Point(64, 38);
                cuadro1.Visible = true;
                cuadro2.Visible = true;
                cuadro3.Visible = true;
                cuadro4.Visible = true;
                picCSGOPEDIA.Visible = true;
                picSpecialThanks.Visible = true;
                txtClipboard1.Parent = picContainerGreen;
                txtClipboard1.Location = new Point(64, 225);
                txtClipboard1.Font = new Font("Comic Sans MS", 9);
                txtClipboard1.Size = new Size(294, 20);
                txtClipboard1.Visible = true;
            }
            catch
            {

            }
        }
        private void languageRefresh()
        {
            if(button1.ForeColor == Color.LimeGreen) { button1.PerformClick(); }
            if (button2.ForeColor == Color.LimeGreen) { button2.PerformClick(); }
            if (button3.ForeColor == Color.LimeGreen) { button3.PerformClick(); }
            if (button4.ForeColor == Color.LimeGreen) { button4.PerformClick(); }
            if (button5.ForeColor == Color.LimeGreen) { button5.PerformClick(); }
            if (button6.ForeColor == Color.LimeGreen) { button6.PerformClick(); }
            if (button7.ForeColor == Color.LimeGreen) { button7.PerformClick(); }
            if (button8.ForeColor == Color.LimeGreen) { button8.PerformClick(); }

        }
        private void reproductor(string url)
        {
            try
            {
                if (CheckForInternetConnnection())
                {
                    string html = "<html><head>";
                    html += "<meta content='IE=Edge' http-equiv='X-UA-Compatible'/>";
                    html += "<iframe id='video' src= 'https://www.youtube.com/embed/{0}' width='410' height='230' frameborder='0'></iframe>";
                    html += "</body></html>";
                    webBrowser1.DocumentText = string.Format(html, url.Split('=')[1]);
                    picOffline.Visible = false;
                }
                else
                {
                    picOffline.Visible = true;
                    FormConnectionOffline fco = new FormConnectionOffline();
                    fco.ShowDialog();
                }
            }
            catch
            {

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
        public void Ejecutar(string texto)
        {
            strClipboardKEY = texto;
            txtClipboard1.Text = "bind " + strClipboardKEY + strClipBoardBind;
            strClipboardB = txtClipboard1.Text;
            //btn AutoExec
            if(strClipboardexec == 1)
            {
                //button ClearDecals
                if (button8.ForeColor == Color.LimeGreen)
                {
                    if (strClipboardKEY == "F")
                    {
                        txtClipboard1.Text = "bind F " + "\"r_cleardecals; +lookatweapon\"";
                        Clipboard.SetText("bind F " + "\"r_cleardecals; +lookatweapon\"");
                        strClipboardexec = 0;
                    }
                }
                //button Increase Volume Sneaking
                if(button5.ForeColor == Color.LimeGreen)
                {
                    txtClipboard1.Text = "alias +walkvol \"incrementvar volume 0 1 0.5; +speed\"; alias -walkvol \"incrementvar volume 0 1 -0.5; -speed\"; bind \"shift\" \"+walkvol\"";
                    Clipboard.SetText(txtClipboard1.Text);
                }
                else
                {
                    Clipboard.SetText(strClipboardB);
                    strClipboardexec = 0;
                }

            }
            //btnClipboard
            else
            {
                //button ClearDecals
                if (button8.ForeColor == Color.LimeGreen)
                {
                    if (strClipboardKEY == "F")
                    {
                        txtClipboard1.Text = "bind F " + "\"r_cleardecals; +lookatweapon\"";
                        Clipboard.SetText("bind F " + "\"r_cleardecals; +lookatweapon\"");
                    }
                }
                //button Increase Volume Sneaking
                if (button5.ForeColor == Color.LimeGreen)
                {
                    txtClipboard1.Text = "alias +walkvol \"incrementvar volume 0 1 0.5; +speed\"; alias -walkvol \"incrementvar volume 0 1 -0.5; -speed\"; bind \"shift\" \"+walkvol\"";
                    Clipboard.SetText(txtClipboard1.Text);
                }
                else
                {
                    Clipboard.SetText(strClipboardB);
                }
            }
            timerClipboard.Enabled = true;
            timerClipboard.Start();
            lblCoppied.Visible = true;
            Properties.Settings.Default.formKeyboard = 0;
        }
        #endregion

        #region Buttons, Panels & PictureBox
        //Language,timers,panels and buttons Settings
        private void btnClose_MouseClick(object sender, MouseEventArgs e)
        {
            Environment.Exit(0);
        }
        private void btnMinimize_MouseClick(object sender, MouseEventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            {
                WindowState = FormWindowState.Minimized;
            }
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
        private void button1_Click(object sender, EventArgs e)
        {
            string url = "https://www.youtube.com/watch?v=vHetBOMjbJQ";
            DoAllRed();
            setUpBinds();
            button1.ForeColor = Color.LimeGreen;
            switch (Properties.Settings.Default.Language)
            {
                case 0:
                    lblDesc.Text = "Bind allows players to turn around in a fastest way." + Environment.NewLine + "It will be especially useful for people who play with low sensitivity." + Environment.NewLine + "Thus, for comfortable use this bind requires individual adjustment of values depending on player’s sensitivity.";
                    break;
                case 1:
                    lblDesc.Text = "Este bind permite a los jugadores girarse rapidamente. Será especialmente útil para las personas con una baja sensibilidad. Por ende, para un uso cómodo, este bind requiere un ajuste individual de los valores en función de la sensibilidad del jugador.";
                    break;
                case 2:
                    lblDesc.Text = "Esse bind permite que os jogadores mudem de maneira mais rápida" + Environment.NewLine + "Será especialmente útil para pessoas que jogam com baixa sensibilidade." + Environment.NewLine + "Assim, para uso confortável, esse vínculo requer ajuste individual de valores, dependendo da sensibilidade do jogador.";
                    break;
            }
            strClipBoardBind = " +spin;alias +spin m_yaw 0.09;alias -spin m_yaw 0.022";
            txtClipboard1.Text = "bind " + strClipboardKEY + strClipBoardBind;
            reproductor(url);
            webBrowser1.Visible = true;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            string url = "https://www.youtube.com/watch?v=PRT57-xOa-o";
            DoAllRed();
            setUpBinds();
            button2.ForeColor = Color.LimeGreen;
            switch (Properties.Settings.Default.Language)
            {
                case 0:
                    lblDesc.Text = "Bind allows you throw a smoke automatically in a perfect timing." + Environment.NewLine + "Thus, it deals with the problem of many elaborate smokes.";
                    break;
                case 1:
                    lblDesc.Text = "Este bind te permite lanzar un humo automáticamente en el momento perfecto." + Environment.NewLine + "Por tanto, trata el problema de muchos humos elaborados.";
                    break;
                case 2:
                    lblDesc.Text = "Esse bind permite que você libere automaticamente uma smoke no momento perfeito." + Environment.NewLine + "Assim, ele lida com o problema de muitas smokes elaboradas";
                    break;
            }
            strClipBoardBind = " \"+jump; -attack; -jump\"";
            txtClipboard1.Text = "bind " + strClipboardKEY + strClipBoardBind;
            reproductor(url);
            webBrowser1.Visible = true;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            string url = "https://www.youtube.com/watch?v=Oq_e4TCrLww";
            DoAllRed();
            setUpBinds();
            button3.ForeColor = Color.LimeGreen;
            switch (Properties.Settings.Default.Language)
            {
                case 0:
                    lblDesc.Text = "The switch hand bind will switch your gun position between your left hand and right hand whenever you press the bind key." + Environment.NewLine + "This is used to prevent your gun model from reducing visibility.";
                    break;
                case 1:
                    lblDesc.Text = "El bind Switch Hand cambiará la posición de tu arma entre la mano izquierda y la derecha cada vez que presione la tecla establecida." + Environment.NewLine + "Esto se usa para evitar que el modelo de su arma reduzca la visibilidad.";
                    break;
                case 2:
                    lblDesc.Text = "O bind Switch Hand mudará a posição de sua arma entre a mão esquerda e direita cada vez que você pressionar a tecla estabelecido." + Environment.NewLine + "Isso é usado para evitar que o modelo da sua arma reduza a visibilidade.";
                    break;
            }
            strClipBoardBind = " \"toggle cl_righthand 0 1\"";
            txtClipboard1.Text = "bind " + strClipboardKEY + strClipBoardBind;
            reproductor(url);
            webBrowser1.Visible = true;
        }
        private void button4_Click(object sender, EventArgs e)
        {
            string url = "https://www.youtube.com/watch?v=Lo1GNm-tuJI";
            DoAllRed();
            setUpBinds();
            button4.ForeColor = Color.LimeGreen;
            switch (Properties.Settings.Default.Language)
            {
                case 0:
                    lblDesc.Text = "Easy way to find a bomb bind activates an in-game instructor which clearly shows both the direction and the precise location of the bomb regardless of smokes, boxes and other things.";
                    break;
                case 1:
                    lblDesc.Text = "El bind 'Easy way to find a bomb' activa un instructor en el juego que muestra claramente la dirección y la ubicación precisa de la bomba, independientemente de los humos, cajas y otras cosas.";
                    break;
                case 2:
                    lblDesc.Text = "O bind 'Easy way to find a bomb' ativa um instrutor no juego que muestra claramente a direção e a liberação precisa de bomba, independentemente dos humos, cajas e outras cosas.";
                    break;
            }
            strClipBoardBind = " \"toggle gameinstructor_enable;cl_clearhinthistory\"";
            txtClipboard1.Text = "bind " + strClipboardKEY + strClipBoardBind;
            reproductor(url);
            webBrowser1.Visible = true;
        }
        private void button5_Click(object sender, EventArgs e)
        {
            string url = "https://www.youtube.com/watch?v=7WLRszALDtE";
            DoAllRed();
            setUpBinds();
            button5.ForeColor = Color.LimeGreen;
            switch (Properties.Settings.Default.Language)
            {
                case 0:
                    lblDesc.Text = "This bind is especially useful for clutches. A single click on the 'Shift' button increases the in-game volume and allows you to hear better what's going on the map.";
                    break;
                case 1:
                    lblDesc.Text = "Este bind es especialmente útil para clutches. Un solo clic en el botón 'Shift' aumenta el volumen del juego y te permite escuchar mejor lo que sucede en el mapa.";
                    break;
                case 2:
                    lblDesc.Text = "Este bind é especialmente útil para clutches. Um único clique no botão 'Shift' aumenta o volume do jogo e permite que você ouça melhor o que está acontecendo no mapa.";
                    break;
            }
            strClipBoardBind = "alias +walkvol \"incrementvar volume 0 1 0.5; +speed\"; alias -walkvol \"incrementvar volume 0 1 -0.5; -speed\"; bind \"shift\" \"+walkvol\"";
            txtClipboard1.Text = strClipBoardBind;
            reproductor(url);
            webBrowser1.Visible = true;
        }
        private void button6_Click(object sender, EventArgs e)
        {
            string url = "https://www.youtube.com/watch?v=HUULmVnj054";
            DoAllRed();
            setUpBinds();
            button6.ForeColor = Color.LimeGreen;
            switch (Properties.Settings.Default.Language)
            {
                case 0:
                    lblDesc.Text = "Fast bomb drop bind allows you to drop a bomb quickly even without a switch of the main weapon.";
                    break;
                case 1:
                    lblDesc.Text = "El bind 'Fast bomb drop' permimte tirar el C4 rapidamente incluso sin casi alterar tu arma principal al cambiar de objeto.";
                    break;
                case 2:
                    lblDesc.Text = "O bind 'Fast bomb drop' permite que você solte o C4 rapidamente, mesmo sem quase alterar sua arma principal ao trocar de objetos.";
                    break;
            }
            strClipBoardBind = " \"use weapon_c4; drop; \"";
            txtClipboard1.Text = "bind " + strClipboardKEY + strClipBoardBind;
            reproductor(url);
            webBrowser1.Visible = true;
        }
        private void button7_Click(object sender, EventArgs e)
        {
            string url = "https://www.youtube.com/watch?v=5S1juNN1MXU";
            DoAllRed();
            setUpBinds();
            button7.ForeColor = Color.LimeGreen;
            switch (Properties.Settings.Default.Language)
            {
                case 0:
                    lblDesc.Text = "This bind will zoom your radar in when you press the key on your keyboard, pressing it 4 times will loop the size back round to where it was originally.";
                    break;
                case 1:
                    lblDesc.Text = "Este bind aumentará el zoom de tu radar cuando presiones la tecla preestablecida. Si presionas esta 4 veces el radar volverá al zoom original.";
                    break;
                case 2:
                    lblDesc.Text = "Esta ligação aumentará o zoom no seu radar quando você pressionar a tecla predefinida. Se você pressionar 4 vezes, o radar retornará ao zoom original.";
                    break;
            }
            strClipBoardBind = " \"incrementvar cl_radar_scale 0 1 0.25\"";
            txtClipboard1.Text = "bind " + strClipboardKEY + strClipBoardBind;
            reproductor(url);
            webBrowser1.Visible = true;
        }
        private void button8_Click(object sender, EventArgs e)
        {
            string url = "https://www.youtube.com/watch?v=rTRm0WOu_qM";
            DoAllRed();
            setUpBinds();
            button8.ForeColor = Color.LimeGreen;
            switch (Properties.Settings.Default.Language)
            {
                case 0:
                    lblDesc.Text = "This bind will instantly clear all decals when you press the F key."+Environment.NewLine+"This is useful as it will make things easier to see - for example, often blood on walls makes it harder to see enemies who are peeking in front of it";
                    break;
                case 1:
                    lblDesc.Text = "Este bind limpiara automaticamente las paredes al presionar la tecla F"+Environment.NewLine+ "Este es especialmente útil cuando no puedes ver claramente. - por ejemplo, a menudo, la sangre en las paredes hace que sea más difícil ver a los enemigos que se asoman frente a ella";
                    break;
                case 2:
                    lblDesc.Text = "Esse bind irá limpar automaticamente as paredes ao pressionar a tecla F." + Environment.NewLine + "Isso é especialmente útil quando você não consegue ver claramente. -por exemplo, o sangue nas paredes muitas vezes torna mais difícil ver os inimigos aparecendo à sua frente";
                    break;
            }
            strClipBoardBind = " r_cleardecals";
            txtClipboard1.Text = "bind " + strClipboardKEY + strClipBoardBind;
            reproductor(url);
            webBrowser1.Visible = true;
        }
        private void btnHome_MouseClick(object sender, MouseEventArgs e)
        {
            //Esconder el form, mostrar el formPrincipal y cerrar este.
            Close();
        }
        private void panelContainer_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        private void panelBinds_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        private void panelHerramientas_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        private void pictureBox4_MouseDown(object sender, MouseEventArgs e)
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
        private void btnPR_MouseClick(object sender, MouseEventArgs e)
        {
            Properties.Settings.Default.Language = 2;
            Properties.Settings.Default.Save();
            languageRefresh();

        }
        private void btnES_MouseClick(object sender, MouseEventArgs e)
        {
            Properties.Settings.Default.Language = 1;
            Properties.Settings.Default.Save();
            languageRefresh();
        }
        private void btnEN_MouseClick(object sender, MouseEventArgs e)
        {
            Properties.Settings.Default.Language = 0;
            Properties.Settings.Default.Save();
            languageRefresh();
        }
        private void btnClipboard_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                if(Properties.Settings.Default.formKeyboard == 0)
                {
                    if (button1.ForeColor == Color.LimeGreen || button2.ForeColor == Color.LimeGreen || button3.ForeColor == Color.LimeGreen || button4.ForeColor == Color.LimeGreen || button6.ForeColor == Color.LimeGreen || button7.ForeColor == Color.LimeGreen || button8.ForeColor == Color.LimeGreen)
                    {
                        FormKeyDetect fKD = new FormKeyDetect
                        {
                            contrato = this
                        };
                        fKD.Show();
                        lblCoppied.Text = "Bind Coppied Successfully!";
                        lblCoppied.Location = new Point(625, 354);
                        timerClipboard.Enabled = true;
                        timerClipboard.Start();
                        Properties.Settings.Default.formKeyboard = 1;
                    }
                    if (button5.ForeColor == Color.LimeGreen)
                    {
                        Clipboard.SetText(txtClipboard1.Text);
                        lblCoppied.Text = "Bind Coppied Successfully!";
                        lblCoppied.Location = new Point(625, 354);
                        lblCoppied.Visible = true;
                        timerClipboard.Enabled = true;
                        timerClipboard.Start();
                        Properties.Settings.Default.formKeyboard = 1;
                    }
                }
                else
                {
                    MessageBoxButtons buttons = MessageBoxButtons.OK;
                    MessageBoxIcon icon = MessageBoxIcon.Information;
                    string message = "SUPREME";
                    string caption = "The keyboard is currently open";
                    DialogResult result;
                    Form form;
                    using (form = new Form())
                    {
                        form.TopMost = true;
                        result = MessageBox.Show(form, caption, message, buttons, icon);
                    }
                }
            }

            catch { }
        }
        private void btnAutoExec_Click(object sender, EventArgs e)
        {
            FormKeyDetect kd = new FormKeyDetect
            {
                contrato = this
            };
            if (button5.ForeColor == Color.LimeGreen)
            {
                txtClipboard1.Text = "alias +walkvol \"incrementvar volume 0 1 0.5; +speed\"; alias -walkvol \"incrementvar volume 0 1 -0.5; -speed\"; bind \"shift\" \"+walkvol\"";
                Clipboard.SetText(txtClipboard1.Text);
                timerClipboard.Enabled = true;
                timerClipboard.Start();
                lblCoppied.Text = "Bind Added Successfully to autoexec.cfg!";
                lblCoppied.Location = new Point(595, 354);
                lblCoppied.Visible = true;
            }
            else
            {
                kd.Show();
                lblCoppied.Text = "Bind Added Successfully to autoexec.cfg!";
                lblCoppied.Location = new Point(595, 354);
                strClipboardexec = 1;
            }
        }
        private void tmrClipboard_Tick(object sender, EventArgs e)
        {
            timerClipboard.Stop();
            timerClipboard.Enabled = false;
            lblCoppied.Visible = false;
        }
        private void picMessageHelper_MouseHover(object sender, EventArgs e)
        {
            ToolTip tt1 = new ToolTip
            {
                AutoPopDelay = 15000,
                InitialDelay = 500
            };

            switch (Properties.Settings.Default.Language)
            {
                case 0:
                    tt1.SetToolTip(picMessageHelper, "This button adds the selected bind to the file 'autoexec.cfg' inside the cfg folder of the csgo." + Environment.NewLine + "If doesn't exist, it will create the file automatically." + Environment.NewLine + "Remember to add the parameter '+exec autoexec.cfg' in your launch parameters so that the configuration is loaded :)");
                    break;
                case 1:
                    tt1.SetToolTip(picMessageHelper, "Este botón agrega el bind seleccionado a el archivo 'autoexec.cfg' dentro de la carpeta cfg del csgo." + Environment.NewLine + "En caso de no existir, lo creará automáticamente." + Environment.NewLine + "Recuerda agregar el parámetro '+exec autoexec.cfg' en tus parámetros de lanzamiento para que se cargue la configuracion :)");
                    break;
                case 2:
                    tt1.SetToolTip(picMessageHelper, "Este botão adicionar a bind selecionada ao arquivo 'autoexec.cfg' dentro da pasta cfg do csgo." + Environment.NewLine + "Se não existir, será criado automaticamente." + Environment.NewLine + "Adicione o parâmetro '+exec autoexec.cfg' aos parâmetros de inicialização para carregar a configuração :)");
                    break;
            }
        }
        private void picCSGOPEDIA_Click(object sender, EventArgs e)
        {
            Process.Start("https://csgopedia.com");
        }
        private void sponsorBanner_Click(object sender, EventArgs e)
        {
            Process.Start(SponsorBannerClick);
        }

        /*
         * PANEL_TOOLS
         */
        private void btnHome_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void btnHome_MouseEnter(object sender, EventArgs e)
        {
            btnHome.Visible = false;
            btnHome2.Visible = true;
        }
        private void btnHome2_MouseLeave(object sender, EventArgs e)
        {
            btnHome.Visible = true;
            btnHome2.Visible = false;
        }
        private void btnMaps_Click(object sender, EventArgs e)
        {
            FormUnderContrPop FUCP = new FormUnderContrPop();
            FUCP.ShowDialog();
        }
        private void btnMaps_MouseEnter(object sender, EventArgs e)
        {
            btnMaps.Visible = false;
            btnMaps2.Visible = true;
        }
        private void btnMaps2_MouseLeave(object sender, EventArgs e)
        {
            btnMaps.Visible = true;
            btnMaps2.Visible = false;
        }
        private void btnBug_Click(object sender, EventArgs e)
        {
            FormConfig FConfig = new FormConfig();
            FConfig.ShowDialog();
        }
        private void btnBug_MouseEnter(object sender, EventArgs e)
        {
            btnBug.Visible = false;
            btnBug2.Visible = true;
        }
        private void btnBug2_MouseLeave(object sender, EventArgs e)
        {
            btnBug.Visible = true;
            btnBug2.Visible = false;
        }
        private void btnAbout_Click(object sender, EventArgs e)
        {
            btnAbout2_Click(sender, e);
        }
        private void btnAbout2_Click(object sender, EventArgs e)
        {
            try
            {
                if (Properties.Settings.Default.formAboutIsOpen2 == 0)
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
                if (Properties.Settings.Default.formAboutIsOpen2 == 1)
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
        private void timerAbout_Tick(object sender, EventArgs e)
        {
            //Open FormAbout
            Size = new Size(Width + 8, Height);
            Properties.Settings.Default.formAboutIsOpen2 = 1;
            if (Size.Width == 1394)
            {
                panel2.Visible = false;
                panel2.Visible = true;
                timerAbout.Stop();
                timerAbout.Enabled = false;
                timerAbout.Dispose();
            }
        }
        private void timerAbout2_Tick(object sender, EventArgs e)
        {
            Size = new Size(Width - 8, Height);
            Properties.Settings.Default.formAboutIsOpen2 = 0;
            if (Size.Width == 994)
            {

                timerAbout2.Stop();
                timerAbout2.Enabled = false;
                timerAbout2.Dispose();
            }
        }
        private void pictureBox17_Click(object sender, EventArgs e)
        {
            Process.Start("https://steamcommunity.com/id/GhostyWP");
        }
        private void pictureBox18_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.facebook.com/GHOSTYWP");
        }
        private void pictureBox19_Click(object sender, EventArgs e)
        {
            Process.Start("https://twitter.com/GhostyWP");
        }
        private void pictureBox20_Click(object sender, EventArgs e)
        {
            Process.Start("https://steamcommunity.com/profiles/76561198217825303");
        }
        private void pictureBox21_Click(object sender, EventArgs e)
        {
            Process.Start("http://steamcommunity.com/profiles/76561198039334036");
        }
        private void pictureBox22_Click(object sender, EventArgs e)
        {
            Process.Start("http://steamcommunity.com/profiles/76561198450061202");
        }
        private void timerMessage_Tick(object sender, EventArgs e)
        {
            lblTester.SetBounds(x, y, 1, 1);
            x--;
            switch (Properties.Settings.Default.Language)
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
        private void tmrOpacity_Tick(object sender, EventArgs e)
        {
            if (Opacity != Properties.Settings.Default.Opacity)
            {
                Opacity = Properties.Settings.Default.Opacity;
            }
        }
        #endregion

        #region VARIABLES & IMPORTS
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);
        string strClipboardKEY = "KEY";
        string strClipBoardBind;
        string strClipboardB;
        int strClipboardexec;
        static readonly Random WMessageRnd = new Random();
        private int x = 920;
        private readonly int y = 9;
        #endregion

        readonly List<string> WMessageEN = new List<string>()
        {
              "SUPREME is powered by Github, Microsoft .NET Frameworks and Web Cloud Services",
              "Go Rush B?",
              "Check the ✯STAR if you want to be part of the survey",
              "Remember not buy helmet if you are CT and the TT are in full buy ;)",
              "S1mple: You want be better? Practice your aim, Recoil, Play a lot competitive platforms. Controls your emotions and fitness man, you always can change the game.",
              "If you want be donor or sponsor, click the ✯STAR button ;)",
              "SUPREME really appreciates you for using this tool <3",
              "CS:GO Competitive Platforms brings you a better experience that Valve Matchmaking"
        };
        readonly List<string> WMessageES = new List<string>()
        {
              "SUPREME funciona gracias a Github, Microsoft .NET Frameworks y Servicios web en la nube",
              "Go Rush B?",
              "Revisa la ✯Estrella si quieres ser parte de futuras encuestas y regalos",
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
