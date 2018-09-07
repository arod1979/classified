using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Web;
using System.Web.Helpers;
using System.Web.Http.Controllers;
using System.Web.Mvc;

namespace RegistrationPractice.Classes
{

    [AttributeUsage(AttributeTargets.Method)]
    public class ValidateAntiForgeryTokenOnAllPosts : System.Web.Http.Filters.AuthorizationFilterAttribute
    {
        public override void OnAuthorization(HttpActionContext _Context)
        {
            var request = _Context.Request;
            var headers = request.Headers;
            //  Only validate POSTs
            if (request.Method.Method.ToUpper() == "POST")
            {
                //  Ajax POSTs and normal form posts have to be treated differently when it comes
                //  to validating the AntiForgeryToken
                if (headers.Contains("X-Requested-With") || headers.GetValues("X-Requested-With").FirstOrDefault() == "XMLHttpRequest")
                {


                    IEnumerable<string> headervalues;
                    string headervalue = "";
                    var HeaderValue = _Context.Request.Headers.TryGetValues("__RequestVerificationToken", out headervalues);
                    if (HeaderValue)
                    {
                        headervalue = headervalues.FirstOrDefault();
                    }

                    string cookievalue = "";
                    CookieHeaderValue cookie = _Context.Request.Headers.GetCookies(AntiForgeryConfig.CookieName).FirstOrDefault();
                    if (cookie != null)
                    {
                        cookievalue = cookie[AntiForgeryConfig.CookieName].Value;
                    }



                    AntiForgery.Validate(cookievalue, headervalue);
                }
                //else
                //{
                //    new ValidateAntiForgeryTokenAttribute()
                //        .OnAuthorization(filterContext);
                //}
            }
        }
    }


    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public class RequiresRouteValuesAttribute : ActionMethodSelectorAttribute
    {
        /// <summary>    
        /// Gets required route value names.    
        /// /// </summary>    
        public ReadOnlyCollection<string> Names { get; private set; }
        /// <summary>    
        /// /// Gets or sets a value indicating whether to include form fields in the check.    
        /// /// </summary>    
        /// /// <value><c>true</c> if form fields should be included; otherwise, <c>false</c>.</value>    
        public bool IncludeFormFields { get; set; }
        /// <summary>    
        /// /// Gets or sets a value indicating whether to include query variables in the check.    
        /// /// </summary>    
        /// /// <value>    ///     
        /// <c>true</c> if query variables should be included; otherwise, <c>false</c>.    
        /// /// </value>    
        public bool IncludeQueryVariables { get; set; }

        private RequiresRouteValuesAttribute()
        {
            this.IncludeFormFields = true; this.IncludeQueryVariables = true;
        }

        /// <summary>    
        /// /// Initializes a new instance of the <see cref="RequiresRouteValuesAttribute"/> class.    
        /// /// </summary>    
        /// /// <param name="commaSeparatedNames">Comma separated required route values names.</param>    
        public RequiresRouteValuesAttribute(string commaSeparatedNames) :
            this((commaSeparatedNames ?? string.Empty).Split(','))
        {        // does nothing    
        }

        public RequiresRouteValuesAttribute(IEnumerable<string> names) : this()
        {
            if (names == null || names.Count().Equals(0)) { throw new ArgumentNullException("names"); }
            // store names        
            this.Names = new ReadOnlyCollection<string>(names.Select(val => val.Trim()).ToList());
        }





        /// <summary>    
        /// /// Determines whether the action method selection is valid for the specified controller context.    
        /// /// </summary>    
        /// /// <param name="controllerContext">The controller context.</param>    
        /// /// <param name="methodInfo">Information about the action method.</param>    
        /// /// <returns>    
        /// /// true if the action method selection is valid for the specified controller context; otherwise, false.    
        /// /// </returns>    
        public override bool IsValidForRequest(ControllerContext controllerContext, MethodInfo methodInfo)
        {


            if (controllerContext == null)
            {
                throw new ArgumentNullException("controllerContext");
            }

            // always include route values        
            HashSet<string> uniques = new HashSet<string>(controllerContext.RouteData.Values.Keys);

            // include form fields if required        
            if (this.IncludeFormFields)
            {
                uniques.UnionWith(controllerContext.HttpContext.Request.Form.AllKeys);
            }

            // include query string variables if required        
            if (this.IncludeQueryVariables)
            {
                uniques.UnionWith(controllerContext.HttpContext.Request.QueryString.AllKeys);
            }

            // determine whether all route values are present        
            return this.Names.All(val => uniques.Contains(val));
        }

    }
}

