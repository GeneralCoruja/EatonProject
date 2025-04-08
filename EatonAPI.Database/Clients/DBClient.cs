namespace EatonAPI.Database.Clients
{
    using MongoDB.Driver;

    public abstract class DBClient<T>
    {
        protected IMongoCollection<T> _collection;

        public DBClient(IMongoCollection<T> collection)
        {
            _collection = collection;
        }
    }
}