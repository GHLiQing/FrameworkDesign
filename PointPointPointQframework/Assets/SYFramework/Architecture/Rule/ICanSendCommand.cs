using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SYFramework
{
	public interface ICanSendCommand : IBelongToArchitecture
	{
		
	}

	public static class CanSendCommandExtension
	{
		public static void SendCommand<T>(this ICanSendCommand self) where T :  ICommand,new() //有一个无参的构造函数
		{
			self.GetArchitecture().SendCommand<T>();
		}

		public static void SendCommand<T>(this ICanSendCommand self,T command) where T :ICommand
		{
			self.GetArchitecture().SendCommand<T>(command);
		}
	}

}
