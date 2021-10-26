using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SYFramework
{
	public interface ICanGetModel :IBelongToArchitecture
	{
		
	}

	/// <summary>
	/// 静态扩展
	/// </summary>
	public static class CanGetModelExtension
	{
		public static T GetModel<T>(this ICanGetModel self) where T : class, IModel
		{
			return self.GetArchitecture().GetModel<T>();
		} 
	}
}

