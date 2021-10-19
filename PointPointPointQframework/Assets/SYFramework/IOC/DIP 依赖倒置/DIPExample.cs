using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
namespace SYFramework.Des
{
	public class DIPExample : MonoBehaviour
	{

		private void Start()
		{
			var container = new IOCContainer();

			//注册形式转换为接口
			container.Regitser<IStorage>(new PlayerPreString());

			var pstore = container.Get<IStorage>();

			pstore.SaveString("run", "测试 run ");

			Debug.Log("加载 数据:"+pstore.LoadString("run"));

			container.Regitser<IStorage>(new EditorPlayerP());
			var estore = container.Get<IStorage>();
			
			Debug.Log("加载 数据:" + estore.LoadString("run"));
		}
	}



	interface IStorage
	{
		void SaveString(string key, string value);

		string LoadString(string key, string value="");
	}

	public class PlayerPreString : IStorage
	{
		public string LoadString(string key, string value)
		{
			return PlayerPrefs.GetString(key);
		}

		public void SaveString(string key, string value)
		{
			PlayerPrefs.SetString(key, value);
		}
	}

	public class EditorPlayerP : IStorage
	{
		public string LoadString(string key, string value)
		{
#if UNITY_EDITOR
			return EditorPrefs.GetString(key);
#else
			retrun "";
#endif

		}

		public void SaveString(string key, string value)
		{
#if UNITY_EDITOR
			EditorPrefs.SetString(key, value);
#endif
		}
	}
}
