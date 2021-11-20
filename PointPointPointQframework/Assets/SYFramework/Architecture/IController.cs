using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SYFramework
{
	/// <summary>
	/// 使用规则:ICanGetModel,ICanGetSystem,ICanSendCommand,ICanRegisterEvent 继承这些接口就可以使用这些功能
	/// 调用方式：view层实现这个接口 通过this 调用
	/// 
	/// </summary>
	public interface IController : IBelongToArchitecture,ICanGetModel,ICanGetSystem,ICanSendCommand,ICanRegisterEvent
	{
		
	}

	/// <summary>
	/// 可以对icontroller进行扩展 这里解决样板代码
	/// 这里扩展可以使用也可以不使用 
	/// </summary>
	public abstract class PointPointGame : MonoBehaviour, IController
	{
		IArchitecture IBelongToArchitecture.GetArchitecture()
		{
			return PointGame.Interface;
		}
	}

}
