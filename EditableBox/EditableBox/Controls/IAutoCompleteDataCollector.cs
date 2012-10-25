using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace EditableBox.Controls
{
    public interface IAutoCompleteDataCollector
    {
        void GatherData(AutoCompleteDataArgs arg);
    }

    public delegate void PopulateDataDel(IEnumerable coll);

    public class AutoCompleteDataArgs
    {
        public object ExistingData { get; set; }

        public PopulateDataDel PopulateData { get; set; } 
    }
}
