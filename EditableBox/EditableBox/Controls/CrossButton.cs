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

namespace EditableBox.Controls 
{
    /// <summary>
    
    ///
    ///     <MyNamespace:CrossButton/>
    ///
    /// </summary>
    public class CrossButton : Button
    {
        /// <summary>
        /// Initializes the <see cref="CrossButton"/> class.
        /// http://www.codeproject.com/Articles/242628/A-Simple-Cross-Button-for-WPF
        /// </summary>
        static CrossButton()
        {
            //  Set the style key, so that our control template is used.
            DefaultStyleKeyProperty.OverrideMetadata(typeof(CrossButton),
                   new FrameworkPropertyMetadata(typeof(CrossButton)));
        }
    }
}
