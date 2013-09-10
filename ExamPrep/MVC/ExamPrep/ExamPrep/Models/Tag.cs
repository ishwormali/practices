using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExamPrep.Models
{
    public class Tag
    {
       
        public Post Post { get; set; }
        public string TagName { get; set; }
    }
}