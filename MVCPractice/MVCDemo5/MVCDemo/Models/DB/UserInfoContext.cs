using MVCDemo2.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCDemo.Models.DB
{
    //[ModelBinder(typeof(UserInfoModelBinder))]
    public class UserInfo
    {
        //[ReadOnly(true)]
        public int Id { get; set; }

        [Required]
        [Display(Name="First Name")]
        [StringLength(10)]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }





        public static IList<UserInfo> Users = new List<UserInfo>()
        {
            new UserInfo(){Id=1,FirstName="Ram",LastName="Bahadur"},
            new UserInfo(){Id=2,FirstName="Hari",LastName="Shrestha"},
            new UserInfo(){Id=3,FirstName="Rita",LastName="Pandey"}

        };
    }

    public class UserInfoParent
    {

        public UserInfo User { get; set; }
    }
}