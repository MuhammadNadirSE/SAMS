using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Angle.Models;

namespace Angle.ViewModels.ServiceProvider
{
    public class ServiceProviderListViewModel
    {
        public ServiceProviderListViewModel()
        {
            Distributors = new List<Distributor>();
        }

        public IList<Distributor> Distributors { get; set; }
    }
}