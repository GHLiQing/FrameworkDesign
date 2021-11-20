using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SYFramework
{

	/// <summary>
	/// 系统层
	/// 使用规则：
	/// ICanGetModel,ICanGetUtility,ICanSendEvent,ICanRegisterEvent
	/// 继承了这些接口就可以使用这些功能
	/// </summary>
	public interface ISystem: IBelongToArchitecture, ICanSetArchitecture,ICanGetModel,ICanGetUtility,ICanSendEvent,ICanRegisterEvent
	{
		void Init();
	}
	public abstract class AbstractSystem : ISystem
	{
		private IArchitecture mArchitecture = null;//互相持有 关联
		/// <summary>
		/// 接口阉割
		/// </summary>
		/// <returns></returns>
		IArchitecture IBelongToArchitecture.GetArchitecture()
		{
			return mArchitecture;
		}

		/// <summary>
		/// 接口阉割
		/// </summary>
		/// <param name="architecture"></param>
		void ICanSetArchitecture.SetArchitecture(IArchitecture architecture) //互相持有 依赖
		{
			mArchitecture = architecture;
		}

		void ISystem.Init()
		{
			OnInit();
		}

		protected abstract void OnInit();
	}
}