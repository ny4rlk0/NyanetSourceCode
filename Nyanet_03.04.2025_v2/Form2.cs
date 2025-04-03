using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nyanet
{

    public partial class Form2 : Form
    {
        private Form1 _form1;
        public Form2(Form1 form1)
        {
            InitializeComponent();
            _form1 = form1; // Store the reference to Form1
            FormClosing += Form2_FormClosing;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ((textBox1.Text=="" || textBox2.Text=="" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "") && (textBox1.Text == null || textBox2.Text == null || textBox3.Text == null || textBox4.Text == null || textBox5.Text == null || textBox6.Text == null))
            {
                MessageBox.Show("Don't leave empty textbox!\nBoş giriş alanı bırakma!");
            }
            else {

                Form1.Cdnsv4_1 = textBox1.Text;
                Form1.Cdnsv4_2 = textBox2.Text;
                Form1.Cdnsv6_1 = textBox3.Text;
                Form1.Cdnsv6_2 = textBox4.Text;
                Form1.ChttpsTemplate = textBox5.Text;
                if (_form1.comboBox2.Items.Count == 7)
                {
                    _form1.comboBox2.SelectedIndex = 5;
                    _form1.comboBox2.Items.RemoveAt(6);//0,1,2<= Hedef Custom DNS Sil
                }
                _form1.comboBox2.Items.Add(textBox6.Text);
                _form1.comboBox2.SelectedIndex = 6;
                _form1.button3.Enabled = true;
                this.Close();
            }

        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
                    _form1.button3.Enabled = true;
        }
    }
}
