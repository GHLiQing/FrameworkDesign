using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SYFramework
{
	/// <summary>
	/// 游戏结束命令
	/// </summary>
	public class GameOverEventCommand : AbstractCommand
	{
		
		public override void OnExecute()
		{
			//GameOverEevent.Trigger();
			this.SendEvent<GameOverEevent>();
		}
	}

}
