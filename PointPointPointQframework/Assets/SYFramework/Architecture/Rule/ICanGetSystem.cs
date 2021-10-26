using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SYFramework
{
	public interface ICanGetSystem : IBelongToArchitecture
	{
		
	}
	
	/// <summary>
	/// 静态扩展
	/// </summary>
	public static class CanGetSystemExtension
	{
		public static T GetSystem<T>(this ICanGetSystem self) where T : class, ISystem
		{
			return self.GetArchitecture().GetSystem<T>();
		}
	}
}
