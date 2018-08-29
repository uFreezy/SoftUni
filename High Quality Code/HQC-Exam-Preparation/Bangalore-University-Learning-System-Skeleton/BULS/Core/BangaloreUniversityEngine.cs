﻿namespace BangaloreUniversityLearningSystem.Core
{
    using System;
    using System.Linq;
    using System.Reflection;
    using Controllers;
    using Data;
    using Interfaces;
    using Models;

    public class BangaloreUniEngine : IEngine
    {
        public void Run()
        {
            var db = new BangaloreUniversityDate();
            User user = null;

            while (true)
            {
                var str = Console.ReadLine();

                if (str == null)
                {
                    break;
                }

                var route = new Route(str);
                var controllerType = Assembly.GetExecutingAssembly()
                    .GetTypes()
                    .FirstOrDefault(type => type.Name == route.ControllerName);
                var ctrl = Activator.CreateInstance(controllerType, db, user) as Controller;
                var act = controllerType.GetMethod(route.ActionName);
                var @params = MapParameters(route, act);

                try
                {
                    var view = act.Invoke(ctrl, @params) as IView;
                    Console.WriteLine(view.Display());
                    user = ctrl.User;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.InnerException.Message);
                }
            }
        }

        private static object[] MapParameters(IRoute route, MethodInfo action)
        {
            return action.GetParameters().Select<ParameterInfo, object>(p =>
            {
                if (p.ParameterType == typeof(int))
                {
                    return int.Parse(route.Parameters[p.Name]);
                }

                return route.Parameters[p.Name];
            }).ToArray();
        }
    }
}