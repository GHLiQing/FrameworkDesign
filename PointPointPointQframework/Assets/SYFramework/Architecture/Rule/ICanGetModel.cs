using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SYFramework
{
	/// <summary>
	/// 使用规则：
	/// 把system mdel utility command 全部阉割掉 
	/// 对应的ICanGetXXX继承之后 就可以通过this访问
	/// </summary>
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

