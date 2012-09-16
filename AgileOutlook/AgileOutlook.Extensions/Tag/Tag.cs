using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace AgileOutlook.Extensions.Tag
{
    public class Tag : INotifyPropertyChanged
    {

        private string tagSource;
        public string TagSource 
        {
            get 
            {
                return tagSource;
            }
            set
            {
                tagSource = value;
                RaisePropertyChanged("TagSource");
            }
        }

        private string tagName;
        public string TagName
        {
            get
            {
                return tagName;
            }
            set
            {
                tagName = value;
                RaisePropertyChanged("TagName");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string name)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
    }
}
