using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace SYFramework
{
	interface IStorage:IUtility
	{
		void SavaInt(string key, int value);

		int LoadInt(string key, int value = 0);
	}

	public class PlayerStore : IStorage
	{
		public int LoadInt(string key, int value = 0)
		{
			return PlayerPrefs.GetInt(key, value);
		}

		public void SavaInt(string key, int value=0)
		{
			PlayerPrefs.SetInt(key, value);
		}
	}

	public class EditorWindoPlayerStore : IStorage
	{
		public int LoadInt(string key, int value = 0)
		{
#if UNITY_EDITOR
			return EditorPrefs.GetInt(key, value);
#else
			return "";
#endif


		}

		public void SavaInt(string key, int value=0)
		{
#if UNITY_EDITOR
			EditorPrefs.SetInt(key, value);

#endif

		}
	}
}

