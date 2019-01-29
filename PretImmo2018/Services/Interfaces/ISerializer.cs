using System.Collections.Generic;
using System.Threading.Tasks;

namespace PretImmo2018.Services.Interfaces
{
	/// <summary>
	/// Contrat de sérialisation d'un objet de type T.
	/// </summary>
	/// <typeparam name="T">Type de l'objet à sérialiser</typeparam>
	public interface ISerializer<T>
	{
		/// <summary>
		/// Sérialise l'objet de type T en paramètre
		/// </summary>
		/// <param name="obj"></param>
		/// <returns>Une Task (asynchrone inside)</returns>
		Task SerializeObject(T obj);

		/// <summary>
		/// Désérialise un objet de type T sous forme de liste.
		/// </summary>
		/// <returns></returns>
		Task<IEnumerable<T>> DeserializeAll();
	}
}
