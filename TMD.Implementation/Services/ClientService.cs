using System;
using System.Collections.Generic;
using TMD.Interfaces.IRepository;
using TMD.Interfaces.IServices;
using TMD.Models.DomainModels;

namespace TMD.Implementation.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository clientRepository;

        public ClientService(IClientRepository clientRepository)
        {
            this.clientRepository = clientRepository;
        }

        public IEnumerable<Client> GetAll()
        {
            return clientRepository.GetAll();
        }

        public Client FindClientById(int id)
        {
            return clientRepository.Find(id);
        }

        public bool SaveClient(Client client)
        {
            clientRepository.Add(client);
            clientRepository.SaveChanges();
            return true;
        }

        public bool UpdateClient(Client client)
        {
            clientRepository.Update(client);
            clientRepository.SaveChanges();
            return true;
        }

        public bool DeleteClient(Client client)
        {
            clientRepository.Delete(client);
            clientRepository.SaveChanges();
            return true;
        }
    }
}
