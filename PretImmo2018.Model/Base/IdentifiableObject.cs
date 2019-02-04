using PretImmo2018.Model.Interfaces;
using System;

namespace PretImmo2018.Model.Base
{
	/// <summary>
	/// Classe abstraite ajoutant un ID aux classes dérivées et une implémentation de IEquatable.
	/// </summary>
	public abstract class IdentifiableObject : IEquatable<IdentifiableObject>, IIdentifiable
	{
		/// <summary>
		/// Identifiant de l'élément
		/// </summary>
		public int ID { get; set; }

		/// <summary>
		/// Définit une méthode de comparaison de deux instances de même type.
		/// </summary>
		/// <param name="other"></param>
		/// <returns>Vrai (même id) ou faux (id différents).</returns>
		public bool Equals(IdentifiableObject other)
		{
			return ID == other.ID;
		}
	}
}
