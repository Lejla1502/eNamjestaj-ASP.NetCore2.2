using eNamjestaj.Data.Models;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Text;

namespace eNamjestaj.Data.Helper
{
    public class AuditAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            // Stores the Request in an Accessible object  
            var request = filterContext.HttpContext.Request;
            // Generate an audit  
            Log audit = new Log()
            {

                // Your Audit Identifier
                // Our Username (if available)  
                Username = (filterContext.HttpContext.GetLogiraniKorisnik() != null) ? filterContext.HttpContext.GetLogiraniKorisnik().KorisnickoIme : "Anonymous",
                // The IP Address of the Request  
                IPAddress = Convert.ToString(request.HttpContext.Connection.RemoteIpAddress),
                // The URL that was accessed  

                AreaAccessed = request.GetDisplayUrl().ToString(),
                // Creates our Timestamp  
                Timestamp = DateTime.UtcNow
            };
            // Stores the Audit in the Database  
            MojContext context = new MojContext();
            context.Log.Add(audit);
            context.SaveChanges();
            // Finishes executing the Action as normal   
            base.OnActionExecuting(filterContext);
        }
    }
}
