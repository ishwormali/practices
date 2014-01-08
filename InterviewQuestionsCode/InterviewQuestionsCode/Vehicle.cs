using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewQuestionsCode
{
    //public class Vehicle
    //{
    //    public void StallEngine()
    //    {
    //        ///this function should not be callable from outside this class
    //        ///or it should only be callable from child/inherited classes.
    //    }
    //}


    public class Vehicle
    {
        public string VechicleName { get; set; }

        public Vehicle()
        {
           // ChildName = "Children of Vehicle";
        }
        public class VehicleChild
        {
            public string ChildName { get; set; }

            public VehicleChild()
            {
               // this.VehicleName = "Parent of VehicleChild";
            }
        }
    }
}
