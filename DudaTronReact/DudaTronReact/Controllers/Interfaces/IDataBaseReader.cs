using DudaTronReact.Controllers.SupportClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DudaTronReact.Controllers.Interfaces
{
	public interface IDataBaseReader
	{
		List<T> GetData<T>(string query) where T : class;
		T GetFirst<T>(string query) where T : class;
		T GetFirstOrDefault<T>(string query) where T : class;
		T GetSingleOrDefault<T>(string query) where T : class;
		void InsertData(string insertData, object param);
		void InsertDataInTransaction(string[] insertQueries, object paramn);
		void UpdateData(string updateData, object param);
		void DeteleData(string deleteData, object param);
		void DeteleData(string deleteData);
		void DeleteDataInTransaction(string[] deleteQueries, object param);

	}
}
