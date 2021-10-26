using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SYFramework
{

	/// <summary>
	/// 命令接口 用于扩展
	/// 实现游戏逻辑
	/// </summary>
    public interface ICommand:IBelongToArchitecture,ICanSetArchitecture,ICanGetModel,ICanGetSystem,ICanGetUtility,ICanSendEvent,ICanSendCommand
    {
        void Execute();//执行命令
    }

	public abstract class AbstractCommand : ICommand
	{

		private IArchitecture mArchitecture = null;
		void ICommand.Execute()
		{
			OnExecute();
		}

		public abstract void OnExecute();

		IArchitecture  IBelongToArchitecture.GetArchitecture()
		{
			return mArchitecture;
		}

		 void ICanSetArchitecture.SetArchitecture(IArchitecture architecture)
		{
			this.mArchitecture = architecture;
		}

		
	}
}

