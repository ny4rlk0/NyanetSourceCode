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
using System.Security.Cryptography;
using System.Net;

namespace Nyanet
{
    public partial class Form1 : Form
    {
        string sysFolder = Environment.GetFolderPath(Environment.SpecialFolder.System);
        string startupPath = Application.StartupPath + "\\";
        public Process p;
        string Nyanet_exe = "";
        string NyanetServiceFramework_exe = "2093b62a2dea784dc84e32a70e4a8dd4";
        string WinDivert_dll= "b2014d33ee645112d5dc16fe9d9fcbff";
        string WinDivert64_sys = "89ed5be7ea83c01d0de33d3519944aa5";
        string WinDivert32_sys = "067f9a24d630670f543d95a98cc199df";
        public static string dnsv4_1 = "", dnsv4_2 = "", dnsv6_1 = "", dnsv6_2 = "", httpsTemplate="";
        Uri dotnet_x64 = new Uri("https://github.com/ny4rlk0/Nyanet/releases/download/Gereksinimler/windowsdesktop-runtime-6.0.20-win-x64.exe");
        Uri dotnet_x86 = new Uri("https://github.com/ny4rlk0/Nyanet/releases/download/Gereksinimler/windowsdesktop-runtime-6.0.20-win-x86.exe");

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
            MessageBox.Show("Programı yazmış olabilirim ama kullanımından doğacak hiçbir zarar veya sorumluluğu kabul etmemekteyim. İşbu yazılım size hiçbir garanti verilmeden ücretsiz sunulmuştur. -ny4rlk0\nhttps://github.com/ny4rlk0");
            if (comboBox1.SelectedIndex==0)
                nyanetServiceFramework("-n","start");
            else if (comboBox1.SelectedIndex == 1)
                nyanetServiceFramework("-y", "start");
            else if (comboBox1.SelectedIndex == 2)
                nyanetServiceFramework("-a", "start");
            else if (comboBox1.SelectedIndex == 3)
                nyanetServiceFramework("-r", "start");
            else if (comboBox1.SelectedIndex == 4)
                nyanetServiceFramework("-l", "start");
            else if (comboBox1.SelectedIndex == 5)
                nyanetServiceFramework("-k", "start");
            else  nyanetServiceFramework("-l", "start");
        }
        private void button2_Click(object sender, EventArgs e)
        {
            nyanetServiceFramework("NyanetServiceFramework","stop"); //terminate nyanet
            button1.Enabled = true;
            button1.Visible = true;
            button2.Enabled = false;
            button2.Visible = false;
        }
        private void Form1_Load(object sender, EventArgs e){
            checkAdminAccess();
            Show();
            Activate();
            Focus();
            Thread nyanetServiceStatus = new Thread(() => checkServiceStatus());
            nyanetServiceStatus.IsBackground = true;
            nyanetServiceStatus.Start();
            comboBox1.Items.Add("-n Uyumlu Mod");
            comboBox1.Items.Add("-y Hızlı HTTPS ve Uyumlu Mod");
            comboBox1.Items.Add("-a Hızlı HTTP ve HTTPS Mod");
            comboBox1.Items.Add("-r En hızlı Mod");
            comboBox1.Items.Add("-l Varsayılan Mod");
            comboBox1.Items.Add("-k Varsayılan 2, Karışık Paket Sıralaması Mod");
            comboBox1.Items.Add("-o Geçersiz Mod");
            try { comboBox1.SelectedIndex = comboBox1.FindString("-l Varsayılan Mod"); }
            catch (Exception) { }
            comboBox2.Items.Add("Cloudflare");
            comboBox2.Items.Add("Google");
            try { comboBox2.SelectedIndex = comboBox2.FindString("Cloudflare"); }
            catch (Exception) { }
            string notFound = "";
            if (!File.Exists(startupPath+ "NyanetServiceFramework.exe"))
                notFound += "NyanetServiceFramework.exe ";
            if (!File.Exists(startupPath + "WinDivert.dll"))
                notFound += "WinDivert.dll ";
            if (!File.Exists(startupPath + "WinDivert64.sys"))
                notFound += "WinDivert64.sys ";
            if (!File.Exists(startupPath + "WinDivert32.sys"))
                notFound += "WinDivert32.sys ";
            if (notFound!="")
                MessageBox.Show("("+notFound+") Dosyalardan bazıları eksik. Program normal çalışmayabilir!");
            try
            {
                using (var md5 = MD5.Create())
                {
                    using (var stream = File.OpenRead(startupPath + "Nyanet.exe"))
                    {
                        var hash = md5.ComputeHash(stream);
                        string hesaplananHash = BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
                        label10.Text = "Nyanet.exe MD5: " + hesaplananHash;
                        Nyanet_exe = hesaplananHash;
                    }
                }
            }
            catch (Exception) { }
        }
        private void checkServiceStatus() {
            try
            {
                Process[] pname = Process.GetProcessesByName("NyanetServiceFramework");
                if (pname.Length == 0){
                    if (label3.Text != "Çalışmıyor"){
                        this.Invoke((MethodInvoker)delegate {
                            label3.Text = "Çalışmıyor";
                            label3.ForeColor = Color.Red;
                                try
                                {
                                    using (var md5 = MD5.Create()) { 
                                        using (var stream = File.OpenRead(startupPath + "NyanetServiceFramework.exe"))
                                        {
                                            var hash = md5.ComputeHash(stream);
                                            string hesaplananHash = BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
                                            if (hesaplananHash != NyanetServiceFramework_exe)
                                            {
                                                label4.ForeColor = Color.Red;
                                                label4.Text = "NyanetServiceFramework.exe: MD5 Hash Doğrulanamadı!";
                                            }
                                            else
                                            {
                                                label4.Text = "NyanetServiceFramework.exe: MD5 Hash Doğrulandı!";
                                                label4.ForeColor = Color.Lime;
                                            }
                                        }
                                    }
                                }
                                catch (Exception)
                                {}
                                //pname[0].MainModule.FileName.ToString())
                        });
                        
                    }

                }
                else{
                    if (label3.Text!= "Çalışıyor"){
                        this.Invoke((MethodInvoker)delegate {
                        label3.Text = "Çalışıyor";
                        label3.ForeColor = Color.Lime;
                        pname[0].MainModule.FileName.ToString();
                            try
                            {
                                using (var md5 = MD5.Create())
                                {                                     //pname[0].MainModule.FileName.ToString())
                                    using (var stream = File.OpenRead(startupPath + "NyanetServiceFramework.exe"))
                                    {
                                        var hash = md5.ComputeHash(stream);
                                        string hesaplananHash= BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
                                        if (hesaplananHash!= NyanetServiceFramework_exe)
                                        {
                                            label4.ForeColor= Color.Red;
                                            label4.Text = "NyanetServiceFramework.exe: MD5 Hash Doğrulanamadı!";
                                        }
                                        else{
                                            label4.Text = "NyanetServiceFramework.exe: MD5 Hash Doğrulandı!";
                                            label4.ForeColor = Color.Lime;
                                            }
                                    }
                                }
                            }
                            catch (Exception){ }
                        });
                    }

                }
                this.Invoke((MethodInvoker)delegate {
                    try
                    {
                        using (var md5 = MD5.Create())
                        {
                            using (var stream = File.OpenRead(startupPath + "WinDivert.dll"))
                            {
                                var hash = md5.ComputeHash(stream);
                                string hesaplananHash = BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
                                if (hesaplananHash != WinDivert_dll)
                                {
                                    label5.Text = "WinDivert.dll: MD5 Hash Doğrulanamadı!";
                                    label5.ForeColor = Color.Red;
                                }
                                else
                                {
                                    label5.Text = "WinDivert.dll: MD5 Hash Doğrulandı!";
                                    label5.ForeColor = Color.Lime;
                                }
                            }
                        }
                    }
                    catch (Exception){ }
                    try
                    {
                        using (var md5 = MD5.Create())
                        {
                            using (var stream = File.OpenRead(startupPath + "WinDivert64.sys"))
                            {
                                var hash = md5.ComputeHash(stream);
                                string hesaplananHash = BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
                                if (hesaplananHash != WinDivert64_sys)
                                {
                                    label6.Text = "WinDivert64.sys: MD5 Hash Doğrulanamadı!";
                                    label6.ForeColor = Color.Red;
                                }
                                else
                                {
                                    label6.Text = "WinDivert64.sys: MD5 Hash Doğrulandı!";
                                    label6.ForeColor = Color.Lime;
                                }
                            }
                        }
                    }
                    catch (Exception){ }
                    try
                    {
                        using (var md5 = MD5.Create())
                        {
                            using (var stream = File.OpenRead(startupPath + "WinDivert32.sys"))
                            {
                                var hash = md5.ComputeHash(stream);
                                string hesaplananHash = BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
                                if (hesaplananHash != WinDivert32_sys)
                                {
                                    label8.Text = "WinDivert32.sys: MD5 Hash Doğrulanamadı!";
                                    label8.ForeColor = Color.Red;
                                }
                                else
                                {
                                    label8.Text = "WinDivert32.sys: MD5 Hash Doğrulandı!";
                                    label8.ForeColor = Color.Lime;
                                }
                            }
                        }
                    }
                    catch (Exception){ }
                });
            }
            catch (Exception e)
            {
                MessageBox.Show("checkServiceStatus: \n"+e.ToString());
                
            }
            Thread.Sleep(1000);//2 saniye bekle
            checkServiceStatus();
        }
        //Set DNS Over HTTPS Settings for Windows 11, As You Can See I am Using CloudFlare <3
        private void setDoH()
        {
            setDNSValues();
            try{
                CMD("/C REG ADD \"HKLM\\SOFTWARE\\Policies\\Microsoft\\Windows NT\\DNSClient\" /F");
            }
            catch (Exception e){ MessageBox.Show(e.ToString()); }
            try{
                CMD("/C REG ADD \"HKLM\\SOFTWARE\\Policies\\Microsoft\\Windows NT\\DNSClient\" /v DoHPolicy /t REG_DWORD /d 2 /F");
            }
            catch (Exception e) { MessageBox.Show(e.ToString()); }
            try
            {
                CMD("/C REG ADD \"HKLM\\SYSTEM\\CurrentControlSet\\Services\\Dnscache\\Parameters\\DohWellKnownServers\" /F");
            }
            catch (Exception e) { MessageBox.Show(e.ToString()); }
            try
            {
                CMD("/C REG ADD \"HKLM\\SYSTEM\\CurrentControlSet\\Services\\Dnscache\\Parameters\\DohWellKnownServers\\" +dnsv4_1+"\" /F");
            }
            catch (Exception e) { MessageBox.Show(e.ToString()); }
            try
            {
                CMD("/C REG ADD \"HKLM\\SYSTEM\\CurrentControlSet\\Services\\Dnscache\\Parameters\\DohWellKnownServers\\" +dnsv4_1+"\" /v Template /t REG_SZ /d "+httpsTemplate+" /F");
            }
            catch (Exception e) { MessageBox.Show(e.ToString()); }
            try
            {
                CMD("/C REG ADD \"HKLM\\SYSTEM\\CurrentControlSet\\Services\\Dnscache\\Parameters\\DohWellKnownServers\\" +dnsv4_2+"\" /F");
            }
            catch (Exception e) { MessageBox.Show(e.ToString()); }
            try
            {
                CMD("/C REG ADD \"HKLM\\SYSTEM\\CurrentControlSet\\Services\\Dnscache\\Parameters\\DohWellKnownServers\\" +dnsv4_2+"\" /v Template /t REG_SZ /d "+httpsTemplate+" /F");
            }
            catch (Exception e) { MessageBox.Show(e.ToString()); }
            try
            {
                CMD("/C REG ADD \"HKLM\\SYSTEM\\CurrentControlSet\\Services\\Dnscache\\Parameters\\DohWellKnownServers\\" +dnsv6_1+"\" /F");
            }
            catch (Exception e) { MessageBox.Show(e.ToString()); }
            try
            {
                CMD("/C REG ADD \"HKLM\\SYSTEM\\CurrentControlSet\\Services\\Dnscache\\Parameters\\DohWellKnownServers\\" +dnsv6_1+"\" /v Template /t REG_SZ /d "+httpsTemplate+" /F");
            }
            catch (Exception e) { MessageBox.Show(e.ToString()); }
            try
            {
                CMD("/C REG ADD \"HKLM\\SYSTEM\\CurrentControlSet\\Services\\Dnscache\\Parameters\\DohWellKnownServers\\" +dnsv6_2+"\" /F");
            }
            catch (Exception e) { MessageBox.Show(e.ToString()); }
            try
            {
                CMD("/C REG ADD \"HKLM\\SYSTEM\\CurrentControlSet\\Services\\Dnscache\\Parameters\\DohWellKnownServers\\" +dnsv6_2+"\" /v Template /t REG_SZ /d "+httpsTemplate+" /F");
            }
            catch (Exception e) { MessageBox.Show(e.ToString()); }
            MessageBox.Show(comboBox2.SelectedText.ToString() + " DNS sunucusu sisteminize eklendi. DNS ayarlarını aktifleştirmeyi unutmayın! (1. Adım)");
            checkBox2.Checked = false;
        }
        private void setDNSServers()
        {
            setDNSValues();
            try
            {
                CMD("/C netsh interface ipv4 set dns name=\"Ethernet\" source=static address=none");
            }
            catch (Exception e) { MessageBox.Show(e.ToString()); }
            try{
                CMD("/C netsh interface ipv4 set dns name=\"Wi-Fi\" source=static address=none");
            }
            catch (Exception e) { MessageBox.Show(e.ToString()); }
            try{
                CMD("/C netsh interface ipv6 set dns name=\"Ethernet\" source=static address=none");
            }
            catch (Exception e) { MessageBox.Show(e.ToString()); }
            try{
                CMD("/C netsh interface ipv6 set dns name=\"Wi-Fi\" source=static address=none");
            }
            catch (Exception e) { MessageBox.Show(e.ToString()); }
            try{
                CMD("/C netsh interface ipv4 add dnsservers \"Wi-Fi\" " +dnsv4_1+" index=1");
            }
            catch (Exception e) { MessageBox.Show(e.ToString()); }
            try{
                CMD("/C netsh interface ipv4 add dnsservers \"Wi-Fi\" " +dnsv4_2+" index=2");
            }
            catch (Exception e) { MessageBox.Show(e.ToString()); }
            try{
                CMD("/C netsh interface ipv6 add dnsservers \"Wi-Fi\" " +dnsv6_1+" index=1");
            }
            catch (Exception e) { MessageBox.Show(e.ToString()); }
            try{
                CMD("/C netsh interface ipv6 add dnsservers \"Wi-Fi\" " +dnsv6_2+" index=2");
            }
            catch (Exception e) { MessageBox.Show(e.ToString()); }
            try{
                CMD("/C netsh interface ipv4 add dnsservers \"Ethernet\" " +dnsv4_1+" index=1");
            }
            catch (Exception e) { MessageBox.Show(e.ToString()); }
            try{
                CMD("/C netsh interface ipv4 add dnsservers \"Ethernet\" " +dnsv4_2+" index=2");
            }
            catch (Exception e) { MessageBox.Show(e.ToString()); }
            try{
                CMD("/C netsh interface ipv6 add dnsservers \"Ethernet\" " +dnsv6_1+" index=1");
            }
            catch (Exception e) { MessageBox.Show(e.ToString()); }
            try{
                CMD("/C netsh interface ipv6 add dnsservers \"Ethernet\" " +dnsv6_2+" index=2");
            }
            catch (Exception e) { MessageBox.Show(e.ToString()); }
            checkBox1.Checked = false;
            MessageBox.Show(comboBox2.SelectedText.ToString()+" DNS sunucusu aktifleştirildi! (2. Adım)");
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
                catch (Exception) { MessageBox.Show("Ağ paketlerini manipule ettiğim ve sistem sürücüsü içerdiğim için Administrator olarak çalışmam lazım.\nAdmin yetkisi vermediğin için yazılım kapatılıyor."); }
                // Shut down the current process
                Environment.Exit(0);
            }
        }
        private void nyanetServiceFramework(string Options,string StartOrStop)
        {
            Thread nyanetServiceFrameworkDelagateBackground = new Thread(() => nyanetServiceFrameworkDelagate(Options,StartOrStop));
            nyanetServiceFrameworkDelagateBackground.IsBackground = true;
            nyanetServiceFrameworkDelagateBackground.Start();
        }
        private void nyanetServiceFrameworkDelagate(string Options,string StartOrStop)
        {
            try
            {
                if (StartOrStop=="start")
                {
                    Process p = new Process();
                    p.StartInfo.FileName = startupPath+ "NyanetServiceFramework.exe";
                    p.StartInfo.Arguments = Options;
                    p.StartInfo.UseShellExecute = false;
                    p.StartInfo.RedirectStandardOutput = false;
                    p.StartInfo.RedirectStandardError = false;
                    p.StartInfo.CreateNoWindow = true;
                    p.Start();
                    p.WaitForExit();
                }
                else if (StartOrStop=="stop") {
                    Process[] pname = Process.GetProcessesByName("NyanetServiceFramework");
                    if (pname.Length == 0)
                    {
                        //not running
                    }
                       
                    else //running
                        CMD("/C taskkill /im \"NyanetServiceFramework.exe\" /f");
                }

            }
            catch (Exception er) { MessageBox.Show(er.ToString()); }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            button3.Enabled = false;
            button3.Visible = false;
            //Form Aç
            // Create a new instance of the Form2 class
            Form2 settingsForm = new Form2();

            // Show the settings form
            settingsForm.Show();
            //DNS Ekle
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {
                checkBox3.Enabled = false;
                checkBox3.Visible = false;
                label12.Enabled = true;
                label12.Visible = true;
                Thread cmdBackground = new Thread(() => downloadNeccesaryWindowsUpdate());
                cmdBackground.IsBackground = true;
                cmdBackground.Start();
            }

        }
        private void downloadNeccesaryWindowsUpdate()
        {
            using (var client = new WebClient())
            {
                client.DownloadProgressChanged += (sender, e) =>
                {
                    this.Invoke((MethodInvoker)delegate {label12.Text = ("Gereksinimler indiriliyor. (windowsdesktop-runtime-6.0.20-win-x64.exe %" + e.ProgressPercentage.ToString() + " )"); });
                };
                client.DownloadFileCompleted += (sender, e) =>
                {
                    ifAvaiableInstallDotnet("windowsdesktop-runtime-6.0.20-win-x64.exe");
                    using (var client2 = new WebClient())
                    {
                        client2.DownloadProgressChanged += (sender2, e2) =>
                        {
                            this.Invoke((MethodInvoker)delegate { label12.Text = ("Gereksinimler indiriliyor. (windowsdesktop-runtime-6.0.20-win-x86.exe %" + e2.ProgressPercentage.ToString() + " )"); });
                        };
                        client2.DownloadFileCompleted += (sender2, e2) =>
                        {
                            ifAvaiableInstallDotnet("windowsdesktop-runtime-6.0.20-win-x86.exe");
                        };
                        client2.DownloadFileAsync(dotnet_x86, "windowsdesktop-runtime-6.0.20-win-x86.exe");
                    }
                };
                client.DownloadFileAsync(dotnet_x64, "windowsdesktop-runtime-6.0.20-win-x64.exe");
            }
            /*
            using (var client = new WebClient())
            {
                client.DownloadProgressChanged += (sender, e) =>
                {
                    this.Invoke((MethodInvoker)delegate {label12.Text = ("Gereksinimler indiriliyor. (windowsdesktop-runtime-6.0.20-win-x86.exe %" + e.ProgressPercentage.ToString() + " )"); });
                };
                client.DownloadFileCompleted += (sender, e) =>
                {
                    ifAvaiableInstallDotnet("windowsdesktop-runtime-6.0.20-win-x86.exe");
                };
                client.DownloadFileAsync(dotnet_x86, "windowsdesktop-runtime-6.0.20-win-x86.exe");
            }*/
        }
        private void ifAvaiableInstallDotnet(string name)
        {
            try
            {
                Thread.Sleep(2000);
                using (var mutex = Mutex.OpenExisting(@"Global\_MSIExecute"))
                {
                    ifAvaiableInstallDotnet(name);
                }
            }
            catch (Exception)
            {
                // Mutex not found; MSI isn't running
                try
                {
                    Process p = new Process();
                    p.StartInfo.FileName = startupPath + name;
                    p.StartInfo.Arguments = "/install /quiet /norestart";
                    p.StartInfo.UseShellExecute = false;
                    p.StartInfo.RedirectStandardOutput = false;
                    p.StartInfo.RedirectStandardError = false;
                    p.StartInfo.CreateNoWindow = true;
                    p.Start();
                    p.WaitForExit();
                    if (name== "windowsdesktop-runtime-6.0.20-win-x86.exe")
                        label12.Text="Gereksinimleri yükleme işlemi tamamlandı!";
                }
                catch (Exception) { Thread.Sleep(1000); }
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
                setDNSServers();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
                setDoH();
        }

        private void CMD(string Command)
        {
            Thread cmdBackground = new Thread(() => CMDelagate(Command));
            cmdBackground.IsBackground = true;
            cmdBackground.Start();
        }
        private void CMDelagate(string Command)
        {
            try
            {
                Process p = new Process();
                p.StartInfo.FileName = "CMD.EXE";
                p.StartInfo.Arguments = Command;
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.RedirectStandardOutput = false;
                p.StartInfo.RedirectStandardError = false;
                p.StartInfo.CreateNoWindow = true;
                p.Start();
                p.WaitForExit();
            }
            catch (Exception er) { MessageBox.Show(er.ToString()); }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Nyanet_exe: "+Nyanet_exe+"\nNyanetServiceFramework_exe: "+ NyanetServiceFramework_exe+ "\nWinDivert_dll: "+ WinDivert_dll+ "\nWinDivert64_sys: "+ WinDivert64_sys+ "\nWinDivert32_sys: "+ WinDivert32_sys, "MD5 Hash");
        }
        private void setDNSValues()
        {
            if (comboBox2.SelectedIndex ==0) //Cloudflare
            {
                dnsv4_1 = "1.1.1.1";
                dnsv4_2 = "1.0.0.1";
                dnsv6_1 = "2606:4700:4700::1111";
                dnsv6_2 = "2606:4700:4700::1001";
                httpsTemplate = "https://cloudflare-dns.com/dns-query";
            }
            else if (comboBox2.SelectedIndex == 1)//Google
            {
                dnsv4_1 = "8.8.8.8";
                dnsv4_2 = "8.8.4.4";
                dnsv6_1 = "2001:4860:4860::8888";
                dnsv6_2 = "2001:4860:4860::8844";
                httpsTemplate = "https://dns.google/dns-query";
            }
            else if (comboBox2.SelectedIndex == 3)//Custom
            { } //Do nothing. This values should be set by Form2 => private void button1_Click(object sender, EventArgs e)
        }
    }
}
