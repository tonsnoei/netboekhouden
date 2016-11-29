using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;

namespace Boekhouden
{
    public partial class Tenant
    {
        /// <summary>
        /// Returns the Id of the current tenant.
        /// </summary>
        public static Guid CurrentId
        {
            get
            {
                Guid? id = GetIdFromSession();
                if (id == null)
                    id = GetIdFromDB();

                if (id == null)
                {
                    id = CreateNew().Id;
                    AddIdToSession(id.Value);
                }

                return id.Value;
            }
        }

        public static Tenant GetCurrent(Entities db)
        {            
            Tenant tenant = db.Tenants.SingleOrDefault(x => x.Id == CurrentId);
            return tenant;
        }

        private static Tenant CreateNew()
        {
            Entities db = new Entities();

            Tenant tenant = new Tenant();
            tenant.Id = Guid.NewGuid();
            tenant.CreationDate = DateTime.Now;
            db.Tenants.Add(tenant);
            string currentUserId = AspNetUsers.GetCurrentId();
            AspNetUsers user = db.AspNetUsers.SingleOrDefault(x => x.Id == currentUserId );
            user.TenantId = tenant.Id;
            db.SaveChanges();
            return tenant;
        }

        private static Guid? GetIdFromDB()
        {
            AspNetUsers user = AspNetUsers.GetCurrentUser();
            if (user != null)
                return user.TenantId;
            else
                return null;
        }

        private static Guid? GetIdFromSession()
        {
            object id = HttpContext.Current.Session["tenant_id_" + AspNetUsers.GetCurrentId()];
            if (id == null)
                return null;
            else
            {
                return (Guid)id;
            }
        }

        private static void AddIdToSession(Guid id)
        {
            HttpContext.Current.Session["tenant_id_" + AspNetUsers.GetCurrentId()] = id;
        }
    }
}