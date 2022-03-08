namespace SMSolution.Adapters.MongoDB.Models
{
    public class DBParameterModel
    {
        public string Url { get; set; }
        public string Database { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public string GetConnectionString()
        {
            //return $"mongodb://{Url}/?authSource=admin";
            return $"mongodb+srv://{Username}:{Password}@{Database}.l1lza.mongodb.net/myFirstDatabase?retryWrites=true&w=majority";

        }
    }
}
