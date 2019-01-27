using System;

namespace PretImmo2018.Exceptions
{
	class ServiceException : Exception
	{
		public ServiceException() : base() { }
		public ServiceException(string message) : base(message)
		{
		}
		public ServiceException(string message, Exception innerException) : base(message, innerException)
		{
		}
	}
}
