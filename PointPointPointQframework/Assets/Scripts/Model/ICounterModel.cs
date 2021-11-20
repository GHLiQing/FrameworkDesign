using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
namespace SYFramework
{
	/// <summary>
	/// model 接口 
	/// 用于扩展一些数据类
	/// 使用方式： 继承IModel 添加需要的属性或者方法
	/// 这里使用的是UniRx响应式属性
	/// </summary>
	public interface ICounterModel: IModel
	{   
		 ReactiveProperty<int> Count{ get; }

		BindableProprety<int> ModelName { get; }
	}

	public class CounterModel : AbstractModel, ICounterModel
	{

		protected override void OnInit()
		{
			//通过Architecture 获取
			var istorage = this.GetUtility<IStorage>();

			Count.Value = istorage.LoadInt("Counter", 0);


			Count.Subscribe(counter => {


				istorage.SavaInt("Counter", counter);
			});
		}

		public ReactiveProperty<int> Count { get; } = new ReactiveProperty<int>()
		{

			Value = 0

		};

		public BindableProprety<int> ModelName { get; } = new BindableProprety<int>()
		{
			Valuse = 0
		};
	}
}
