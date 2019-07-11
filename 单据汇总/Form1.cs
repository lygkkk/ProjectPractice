﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 单据汇总
{
    public partial class Form1 : Form
    {
        public event Action<string> ConfirmClick;
        public Form1()
        {
            InitializeComponent();
            comboBox1.Items.Add("1");
            comboBox1.Items.Add("2");
            comboBox1.Items.Add("3");
            comboBox1.Items.Add("4");
            comboBox1.Items.Add("5");
            button1.Click += (sender, args) => ConfirmClick.Invoke(textBox1.Text);
        }
    }
}
