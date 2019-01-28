using Newtonsoft.Json;
using PretImmo2018.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PretImmo2018.Services
{
	public class JsonSerializer<T> : ISerializer<T> where T : IEquatable<T>
	{
		string _fileName = $"{(typeof(T)).Name}.json";

		public async Task<IEnumerable<T>> DeserializeAll()
		{
			string content = null;
			using (var sw = new StreamReader(_fileName, Encoding.UTF8))
			{
				content = await sw.ReadToEndAsync();
			}

			if (string.IsNullOrWhiteSpace(content))
			{
				return new List<T>();
			}

			return JsonConvert.DeserializeObject<List<T>>(content);
		}


		public async Task SerializeObject(T obj)
		{

			//File.Create(_fileName);

			string content = null;
			using (var sw = new StreamReader(_fileName, Encoding.UTF8))
			{
				content = await sw.ReadToEndAsync();
			}

			var listOfTs = new List<T>();

			if (!string.IsNullOrEmpty(content))
			{
				listOfTs = JsonConvert.DeserializeObject<List<T>>(content);
				if (listOfTs.Contains(obj))
				{
					var existingObj = listOfTs.FirstOrDefault(_ => _.Equals(obj));
					if (existingObj != null)
					{
						listOfTs.Remove(existingObj);
						listOfTs.Add(obj);
					}
				}
				else
				{
					listOfTs.Add(obj);
				}
			}
			else
			{
				listOfTs.Add(obj);
			}

			var json = JsonConvert.SerializeObject(listOfTs, Formatting.Indented);
			File.WriteAllText(_fileName, json);
		}
	}
}
