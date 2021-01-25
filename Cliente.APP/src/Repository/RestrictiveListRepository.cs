using System;
using System.Collections.Generic;
using Cliente.APP.Entities;
using Cliente.APP.Repositories.Settings;
using MongoDB.Driver;

namespace Cliente.APP.Repositories
{
    public class RestrictiveListRepository : IRestrictiveListRepository
    {
        private const string COLLENTION_NAME = "RestrictiveLists";

        private readonly IMongoCollection<RestrictiveList> _restrictiveList;

        public RestrictiveListRepository()
        {
            var client = new MongoClient(MongoSettings.ConnectionString);
            var database = client.GetDatabase(MongoSettings.DatabaseName);

            _restrictiveList = database.GetCollection<RestrictiveList>(COLLENTION_NAME);
        }

        public IList<RestrictiveList> Get() 
            => _restrictiveList.Find(restrictive => true).ToList();

        public RestrictiveList Get(string id) 
            => _restrictiveList.Find<RestrictiveList>(restrictive => restrictive.Id == id).FirstOrDefault();

        public RestrictiveList GetByCPF(string cpf)  => 
            _restrictiveList.Find<RestrictiveList>(restrictive => restrictive.CPF == cpf).FirstOrDefault();
        
        public RestrictiveList Store(RestrictiveList restrictiveList)
        {
            _restrictiveList.InsertOne(restrictiveList);
            return restrictiveList;
        }
    }
}