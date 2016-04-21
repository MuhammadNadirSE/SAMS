using System.Collections.Generic;

namespace Angle.ViewModels.Client
{
    public class ClientViewModel
    {
        public Models.Client Client { get; set; }
        public IList<TMD.Models.DomainModels.Distributor> Distributors { get; set; }
    }
}