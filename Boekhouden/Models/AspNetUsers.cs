using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace Boekhouden
{
    partial class AspNetUsers
    { 
        public static AspNetUsers GetCurrentUser()
        {
            Entities db = new Entities();
            string currentUserId = GetCurrentId();
            return db.AspNetUsers.Single(x => x.Id == currentUserId);
        }

        public static string GetCurrentId()
        {
            return HttpContext.Current.User.Identity.GetUserId();
        }

        
    }
}