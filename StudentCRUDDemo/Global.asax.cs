using StudentCRUDDemo.BLL.Services;
using StudentCRUDDemo.DAL;
using StudentCRUDDemo.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Unity;
using Unity.AspNet.Mvc;

namespace StudentCRUDDemo
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
 

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            RegisterUnityContainer();
        }

        private void RegisterUnityContainer()
        {
            var container = new UnityContainer();

            
            container.RegisterType<IStudentService, StudentService>();
            container.RegisterType<IStudentRepository, StudentRepository>();
            container.RegisterType<IRoleRepository, RoleRepository>();
            container.RegisterType<IUserRepository, UserRepository>();
            container.RegisterType<IUserService, UserService>();

            
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }

        //this is for preventing or security for the web page/data when we hit to back button on web page then it not shows secured data/essential details it only shows when user is logged in

        //protected void Application_AcquireRequestState(object sender, EventArgs e)
        //{
        //    HttpContext context = HttpContext.Current;

        //    var allowedPages = new List<string> { "/Student/Home", "/Student/Contact", "/Student/About", "/User/CreateUser" };

        //    if (context.Session["Role"] == null &&
        //        !context.Request.Url.AbsolutePath.Contains("Login") &&
        //        !allowedPages.Any(page => context.Request.Url.AbsolutePath.Contains(page)))
        //    {
        //        context.Response.Redirect("~/User/Login");
        //    }
        //}
    }
}
