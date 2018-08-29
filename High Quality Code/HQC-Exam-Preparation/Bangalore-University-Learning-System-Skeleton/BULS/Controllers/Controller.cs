namespace BangaloreUniversityLearningSystem.Controllers
{
    using System;
    using System.Diagnostics;
    using System.Linq;
    using System.Reflection;
    using Core.Interfaces;
    using Models;
    using Utilities;

    public abstract class Controller
    {       
        public User User { get; set; }

        public bool HasCurrentUser
        {
            get { return this.User != null; }
        }

        protected IBangaloreUniversityDate Data { get; set; }

        protected IView View(object model)
        {
            var fullNamespace = this.GetType().Namespace;
            var firstSeparatorIndex = fullNamespace.IndexOf(".");
            var baseNamespace = fullNamespace.Substring(0, firstSeparatorIndex);
            var controllerName = this.GetType().Name.Replace("Controller", string.Empty);
            var actionName = new StackTrace().GetFrame(1).GetMethod().Name;
            var fullPath = baseNamespace + ".Views." + controllerName + "." + actionName;
            var viewType = Assembly
                .GetExecutingAssembly()
                .GetType(fullPath);
            return Activator.CreateInstance(viewType, model) as IView;
        }

        protected void EnsureAuthorization(params Role[] roles)
        {
            if (!this.HasCurrentUser)
            {
                throw new ArgumentException("There is no currently logged in user.");
            }

            foreach (var u in this.Data.Users.GetAll())
            {
                if (!roles.Any(role => this.User.IsInRole(role)))
                {
                    throw new DivideByZeroException("The current user is not authorized to perform this operation.");
                }                  
            }           
        }
    }
}