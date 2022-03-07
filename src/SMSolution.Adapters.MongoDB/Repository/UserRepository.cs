using SMSolution.Domain.Application.Interfaces;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SMSolution.Adapters.MongoDB.ConnectionFactory;

namespace SMSolution.Adapters.MongoDB.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly IDBConnectionFactory _mongo;
        public UserRepository(IDBConnectionFactory mongo)
        {
            _mongo = mongo;
        }



    }
}
