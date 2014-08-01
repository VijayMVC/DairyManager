using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Diary.DAL;
using Diary.Entity;

namespace Diary.BLL
{
    public class Client
    {

        ClientDao clientDao = new ClientDao();

        public Guid InsertClient(ClientEntity clientEntity)
        {
            return clientDao.InsertClient(clientEntity);
        }

        public bool UpdateClient(ClientEntity clientEntity)
        {
            return clientDao.UpdateClient(clientEntity);

        }

        public DataSet SelectClientByClientId(Guid clientId)
        {
            return clientDao.SelectClientByClientId(clientId);

        }

        public DataSet SelectClientAll()
        {
            return clientDao.SelectClientAll();

        }
    }
}
