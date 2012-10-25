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
using System.Windows.Controls.Primitives;
using System.Collections;

namespace EditableBox.Controls
{
    /// <summary>
    
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
            PART_AutoCompleteList = Template.FindName(Part_AutoCompleteListName,this) as Selector;
            PART_Popup = Template.FindName(Part_PopupName, this) as Popup;
            if (PART_Popup != null)
            {
                
            }
            GoToDisplayState(false);
            
        }

        void ContentHost_LostFocus(object sender, RoutedEventArgs e)
        {
            GoToDisplayState(false);
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            if (IsEditing)
            {
                IsPopupOpen = true;
            }
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
                        SelectCurrentItem();
                        GoToDisplayState(false);
                    }
                    else
                    {
                        GoToEditState(false);
                    }

                    break;
                case Key.Down:case Key.Up:
                    SelectNextItemIndex(e.Key);
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
            IsPopupOpen = false;
        }

        protected void GoToEditState(bool useTransition)
        {
            IsEditing = true;
            bufferText = this.Text;
        }

        protected virtual void OpenPopup(bool skipItemsCount=false)
        {
            if (EnableAutoComplete && IsEditing && (skipItemsCount==true || (GetItemsCount() > 0 && skipItemsCount==false)))
            {
                IsPopupOpen = true;
            }
            else
            {
                ClosePopup();
            }
        }

        protected virtual void ClosePopup()
        {
            IsPopupOpen = false;
            if (PART_AutoCompleteList != null)
            {
                PART_AutoCompleteList.SelectedIndex = -1;
                
            }
        }

        protected virtual int GetItemsCount()
        {
            if (PART_AutoCompleteList != null)
            {
                return (PART_AutoCompleteList.Items == null ? 0:PART_AutoCompleteList.Items.Count );
            }
            return 0;
        }

        protected virtual void InvalidateTextChange()
        {
            if (AutoCompleteCollector != null && IsEditing)
            {
                AutoCompleteDataArgs arg = new AutoCompleteDataArgs();
                arg.ExistingData = this.DataContext ?? this.Text;
                arg.PopulateData = this.PopulateData;
                AutoCompleteCollector.GatherData(arg);
            }
        }

        private void PopulateData(IEnumerable coll)
        {
            if (PART_AutoCompleteList != null)
            {
                PART_AutoCompleteList.ItemsSource = coll;
                OpenPopup();
            }
        }

        protected override void OnTextChanged(TextChangedEventArgs e)
        {
            base.OnTextChanged(e);
            InvalidateTextChange();
        }

        private void SelectNextItemIndex(Key ky)
        {
            if (PART_AutoCompleteList != null)
            {
                if (ky == Key.Up)
                {
                    if (PART_AutoCompleteList.SelectedIndex > 0)
                    {
                        PART_AutoCompleteList.SelectedIndex -= 1;
                        
                    }
                    
                }
                else if (ky == Key.Down)
                {
                    if (PART_AutoCompleteList.SelectedIndex < PART_AutoCompleteList.Items.Count-1)
                    {
                        PART_AutoCompleteList.SelectedIndex += 1;
                    }
                }
            }
            
        }

        private void SelectCurrentItem()
        {
            if (PART_AutoCompleteList != null && IsEditing && EnableAutoComplete)
            {
                if (PART_AutoCompleteList.SelectedIndex >= 0)
                {
                    var selectedItem = PART_AutoCompleteList.SelectedItem;
                    this.DataContext = selectedItem;
                }
            }
        }

        private void Test()
        {
            
        }

        private UIElement ContentHost;
        private string bufferText;
        Selector PART_AutoCompleteList;
        Popup PART_Popup;
        public const string Part_ContentHost = "PART_ContentHost";
        public const string Part_Display = "PART_Display";
        public const string Part_AutoCompleteListName = "PART_AutoCompleteList";
        public const string Part_PopupName = "PART_AutoCompletePopup";


        public bool EnableAutoComplete
        {
            get { return (bool)GetValue(EnableAutoCompleteProperty); }
            set { SetValue(EnableAutoCompleteProperty, value); }
        }

        // Using a DependencyProperty as the backing store for EnableAutoComplete.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty EnableAutoCompleteProperty =
            DependencyProperty.Register("EnableAutoComplete", typeof(bool), typeof(EditableBox), new UIPropertyMetadata(false));

        
        public bool IsPopupOpen
        {
            get { return (bool)GetValue(IsPopupOpenProperty); }
            set { SetValue(IsPopupOpenProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsPopupOpen.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsPopupOpenProperty =
            DependencyProperty.Register("IsPopupOpen", typeof(bool), typeof(EditableBox), new UIPropertyMetadata(false));


        public DataTemplate AutoCompleteItemTemplate
        {
            get { return (DataTemplate)GetValue(AutoCompleteItemTemplateProperty); }
            set { SetValue(AutoCompleteItemTemplateProperty, value); }
        }

        // Using a DependencyProperty as the backing store for AutoCompleteItemTemplate.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty AutoCompleteItemTemplateProperty =
            DependencyProperty.Register("AutoCompleteItemTemplate", typeof(DataTemplate), typeof(EditableBox), new UIPropertyMetadata(null)
            //{
            //    PropertyChangedCallback = delegate(DependencyObject d, DependencyPropertyChangedEventArgs e)
            //        {
            //            DataTemplate dt = e.NewValue as DataTemplate;
            //            EditableBox editBox = d as EditableBox;
            //            if (dt != null && editBox != null && editBox.PART_AutoCompleteList!=null)
            //            {
            //                editBox.PART_AutoCompleteList.ItemTemplate = dt;
            //            }
            //        }
            //}
            );

        

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



        public IAutoCompleteDataCollector AutoCompleteCollector
        {
            get { return (IAutoCompleteDataCollector)GetValue(AutoCompleteCollectorProperty); }
            set { SetValue(AutoCompleteCollectorProperty, value); }
        }

        // Using a DependencyProperty as the backing store for AutoCompleteCollector.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty AutoCompleteCollectorProperty =
            DependencyProperty.Register("AutoCompleteCollector", typeof(IAutoCompleteDataCollector), typeof(EditableBox), new UIPropertyMetadata(null));

        
        
    }
}
