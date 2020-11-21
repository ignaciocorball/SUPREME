using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Supreme.Forms
{
    public partial class Update : Form
    {
        //DLL IMPORTS
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(IntPtr hwnd, int wmsg, int wparam, int lparam);
        string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        string currentDirectory = Directory.GetCurrentDirectory();


        public Update()
        {
            InitializeComponent();
            Text = "Updater";
        }
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
        private void button1_Click(object sender, EventArgs e)
        {
            string inkPath = currentDirectory + @"\SUPREME";
            if (currentDirectory == desktopPath)
            {
                try
                {
                    string shortcutPath = GetShortcutInfo(inkPath);
                    string parser = shortcutPath.Replace(@"\SUPREME.exe", @"\SUPREMEUPDATER.exe");
                    Process.Start(parser);
                    Environment.Exit(0);

                }
                catch
                {
                    
                }
            }
            else
            {
                Process.Start(Directory.GetCurrentDirectory() + "\\SUPREMEUPDATER.exe");
                Environment.Exit(0);
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        private void button2_MouseEnter(object sender, EventArgs e)
        {
            button2.ForeColor = Color.White;
            button2.BackColor = Color.DarkRed;
        }
        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.ForeColor = Color.DarkRed;
            button2.BackColor = Color.FromArgb(24, 26, 29);
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
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        private void Update_Shown(object sender, EventArgs e)
        {
            TopMost = true;
        }
    }
}
