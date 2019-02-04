using Newtonsoft.Json;
using PretImmo2018.DAL.Exceptions;
using PretImmo2018.Model.Base;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace PretImmo2018.DAL
{
	public class JsonRepository<T> : IRepository<T> where T : IdentifiableObject
	{
		#region Props

		private string _fileName = $"{(typeof(T)).Name}.json";

		private List<T> _data = new List<T>();

		#endregion

		#region Constructor

		public JsonRepository()
		{
			// chargement des données dans _data
			try
			{
				LoadData();
			}
			catch (IOException)
			{
				try
				{
					InitFile();
				}
				catch (Exception e)
				{
					throw new DALException("Initialisation du fichier impossible.", e);
				}
			}
			catch (Exception ex)
			{
				throw new DALException("Erreur d'initialisation du JsonRepository.", ex);
			}
		}

		#endregion

		#region Initialisation methods

		private void LoadData()
		{
			string content = null;
			using (var sw = new StreamReader(_fileName, Encoding.UTF8))
			{
				content = sw.ReadToEnd();
			}
			if (string.IsNullOrEmpty(content))
			{
				return;
			}
			_data = JsonConvert.DeserializeObject<List<T>>(content);
		}

		private void InitFile()
		{
			var json = JsonConvert.SerializeObject(_data);
			if (!string.IsNullOrEmpty(json))
			{
				File.WriteAllText(_fileName, json);
			}
		}

		#endregion

		#region Public methods, implements IRepository<T>

		public T Add(T obj)
		{
			try
			{
				if (obj == null)
					throw new ArgumentNullException(nameof(obj));

				// l'id n'a pas été défini
				if (obj.ID <= 0)
				{
					var id = 1;
					if (_data.Any())
					{
						id = _data.Max(p => p.ID) + 1;
					}
					obj.ID = id;
				}
				_data.Add(obj);
				return obj;
			}
			catch (Exception ex)
			{
				throw new DALException("Impossible d'ajouter l'élément.", ex);
			}
		}

		public void Clear()
		{
			_data.Clear();
			_data.TrimExcess();
		}

		public T Get(int id)
		{
			return _data
				.FirstOrDefault(_ => _.ID == id);
		}

		public IEnumerable<T> GetAll()
		{
			return _data;
		}

		public T Remove(T obj)
		{
			_data.Remove(obj);
			return obj;
		}

		public T Remove(int id)
		{
			var t = Get(id);

			if (t == null)
				return null;

			_data.Remove(t);
			return t;
		}

		public void Save()
		{
			try
			{
				// on persiste la liste _data sur le disque
				var json = JsonConvert.SerializeObject(_data, Formatting.None);
				File.WriteAllText(_fileName, json);
			}
			catch (Exception ex)
			{
				throw new DALException("Sauvegarde impossible", ex);
			}
		}

		public T Update(T obj)
		{
			var index = _data.IndexOf(obj);
			if (index >= 0)
			{
				_data[index] = obj;
				return _data[index];
			}
			return null;
		}

		#endregion
	}
}
