using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SYFramework
{

	/// <summary>
	/// 系统层
	/// </summary>
	public interface ISystem: IBelongToArchitecture, ICanSetArchitecture
	{
		void Init();
	}
	public abstract class AbstractSystem : ISystem
	{
		private IArchitecture mArchitecture = null;//互相持有 关联
		public IArchitecture GetArchitecture()
		{
			return mArchitecture;
		}

		public void SetArchitecture(IArchitecture architecture) //互相持有 依赖
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