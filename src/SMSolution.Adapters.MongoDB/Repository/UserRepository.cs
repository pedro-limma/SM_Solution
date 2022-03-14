using MongoDB.Driver;
using MongoDB.Driver.Linq;
using SMSolution.Adapters.MongoDB.ConnectionFactory;
using SMSolution.Domain.Application.Interfaces;
using SMSolution.Domain.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Threading.Tasks;

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
                IMongoCollection<User> collection = _mongo.Connection("SM_Solution").GetCollection<User>("Users");

                 await collection.InsertOneAsync(usr);

                return usr;
            }
            catch (Exception ex)
            {
                return $"[Erro ao inserir na tabela] \n {ex.Message}";
            }
        }

        public async Task<dynamic> DeleteUser(string cpf)
        {
            IMongoCollection<User> collection = _mongo.Connection("SM_Solution").GetCollection<User>("Users");

            Expression<Func<User, bool>> filter = x => x.CPF.Equals(cpf);

            return await collection.DeleteOneAsync(filter);
        }

        public async Task<dynamic> Index()
        {
            try
            {
                IMongoCollection<User> collection = _mongo.Connection("SM_Solution").GetCollection<User>("Users");

                FilterDefinition<User> filter = Builders<User>.Filter.Empty;

                List<User> result = collection.Find(filter).ToList();

                return result;
            }
            catch (Exception ex)
            {
                return $"[Erro ao buscar indices] \n {ex.Message}";
            }
        }

        public async Task<dynamic> IndexByCPF(string cpf)
        {
            IMongoCollection<User> collection =  _mongo.Connection("SM_Solution").GetCollection<User>("Users");

            Expression<Func<User, bool>> filter = x => x.CPF.Equals(cpf);

            return collection.Find(filter).FirstOrDefault();

        }

        public async Task<dynamic> UpdateByCPF(string cpf, User usr)
        {
            IMongoCollection<User> collection = _mongo.Connection("SM_Solution").GetCollection<User>("Users");

            Expression<Func<User, bool>> filter = x => x.CPF.Equals(cpf);

            User user = collection.Find(filter).FirstOrDefault();

            if (user is null)
                throw new Exception("Erro ao encontrar na base.");

            user.Name = usr.Name??user.Name;
            user.Email = usr.Email??user.Email;
            user.PhoneNumber = usr.PhoneNumber ?? user.PhoneNumber;
            user.Password = usr.Password ?? user.Password;
            user.Role = usr.Role ?? user.Role;
            user.UpdatedAt = usr.UpdatedAt;

            return collection.ReplaceOne(filter, user);
        }

        public async Task<User> LoginUser(string email, string password)
        {
            IMongoCollection<User> collection = _mongo.Connection("SM_Solution").GetCollection<User>("Users");
            
            password = new Crypt(SHA512.Create()).HashPassword(password);

            Expression<Func<User, bool>> filter = x => x.Email == email && x.Password == password;

            return await collection.Find(filter).FirstOrDefaultAsync();

        }
    }
}
