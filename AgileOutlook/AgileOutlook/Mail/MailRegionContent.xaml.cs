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

namespace AgileOutlook.Mail
{
    /// <summary>
    /// Interaction logic for MailRegionContent.xaml
    /// </summary>
    public partial class MailRegionContent : UserControl
    {
        public MailRegionContent()
        {
            InitializeComponent();
        }

        public void AddRegionControl(UserControl control)
        {
            stackPanel1.Children.Add(control);
        }
    }
}
