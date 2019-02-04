using PretImmo2018.Model.Base;
using System.Collections.Generic;

namespace PretImmo2018.DAL
{
	/// <summary>
	/// Contrat d'interface du pattern Repository.
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public interface IRepository<T> where T : IdentifiableObject
	{
		/// <summary>
		/// Ajoute un objet de type <see cref="T"/>.
		/// </summary>
		/// <param name="obj"></param>
		T Add(T obj);

		/// <summary>
		/// Supprime un objet de type <see cref="T"/>.
		/// </summary>
		/// <param name="obj"></param>
		T Remove(T obj);

		/// <summary>
		/// Supprime un objet à partir de son identifiant.
		/// </summary>
		/// <param name="id"></param>
		T Remove(int id);

		/// <summary>
		/// Met à jour un objet
		/// </summary>
		/// <param name="obj"></param>
		T Update(T obj);

		/// <summary>
		/// Récupère un objet via son identifiant.
		/// </summary>
		/// <param name="id"></param>
		T Get(int id);

		/// <summary>
		/// Récupère tous les objets de type <see cref="T"/>.
		/// </summary>
		IEnumerable<T> GetAll();

		/// <summary>
		/// SAuvegarde les modifications
		/// </summary>
		/// <returns></returns>
		void Save();

		/// <summary>
		/// Efface tous les éléments.
		/// </summary>
		void Clear();
	}
}
