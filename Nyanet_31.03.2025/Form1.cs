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

namespace Nyanet
{
    public partial class Form1 : Form
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///                                                                                                                                          ///
        ///                                                                                                                                          ///
        ///                  N Y 4 R L K 0    31.03.2025 08:05                                                                                       ///
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
        bool CMDBusy = false;
        string CMDOutput = "", CMDError = "", CMDelagateReturnOutputText = "";
        string startup_path = Application.StartupPath + "\\";
        bool getDNSRunning = false;
        bool lang = true; //false=english
        public Form1()//This method will auto run without called!
        {
            checkAdminAccess();
            InitializeComponent();
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
            //checkBox2.FlatAppearance.MouseOverBackColor = Color.Black;
            
            checkBox2.BackColorChanged += (s, e) => {
                checkBox2.FlatAppearance.MouseOverBackColor = button7.BackColor;
            };
            checkBox2.MouseLeave += (s, e) => { checkBox2.FlatAppearance.CheckedBackColor = Color.Transparent; checkBox2.FlatAppearance.MouseOverBackColor = Color.Transparent; };
            checkBox2.MouseHover += (s, e) => { checkBox2.FlatAppearance.MouseOverBackColor = Color.Transparent; checkBox2.FlatAppearance.CheckedBackColor = Color.Transparent; checkBox2.BackColor = Color.Transparent; };
            checkBox2.FlatAppearance.CheckedBackColor = Color.Transparent; checkBox2.FlatAppearance.MouseOverBackColor = Color.Transparent;
            checkBox2.FlatAppearance.MouseOverBackColor = Color.Transparent; checkBox2.FlatAppearance.CheckedBackColor = Color.Transparent; checkBox2.BackColor = Color.Transparent;
            
            checkBox1.MouseLeave += (s, e) => { checkBox1.FlatAppearance.CheckedBackColor = Color.Transparent; checkBox1.FlatAppearance.MouseOverBackColor = Color.Transparent; };
            checkBox1.MouseHover += (s, e) => { checkBox1.FlatAppearance.MouseOverBackColor = Color.Transparent; checkBox1.FlatAppearance.CheckedBackColor = Color.Transparent; checkBox1.BackColor = Color.Transparent; };
            checkBox1.FlatAppearance.CheckedBackColor = Color.Transparent; checkBox1.FlatAppearance.MouseOverBackColor = Color.Transparent;
            checkBox1.FlatAppearance.MouseOverBackColor = Color.Transparent; checkBox1.FlatAppearance.CheckedBackColor = Color.Transparent; checkBox1.BackColor = Color.Transparent;
            
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
        }
        private void button1_Click(object sender, EventArgs e)
        {
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
        }
        private void button2_Click(object sender, EventArgs e)
        {   
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
        }
        private void Form1_Load(object sender, EventArgs e) {
            //checkAdminAccess();
            if (!runnedOnce) {runOnce(); }
            this.Activated += AfterLoading;
        }
        private void runOnce()
        {
            string mPath = Process.GetCurrentProcess().MainModule.FileName.Replace(Process.GetCurrentProcess().ProcessName + ".exe", "magicKey");
            bool m = System.IO.File.Exists(Process.GetCurrentProcess().MainModule.FileName.Replace(Process.GetCurrentProcess().ProcessName + ".exe", "magicKey"));
            if (m) checkBox7.Checked = false;

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
            label11.Text = "Tespit edilen ISO sistem dili kodu " + sysLang + "!";
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

            comboBox2.Items.Add("Cloudflare");
            comboBox2.Items.Add("Google");
            try { comboBox2.SelectedIndex = comboBox2.FindString("Cloudflare"); }
            catch (Exception) { }
            if (sysLang!="tr" && sysLang!="az")
            {
                lang = false;//english
                this.Invoke((MethodInvoker)delegate { changeLangEnglish(); });
            }
            //Uncomment for testing english language
            //lang = false;//english
            //this.Invoke((MethodInvoker)delegate { changeLangEnglish(); });

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
                MessageBox.Show("(" + notFound + ") Dosyalardan bazıları eksik. Programı yeniden indirin. Yazılım kapatılıyor. \n Some of the files are missing!\nDownload it again from: https://github.com/ny4rlk0/Nyanet\nExiting...");
                Environment.Exit(0);
            }

            if (true)
            {
                runnedOnce = true;
                Thread nyanetServiceStatus = new Thread(() => checkServiceStatus());
                nyanetServiceStatus.IsBackground = true;
                nyanetServiceStatus.Start();

                this.Invoke((MethodInvoker)delegate
                {
                    if (!System.IO.File.Exists("runAsCurrentUser"))
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
                        try { CMD("/C sc stop windivert >nul 2>&1"); }
                        catch (Exception) {  }
                    }

                });
                groupBox1.Visible = false;
                groupBox2.Visible = false;
                try { updateInterfaces(); }
                catch (Exception er) { MessageBox.Show(er.ToString()); }
                try { appExactPath = System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName; appPathGet = true; }
                catch (System.Exception) { appPathGet = false; }
                //checkBox2.FlatAppearance.CheckedBackColor = Color.Black;
                //checkBox2.FlatAppearance.MouseOverBackColor = Color.Black;
                //checkBox2.FlatAppearance.MouseDownBackColor = Color.Black;
                #region Read ttl from File
                string ttl = numericUpDown1.Value.ToString();
                if (System.IO.File.Exists("ttl"))
                {
                    ttl = System.IO.File.ReadAllText(startupPath + "ttl");
                    numericUpDown1.Value = Convert.ToInt32(ttl);
                }

                #endregion
                this.Invoke((MethodInvoker)delegate {

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


                    //Update Force DNS Redirect Checkbox
                    string dnsv4 = "77.88.8.8", dnsv4_Port = "1253", dnsv6 = "2a02:6b8::feed:0ff", dnsv6_Port = "1253";
                    string dpPath = Process.GetCurrentProcess().MainModule.FileName.Replace(Process.GetCurrentProcess().ProcessName + ".exe", "redirDNS");
                    bool dp = System.IO.File.Exists(Process.GetCurrentProcess().MainModule.FileName.Replace(Process.GetCurrentProcess().ProcessName + ".exe", "redirDNS"));
                    if (dp) checkBox6.Checked = true;
                    else checkBox6.Checked = false;
                    ////////////////////////////////

                    this.Invoke((MethodInvoker)delegate
                    {
                        if (checkBox6.Checked)
                        {
                            if (!System.IO.File.Exists(dpPath))
                                System.IO.File.WriteAllText(dpPath,$"{dnsv4}|{dnsv4_Port}|{dnsv6}|{dnsv6_Port}");
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

                    if (System.IO.File.Exists(Process.GetCurrentProcess().MainModule.FileName.Replace(Process.GetCurrentProcess().ProcessName+".exe", "runAsCurrentUser")))
                    {
                        checkBox2.Checked = true;
                        //checkBox5.Checked = true;
                        button1.Visible = false;
                        button1.Enabled = false;
                        button2.Enabled = true;
                        button2.Visible = true;
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
                        this.ShowInTaskbar = false;
                        this.WindowState = FormWindowState.Minimized;
                        this.Hide();
                    }
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

                });
 
            }
        }
        private void AfterLoading(object sender, EventArgs e)
        {
            this.Activated -= AfterLoading;

            string mPath = Process.GetCurrentProcess().MainModule.FileName.Replace(Process.GetCurrentProcess().ProcessName + ".exe", "magicKey");
            bool m = System.IO.File.Exists(Process.GetCurrentProcess().MainModule.FileName.Replace(Process.GetCurrentProcess().ProcessName + ".exe", "magicKey"));
            if (m) checkBox7.Checked = false;

            notifyIcon1.Icon = Properties.Resources.n128;
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
            #region No Multiple Instances
            System.Diagnostics.Process pThis = System.Diagnostics.Process.GetCurrentProcess();
            foreach (System.Diagnostics.Process p in System.Diagnostics.Process.GetProcesses())
                if (p.Id != pThis.Id && p.ProcessName == pThis.ProcessName)
                    Environment.Exit(0);
            #endregion
            if (this.WindowState == FormWindowState.Minimized)
            {
                //Call minimize logic from here
                this.Hide();
                this.ShowInTaskbar = false;
            }
        }
        private void Form1_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                // Minimize işlemi sırasında yapılacak işlemler
                // this.WindowState = FormWindowState.Minimized;
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
        }
        private void OpenClick(object sender, EventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
            this.Activate();
            this.Focus();
            this.ShowInTaskbar = true;
            //this.WindowState = FormWindowState.Normal;
        }
        private void ExitClick(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void checkServiceStatus() {
            try
            {
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
                        });
                    }
                }
                try
                {
                    if (!getDNSRunning) {
                        Thread cmdBackground = new Thread(() => getDNS());
                        cmdBackground.IsBackground = true;
                        cmdBackground.Start();
                    }
                }
                catch (Exception) { }
                try
                {
                    if (SortCMDCommands.Count != 0 && SortCMDCommands != null && !CMDBusy)
                    {
                        Thread cmdBackground = new Thread(() => CMDelagate(SortCMDCommands[0]));
                        cmdBackground.IsBackground = true;
                        cmdBackground.Start();
                    }

                }
                catch (Exception er) { MessageBox.Show(er.ToString()); }
                /*try
                {
                    if (SortCMDCommands.Count == 0) { 
                    updateInterfaces();
                    }
                }
                catch (Exception er){ MessageBox.Show(er.ToString()); }*/
            }
            catch (Exception e)
            {
                writeLog("checkServiceStatus: \n" + e.ToString());

            }

            Thread.Sleep(200);//0.05 sn bekle
            Thread nyanetServiceStatus = new Thread(() => checkServiceStatus());
            nyanetServiceStatus.IsBackground = true;
            nyanetServiceStatus.Start();
        }
        //Set DNS Over HTTPS Settings for Windows 11
        private void setDNSServers()
        {
            setDNSValues();
            try
            {
                #region Write a log
                writeLog("Called setDNSServers() => Changing DNS Servers...");
                #endregion
            }
            catch (Exception) { }
            /*try
            {
                if (NetworkInterfaceNames.Count == 0 || NetworkInterfacesGUIDS.Count == 0)
                    updateInterfaces();
            }
            catch (Exception){}*/
            try
            {
                CMD("/C REG ADD \"HKLM\\SOFTWARE\\Policies\\Microsoft\\Windows NT\\DNSClient\" /F");
            }
            catch (Exception e) { MessageBox.Show(e.ToString()); }
            try
            {
                CMD("/C REG ADD \"HKLM\\SOFTWARE\\Policies\\Microsoft\\Windows NT\\DNSClient\" /v DoHPolicy /t REG_DWORD /d 2 /F");//2
            }
            catch (Exception e) { MessageBox.Show(e.ToString()); }
            try
            {
                CMD("/C REG ADD \"HKLM\\SYSTEM\\CurrentControlSet\\Services\\Dnscache\\Parameters\\DohWellKnownServers\" /F");
            }
            catch (Exception e) { MessageBox.Show(e.ToString()); }
            try
            {
                CMD("/C REG ADD \"HKLM\\SYSTEM\\CurrentControlSet\\Services\\Dnscache\\Parameters\\DohWellKnownServers\\" + dnsv4_1 + "\" /F");
            }
            catch (Exception e) { MessageBox.Show(e.ToString()); }
            try
            {
                CMD("/C REG ADD \"HKLM\\SYSTEM\\CurrentControlSet\\Services\\Dnscache\\Parameters\\DohWellKnownServers\\" + dnsv4_1 + "\" /v Template /t REG_SZ /d " + httpsTemplate + " /F");
            }
            catch (Exception e) { MessageBox.Show(e.ToString()); }
            try
            {
                CMD("/C REG ADD \"HKLM\\SYSTEM\\CurrentControlSet\\Services\\Dnscache\\Parameters\\DohWellKnownServers\\" + dnsv4_2 + "\" /F");
            }
            catch (Exception e) { MessageBox.Show(e.ToString()); }
            try
            {
                CMD("/C REG ADD \"HKLM\\SYSTEM\\CurrentControlSet\\Services\\Dnscache\\Parameters\\DohWellKnownServers\\" + dnsv4_2 + "\" /v Template /t REG_SZ /d " + httpsTemplate + " /F");
            }
            catch (Exception e) { MessageBox.Show(e.ToString()); }
            try
            {
                CMD("/C REG ADD \"HKLM\\SYSTEM\\CurrentControlSet\\Services\\Dnscache\\Parameters\\DohWellKnownServers\\" + dnsv6_1 + "\" /F");
            }
            catch (Exception e) { MessageBox.Show(e.ToString()); }
            try
            {
                CMD("/C REG ADD \"HKLM\\SYSTEM\\CurrentControlSet\\Services\\Dnscache\\Parameters\\DohWellKnownServers\\" + dnsv6_1 + "\" /v Template /t REG_SZ /d " + httpsTemplate + " /F");
            }
            catch (Exception e) { MessageBox.Show(e.ToString()); }
            try
            {
                CMD("/C REG ADD \"HKLM\\SYSTEM\\CurrentControlSet\\Services\\Dnscache\\Parameters\\DohWellKnownServers\\" + dnsv6_2 + "\" /F");
            }
            catch (Exception e) { MessageBox.Show(e.ToString()); }
            try
            {
                CMD("/C REG ADD \"HKLM\\SYSTEM\\CurrentControlSet\\Services\\Dnscache\\Parameters\\DohWellKnownServers\\" + dnsv6_2 + "\" /v Template /t REG_SZ /d " + httpsTemplate + " /F");
            }
            catch (Exception e) { MessageBox.Show(e.ToString()); }
            try
            {
                CMD("/C gpupdate /force");
            }
            catch (Exception e) { MessageBox.Show(e.ToString()); }


            foreach (string networkAdapterName in NetworkInterfaceNames)
            {
                try
                {
                    CMD($"/C netsh interface ipv4 set dns name=\"{networkAdapterName}\" source=static address=none");
                }
                catch (Exception e) { MessageBox.Show(e.ToString()); }
                try
                {
                    CMD($"/C netsh interface ipv6 set dns name=\"{networkAdapterName}\" source=static address=none");
                }
                catch (Exception e) { MessageBox.Show(e.ToString()); }
                try
                {
                    CMD($"/C netsh interface ipv4 add dnsservers \"{networkAdapterName}\" " + dnsv4_1 + " index=1");
                }
                catch (Exception e) { MessageBox.Show(e.ToString()); }
                try
                {
                    CMD($"/C netsh interface ipv4 add dnsservers \"{networkAdapterName}\" " + dnsv4_2 + " index=2");
                }
                catch (Exception e) { MessageBox.Show(e.ToString()); }
                try
                {
                    CMD($"/C netsh interface ipv6 add dnsservers \"{networkAdapterName}\" " + dnsv6_1 + " index=1");
                }
                catch (Exception e) { MessageBox.Show(e.ToString()); }
                try
                {
                    CMD($"/C netsh interface ipv6 add dnsservers \"{networkAdapterName}\" " + dnsv6_2 + " index=2");
                }
                catch (Exception e) { MessageBox.Show(e.ToString()); }
            }

            //HANDLE WINDOWS SETTINGS NETWORKING GUI
            try
            {
                /*if (WindowsSettingsNetAdapterGUIDList.Count==0&&NetworkInterfacesGUIDS.Count!=0)
                {
                    foreach (var item in NetworkInterfacesGUIDS)
                        WindowsSettingsNetAdapterGUIDList.Add(item);
                }*/
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
                //CMD("Enable Checkbox1");
                this.Invoke((MethodInvoker)delegate
                {
                    checkBox1.BackColor = Color.Green;
                    checkBox1.Enabled = true;
                });
            }
            catch (Exception e) { MessageBox.Show(e.ToString()); }
        }
        private void updateInterfaces()
        {
            CMD("/C reg query \"HKLM\\SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\NetworkCards\"");
        }
        private static void checkAdminAccess()
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
        private void nyanetServiceFramework(string Options, string StartOrStop)
        {
            Thread nyanetServiceFrameworkDelagateBackground = new Thread(() => nyanetServiceFrameworkDelagate(Options, StartOrStop));
            nyanetServiceFrameworkDelagateBackground.IsBackground = true;
            nyanetServiceFrameworkDelagateBackground.Start();
        }
        private void nyanetServiceFrameworkDelagate(string Options, string StartOrStop)
        {
            try
            {
                if (System.IO.File.Exists(Process.GetCurrentProcess().MainModule.FileName.Replace(Process.GetCurrentProcess().ProcessName + ".exe", "redirDNS"))&&StartOrStop != "stop")
                {
                    string secret,redirDNSPath= Process.GetCurrentProcess().MainModule.FileName.Replace(Process.GetCurrentProcess().ProcessName + ".exe", "redirDNS");
                    using (FileStream fileStream = new FileStream(redirDNSPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                        using (StreamReader streamReader = new StreamReader(fileStream))
                            secret = streamReader.ReadToEnd();
                    string[] info = secret.Split('|');
                    string dnsv4 = info[0];
                    string dnsv4_Port = info[1];
                    string dnsv6 = info[2];
                    string dnsv6_Port = info[3];
                    if (dnsv4 != "none" && dnsv4_Port != "none" && dnsv6 != "none" && dnsv6_Port != "none")
                        Options += " --dns-addr " + dnsv4 + " --dns-port " + dnsv4_Port + " --dnsv6-addr " + dnsv6 + " --dnsv6-port " + dnsv6_Port;
                    else if (dnsv4 != "none" && dnsv4_Port != "none" && dnsv6 == "none" && dnsv6_Port == "none")
                        Options += " --dns-addr " + dnsv4 + " --dns-port " + dnsv4_Port;
                    else if (dnsv4 == "none" && dnsv4_Port == "none" && dnsv6 != "none" && dnsv6_Port != "none")
                        Options += " --dnsv6-addr " + dnsv6 + " --dnsv6-port " + dnsv6_Port;
                    writeLog($"Detected redirDNS file.\nUsing DNS Redirect dnsv4:{dnsv4} dnsv4_Port:{dnsv4_Port} dnsv6:{dnsv6} dnsv6_Port:{dnsv6_Port}");
                }
                #region Write a log
                if (StartOrStop!="stop")
                {
                    writeLog(StartOrStop+": "+"NyanetServiceFramework.exe "+Options);
                    if (System.IO.File.Exists(Process.GetCurrentProcess().MainModule.FileName.Replace(Process.GetCurrentProcess().ProcessName + ".exe", "blacklist.txt")))
                        writeLog("blacklist.txt file found!\nUsing DPI Unblock on only blacklist.txt file domains!");
                }
                #endregion
                //NyanetServiceFramework.exe --set-ttl 6 -p -q -r -s -m -a --blacklist blacklist.txt
                if (System.IO.File.Exists(Process.GetCurrentProcess().MainModule.FileName.Replace(Process.GetCurrentProcess().ProcessName + ".exe", "blacklist.txt")) && StartOrStop != "stop")
                    Options+= " --blacklist blacklist.txt";
                if (StartOrStop == "start")
                {
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
            catch (Exception er) { MessageBox.Show(er.ToString()); }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            button3.Enabled = false;
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
                try
                {
                    #region Write a log
                    writeLog("Called downloadNeccesaryWindowsUpdate() => Downloading windowsdesktop-runtime-6.0.20-win-x64.exe");
                    #endregion
                }
                catch (Exception) { }
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
                    try
                    {
                        #region Write a log
                        writeLog("Called downloadNeccesaryWindowsUpdate() => Downloading windowsdesktop-runtime-6.0.20-win-x86.exe");
                        #endregion
                    }
                    catch (Exception) { }
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
                    if (name == "windowsdesktop-runtime-6.0.20-win-x86.exe")
                    {
                        if (lang) label12.Text = "Gereksinimleri yükleme işlemi tamamlandı!";
                        else if (!lang) label12.Text = "Downloading neccesary updates compleated!";
                        try
                        {
                            #region Write a log
                            writeLog("Called ifAvaiableInstallDotnet() => Installing neccesary runtimes compleated!");
                            #endregion
                        }
                        catch (Exception) { }
                    }

                }
                catch (Exception) { Thread.Sleep(1000); }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Invoke((MethodInvoker)delegate { System.IO.File.Create(startupPath + "en").Dispose(); });
            this.Invoke((MethodInvoker)delegate { changeLangEnglish(); });
        }
        private void changeLangEnglish()
        {
            this.Invoke((MethodInvoker)delegate {
                try
                {
                    #region Write a log
                    writeLog("Called changeLangEnglish() => Changing Langue to English...");
                    #endregion
                }
                catch (Exception) { }
                lang = false;
                groupBox2.Text = "System Info";
                label7.Text = "Work Mode:";
                button2.Text = "Stop";
                button1.Text = "Connect";
                label2.Text = "Nyanet:";
                button4.Text = "Refresh";
                button7.Text = "Unload Windivert Driver";
                groupBox1.Text = "Set DNS Settings";
                checkBox1.Text = "Apply DNS Settings";
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
        }

        private void button7_Click(object sender, EventArgs e)
        {
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
                try { CMD("/C sc stop windivert >nul 2>&1"); }
                catch (Exception) {  }
                button1.Enabled = true;
                button1.Visible = true;
                button2.Enabled = false;
                button2.Visible = false;
            });
        }

        private void button4_Click(object sender, EventArgs e)
        {
            updateInterfaces();
        }

        private void getDNS()
        {
            getDNSRunning = true;
            string dns = GetDnsAdress().ToString();
            this.Invoke((MethodInvoker)delegate { if (richTextBox2.Text != dns) richTextBox2.Text = dns; });//this.Invoke((MethodInvoker)delegate { });
            getDNSRunning = false;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {

        }
        private static String GetDnsAdress()
        {
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
                            i++;
                        }
                        return dns;
                    }
                }
            }
            catch (Exception)
            { return "DNS Adresi Bulunamadı"; }
            return "DNS Adresi Bulunamadı";
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                checkBox1.BackColor = Color.Red;
                checkBox1.Checked = false;
                checkBox1.Enabled = false;
                SortCMDCommands.Clear();
                //checkBox1.Checked = false;
                //checkBox1.Enabled = false;
                //checkBox1.Visible = false;

                setDNSServers();
                //setDNSServers();
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
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
                    if (!System.IO.File.Exists(dpPath))
                        System.IO.File.WriteAllText(dpPath, $"{dnsv4}|{dnsv4_Port}|{dnsv6}|{dnsv6_Port}|{comboBox3.SelectedIndex.ToString()}");
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
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
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
            });
        }

        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {
            string dpPath = Process.GetCurrentProcess().MainModule.FileName.Replace(Process.GetCurrentProcess().ProcessName + ".exe", "magicKey");
            bool dp = System.IO.File.Exists(Process.GetCurrentProcess().MainModule.FileName.Replace(Process.GetCurrentProcess().ProcessName + ".exe", "magicKey"));
            //if (dp) checkBox6.Checked = true;
            //else checkBox6.Checked = false;
            ////////////////////////////////

            this.Invoke((MethodInvoker)delegate
            {
                if (checkBox7.Checked)
                {
                    if (System.IO.File.Exists(dpPath))
                        System.IO.File.Delete(dpPath);
                    checkBox7.ForeColor = Color.Lime;
                    checkBox7.BackColor = Color.Transparent;
                    checkBox7.FlatAppearance.BorderColor = Color.Lime;
                }
                else
                {
                    if (!System.IO.File.Exists(dpPath))
                        System.IO.File.WriteAllText(dpPath, " ");
                    checkBox7.ForeColor = Color.Red;
                    checkBox7.BackColor = Color.Transparent;
                    checkBox7.FlatAppearance.BorderColor = Color.Red;
                }
            });
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Write code to here YOOOıuhıu
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
                    if (button1.Enabled==false)
                    {
                        Process nsf = Process.GetProcessesByName("NyanetServiceFramework").FirstOrDefault();
                        if (nsf != null)
                        {
                            nsf.Kill();
                            nsf.Dispose();
                        }
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
                catch (Exception) { }
            });
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox5.Checked)
            {
                groupBox1.Visible = true;
                groupBox2.Visible = true;
                checkBox5.ForeColor = Color.White;
                checkBox5.BackColor = Color.Transparent;
                checkBox5.FlatAppearance.CheckedBackColor = Color.Transparent; checkBox5.FlatAppearance.MouseOverBackColor = Color.Transparent;
                checkBox5.FlatAppearance.MouseOverBackColor = Color.Transparent; checkBox5.FlatAppearance.CheckedBackColor = Color.Transparent; checkBox5.BackColor = Color.Transparent;
            }
            else
            {
                groupBox1.Visible = false;
                groupBox2.Visible = false;
                checkBox5.ForeColor = Color.DodgerBlue;
                checkBox5.BackColor = Color.Transparent;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (!appPathGet)
            {
                try
                {
                    #region Write a log
                    writeLog("Could not find the application path.");
                    #endregion
                }
                catch (Exception) { }

               writeLog("Could not find the application path.");
            }
                
            if (checkBox2.Checked && appPathGet)
            {

                this.Invoke((MethodInvoker)delegate {

                    checkBox2.ForeColor = Color.DarkGreen;
                    checkBox2.BackColor = Color.Transparent;
                    checkBox2.FlatAppearance.BorderColor = Color.DarkGreen;
                    //checkBox2.Checked = true;
                });

                #region Add Program To User Login
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
                #endregion

                //checkBox2.Enabled = false;

            }
            else if (!checkBox2.Checked && appPathGet)
            {
                this.Invoke((MethodInvoker)delegate {
                    checkBox2.ForeColor = Color.Red;
                    //checkBox2.BackColor = Color.Black;
                    checkBox2.FlatAppearance.BorderColor = Color.Red;
                    //checkBox2.Checked = false;
                });

                #region Remove Program From User Login
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
                #endregion
                //checkBox2.Enabled = true;

            }
        }
        private void CMD(string Command)
        {
            SortCMDCommands.Add(Command);
        }
        private void writeLog(string log){
            if (log==null||log==""||log==" "||log==" \n"||log=="\n") return;
            #region Create a Debug log file called debug.txt then log all commands errors outputs etc.
            string dbPath = Process.GetCurrentProcess().MainModule.FileName.Replace(Process.GetCurrentProcess().ProcessName + ".exe", "debug.txt");
            //if (!System.IO.File.Exists(dbPath))
            //    System.IO.File.WriteAllText(dbPath, string.Empty);
            if (System.IO.File.Exists(dbPath))
                using (StreamWriter w = System.IO.File.AppendText(dbPath))
                    w.WriteLine(GetCurrentDateTime()+"\n"+log);
            #endregion
        }
        private void CMDelagate(string Command)
        {
            if (!CMDBusy)
            {
               try
                {
                    if (Command=="Enable Checkbox1")
                    {
                        checkBox1.Visible = true;
                        checkBox1.Enabled = true;
                    }
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
                        if (CMDOutput.ToString().Trim()!=null&& CMDOutput.ToString().Trim() !=""&& CMDOutput.ToString().Trim() !="\n")
                            writeLog("COMMAND: CMD " + Command.ToString()+"\n"+"OUTPUT: "+CMDOutput.ToString().Trim());
                        else if (CMDOutput.ToString().Trim()==null)
                            writeLog("COMMAND: CMD "+Command.ToString());
                        //writeLog(CMDOutput.ToString().Trim());
                        if (CMDError.ToString().Trim() != null && CMDError.ToString().Trim() != "" && CMDError.ToString().Trim() != "\n")
                            writeLog("ERROR: "+CMDError.ToString().Trim());
                        #endregion
                    if (Command == "/C reg query \"HKLM\\SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\NetworkCards\"")
                    {
                        #region QueryNetworkCards, Display Network Card Info, Add Network Card Info to Lists
                        NetworkInterface[] adapters = NetworkInterface.GetAllNetworkInterfaces();
                        NetworkInterfaceNames.Clear();
                        NetworkInterfacesGUIDS.Clear();
                        WindowsSettingsNetAdapterGUIDList.Clear();
                        try
                        {
                            #region Write a log
                            writeLog("Queriying network adapters...");
                            #endregion
                        }
                        catch (Exception) { }
                        foreach (NetworkInterface adapter in adapters)
                        {
                            string name = adapter.Name.ToString();
                            string mac = adapter.GetPhysicalAddress().ToString().Trim();
                            string desc = adapter.Description.ToString().Trim();
                            string guid = adapter.Id.ToString();
                            if (mac != null && mac != " " && mac != "" && adapter.OperationalStatus == OperationalStatus.Up)
                            {
                                /*richTextBox1.Text += "Adapter Name:" + name + "\n";
                                richTextBox1.Text += "Device Model:" + desc + "\n";
                                richTextBox1.Text += "GUID:" + guid + "\n";
                                richTextBox1.Text += "MAC Address:" + mac + "\n";
                                richTextBox1.Text += "\n\n";*/
                                if (!name.Contains("vEthernet") && "Remote NDIS based Internet Sharing Device" != name && !desc.Contains("VirtualBox") && !desc.Contains("VPN Client Adapter") && !desc.Contains("Bluetooth") && !desc.Contains("Virtual") && !desc.Contains("SonicWall Net Extender") && !desc.Contains("VMware") && !desc.Contains("VPN") && !desc.Contains("Loopback") && !desc.Contains("LogMeIn") && !desc.Contains("Hamachi") && !desc.Contains("vmxnet") && !desc.Contains("Astrill"))
                                {
                                    try
                                    {
                                        #region Write a log
                                        writeLog(name.ToString()+"\n"+desc.ToString()+"\n"+guid.ToString());
                                        #endregion
                                    }
                                    catch (Exception) { }
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
                                    //MessageBox.Show(NetworkInterfaceNames.Count.ToString()); Ağ kartı sayısını messagebox olarak göster Hata ayıklama için yazıldı
                                });

                            }
                        }
                        #endregion
                    }
                    if (SortCMDCommands!=null&&SortCMDCommands.Count!=0)
                        SortCMDCommands.RemoveAt(0);
                    if (SortCMDCommands.Count == 0&&checkBox1.Checked)
                    {
                        this.Invoke((MethodInvoker)delegate {
                            //checkBox1.Checked = false;
                            //MessageBox.Show(comboBox2.SelectedText.ToString() + " DNS sunucusu aktifleştirildi! (2. Adım)");
                        });
                    }
                    CMDBusy = false;
                }
                catch (Exception er) { MessageBox.Show(er.ToString());CMDBusy = false; }
            }
 
        }
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
        private void label1_Click(object sender, EventArgs e)
        {
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
            {
                dnsv4_1 = Cdnsv4_1;
                dnsv4_2 = Cdnsv4_2;
                dnsv6_1 = Cdnsv6_1;
                dnsv6_2 = Cdnsv6_2;
                httpsTemplate = ChttpsTemplate;
            
            }
            try
            {
                #region Write a log
                writeLog("Called setDNSValues() => Setting DNS Server variables...");
                #endregion
            }
            catch (Exception) { }
        }
        static void ErrorOutputHandler(object sendingProcess, DataReceivedEventArgs outLine)
        {
            
        }
        // A function that returns the current date time as a string in the specified format
        private static string GetCurrentDateTime()
        {
            DateTime now = DateTime.Now;
            string format = "dd/MM/yyyy HH:mm:ss";
            string result = now.ToString(format);
            return result;
        }
    }
}
