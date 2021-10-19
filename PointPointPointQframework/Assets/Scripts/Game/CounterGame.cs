using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SYFramework.Des;
namespace SYFramework
{
	/// <summary>
	/// 每个游戏都会有一个Game脚本 用于注册一些模块
	/// 例如： model 模块 Utitly模块
	/// </summary>
	public class CounterGame : Architecture<CounterGame>
	{
		/// <summary>
		/// 这里用于注册需要的数据
		/// </summary>
		protected override void Init()
		{

			Debug.Log("CounterGame  模块注册");
			RegisterModel<ICounterModel>(new CounterModel());

			Register<IStorage>(new PlayerStore());

			RegisterSystem<IArchitectureSystem>(new ArchitectureSystem());
			
		}
	}

}
