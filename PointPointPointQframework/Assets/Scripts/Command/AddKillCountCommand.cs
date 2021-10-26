using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

/// <summary>
/// 表现逻辑  model-->view
/// </summary>
namespace SYFramework
{
    /// <summary>
    /// 封装成 结构体
    /// 结构体优点： 可以减少new 对象带来的内存回收，寻址操作
    /// 结构体体量更小
    /// 杀掉敌人命令
    /// </summary>
    public class AddKillCountCommand : AbstractCommand
    {

		/// <summary>
		/// 执行 ++   
		/// </summary>
		public override void OnExecute()
		{
			//获得实例
			var gamemodel = this.GetModel<IGameMode>();
			gamemodel.KillCount.Value++;

			gamemodel.KillCount
				.Subscribe(values =>
				{
					if (values == 10)
					{

						this.SendEvent<GameOverEevent>();
					}
				});
		}
	}


    public class SubKillCountCommand :AbstractCommand
    {
      
     
		/// <summary>
		/// 执行  --
		/// </summary>
		public override void OnExecute()
		{
			var gamemodel = this.GetModel<IGameMode>();
			gamemodel.KillCount.Value--;
			gamemodel.KillCount
				.Subscribe(values =>
				{
					if (values == 0)
					{
						//GameOverEevent.Trigger();
						//new GameOverEventCommand().OnExecute();
						this.SendEvent<GameOverEevent>();
					}
				});
		}
	}

}
