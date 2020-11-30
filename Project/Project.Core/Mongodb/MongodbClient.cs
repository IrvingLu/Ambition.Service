﻿using MongoDB.Driver;
using Project.Infrastructure.Core.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Infrastructure.Core.Mongodb
{
    public static class MongodbClient<T> where T : class
    {
        #region +MongodbInfoClient 获取mongodb实例
        /// <summary>
        /// 获取mongodb实例
        /// </summary>
        /// <param name="host">连接字符串，库，表</param>
        /// <returns></returns>
        public static IMongoCollection<T> MongodbInfoClient(MongodbHostConfig host)
        {

            MongoClient client = new MongoClient(host.Connection);
            var dataBase = client.GetDatabase(host.DataBase);
            if (string.IsNullOrEmpty(host.Table))
            {
                return dataBase.GetCollection<T>(typeof(T).Name);
            }
            else
            {
                return dataBase.GetCollection<T>(host.Table);
            }

        }
        /// <summary>
        /// 获取mongodb实例
        /// </summary>
        /// <param name="host">连接字符串，库，表</param>
        /// <returns></returns>
        public static IMongoDatabase MongodbDatabase(MongodbHostConfig host)
        {
            MongoClient client = new MongoClient(host.Connection);
            var dataBase = client.GetDatabase(host.DataBase);
            return dataBase;
        }
        #endregion
    }
}
