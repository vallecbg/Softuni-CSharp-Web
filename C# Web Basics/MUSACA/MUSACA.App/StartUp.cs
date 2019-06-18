using System;
using MUSACA.Data;
using SIS.MvcFramework;
using SIS.MvcFramework.Routing;

namespace MUSACA.App
{
    public class Startup : IMvcApplication
    {
        public void Configure(IServerRoutingTable serverRoutingTable)
        {
            using (var context = new MUSACADbContext())
            {
                context.Database.EnsureCreated();
            }
        }

        public void ConfigureServices(SIS.MvcFramework.DependencyContainer.IServiceProvider serviceProvider)
        {
            
        }

        //public void ConfigureServices(IServiceProvider serviceProvider)
        //{
        //    serviceProvider.Add<IAlbumService, AlbumService>();
        //    serviceProvider.Add<ITrackService, TrackService>();
        //    serviceProvider.Add<IUserService, UserService>();
        //}
    }
}
