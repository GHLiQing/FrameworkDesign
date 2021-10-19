using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SYFramework
{

	/// <summary>
	/// 命令接口 用于扩展
	/// 实现游戏逻辑
	/// </summary>
    public interface ICommand:IBelongToArchitecture,ICanSetArchitecture
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

		public IArchitecture GetArchitecture()
		{
			return mArchitecture;
		}

		public void SetArchitecture(IArchitecture architecture)
		{
			this.mArchitecture = architecture;
		}

		
	}
}

