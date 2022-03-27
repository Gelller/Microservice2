namespace Microservice2.MongoDb
{
    public interface IBookDatabaseSetting
    {
        public string BookCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
