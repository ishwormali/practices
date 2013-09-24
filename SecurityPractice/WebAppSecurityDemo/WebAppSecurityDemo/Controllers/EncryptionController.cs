using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppSecurityDemo.Models;

namespace WebAppSecurityDemo.Controllers
{
    public class EncryptionController : Controller
    {
        //
        // GET: /Encryption/

        public ActionResult Index()
        {
            return View();
        }

        public string Encrypt(string input)
        {
            var encrypted = Encryption.Encrypt(input);
            return encrypted;
        }

        public string Decrypt(string input)
        {
            var decrypted = Encryption.Decrypt(input);
            return decrypted;
        }

    }
}
