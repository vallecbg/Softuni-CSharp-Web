using SULS.Services;

namespace SULS.App
{
    using Data;
    using SIS.MvcFramework;
    using SIS.MvcFramework.DependencyContainer;
    using SIS.MvcFramework.Routing;

    public class StartUp : IMvcApplication
    {
        public void Configure(IServerRoutingTable serverRoutingTable)
        {
            using (var db = new SULSContext())
            {
                //db.Database.EnsureDeleted();
                db.Database.EnsureCreated();
            }
        }

        public void ConfigureServices(IServiceProvider serviceProvider)
        {
            //TODO: Don't forget to add services
            serviceProvider.Add<IUsersService, UsersService>();
            serviceProvider.Add<IProblemsService, ProblemsService>();
            serviceProvider.Add<ISubmissionsService, SubmissionsService>();
        }
    }
}