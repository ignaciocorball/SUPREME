using Ionic.Zip;
using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace helper_v2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            string getCurrentDirectory = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            string supremeZIP = getCurrentDirectory + @"\SUPREME_UPDATE.zip";
            UnZIP(supremeZIP, getCurrentDirectory);
            Process.Start(getCurrentDirectory + @"\SUPREME.exe");
            File.Delete(supremeZIP);
            Environment.Exit(0);
        }
        public void UnZIP(string zipFilePath, string outputDirectoryPath)
        {
            try
            {
                using (ZipFile zip1 = ZipFile.Read(zipFilePath))
                {
                    foreach (ZipEntry e in zip1)
                    {
                        e.Extract(outputDirectoryPath, ExtractExistingFileAction.OverwriteSilently);
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error Unzipping file " + ex);
            }
        }
    }
}
