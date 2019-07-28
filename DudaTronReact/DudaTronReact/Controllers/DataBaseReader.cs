using Dapper;
using DudaTronReact.Controllers.Interfaces;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace DudaTronReact.Controllers
{
	public class DataBaseReader : IDataBaseReader
	{
		private static IConfiguration config;

		public DataBaseReader()
		{
			config = ConfigReader.config;
		}

		public List<T> GetData<T>(string query) where T : class
		{
			using (IDbConnection connection = CreateConnection())
			{
				return connection.Query<T>(query).ToList();
			}
		}

		public T GetFirst<T>(string query) where T : class
		{
			using (IDbConnection connection = CreateConnection())
			{
				return connection.QueryFirst<T>(query);
			}
		}

		public T GetFirstOrDefault<T>(string query) where T : class
		{
			using (IDbConnection connection = CreateConnection())
			{
				return connection.QueryFirstOrDefault<T>(query);
			}
		}

		public T GetSingleOrDefault<T>(string query) where T : class
		{
			using (IDbConnection connection = CreateConnection())
			{
				return connection.QuerySingleOrDefault<T>(query);
			}
		}

		public void InsertData(string insertQuery, object param)
		{
			using (IDbConnection connection = CreateConnection())
			{
				connection.Execute(insertQuery, param);
			}
		}

		public void InsertDataInTransaction(string[] insertQueries, object param)
		{
			using (IDbConnection connection = CreateConnection())
			{
				connection.Open();

				using (var transaction = connection.BeginTransaction())
				{
					foreach (string insertQuery in insertQueries)
					{
						connection.Execute(insertQuery, param, transaction);
					}
					transaction.Commit();
				}
			}
		}

		public void UpdateData(string updateQuery, object param)
		{
			using (IDbConnection connection = CreateConnection())
			{
				connection.Execute(updateQuery, param);
			}
		}

		public void DeteleData(string deleteQuery, object param)
		{
			using (IDbConnection connection = CreateConnection())
			{
				connection.Execute(deleteQuery, param);
			}
		}

		public void DeteleData(string deleteQuery)
		{
			using (IDbConnection connection = CreateConnection())
			{
				connection.Execute(deleteQuery);
			}
		}

		public void DeleteDataInTransaction(string[] deleteQueries, object param)
		{
			using (IDbConnection connection = CreateConnection())
			{
				connection.Open();

				using (var transaction = connection.BeginTransaction())
				{
					foreach (string deleteQuery in deleteQueries)
					{
						connection.Execute(deleteQuery, param, transaction);
					}
					transaction.Commit();
				}
			}
		}

		private SqlConnection CreateConnection()
		{
			return new SqlConnection(config.GetConnectionString("DefaultConnection"));
		}
	}
}