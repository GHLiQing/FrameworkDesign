using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SocialPlatforms.Impl;
using UniRx;
namespace SYFramework
{

    public enum GameState
    {
        NotStart,
        Started,
        Over
    }

	public interface IGameMode:IModel
	{
		ReactiveProperty<int> KillCount { get;  }
		ReactiveProperty<int> Gold { get; }
		ReactiveProperty<int> Score { get;  }
		ReactiveProperty<int> BaseScore { get;  }
	}

    /// <summary>
    /// 游戏数据 
	/// 1 可以使用单例
	/// 2 现在是用的是ioc
    /// </summary>
    public  class GameModel :AbstractModel, IGameMode
    {

        //游戏状态
        public  GameState mGameState = GameState.NotStart;

		public ReactiveProperty<int> KillCount { get; } = new ReactiveProperty<int>() { Value=0};

		public ReactiveProperty<int> Gold { get; } = new ReactiveProperty<int>() { Value = 0 };

		public ReactiveProperty<int> Score { get; } = new ReactiveProperty<int>() { Value = 0 };

		public ReactiveProperty<int> BaseScore { get; } = new ReactiveProperty<int>() { Value = 0 };

		protected override void OnInit()
		{
			
		}


		//响应式 属性

	}

}
