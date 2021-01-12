using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.GridFS;
using Project.Core.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Core.Mongodb
{
    /// <summary>
    /// 功能描述    ：Mongodb
    /// 创 建 者    ：鲁岩奇
    /// 创建日期    ：2021/1/12 9:40:56 
    /// 最后修改者  ：Administrator
    /// 最后修改日期：2021/1/12 9:40:56 
    /// </summary>
    public static class MongodbHelper<T> where T : class, new()
    {
        #region +Add 添加一条数据

        /// <summary>
        /// 添加一条数据
        /// </summary>
        /// <param name="t">添加的实体</param>
        /// <param name="host">mongodb连接信息</param>
        /// <returns></returns>
        public static int Add(MongodbHostConfig host, T t)
        {
            try
            {
                var client = MongodbClient<T>.MongodbInfoClient(host);
                client.InsertOne(t);
                return 1;
            }
            catch
            {
                return 0;
            }
        }

        #endregion

        #region +AddAsync 异步添加一条数据

        /// <summary>
        /// 异步添加一条数据
        /// </summary>
        /// <param name="t">添加的实体</param>
        /// <param name="host">mongodb连接信息</param>
        /// <returns></returns>
        public static async Task<int> AddAsync(MongodbHostConfig host, T t)
        {
            try
            {
                var client = MongodbClient<T>.MongodbInfoClient(host);
                await client.InsertOneAsync(t);
                return 1;
            }
            catch
            {
                return 0;
            }
        }

        public static Task<int> GridFSAddAsync(MongodbHostConfig host)
        {
            try
            {
                var client = MongodbClient<T>.MongodbInfoClient(host);

                return Task.FromResult(1);
            }
            catch
            {
                return Task.FromResult(0);
            }
        }

        #endregion

        #region +InsertMany 批量插入

        /// <summary>
        /// 批量插入
        /// </summary>
        /// <param name="host">mongodb连接信息</param>
        /// <param name="t">实体集合</param>
        /// <returns></returns>
        public static int InsertMany(MongodbHostConfig host, List<T> t)
        {
            try
            {
                var client = MongodbClient<T>.MongodbInfoClient(host);
                client.InsertMany(t);
                return 1;
            }
            catch (Exception )
            {
                return 0;
                throw ;
            }
        }

        #endregion

        #region +InsertManyAsync 异步批量插入

        /// <summary>
        /// 异步批量插入
        /// </summary>
        /// <param name="host">mongodb连接信息</param>
        /// <param name="t">实体集合</param>
        /// <returns></returns>
        public static async Task<int> InsertManyAsync(MongodbHostConfig host, List<T> t)
        {
            try
            {
                var client = MongodbClient<T>.MongodbInfoClient(host);
                await client.InsertManyAsync(t);
                return 1;
            }
            catch
            {
                return 0;
            }
        }

        #endregion

        #region +Update 修改一条数据

        /// <summary>
        /// 修改一条数据
        /// </summary>
        /// <param name="t">添加的实体</param>
        /// <param name="host">mongodb连接信息</param>
        /// <param name="id">主键</param>
        /// <returns></returns>
        public static UpdateResult Update(MongodbHostConfig host, T t, string id)
        {
            try
            {
                var client = MongodbClient<T>.MongodbInfoClient(host);
                //修改条件
                FilterDefinition<T> filter = Builders<T>.Filter.Eq("_id", new ObjectId(id));
                //要修改的字段
                var list = new List<UpdateDefinition<T>>();
                foreach (var item in t.GetType().GetProperties())
                {
                    if (item.Name.ToLower() == "id") continue;
                    list.Add(Builders<T>.Update.Set(item.Name, item.GetValue(t)));
                }

                var updatefilter = Builders<T>.Update.Combine(list);
                return client.UpdateOne(filter, updatefilter);
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region +UpdateAsync 异步修改一条数据

        /// <summary>
        /// 异步修改一条数据
        /// </summary>
        /// <param name="t">添加的实体</param>
        /// <param name="host">mongodb连接信息</param>
        /// <param name="id">主键</param>
        /// <returns></returns>
        public static async Task<UpdateResult> UpdateAsync(MongodbHostConfig host, T t, string id)
        {
            try
            {
                var client = MongodbClient<T>.MongodbInfoClient(host);
                //修改条件
                FilterDefinition<T> filter = Builders<T>.Filter.Eq("_id", id);
                //要修改的字段
                var list = new List<UpdateDefinition<T>>();
                foreach (var item in t.GetType().GetProperties())
                {
                    if (item.Name.ToLower() == "id") continue;
                    list.Add(Builders<T>.Update.Set(item.Name, item.GetValue(t)));
                }

                var updatefilter = Builders<T>.Update.Combine(list);
                return await client.UpdateOneAsync(filter, updatefilter);
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region +UpdateManay 批量修改数据

        /// <summary>
        /// 批量修改数据
        /// </summary>
        /// <param name="dic">要修改的字段</param>
        /// <param name="host">mongodb连接信息</param>
        /// <param name="filter">修改条件</param>
        /// <returns></returns>
        public static UpdateResult UpdateManay(MongodbHostConfig host, Dictionary<string, string> dic,
            FilterDefinition<T> filter)
        {
            try
            {
                var client = MongodbClient<T>.MongodbInfoClient(host);
                T t = new T();
                //要修改的字段
                var list = new List<UpdateDefinition<T>>();
                foreach (var item in t.GetType().GetProperties())
                {
                    if (!dic.ContainsKey(item.Name)) continue;
                    var value = dic[item.Name];
                    list.Add(Builders<T>.Update.Set(item.Name, value));
                }

                var updatefilter = Builders<T>.Update.Combine(list);
                return client.UpdateMany(filter, updatefilter);
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region +UpdateManayAsync 异步批量修改数据

        /// <summary>
        /// 异步批量修改数据
        /// </summary>
        /// <param name="dic">要修改的字段</param>
        /// <param name="host">mongodb连接信息</param>
        /// <param name="filter">修改条件</param>
        /// <returns></returns>
        public static async Task<UpdateResult> UpdateManayAsync(MongodbHostConfig host, Dictionary<string, string> dic,
            FilterDefinition<T> filter)
        {
            try
            {
                var client = MongodbClient<T>.MongodbInfoClient(host);
                T t = new T();
                //要修改的字段
                var list = new List<UpdateDefinition<T>>();
                foreach (var item in t.GetType().GetProperties())
                {
                    if (!dic.ContainsKey(item.Name)) continue;
                    var value = dic[item.Name];
                    list.Add(Builders<T>.Update.Set(item.Name, value));
                }

                var updatefilter = Builders<T>.Update.Combine(list);
                return await client.UpdateManyAsync(filter, updatefilter);
            }
            catch (Exception )
            {
                throw ;
            }
        }

        #endregion

        #region Delete 删除一条数据

        /// <summary>
        /// 删除一条数据
        /// </summary>
        /// <param name="host">mongodb连接信息</param>
        /// <param name="id">objectId</param>
        /// <returns></returns>
        public static DeleteResult Delete(MongodbHostConfig host, string id)
        {
            try
            {
                var client = MongodbClient<T>.MongodbInfoClient(host);
                FilterDefinition<T> filter = Builders<T>.Filter.Eq("_id", new ObjectId(id));
                return client.DeleteOne(filter);
            }
            catch (Exception)
            {
                throw;
            }

        }

        #endregion

        #region DeleteAsync 异步删除一条数据

        /// <summary>
        /// 异步删除一条数据
        /// </summary>
        /// <param name="host">mongodb连接信息</param>
        /// <param name="id">objectId</param>
        /// <returns></returns>
        public static async Task<DeleteResult> DeleteAsync(MongodbHostConfig host, string id)
        {
            try
            {
                var client = MongodbClient<T>.MongodbInfoClient(host);
                //修改条件
                FilterDefinition<T> filter = Builders<T>.Filter.Eq("id", id);
                return await client.DeleteOneAsync(filter);
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region DeleteMany 删除多条数据

        /// <summary>
        /// 删除一条数据
        /// </summary>
        /// <param name="host">mongodb连接信息</param>
        /// <param name="filter">删除的条件</param>
        /// <returns></returns>
        public static DeleteResult DeleteMany(MongodbHostConfig host, FilterDefinition<T> filter)
        {
            try
            {
                var client = MongodbClient<T>.MongodbInfoClient(host);
                return client.DeleteMany(filter);
            }
            catch (Exception)
            {
                throw;
            }

        }

        #endregion

        #region DeleteManyAsync 异步删除多条数据

        /// <summary>
        /// 异步删除多条数据
        /// </summary>
        /// <param name="host">mongodb连接信息</param>
        /// <param name="filter">删除的条件</param>
        /// <returns></returns>
        public static async Task<DeleteResult> DeleteManyAsync(MongodbHostConfig host, FilterDefinition<T> filter)
        {
            try
            {
                var client = MongodbClient<T>.MongodbInfoClient(host);
                return await client.DeleteManyAsync(filter);
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region Count 根据条件获取总数

        /// <summary>
        /// 根据条件获取总数
        /// </summary>
        /// <param name="host">mongodb连接信息</param>
        /// <param name="filter">条件</param>
        /// <returns></returns>
        public static long Count(MongodbHostConfig host, FilterDefinition<T> filter)
        {
            try
            {
                var client = MongodbClient<T>.MongodbInfoClient(host);
#pragma warning disable CS0618 // 类型或成员已过时
                return client.Count(filter);
#pragma warning restore CS0618 // 类型或成员已过时
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region CountAsync 异步根据条件获取总数

        /// <summary>
        /// 异步根据条件获取总数
        /// </summary>
        /// <param name="host">mongodb连接信息</param>
        /// <param name="filter">条件</param>
        /// <returns></returns>
        public static async Task<long> CountAsync(MongodbHostConfig host, FilterDefinition<T> filter)
        {
            try
            {
                var client = MongodbClient<T>.MongodbInfoClient(host);
#pragma warning disable CS0618 // 类型或成员已过时
                return await client.CountAsync(filter);
#pragma warning restore CS0618 // 类型或成员已过时
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region FindOne 根据id查询一条数据

        /// <summary>
        /// 根据id查询一条数据
        /// </summary>
        /// <param name="host">mongodb连接信息</param>
        /// <param name="id">objectid</param>
        /// <param name="field">要查询的字段，不写时查询全部</param>
        /// <returns></returns>
        public static T FindOne(MongodbHostConfig host, string id, string[] field = null)
        {
            try
            {
                var client = MongodbClient<T>.MongodbInfoClient(host);
                FilterDefinition<T> filter = Builders<T>.Filter.Eq("_id", new ObjectId(id));
                //不指定查询字段
                if (field == null || field.Length == 0)
                {
                    return client.Find(filter).FirstOrDefault<T>();
                }

                //制定查询字段
                var fieldList = new List<ProjectionDefinition<T>>();
                for (int i = 0; i < field.Length; i++)
                {
                    fieldList.Add(Builders<T>.Projection.Include(field[i].ToString()));
                }

                var projection = Builders<T>.Projection.Combine(fieldList);
                fieldList?.Clear();
                return client.Find(filter).Project<T>(projection).FirstOrDefault<T>();
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region FindOneAsync 异步根据id查询一条数据

        /// <summary>
        /// 异步根据id查询一条数据
        /// </summary>
        /// <param name="host">mongodb连接信息</param>
        /// <param name="id">objectId</param>
        /// <param name="field">字段名称</param>
        /// <returns></returns>
        public static async Task<T> FindOneAsync(MongodbHostConfig host, string id, string[] field = null)
        {
            var client = MongodbClient<T>.MongodbInfoClient(host);
            var filter = Builders<T>.Filter.Eq("_id", id);
            //不指定查询字段
            if (field == null || field.Length == 0)
            {
                return await client.Find(filter).FirstOrDefaultAsync();
            }

            //制定查询字段
            var fieldList = field.Select(t => Builders<T>.Projection.Include(t.ToString())).ToList();
            var projection = Builders<T>.Projection.Combine(fieldList);
            fieldList.Clear();
            return await client.Find(filter).Project<T>(projection).FirstOrDefaultAsync();
        }

        /// <summary>
        /// 异步根据指定的列查询一条数据
        /// </summary>
        /// <param name="host">mongodb连接信息</param>
        /// <param name="columnName">列名</param>
        /// <param name="columnValue">列值</param>
        /// <returns></returns>
        public static async Task<T> FindOneAsync(MongodbHostConfig host, string columnName, string columnValue)
        {
            var client = MongodbClient<T>.MongodbInfoClient(host);
            var filter = Builders<T>.Filter.Eq(columnName, columnValue);
            return await client.Find(filter).FirstOrDefaultAsync();
        }

        #endregion

        #region FindList 查询集合

        /// <summary>
        /// 查询集合
        /// </summary>
        /// <param name="host">mongodb连接信息</param>
        /// <param name="filter">查询条件</param>
        /// <param name="field">要查询的字段,不写时查询全部</param>
        /// <param name="sort">要排序的字段</param>
        /// <returns></returns>
        public static List<T> FindList(MongodbHostConfig host, FilterDefinition<T> filter, string[] field = null,
            SortDefinition<T> sort = null)
        {
            try
            {
                var client = MongodbClient<T>.MongodbInfoClient(host);
                //不指定查询字段
                if (field == null || field.Length == 0)
                {
                    if (sort == null) return client.Find(filter).ToList();
                    //进行排序
                    return client.Find(filter).Sort(sort).ToList();
                }

                //制定查询字段
                var fieldList = new List<ProjectionDefinition<T>>();
                for (int i = 0; i < field.Length; i++)
                {
                    fieldList.Add(Builders<T>.Projection.Include(field[i].ToString()));
                }

                var projection = Builders<T>.Projection.Combine(fieldList);
                fieldList?.Clear();
                if (sort == null) return client.Find(filter).Project<T>(projection).ToList();
                //排序查询
                return client.Find(filter).Sort(sort).Project<T>(projection).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region FindListAsync 异步查询集合

        /// <summary>
        /// 异步查询集合
        /// </summary>
        /// <param name="host">mongodb连接信息</param>
        /// <param name="filter">查询条件</param>
        /// <param name="field">要查询的字段,不写时查询全部</param>
        /// <param name="sort">要排序的字段</param>
        /// <returns></returns>
        public static async Task<List<T>> FindListAsync(MongodbHostConfig host, FilterDefinition<T> filter,
            string[] field = null, SortDefinition<T> sort = null)
        {
            try
            {
                var client = MongodbClient<T>.MongodbInfoClient(host);
                //不指定查询字段
                if (field == null || field.Length == 0)
                {
                    if (sort == null) return await client.Find(filter).ToListAsync();
                    return await client.Find(filter).Sort(sort).ToListAsync();
                }

                //制定查询字段
                var fieldList = new List<ProjectionDefinition<T>>();
                for (int i = 0; i < field.Length; i++)
                {
                    fieldList.Add(Builders<T>.Projection.Include(field[i].ToString()));
                }

                var projection = Builders<T>.Projection.Combine(fieldList);
                fieldList?.Clear();
                if (sort == null) return await client.Find(filter).Project<T>(projection).ToListAsync();
                //排序查询
                return await client.Find(filter).Sort(sort).Project<T>(projection).ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region FindListByPage 分页查询集合

        /// <summary>
        /// 分页查询集合
        /// </summary>
        /// <param name="host">mongodb连接信息</param>
        /// <param name="filter">查询条件</param>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">页容量</param>
        /// <param name="count">总条数</param>
        /// <param name="field">要查询的字段,不写时查询全部</param>
        /// <param name="sort">要排序的字段</param>
        /// <returns></returns>
        public static List<T> FindListByPage(MongodbHostConfig host, FilterDefinition<T> filter, int pageIndex,
            int pageSize, out long count, string[] field = null, SortDefinition<T> sort = null)
        {
            try
            {
                var client = MongodbClient<T>.MongodbInfoClient(host);
#pragma warning disable CS0618 // 类型或成员已过时
                count = client.Count(filter);
#pragma warning restore CS0618 // 类型或成员已过时
                //不指定查询字段
                if (field == null || field.Length == 0)
                {
                    if (sort == null)
                        return client.Find(filter).Skip((pageIndex - 1) * pageSize).Limit(pageSize).ToList();
                    //进行排序
                    return client.Find(filter).Sort(sort).Skip((pageIndex - 1) * pageSize).Limit(pageSize).ToList();
                }

                //制定查询字段
                var fieldList = new List<ProjectionDefinition<T>>();
                for (int i = 0; i < field.Length; i++)
                {
                    fieldList.Add(Builders<T>.Projection.Include(field[i].ToString()));
                }

                var projection = Builders<T>.Projection.Combine(fieldList);
                fieldList?.Clear();

                //不排序
                if (sort == null)
                    return client.Find(filter).Project<T>(projection).Skip((pageIndex - 1) * pageSize).Limit(pageSize)
                        .ToList();

                //排序查询
                return client.Find(filter).Sort(sort).Project<T>(projection).Skip((pageIndex - 1) * pageSize)
                    .Limit(pageSize).ToList();

            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region FindListByPageAsync 异步分页查询集合

        /// <summary>
        /// 异步分页查询集合
        /// </summary>
        /// <param name="host">mongodb连接信息</param>
        /// <param name="filter">查询条件</param>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">页容量</param>
        /// <param name="field">要查询的字段,不写时查询全部</param>
        /// <param name="sort">要排序的字段</param>
        /// <returns></returns>
        public static async Task<List<T>> FindListByPageAsync(MongodbHostConfig host, FilterDefinition<T> filter,
            int pageIndex, int pageSize, string[] field = null, SortDefinition<T> sort = null)
        {
            try
            {
                var client = MongodbClient<T>.MongodbInfoClient(host);
                //不指定查询字段
                if (field == null || field.Length == 0)
                {
                    if (sort == null)
                        return await client.Find(filter).Skip((pageIndex - 1) * pageSize).Limit(pageSize).ToListAsync();
                    //进行排序
                    return await client.Find(filter).Sort(sort).Skip((pageIndex - 1) * pageSize).Limit(pageSize)
                        .ToListAsync();
                }

                //制定查询字段
                var fieldList = new List<ProjectionDefinition<T>>();
                for (int i = 0; i < field.Length; i++)
                {
                    fieldList.Add(Builders<T>.Projection.Include(field[i].ToString()));
                }

                var projection = Builders<T>.Projection.Combine(fieldList);
                fieldList?.Clear();

                //不排序
                if (sort == null)
                    return await client.Find(filter).Project<T>(projection).Skip((pageIndex - 1) * pageSize)
                        .Limit(pageSize).ToListAsync();

                //排序查询
                return await client.Find(filter).Sort(sort).Project<T>(projection).Skip((pageIndex - 1) * pageSize)
                    .Limit(pageSize).ToListAsync();

            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region GridFS

        /// <summary>
        ///  上传文件
        ///  </summary>
        /// <param name="host"></param>
        /// <param name="fileBytes"></param>
        public static int FilePut(MongodbHostConfig host, byte[] fileBytes)
        {
            var client = MongodbClient<T>.MongodbDatabase(host);
            GridFSBucket fs = new GridFSBucket(client);
            string fileName = Guid.NewGuid().ToString();
            var obj = fs.UploadFromBytesAsync(fileName, fileBytes).Result;
            return obj.Timestamp;
        }

        /// <summary>
        /// 删除文件
        /// </summary>
        /// <param name="host"></param>
        /// <param name="objectId"></param>
        public static void FileDelete(MongodbHostConfig host, string objectId)
        {
            var client = MongodbClient<T>.MongodbDatabase(host);
            GridFSBucket fs = new GridFSBucket(client);
            ObjectId obj = new ObjectId(objectId);
            fs.Delete(obj);
        }

        /// <summary>
        /// 下载文件
        /// </summary>
        /// <param name="host"></param>
        /// <param name="objectId"></param>
        public static byte[] FileGet(MongodbHostConfig host, string objectId)
        {
            var client = MongodbClient<T>.MongodbDatabase(host);
            GridFSBucket fs = new GridFSBucket(client);
            ObjectId obj = new ObjectId(objectId);
            var fileBytes = fs.DownloadAsBytesAsync(obj).Result;
            return fileBytes;
        }

        #endregion
    }
}
