using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AgileOutlook.Core
{
    public class AOContextMenuItem
    {
        public string Caption { get; set; }

        public int FaceId { get; set; }

        public bool IsTopMenu { get; set; }

        private IEnumerable<AOContextMenuItem> subMenus;

        public IEnumerable<AOContextMenuItem> SubMenus
        {
            get
            {
                if (subMenus == null)
                {
                    subMenus = new List<AOContextMenuItem>();
                }

                return subMenus;
            }
            set
            {
                subMenus = value;
            }
        }
    }
}
