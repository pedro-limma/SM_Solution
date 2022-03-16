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

        public async Task<User> Create(User usr)
        {
            IMongoCollection<User> collection = _mongo.Connection("SM_Solution").GetCollection<User>("Users");

            await collection.InsertOneAsync(usr);

            return usr;
        }

        public async Task<string> DeleteUser(string cpf)
        {
            IMongoCollection<User> collection = _mongo.Connection("SM_Solution").GetCollection<User>("Users");

            Expression<Func<User, bool>> filter = x => x.CPF.Equals(cpf);

            await collection.DeleteOneAsync(filter);

            return "Usuário deletado com sucesso";
        }
            
        public async Task<IList<User>> Index()
        {
            IMongoCollection<User> collection = _mongo.Connection("SM_Solution").GetCollection<User>("Users");

            FilterDefinition<User> filter = Builders<User>.Filter.Empty;

            IList<User> result = collection.Find(filter).ToList();

            if (result is null)
                throw new Exception("Erro ao encontrar indices");

            return result;
            
        }

        public async Task<User> IndexByCPF(string cpf)
        {
            IMongoCollection<User> collection =  _mongo.Connection("SM_Solution").GetCollection<User>("Users");

            Expression<Func<User, bool>> filter = x => x.CPF.Equals(cpf);

            return collection.Find(filter).FirstOrDefault();

        }

        public async Task<User> UpdateByCPF(string cpf, User usr)
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

            await collection.ReplaceOneAsync(filter, user);


            return user;
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
