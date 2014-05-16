using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Text;
using System.Web.Security;

namespace FunkyRemoteControl.ConsoleApp
{
    public class LoginManager
    {
        public bool Login(string userName, string password, out Cookie authCookie)
        {
            var request=WebRequest.Create(ConfigurationManager.AppSettings["RemoteServer"] + "api/authorize") as HttpWebRequest;
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.CookieContainer = new CookieContainer();

            var authCredentials = "userName=" + userName + "&password=" + password;
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(authCredentials);
            request.ContentLength = bytes.Length;
            using (var requestStream = request.GetRequestStream())
            {
                requestStream.Write(bytes, 0, bytes.Length);
            }

            using (var response = request.GetResponse() as HttpWebResponse)
            {
                authCookie = response.Cookies[".AspNet.ApplicationCookie"];
            }

            if (authCookie != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
