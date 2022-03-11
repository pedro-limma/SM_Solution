using SMSolution.Domain.Application.Interfaces;
using System;
using SMSolution.Adapters.MongoDB.ConnectionFactory;
using SMSolution.Domain.Core.Models;
using System.Threading.Tasks;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Driver.Linq;

namespace SMSolution.Adapters.MongoDB.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly IDBConnectionFactory _mongo;
        public UserRepository(IDBConnectionFactory mongo)
        {
            _mongo = mongo;
        }

        public async Task<dynamic> Create(User usr)
        {
            try
            {
                var connection = _mongo.Connection("SM_Solution").GetCollection<User>("Users");

                 connection.InsertOne(usr);

                return usr;
            }
            catch (Exception ex)
            {
                return $"[Erro ao inserir na tabela] \n {ex.Message}";
            }
        }

        public async Task<dynamic> Index()
        {
            try
            {
                var collection = _mongo.Connection("SM_Solution").GetCollection<User>("Users");

                var filter = Builders<User>.Filter.Empty;

                List<User> result = collection.Find(filter).ToList();

                return result;
            }
            catch (Exception ex)
            {
                return $"[Erro ao buscar indices] \n {ex.Message}";
            }
        }

        public async Task<dynamic> IndexByCPF(int cpf)
        {
            IMongoQueryable<User> collection = _mongo.Connection("SM_Solution").GetCollection<User>("Users").AsQueryable();

            return (from user in collection where user.CPF == cpf.ToString() select user).FirstOrDefault();  

        }
    }
}
