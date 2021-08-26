using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationRP.Services
{
	public interface IDBOperations<T>
	{
		List<T> GetAll();
		T getById(int? id);
		T Add(T t);
		bool Delete(int id);
		T Edit(T t);
	}
}
