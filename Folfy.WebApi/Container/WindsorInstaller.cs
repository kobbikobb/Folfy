using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Folfy.WebApi.Data;
using Folfy.WebApi.Models;
using Folfy.WebApi.Models.Data;

namespace Folfy.WebApi.Container
{
    public class WindsorInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Classes.FromThisAssembly().
                Where(x => x.Name.EndsWith("Controller")).
                LifestylePerWebRequest());

            container.Register(Component.For<IRepository<Scorecard>>().ImplementedBy<ScorecardRepository>().LifestylePerWebRequest());
            container.Register(Component.For<IRepository<Hole>>().ImplementedBy<HoleRepository>().LifestylePerWebRequest());
            container.Register(Component.For<IRepository<User>>().ImplementedBy<UserRepository>().LifestylePerWebRequest());
            container.Register(Component.For<IRepository<Course>>().ImplementedBy<CourseRepository>().LifestylePerWebRequest());
            container.Register(Component.For<IRepository<CourseHole>>().ImplementedBy<CourseHoleRepository>().LifestylePerWebRequest());
        }
    }
}