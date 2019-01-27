using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PretImmo2018.Services.Interfaces
{
	public interface ISerializer<T>
	{
		Task SerializeObject(T obj);
		Task<IEnumerable<T>> DeserializeAll();
	}
}
