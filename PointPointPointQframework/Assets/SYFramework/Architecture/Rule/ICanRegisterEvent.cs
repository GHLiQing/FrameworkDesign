using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
namespace SYFramework
{
	public interface ICanRegisterEvent : IBelongToArchitecture
	{
		
	}

	public static class CanRegisterEventExtension
	{
		public static IUnRegister RegisterEvent<T>(this ICanRegisterEvent self,Action<T> action)
		{
			return self.GetArchitecture().RegisterEvent<T>(action);
		}

		public static void UnRegisterEvent<T>(this ICanRegisterEvent self,Action<T> onEvent)
		{
			self.GetArchitecture().UnRegisterEvent<T>(onEvent);
		}

	}
}

