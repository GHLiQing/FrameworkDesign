using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SYFramework
{
	/// <summary>
	/// 控制器 接口
	/// view 类继承这个接口进行重写 
	/// 获取方式：单例
	/// </summary>
	public interface IController : IBelongToArchitecture,ICanGetModel,ICanGetSystem,ICanSendCommand,ICanRegisterEvent
	{
		
	}

}
