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

namespace Nyanet
{
    public partial class Form1 : Form
    {
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///                                                                                                                                          ///
        ///                                                                                                                                          ///
        ///                  N Y 4 R L K 0    13.10.2023 21:55:03                                                                                    ///
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
        string startup_path2 = Application.StartupPath;
        public Process p;
        string Nyanet_exe = "";
        string NyanetServiceFramework_exe = "2093b62a2dea784dc84e32a70e4a8dd4";
        string WinDivert_dll= "b2014d33ee645112d5dc16fe9d9fcbff";
        string WinDivert64_sys = "89ed5be7ea83c01d0de33d3519944aa5";
        string WinDivert32_sys = "067f9a24d630670f543d95a98cc199df";
        string runtimex64_exe="2dd697493474c5b7329f012364580ad6";
        string runtimex32_exe = "fd369cd37ea9d7c83793769989c040dc";
        public static string dnsv4_1 = "", dnsv4_2 = "", dnsv6_1 = "", dnsv6_2 = "", httpsTemplate="";
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
        string CMDOutput="", CMDError="", CMDelagateReturnOutputText="";
        string startup_path = Application.StartupPath + "\\";
        bool getDNSRunning = false;
        bool softwareProtectionServiceIsRunning=false;
        bool a833422m = false, a284373m = false,ududlrlrbastart=false,replace=false;
        bool lang = true; //false=english
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
            if (lang)MessageBox.Show("Programı yazmış olabilirim ama kullanımından doğacak hiçbir zarar veya sorumluluğu kabul etmemekteyim. İşbu yazılım size hiçbir garanti verilmeden ücretsiz sunulmuştur. -ny4rlk0\nhttps://github.com/ny4rlk0");
            else if (!lang) MessageBox.Show("I may have written the program, but I do not accept any damage or responsibility that may arise from its use. This software is provided to you free of charge, without any warranty. -ny4rlk0\nhttps://github.com/ny4rlk0");
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
            if (notFound != "")
            {
                if(lang)
                    MessageBox.Show("(" + notFound + ") Dosyalardan bazıları eksik. Bu dosyalar şimdi indirilmeye çalışılacak!\n Some of the files are missing! Gonna get them from github repo right now!");
                else if(!lang)
                    MessageBox.Show("(" + notFound + ") Dosyalardan bazıları eksik. Bu dosyalar şimdi indirilmeye çalışılacak!\n Some of the files are missing! Gonna get them from github repo right now!");
            }

            try
            {
                if (notFound != "")
                    redownloadSoftware();
            }
            catch (Exception)
            {

                MessageBox.Show("İndirme başarısız!\nDownload Failed!");
                ududlrlrbastart = false;
            }
            if (File.Exists(startup_path + "godmode.txt"))
                ududlrlrbastart = true;
            if (notFound=="")
            {
                Thread nyanetServiceStatus = new Thread(() => checkServiceStatus());
                nyanetServiceStatus.IsBackground = true;
                nyanetServiceStatus.Start();
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
                try
                {
                    updateInterfaces();
                }
                catch (Exception er){ MessageBox.Show(er.ToString()); }
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
                        if (label3.Text != "Çalışmıyor"||label3.Text!="Not Running")
                        {
                            if (lang)
                                label3.Text = "Çalışmıyor";
                            else if (!lang)
                                label3.Text = "Not Running";

                            label3.ForeColor = Color.Red;
                        }
                    });
                }
                else
                {
                    if (label3.Text != "Çalışıyor"||label3.Text!="Running")
                    {
                        this.Invoke((MethodInvoker)delegate
                        {
                            if (lang) label3.Text = "Çalışıyor";
                            else if (!lang)label3.Text = "Running";
                            
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
                catch (Exception){ }
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
                MessageBox.Show("checkServiceStatus: \n"+e.ToString());
                
            }
            
            Thread.Sleep(200);//0.05 sn bekle
            Thread nyanetServiceStatus = new Thread(() => checkServiceStatus());
            nyanetServiceStatus.IsBackground = true;
            nyanetServiceStatus.Start();
        }
        private void redownloadSoftware()
        {
            using (var client = new WebClient())
            {
                ududlrlrbastart = true;
                replace = true;
                client.DownloadProgressChanged += (sender2, e2) =>
                {
                };
                client.DownloadFileCompleted += (sender2, e2) =>
                {
                    if (Directory.Exists(startup_path + "Release"))
                        Directory.Delete(startup_path + "Release");
                    ZipFile.ExtractToDirectory("software.zip", startup_path);
                    selfDelete();
                };
                client.DownloadFileAsync(softwareMissing, "software.zip");
            }
        }
        //Set DNS Over HTTPS Settings for Windows 11
        private void setDNSServers()
        {
            setDNSValues();
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
            try
            {
                CMD("/C netsh interface ipv4 set dns name=\"Ethernet\" source=static address=none");
            }
            catch (Exception e) { MessageBox.Show(e.ToString()); }
            try{
                CMD("/C netsh interface ipv4 set dns name=\"Wi-Fi\" source=static address=none");
            }
            catch (Exception e) { MessageBox.Show(e.ToString()); }
            try
            {
                CMD("/C netsh interface ipv6 set dns name=\"Ethernet\" source=static address=none");
            }
            catch (Exception e) { MessageBox.Show(e.ToString()); }
            try
            {
                CMD("/C netsh interface ipv6 set dns name=\"Wi-Fi\" source=static address=none");
            }
            catch (Exception e) { MessageBox.Show(e.ToString()); }
            try
            {
                CMD("/C netsh interface ipv4 add dnsservers \"Wi-Fi\" " +dnsv4_1+" index=1");
            }
            catch (Exception e) { MessageBox.Show(e.ToString()); }
            try
            {
                CMD("/C netsh interface ipv4 add dnsservers \"Wi-Fi\" " +dnsv4_2+" index=2");
            }
            catch (Exception e) { MessageBox.Show(e.ToString()); }
            try
            {
                CMD("/C netsh interface ipv6 add dnsservers \"Wi-Fi\" " +dnsv6_1+" index=1");
            }
            catch (Exception e) { MessageBox.Show(e.ToString()); }
            try
            {
                CMD("/C netsh interface ipv6 add dnsservers \"Wi-Fi\" " +dnsv6_2+" index=2");
            }
            catch (Exception e) { MessageBox.Show(e.ToString()); }
            try
            {
                CMD("/C netsh interface ipv4 add dnsservers \"Ethernet\" " +dnsv4_1+" index=1");
            }
            catch (Exception e) { MessageBox.Show(e.ToString()); }
            try
            {
                CMD("/C netsh interface ipv4 add dnsservers \"Ethernet\" " +dnsv4_2+" index=2");
            }
            catch (Exception e) { MessageBox.Show(e.ToString()); }
            try
            {
                CMD("/C netsh interface ipv6 add dnsservers \"Ethernet\" " +dnsv6_1+" index=1");
            }
            catch (Exception e) { MessageBox.Show(e.ToString()); }
            try
            {
                CMD("/C netsh interface ipv6 add dnsservers \"Ethernet\" " +dnsv6_2+" index=2");
            }
            catch (Exception e) { MessageBox.Show(e.ToString()); }
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
                    if (networkAdapterGUID!=null&&networkAdapterGUID!=""&&networkAdapterGUID!=" ")
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
            catch (Exception e){ MessageBox.Show(e.ToString()); }
        }
        private void updateInterfaces()
        {
            CMD("/C reg query \"HKLM\\SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\NetworkCards\"");
            //CMD("/C reg query \"HKLM\\SYSTEM\\CurrentControlSet\\Services\\Dnscache\\InterfaceSpecificParameters\"");
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
                a833422m = true;
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
                    a833422m = false;
                    //MessageBox.Show(a833422m.ToString());
                    ifAvaiableInstallDotnet("windowsdesktop-runtime-6.0.20-win-x64.exe");
                    using (var client2 = new WebClient())
                    {
                        a284373m = true;
                        client2.DownloadProgressChanged += (sender2, e2) =>
                        {
                            
                            this.Invoke((MethodInvoker)delegate {
                                if (lang) label12.Text = ("Gereksinimler indiriliyor. (windowsdesktop-runtime-6.0.20-win-x86.exe %" + e2.ProgressPercentage.ToString() + " )");
                                else if (!lang) label12.Text = ("Downloading neccesary updates. (windowsdesktop-runtime-6.0.20-win-x86.exe %" + e2.ProgressPercentage.ToString() + " )");

                            });
                        };
                        client2.DownloadFileCompleted += (sender2, e2) =>
                        {
                            a284373m = false;
                            //MessageBox.Show(a284373m.ToString());
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
                    if (name== "windowsdesktop-runtime-6.0.20-win-x86.exe")
                    {
                        if (lang)    label12.Text="Gereksinimleri yükleme işlemi tamamlandı!";
                        else if (!lang) label12.Text = "Downloading neccesary updates compleated!";
                    }
                        
                }
                catch (Exception) { Thread.Sleep(1000); }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Invoke((MethodInvoker)delegate {
                lang = false;
                groupBox2.Text = "Software Integrity Protection Service";
                label7.Text = "Work Mode:";
                button2.Text = "Stop";
                button1.Text = "Start";
                label2.Text = "Nyanet stat:";
                button4.Text = "Refresh";
                groupBox1.Text = "Set DNS Settings";
                checkBox1.Text = "Apply DNS Settings";
                label11.Text = "Windows 11 22H2 Build 22621.2283 ❤️ Developer Version";
                label1.Text = "(Click here for MD5.)";
                checkBox3.Text = "Download Neccesary (windowsdesktop-runtime-6.0.20-win-x64.exe ve windowsdesktop-runtime-6.0.20-win-x86.exe)";
                label12.Text = "Downloading Neccesary ";
                comboBox1.Items.Clear();
                comboBox1.Items.Add("-n Compatible Mode");
                comboBox1.Items.Add("-y Fast HTTPS and Compatible Mode");
                comboBox1.Items.Add("-a Fast HTTP and HTTPS Mode");
                comboBox1.Items.Add("-r Fastest Mode");
                comboBox1.Items.Add("-l Default Mode");
                comboBox1.Items.Add("-k Default 2, Mixed Package Order Mode");
                comboBox1.Items.Add("-o Invalid Mode");
                try { comboBox1.SelectedIndex = comboBox1.FindString("-l Default Mode"); }
                catch (Exception) { }
            });

        }

        private void button4_Click(object sender, EventArgs e)
        {
            updateInterfaces();
        }

        private void getDNS()
        {
            if (!softwareProtectionServiceIsRunning)
            {
                Thread cmdBackground = new Thread(() => softwareProtectionService());
                cmdBackground.IsBackground = true;
                cmdBackground.Start();
            }
                
            getDNSRunning = true;
            string dns = GetDnsAdress().ToString();
            this.Invoke((MethodInvoker)delegate { if(richTextBox2.Text!=dns)richTextBox2.Text = dns; });
            getDNSRunning = false;
        }
        private void softwareProtectionService()
        {
            bool directoryAccessDenied = false, fileAccessDenied = false;
            softwareProtectionServiceIsRunning = true;
            List<string> danger = new List<string>();
            danger.Clear();
            if (Debugger.IsAttached)//Check for debugger if exists you have no right to use this program
            {
                try
                {
                    if (lang) File.WriteAllText(startup_path + "Uyarı.txt", "Programın bütünlüğünü bozacak ve kaynak koda ulaşmaya çalışacak davranışlardan sakınınız!\nProgram içerisindeki dosyaları değiştirmeyiniz!\nProgram ile aynı klasöre başka bir dosya ya da klasör koymayınız!\nSon kısım virüsleri engellemek için var.\n\t\t\t\t\t\t\t\t\t\t\t\t\t~ny4rlk0", Encoding.UTF8);
                    else if (!lang) File.WriteAllText(startup_path + "Warning.txt", "Avoid any behavior that will disrupt the integrity of the program and attempt to access the source code!\nDo not change the files in the program!\nDo not put another file or folder in the same folder as the program!\nThe last part is there to prevent viruses.\n\t\t\t\t\t \t\t\t\t\t\t\t\t~ny4rlk0", Encoding.UTF8);
                }
                catch (Exception){ }
                try
                {
                    if (File.Exists(startupPath + "NyanetServiceFramework.exe"))
                        File.Delete(startupPath + "NyanetServiceFramework.exe");
                    if (File.Exists(startupPath + "WinDivert.dll"))
                        File.Delete(startupPath + "WinDivert.dll");
                    if (File.Exists(startupPath + "WinDivert32.sys"))
                        File.Delete(startupPath + "WinDivert32.sys");
                    if (File.Exists(startupPath + "WinDivert64.sys"))
                        File.Delete(startupPath + "WinDivert64.sys");
                    if (File.Exists(startupPath + "windowsdesktop-runtime-6.0.20-win-x64.exe"))
                        File.Delete(startupPath + "windowsdesktop-runtime-6.0.20-win-x64.exe");
                    if (File.Exists(startupPath + "windowsdesktop-runtime-6.0.20-win-x86.exe"))
                        File.Delete(startupPath + "windowsdesktop-runtime-6.0.20-win-x86.exe");
                    selfDelete();
                }
                catch (Exception){ }

            }
            if (!ududlrlrbastart)
            {

            
            try
            {
                string[] folders = Directory.GetDirectories(startupPath);
                foreach (var folder in folders)
                {
                    danger.Add(folder);
                }
                    
            }
            catch (UnauthorizedAccessException){directoryAccessDenied = true;}
            try
            {
                string[] files = Directory.GetFiles(startupPath);
                foreach (string file in files)
                {
                    int counterD = 0;
                    if (File.Exists(startupPath + "WinDivert.dll")&&file== startupPath + "WinDivert.dll") { 
                        using (var md5 = MD5.Create())
                        {
                            using (var stream = File.OpenRead(startupPath + "WinDivert.dll"))
                            {
                                var hash = md5.ComputeHash(stream);
                                string hesaplananHash = BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
                                    if (hesaplananHash == WinDivert_dll)
                                        counterD++;
                                    else if (hesaplananHash != WinDivert_dll)
                                        redownloadSoftware();
                            }
                        }
                    }
                    else if (File.Exists(startupPath + "WinDivert32.sys") && file == startupPath + "WinDivert32.sys") { 
                        using (var md5 = MD5.Create())
                        {
                            using (var stream = File.OpenRead(startupPath + "WinDivert32.sys"))
                            {
                                var hash = md5.ComputeHash(stream);
                                string hesaplananHash = BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
                                if (hesaplananHash == WinDivert32_sys)
                                    counterD++;
                                else if (hesaplananHash != WinDivert32_sys)
                                    redownloadSoftware();
                                }
                        }
                    }
                    else if (File.Exists(startupPath + "WinDivert64.sys") && file == startupPath + "WinDivert64.sys")
                    {
                        using (var md5 = MD5.Create())
                        {
                            using (var stream = File.OpenRead(startupPath + "WinDivert64.sys"))
                            {
                                var hash = md5.ComputeHash(stream);
                                string hesaplananHash = BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
                                if (hesaplananHash == WinDivert64_sys)
                                    counterD++;
                                else if (hesaplananHash != WinDivert64_sys)
                                    redownloadSoftware();
                                }
                        }
                    }
                    else if (File.Exists(startupPath+ "windowsdesktop-runtime-6.0.20-win-x64.exe") && file == startupPath + "windowsdesktop-runtime-6.0.20-win-x64.exe" && a833422m==false)
                    {
                        using (var md5 = MD5.Create())
                        {
                            using (var stream = File.OpenRead(startupPath + "windowsdesktop-runtime-6.0.20-win-x64.exe"))
                            {
                                var hash = md5.ComputeHash(stream);
                                string hesaplananHash = BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
                                    if (hesaplananHash == runtimex64_exe)
                                        counterD++;
                                }
                        }
                    }
                    else if (File.Exists(startupPath + "windowsdesktop-runtime-6.0.20-win-x64.exe") && file == startupPath + "windowsdesktop-runtime-6.0.20-win-x64.exe"&&a833422m==true)
                    {
                        counterD++;
                    }
                    else if (File.Exists(startupPath + "windowsdesktop-runtime-6.0.20-win-x86.exe") && file == startupPath + "windowsdesktop-runtime-6.0.20-win-x86.exe"&&a284373m==false)
                    {
                        using (var md5 = MD5.Create())
                        {
                            using (var stream = File.OpenRead(startupPath + "windowsdesktop-runtime-6.0.20-win-x86.exe"))
                            {
                                var hash = md5.ComputeHash(stream);
                                string hesaplananHash = BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
                                if (hesaplananHash == runtimex32_exe)
                                    counterD++;
                            }
                        }
                    }
                    else if (File.Exists(startupPath + "windowsdesktop-runtime-6.0.20-win-x86.exe") && file == startupPath + "windowsdesktop-runtime-6.0.20-win-x86.exe" && a284373m==true)
                    {
                        counterD++;
                    }
                    else if (File.Exists(startupPath + "NyanetServiceFramework.exe") && file == startupPath + "NyanetServiceFramework.exe")
                        {
                            using (var md5 = MD5.Create())
                            {
                                using (var stream = File.OpenRead(startupPath + "NyanetServiceFramework.exe"))
                                {
                                    var hash = md5.ComputeHash(stream);
                                    string hesaplananHash = BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
                                    if (hesaplananHash == NyanetServiceFramework_exe)
                                        counterD++;
                                    else if (hesaplananHash != NyanetServiceFramework_exe)
                                        redownloadSoftware();
                                }
                            }
                        }
                    else if (File.Exists(startupPath + "Nyanet.exe") && file == startupPath + "Nyanet.exe")
                    {
                        using (var md5 = MD5.Create())
                        {
                            using (var stream = File.OpenRead(startupPath + "Nyanet.exe"))
                            {
                                var hash = md5.ComputeHash(stream);
                                string hesaplananHash = BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
                                if (hesaplananHash == Nyanet_exe)
                                    counterD++;
                                else if (hesaplananHash != Nyanet_exe)
                                    redownloadSoftware();
                                }
                        }
                    }
                    if (counterD!=1)
                        danger.Add(file);
                }
                    
            }
            catch (UnauthorizedAccessException){fileAccessDenied = true;}
            if (directoryAccessDenied||fileAccessDenied|| danger.Count != 0)//Do not mess with my software
            {
                try
                {
                    if (Directory.Exists(startupPath + "NyanetSoftwareProtectionService"))
                        Directory.Delete(startupPath + "NyanetSoftwareProtectionService");
                }
                catch (Exception){}
                try
                {
                        if (lang) File.WriteAllText(startup_path + "Uyarı.txt", "Programın bütünlüğünü bozacak ve kaynak koda ulaşmaya çalışacak davranışlardan sakınınız!\nProgram içerisindeki dosyaları değiştirmeyiniz!\nProgram ile aynı klasöre başka bir dosya ya da klasör koymayınız!\nSon kısım virüsleri engellemek için var.\n\t\t\t\t\t\t\t\t\t\t\t\t\t~ny4rlk0", Encoding.UTF8);
                        else if (!lang) File.WriteAllText(startup_path + "Warning.txt", "Avoid any behavior that will disrupt the integrity of the program and attempt to access the source code!\nDo not change the files in the program!\nDo not put another file or folder in the same folder as the program!\nThe last part is there to prevent viruses.\n\t\t\t\t\t \t\t\t\t\t\t\t\t~ny4rlk0", Encoding.UTF8);
                }
                catch (Exception){ }
                try
                {
                    string n = "NyanetSoftwareProtectionService";
                    Directory.CreateDirectory(startupPath+n);
                    File.Copy(Process.GetCurrentProcess().MainModule.FileName, startupPath + n +"\\Nyanet.exe", true);
                    File.Copy(startupPath + "NyanetServiceFramework.exe", startupPath + n + "\\NyanetServiceFramework.exe", true);
                    File.Copy(startupPath + "WinDivert.dll", startupPath + n + "\\WinDivert.dll", true);
                    File.Copy(startupPath + "WinDivert32.sys", startupPath + n + "\\WinDivert32.sys", true);
                    File.Copy(startupPath + "WinDivert64.sys", startupPath + n + "\\WinDivert64.sys", true);
                    if (File.Exists(startupPath + "NyanetServiceFramework.exe"))
                        File.Delete(startupPath + "NyanetServiceFramework.exe");
                    if (File.Exists(startupPath + "WinDivert.dll"))
                        File.Delete(startupPath + "WinDivert.dll");
                    if (File.Exists(startupPath + "WinDivert32.sys"))
                        File.Delete(startupPath + "WinDivert32.sys");
                    if (File.Exists(startupPath + "WinDivert64.sys"))
                        File.Delete(startupPath + "WinDivert64.sys");
                    if (File.Exists(startupPath + "windowsdesktop-runtime-6.0.20-win-x64.exe"))
                        File.Delete(startupPath + "windowsdesktop-runtime-6.0.20-win-x64.exe");
                    if (File.Exists(startupPath + "windowsdesktop-runtime-6.0.20-win-x86.exe"))
                        File.Delete(startupPath + "windowsdesktop-runtime-6.0.20-win-x86.exe");
                    selfDelete();
                    
                }
                catch (Exception)
                {
                    if (File.Exists(startupPath + "NyanetServiceFramework.exe"))
                        File.Delete(startupPath + "NyanetServiceFramework.exe");
                    if (File.Exists(startupPath + "WinDivert.dll"))
                        File.Delete(startupPath + "WinDivert.dll");
                    if (File.Exists(startupPath + "WinDivert32.sys"))
                        File.Delete(startupPath + "WinDivert32.sys");
                    if (File.Exists(startupPath + "WinDivert64.sys"))
                        File.Delete(startupPath + "WinDivert64.sys");
                    if (File.Exists(startupPath + "windowsdesktop-runtime-6.0.20-win-x64.exe"))
                        File.Delete(startupPath + "windowsdesktop-runtime-6.0.20-win-x64.exe");
                    if (File.Exists(startupPath + "windowsdesktop-runtime-6.0.20-win-x86.exe"))
                        File.Delete(startupPath + "windowsdesktop-runtime-6.0.20-win-x86.exe");
                    selfDelete();
                }
            }
            }
            Thread.Sleep(30000);
            Thread x = new Thread(() => softwareProtectionService());
            x.IsBackground = true;
            x.Start();
        }
        private void selfDelete()
        {
            if (File.Exists(startup_path+"nyaInternalCodes.bat"))
            {
                File.Delete(startup_path + "nyaInternalCodes.bat");
            }
            string batchScriptName = "nyaInternalCodes.bat";
            using (StreamWriter writer = File.AppendText(batchScriptName))
            {
                writer.WriteLine("taskkill /im \"Nyanet.exe\" /f");
                writer.WriteLine("taskkill /im \"Nyanet.exe\" /f");
                writer.WriteLine("taskkill /im \"Nyanet.exe\" /f");
                writer.WriteLine("taskkill /im \"Nyanet.exe\" /f");
                writer.WriteLine("del \""+ Process.GetCurrentProcess().MainModule.FileName + "\" /f");
                writer.WriteLine("del \"" + startup_path + "WinDivert.dll\" /f");
                writer.WriteLine("del \"" + startup_path + "WinDivert32.sys\" /f");
                writer.WriteLine("del \"" + startup_path + "WinDivert64.sys\" /f");
                writer.WriteLine("del \"" + startup_path + "NyanetServiceFramework.exe\" /f");
                if (replace)
                {
                    writer.WriteLine("copy \"" + startup_path + "Release\\WinDivert.dll\" \""+ startup_path2 + "\"");
                    writer.WriteLine("copy \"" + startup_path + "Release\\NyanetServiceFramework.exe\" \""+startup_path2+ "\"");
                    writer.WriteLine("copy \"" + startup_path + "Release\\WinDivert64.sys\" \"" + startup_path2+ "\"");
                    writer.WriteLine("copy \"" + startup_path + "Release\\WinDivert32.sys\" \"" + startup_path2+ "\"");
                    writer.WriteLine("copy \"" + startup_path + "Release\\Nyanet.exe\" \""+ startup_path2+ "\"");
                    writer.WriteLine("rd /Q /S \"" + startup_path + "Release\"");
                    writer.WriteLine("del \"" + startup_path + "software.zip\"");
                    //writer.WriteLine("PAUSE");
                    writer.WriteLine("START \"\" "+startup_path+ "Nyanet.exe & del \"%~f0\" & exit");
                }
                if (!replace)
                {
                    writer.WriteLine("del \"%~f0\" & exit");
                }
            }
            Process pp = new Process();
            pp.StartInfo.FileName = "CMD.EXE";
            pp.StartInfo.Arguments = "/C start \"\" \""+startupPath+ "nyaInternalCodes.bat\"";
            pp.StartInfo.UseShellExecute = false;
            pp.StartInfo.RedirectStandardOutput = false;
            pp.StartInfo.RedirectStandardError = false;
            pp.StartInfo.CreateNoWindow = true;
            pp.Start();
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
                            dns=dns+"DNS "+i.ToString()+": "+dnsAdress.ToString()+"\n";
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
        private void CMD(string Command)
        {
            SortCMDCommands.Add(Command);
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
                    //MessageBox.Show(Command);
                    Process p = new Process();
                    p.StartInfo.FileName = "CMD.EXE";
                    p.StartInfo.Arguments = Command;
                    p.StartInfo.UseShellExecute = false;
                    p.StartInfo.RedirectStandardOutput = true;
                    p.StartInfo.RedirectStandardError = true;
                    p.StartInfo.CreateNoWindow = true;
                    p.Start();
                    /*while (!p.StandardOutput.EndOfStream) {
                    CMDOutput=p.StandardOutput.ReadLine();
                    }*/
                    CMDOutput = p.StandardOutput.ReadToEnd();
                    CMDError = p.StandardError.ReadToEnd();
                    p.WaitForExit();
                    if (Command == "/C reg query \"HKLM\\SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\NetworkCards\"")
                    {
                        //NetworkInterfaceNames.Clear();
                        //NetworkInterfacesGUIDS.Clear();
                        //NetAdapterList.Clear();
                        CMDOutput = CMDOutput.Replace(" ", "");
                        CMDOutput = CMDOutput.Replace("WindowsNT", "Windows NT");
                        CMDOutput = CMDOutput.Replace("\r", "");
                        List<string> TempList = new List<string>();
                        TempList.Clear();
                        foreach (var item in Regex.Split(CMDOutput, "\n"))
                            TempList.Add(item);
                        foreach (string s in TempList)
                        {
                            if (s != null && s != "" && s != " ")
                            {
                                bool containsSameText = false;
                                foreach (string d in NetAdapterList)
                                {
                                    if (d.Contains(s))
                                    { containsSameText = true;break; }
                                }
                                if (!containsSameText)
                                    NetAdapterList.Add(s);
                            }
                                
                        }
                        //string a346e = "";
                        foreach (string NetAdapter in NetAdapterList)
                        {
                            string nadapterName=CMDelagateReturnOutput("/C reg query \""+NetAdapter+"\" /v \"Description\"");
                            nadapterName = nadapterName.Replace("    ", "");
                            nadapterName = nadapterName.Replace("Description", "");
                            nadapterName = nadapterName.Replace("REG_SZ", "");
                            string nadapterGUID=CMDelagateReturnOutput("/C reg query \"" + NetAdapter + "\" /v \"ServiceName\"");
                            nadapterGUID = nadapterGUID.Replace("    ", "");
                            nadapterGUID = nadapterGUID.Replace("ServiceName", "");
                            nadapterGUID = nadapterGUID.Replace("REG_SZ", "");
                            /*
                             * 
                             We are hiding NDIS so we can ignore it! This is intended behaviour!
                             *
                             */
                            if ((nadapterGUID!=null&&nadapterGUID!=""&&nadapterGUID!=" ")&&(nadapterName!=null&&nadapterName!=""&&nadapterName!=" "&&nadapterName != "Remote NDIS based Internet Sharing Device"))//&&nadapterName!="Remote NDIS based Internet Sharing Device"))
                            {
                                bool containsSameText = false;
                                foreach (string d in NetworkInterfaceNames)
                                {
                                    if (d.Contains(nadapterName))
                                    { containsSameText = true; break; }
                                }
                                if (!containsSameText)
                                {
                                    NetworkInterfaceNames.Add(nadapterName);
                                    NetworkInterfacesGUIDS.Add(nadapterGUID);
                                }
                                bool containsSame = false;
                                foreach (string d in WindowsSettingsNetAdapterGUIDList)
                                {
                                    if (d.Contains(nadapterGUID))
                                    { containsSame = true; break; }
                                }
                                if (!containsSame)
                                    WindowsSettingsNetAdapterGUIDList.Add(nadapterGUID);
                            }
                        }
                        this.Invoke((MethodInvoker)delegate {
                            string updateLabel14NetworkCards="";
                            if (NetworkInterfaceNames.Count !=0&&NetworkInterfacesGUIDS.Count!=0) {
                                for (int i = 0; i < NetworkInterfaceNames.Count; i++)
                                {
                                    if (NetworkInterfaceNames[i] != "Remote NDIS based Internet Sharing Device")
                                        updateLabel14NetworkCards = updateLabel14NetworkCards+"\n" + NetworkInterfaceNames[i]+"\n"+NetworkInterfacesGUIDS[i];
                                }

                            }
                            if (lang) richTextBox1.Text = "Ağ Kartları: "+updateLabel14NetworkCards;
                            else if (!lang) richTextBox1.Text = "Network Cards: " + updateLabel14NetworkCards;
                            //MessageBox.Show(NetworkInterfaceNames.Count.ToString()); Ağ kartı sayısını messagebox olarak göster Hata ayıklama için yazıldı
                        });

                    }
                    if (Command== "/C reg query \"HKLM\\SYSTEM\\CurrentControlSet\\Services\\Dnscache\\InterfaceSpecificParameters\"")
                    {/*
                        //WindowsSettingsNetAdapterGUIDList.Clear();
                        CMDOutput = CMDOutput.Replace(" ", "");
                        CMDOutput = CMDOutput.Replace("HKEY_LOCAL_MACHINE\\SYSTEM\\CurrentControlSet\\Services\\Dnscache\\InterfaceSpecificParameters\\", "");
                        CMDOutput = CMDOutput.Replace("\r", "");

                        //s != NetworkInterfacesGUIDS[NdisIndex] This and above is basically making sure we are not changing any settings on NDIS Network Adapter
                        string a34 = "";
                        foreach (var s in Regex.Split(CMDOutput, "\n"))
                        {
                            //MessageBox.Show(s);
                            if (s.Contains("Remote NDIS based Internet Sharing Device")&& s == null && s == ""&& s == " ")
                                continue;
                            //WindowsSettingsNetAdapterGUIDList.Add(s);
                            //MessageBox.Show("Added: "+s);
                            a34 = a34+s+"\n";  
                        }
                        File.WriteAllText(startup_path + "a.txt", a34.ToString(), Encoding.ASCII);*/
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
            if (lang) MessageBox.Show("Nyanet_exe: "+Nyanet_exe+"\nNyanetServiceFramework_exe: "+ NyanetServiceFramework_exe+ "\nWinDivert_dll: "+ WinDivert_dll+ "\nWinDivert64_sys: "+ WinDivert64_sys+ "\nWinDivert32_sys: "+ WinDivert32_sys+ "\nwindowsdesktop-runtime-6.0.20-win-x64.exe:\n"+runtimex64_exe+ "\nwindowsdesktop-runtime-6.0.20-win-x32.exe:\n"+runtimex32_exe+"\nMD5 uyuşmazlık durumunda yazılım kendini yeniden indirecektir!\nSırf bu özelliği eklediğim için virüs olarak görülüyor.\nKendi yazdığımız yazılımıda korumayalım, mı WTF!", "MD5 Hash");
            else if (!lang) MessageBox.Show("Nyanet_exe: " + Nyanet_exe + "\nNyanetServiceFramework_exe: " + NyanetServiceFramework_exe + "\nWinDivert_dll: " + WinDivert_dll + "\nWinDivert64_sys: " + WinDivert64_sys + "\nWinDivert32_sys: " + WinDivert32_sys + "\nwindowsdesktop-runtime-6.0.20-win-x64.exe:\n" + runtimex64_exe + "\nwindowsdesktop-runtime-6.0.20-win-x32.exe:\n" + runtimex32_exe + "\nIn case of MD5 mismatch software can download itself again!\n Just beacause of this feature it freaking shows as virus. \nShouldn't we protect the software we wrote ourselves? WTF!", "MD5 Hash");
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
        }
        static void ErrorOutputHandler(object sendingProcess, DataReceivedEventArgs outLine)
        {
            
        }
    }
}
