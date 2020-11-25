using Core.ContextDatabase;
using MongoDB.Driver;

namespace BlazorComponentLibServer.Context
{
    public class BlazorContext : BaseContext
    {
        public sealed override string ConnectionString { get; } = "mongodb://127.0.0.1:27017";
        public sealed override string DatabaseName { get; } = "BlazorComponentDataTest";

        public BlazorContext() : base()
        {
            Client = new MongoClient(ConnectionString);
            MongoDatabase = Client.GetDatabase(DatabaseName);
        }
    }
}
