using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SYFramework
{

	/// <summary>
	/// 使用规则：
	/// ICanGetModel,ICanGetSystem,ICanGetUtility,ICanSendEvent,ICanSendCommand
	/// 继承了这些接口 就可以使用这些功能 
	/// 使用方法：this
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

