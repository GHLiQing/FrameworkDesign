using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SYFramework
{
	public class CountApp
	{
		private static IOCContainer mIOCContainer = null;

		/// <summary>
		/// 确保有一个ioccontainer 的实例
		/// </summary>
		static void MakeSureContainer()
		{
			if (mIOCContainer==null)
			{
				mIOCContainer = new IOCContainer();
				Init();
			}
		}

		/// <summary>
		/// 注册模块
		/// </summary>
		private static void Init()
		{
			mIOCContainer.Regitser(new GameModel());
		}

		/// <summary>
		/// 获取模块
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <returns></returns>
		public static T Get<T> () where T : class
		{
			MakeSureContainer();
			return mIOCContainer.Get<T>();
		}



	}

}
