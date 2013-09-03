using MVCDemo.Models.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCDemo2.Models
{
    public class UserInfoModelBinderProvider:IModelBinderProvider
    {
        public IModelBinder GetBinder(Type modelType)
        {
            if (typeof(UserInfo)==modelType)
            {
                return new UserInfoModelBinder();
            }

            return null;
        }
    }
}