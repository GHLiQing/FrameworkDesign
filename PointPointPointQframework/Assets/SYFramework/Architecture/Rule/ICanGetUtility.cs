using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SYFramework
{
	public interface ICanGetUtility : IBelongToArchitecture
	{
		
	}

	/// <summary>
	/// 添加使用规则 ：需要使用Utility接口的实现ICanGetUtility即可
	/// </summary>
	public static class CanGetUtilityExtension
	{
		public static T GetUtility<T>(this ICanGetUtility self) where T : class, IUtility
		{
			return self.GetArchitecture().GetUtility<T>();
		}
	}

}
