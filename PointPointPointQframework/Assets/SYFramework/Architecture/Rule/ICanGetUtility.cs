using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SYFramework
{
	public interface ICanGetUtility : IBelongToArchitecture
	{
		
	}

	/// <summary>
	/// 静态扩展
	/// </summary>
	public static class CanGetUtilityExtension
	{
		public static T GetUtility<T>(this ICanGetUtility self) where T : class, IUtility
		{
			return self.GetArchitecture().GetUtility<T>();
		}
	}

}
