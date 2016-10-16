using System;
using System.Collections.Generic;
using System.IO;

namespace Tasky.Shared 
{
	public class TodoItemRepositoryADO 
	{
		TodoDatabase db = null;
		protected static string dbLocation;		
		protected static TodoItemRepositoryADO me;		

		static TodoItemRepositoryADO ()
		{
			me = new TodoItemRepositoryADO();
		}

		protected TodoItemRepositoryADO ()
		{
			dbLocation = DatabaseFilePath;

			db = new TodoDatabase(dbLocation);
		}

		public static string DatabaseFilePath 
		{
			get 
			{ 
				var sqliteFilename = "TaskDatabase.db3";
				#if NETFX_CORE
				#else

				#if SILVERLIGHT
				#else

				#if __ANDROID__
				#else
			
				string documentsPath = Environment.GetFolderPath (Environment.SpecialFolder.Personal); 
				string libraryPath = Path.Combine (documentsPath, "..", "Library"); 
				#endif
				var path = Path.Combine (libraryPath, sqliteFilename);
				#endif

				#endif
				return path;	
			}
		}

		public static TodoItem GetTask(int id)
		{
			return me.db.GetItem(id);
		}

		public static IEnumerable<TodoItem> GetTasks ()
		{
			return me.db.GetItems();
		}

		public static int SaveTask (TodoItem item)
		{
			return me.db.SaveItem(item);
		}

		public static int DeleteTask(int id)
		{
			return me.db.DeleteItem(id);
		}
	}
}

