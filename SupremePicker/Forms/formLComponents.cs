using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Supreme.Forms
{
    public partial class formLComponents : Form
    {
        public formLComponents()
        {
            InitializeComponent();
            tmrLoaded.Enabled = true;
            tmrLoaded.Start();

        }
        private void formLComponents_Load(object sender, EventArgs e)
        {
            tmrDots.Enabled = true;
            tmrDots.Start();
            label2.Text = Properties.Settings.Default.C_Assembly_Version;
        }

        #region BackEnd
        private void tmrLoaded_Tick(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.formLoaderIsReady == true)
            {
                Close();
            }
        }
        private void tmrDots_Tick(object sender, EventArgs e)
        {
            switch (contador)
            {
                case 4:
                    label1.Text = "LOADING COMPONENTS...";
                    contador = 1;
                    break;
                case 3:
                    label1.Text = "LOADING COMPONENTS..";
                    contador = 4;
                    break;
                case 2:
                    label1.Text = "LOADING COMPONENTS.";
                    contador = 3;
                    break;
                case 1:
                    label1.Text = "LOADING COMPONENTS";
                    contador = 2;
                    break;
            }
        }
        #endregion

        #region FrontEnd
        private void LoadingGif_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        #endregion

        #region Variables & Imports
        int contador = 1;
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(IntPtr hwnd, int wmsg, int wparam, int lparam);
        #endregion
    }
}
