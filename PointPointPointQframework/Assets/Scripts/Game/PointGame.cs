using System;
using System.Collections;
using System.Collections.Generic;
using UniRx.InternalUtil;
using UnityEngine;


namespace SYFramework
{
	/// <summary>
	/// 每个游戏都会有一个Game脚本 用于注册一些模块使用
	/// 所有的模块 全部注册到init 方法中 通过PointGame类获取模块Get
	/// 这里注册model模块 让后获取模块
	/// </summary>
	public class PointGame:Architecture<PointGame>
    {
		

		protected override void Init()
		{
			Register<IGameMode>(new GameModel());
			//Register<IGameMode>(new GameModel()); 继续注册模块
		}
	}

}
