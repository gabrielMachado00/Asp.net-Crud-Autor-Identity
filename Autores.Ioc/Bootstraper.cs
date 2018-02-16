using Autores.Data.Interface;

using Autores.Identity.Context;
using Autores.Identity.Model;
using Autores.Data.Repository;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using SimpleInjector;

using ProjetoCrm.Infra.Data.Repository;

using Autors.Data.Context;

using Autores.Identity.Configuration;


namespace Autores.IoC
{
    public class BootStrapper
    {
        public static void RegisterServices(Container container)
        {

 
            container.Register<ApplicationDbContext>(Lifestyle.Scoped);
            container.Register<IUserStore<ApplicationUser>>(() => new UserStore<ApplicationUser>(new ApplicationDbContext()), Lifestyle.Scoped);
            container.Register<IRoleStore<IdentityRole, string>>(() => new RoleStore<IdentityRole>(), Lifestyle.Scoped);
            container.Register<ApplicationRoleManager>(Lifestyle.Scoped);
            container.Register<ApplicationUserManager>(Lifestyle.Scoped);
            container.Register<ApplicationSignInManager>(Lifestyle.Scoped);


            container.Register<AutoresContext>(Lifestyle.Scoped);
            container.Register(typeof(IRepositorioBase<>),typeof(RepositorioBase<>),Lifestyle.Scoped);
            container.Register<IAutorRepositorio, AutorRepositorio>(Lifestyle.Scoped);
            container.Register<ILivroRepositorio, LivroRepositorio>(Lifestyle.Scoped);
            container.Register<IUsuarioRepository,UsuarioRepository>(Lifestyle.Scoped);

        }


    }
}

