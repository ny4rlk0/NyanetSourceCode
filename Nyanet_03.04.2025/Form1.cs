using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
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
using System.Net.NetworkInformation;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Text.RegularExpressions;
using System.Collections;
using System.IO.Compression;
using IWshRuntimeLibrary;
using System.Runtime.Remoting.Contexts;
using System.Diagnostics.Eventing.Reader;
using System.Runtime.Remoting.Messaging;
using System.Runtime.CompilerServices;
using System.Net.Sockets;

namespace Nyanet
{
    public partial class Form1 : Form
    {
        //TO DO Write Seperate Nyanet Auto Updater Program to Ship With Same Exe Sometime, Tomorrow? Next year? Maybe? LoL
        //LoL This is second time i am doing this.
        //Last time i wrote the code to auto update Defender detected this mess of a code as virus so not so sure about adding it or not!
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///                                                                                                                                          ///
        ///                                                                                                                                          ///
        ///                  N Y 4 R L K 0    03.04.2025 09:21                                                                                       ///
        ///                                                                                                                                          ///
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /*
        ⠋⠌⠁⠃⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠄⠠⠀⠄⠤⠐⡀⠄⠠⠀⢀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
        ⣁⠠⢀⢀⠀⢀⠠⠀⠀⠠⠀⠀⡀⠠⠀⠀⠠⠀⢀⠀⠀⠀⠀⡀⠀⠄⠠⠀⠀⠤⠀⠄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠄⠀⠀⠀⠀⠀⠀⠀⠀⠄⠀⡠⠀⠀⡠⠀⡠⠐⢌⠠⠄⡔⠠⢔⠠⠤⠡⠆⢠⠀⠄⠀⠀⠀⡀⠀⠀⡀⠠⠀⠀⢀⠀⢀⠠⠀⠀⠄⠠⠀⡀⠀⠠⠀⠀⠀⠀⠀⠠⠀⢀⠀⠀⡀⠀⠠⠀⠀⠠⠀⠀⡀⢀⠀⠄⠀⠀⠄⠀⡀⢀⠀⠠⠀⢀⠠⠀⠀⡀⢀⠀⡀⠠⠀⠀⠄
        ⣀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠄⠀⠀⠀⠀⠀⠀⠄⠀⠀⠀⣀⡀⠀⠀⢂⠠⠈⡀⠠⠀⠀⠀⠀⠀⠠⠐⠀⠂⠠⠐⠀⠄⠀⠀⠠⠀⢀⢂⠀⢊⠀⠄⢀⠑⠐⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠠⠀⠀⠀⡀⠐⠀⢀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
        ⠤⠀⠀⠂⠀⡁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⡀⠈⠀⠀⣀⣤⣀⠀⠀⠀⠀⣔⣿⣿⡿⠿⣶⣄⡀⠅⡐⢀⡀⠀⠀⡀⠀⠁⢌⠈⡄⢁⠂⠂⢌⠠⡉⢀⠁⠤⡈⡈⢀⠂⠀⠀⠀⠀⢀⠈⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠐⠈⡀⠀⠈⠀⠌⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
        ⠢⠐⠀⢀⠀⠄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⠀⠀⠀⠠⠀⠁⠠⠀⠄⠀⠀⠁⢼⡿⠉⠙⠱⠀⠀⢰⣿⢿⡁⠀⠀⠀⠈⠻⣆⠐⠀⠄⡁⢂⠀⠀⠀⠀⠠⢀⠂⠠⠌⢠⠐⠄⠂⠍⡠⠐⡀⠀⠀⠀⠀⠐⠀⠀⠀⠄⠈⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⡀⠠⠐⠀⠠⢀⠡⠉⠌⠠⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
        ⡑⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠐⠀⠀⠀⢀⣤⠀⠈⢀⢀⠘⣿⣄⠀⠀⠀⡀⠹⣿⣀⠀⢀⠀⠀⠀⠀⢻⣇⠈⡀⠠⠀⠂⡀⠂⠀⠁⠂⠌⡐⠂⠄⠂⡌⠑⠠⠀⢀⠠⠀⠀⠀⠀⠀⠀⡐⠈⠀⢀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠠⠐⠀⢂⠔⠁⠂⠄⠁⠄⡈⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
        ⢌⠀⠐⠀⠀⡁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠀⠀⠐⠀⠀⠈⢷⣄⠘⣿⡉⠀⠈⠻⣷⣄⡀⢀⣤⣤⣬⣤⣄⣀⣀⠀⠀⠈⣿⡆⠀⠀⠁⠔⠀⠀⠀⠠⠁⢂⠀⠂⠌⠑⣀⢉⠐⣁⠠⢀⠀⠂⠀⢀⠀⡀⢠⠂⠁⡀⠀⠂⠀⠀⠀⠀⠀⠀⠀⠀⡀⠠⠀⠋⣀⠂⢉⠂⠐⡀⠁⠀⠈⠀⠀⠉⠐⠠⢀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
        ⠢⠀⠀⠈⠀⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣾⣰⡋⠁⠀⠀⠉⠓⠮⢿⣦⣤⣤⣌⣛⣿⣿⣥⣄⣀⣀⣀⡈⠉⠻⣦⣤⣿⣯⠀⠄⠀⠀⠈⢀⠀⠄⡁⠂⢀⠀⠌⢠⠀⠄⡁⠠⠐⠄⡂⠡⢀⠄⢂⠀⢂⠌⢢⠠⠑⠠⢄⡈⠀⠀⢀⠠⠐⢀⠀⠠⠒⡐⢠⠉⠠⠀⠂⠠⠀⠀⠀⠀⠀⠐⠈⠀⠀⠀⠁⠈⠀⡀⠀⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
        ⡑⠀⠀⠁⠀⠄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣆⠙⢷⣷⣤⣀⠀⠀⠐⠂⠀⣉⣛⣻⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⢿⣶⣄⢹⣿⣯⠀⠀⠀⠀⠀⠂⠐⠠⠀⠂⠀⠄⠈⠄⠂⠐⠀⠐⠈⠄⠐⡐⠀⢂⠂⠌⠄⠂⠡⠄⠁⠂⡀⠈⠢⢉⠄⠤⠐⠠⠤⣋⠐⢣⡀⠐⠠⠀⡁⠀⠐⠀⢀⠀⠄⠀⠀⠀⠀⠀⠀⠀⠄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
        ⣌⠀⠀⠐⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠛⢳⣶⣮⣽⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣻⣿⣷⣿⣿⣿⣿⡇⠈⠀⠀⠀⠐⡀⠁⢀⠐⠀⠂⠈⡀⠈⠀⡈⠀⠀⠈⢀⠀⢣⡄⢡⢈⠐⡉⠂⡌⢑⡀⠀⠐⡀⢀⢣⠀⡌⠀⠀⠀⠙⠂⣤⠁⢒⢠⠈⢀⠀⡄⠀⠀⠀⠀⠀⠀⠀⠀⠈⠀⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
        ⢮⠀⠀⠆⠀⡃⠀⠀⠀⠀⠀⠀⠀⠀⣀⣴⣶⣷⣶⣤⣄⣀⠉⢻⣿⣯⣍⣉⣽⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣃⠀⠀⠀⠀⠀⠁⠃⢨⠀⠀⠃⠰⡁⢣⠀⢁⢠⠰⠀⢘⡜⠀⢠⠰⠈⡀⠁⠀⠘⡌⡁⠰⠀⠁⠘⠀⡛⠀⠀⠀⡄⠀⠰⡈⡞⣬⡳⠶⢨⠃⢠⠀⡄⠀⠀⠀⠀⠀⠀⠀⠀⠁⠀⠃⡘⠀⢠⠀⢠⠀⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
        ⠣⠀⠀⢀⠀⡁⠀⠀⠀⠀⠀⠀⠀⣘⣿⣿⣧⣄⡉⠙⠻⣿⣿⣧⣽⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣧⡀⠀⠀⠀⠀⠄⠀⠠⠀⠀⠀⠁⡀⢀⠈⠠⠀⠛⠈⠀⠀⠀⠀⠀⡁⠀⠠⠀⠀⡁⠀⠀⠀⠀⠀⠁⠀⠀⠀⠀⠠⠀⣅⠣⠄⡅⢃⠏⢀⡠⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠁⠀⠀⠀⠀⠀⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
        ⠱⠀⠈⠀⠀⠄⠀⠀⠀⠀⠀⠀⠸⠟⢟⡿⢿⣿⣿⣶⣾⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡟⢷⣄⠐⠀⠀⠀⠀⠠⠀⠀⠀⠀⣠⣤⡀⠂⠄⠀⠀⠀⠀⠀⠀⢀⠀⠈⠐⠂⠄⡄⠄⠂⠄⠠⠀⠀⠀⠀⠠⠀⠐⠠⢀⠐⠠⠄⠂⠠⠀⠄⠠⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
        ⡑⠀⠀⠐⠀⠂⠀⠀⠀⠀⠀⠀⠀⠀⠈⠙⠛⠿⠟⠻⠻⠿⢿⣷⣤⣤⣥⣽⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⢿⣿⣿⣿⣿⡄⢻⡄⠀⠀⣀⣶⣴⠀⢁⡈⣀⣿⣿⣧⠀⣁⣁⡀⣀⣀⣤⣤⣤⣤⡄⠂⠈⠀⠀⠈⠑⠂⠁⠂⢀⠀⠀⠐⠀⢁⡀⠠⠀⠔⠀⠊⠀⠀⠀⠐⠀⠀⠐⡀⠂⠠⠀⠐⠀⠂⠐⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
        ⢌⠀⠐⠀⠀⡁⠀⠀⠀⠀⠀⠀⠀⠀⠀⢤⣶⡾⠷⠶⢶⣶⣤⣤⣌⣽⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⢿⣥⣿⢿⣿⣿⢹⢇⡼⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣷⣿⡇⠀⣀⠀⠀⠀⠀⠀⠀⡀⠀⠀⠀⢀⠈⠀⠠⠁⠈⠀⠀⠁⠀⠀⠀⠀⠀⠀⠀⠀⠠⠁⠀⢁⠀⡀⠀⠀⠀⠄⠁⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
        ⠢⠀⢀⠠⠀⠄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠘⠳⠀⠀⠀⠸⣤⣴⡾⢿⣛⣛⣻⣿⢶⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣧⣉⡽⢃⣨⣿⣗⠞⠉⠀⠉⠉⢉⣽⣿⣿⠀⣻⣿⣏⡉⠫⠉⠀⣿⣿⡇⠀⢈⣍⣍⣍⢉⣁⣀⣀⣀⣀⣀⣠⣀⣀⣀⣀⣤⣁⣀⣀⣀⣄⣀⣀⣀⣀⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
        ⡑⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠀⠀⠀⠀⣾⡿⣻⠿⠛⢋⣹⡿⠿⠛⠻⢟⣷⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣶⣴⣿⣿⣿⣿⣶⣶⣶⣶⣾⣿⣿⣶⣶⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣷⣤⣤⣤⣦⣤⣦⣶⣴⣦⣶⣴⣦⣶⣶⣶⣶⣶⣶⣶⣶⣶⣶⣶⣶⣶⣶⣶⣿⡿⣿⣿⢿⣷⣶⡀⠂⠀⠀⠀⠀⠀⠀⠀⠀
        ⢌⠀⠀⠂⠀⡁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⣿⠀⠻⠄⣤⡟⠉⠀⠀⠀⣰⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡿⠛⠛⠛⢛⠛⠛⠛⠛⠛⠛⠛⠛⠛⠛⠛⠛⠛⠛⠛⠛⠛⠛⠛⠛⠛⠛⠻⠿⠿⠿⠿⠿⠿⠛⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
        ⠢⠀⠀⠐⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠉⠀⠀⣸⣿⣀⡀⠐⠀⣰⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣟⣿⡟⢻⣿⣿⣿⢿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⢿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣷⡄⠀⠀⠀⠀⠀⠀⠀⠉⠈⠈⠁⠈⠁⠉⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
        ⡑⠀⠠⠀⠀⠂⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠐⠀⠀⠀⠀⠻⣿⠾⠛⠀⢀⣿⣿⣷⣿⣿⣿⣿⣿⣿⣿⣿⣿⣾⣷⣼⣿⣿⣿⣧⠈⠹⡻⠿⣿⣟⡻⣟⣛⣻⣟⠿⣿⣿⣿⣿⣿⣿⣿⣷⣿⣿⣿⣿⣿⢿⡞⠹⢿⠿⣿⠿⠿⠿⠿⠿⠻⠟⠛⠛⠛⠙⠿⠟⠁⠙⠆⠁⠀⠀⠀⠀⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠠⠐⠈⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
        ⢌⠀⠀⠠⠀⠂⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⡀⠈⠀⡀⠀⠈⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣷⣟⣿⣿⣿⣿⢹⢿⣇⡴⢷⣾⣻⣥⣿⡝⣻⣟⣻⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣟⠀⠀⠀⣴⠏⠀⡀⠀⠀⢀⠀⠠⢈⠌⡁⠉⠤⠀⠁⠀⠀⠀⠀⠈⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⡀⠀⠀⠊⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
        ⢀⠀⡀⠀⠀⡁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⡀⠀⠀⠀⢺⣿⡆⠀⠀⣀⣰⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣞⣽⣿⣿⣿⣯⠿⣿⣹⣿⣼⣿⢷⣿⢯⣭⠷⣿⣿⠿⠿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⠃⠀⢠⣾⠏⠀⠀⣀⣔⠈⠤⢡⡍⢠⠐⠀⠢⠄⡁⢐⠄⡀⢀⡀⠠⢀⠀⢀⠀⠀⠀⠀⡂⢈⠤⠀⠆⡒⠂⠄⠀⠠⠀⠀⢀⠠⡐⢈⠡⠈⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
        ⠀⠀⡀⠀⠀⠄⠀⠀⠀⠀⠀⠀⠀⠀⠠⠀⠹⠿⣷⠀⠀⠀⠛⠃⣤⠀⠹⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣻⣿⡿⠟⠻⣿⣿⣿⡿⠋⠔⠠⠄⠄⠠⣿⡿⠿⠿⠟⠛⠋⢋⠉⡉⢀⣰⡿⠁⠄⢐⣶⣿⠟⠁⠁⠄⠐⠢⠈⠌⣁⠐⡀⢂⠌⠄⠀⠀⣀⠖⠊⠀⠀⠀⠀⠀⠖⠁⠀⠒⠠⠈⠑⠬⢁⡂⡐⠌⠄⠐⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
        ⠀⠀⢐⡠⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⡜⠻⣥⡀⠀⠀⠀⠀⠤⣬⣦⢠⣬⣿⣝⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡿⡟⠁⠀⠒⠀⠀⠉⣰⡀⠁⢈⣀⠌⠘⡀⣀⠐⠂⢉⠠⡈⠀⠂⠐⢀⣼⠟⠀⢀⣾⣿⠟⠁⠀⠀⠀⠀⠀⠀⠁⠐⠀⠠⠀⠀⠀⠀⠠⠁⠀⣀⠀⡀⠂⢁⠉⠀⠀⠈⠀⠀⠐⠀⠀⠀⠀⠀⠐⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
        ⠀⠈⠁⠀⠀⠄⠈⠀⠀⠀⠀⠀⠘⠓⠀⠛⠀⠀⠀⠀⣿⡇⢈⠄⡈⠉⢿⠰⢿⣿⣷⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡯⢍⣿⣷⣶⣾⣿⣾⣶⣶⣆⠿⠇⠀⠄⣀⠔⠂⠔⡠⠉⠠⢀⡀⠤⠀⣖⣤⡿⠃⡀⠰⡿⠛⠁⠀⠀⠀⠀⠀⠀⠀⠀⡀⠀⠀⠀⠀⠀⠀⠀⡀⠐⠀⣠⠁⢄⠨⠀⠆⠈⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
        ⠀⠀⠀⠀⠀⠄⠀⠀⠀⠀⠀⠳⣄⡀⠀⠀⠀⠀⠀⣠⠏⢡⢀⠒⠄⠢⠀⠀⢈⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣧⣶⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣷⠀⠒⠰⢀⠊⡉⠤⠀⠺⢶⡀⠅⢂⣵⡾⠋⢀⠤⢠⣐⠢⣀⡠⠔⠒⠒⠢⣀⠠⠀⠄⠐⠂⠀⠈⠀⠀⠀⡀⠀⠀⠀⠀⠆⡨⠄⠃⠂⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
        ⡀⠀⠀⠀⠀⠂⠀⠀⠀⠀⠀⠀⠀⠁⠤⢀⡤⠚⡍⠀⠨⠄⣀⣤⣶⣶⣶⣶⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡏⢭⡁⣄⠈⠻⣿⠇⣠⠘⡀⠀⠐⠈⡀⠂⣀⣤⣾⡿⡋⢀⢳⠌⣀⢃⠰⠌⣩⠐⠂⡉⠉⠒⡀⠑⠀⠈⠀⠐⠀⠀⠀⠄⡠⠀⠄⠀⡁⠔⠉⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
        ⢌⠀⠐⠀⠀⡁⠀⠀⠀⠀⠀⠀⠀⠀⠐⠚⠀⠆⠐⠂⠐⠀⢻⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⢺⡥⣓⠄⠢⡅⠹⡻⡟⠠⠄⠅⠒⣠⣴⢾⣯⠗⠋⣀⠉⢠⠞⣌⠢⡨⠗⢘⡁⢈⢁⡠⢁⠀⠀⠁⠀⠀⢀⡀⠈⠁⠈⣀⠑⠈⡌⠁⠆⣈⠀⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
        ⠢⠀⠀⠀⠀⡄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠰⣶⣶⣶⣶⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡷⣯⣷⣔⣈⡄⣑⣭⡶⣤⣾⣻⠽⠞⠉⠀⠉⢀⢀⠰⢉⠶⠌⡖⠁⠤⠈⣤⠆⠁⡀⠳⠈⠀⡁⠠⠈⠠⢀⠀⠔⠀⠀⠀⠀⢀⠉⢀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
        ⡑⠀⠀⠄⠀⡀⠐⠀⠀⠀⠸⣶⡆⠀⠀⢀⣤⣾⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⢏⡿⠶⣝⣳⣿⣷⡟⠉⢀⠘⢯⠀⠐⠀⠀⠀⡃⢁⠘⢀⣾⠐⡪⠈⢒⠄⠄⠢⣈⡘⠁⠂⠌⡀⠀⠂⠴⠀⢠⠒⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
        ⠌⠀⠀⠀⠀⠄⠀⠄⠀⠉⠀⠀⠃⠐⠀⠀⠘⣿⣿⣿⣿⣿⣿⣿⡿⣹⢿⣿⣿⣿⣿⣿⣿⣷⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣾⣿⣾⡿⢻⡏⢩⢛⣷⡀⠈⠒⣻⡀⠁⣀⠀⠀⡂⡁⠀⠘⡟⠁⠡⢩⢀⠋⢀⡁⡈⠘⠌⠇⠀⠐⠀⠐⠈⢂⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠄⠀⠀⠈⠀⠀⠀⠆⠀⠐⠀⠀⠀⠈⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
        ⠨⠀⢀⠀⠈⠀⠂⠀⠀⠂⠀⠠⠁⠀⠠⡈⠀⠘⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⢏⣽⣿⣿⣿⡿⠂⠙⢦⡘⢻⣽⣶⣿⣿⣷⡀⠠⠀⢂⠈⢁⣠⣌⢱⡄⢐⠣⡈⠄⣵⡀⡈⠔⠐⠄⠁⠀⠄⠠⠁⠂⠀⠀⠀⢀⠀⠁⠀⠀⠀⠀⠀⠀⠀⠀⢀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
        ⡳⠀⢀⠆⠘⡄⠀⠀⡄⢀⠘⠀⠀⠀⠆⢠⣴⣤⠸⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡿⡇⡄⠀⠀⠃⢷⣾⣿⣿⣿⣿⣿⣿⣄⠀⠆⠀⣰⢟⣀⠶⠀⣤⡀⢇⣤⢿⡆⡀⣸⡄⠀⡄⠀⢀⠰⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢠⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⡄⠀⠀⡄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
        ⠱⠀⢨⠀⠀⠆⠀⠀⠆⢨⠀⠘⠀⠆⡴⠸⣿⣵⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡿⠿⠟⠃⢠⡅⣤⠃⠰⠀⠙⣿⣿⣿⣿⣿⣿⣿⡆⠘⠸⠃⠛⠟⠀⡟⢻⣽⣿⠟⠈⣤⢡⡟⠃⠀⡜⠰⠸⢧⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢠⠶⠀⠘⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠆⠀⠀⠆⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
        ⠈⢀⠠⠀⠈⠀⠒⠀⠀⠀⠀⠂⡃⠈⠔⠄⡩⢁⡙⢿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡏⠉⣉⣲⠐⠄⠀⡄⢘⢈⠒⡨⢀⡘⠂⡀⢁⠀⠹⣿⣿⣿⣿⣿⣷⡁⠰⣆⠀⠀⠩⢉⢁⢘⠛⠊⡁⠈⠈⠅⢈⢃⠀⠐⠰⠸⡓⢲⡀⠀⠀⠀⠀⠀⢀⠐⠁⠈⡀⢂⠀⡠⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
        ⠈⠀⡀⠐⠀⢁⣀⠀⡀⢈⠀⠀⠤⠉⠄⠣⠜⢨⡐⢀⢻⣿⣿⣻⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⠿⠛⠁⠰⠸⠂⠡⣨⢃⠐⠆⣂⢡⠐⡄⠩⠜⡰⢀⠌⡅⢈⠻⣿⣿⣿⣿⣷⡀⠤⠤⠀⢂⠠⠄⡀⢡⠈⣀⣾⠃⠀⣟⢈⠀⢡⢈⡁⢣⠀⢇⠀⠀⠀⠀⢀⠀⡀⢈⡐⠀⠄⠈⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
        ⠀⠀⢀⠔⢉⠔⢀⠒⠤⢀⠡⠄⢃⠪⠌⡡⢚⢠⣈⠄⣾⣿⣿⢻⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡏⠄⠐⢀⠑⡄⢊⡀⢓⡶⢯⠐⠒⠀⠤⠠⣌⠉⠦⠰⡀⢦⡈⠔⢢⠘⢻⣿⣿⣿⣷⡀⠐⠐⠂⠄⢂⠀⠴⣶⠋⣁⢈⠀⣸⢎⠠⣿⡖⢼⡅⢳⡀⢀⠀⠀⠀⡈⠀⠠⠜⠇⠈⠠⠀⡀⠄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
        ⠀⡀⠤⠘⢠⠊⢀⠊⡐⠂⠙⠄⠦⡁⠒⠰⠀⠄⡑⢸⣿⣿⣷⣤⡙⠼⢭⢩⠵⣍⠟⣭⣻⣿⣿⡿⣠⠐⡈⢄⣧⢹⡀⠂⣈⡙⠀⡨⠑⡍⡒⠡⢄⠙⡇⡑⢢⠐⠡⡘⢈⠢⢁⠹⣿⣿⣿⣷⣄⡀⠀⠁⠀⠄⠀⢏⣉⢻⣹⡆⣬⣷⣦⢏⢻⡌⠾⣾⡇⡀⢀⠀⠁⠀⠀⢁⠄⢀⡂⠁⣀⠀⠄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
        ⠉⠀⢄⠉⡂⠌⢢⠀⢂⠌⠁⡌⠠⢐⠉⠠⠉⢡⠀⠀⢿⣿⣿⣿⣿⣿⣶⣧⣾⣴⣯⣾⣿⣿⠏⣠⣿⢷⣈⡼⠿⡁⢣⢁⣬⡁⡖⢁⠲⠇⡐⢃⣼⡇⢰⠠⠡⢌⡑⢠⠈⠩⠑⢄⠈⣿⣿⣿⣿⣦⡢⢀⠂⠉⠷⣽⣿⣰⣮⡹⣦⠘⢷⣯⣰⣿⡄⢻⢷⢻⠀⣧⠀⢀⠀⠀⡀⠄⠀⠄⡈⠆⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
        ⠀⠈⡄⠠⢉⠔⡠⠜⠠⢌⠂⠤⢁⠄⠂⡁⠡⠀⠀⠀⠀⡇⣬⢛⠻⠿⣿⣿⣿⡿⣿⣷⡿⡟⣶⣹⢏⣼⣿⢃⡒⡒⢯⢠⢑⡀⠜⡤⣨⣁⠆⢟⡁⢺⠻⡀⠇⠤⠐⠄⠂⠅⠣⠐⠆⡈⢿⣿⣿⣿⣿⡂⠠⣀⢴⣖⢹⠽⠋⢿⣇⣷⡞⢿⣳⠌⠹⠆⡈⢸⡜⢙⠀⠈⠀⠀⠙⢁⠀⣤⠀⢌⠢⣀⡄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
        ⠀⠂⡄⢁⠢⠁⠴⠈⠖⠢⠌⠴⠠⠐⠦⠐⠀⠒⠀⠂⢸⢃⠣⣌⡃⡒⠐⣠⣿⣿⣿⣟⣻⣯⣭⢊⣻⣯⣦⠒⢇⡑⢺⡤⢦⣅⡎⣜⡳⡉⡷⢷⡿⢃⣒⣃⣒⣒⣁⣊⣑⢂⡒⣈⢄⡠⢙⣿⣿⣿⣿⣷⣜⢿⠿⣿⠆⣀⢊⢡⣿⣾⣿⢜⣫⠉⣼⣮⣿⡈⠹⢾⡄⢁⢀⡀⣀⠀⣶⣧⣧⡈⠐⠀⠇⢀⠀⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
        ⣀⣀⣀⣀⣈⣉⣈⣩⣥⣦⣤⢦⢭⣤⢭⣉⣏⡭⣭⣡⣬⣧⣓⡌⡃⢌⣰⣿⡿⠿⢿⣺⣿⣯⣿⣧⣼⡿⣝⡟⣈⣤⢋⠗⣠⣤⡴⣼⠷⣯⢿⠧⡞⣧⢥⢦⡴⣌⣰⢤⡬⠄⣁⡠⠂⠂⢉⣿⣿⣿⣿⣿⣿⣆⡯⡽⠛⣁⠤⢤⢽⠾⣿⣯⣿⣿⣿⣿⡛⡏⠷⣽⠃⡒⠀⠀⡀⠰⡼⠿⠿⠿⠿⠶⣦⠤⠀⢀⠠⠈⠀⠁⠄⠠⠀⠄⠀⠀⠀⠄⠀⠀⠂⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
        ⢉⢐⣢⣭⣫⣛⣛⣭⣭⣽⡼⡭⠾⠤⠷⠼⣴⣎⣳⢛⡼⠮⠿⢟⡛⢟⡳⠶⠿⣿⡿⠿⠻⠿⠷⡿⢻⡿⣧⠾⠿⣐⠭⠧⠷⢆⡓⠮⡝⣬⣩⣚⠱⣌⣋⡭⣖⡥⣞⣤⣭⡽⣤⢦⡵⣶⣮⣿⣿⣿⣿⣿⣿⣿⠾⠝⠛⠃⢋⣉⣩⣿⣿⣿⣿⣿⣿⡏⣿⣥⣶⣡⣷⢶⣶⣤⣤⣤⣤⣤⣤⣤⣤⣤⣤⣤⣤⣤⣤⣀⣈⡀⣀⣀⣀⣀⣀⣀⣀⡀⣀⠀⣀⢀⡀⣁⢀⡀⢈⡀⣁⡀⣀⡀⠐⠀⠂⠀⠂⠀⠀⠀
        ⠸⠉⢵⣶⣽⠄⢃⠢⢴⣄⣐⣢⣡⣉⣜⣠⣆⠰⠌⠥⢲⣉⣱⢨⡐⠡⠦⠙⠒⠠⠦⠭⠭⠴⠣⠼⠔⣒⠒⢓⣒⠓⡨⢉⣍⣆⣜⠭⠵⠦⠧⠭⠿⠐⠮⣉⣰⢈⠩⡡⢍⡱⠭⢭⠓⡳⠮⠽⠯⠘⡙⢉⣉⣀⣀⣌⡙⢫⠝⣻⣻⢟⡿⣛⣿⡻⢯⣽⣯⣷⣚⣻⣷⣚⣶⣾⠶⠷⢬⣍⠡⠦⠖⠒⢈⣀⣉⣉⣉⣉⣉⣉⣉⡉⢉⠉⡁⠀⠀⠉⠀⠉⠈⠀⠉⠀⠁⠈⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠂⠈⠀
         */
        #region Fix having no way to drag window because of hiding top bar
        ////////////////////////////////////////////////////////////////
        /// Fix to drag form without titlebar///////////////////////////
        private const int WM_NCHITTEST = 0x84;
        private const int HTCLIENT = 0x1;
        private const int HTCAPTION = 0x2;
        protected override void WndProc(ref Message message)
        {
            base.WndProc(ref message);
            if (message.Msg == WM_NCHITTEST && (int)message.Result == HTCLIENT)
                message.Result = (IntPtr)HTCAPTION;
        }
        #endregion
        #region Change Form Main UI Colors Here
        ////////////////////////////////////////////////////////////////
        ///        Change Combo Box colors here
        Color
              comboBoxTextColor = Color.Indigo,
              comboBoxBackgroundColor= Color.FromArgb(255, 220, 255),///soft Pink
              comboBoxSelectionColor= Color.Gold;
        ///////////////////////////////////////////////////////////////
        ///         Change Group Box Border Color Here
        Color groupBoxBorderColor = Color.Gold;
        //////////////////////////////////////////////////////////////
        #endregion
        #region Declare and Set Global Variables / Lists
        string sysFolder = Environment.GetFolderPath(Environment.SpecialFolder.System);
        string startupPath = Application.StartupPath + "\\";
        bool appPathGet = false, runnedOnce= false;
        string appExactPath = "";// System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName;
        MenuItem Open;
        MenuItem Exit;
        string sysLang = CultureInfo.CurrentCulture.TwoLetterISOLanguageName;
        string startup_path2 = Application.StartupPath;
        static string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\";
        string userStartupProgramsPath = Path.Combine(appDataPath, @"Microsoft\Windows\Start Menu\Programs\Startup");
        public Process p;
        public static string dnsv4_1 = "", dnsv4_2 = "", dnsv6_1 = "", dnsv6_2 = "", httpsTemplate = "";
        public static string Cdnsv4_1 = "", Cdnsv4_2 = "", Cdnsv6_1 = "", Cdnsv6_2 = "", ChttpsTemplate = "";
        Uri dotnet_x64 = new Uri("https://github.com/ny4rlk0/Nyanet/releases/download/Gereksinimler/windowsdesktop-runtime-6.0.20-win-x64.exe");
        Uri dotnet_x86 = new Uri("https://github.com/ny4rlk0/Nyanet/releases/download/Gereksinimler/windowsdesktop-runtime-6.0.20-win-x86.exe");
        Uri softwareMissing = new Uri("https://github.com/ny4rlk0/Nyanet/releases/download/GelistiriciSurumu/GelistiriciSurumu.zip");
        List<string> SortCMDCommands = new List<string>();
        List<string> NetworkInterfaceNames = new List<string>();
        List<string> NetworkInterfacesGUIDS = new List<string>();
        List<string> WindowsSettingsNetAdapterGUIDList = new List<string>();
        List<string> NetAdapterList = new List<string>();
        List<string> DNSAddr = new List<string>();
        bool CMDBusy = false;
        string CMDOutput = "", CMDError = "", CMDelagateReturnOutputText = "";
        string startup_path = Application.StartupPath + "\\";
        bool getDNSRunning = false;
        bool lang = true; //false=english
        #endregion
        #region Custom Code to Edit UI Elements On The Go
        private void DrawGroupBox(GroupBox box, Graphics g, Color borderColor)
        {
            if (box != null)
            {
                //Brush textBrush = new SolidBrush(textColor);
                Brush borderBrush = new SolidBrush(borderColor);
                Pen borderPen = new Pen(borderBrush);
                SizeF strSize = g.MeasureString(box.Text, box.Font);
                Rectangle rect = new Rectangle(box.ClientRectangle.X,
                                               box.ClientRectangle.Y + (int)(strSize.Height / 2)-1,
                                               box.ClientRectangle.Width -1,
                                               box.ClientRectangle.Height - (int)(strSize.Height / 2)-1 );
                // Clear text and border
                //g.Clear(Color.Transparent);

                // Draw text
                //g.DrawString(box.Text, box.Font, textBrush, box.Padding.Left, 0);

                // Drawing Border
                //Left
                g.DrawLine(borderPen, rect.Location, new Point(rect.X, rect.Y + rect.Height));
                //Right
                g.DrawLine(borderPen, new Point(rect.X + rect.Width, rect.Y), new Point(rect.X + rect.Width, rect.Y + rect.Height));
                //Bottom
                g.DrawLine(borderPen, new Point(rect.X, rect.Y + rect.Height), new Point(rect.X + rect.Width, rect.Y + rect.Height));
                //Top1
                g.DrawLine(borderPen, new Point(rect.X, rect.Y), new Point(rect.X + box.Padding.Left, rect.Y));
                //Top2
                g.DrawLine(borderPen, new Point(rect.X + box.Padding.Left + (int)(strSize.Width), rect.Y), new Point(rect.X + rect.Width, rect.Y));
            }
        }
        private void groupBox2_Paint(object sender, PaintEventArgs e)//Group Box Paint Item Event
        {
            GroupBox box = sender as GroupBox;
            DrawGroupBox(box, e.Graphics, groupBoxBorderColor);
        }
        private void groupBox1_Paint(object sender, PaintEventArgs e)
        {
            GroupBox box = sender as GroupBox;
            DrawGroupBox(box, e.Graphics, groupBoxBorderColor);
        }
        private void PaintBorderlessGroupBox(object sender, PaintEventArgs p)
        {
            groupBox1.Paint -= PaintBorderlessGroupBox;
            GroupBox box = (GroupBox)sender;
            p.Graphics.Clear(SystemColors.Control);
            p.Graphics.DrawString(box.Text, box.Font, Brushes.Gold, 0, 0);
        }
        private void comboBox2_DrawItem(object sender, DrawItemEventArgs e)//Combo Box Draw Item Event
        {
            modifyComboBoxColor(sender, e);
        }

        private void comboBox3_DrawItem(object sender, DrawItemEventArgs e)
        {
            modifyComboBoxColor(sender, e);
        }

        private void comboBox1_DrawItem(object sender, DrawItemEventArgs e)
        {
            modifyComboBoxColor(sender, e);
        }
        //Custom code to modify comboBox Colors
        private void modifyComboBoxColor(object sender, DrawItemEventArgs e)
        {
            var combo = sender as System.Windows.Forms.ComboBox;

            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
                e.Graphics.FillRectangle(new SolidBrush(comboBoxSelectionColor), e.Bounds);
            else e.Graphics.FillRectangle(new SolidBrush(comboBoxBackgroundColor), e.Bounds);

            e.Graphics.DrawString(combo.Items[e.Index].ToString(),
                                          e.Font,
                                          new SolidBrush(comboBoxTextColor),
                                          new Point(e.Bounds.X, e.Bounds.Y));
        }
        //////////////////////////////////////////////////
        #endregion
        public Form1()//This method will auto run without called!
        {
            AppDomain.CurrentDomain.ProcessExit += new EventHandler(OnProcessExit);
            #region logs
            writeLog("Program has been started!",true);
            writeLog("Nyanet Logger has been started!");
            writeLog("Checking Admin Access from OS!");
            #endregion
            #region Check Administrator Access
            checkAdminAccess();
            #endregion
            #region logs
            writeLog("Admin access has been Acquired!");
            writeLog("Beginning to Initializing Components!");
            #endregion
            InitializeComponent();
            #region UI Tweaks
            button1.FlatAppearance.MouseOverBackColor = button1.BackColor;
            button1.BackColorChanged += (s, e) => {
                button1.FlatAppearance.MouseOverBackColor = button1.BackColor;
            };
            button2.FlatAppearance.MouseOverBackColor = button2.BackColor;
            button2.BackColorChanged += (s, e) => {
                button2.FlatAppearance.MouseOverBackColor = button2.BackColor;
            };
            button4.FlatAppearance.MouseOverBackColor = button4.BackColor;
            button4.BackColorChanged += (s, e) => {
                button4.FlatAppearance.MouseOverBackColor = button4.BackColor;
            };
            button7.FlatAppearance.MouseOverBackColor = button7.BackColor;
            button7.BackColorChanged += (s, e) => {
                button7.FlatAppearance.MouseOverBackColor = button2.BackColor;
            };

            button5.FlatAppearance.MouseOverBackColor = button5.BackColor;
            button5.BackColorChanged += (s, e) => {
                button5.FlatAppearance.MouseOverBackColor = button2.BackColor;
            };
            button6.FlatAppearance.MouseOverBackColor = button6.BackColor;
            button6.BackColorChanged += (s, e) => {
                button6.FlatAppearance.MouseOverBackColor = button2.BackColor;
            };
            button5.FlatAppearance.CheckedBackColor = Color.Transparent; button5.FlatAppearance.MouseOverBackColor = Color.Transparent;
            button5.FlatAppearance.MouseOverBackColor = Color.Transparent; button5.FlatAppearance.CheckedBackColor = Color.Transparent; button5.BackColor = Color.Transparent;

            button6.FlatAppearance.CheckedBackColor = Color.Transparent; button6.FlatAppearance.MouseOverBackColor = Color.Transparent;
            button6.FlatAppearance.MouseOverBackColor = Color.Transparent; button6.FlatAppearance.CheckedBackColor = Color.Transparent; button6.BackColor = Color.Transparent;
            //checkBox2.FlatAppearance.MouseOverBackColor = Color.Black;

            checkBox2.BackColorChanged += (s, e) => {
                checkBox2.FlatAppearance.MouseOverBackColor = button7.BackColor;
            };
            checkBox2.MouseLeave += (s, e) => { checkBox2.FlatAppearance.CheckedBackColor = Color.Transparent; checkBox2.FlatAppearance.MouseOverBackColor = Color.Transparent; };
            checkBox2.MouseHover += (s, e) => { checkBox2.FlatAppearance.MouseOverBackColor = Color.Transparent; checkBox2.FlatAppearance.CheckedBackColor = Color.Transparent; checkBox2.BackColor = Color.Transparent; };
            checkBox2.FlatAppearance.CheckedBackColor = Color.Transparent; checkBox2.FlatAppearance.MouseOverBackColor = Color.Transparent;
            checkBox2.FlatAppearance.MouseOverBackColor = Color.Transparent; checkBox2.FlatAppearance.CheckedBackColor = Color.Transparent; checkBox2.BackColor = Color.Transparent;
            
            //checkBox1.MouseLeave += (s, e) => { checkBox1.FlatAppearance.CheckedBackColor = Color.Transparent; checkBox1.FlatAppearance.MouseOverBackColor = Color.Transparent; };
            //checkBox1.MouseHover += (s, e) => { checkBox1.FlatAppearance.MouseOverBackColor = Color.Transparent; checkBox1.FlatAppearance.CheckedBackColor = Color.Transparent; checkBox1.BackColor = Color.Transparent; };
            //checkBox1.FlatAppearance.CheckedBackColor = Color.Transparent; checkBox1.FlatAppearance.MouseOverBackColor = Color.Transparent;
            //checkBox1.FlatAppearance.MouseOverBackColor = Color.Transparent; checkBox1.FlatAppearance.CheckedBackColor = Color.Transparent; checkBox1.BackColor = Color.Transparent;
            
            checkBox5.MouseLeave += (s, e) => { checkBox5.FlatAppearance.CheckedBackColor = Color.Transparent; checkBox5.FlatAppearance.MouseOverBackColor = Color.Transparent; };
            checkBox5.MouseHover += (s, e) => { checkBox5.FlatAppearance.MouseOverBackColor = Color.Transparent; checkBox5.FlatAppearance.CheckedBackColor = Color.Transparent; checkBox5.BackColor = Color.Transparent; };
            checkBox5.FlatAppearance.CheckedBackColor = Color.Transparent; checkBox5.FlatAppearance.MouseOverBackColor = Color.Transparent;
            checkBox5.FlatAppearance.MouseOverBackColor = Color.Transparent; checkBox5.FlatAppearance.CheckedBackColor = Color.Transparent; checkBox5.BackColor = Color.Transparent;
            
            checkBox6.BackColorChanged += (s, e) => {
                checkBox6.FlatAppearance.MouseOverBackColor = button7.BackColor;
            };
            checkBox6.MouseLeave += (s, e) => { checkBox6.FlatAppearance.CheckedBackColor = Color.Transparent; checkBox6.FlatAppearance.MouseOverBackColor = Color.Transparent; };
            checkBox6.MouseHover += (s, e) => { checkBox6.FlatAppearance.MouseOverBackColor = Color.Transparent; checkBox6.FlatAppearance.CheckedBackColor = Color.Transparent; checkBox6.BackColor = Color.Transparent; };
            checkBox6.FlatAppearance.CheckedBackColor = Color.Transparent; checkBox6.FlatAppearance.MouseOverBackColor = Color.Transparent;
            checkBox6.FlatAppearance.MouseOverBackColor = Color.Transparent; checkBox6.FlatAppearance.CheckedBackColor = Color.Transparent; checkBox6.BackColor = Color.Transparent;

            checkBox7.FlatAppearance.MouseOverBackColor = button7.BackColor;
            checkBox7.BackColorChanged += (s, e) => {
                checkBox7.FlatAppearance.MouseOverBackColor = button7.BackColor;
            };
            checkBox7.MouseLeave += (s, e) => { checkBox7.FlatAppearance.CheckedBackColor = Color.Transparent; checkBox7.FlatAppearance.MouseOverBackColor = Color.Transparent; };
            checkBox7.MouseHover += (s, e) => { checkBox7.FlatAppearance.MouseOverBackColor = Color.Transparent; checkBox7.FlatAppearance.CheckedBackColor = Color.Transparent; checkBox7.BackColor = Color.Transparent; };
            checkBox7.FlatAppearance.CheckedBackColor = Color.Transparent; checkBox7.FlatAppearance.MouseOverBackColor = Color.Transparent;
            checkBox7.FlatAppearance.MouseOverBackColor = Color.Transparent; checkBox7.FlatAppearance.CheckedBackColor = Color.Transparent; checkBox7.BackColor = Color.Transparent;
            #endregion
        }
        private void button1_Click(object sender, EventArgs e)
        {
            #region Start Nyanet Service Framework Manually by Clicking Start Button
            writeLog("Start button clicked.");
            button1.Visible = false;
            button1.Enabled = false;
            button2.Enabled = true;
            button2.Visible = true;
            string ttl=numericUpDown1.Value.ToString();
            #region Save TTL to File
            this.Invoke((MethodInvoker)delegate {
                if (!System.IO.File.Exists("ttl"))
                    System.IO.File.Create(startupPath + "ttl").Dispose();
                System.IO.File.WriteAllText(startupPath + "ttl", ttl);
            });
            #endregion
            string ttl_opt, snusnu; //Magic key 5.12.2024
            if (checkBox4.Checked) ttl_opt = " --set-ttl " + ttl;
            else ttl_opt = "";
            if (checkBox7.Checked) snusnu = " -p -q -r -s -m -a";
            else snusnu = "";
            if (comboBox1.SelectedIndex == 0)
                nyanetServiceFramework("-1" + ttl_opt + snusnu, "start");//-n
            else if (comboBox1.SelectedIndex == 1)
                nyanetServiceFramework("-2" + ttl_opt + snusnu, "start");//-y
            else if (comboBox1.SelectedIndex == 2)
                nyanetServiceFramework("-3" + ttl_opt + snusnu, "start");//-a
            else if (comboBox1.SelectedIndex == 3)
                nyanetServiceFramework("-4" + ttl_opt + snusnu, "start");//-r
            else if (comboBox1.SelectedIndex == 4)
                nyanetServiceFramework("-9" + ttl_opt + snusnu, "start");//-l
            else if (comboBox1.SelectedIndex == 5)
                nyanetServiceFramework("-8" + ttl_opt + snusnu, "start");//-k
            else if (comboBox1.SelectedIndex == 6)
                nyanetServiceFramework(ttl_opt.TrimStart() + snusnu, "start");//-l
            else if (comboBox1.SelectedIndex == 7)
                nyanetServiceFramework("-5" + ttl_opt + snusnu, "start");//-l
            else if (comboBox1.SelectedIndex == 8)
                nyanetServiceFramework("-6" + ttl_opt + snusnu, "start");
            else //if (comboBox1.SelectedIndex == 9)//
                nyanetServiceFramework("-7" + ttl_opt + snusnu, "start");
            #endregion
        }
        private void button2_Click(object sender, EventArgs e)
        {
            #region Stop Nyanet Service Framework Manually by Clicking Stop Button
            writeLog("Stop button clicked.");
            nyanetServiceFramework("NyanetServiceFramework", "stop"); //terminate nyanet
            #region Save TTL to File
            string ttl = numericUpDown1.Value.ToString();
            this.Invoke((MethodInvoker)delegate {
                if (!System.IO.File.Exists("ttl"))
                    System.IO.File.Create(startupPath + "ttl").Dispose();
                System.IO.File.WriteAllText(startupPath + "ttl", ttl);
            });
            #endregion
            button1.Enabled = true;
            button1.Visible = true;
            button2.Enabled = false;
            button2.Visible = false;
            #endregion
        }
        private void Form1_Load(object sender, EventArgs e) {
            #region Form1_Load Events
            writeLog("Form1 has been loaded!");
            if (!runnedOnce) {runOnce(); }
            this.Activated += AfterLoading;
            #endregion
        }
        private void runOnce()
        {
            #region Log
            writeLog("runOnce() method has been loaded!");
            #endregion
            #region lock maximum size to window size 
            this.MaximumSize = this.Size;
            #endregion
            #region Check Magic Key
            string mPath = Process.GetCurrentProcess().MainModule.FileName.Replace(Process.GetCurrentProcess().ProcessName + ".exe", "magicKey");
            bool m = System.IO.File.Exists(Process.GetCurrentProcess().MainModule.FileName.Replace(Process.GetCurrentProcess().ProcessName + ".exe", "magicKey"));
            if (m) checkBox7.Checked = false;
            #endregion
            #region If redirDNS file exists set redirect DNS combobox3 Index number
            if (System.IO.File.Exists(Process.GetCurrentProcess().MainModule.FileName.Replace(Process.GetCurrentProcess().ProcessName + ".exe", "redirDNS")))
            {
                string secret, redirDNSPath = Process.GetCurrentProcess().MainModule.FileName.Replace(Process.GetCurrentProcess().ProcessName + ".exe", "redirDNS");
                using (FileStream fileStream = new FileStream(redirDNSPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                using (StreamReader streamReader = new StreamReader(fileStream))
                    secret = streamReader.ReadToEnd();
                string[] info = secret.Split('|');
                string comboBox3Index = info[4];
                if (comboBox3Index != "-1")
                    comboBox3.SelectedIndex = Convert.ToInt32(comboBox3Index);
            }
            else {
                if (comboBox3.SelectedIndex == -1)
                    comboBox3.SelectedIndex = 0;
            }
            #endregion
            #region print detected system language as ISO Country code
            label11.Text = "Tespit edilen ISO sistem dili kodu " + sysLang + "!";
            #endregion
            #region Add Work Mode (ComboBox 1) Options
            comboBox1.Items.Add("-1 Uyumlu");
                comboBox1.Items.Add("-2 Hızlı HTTPS ve Uyumlu");
                comboBox1.Items.Add("-3 Hızlı HTTP ve HTTPS");
                comboBox1.Items.Add("-4 En hızlı");
                comboBox1.Items.Add("-9 Varsayılan");
                comboBox1.Items.Add("-8 Varsayılan 2, Karışık Paket Sıralaması");
                comboBox1.Items.Add("Varsayılan");
                comboBox1.Items.Add("-5 Oto TTL, Ters Frag, Max Payload");
                comboBox1.Items.Add("-6 Yanlış Seq, Ters Frag, Max Payload");
                comboBox1.Items.Add("-7 Yanlış Chksum, Ters Frag, Max Payload");
            #endregion
            #region If currentServiceMode file exists restore last Work Mode
            this.Invoke((MethodInvoker)delegate
            {
                string _CSM = comboBox1.SelectedIndex.ToString();
                if (System.IO.File.Exists("currentServiceMode"))
                {
                    string modeIndex=System.IO.File.ReadAllText("currentServiceMode");
                    if (modeIndex.Trim() != "-1")
                        comboBox1.SelectedIndex = Convert.ToInt32(modeIndex.Trim());
                    else comboBox1.SelectedIndex = 6;
                }
                else
                {
                    try { comboBox1.SelectedIndex = 6; }
                    catch (Exception) { }
                }
            });
            #endregion
            #region Add DoH (ComboBox 2) Options
            comboBox2.Items.Add("Cloudflare");
            comboBox2.Items.Add("Google");
            comboBox2.Items.Add("Quad9 Malware blocking, DNSSEC, ECS");
            comboBox2.Items.Add("Adguard Adblock Trackers");
            comboBox2.Items.Add("WikiMedia");
            comboBox2.Items.Add("Controld Adblock Trackers");
            #endregion
            #region Set DoH (ComboBox 2) as Cloudflare but do not apply it
            try { comboBox2.SelectedIndex = comboBox2.FindString("Cloudflare"); }
            catch (Exception) { }
            #endregion
            #region Check System Langue ISO code if it is not Turkish or Azerbaijani set default language to English
            if (sysLang!="tr" && sysLang!="az")
            {
                lang = false;//english
                this.Invoke((MethodInvoker)delegate { changeLangEnglish(); });
            }
            //Uncomment for testing english language
            //lang = false;//english
            //this.Invoke((MethodInvoker)delegate { changeLangEnglish(); });
            #endregion
            #region Check Missing Files if it is found exit
            string notFound = "";
            if (!System.IO.File.Exists(startupPath + "NyanetServiceFramework.exe"))
                notFound += "NyanetServiceFramework.exe ";
            if (!System.IO.File.Exists(startupPath + "WinDivert.dll"))
                notFound += "WinDivert.dll ";
            if (!System.IO.File.Exists(startupPath + "WinDivert64.sys"))
                notFound += "WinDivert64.sys ";
            //if (!System.IO.File.Exists(startupPath + "WinDivert32.sys"))
            //    notFound += "WinDivert32.sys ";
            //if (!System.IO.File.Exists(startupPath + "msys-2.0.dll"))
            //    notFound += "msys-2.0.dll ";
            if (notFound != "")
            {
                string _9 = "";
                if (!lang) _9 = "Some of the files are missing!\nDownload it again from: https://github.com/ny4rlk0/Nyanet\nExiting...";
                else _9 = "Dosyalardan bazıları eksik. Programı yeniden indirin. Yazılım kapatılıyor.\nhttps://github.com/ny4rlk0/Nyanet";
                MessageBox.Show($"({notFound})\n{_9}");
                writeLog($"{notFound} Some of the files are missing! Download it again from: https://github.com/ny4rlk0/Nyanet");
                writeLog("Shutting down Nyanet Logger...");
                Environment.Exit(0);
            }
            #endregion
            runnedOnce = true;
            #region Form UI Maximum Size Customation and Remove Top Bar
            this.MaximizeBox = false;
            //this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.FormBorderStyle = FormBorderStyle.None;
            #endregion
            #region Start Check Nyanet Service Framework status and Update The UI Background Job
            Thread nyanetServiceStatus = new Thread(() => checkServiceStatus());
            nyanetServiceStatus.IsBackground = true;
            nyanetServiceStatus.Start();
            #endregion
            this.Invoke((MethodInvoker)delegate
            {
            #region if runAsCurrentUser file not found kill Nyanet Service Framework and Stop Windivert Driver at app start!
            if (!System.IO.File.Exists("runAsCurrentUser"))
            {
                try { //CMD("/C taskkill /im \"NyanetServiceFramework.exe\" /f");
                    Process[] nsf = Process.GetProcessesByName("NyanetServiceFramework");
                    if (nsf.Length != 0)
                    {
                        foreach (Process p in nsf)
                        {
                            p.Kill();
                            p.Dispose();
                        }
                        writeLog("stop: NyanetServiceFramework.exe!");
                    }
                }
                catch (Exception) {  }
                try { CMD("/C sc stop windivert >nul 2>&1"); }
                catch (Exception) {  }
            }
            #endregion
            #region Hide Group Box 1 and Group Box 2
            groupBox1.Visible = false;
            groupBox2.Visible = false;
            #endregion
            #region Update Network Cards
            try { updateNetworkCards(); }
            catch (Exception er) { writeLog(er.ToString()); }
            #endregion
            #region Update appExactPath variable set appPathGet to false if we can't find it
            try { appExactPath = System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName; appPathGet = true; }
            catch (Exception) { appPathGet = false; }
            //checkBox2.FlatAppearance.CheckedBackColor = Color.Black;
            //checkBox2.FlatAppearance.MouseOverBackColor = Color.Black;
            //checkBox2.FlatAppearance.MouseDownBackColor = Color.Black;
            #endregion
            #region Read ttl from File
            string ttl = numericUpDown1.Value.ToString();
            if (System.IO.File.Exists("ttl"))
            {
                ttl = System.IO.File.ReadAllText(startupPath + "ttl");
                numericUpDown1.Value = Convert.ToInt32(ttl);
            }

            #endregion
            #region If redirDNS file exists read and set redirect DNS info then Update Redirect DNS button in UI. 
            //Tek satıra indirdin olurda if ifadesinde ne olduğunu unutursan ki unutacaksın buraya bak.
            /*/ Get the current file path
            string currentFilePath = Process.GetCurrentProcess().MainModule.FileName;

            // Generate the target file path
            string targetFilePath = currentFilePath.Replace(Process.GetCurrentProcess().ProcessName + ".exe", "runAsCurrentUser.exe");

            // Check if the target file exists
            if (System.IO.File.Exists(targetFilePath))
            {
                // File exists logic
            }*/
            string dnsv4 = "", dnsv4_Port = "", dnsv6 = "", dnsv6_Port = "",comboBox3Index="";
            if (System.IO.File.Exists(Process.GetCurrentProcess().MainModule.FileName.Replace(Process.GetCurrentProcess().ProcessName + ".exe", "redirDNS")))
            {
                string secret, redirDNSPath = Process.GetCurrentProcess().MainModule.FileName.Replace(Process.GetCurrentProcess().ProcessName + ".exe", "redirDNS");
                using (FileStream fileStream = new FileStream(redirDNSPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                    using (StreamReader streamReader = new StreamReader(fileStream))
                        secret = streamReader.ReadToEnd();
                string[] info = secret.Split('|');
                dnsv4 = info[0];
                dnsv4_Port = info[1];
                dnsv6 = info[2];
                dnsv6_Port = info[3];
                comboBox3Index = info[4];
                comboBox3.SelectedIndex = Convert.ToInt32(comboBox3Index);
            }
                    
            if (comboBox3.SelectedIndex == 0)
            {
                dnsv4 = "77.88.8.8"; dnsv4_Port = "1253"; dnsv6 = "2a02:6b8::feed:0ff"; dnsv6_Port = "1253";
            }
            else if (comboBox3.SelectedIndex == 1)
            {
                dnsv4 = "9.9.9.9"; dnsv4_Port = "9953"; dnsv6 = "none"; dnsv6_Port = "none";
            }
            else if (comboBox3.SelectedIndex == 2)
            {
                dnsv4 = "208.67.222.222"; dnsv4_Port = "5353"; dnsv6 = "none"; dnsv6_Port = "none";
            }
            else
            {
                comboBox1.SelectedIndex = 0;
                dnsv4 = "77.88.8.8"; dnsv4_Port = "1253"; dnsv6 = "2a02:6b8::feed:0ff"; dnsv6_Port = "1253";
            }
            string dpPath = Process.GetCurrentProcess().MainModule.FileName.Replace(Process.GetCurrentProcess().ProcessName + ".exe", "redirDNS");
            bool dp = System.IO.File.Exists(Process.GetCurrentProcess().MainModule.FileName.Replace(Process.GetCurrentProcess().ProcessName + ".exe", "redirDNS"));
            //Update Force DNS Redirect Checkbox
            if (dp) checkBox6.Checked = true;
            else checkBox6.Checked = false;
            ////////////////////////////////
            this.Invoke((MethodInvoker)delegate
            {
                if (checkBox6.Checked)
                {
                    if (!System.IO.File.Exists(dpPath))
                        System.IO.File.WriteAllText(dpPath,$"{dnsv4}|{dnsv4_Port}|{dnsv6}|{dnsv6_Port}|{comboBox3.SelectedIndex.ToString()}");
                    checkBox6.ForeColor = Color.Lime;
                    checkBox6.BackColor = Color.Transparent;
                    checkBox6.FlatAppearance.BorderColor = Color.Lime;
                }
                else
                {
                    if (System.IO.File.Exists(dpPath))
                        System.IO.File.Delete(dpPath);
                    checkBox6.ForeColor = Color.Red;
                    checkBox6.BackColor = Color.Transparent;
                    checkBox6.FlatAppearance.BorderColor = Color.Red;
                }
            });
            #endregion
            #region if runAsCurrentUser file exists Start Nyanet in Background when user Login.
            if (System.IO.File.Exists(Process.GetCurrentProcess().MainModule.FileName.Replace(Process.GetCurrentProcess().ProcessName+".exe", "runAsCurrentUser")))
            {
                checkBox2.Checked = true;
                //checkBox5.Checked = true;
                button1.Visible = false;
                button1.Enabled = false;
                button2.Enabled = true;
                button2.Visible = true;
                #region Start Nyanet Service Framework and Get Correct Startup variables.
                ttl = numericUpDown1.Value.ToString();
                string ttl_opt, snusnu; //Magic key 5.12.2024
                if (checkBox4.Checked) ttl_opt = " --set-ttl " + ttl;
                else ttl_opt = "";
                if (checkBox7.Checked) snusnu = " -p -q -r -s -m -a";
                else snusnu = "";
                if (comboBox1.SelectedIndex == 0)
                    nyanetServiceFramework("-1" + ttl_opt + snusnu, "start");//-n
                else if (comboBox1.SelectedIndex == 1)
                    nyanetServiceFramework("-2" + ttl_opt + snusnu, "start");//-y
                else if (comboBox1.SelectedIndex == 2)
                    nyanetServiceFramework("-3" + ttl_opt + snusnu, "start");//-a
                else if (comboBox1.SelectedIndex == 3)
                    nyanetServiceFramework("-4" + ttl_opt + snusnu, "start");//-r
                else if (comboBox1.SelectedIndex == 4)
                    nyanetServiceFramework("-9" + ttl_opt + snusnu, "start");//-l
                else if (comboBox1.SelectedIndex == 5)
                    nyanetServiceFramework("-8" + ttl_opt + snusnu, "start");//-k
                else if (comboBox1.SelectedIndex == 6)
                    nyanetServiceFramework(ttl_opt.TrimStart() + snusnu, "start");//-l
                else if (comboBox1.SelectedIndex == 7)
                    nyanetServiceFramework("-5" + ttl_opt + snusnu, "start");//-l
                else if (comboBox1.SelectedIndex == 8)
                    nyanetServiceFramework("-6" + ttl_opt + snusnu, "start");
                else //if (comboBox1.SelectedIndex == 9)//
                    nyanetServiceFramework("-7" + ttl_opt + snusnu, "start");
                #endregion
                #region Setup Notifications and Notification Icons
                notifyIcon1.Icon = Properties.Resources.n128;
                notifyIcon1.ContextMenu = new ContextMenu();
                string _1, _2, _3;
                if (sysLang != "tr" && sysLang != "az")
                { _1 = "Open"; _2 = "Exit"; _3 = "Minimized to notification bar!"; }
                else { _1 = "Aç"; _2 = "Çıkış"; _3 = "Bildirim çubuğuna küçültüldü!"; }
                Open = new MenuItem(_1);
                Exit = new MenuItem(_2);
                notifyIcon1.ContextMenu.MenuItems.Add(Open);
                notifyIcon1.ContextMenu.MenuItems.Add(Exit);
                Exit.Click += ExitClick;
                Open.Click += OpenClick;
                notifyIcon1.MouseDoubleClick += OpenClick;
                notifyIcon1.Visible = true;
                notifyIcon1.Text = "Nyanet D.P.I. Agent\ngithub.com/ny4rlk0";
                notifyIcon1.BalloonTipText = _3;
                //notifyIcon1.ShowBalloonTip(3000);
                //notifyIcon1.BalloonTipIcon = ToolTipIcon.Info;
                #endregion
                #region Hide Form Main UI
                this.ShowInTaskbar = false;
                this.WindowState = FormWindowState.Minimized;
                this.Hide();
                #endregion
            }
            #endregion
            #region Else if runAsCurrentUser file does not exists remove Nyanet from app login startup path
            else if (!System.IO.File.Exists("runAsCurrentUser"))
            {
                checkBox2.Checked = false;
                this.Invoke((MethodInvoker)delegate {
                    checkBox2.ForeColor = Color.Red;
                    //checkBox2.BackColor = Color.Black;
                    checkBox2.FlatAppearance.BorderColor = Color.Red;
                    //checkBox2.Checked = false;
                });
                try
                {
                    if (System.IO.File.Exists(userStartupProgramsPath + "\\nyanet.lnk"))
                        System.IO.File.Delete(userStartupProgramsPath + "\\nyanet.lnk");
                    if (System.IO.File.Exists("runAsCurrentUser"))
                        System.IO.File.Create("runAsCurrentUser");
                }
                catch (Exception) { }
            }
            #endregion
            });
        }
        private void AfterLoading(object sender, EventArgs e)
        {
            this.Activated -= AfterLoading;
            #region Log
            writeLog("AfterLoading() method has been loaded.");
            #endregion
            #region Update Magic Key checkbox in Main UI
            string mPath = Process.GetCurrentProcess().MainModule.FileName.Replace(Process.GetCurrentProcess().ProcessName + ".exe", "magicKey");
            bool m = System.IO.File.Exists(Process.GetCurrentProcess().MainModule.FileName.Replace(Process.GetCurrentProcess().ProcessName + ".exe", "magicKey"));
            if (m) checkBox7.Checked = false;
            #endregion
            #region Setup Notification Icon, Menu, Text
            notifyIcon1.Icon = Properties.Resources.n128_r;
            notifyIcon1.ContextMenu = new ContextMenu();
            string _1,_2;
            if (sysLang != "tr" && sysLang != "az")
            {_1 = "Open"; _2 = "Exit"; }
            else { _1 = "Aç";_2 = "Çıkış"; }
            Open = new MenuItem(_1);
            Exit = new MenuItem(_2);
            notifyIcon1.ContextMenu.MenuItems.Add(Open);
            notifyIcon1.ContextMenu.MenuItems.Add(Exit);
            Exit.Click += ExitClick;
            Open.Click += OpenClick;
            notifyIcon1.MouseDoubleClick += OpenClick;
            notifyIcon1.Visible = true;
            notifyIcon1.Text = "Nyanet D.P.I. Agent\ngithub.com/ny4rlk0";
            //notifyIcon1.BalloonTipText = _3;
            //if (!runnedOnce2) notifyIcon1.ShowBalloonTip(3000);
            //notifyIcon1.BalloonTipIcon = ToolTipIcon.Info;
            #endregion
            #region No Multiple Instances
            System.Diagnostics.Process pThis = System.Diagnostics.Process.GetCurrentProcess();
            foreach (System.Diagnostics.Process p in System.Diagnostics.Process.GetProcesses())
                if (p.Id != pThis.Id && p.ProcessName == pThis.ProcessName)
                    Environment.Exit(0);
            #endregion
            #region if Main UI is minimized Hide the program
            if (this.WindowState == FormWindowState.Minimized)
            {
                //Call minimize logic from here
                this.Hide();
                this.ShowInTaskbar = false;
            }
            #endregion
        }
        private void Form1_Resize(object sender, EventArgs e)
        {
            #region if form Main UI is minimized also Hide the taskbar and minimize to notification area
            if (this.WindowState == FormWindowState.Minimized)//|| this.WindowState == FormWindowState.Maximized)
            {
                // Minimize işlemi sırasında yapılacak işlemler
                // this.WindowState = FormWindowState.Minimized;
                writeLog("Form1 has been minimized to notification bar!");
                string _3;
                if (sysLang != "tr" && sysLang != "az")
                { _3 = "Minimized to notification bar!"; }
                else { _3 = "Bildirim çubuğuna küçültüldü!"; }
                notifyIcon1.BalloonTipText = _3;
                notifyIcon1.ShowBalloonTip(1000);
                this.Hide();
                this.ShowInTaskbar = false;
                notifyIcon1.Visible = true;
            }
            #endregion
        }
        private void OpenClick(object sender, EventArgs e)
        {
            #region if menu item Open is clicked Show Form Main UI
            writeLog("Displaying Form1!");
            this.Show();
            this.WindowState = FormWindowState.Normal;
            this.Activate();
            this.Focus();
            this.ShowInTaskbar = true;
            //this.WindowState = FormWindowState.Normal;
            #endregion
        }
        private void ExitClick(object sender, EventArgs e)
        {
            #region if menu item Exit is clicked Exit from program
            writeLog("Shutting down Nyanet Logger...");
            foreach (var process in Process.GetProcessesByName("NyanetServiceFramework"))
                process.Kill();
            notifyIcon1.Visible = false;
            notifyIcon1.Dispose();
            Environment.Exit(0);
            #endregion
        }
        void OnProcessExit(object sender, EventArgs e)
        {
            #region Log process exit to debug.txt file if it exists
            writeLog("Shutting down Nyanet Logger...");
            #endregion
        }
        private void checkServiceStatus() {
            try
            {
                #region Update Nyanet Service Framework status in Form Main UI
                Process[] pname = Process.GetProcessesByName("NyanetServiceFramework");
                if (pname.Length == 0)
                {
                    this.Invoke((MethodInvoker)delegate
                    {
                        if ((lang&&label3.Text != "Çalışmıyor") || (!lang&&label3.Text != "Not Running"))
                        {
                            if (lang) label3.Text = "Çalışmıyor";
                            else if (!lang) label3.Text = "Not Running";

                            if (lang)
                            {
                                notifyIcon1.BalloonTipText = "DPI servisi durduruldu.";
                                notifyIcon1.ShowBalloonTip(1000);
                            }
                            else if (!lang)
                            {
                                notifyIcon1.BalloonTipText = "DPI service has been stopped.";
                                notifyIcon1.ShowBalloonTip(1000);
                            }

                            label3.ForeColor = Color.Red;
                            notifyIcon1.Icon = Properties.Resources.n128_r;
                        }
                    });
                }
                else
                {
                    if ((lang && label3.Text != "Çalışıyor") || (!lang && label3.Text != "Running"))
                    {
                        this.Invoke((MethodInvoker)delegate
                        {
                            if (lang) label3.Text = "Çalışıyor";
                            else if (!lang) label3.Text = "Running";
                            if (lang)
                            {
                                notifyIcon1.BalloonTipText = "DPI servisi başlatıldı.";
                                notifyIcon1.ShowBalloonTip(1000);
                            }
                            else if (!lang)
                            {
                                notifyIcon1.BalloonTipText = "DPI service has been started.";
                                notifyIcon1.ShowBalloonTip(1000);
                            }
                            label3.ForeColor = Color.Lime;
                            notifyIcon1.Icon = Properties.Resources.n128_g;
                        });
                    }
                }
                #endregion
                #region Update DNS Info on the Form Main UI
                try
                {
                    if (!getDNSRunning) {
                        Thread cmdBackground = new Thread(() => getDNS());
                        cmdBackground.IsBackground = true;
                        cmdBackground.Start();
                    }
                }
                catch (Exception) { }
                #endregion
                #region If There is a command in Queue run the command as new Thread
                try
                {
                    if (SortCMDCommands.Count != 0 && SortCMDCommands != null && !CMDBusy)
                    {
                        Thread cmdBackground = new Thread(() => CMDelagate(SortCMDCommands[0]));
                        cmdBackground.IsBackground = true;
                        cmdBackground.Start();
                    }

                }
                catch (Exception er) { writeLog(er.ToString()); }
                /*try
                {
                    if (SortCMDCommands.Count == 0) { 
                    updateInterfaces();
                    }
                }
                catch (Exception er){ MessageBox.Show(er.ToString()); }*/
                #endregion
            }
            catch (Exception e)
            {
                #region If there is a error in checkServiceStatus method and debug.txt exists log in to file!
                writeLog("checkServiceStatus: \n" + e.ToString());
                #endregion
            }
            #region Wait 2 seconds and call this method again
            Thread.Sleep(2000);//0.05 sn bekle
            checkServiceStatus();
            //Thread nyanetServiceStatus = new Thread(() => checkServiceStatus());
            //nyanetServiceStatus.IsBackground = true;
            //nyanetServiceStatus.Start();
            #endregion
        }
        //Set DNS Over HTTPS Settings for Windows 11
        private void setDNSServers()
        {
            #region Set DNS Servers via Regedit
            setDNSValues();
            #region Write a log
                writeLog("Setting [D]NS [O]ver [H]TTPS servers.");
                writeLog($"DoH: DNSv4_1: {dnsv4_1} DNSv4_2: {dnsv4_2} DNSv6_1: {dnsv6_1} DNSv6_2: {dnsv6_2} HTTPS_TEMPLATE: {httpsTemplate}");
                #endregion
            CMD("/C REG ADD \"HKLM\\SOFTWARE\\Policies\\Microsoft\\Windows NT\\DNSClient\" /F");
            CMD("/C REG ADD \"HKLM\\SOFTWARE\\Policies\\Microsoft\\Windows NT\\DNSClient\" /v DoHPolicy /t REG_DWORD /d 2 /F");//2
            CMD("/C REG ADD \"HKLM\\SYSTEM\\CurrentControlSet\\Services\\Dnscache\\Parameters\\DohWellKnownServers\" /F");
            CMD("/C REG ADD \"HKLM\\SYSTEM\\CurrentControlSet\\Services\\Dnscache\\Parameters\\DohWellKnownServers\\" + dnsv4_1 + "\" /F");
            CMD("/C REG ADD \"HKLM\\SYSTEM\\CurrentControlSet\\Services\\Dnscache\\Parameters\\DohWellKnownServers\\" + dnsv4_1 + "\" /v Template /t REG_SZ /d " + httpsTemplate + " /F");
            CMD("/C REG ADD \"HKLM\\SYSTEM\\CurrentControlSet\\Services\\Dnscache\\Parameters\\DohWellKnownServers\\" + dnsv4_2 + "\" /F");
            CMD("/C REG ADD \"HKLM\\SYSTEM\\CurrentControlSet\\Services\\Dnscache\\Parameters\\DohWellKnownServers\\" + dnsv4_2 + "\" /v Template /t REG_SZ /d " + httpsTemplate + " /F");
            CMD("/C REG ADD \"HKLM\\SYSTEM\\CurrentControlSet\\Services\\Dnscache\\Parameters\\DohWellKnownServers\\" + dnsv6_1 + "\" /F");
            CMD("/C REG ADD \"HKLM\\SYSTEM\\CurrentControlSet\\Services\\Dnscache\\Parameters\\DohWellKnownServers\\" + dnsv6_1 + "\" /v Template /t REG_SZ /d " + httpsTemplate + " /F");
            CMD("/C REG ADD \"HKLM\\SYSTEM\\CurrentControlSet\\Services\\Dnscache\\Parameters\\DohWellKnownServers\\" + dnsv6_2 + "\" /F");
            CMD("/C REG ADD \"HKLM\\SYSTEM\\CurrentControlSet\\Services\\Dnscache\\Parameters\\DohWellKnownServers\\" + dnsv6_2 + "\" /v Template /t REG_SZ /d " + httpsTemplate + " /F");
            CMD("/C gpupdate /force");

            foreach (string networkAdapterName in NetworkInterfaceNames)
            {
                CMD($"/C netsh interface ipv4 set dns name=\"{networkAdapterName}\" source=static address=none");
                CMD($"/C netsh interface ipv6 set dns name=\"{networkAdapterName}\" source=static address=none");
                CMD($"/C netsh interface ipv4 add dnsservers \"{networkAdapterName}\" " + dnsv4_1 + " index=1");
                CMD($"/C netsh interface ipv4 add dnsservers \"{networkAdapterName}\" " + dnsv4_2 + " index=2");
                CMD($"/C netsh interface ipv6 add dnsservers \"{networkAdapterName}\" " + dnsv6_1 + " index=1");
                CMD($"/C netsh interface ipv6 add dnsservers \"{networkAdapterName}\" " + dnsv6_2 + " index=2");
            }
            //HANDLE WINDOWS SETTINGS NETWORKING GUI
            foreach (string networkAdapterGUID in NetworkInterfacesGUIDS)
            {
                if (networkAdapterGUID != null && networkAdapterGUID != "" && networkAdapterGUID != " ")
                {
                    CMD("/C REG ADD \"HKLM\\SYSTEM\\CurrentControlSet\\Services\\Dnscache\\InterfaceSpecificParameters\\" + networkAdapterGUID + "\" /F");
                    CMD("/C REG ADD \"HKLM\\SYSTEM\\CurrentControlSet\\Services\\Dnscache\\InterfaceSpecificParameters\\" + networkAdapterGUID + "\\DohInterfaceSettings\" /F");
                    CMD("/C REG ADD \"HKLM\\SYSTEM\\CurrentControlSet\\Services\\Dnscache\\InterfaceSpecificParameters\\" + networkAdapterGUID + "\\DohInterfaceSettings\\Doh\" /F");
                    CMD("/C REG ADD \"HKLM\\SYSTEM\\CurrentControlSet\\Services\\Dnscache\\InterfaceSpecificParameters\\" + networkAdapterGUID + "\\DohInterfaceSettings\\Doh6\" /F");
                    CMD("/C REG ADD \"HKLM\\SYSTEM\\CurrentControlSet\\Services\\Dnscache\\InterfaceSpecificParameters\\" + networkAdapterGUID + "\\DohInterfaceSettings\\Doh\\" + dnsv4_1 + "\" /F");
                    CMD("/C REG ADD \"HKLM\\SYSTEM\\CurrentControlSet\\Services\\Dnscache\\InterfaceSpecificParameters\\" + networkAdapterGUID + "\\DohInterfaceSettings\\Doh\\" + dnsv4_2 + "\" /F");
                    CMD("/C REG ADD \"HKLM\\SYSTEM\\CurrentControlSet\\Services\\Dnscache\\InterfaceSpecificParameters\\" + networkAdapterGUID + "\\DohInterfaceSettings\\Doh6\\" + dnsv6_1 + "\" /F");
                    CMD("/C REG ADD \"HKLM\\SYSTEM\\CurrentControlSet\\Services\\Dnscache\\InterfaceSpecificParameters\\" + networkAdapterGUID + "\\DohInterfaceSettings\\Doh6\\" + dnsv6_1 + "\" /F");
                    CMD("/C REG ADD \"HKLM\\SYSTEM\\CurrentControlSet\\Services\\Dnscache\\InterfaceSpecificParameters\\" + networkAdapterGUID + "\\DohInterfaceSettings\\Doh\\" + dnsv4_1 + "\" /v DohTemplate /t REG_SZ /d " + httpsTemplate + " /F");
                    CMD("/C REG ADD \"HKLM\\SYSTEM\\CurrentControlSet\\Services\\Dnscache\\InterfaceSpecificParameters\\" + networkAdapterGUID + "\\DohInterfaceSettings\\Doh\\" + dnsv4_2 + "\" /v DohTemplate /t REG_SZ /d " + httpsTemplate + " /F");
                    CMD("/C REG ADD \"HKLM\\SYSTEM\\CurrentControlSet\\Services\\Dnscache\\InterfaceSpecificParameters\\" + networkAdapterGUID + "\\DohInterfaceSettings\\Doh6\\" + dnsv6_1 + "\" /v DohTemplate /t REG_SZ /d " + httpsTemplate + " /F");
                    CMD("/C REG ADD \"HKLM\\SYSTEM\\CurrentControlSet\\Services\\Dnscache\\InterfaceSpecificParameters\\" + networkAdapterGUID + "\\DohInterfaceSettings\\Doh6\\" + dnsv6_2 + "\" /v DohTemplate /t REG_SZ /d " + httpsTemplate + " /F");
                    CMD("/C REG ADD \"HKLM\\SYSTEM\\CurrentControlSet\\Services\\Dnscache\\InterfaceSpecificParameters\\" + networkAdapterGUID + "\\DohInterfaceSettings\\Doh\\" + dnsv4_1 + "\" /v DohFlags /t REG_QWORD /d \"0x1\" /F");//0x0 Disabled 0x1 Enabled Windows Settings Uygulamasındaki şifreli DNS sunucusu ayarını aktifleştiriyor
                    CMD("/C REG ADD \"HKLM\\SYSTEM\\CurrentControlSet\\Services\\Dnscache\\InterfaceSpecificParameters\\" + networkAdapterGUID + "\\DohInterfaceSettings\\Doh\\" + dnsv4_2 + "\" /v DohFlags /t REG_QWORD /d \"0x1\" /F");//0x0 Disabled 0x1 Enabled
                    CMD("/C REG ADD \"HKLM\\SYSTEM\\CurrentControlSet\\Services\\Dnscache\\InterfaceSpecificParameters\\" + networkAdapterGUID + "\\DohInterfaceSettings\\Doh6\\" + dnsv6_1 + "\" /v DohFlags /t REG_QWORD /d \"0x1\" /F");//0x0 Disabled 0x1 Enabled
                    CMD("/C REG ADD \"HKLM\\SYSTEM\\CurrentControlSet\\Services\\Dnscache\\InterfaceSpecificParameters\\" + networkAdapterGUID + "\\DohInterfaceSettings\\Doh6\\" + dnsv6_2 + "\" /v DohFlags /t REG_QWORD /d \"0x1\" /F");//0x0 Disabled 0x1 Enabled
                }
            }
            #endregion
            this.Invoke((MethodInvoker)delegate
            {
                #region Enable Apply DNS Settings Button
                button6.Enabled = true;
                button6.Visible = true;
                button5.Enabled = false;
                button5.Visible = false;
                #endregion
            });
        }
        private void updateNetworkCards()
        {
            #region Query Network Cards from Regedit
            CMD("/C reg query \"HKLM\\SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\NetworkCards\"");
            #endregion
        }
        private void checkAdminAccess()
        {
            #region Administration Permission Request Logic
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
                catch (Exception) {
                    writeLog("Admin access denied!");
                    writeLog("Shutting down Nyanet Logger...");
                    MessageBox.Show("Run as Administrator!"); 
                }
                // Shut down the current process
                Environment.Exit(0);
            }
            #endregion
        }
        private void nyanetServiceFramework(string Options, string StartOrStop)
        {
            #region Start Nyanet Service Framework Delagate as new Background Thread
            Thread nyanetServiceFrameworkDelagateBackground = new Thread(() => nyanetServiceFrameworkDelagate(Options, StartOrStop));
            nyanetServiceFrameworkDelagateBackground.IsBackground = true;
            nyanetServiceFrameworkDelagateBackground.Start();
            #endregion
        }
        private void nyanetServiceFrameworkDelagate(string Options, string StartOrStop)
        {
            #region Nyanet Service Framework Startup Logic
            try
            {

                #region Write a log
                if (StartOrStop!="stop")
                {
                    if (System.IO.File.Exists(Process.GetCurrentProcess().MainModule.FileName.Replace(Process.GetCurrentProcess().ProcessName + ".exe", "blacklist.txt")))
                        writeLog("blacklist.txt file found!\nUsing DPI Unblock on only blacklist.txt file domains!");
                }
                #endregion
                //NyanetServiceFramework.exe --set-ttl 6 -p -q -r -s -m -a --blacklist blacklist.txt
                if (System.IO.File.Exists(Process.GetCurrentProcess().MainModule.FileName.Replace(Process.GetCurrentProcess().ProcessName + ".exe", "blacklist.txt")) && StartOrStop != "stop")
                    Options+= " --blacklist blacklist.txt";
                if (StartOrStop == "start")
                {
                    string dnsv4="", dnsv4_Port="", dnsv6="", dnsv6_Port="";
                    if (System.IO.File.Exists(Process.GetCurrentProcess().MainModule.FileName.Replace(Process.GetCurrentProcess().ProcessName + ".exe", "redirDNS")))
                    {
                        string secret, redirDNSPath = Process.GetCurrentProcess().MainModule.FileName.Replace(Process.GetCurrentProcess().ProcessName + ".exe", "redirDNS");
                        using (FileStream fileStream = new FileStream(redirDNSPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                        using (StreamReader streamReader = new StreamReader(fileStream))
                            secret = streamReader.ReadToEnd();
                        string[] info = secret.Split('|');
                        dnsv4 = info[0];
                        dnsv4_Port = info[1];
                        dnsv6 = info[2];
                        dnsv6_Port = info[3];
                        if (dnsv4 != "none" && dnsv4_Port != "none" && dnsv6 != "none" && dnsv6_Port != "none")
                            Options += " --dns-addr " + dnsv4 + " --dns-port " + dnsv4_Port + " --dnsv6-addr " + dnsv6 + " --dnsv6-port " + dnsv6_Port;
                        else if (dnsv4 != "none" && dnsv4_Port != "none" && dnsv6 == "none" && dnsv6_Port == "none")
                            Options += " --dns-addr " + dnsv4 + " --dns-port " + dnsv4_Port;
                        else if (dnsv4 == "none" && dnsv4_Port == "none" && dnsv6 != "none" && dnsv6_Port != "none")
                            Options += " --dnsv6-addr " + dnsv6 + " --dnsv6-port " + dnsv6_Port;
                        //writeLog($"Detected redirDNS file.\nUsing DNS Redirect dnsv4:{dnsv4} dnsv4_Port:{dnsv4_Port} dnsv6:{dnsv6} dnsv6_Port:{dnsv6_Port}");
                    }
                    //Kill first ask later
                    //CMD("/C taskkill /im \"NyanetServiceFramework.exe\" /f >nul 2>&1");
                    Process nsf = Process.GetProcessesByName("NyanetServiceFramework").FirstOrDefault();
                    if (nsf != null)
                    {
                        nsf.Kill();
                        nsf.Dispose();
                        writeLog("stop: NyanetServiceFramework.exe!");
                    }

                    if (System.IO.File.Exists(Process.GetCurrentProcess().MainModule.FileName.Replace(Process.GetCurrentProcess().ProcessName + ".exe", "redirDNS")))
                    {
                        writeLog($"{StartOrStop}: NyanetServiceFramework.exe {Options}");
                        writeLog($"Detected redirDNS file.");
                        writeLog($"Using DNS Redirect dnsv4: {dnsv4} dnsv4_Port: {dnsv4_Port} dnsv6: {dnsv6} dnsv6_Port: {dnsv6_Port}");
                    }
                    else writeLog(StartOrStop + ": " + "NyanetServiceFramework.exe " + Options);
                    ////////////////////////////
                    Process p = new Process();
                    p.StartInfo.FileName = startupPath + "NyanetServiceFramework.exe";
                    p.StartInfo.Arguments = Options;
                    p.StartInfo.UseShellExecute = false;
                    p.StartInfo.RedirectStandardOutput = false;
                    p.StartInfo.RedirectStandardError = true;
                    p.StartInfo.CreateNoWindow = true;
                    p.Start();
                    string err = p.StandardError.ReadToEnd();
                    p.WaitForExit();
                    err=err.Trim();
                    if (err != null&&err!=" "&&err!=""&&err!="\n"&&err!=" \n") {
                        writeLog("NyanetServiceFramework.exe Error:\n"+err+"\nNyanetServiceFramework.exe "+Options);
                        if (System.IO.File.Exists(Process.GetCurrentProcess().MainModule.FileName.Replace(Process.GetCurrentProcess().ProcessName + ".exe", "blacklist.txt")))
                        {
                            System.IO.File.Delete(Process.GetCurrentProcess().MainModule.FileName.Replace(Process.GetCurrentProcess().ProcessName + ".exe", "blacklist.txt"));
                            if (!System.IO.File.Exists(Process.GetCurrentProcess().MainModule.FileName.Replace(Process.GetCurrentProcess().ProcessName + ".exe", "blacklist.txt")))
                                writeLog("A problem with blacklist.txt detected and file has been deleted!");
                        }
                    }
                }
                else if (StartOrStop == "stop") {
                    Process nsf = Process.GetProcessesByName("NyanetServiceFramework").FirstOrDefault();
                    if (nsf != null) {
                        nsf.Kill();
                        nsf.Dispose();
                        writeLog("stop: NyanetServiceFramework.exe!");
                    }
                    //CMD("/C taskkill /im \"NyanetServiceFramework.exe\" /f");
                }

            }
            catch (Exception er) { writeLog(er.ToString()); }
        #endregion
        }

        private void button3_Click(object sender, EventArgs e)
        {
            #region Custom DoH server add Logic
            button3.Enabled = false;
            //Form Aç
            // Create a new instance of the Form2 class
            Form2 settingsForm = new Form2();

            // Show the settings form
            settingsForm.Show();
            //DNS Ekle
            #endregion
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            #region Call to downloadNeccesaryWindowsUpdate Logic which responsible of Downloading Windows Desktop Runtime 6.0.20 x64 and x86 
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
            #endregion
        }
        private void downloadNeccesaryWindowsUpdate()
        {
            #region Logic to Download Windows Desktop Runtime 6.0.20
            using (var client = new WebClient())
            {
                
                #region Write a log
                writeLog("Downloading windowsdesktop-runtime-6.0.20-win-x64.exe!");
                    #endregion
                client.DownloadProgressChanged += (sender, e) =>
                {
                    this.Invoke((MethodInvoker)delegate {
                        if (lang)
                            label12.Text = ("Gereksinimler indiriliyor. (windowsdesktop-runtime-6.0.20-win-x64.exe %" + e.ProgressPercentage.ToString() + " )");
                        if (!lang)
                            label12.Text = ("Downloading neccesary updates. (windowsdesktop-runtime-6.0.20-win-x64.exe %" + e.ProgressPercentage.ToString() + " )");
                    });
                };
                client.DownloadFileCompleted += (sender, e) =>
                {
                    #region Write a log
                    writeLog("Downloading windowsdesktop-runtime-6.0.20-win-x86.exe!");
                    #endregion
                    ifAvaiableInstallDotnet("windowsdesktop-runtime-6.0.20-win-x64.exe");
                    using (var client2 = new WebClient())
                    {
                        client2.DownloadProgressChanged += (sender2, e2) =>
                        {
                            this.Invoke((MethodInvoker)delegate {
                                if (lang) label12.Text = ("Gereksinimler indiriliyor. (windowsdesktop-runtime-6.0.20-win-x86.exe %" + e2.ProgressPercentage.ToString() + " )");
                                else if (!lang) label12.Text = ("Downloading neccesary updates. (windowsdesktop-runtime-6.0.20-win-x86.exe %" + e2.ProgressPercentage.ToString() + " )");
                            });
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
            #endregion
        }
        private void ifAvaiableInstallDotnet(string name)
        {
            #region Logic to Install Windows Desktop Runtime 6.0.20
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
                    if (name == "windowsdesktop-runtime-6.0.20-win-x86.exe")
                    {
                        if (lang) label12.Text = "Gereksinimleri yükleme işlemi tamamlandı!";
                        else if (!lang) label12.Text = "Downloading neccesary updates compleated!";
                        #region Write a log
                            writeLog("Installing necessary runtimes compleated!");
                            #endregion
                    }
                }
                catch (Exception) { Thread.Sleep(1000); }
            }
            #endregion
        }
        private void changeLangEnglish()
        {
            #region Logic to Change Language to English
            this.Invoke((MethodInvoker)delegate {
                #region Write a log
                    writeLog("Called changeLangEnglish() => Changing Langue to English...");
                    #endregion
                lang = false;
                groupBox2.Text = "System Info";
                label7.Text = "Work Mode:";
                button2.Text = "Stop";
                button1.Text = "Connect";
                label2.Text = "Nyanet:";
                button4.Text = "Refresh";
                button7.Text = "Unload Windivert Driver";
                groupBox1.Text = "Set DNS Settings";
                button6.Text = "Apply DNS Settings";
                label11.Text = "Detected system language ISO code is "+sysLang+"!";
                checkBox3.Text = "Download requirements";
                label12.Text = "Download requirements ";
                comboBox1.Items.Clear();
                comboBox1.Items.Add("-1 Compatible");
                comboBox1.Items.Add("-2 Fast HTTPS and Compatible");
                comboBox1.Items.Add("-3 Fast HTTP and HTTPS");
                comboBox1.Items.Add("-4 Fastest");
                comboBox1.Items.Add("-9 Default");
                comboBox1.Items.Add("-8 Default 2, Mixed Package Order");
                comboBox1.Items.Add("Default");
                comboBox1.Items.Add("-5 Auto TTL, Reverse Frag, Max Payload");
                comboBox1.Items.Add("-6 Wrong Seq, Reverse Frag, Max Payload");
                comboBox1.Items.Add("-7 Wrong Chksum, Reverse Frag, Max Payload");
                checkBox2.Text = "Start at Login";
                try
                {
                    notifyIcon1.ContextMenu.MenuItems[0].Text = "Open";
                    notifyIcon1.ContextMenu.MenuItems[1].Text = "Exit";
                }
                catch (Exception) { }
                this.Invoke((MethodInvoker)delegate
                {
                    string _CSM = comboBox1.SelectedIndex.ToString();
                    if (System.IO.File.Exists("currentServiceMode"))
                    {
                        string modeIndex = System.IO.File.ReadAllText("currentServiceMode");
                        if (modeIndex.Trim()!="-1")
                            comboBox1.SelectedIndex = Convert.ToInt32(modeIndex.Trim());
                        else comboBox1.SelectedIndex = 6;
                    }
                    else
                    {
                        try { comboBox1.SelectedIndex = 6; }
                        catch (Exception) { }
                    }
                });
            });
            #endregion
        }

        private void button7_Click(object sender, EventArgs e)
        {
            #region Logic to Unload WinDivert64.sys Driver from Windows
            this.Invoke((MethodInvoker)delegate
            {
                try { //CMD("/C taskkill /im \"NyanetServiceFramework.exe\" /f");
                    Process nsf = Process.GetProcessesByName("NyanetServiceFramework").FirstOrDefault();
                    if (nsf != null)
                    {
                        nsf.Kill();
                        nsf.Dispose();
                    }
                }
                catch (Exception) {  }
                try {
                    writeLog("Unloading WinDivert64.sys driver...");
                    CMD("/C sc stop windivert >nul 2>&1"); }
                catch (Exception) {  }
                button1.Enabled = true;
                button1.Visible = true;
                button2.Enabled = false;
                button2.Visible = false;
            });
            #endregion
        }

        private void button4_Click(object sender, EventArgs e)
        {
            #region Update Network Cards if Button is pressed
            updateNetworkCards();
            #endregion
        }

        private void getDNS()
        {
            #region Logic to Call GetDNSAdress Method to Update DNS Adresses displayed in Form Main UI
            getDNSRunning = true;
            string dns = GetDnsAdress().ToString();
            this.Invoke((MethodInvoker)delegate { if (richTextBox2.Text != dns) richTextBox2.Text = dns; });//this.Invoke((MethodInvoker)delegate { });
            Thread.Sleep(2000);
            getDNSRunning = false;
            #endregion
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            #region Logs about Time To Live (TTL)
            if (checkBox4.Checked) writeLog("Set ttl enabled.");
            else writeLog("Set ttl disabled.");
            #endregion
        }
        private String GetDnsAdress()
        {
            #region Logic to Get DNS Adresses from Valid Network Interfaces
            NetworkInterface[] networkInterfaces = NetworkInterface.GetAllNetworkInterfaces();
            try
            {
                foreach (NetworkInterface networkInterface in networkInterfaces)
                {
                    if (networkInterface.OperationalStatus == OperationalStatus.Up)
                    {
                        IPInterfaceProperties ipProperties = networkInterface.GetIPProperties();
                        IPAddressCollection dnsAddresses = ipProperties.DnsAddresses;
                        string dns = "";
                        int i = 1;
                        foreach (IPAddress dnsAdress in dnsAddresses)
                        {
                            dns = dns + "DNS " + i.ToString() + ": " + dnsAdress.ToString() + "\n";
                            if (!DNSAddr.Contains($"DNS {i.ToString()}: {dnsAdress.ToString()}"))
                            {
                                writeLog($"DNS {i.ToString()}: {dnsAdress.ToString()}");
                                DNSAddr.Add($"DNS {i.ToString()}: {dnsAdress.ToString()}");
                            }
                            i++;
                        }
                        if (DNSAddr.Count>10) DNSAddr.Clear();
                        Thread.Sleep(100);
                        return dns;
                    }
                }
            }
            catch (Exception)
            { return "DNS Adresi Bulunamadı"; }
            return "DNS Adresi Bulunamadı";
            #endregion
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            #region Logic to Set Plain DNS Redirect from DNS servers that supports using Unusual DNS Ports 
            //Update Force DNS Redirect Checkbox
            string dnsv4, dnsv4_Port, dnsv6, dnsv6_Port;
            if (comboBox3.SelectedIndex == 0)
            {
                dnsv4 = "77.88.8.8"; dnsv4_Port = "1253"; dnsv6 = "2a02:6b8::feed:0ff"; dnsv6_Port = "1253";
            }
            else if (comboBox3.SelectedIndex == 1)
            {
                dnsv4 = "9.9.9.9"; dnsv4_Port = "9953"; dnsv6 = "none"; dnsv6_Port ="none";
            }
            else if (comboBox3.SelectedIndex == 2)
            {
                dnsv4 = "208.67.222.222"; dnsv4_Port = "5353"; dnsv6 = "none"; dnsv6_Port = "none";
            }
            else
            {
                comboBox1.SelectedIndex = 0;
                dnsv4 = "77.88.8.8"; dnsv4_Port = "1253"; dnsv6 = "2a02:6b8::feed:0ff"; dnsv6_Port = "1253";
            }
            string dpPath = Process.GetCurrentProcess().MainModule.FileName.Replace(Process.GetCurrentProcess().ProcessName + ".exe", "redirDNS");
            bool dp = System.IO.File.Exists(Process.GetCurrentProcess().MainModule.FileName.Replace(Process.GetCurrentProcess().ProcessName + ".exe", "redirDNS"));
            //if (dp) checkBox6.Checked = true;
            //else checkBox6.Checked = false;
            ////////////////////////////////

            this.Invoke((MethodInvoker)delegate
            {
                if (checkBox6.Checked)
                {
                    writeLog("DNS Redirect enabled.");
                    if (!System.IO.File.Exists(dpPath))
                        System.IO.File.WriteAllText(dpPath, $"{dnsv4}|{dnsv4_Port}|{dnsv6}|{dnsv6_Port}|{comboBox3.SelectedIndex.ToString()}");
                    writeLog($"DNS Redirect: DNSv4: {dnsv4} DNSv4_Port: {dnsv4_Port} DNSv6: {dnsv6} DNSv6_Port: {dnsv6_Port}");
                    checkBox6.ForeColor = Color.Lime;
                    checkBox6.BackColor = Color.Transparent;
                    checkBox6.FlatAppearance.BorderColor = Color.Lime;
                }
                else
                {
                    writeLog("DNS Redirect disabled.");
                    if (System.IO.File.Exists(dpPath))
                        System.IO.File.Delete(dpPath);
                    checkBox6.ForeColor = Color.Red;
                    checkBox6.BackColor = Color.Transparent;
                    checkBox6.FlatAppearance.BorderColor = Color.Red;
                }
                restartNyanet();
            });
            #endregion
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            #region Logic to Update Plain DNS Redirect DNS servers
            //Update Force DNS Redirect Checkbox
            string dnsv4, dnsv4_Port, dnsv6, dnsv6_Port;
            if (comboBox3.SelectedIndex == 0)
            {
                dnsv4 = "77.88.8.8"; dnsv4_Port = "1253"; dnsv6 = "2a02:6b8::feed:0ff"; dnsv6_Port = "1253";
            }
            else if (comboBox3.SelectedIndex == 1)
            {
                dnsv4 = "9.9.9.9"; dnsv4_Port = "9953"; dnsv6 = "none"; dnsv6_Port = "none";
            }
            else if (comboBox3.SelectedIndex == 2)
            {
                dnsv4 = "208.67.222.222"; dnsv4_Port = "5353"; dnsv6 = "none"; dnsv6_Port = "none";
            }
            else
            {
                comboBox1.SelectedIndex = 0;
                dnsv4 = "77.88.8.8"; dnsv4_Port = "1253"; dnsv6 = "2a02:6b8::feed:0ff"; dnsv6_Port = "1253";
            }
            string dpPath = Process.GetCurrentProcess().MainModule.FileName.Replace(Process.GetCurrentProcess().ProcessName + ".exe", "redirDNS");
            bool dp = System.IO.File.Exists(Process.GetCurrentProcess().MainModule.FileName.Replace(Process.GetCurrentProcess().ProcessName + ".exe", "redirDNS"));
            //if (dp) checkBox6.Checked = true;
            //else checkBox6.Checked = false;
            ////////////////////////////////

            this.Invoke((MethodInvoker)delegate
            {
                if (System.IO.File.Exists(dpPath))
                {
                    System.IO.File.Delete(dpPath);
                    System.IO.File.WriteAllText(dpPath, $"{dnsv4}|{dnsv4_Port}|{dnsv6}|{dnsv6_Port}|{comboBox3.SelectedIndex.ToString()}");
                }
                if (checkBox6.Checked&&!button1.Enabled)
                        restartNyanet();
            });
            #endregion
        }

        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {
            #region Logic to Handle Magic Key check box enable or disable
            string mPath = Process.GetCurrentProcess().MainModule.FileName.Replace(Process.GetCurrentProcess().ProcessName + ".exe", "magicKey");
            bool m = System.IO.File.Exists(Process.GetCurrentProcess().MainModule.FileName.Replace(Process.GetCurrentProcess().ProcessName + ".exe", "magicKey"));
            this.Invoke((MethodInvoker)delegate
            {
                if (checkBox7.Checked)
                {
                    writeLog("Magic Key disabled.");
                    if (m) System.IO.File.Delete(mPath);
                    checkBox7.ForeColor = Color.Lime;
                    checkBox7.BackColor = Color.Transparent;
                    checkBox7.FlatAppearance.BorderColor = Color.Lime;
                }
                else
                {
                    writeLog("Magic Key enabled.");
                    if (!System.IO.File.Exists(mPath)) System.IO.File.WriteAllText(mPath, " ");
                    checkBox7.ForeColor = Color.Red;
                    checkBox7.BackColor = Color.Transparent;
                    checkBox7.FlatAppearance.BorderColor = Color.Red;
                }
            });
            #endregion
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            #region Call logic to restart Nyanet Service Framework if selected index changed
            restartNyanet();
            #endregion
        }
        private void restartNyanet()
        {
            #region Logic to Restart Nyanet Services Framework
            this.Invoke((MethodInvoker)delegate
            {
                string _CSM = comboBox1.SelectedIndex.ToString();
                if (!System.IO.File.Exists("currentServiceMode"))
                    using (StreamWriter w = System.IO.File.AppendText("currentServiceMode"))
                        w.WriteLine(_CSM);
                else
                {
                    System.IO.File.Delete("currentServiceMode");
                    using (StreamWriter w = System.IO.File.AppendText("currentServiceMode"))
                        w.WriteLine(_CSM);
                }
                try
                { //CMD("/C taskkill /im \"NyanetServiceFramework.exe\" /f");
                    if (button1.Enabled == false)
                    {
                        writeLog("Restarting Nyanet Service Framework.");
                        //Start Nyanet Again
                        button1.Visible = false;
                        button1.Enabled = false;
                        button2.Enabled = true;
                        button2.Visible = true;
                        string ttl = numericUpDown1.Value.ToString();
                        #region Save TTL to File
                        this.Invoke((MethodInvoker)delegate {
                            if (!System.IO.File.Exists("ttl"))
                                System.IO.File.Create(startupPath + "ttl").Dispose();
                            System.IO.File.WriteAllText(startupPath + "ttl", ttl);
                        });
                        #endregion
                        string ttl_opt, snusnu; //Magic key 5.12.2024
                        if (checkBox4.Checked) ttl_opt = " --set-ttl " + ttl;
                        else ttl_opt = "";
                        if (checkBox7.Checked) snusnu = " -p -q -r -s -m -a";
                        else snusnu = "";
                        if (comboBox1.SelectedIndex == 0)
                            nyanetServiceFramework("-1" + ttl_opt + snusnu, "start");//-n
                        else if (comboBox1.SelectedIndex == 1)
                            nyanetServiceFramework("-2" + ttl_opt + snusnu, "start");//-y
                        else if (comboBox1.SelectedIndex == 2)
                            nyanetServiceFramework("-3" + ttl_opt + snusnu, "start");//-a
                        else if (comboBox1.SelectedIndex == 3)
                            nyanetServiceFramework("-4" + ttl_opt + snusnu, "start");//-r
                        else if (comboBox1.SelectedIndex == 4)
                            nyanetServiceFramework("-9" + ttl_opt + snusnu, "start");//-l
                        else if (comboBox1.SelectedIndex == 5)
                            nyanetServiceFramework("-8" + ttl_opt + snusnu, "start");//-k
                        else if (comboBox1.SelectedIndex == 6)
                            nyanetServiceFramework(ttl_opt.TrimStart() + snusnu, "start");//-l
                        else if (comboBox1.SelectedIndex == 7)
                            nyanetServiceFramework("-5" + ttl_opt + snusnu, "start");//-l
                        else if (comboBox1.SelectedIndex == 8)
                            nyanetServiceFramework("-6" + ttl_opt + snusnu, "start");
                        else //if (comboBox1.SelectedIndex == 9)//
                            nyanetServiceFramework("-7" + ttl_opt + snusnu, "start");
                    }
                }
                catch (Exception ex) { writeLog("comboBox1.SelectedIndexChanged():\n" + ex.ToString()); }
            });
            #endregion
        }

        private void button6_Click(object sender, EventArgs e)
        {
            #region Logic to call setDNSServers() to you know set DoH DNS Servers
            button5.Enabled = true;
            button5.Visible = true;
            button6.Enabled = false;
            button6.Visible = false;
            SortCMDCommands.Clear();
            setDNSServers();
            #endregion
        }

        private void label5_Click(object sender, EventArgs e)
        {
            #region Label click to exit from Nyanet
            writeLog("Shutting down Nyanet Logger...");
            ExitClick(sender,e);
            //Environment.Exit(0);
            #endregion
        }

        private void label4_Click(object sender, EventArgs e)
        {
            #region Label click to minimize Nyanet
            this.WindowState = FormWindowState.Minimized;
            #endregion
        }
        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            #region Hide and Show Groupbox1 and Groupbox2
            if (checkBox5.Checked)
            {
                groupBox1.Visible = true;
                groupBox2.Visible = true;
                checkBox5.ForeColor = Color.Gold;
                checkBox5.BackColor = Color.Transparent;
                checkBox5.FlatAppearance.CheckedBackColor = Color.Transparent; checkBox5.FlatAppearance.MouseOverBackColor = Color.Transparent;
                checkBox5.FlatAppearance.MouseOverBackColor = Color.Transparent; checkBox5.FlatAppearance.CheckedBackColor = Color.Transparent; checkBox5.BackColor = Color.Transparent;
            }
            else
            {
                groupBox1.Visible = false;
                groupBox2.Visible = false;
                checkBox5.ForeColor = Color.Gold;
                checkBox5.BackColor = Color.Transparent;
            }
            #endregion
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            #region Logic to add/remove program to start at user login
            #region Write a log
            if (!appPathGet)
                writeLog("Could not find the application path.");
            #endregion
            if (checkBox2.Checked && appPathGet)
            {

                this.Invoke((MethodInvoker)delegate {

                    checkBox2.ForeColor = Color.DarkGreen;
                    checkBox2.BackColor = Color.Transparent;
                    checkBox2.FlatAppearance.BorderColor = Color.DarkGreen;
                    //checkBox2.Checked = true;
                });
                try
                {                    
                    #region Write a log
                    writeLog("Started at logon ENABLED!");
                    #endregion
                    WshShell shell = new WshShell();
                    IWshShortcut shortcut = (IWshShortcut)shell.CreateShortcut(userStartupProgramsPath + "\\nyanet.lnk");
                    shortcut.TargetPath = appExactPath;
                    shortcut.IconLocation = appExactPath; // Set the icon location (optional)
                    shortcut.Save();
                    System.IO.File.Create("runAsCurrentUser");
                }
                catch (Exception) { }
            }
            else if (!checkBox2.Checked && appPathGet)
            {
                this.Invoke((MethodInvoker)delegate {
                    checkBox2.ForeColor = Color.Red;
                    //checkBox2.BackColor = Color.Black;
                    checkBox2.FlatAppearance.BorderColor = Color.Red;
                    //checkBox2.Checked = false;
                });
                try
                {
                    #region Write a log
                    writeLog("Started at logon DISABLED!");
                    #endregion
                    if (System.IO.File.Exists(userStartupProgramsPath + "\\nyanet.lnk"))
                        System.IO.File.Delete(userStartupProgramsPath + "\\nyanet.lnk");
                    if (System.IO.File.Exists("runAsCurrentUser"))
                        System.IO.File.Delete("runAsCurrentUser");
                }
                catch (Exception){}
               
            }
            #endregion
        }
        private void CMD(string Command)
        {
            #region Add CMD Commands to List called SortCMDCommands so we can execute in order that they added!
            SortCMDCommands.Add(Command);
            #endregion
        }
        private void writeLog(string log,bool firstStart=false){
            if (log==null||log==""||log==" "||log==" \n"||log=="\n") return;
            #region Create a Debug log file called debug.txt then log all commands errors outputs etc.
            string dbPath = Process.GetCurrentProcess().MainModule.FileName.Replace(Process.GetCurrentProcess().ProcessName + ".exe", "debug.txt");
            //if (!System.IO.File.Exists(dbPath))
            //    System.IO.File.WriteAllText(dbPath, string.Empty);

            //using (FileStream fileStream = new FileStream(dbPath, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite))
            //using (StreamWriter sw = new StreamWriter(fileStream))
            //    sw.Write(GetCurrentDateTime() + ": " + log);

            if (System.IO.File.Exists(dbPath))
            {
                if (!firstStart)
                {
                    using (FileStream fileStream = new FileStream(dbPath, FileMode.Append, FileAccess.Write, FileShare.ReadWrite))
                        using (StreamWriter sw = new StreamWriter(fileStream))
                            sw.WriteLine(GetCurrentDateTime() + ": " + log);
                    //OLD Logic
                    //using (StreamWriter w = System.IO.File.AppendText(dbPath))
                    //    w.WriteLine(GetCurrentDateTime() + ": " + log);
                }
                else {
                    using (FileStream fileStream = new FileStream(dbPath, FileMode.Append, FileAccess.Write, FileShare.ReadWrite))
                        using (StreamWriter sw = new StreamWriter(fileStream))
                            sw.WriteLine("\n"+GetCurrentDateTime() + ": " + log);
                    //OLD Logic
                    //using (StreamWriter w = System.IO.File.AppendText(dbPath))
                    //    w.WriteLine("\n"+GetCurrentDateTime() + ": " + log);
                }

            }

            #endregion
        }
        private void CMDelagate(string Command)
        {
            #region Run Queued CMD Commands if CMD is not busy right now
            if (!CMDBusy)
            {
               try
                {
                    CMDBusy =true;
                    #region Run Command as new proccess
                        Process p = new Process();
                        p.StartInfo.FileName = "CMD.EXE";
                        p.StartInfo.Arguments = Command;
                        p.StartInfo.UseShellExecute = false;
                        p.StartInfo.RedirectStandardOutput = true;
                        p.StartInfo.RedirectStandardError = true;
                        p.StartInfo.CreateNoWindow = true;
                        p.Start();
                        CMDOutput = p.StandardOutput.ReadToEnd();
                        CMDError = p.StandardError.ReadToEnd();
                        p.WaitForExit();
                    #endregion
                    #region Write a log
                        if (CMDOutput.ToString().Trim()!=null&& CMDOutput.ToString().Trim() !=""&& CMDOutput.ToString().Trim() != "\n")
                        {
                            writeLog("COMMAND: CMD " + Command.ToString());
                            if(CMDOutput.Contains("˜Ÿlem baŸar\u008dyla tamamland\u008d"))
                                CMDOutput = CMDOutput.Trim().Replace("˜Ÿlem baŸar\u008dyla tamamland\u008d", "OK");
                            if (CMDOutput.Contains("\n"))
                                CMDOutput = CMDOutput.Trim().Replace("\n", $"{GetCurrentDateTime().ToString()}: OUTPUT: ");
                            writeLog("OUTPUT: " + CMDOutput.ToString().Trim());
                        }
                        else if (CMDOutput.ToString().Trim()==null)
                            writeLog("COMMAND: CMD "+Command.ToString());
                        //writeLog(CMDOutput.ToString().Trim());
                        if (CMDError.ToString().Trim() != null && CMDError.ToString().Trim() != "" && CMDError.ToString().Trim() != "\n")
                            writeLog("ERROR: "+CMDError.ToString().Trim());
                        #endregion
                    #region QueryNetworkCards, Display Network Card Info, Add Network Card Info to Lists
                    if (Command == "/C reg query \"HKLM\\SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\NetworkCards\"")
                    {
                        NetworkInterface[] adapters = NetworkInterface.GetAllNetworkInterfaces();
                        NetworkInterfaceNames.Clear();
                        NetworkInterfacesGUIDS.Clear();
                        WindowsSettingsNetAdapterGUIDList.Clear();
                        #region Write a log
                            writeLog("Querying network adapters!");
                            #endregion
                        foreach (NetworkInterface adapter in adapters)
                        {
                            string name = adapter.Name.ToString();
                            string mac = adapter.GetPhysicalAddress().ToString().Trim();
                            string desc = adapter.Description.ToString().Trim();
                            string guid = adapter.Id.ToString();
                            if (mac != null && mac != " " && mac != "" && adapter.OperationalStatus == OperationalStatus.Up)
                            {
                                if (!name.Contains("vEthernet") && "Remote NDIS based Internet Sharing Device" != name && !desc.Contains("VirtualBox") && !desc.Contains("VPN Client Adapter") && !desc.Contains("Bluetooth") && !desc.Contains("Virtual") && !desc.Contains("SonicWall Net Extender") && !desc.Contains("VMware") && !desc.Contains("VPN") && !desc.Contains("Loopback") && !desc.Contains("LogMeIn") && !desc.Contains("Hamachi") && !desc.Contains("vmxnet") && !desc.Contains("Astrill"))
                                {
                                    #region Write a log
                                    writeLog($"{name} | {desc} | {guid}");
                                    #endregion
                                    NetworkInterfaceNames.Add(name);
                                    NetworkInterfacesGUIDS.Add(guid);
                                    WindowsSettingsNetAdapterGUIDList.Add(guid);
                                }
                                this.Invoke((MethodInvoker)delegate {
                                    string updateLabel14NetworkCards = "";
                                    if (NetworkInterfaceNames.Count != 0 && NetworkInterfacesGUIDS.Count != 0)
                                        for (int i = 0; i < NetworkInterfaceNames.Count; i++)
                                                updateLabel14NetworkCards = updateLabel14NetworkCards + "\n" + NetworkInterfaceNames[i] + "\n" + NetworkInterfacesGUIDS[i];
                                    if (lang) richTextBox1.Text = "Ağ Kartları: " + updateLabel14NetworkCards;
                                    else if (!lang) richTextBox1.Text = "Network Cards: " + updateLabel14NetworkCards;
                                });
                            }
                        }
                    }
                    #endregion
                    #region If SortCMDCommands list is not null or empty remove the one
                    if (SortCMDCommands!=null&&SortCMDCommands.Count!=0)
                        SortCMDCommands.RemoveAt(0);
                    if (SortCMDCommands.Count == 0)
                    {
                        //Do some shit xd
                    }
                    #endregion
                    CMDBusy = false;
                }
                catch (Exception er) { writeLog(er.ToString());CMDBusy = false; }
            }
            #endregion
        }
        #region Not used here for reference
        private string CMDelagateReturnOutput(string Command)
        {
            try
            {
                //MessageBox.Show(Command);
                Command = Command.Replace("WindowsNT", "Windows NT");
                Process p = new Process();
                p.StartInfo.FileName = "CMD.EXE";
                p.StartInfo.Arguments = Command;
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.RedirectStandardOutput = true;
                p.StartInfo.RedirectStandardError = true;
                p.StartInfo.CreateNoWindow = true;
                p.ErrorDataReceived += new DataReceivedEventHandler(ErrorOutputHandler);
                p.Start();
                p.OutputDataReceived += HandleExeOutput;
                p.BeginOutputReadLine();
                p.WaitForExit();
                //p.BeginErrorReadLine();
                //CMDError = p.StandardError.ReadToEnd();
                //p.WaitForExit();
                //string o = p.StandardOutput.ReadToEnd();
                //MessageBox.Show(CMDelagateReturnOutputText);
                //Thread.Sleep(100);
                return CMDelagateReturnOutputText;
            }
            catch (Exception er) { writeLog("CMDelagateReturnOutput:\n"+er.ToString()); }
            return "EMPTY RESPONSE FROM CMDelegateReturnOutput(Command)";
        }
        private void HandleExeOutput(object sender, DataReceivedEventArgs e)
        {
            try
            {
                string output = e.Data;
                if (output != null&&output!=" "&&output!="")
                {
                    //MessageBox.Show(CMDelagateReturnOutputText);
                    output = output.Replace("    ", "");
                    output = output.Replace("Description", "");
                    output = output.Replace("REG_SZ", "");
                    output = output.Replace("ServiceName", "");
                    CMDelagateReturnOutputText = output.ToString();
                }
                    
            }
            catch (Exception er) { writeLog(er.ToString()); }
        }
        static void ErrorOutputHandler(object sendingProcess, DataReceivedEventArgs outLine)
        {

        }
        #endregion
        private void setDNSValues()
        {
            #region Pre Defined DoH DNS Server Variables
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
            else if (comboBox2.SelectedIndex == 2)//Quad9
            {
                dnsv4_1 = "9.9.9.11";
                dnsv4_2 = "149.112.112.11";
                dnsv6_1 = "2620:fe::11";
                dnsv6_2 = "2620:fe::fe:11";
                httpsTemplate = "https://dns11.quad9.net/dns-query";
            }
            else if (comboBox2.SelectedIndex == 3)//Adguard Adblock trackers
            {
                dnsv4_1 = "94.140.14.14";
                dnsv4_2 = "94.140.15.15";
                dnsv6_1 = "2a10:50c0::ad1:ff";
                dnsv6_2 = "2a10:50c0::ad2:ff";
                httpsTemplate = "https://dns.adguard-dns.com/dns-query";
            }
            else if (comboBox2.SelectedIndex == 4)//WikiMedia
            {
                dnsv4_1 = "185.71.138.138";
                dnsv4_2 = "185.71.138.138";
                dnsv6_1 = "2001:67c:930::1";
                dnsv6_2 = "2001:67c:930::1";
                httpsTemplate = "https://wikimedia-dns.org/dns-query";
            }
            else if (comboBox2.SelectedIndex == 5)//Controld Adblock Trecker Block
            {
                dnsv4_1 = "76.76.2.2";
                dnsv4_2 = "76.76.10.2";
                dnsv6_1 = "2606:1a40::2";
                dnsv6_2 = "2606:1a40:1::2";
                httpsTemplate = "https://freedns.controld.com/p2";
            }
            else if (comboBox2.SelectedIndex == 6)//Custom
            {
                dnsv4_1 = Cdnsv4_1;
                dnsv4_2 = Cdnsv4_2;
                dnsv6_1 = Cdnsv6_1;
                dnsv6_2 = Cdnsv6_2;
                httpsTemplate = ChttpsTemplate;
            
            }
            writeLog("Called setDNSValues() => Setting DNS Server variables...");
            #endregion
        }

        // A function that returns the current date time as a string in the specified format
        private static string GetCurrentDateTime()
        {
            #region Logic to Return Current Date Time
            DateTime now = DateTime.Now;
            string format = "dd/MM/yyyy HH:mm:ss";
            string result = now.ToString(format);
            return result;
            #endregion
        }
    }
}
