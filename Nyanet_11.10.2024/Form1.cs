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
using System.Net.NetworkInformation;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Text.RegularExpressions;
using System.Collections;
using System.IO.Compression;
using IWshRuntimeLibrary;

namespace Nyanet
{
    public partial class Form1 : Form
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///                                                                                                                                          ///
        ///                                                                                                                                          ///
        ///                  N Y 4 R L K 0    11.10.2024 17:43                                                                                       ///
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
        bool appPathGet = false;
        string appExactPath = "";// System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName;

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
        bool createLog = true; // Hata logu oluşturuyor
        bool oneTimeDelayedLaunch = false;
        public Form1()
        {
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
            button5.FlatAppearance.MouseOverBackColor = button5.BackColor;
            button5.BackColorChanged += (s, e) => {
                button5.FlatAppearance.MouseOverBackColor = button5.BackColor;
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

        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Visible = false;
            button1.Enabled = false;
            button2.Enabled = true;
            button2.Visible = true;
            string ttl=numericUpDown1.Value.ToString();
            string ttl_opt;
            if (checkBox4.Checked)
            {
                ttl_opt= " --set-ttl "+ttl;
            }
            else ttl_opt = "";
            if (comboBox1.SelectedIndex == 0)
                nyanetServiceFramework("-1"+ttl_opt,"start");//-n
            else if (comboBox1.SelectedIndex == 1)
                nyanetServiceFramework("-2" + ttl_opt, "start");//-y
            else if (comboBox1.SelectedIndex == 2)
                nyanetServiceFramework("-3" + ttl_opt, "start");//-a
            else if (comboBox1.SelectedIndex == 3)
                nyanetServiceFramework("-4" + ttl_opt, "start");//-r
            else if (comboBox1.SelectedIndex == 4)
                nyanetServiceFramework("-9" + ttl_opt, "start");//-l
            else if (comboBox1.SelectedIndex == 5)
                nyanetServiceFramework("-8" + ttl_opt, "start");//-k
            else nyanetServiceFramework("-9" + ttl_opt, "start");//-l
        }
        private void button2_Click(object sender, EventArgs e)
        {   
            nyanetServiceFramework("NyanetServiceFramework", "stop"); //terminate nyanet
            button1.Enabled = true;
            button1.Visible = true;
            button2.Enabled = false;
            button2.Visible = false;
        }
        private void Form1_Load(object sender, EventArgs e) {
            checkAdminAccess();
            Show();
            Activate();
            Focus();
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
            if (System.IO.File.Exists(startupPath + "en"))
            {
                lang = false;//english
                this.Invoke((MethodInvoker)delegate { changeLangEnglish(); });
            }
            string notFound = "";
            if (!System.IO.File.Exists(startupPath + "NyanetServiceFramework.exe"))
                notFound += "NyanetServiceFramework.exe ";
            if (!System.IO.File.Exists(startupPath + "WinDivert.dll"))
                notFound += "WinDivert.dll ";
            if (!System.IO.File.Exists(startupPath + "WinDivert64.sys"))
                notFound += "WinDivert64.sys ";
            if (!System.IO.File.Exists(startupPath + "WinDivert32.sys"))
                notFound += "WinDivert32.sys ";
            if (notFound != "")
            {
                MessageBox.Show("(" + notFound + ") Dosyalardan bazıları eksik. Programı linkten yeniden indirin. Yazılım kapatılıyor. \n Some of the files are missing!\nDownload it again from: https://github.com/ny4rlk0/Nyanet\nExiting...");
                Environment.Exit(0);
            }

            if (notFound == "" || true)
            {
                Thread nyanetServiceStatus = new Thread(() => checkServiceStatus());
                nyanetServiceStatus.IsBackground = true;
                nyanetServiceStatus.Start();

                this.Invoke((MethodInvoker)delegate
                {
                    if (!System.IO.File.Exists("runAsCurrentUser"))
                    {
                        try { CMD("/C taskkill /im \"NyanetServiceFramework.exe\" /f"); }
                        catch (Exception ex) { MessageBox.Show(ex.ToString()); }
                        try { CMD("/C sc stop windivert"); }
                        catch (Exception ex) { MessageBox.Show(ex.ToString()); }
                    }

                });

                try { updateInterfaces(); }
                catch (Exception er) { MessageBox.Show(er.ToString()); }
                try { appExactPath = System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName; appPathGet = true; }
                catch (System.Exception) { appPathGet = false; }
                //checkBox2.FlatAppearance.CheckedBackColor = Color.Black;
                //checkBox2.FlatAppearance.MouseOverBackColor = Color.Black;
                //checkBox2.FlatAppearance.MouseDownBackColor = Color.Black;
                if (System.IO.File.Exists("runAsCurrentUser"))
                {
                    checkBox2.Checked = true;
                    button1.Visible = false;
                    button1.Enabled = false;
                    button2.Enabled = true;
                    button2.Visible = true;
                    nyanetServiceFramework("-l", "start");
                    this.WindowState = FormWindowState.Minimized;
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
                        if (System.IO.File.Exists(userStartupProgramsPath + "\\razerconnect.lnk"))
                            System.IO.File.Delete(userStartupProgramsPath + "\\razerconnect.lnk");
                        if (System.IO.File.Exists("runAsCurrentUser"))
                            System.IO.File.Create("runAsCurrentUser");
                    }
                    catch (Exception) { }
                }
                    

            }
        }
        private void checkServiceStatus() {
            try
            {
                Process[] pname = Process.GetProcessesByName("NyanetServiceFramework");
                if (pname.Length == 0)
                {
                    this.Invoke((MethodInvoker)delegate
                    {
                        if (label3.Text != "Çalışmıyor" || label3.Text != "Not Running")
                        {
                            if (lang) label3.Text = "Çalışmıyor";
                            else if (!lang) label3.Text = "Not Running";
                            label3.ForeColor = Color.Red;
                        }
                    });
                }
                else
                {
                    if (label3.Text != "Çalışıyor" || label3.Text != "Running")
                    {
                        this.Invoke((MethodInvoker)delegate
                        {
                            if (lang) label3.Text = "Çalışıyor";
                            else if (!lang) label3.Text = "Running";
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
                MessageBox.Show("checkServiceStatus: \n" + e.ToString());

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
                if (System.IO.File.Exists("debug.txt"))
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
                #region Write a log
                if (System.IO.File.Exists("debug.txt"))
                {

                    writeLog("NyanetServiceFramework "+Options+" "+StartOrStop);

                }
                #endregion
                if (StartOrStop == "start")
                {
                    Process p = new Process();
                    p.StartInfo.FileName = startupPath + "NyanetServiceFramework.exe";
                    p.StartInfo.Arguments = Options;
                    p.StartInfo.UseShellExecute = false;
                    p.StartInfo.RedirectStandardOutput = false;
                    p.StartInfo.RedirectStandardError = false;
                    p.StartInfo.CreateNoWindow = true;
                    p.Start();
                    p.WaitForExit();
                }
                else if (StartOrStop == "stop") {
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
                    if (System.IO.File.Exists("debug.txt"))
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
                        if (System.IO.File.Exists("debug.txt"))
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
                            if (System.IO.File.Exists("debug.txt"))
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
                    if (System.IO.File.Exists("debug.txt"))
                        writeLog("Called changeLangEnglish() => Changing Langue to English...");
                    #endregion
                }
                catch (Exception) { }
                lang = false;
                groupBox2.Text = "System Info";
                label7.Text = "Work Mode:";
                button2.Text = "Stop";
                button1.Text = "Connect";
                label2.Text = "Razer Connect:";
                button4.Text = "Refresh";
                //button6.Text = "S.I.P.S."; //Stopping over engineering...
                button7.Text = "Unload Windivert Driver";
                groupBox1.Text = "Set DNS Settings";
                checkBox1.Text = "Apply DNS Settings";
                label11.Text = "Windows 11 23H2 Build 22631.3085 ❤️ Razer Version";
                //label1.Text = "(Click here for MD5.)";
                checkBox3.Text = "Download requirements";
                label12.Text = "Download requirements ";
                comboBox1.Items.Clear();
                comboBox1.Items.Add("-n Compatible Mode");
                comboBox1.Items.Add("-y Fast HTTPS and Compatible Mode");
                comboBox1.Items.Add("-a Fast HTTP and HTTPS Mode");
                comboBox1.Items.Add("-r Fastest Mode");
                comboBox1.Items.Add("-l Default Mode");
                comboBox1.Items.Add("-k Default 2, Mixed Package Order Mode");
                comboBox1.Items.Add("-o Invalid Mode");
                checkBox2.Text = "Start at Login";
                try { comboBox1.SelectedIndex = comboBox1.FindString("-l Default Mode"); }
                catch (Exception) { }
            });
        }
        private void button6_Click(object sender, EventArgs e) // SIPS -> Software Integrity Protection Service
        {
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Invoke((MethodInvoker)delegate
            {
                try { CMD("/C taskkill /im \"NyanetServiceFramework.exe\" /f"); }
                catch (Exception ex) { MessageBox.Show(ex.ToString()); }
                try { CMD("/C sc stop windivert"); }
                catch (Exception ex) { MessageBox.Show(ex.ToString()); }
                button1.Enabled = true;
                button1.Visible = true;
                button2.Enabled = false;
                button2.Visible = false;
            });
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

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

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (!appPathGet)
            {
                try
                {
                    #region Write a log
                    if (System.IO.File.Exists("debug.txt"))
                        writeLog("Could not find the application path.");
                    #endregion
                }
                catch (Exception) { }

                MessageBox.Show("Could not find the application path.");
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
                    if (System.IO.File.Exists("debug.txt"))
                    {

                        writeLog("Started at logon ENABLED!");

                    }
                    #endregion
                    WshShell shell = new WshShell();
                    IWshShortcut shortcut = (IWshShortcut)shell.CreateShortcut(userStartupProgramsPath + "\\razerconnect.lnk");
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
                    if (System.IO.File.Exists("debug.txt"))
                    {

                        writeLog("Started at logon DISABLED!");

                    }
                    #endregion
                    if (System.IO.File.Exists(userStartupProgramsPath + "\\razerconnect.lnk"))
                        System.IO.File.Delete(userStartupProgramsPath + "\\razerconnect.lnk");
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
            #region Create a Debug log file called debug.txt then log all commands errors outputs etc.
            if (!System.IO.File.Exists("debug.txt"))
                System.IO.File.WriteAllText("debug.txt", string.Empty);
            if (System.IO.File.Exists("debug.txt"))
                using (StreamWriter w = System.IO.File.AppendText("debug.txt"))
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
                    if (System.IO.File.Exists("debug.txt")) {
                        #region Write a log
                            writeLog("CMD "+Command.ToString());
                            writeLog(CMDOutput.ToString());
                            writeLog(CMDError.ToString());
                        #endregion
                    }
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
                            if (System.IO.File.Exists("debug.txt"))
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
                                        if (System.IO.File.Exists("debug.txt"))
                                            writeLog(name.ToString()+"\n"+desc.ToString()+"\n"+guid.ToString()+"\n");
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
            catch (Exception er) { MessageBox.Show(er.ToString()); }
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
            catch (Exception er) { MessageBox.Show(er.ToString()); }
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
                if (System.IO.File.Exists("debug.txt"))
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
