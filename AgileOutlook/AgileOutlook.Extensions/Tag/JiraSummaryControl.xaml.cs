﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AgileOutlook.Extensions.Tag
{
    /// <summary>
    /// Interaction logic for JiraSummaryControl.xaml
    /// </summary>
    public partial class JiraSummaryControl : UserControl
    {
        public JiraSummaryControl()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("message from button");
        }
    }
}
