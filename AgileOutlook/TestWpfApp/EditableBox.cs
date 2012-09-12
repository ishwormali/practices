using System;
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

namespace TestWpfApp
{
    /// <summary>
    /// Follow steps 1a or 1b and then 2 to use this custom control in a XAML file.
    ///
    /// Step 1a) Using this custom control in a XAML file that exists in the current project.
    /// Add this XmlNamespace attribute to the root element of the markup file where it is 
    /// to be used:
    ///
    ///     xmlns:MyNamespace="clr-namespace:TestWpfApp"
    ///
    ///
    /// Step 1b) Using this custom control in a XAML file that exists in a different project.
    /// Add this XmlNamespace attribute to the root element of the markup file where it is 
    /// to be used:
    ///
    ///     xmlns:MyNamespace="clr-namespace:TestWpfApp;assembly=TestWpfApp"
    ///
    /// You will also need to add a project reference from the project where the XAML file lives
    /// to this project and Rebuild to avoid compilation errors:
    ///
    ///     Right click on the target project in the Solution Explorer and
    ///     "Add Reference"->"Projects"->[Browse to and select this project]
    ///
    ///
    /// Step 2)
    /// Go ahead and use your control in the XAML file.
    ///
    ///     <MyNamespace:EditableListBox/>
    ///
    /// </summary>
    public class EditableBox : TextBox
    {
        
        static EditableBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(EditableBox), new FrameworkPropertyMetadata(typeof(EditableBox)));
            
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            
            ContentHost = Template.FindName(Part_ContentHost, this) as UIElement;
            ContentHost.LostFocus += new RoutedEventHandler(ContentHost_LostFocus);
            GoToDisplayState(false);
            
        }

        void ContentHost_LostFocus(object sender, RoutedEventArgs e)
        {
            GoToDisplayState(false);
        }

        protected override void OnKeyUp(KeyEventArgs e)
        {
            base.OnKeyUp(e);
            switch (e.Key)
            {
                case Key.Escape:
                    if (IsEditing)
                    {
                        this.Text = bufferText;
                    }

                    GoToDisplayState(false);
                    break;
                case Key.Enter:
                    if (IsEditing)
                    {
                        GoToDisplayState(false);
                    }
                    else
                    {
                        GoToEditState(false);
                    }

                    break;
            }
            
        }

        protected override void OnMouseDoubleClick(MouseButtonEventArgs e)
        {
            
            base.OnMouseDoubleClick(e);
            GoToEditState(false);
        }
       
        protected void GoToDisplayState(bool useTransition)
        {
            IsEditing = false;
            bufferText = string.Empty;
        }

        protected void GoToEditState(bool useTransition)
        {
            IsEditing = true;
            bufferText = this.Text;
        }

        

        private void Test()
        {
            
        }

        private UIElement ContentHost;
        private string bufferText;

        public const string Part_ContentHost = "PART_ContentHost";
        public const string Part_Display = "PART_Display";

        public static readonly DependencyProperty CornerRadiusProperty =
            DependencyProperty.Register("CornerRadius", typeof (CornerRadius), typeof (EditableBox), new PropertyMetadata(default(CornerRadius)));

        public CornerRadius CornerRadius
        {
            get { return (CornerRadius) GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }


        public bool IsEditing
        {
            get { return (bool)GetValue(IsEditingProperty); }
            set { SetValue(IsEditingProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsEditing.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsEditingProperty =
            DependencyProperty.Register("IsEditing", typeof(bool), typeof(EditableBox), new UIPropertyMetadata(false));

        
    }
}
