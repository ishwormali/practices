using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ProfessionalMVCTest.Models.DB
{
    //public class UserInfoContext:DbContext
    //{
    //    public UserInfoContext()
    //        : base("DefaultConnection")
    //    {

    //    }

    //    public DbSet<UserInfoOld> UserInfoes { get; set; }
    //}

    ////[Table("UserInfo")]
    //public class UserInfoOld
    //{
    //    [Key]
    //    public int Id { get; set; }

    //    public string FirstName { get; set; }

    //    public string LastName { get; set; }

    //    public DateTime DateOfBirth { get; set; }

    //    public string Gender { get; set; }
    //}

    public class UserInfo
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }



        public static IList<UserInfo> Users = new List<UserInfo>()
        {
            new UserInfo(){Id=1,FirstName="Ram",LastName="Bahadur"},
            new UserInfo(){Id=1,FirstName="Hari",LastName="Shrestha"},
            new UserInfo(){Id=1,FirstName="Rita",LastName="Pandey"}

        };
    }
}