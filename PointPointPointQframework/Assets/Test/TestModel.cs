using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
namespace SYFramework.Test
{
	public static class TestModel
	{

		private static int count = 0;

		public static Action<int> countAction;

		public static int Count
		{

			get => count;
			set
			{
				if (count!=value)
				{
					count = value;
					countAction?.Invoke(value);
				}
			}
		}
	}


	public class IOContainer
	{
		private  Dictionary<Type, object> iocDic = new Dictionary<Type, object>();


		public  void Register<T>(T obj)
		{
			var type = typeof(T);

			if (!iocDic.ContainsKey(type))
			{
				iocDic.Add(type, obj);
			}
			else
			{
				iocDic[type] = obj;
			}
		}


		public  T Get<T>() where T : class
		{
			var type = typeof(T);
			object obj=null;
			if (iocDic.TryGetValue(type,out obj))
			{
				return obj as T;
			}
			return null;
		}
	}


	public class GameApp
	{
		private static IOCContainer Container = null;

		static void MakeSueContainer()
		{
			if (Container==null)
			{
				Container = new IOCContainer();
				Init();
			}
		}

		private static void Init()
		{
			//依赖倒置
			Container.Regitser<IModel>(new PlayerMode());
		}

	
		public static T Get<T>() where T : class
		{
			MakeSueContainer(); ;

			return Container.Get<T>();
		}

	}

	interface IModel
	{
		int Age { get; }
	}

	public class PlayerMode : IModel
	{

		private int age;
		public int Age { get => age; set => age = value; }
	}


	/// <summary>
	/// 架构
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public abstract class Architecture<T> where T:Architecture<T>,new()
	{
		private static T mArchitecture = null;

		static void MakeSureArchitecture()
		{
			if (mArchitecture==null)
			{
				mArchitecture = new T();
				mArchitecture.Init();
			}
		}


		protected abstract void Init();


		private IOCContainer container = null;

		public void Register<T>(T obj)
		{
			MakeSureArchitecture();
			mArchitecture.container.Regitser<T>(obj);
		}

		/// <summary>
		/// 获取 实例
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <returns></returns>
		public static T Get<T>() where T : class
		{
			MakeSureArchitecture();
			return mArchitecture.container.Get<T>();
		}

	}


	public class Single<T> where T : class
	{
		private static T instance = null;

		public static T Instance
		{
			get
			{
				if (instance==null)
				{
					var conts = typeof(T).GetConstructors(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);

					var cont = Array.Find(conts, c => c.GetParameters().Length == 0);

					if (cont==null)
					{
						Debug.Log("没有实例");
					}
					instance = cont.Invoke(null) as T;
				}
				return instance;
			}
		}
	}

}
