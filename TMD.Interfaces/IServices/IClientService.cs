using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMD.Models.DomainModels;

namespace TMD.Interfaces.IServices
{
    public interface  IClientService
    {
        /// <summary>
        /// Get All Clients
        /// </summary>
        IEnumerable<Client> GetAll();
        /// <summary>
        /// Find Client By Id
        /// </summary>
        Client FindClientById(int id);
        /// <summary>
        /// Save Client
        /// </summary>
        bool SaveClient(Client client);
        /// <summary>
        /// Update Client
        /// </summary>
        bool UpdateClient(Client client);
        /// <summary>
        /// Delete Client
        /// </summary>
        bool DeleteClient(Client client);
    }
}
