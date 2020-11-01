using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Supreme.Forms
{
    public partial class FormUnderContrPop : Form
    {
        public FormUnderContrPop()
        {
            InitializeComponent();
            language();
        }

        private void language()
        {
            switch (Properties.Settings.Default.Language)
            {
                case 0:
                    //ENG
                    label1.Text = "This formulary is under construction!";
                    label2.Text = "Be patient and you will be rewarded :)";
                    label2.Location = new Point(132, 70);
                    break;
                case 1:
                    //ES
                    label1.Text = "Este formulario esta bajo construcción!";
                    label2.Text = "Se paciente y serás recompensado :)";
                    label2.Location = new Point(132, 70);
                    break;
                case 2:
                    //PR
                    label1.Text = "Este formulário está em construção!";
                    label2.Text = "Seja paciente e você será recompensado :)";
                    label2.Location = new Point(120, 70);
                    break;
            }
        }


        #region Events & Imports
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);
        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void button1_MouseEnter(object sender, EventArgs e)
        {
            button1.ForeColor = Color.White;
            button1.BackColor = Color.Lime;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.ForeColor = Color.Lime;
            button1.BackColor = Color.FromArgb(24, 26, 29);
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        #endregion
    }
}
