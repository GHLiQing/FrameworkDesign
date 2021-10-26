using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SYFramework
{
    /// <summary>
    /// 游戏开始命令
    /// </summary>
    public class GameStartEventCommand : AbstractCommand
    {
        
		public override void OnExecute()
		{
			//GameStartEvent.Trigger();
			this.SendEvent<GameStartEvent>();
		}
	}

}
