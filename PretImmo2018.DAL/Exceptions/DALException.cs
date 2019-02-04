using System;

namespace PretImmo2018.DAL.Exceptions
{
	/// <summary>
	/// Exceptions de la couche DAL. Encapsule les exceptions.
	/// </summary>
	class DALException : Exception
	{
		public DALException() : base() { }
		public DALException(string message) : base(message) { }
		public DALException(string message, Exception innerException) : base(message, innerException) { }
	}
}
