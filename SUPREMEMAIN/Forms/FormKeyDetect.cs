using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Supreme.Forms
{
    public partial class FormKeyDetect : Form
    {
        public IContract contrato { get; set; }
        public FormKeyDetect()
        {
            InitializeComponent();
            TopMost = true;
        }
        //DLL IMPORTS & VARIABLES
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);
        string keyPressed;
        //This command send the key pressed to formBinds throw IContract
        //contrato.Ejecutar(keyPressed);

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void ESC_Click(object sender, EventArgs e)
        {
            keyPressed = "Esc";
            contrato.Ejecutar(keyPressed);
            Close();
        }

        private void F1_Click(object sender, EventArgs e)
        {
            keyPressed = "F1";
            contrato.Ejecutar(keyPressed);
            Close();
        }

        private void F2_Click(object sender, EventArgs e)
        {
            keyPressed = "F2";
            contrato.Ejecutar(keyPressed);
            Close();
        }

        private void F3_Click(object sender, EventArgs e)
        {
            keyPressed = "F3";
            contrato.Ejecutar(keyPressed);
            Close();
        }

        private void F4_Click(object sender, EventArgs e)
        {
            keyPressed = "F4";
            contrato.Ejecutar(keyPressed);
            Close();
        }

        private void F5_Click(object sender, EventArgs e)
        {
            keyPressed = "F5";
            contrato.Ejecutar(keyPressed);
            Close();
        }

        private void F6_Click(object sender, EventArgs e)
        {
            keyPressed = "F6";
            contrato.Ejecutar(keyPressed);
            Close();
        }

        private void F7_Click(object sender, EventArgs e)
        {
            keyPressed = "F7";
            contrato.Ejecutar(keyPressed);
            Close();
        }

        private void F8_Click(object sender, EventArgs e)
        {
            keyPressed = "F8";
            contrato.Ejecutar(keyPressed);
            Close();
        }

        private void F9_Click(object sender, EventArgs e)
        {
            keyPressed = "F9";
            contrato.Ejecutar(keyPressed);
            Close();
        }

        private void F10_Click(object sender, EventArgs e)
        {
            keyPressed = "F10";
            contrato.Ejecutar(keyPressed);
            Close();
        }

        private void F11_Click(object sender, EventArgs e)
        {
            keyPressed = "F11";
            contrato.Ejecutar(keyPressed);
            Close();
        }

        private void F12_Click(object sender, EventArgs e)
        {
            keyPressed = "F12";
            contrato.Ejecutar(keyPressed);
            Close();
        }

        private void special1_Click(object sender, EventArgs e)
        {
            keyPressed = "`";
            contrato.Ejecutar(keyPressed);
            Close();
        }

        private void UNO_Click(object sender, EventArgs e)
        {
            keyPressed = "1";
            contrato.Ejecutar(keyPressed);
            Close();
        }

        private void DOS_Click(object sender, EventArgs e)
        {
            keyPressed = "2";
            contrato.Ejecutar(keyPressed);
            Close();
        }

        private void TRES_Click(object sender, EventArgs e)
        {
            keyPressed = "3";
            contrato.Ejecutar(keyPressed);
            Close();
        }

        private void CUATRO_Click(object sender, EventArgs e)
        {
            keyPressed = "4";
            contrato.Ejecutar(keyPressed);
            Close();
        }

        private void CINCO_Click(object sender, EventArgs e)
        {
            keyPressed = "5";
            contrato.Ejecutar(keyPressed);
            Close();
        }

        private void SEIS_Click(object sender, EventArgs e)
        {
            keyPressed = "6";
            contrato.Ejecutar(keyPressed);
            Close();
        }

        private void SIETE_Click(object sender, EventArgs e)
        {
            keyPressed = "7";
            contrato.Ejecutar(keyPressed);
            Close();
        }

        private void OCHO_Click(object sender, EventArgs e)
        {
            keyPressed = "8";
            contrato.Ejecutar(keyPressed);
            Close();
        }

        private void NUEVE_Click(object sender, EventArgs e)
        {
            keyPressed = "9";
            contrato.Ejecutar(keyPressed);
            Close();
        }

        private void DIEZ_Click(object sender, EventArgs e)
        {
            keyPressed = "0";
            contrato.Ejecutar(keyPressed);
            Close();
        }

        private void MINUS_Click(object sender, EventArgs e)
        {
            keyPressed = "-";
            contrato.Ejecutar(keyPressed);
            Close();
        }

        private void EQUALS_Click(object sender, EventArgs e)
        {
            keyPressed = "=";
            contrato.Ejecutar(keyPressed);
            Close();
        }

        private void BACKSPACE_Click(object sender, EventArgs e)
        {
            keyPressed = "Backspace";
            contrato.Ejecutar(keyPressed);
            Close();
        }

        private void tab_Click(object sender, EventArgs e)
        {
            keyPressed = "Tab";
            contrato.Ejecutar(keyPressed);
            Close();
        }

        private void Q_Click(object sender, EventArgs e)
        {
            keyPressed = "Q";
            contrato.Ejecutar(keyPressed);
            Close();
        }

        private void W_Click(object sender, EventArgs e)
        {
            keyPressed = "W";
            contrato.Ejecutar(keyPressed);
            Close();
        }

        private void E_Click(object sender, EventArgs e)
        {
            keyPressed = "E";
            contrato.Ejecutar(keyPressed);
            Close();
        }

        private void R_Click(object sender, EventArgs e)
        {
            keyPressed = "R";
            contrato.Ejecutar(keyPressed);
            Close();
        }

        private void T_Click(object sender, EventArgs e)
        {
            keyPressed = "T";
            contrato.Ejecutar(keyPressed);
            Close();
        }

        private void Y_Click(object sender, EventArgs e)
        {
            keyPressed = "Y";
            contrato.Ejecutar(keyPressed);
            Close();
        }

        private void U_Click(object sender, EventArgs e)
        {
            keyPressed = "U";
            contrato.Ejecutar(keyPressed);
            Close();
        }

        private void I_Click(object sender, EventArgs e)
        {
            keyPressed = "I";
            contrato.Ejecutar(keyPressed);
            Close();
        }

        private void O_Click(object sender, EventArgs e)
        {
            keyPressed = "O";
            contrato.Ejecutar(keyPressed);
            Close();
        }

        private void P_Click(object sender, EventArgs e)
        {
            keyPressed = "P";
            contrato.Ejecutar(keyPressed);
            Close();
        }

        private void LBRACKET_Click(object sender, EventArgs e)
        {
            keyPressed = "[";
            contrato.Ejecutar(keyPressed);
            Close();
        }

        private void RBRACKET_Click(object sender, EventArgs e)
        {
            keyPressed = "]";
            contrato.Ejecutar(keyPressed);
            Close();
        }

        private void SPECIAL2_Click(object sender, EventArgs e)
        {
            keyPressed = @"\";
            contrato.Ejecutar(keyPressed);
            Close();
        }

        private void ENTER_Click(object sender, EventArgs e)
        {
            keyPressed = "Enter";
            contrato.Ejecutar(keyPressed);
            Close();
        }

        private void COMILLA_Click(object sender, EventArgs e)
        {
            keyPressed = "'";
            contrato.Ejecutar(keyPressed);
            Close();
        }

        private void DOUBLEDOT_Click(object sender, EventArgs e)
        {
            keyPressed = ";";
            contrato.Ejecutar(keyPressed);
            Close();
        }

        private void L_Click(object sender, EventArgs e)
        {
            keyPressed = "L";
            contrato.Ejecutar(keyPressed);
            Close();
        }

        private void K_Click(object sender, EventArgs e)
        {
            keyPressed = "K";
            contrato.Ejecutar(keyPressed);
            Close();
        }

        private void J_Click(object sender, EventArgs e)
        {
            keyPressed = "J";
            contrato.Ejecutar(keyPressed);
            Close();
        }

        private void H_Click(object sender, EventArgs e)
        {
            keyPressed = "H";
            contrato.Ejecutar(keyPressed);
            Close();
        }

        private void G_Click(object sender, EventArgs e)
        {
            keyPressed = "G";
            contrato.Ejecutar(keyPressed);
            Close();
        }

        private void F_Click(object sender, EventArgs e)
        {
            keyPressed = "F";
            contrato.Ejecutar(keyPressed);
            Close();
        }

        private void D_Click(object sender, EventArgs e)
        {
            keyPressed = "D";
            contrato.Ejecutar(keyPressed);
            Close();
        }

        private void S_Click(object sender, EventArgs e)
        {
            keyPressed = "S";
            contrato.Ejecutar(keyPressed);
            Close();
        }

        private void A_Click(object sender, EventArgs e)
        {
            keyPressed = "A";
            contrato.Ejecutar(keyPressed);
            Close();
        }

        private void capsLock_Click(object sender, EventArgs e)
        {
            keyPressed = "CapsLock";
            contrato.Ejecutar(keyPressed);
            Close();
        }

        private void LSHIFT_Click(object sender, EventArgs e)
        {
            keyPressed = "Shift";
            contrato.Ejecutar(keyPressed);
            Close();
        }

        private void Z_Click(object sender, EventArgs e)
        {
            keyPressed = "Z";
            contrato.Ejecutar(keyPressed);
            Close();
        }

        private void X_Click(object sender, EventArgs e)
        {
            keyPressed = "X";
            contrato.Ejecutar(keyPressed);
            Close();
        }

        private void C_Click(object sender, EventArgs e)
        {
            keyPressed = "C";
            contrato.Ejecutar(keyPressed);
            Close();
        }

        private void V_Click(object sender, EventArgs e)
        {
            keyPressed = "V";
            contrato.Ejecutar(keyPressed);
            Close();
        }

        private void B_Click(object sender, EventArgs e)
        {
            keyPressed = "B";
            contrato.Ejecutar(keyPressed);
            Close();
        }

        private void N_Click(object sender, EventArgs e)
        {
            keyPressed = "N";
            contrato.Ejecutar(keyPressed);
            Close();
        }

        private void M_Click(object sender, EventArgs e)
        {
            keyPressed = "M";
            contrato.Ejecutar(keyPressed);
            Close();
        }

        private void COMMA_Click(object sender, EventArgs e)
        {
            keyPressed = ",";
            contrato.Ejecutar(keyPressed);
            Close();
        }

        private void DOT_Click(object sender, EventArgs e)
        {
            keyPressed = ".";
            contrato.Ejecutar(keyPressed);
            Close();
        }

        private void SLASH_Click(object sender, EventArgs e)
        {
            keyPressed = "/";
            contrato.Ejecutar(keyPressed);
            Close();
        }

        private void RSHIFT_Click(object sender, EventArgs e)
        {
            keyPressed = "RShift";
            contrato.Ejecutar(keyPressed);
            Close();
        }

        private void LCTRL_Click(object sender, EventArgs e)
        {
            keyPressed = "Ctrl";
            contrato.Ejecutar(keyPressed);
            Close();
        }

        private void LWIN_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This key is not available");
        }

        private void LALT_Click(object sender, EventArgs e)
        {
            keyPressed = "Alt";
            contrato.Ejecutar(keyPressed);
            Close();
        }

        private void RALT_Click(object sender, EventArgs e)
        {
            keyPressed = "RAlt";
            contrato.Ejecutar(keyPressed);
            Close();
        }

        private void RCTRL_Click(object sender, EventArgs e)
        {
            keyPressed = "RCtrl";
            contrato.Ejecutar(keyPressed);
            Close();
        }

        private void RWIN_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This key is not available");
        }

        private void MENU_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This key is not available");
        }

        private void PRTSC_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This key is not available");
        }

        private void SCRLLLCK_Click(object sender, EventArgs e)
        {
            keyPressed = "ScrollLock";
            contrato.Ejecutar(keyPressed);
            Close();
        }

        private void PAUSE_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This key is not available");
        }

        private void INSERT_Click(object sender, EventArgs e)
        {
            keyPressed = "ins";
            contrato.Ejecutar(keyPressed);
            Close();
        }

        private void HOME_Click(object sender, EventArgs e)
        {
            keyPressed = "Home";
            contrato.Ejecutar(keyPressed);
            Close();
        }

        private void PAGEUP_Click(object sender, EventArgs e)
        {
            keyPressed = "pgup";
            contrato.Ejecutar(keyPressed);
            Close();
        }

        private void PAGEDOWN_Click(object sender, EventArgs e)
        {
            keyPressed = "pgdn";
            contrato.Ejecutar(keyPressed);
            Close();
        }

        private void END_Click(object sender, EventArgs e)
        {
            keyPressed = "End";
            contrato.Ejecutar(keyPressed);
            Close();
        }

        private void DELETE_Click(object sender, EventArgs e)
        {
            keyPressed = "del";
            contrato.Ejecutar(keyPressed);
            Close();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            keyPressed = "space";
            contrato.Ejecutar(keyPressed);
            Close();
        }

        private void ARROWUP_Click(object sender, EventArgs e)
        {
            keyPressed = "uparrow";
            contrato.Ejecutar(keyPressed);
            Close();
        }

        private void ARROWDOWN_Click(object sender, EventArgs e)
        {
            keyPressed = "downarrow";
            contrato.Ejecutar(keyPressed);
            Close();
        }

        private void ARROWLEFT_Click(object sender, EventArgs e)
        {
            keyPressed = "leftarrow";
            contrato.Ejecutar(keyPressed);
            Close();
        }

        private void ARROWRIGHT_Click(object sender, EventArgs e)
        {
            keyPressed = "rightarrow";
            contrato.Ejecutar(keyPressed);
            Close();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            keyPressed = "NumLock";
            contrato.Ejecutar(keyPressed);
            Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            keyPressed = "kp_slash";
            contrato.Ejecutar(keyPressed);
            Close();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            keyPressed = "kp_multiply";
            contrato.Ejecutar(keyPressed);
            Close();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            keyPressed = "kp_minus";
            contrato.Ejecutar(keyPressed);
            Close();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            keyPressed = "kp_home";
            contrato.Ejecutar(keyPressed);
            Close();
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            keyPressed = "kp_uparrow";
            contrato.Ejecutar(keyPressed);
            Close();
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            keyPressed = "kp_pgup";
            contrato.Ejecutar(keyPressed);
            Close();
        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            keyPressed = "kp_leftarrow";
            contrato.Ejecutar(keyPressed);
            Close();
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            keyPressed = "kp_5";
            contrato.Ejecutar(keyPressed);
            Close();
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            keyPressed = "kp_rightarrow";
            contrato.Ejecutar(keyPressed);
            Close();
        }

        private void pictureBox16_Click(object sender, EventArgs e)
        {
            keyPressed = "kp_end";
            contrato.Ejecutar(keyPressed);
            Close();
        }

        private void pictureBox15_Click(object sender, EventArgs e)
        {
            keyPressed = "kp_downarrow";
            contrato.Ejecutar(keyPressed);
            Close();
        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {
            keyPressed = "kp_pgdn";
            contrato.Ejecutar(keyPressed);
            Close();
        }

        private void pictureBox18_Click(object sender, EventArgs e)
        {
            keyPressed = "kp_ins";
            contrato.Ejecutar(keyPressed);
            Close();
        }

        private void pictureBox17_Click(object sender, EventArgs e)
        {
            keyPressed = "kp_del";
            contrato.Ejecutar(keyPressed);
            Close();
        }

        private void pictureBox20_Click(object sender, EventArgs e)
        {
            keyPressed = "kp_enter";
            contrato.Ejecutar(keyPressed);
            Close();
        }

        private void pictureBox19_Click(object sender, EventArgs e)
        {
            keyPressed = "kp_plus";
            contrato.Ejecutar(keyPressed);
            Close();
        }
    }
}
