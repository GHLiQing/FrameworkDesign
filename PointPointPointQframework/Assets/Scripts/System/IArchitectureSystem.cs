using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
namespace SYFramework
{
	/// <summary>
	/// 系统层接口
	/// </summary>
	public interface IArchitectureSystem : ISystem
	{
		
	}

	public class ArchitectureSystem : AbstractSystem,IArchitectureSystem
	{
		

		protected override void OnInit()
		{
			//封装一层
			var coutemodel =this.GetModel<ICounterModel>();

			var late = coutemodel.Count.Value;

			
			coutemodel.Count.Subscribe(couter=> {

				if (late>couter)
				{
					Debug.Log("成就解锁"+couter);
				}
				late = couter;
			});
		}
	}

}
