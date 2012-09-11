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
    public class EditableBox : ContentControl
    {
        
        static EditableBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(EditableBox), new FrameworkPropertyMetadata(typeof(EditableBox)));
            ContentPresenter
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            
            textbox_Edit = Template.FindName(Part_Edit,this) as TextBox;
            if (textbox_Edit != null)
            {
                textbox_Edit.LostFocus += new RoutedEventHandler(textbox_Edit_LostFocus);
            }

            displayControl = Template.FindName(Part_Display, this) as FrameworkElement;
            GoToDisplayState(false);
            

        }

        protected override void OnMouseDoubleClick(MouseButtonEventArgs e)
        {
            
            base.OnMouseDoubleClick(e);
            if (this.CurrentStateMode == EditableBoxStateMode.Display)
            {
                GoToEditState(true);
            }

            else if (this.CurrentStateMode==EditableBoxStateMode.Edit)
            {
                GoToDisplayState(true);
            }
        }
        
        void textbox_Edit_LostFocus(object sender, RoutedEventArgs e)
        {
            
            GoToDisplayState(false);
            
        }

        

        protected void GoToDisplayState(bool useTransition)
        {
            this.CurrentStateMode = EditableBoxStateMode.Display;

            VisualStateManager.GoToState(this, DisplayState, useTransition);
            ChangeDisplayControlVisibility(Visibility.Visible);
            ChangeEditBoxVisibility(Visibility.Hidden);
            
        }

        protected void GoToEditState(bool useTransition)
        {
            this.CurrentStateMode = EditableBoxStateMode.Display;

            VisualStateManager.GoToState(this, EditState, useTransition);
            ChangeDisplayControlVisibility(Visibility.Hidden);
            ChangeEditBoxVisibility(Visibility.Visible);
            if (textbox_Edit != null)
            {
                textbox_Edit.Focus();
                
            }
        }

        protected virtual void ChangeEditBoxVisibility(Visibility visibility)
        {
            if (textbox_Edit!=null)
            {
                textbox_Edit.Visibility = visibility;
            }
        }

        protected virtual void ChangeDisplayControlVisibility(Visibility visibility)
        {
            if (displayControl != null)
            {
                displayControl.Visibility = visibility;
            }
        }

        private void Test()
        {
            
        }

        private TextBox textbox_Edit;
        private FrameworkElement displayControl;
        private const string EditState = "Edit";
        private const string DisplayState = "Display";
        private DataTemplate DisplayTemplate = null;

        public const string Part_Edit = "PART_EditBox";
        public const string Part_Display = "PART_Display";

        public static readonly DependencyProperty EditableTemplateProperty =
            DependencyProperty.Register("EditableTemplate", typeof (DataTemplate), typeof (EditableBox), new UIPropertyMetadata(default(DataTemplate)));

        public DataTemplate EditableTemplate
        {
            get { return (DataTemplate) GetValue(EditableTemplateProperty); }
            set { SetValue(EditableTemplateProperty, value); }
        }

        public static readonly DependencyProperty CornerRadiusProperty =
            DependencyProperty.Register("CornerRadius", typeof (CornerRadius), typeof (EditableBox), new PropertyMetadata(default(CornerRadius)));

        public CornerRadius CornerRadius
        {
            get { return (CornerRadius) GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }

        public static readonly DependencyProperty CurrentStateModeProperty =
            DependencyProperty.Register("CurrentStateMode", typeof (EditableBoxStateMode), typeof (EditableBox), new PropertyMetadata(default(EditableBoxStateMode)));

        public EditableBoxStateMode CurrentStateMode
        {
            get { return (EditableBoxStateMode) GetValue(CurrentStateModeProperty); }
            set { SetValue(CurrentStateModeProperty, value); }
        }   

        public static readonly DependencyProperty EditableTextProperty =
            DependencyProperty.Register("EditableText", typeof(string), typeof(EditableBox),new UIPropertyMetadata(default(string)));

        public string EditableText
        {
            get { return (string)GetValue(EditableTextProperty); }
            set { SetValue(EditableTextProperty, value); }
        }   

    }
}
