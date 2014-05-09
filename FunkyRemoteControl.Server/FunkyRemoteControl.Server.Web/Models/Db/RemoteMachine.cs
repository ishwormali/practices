using FunkyRemoteControl.Server.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FunkyRemoteControl.Server.Web.Models
{
    public class RemoteMachine
    {
        public virtual int Id { get; set; }

        public virtual ApplicationUser User { get; set; }

        public virtual string ClientName { get; set; }

        public virtual string ClientToken { get; set; }

        public virtual DateTime DateCreated { get; set; }

        public virtual DateTime? DateAuthorized { get; set; }

        public virtual DateTime DateRequested { get; set; }

        //public virtual string UserId { get; set; }

    }
}