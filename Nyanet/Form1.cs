using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nyanet
{
    public partial class Form1 : Form
    {
        string sysFolder = Environment.GetFolderPath(Environment.SpecialFolder.System);
        public Process p;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Visible = false;
            button1.Enabled = false;
            button2.Enabled = true;
            button2.Visible = true;
            if (checkBox2.Checked)
            {
                Thread nyanetRegeditStartBackgroundJob = new Thread(() => setDoH());
                nyanetRegeditStartBackgroundJob.IsBackground = true;
                nyanetRegeditStartBackgroundJob.Start();
            }

            if (checkBox1.Checked)
            {
                Thread nyanetSetDNSBackgroundJob = new Thread(() => setDNSServers());
                nyanetSetDNSBackgroundJob.IsBackground = true;
                nyanetSetDNSBackgroundJob.Start();
            }
            Thread nyanetServiceFrameworkStartBackgroundJob = new Thread(() => nyanetServiceFramework("execute"));
            nyanetServiceFrameworkStartBackgroundJob.IsBackground = true;
            nyanetServiceFrameworkStartBackgroundJob.Start();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Thread nyanetServiceFrameworkStopBackgroundJob = new Thread(() => nyanetServiceFramework("terminate"));
            nyanetServiceFrameworkStopBackgroundJob.IsBackground = true;
            nyanetServiceFrameworkStopBackgroundJob.Start();
            button1.Enabled = true;
            button1.Visible = true;
            button2.Enabled = false;
            button2.Visible = false;
        }
        private void Form1_Load(object sender, EventArgs e)
        {checkAdminAccess();
            Show();
            Activate();
            Focus();
        }
        private void nyanetServiceFramework(string operation)
        {
            if (operation == "execute") {
                try {p = Process.Start("NyanetServiceFramework.exe");}
                catch (Exception e) { MessageBox.Show(e.ToString()); }
            }
            else if (operation == "terminate"){
                try{
                    p.Kill();
                    p.Dispose();
                    Application.Restart();
                    Environment.Exit(0);
                }
                catch (Exception e){ MessageBox.Show(e.ToString()); }
            }
        }
        //Set DNS Over HTTPS Settings for Windows 11, As You Can See I am Using CloudFlare <3
        private void setDoH()
        {
            try{
                string reg1 = "/C REG ADD \"HKLM\\SOFTWARE\\Policies\\Microsoft\\Windows NT\\DNSClient\" /F";
                Process.Start(sysFolder + "\\CMD.exe", reg1);
            }
            catch (Exception e){ MessageBox.Show(e.ToString()); }
            try{
                string reg2 = "/C REG ADD \"HKLM\\SOFTWARE\\Policies\\Microsoft\\Windows NT\\DNSClient\" /v DoHPolicy /t REG_DWORD /d 2 /F";
                Process.Start(sysFolder + "\\CMD.exe", reg2);
            }
            catch (Exception e) { MessageBox.Show(e.ToString()); }
            try
            {
                string reg3 = "/C REG ADD \"HKLM\\SYSTEM\\CurrentControlSet\\Services\\Dnscache\\Parameters\\DohWellKnownServers\" /F";
                Process.Start(sysFolder + "\\CMD.exe", reg3);
            }
            catch (Exception e) { MessageBox.Show(e.ToString()); }
            try
            {
                string reg4 = "/C REG ADD \"HKLM\\SYSTEM\\CurrentControlSet\\Services\\Dnscache\\Parameters\\DohWellKnownServers\\1.1.1.1\" /F";
                Process.Start(sysFolder + "\\CMD.exe", reg4);
            }
            catch (Exception e) { MessageBox.Show(e.ToString()); }
            try
            {
                string reg5 = "/C REG ADD \"HKLM\\SYSTEM\\CurrentControlSet\\Services\\Dnscache\\Parameters\\DohWellKnownServers\\1.1.1.1\" /v Template /t REG_SZ /d https://cloudflare-dns.com/dns-query /F";
                Process.Start(sysFolder + "\\CMD.exe", reg5);
            }
            catch (Exception e) { MessageBox.Show(e.ToString()); }
            try
            {
                string reg6 = "/C REG ADD \"HKLM\\SYSTEM\\CurrentControlSet\\Services\\Dnscache\\Parameters\\DohWellKnownServers\\1.0.0.1\" /F";
                Process.Start(sysFolder + "\\CMD.exe", reg6);
            }
            catch (Exception e) { MessageBox.Show(e.ToString()); }
            try
            {
                string reg7 = "/C REG ADD \"HKLM\\SYSTEM\\CurrentControlSet\\Services\\Dnscache\\Parameters\\DohWellKnownServers\\1.0.0.1\" /v Template /t REG_SZ /d https://cloudflare-dns.com/dns-query /F";
                Process.Start(sysFolder + "\\CMD.exe", reg7);
            }
            catch (Exception e) { MessageBox.Show(e.ToString()); }
            try
            {
                string reg8 = "/C REG ADD \"HKLM\\SYSTEM\\CurrentControlSet\\Services\\Dnscache\\Parameters\\DohWellKnownServers\\2606:4700:4700::1111\" /F";
                Process.Start(sysFolder + "\\CMD.exe", reg8);
            }
            catch (Exception e) { MessageBox.Show(e.ToString()); }
            try
            {
                string reg9 = "/C REG ADD \"HKLM\\SYSTEM\\CurrentControlSet\\Services\\Dnscache\\Parameters\\DohWellKnownServers\\2606:4700:4700::1111\" /v Template /t REG_SZ /d https://cloudflare-dns.com/dns-query /F";
                Process.Start(sysFolder + "\\CMD.exe", reg9);
            }
            catch (Exception e) { MessageBox.Show(e.ToString()); }
            try
            {
                string reg10 = "/C REG ADD \"HKLM\\SYSTEM\\CurrentControlSet\\Services\\Dnscache\\Parameters\\DohWellKnownServers\\2606:4700:4700::1001\" /F";
                Process.Start(sysFolder + "\\CMD.exe", reg10);
            }
            catch (Exception e) { MessageBox.Show(e.ToString()); }
            try
            {
                string reg11 = "/C REG ADD \"HKLM\\SYSTEM\\CurrentControlSet\\Services\\Dnscache\\Parameters\\DohWellKnownServers\\2606:4700:4700::1001\" /v Template /t REG_SZ /d https://cloudflare-dns.com/dns-query /F";
                Process.Start(sysFolder + "\\CMD.exe", reg11);
            }
            catch (Exception e) { MessageBox.Show(e.ToString()); }
        }
        private void setDNSServers()
        {
            try{
                    string cmd1 = "/C netsh interface ipv4 set dns name=\"Ethernet\" source=static address=none";
                    Process.Start(sysFolder + "\\CMD.exe", cmd1);
            }
            catch (Exception e) { MessageBox.Show(e.ToString()); }
            try{
                    string cmd1 = "/C netsh interface ipv4 set dns name=\"Wi-Fi\" source=static address=none";
                    Process.Start(sysFolder + "\\CMD.exe", cmd1);
            }
            catch (Exception e) { MessageBox.Show(e.ToString()); }
            try{
                    string cmd1 = "/C netsh interface ipv6 set dns name=\"Ethernet\" source=static address=none";
                    Process.Start(sysFolder + "\\CMD.exe", cmd1);
            }
            catch (Exception e) { MessageBox.Show(e.ToString()); }
            try{
                    string cmd1 = "/C netsh interface ipv6 set dns name=\"Wi-Fi\" source=static address=none";
                    Process.Start(sysFolder + "\\CMD.exe", cmd1);
            }
            catch (Exception e) { MessageBox.Show(e.ToString()); }
            try{
                    string cmd1 = "/C netsh interface ipv4 add dnsservers \"Wi-Fi\" 1.1.1.1 index=1";
                    Process.Start(sysFolder + "\\CMD.exe", cmd1);
            }
            catch (Exception e) { MessageBox.Show(e.ToString()); }
            try{
                    string cmd1 = "/C netsh interface ipv4 add dnsservers \"Wi-Fi\" 1.0.0.1 index=2";
                    Process.Start(sysFolder + "\\CMD.exe", cmd1);
            }
            catch (Exception e) { MessageBox.Show(e.ToString()); }
            try{
                    string cmd1 = "/C netsh interface ipv6 add dnsservers \"Wi-Fi\" 2606:4700:4700::1111 index=1";
                    Process.Start(sysFolder + "\\CMD.exe", cmd1);
            }
            catch (Exception e) { MessageBox.Show(e.ToString()); }
            try{
                    string cmd1 = "/C netsh interface ipv6 add dnsservers \"Wi-Fi\" 2606:4700:4700::1001 index=2";
                    Process.Start(sysFolder + "\\CMD.exe", cmd1);
            }
            catch (Exception e) { MessageBox.Show(e.ToString()); }
            try{
                    string cmd1 = "/C netsh interface ipv4 add dnsservers \"Ethernet\" 1.1.1.1 index=1";
                    Process.Start(sysFolder + "\\CMD.exe", cmd1);
            }
            catch (Exception e) { MessageBox.Show(e.ToString()); }
            try{
                    string cmd1 = "/C netsh interface ipv4 add dnsservers \"Ethernet\" 1.0.0.1 index=2";
                    Process.Start(sysFolder + "\\CMD.exe", cmd1);
            }
            catch (Exception e) { MessageBox.Show(e.ToString()); }
            try{
                    string cmd1 = "/C netsh interface ipv6 add dnsservers \"Ethernet\" 2606:4700:4700::1111 index=1";
                    Process.Start(sysFolder + "\\CMD.exe", cmd1);
            }
            catch (Exception e) { MessageBox.Show(e.ToString()); }
            try{
                    string cmd1 = "/C netsh interface ipv6 add dnsservers \"Ethernet\" 2606:4700:4700::1001 index=2";
                    Process.Start(sysFolder + "\\CMD.exe", cmd1);
            }
            catch (Exception e) { MessageBox.Show(e.ToString()); }
        }
        private void remoteDisableSwitch() { 
        
        }
        private void checkAdminAccess()
        {
            var wi = WindowsIdentity.GetCurrent();
            var wp = new WindowsPrincipal(wi);
            bool runAsAdmin = wp.IsInRole(WindowsBuiltInRole.Administrator);

            if (!runAsAdmin)
            {
                // It is not possible to launch a ClickOnce app as administrator directly,
                // so instead we launch the app as administrator in a new process.
                var processInfo = new ProcessStartInfo(Assembly.GetExecutingAssembly().CodeBase);
                // The following properties run the new process as administrator
                processInfo.UseShellExecute = true;
                processInfo.Verb = "runas";
                // Start the new process
                try { Process.Start(processInfo); }
                // The user did not allow the application to run as administrator
                catch (Exception) { MessageBox.Show("Since i can install direct X i need to run as Administrator.\nNow exiting."); }
                // Shut down the current process
                Application.Exit();
            }
        }


    }
}
