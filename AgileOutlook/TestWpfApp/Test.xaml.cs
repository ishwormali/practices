using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace TestWpfApp
{
    /// <summary>
    /// Interaction logic for Test.xaml
    /// </summary>
    public partial class Test : Window
    {
        public Test()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            string strPattern = @"CM-\w+";

            string strToTest = "CM-2345 implemented";
            string strToTest2 = "Changes in CM-2395";
            string strToTest3 = "Changes for CM-2365 complete and need to change CM-1258 ";
            var regEx = new Regex(strPattern);

            var match1 = regEx.Match(strToTest);
            
            MessageBox.Show(match1.Success ? match1.Groups[0].Value : "not match " + strToTest);

            var match2 = regEx.Match(strToTest2);
            MessageBox.Show(match2.Success ? match2.Groups[0].Value : "not match " + strToTest2);

            var matches3 = regEx.Matches(strToTest3);
            foreach (Match match3 in matches3)
            {
                foreach (Capture capt in match3.Captures    )
                {
                    MessageBox.Show(string.Format("Index={0}, Value={1}", capt.Index, capt.Value));
                }
            }

            //MessageBox.Show(match3.Success ? match3.Groups[0].Value : "not match " + strToTest3);
            //MessageBox.Show(match3.Success ? match3.Groups[1].Value : "not match " + strToTest3);
        }
    }
}
