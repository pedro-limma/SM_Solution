using SMSolution.Domain.Application.Interfaces;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SMSolution.Adapters.MongoDB.ConnectionFactory;
using SMSolution.Domain.Core.Models;
using MongoDB.Bson;

namespace SMSolution.Adapters.MongoDB.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly IDBConnectionFactory _mongo;
        public UserRepository(IDBConnectionFactory mongo)
        {
            _mongo = mongo;
        }

        public dynamic Create(User usr)
        {
            try
            {
                var connection = _mongo.Connection("SM_Solution").GetCollection<User>("Users");

                usr._id = new ObjectId();

                connection.InsertOne(usr);

                return usr;
            }
            catch (Exception ex)
            {
                return $"[Erro ao inserir na tabela] \n {ex.Message}";
            }

           
        }

    }
}
