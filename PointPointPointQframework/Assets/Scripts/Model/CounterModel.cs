using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

namespace SYFramework
{
	public class CounterModel : AbstractModel, ICounterModel
	{

		protected override void OnInit()
		{
			//通过Architecture 获取
			var istorage = GetArchitecture().GetUtility<IStorage>();
			
			Count.Value = istorage.LoadInt("Counter",0);

			
			Count.Subscribe(counter => {

				
				istorage.SavaInt("Counter", counter);
			});
		}

		public ReactiveProperty<int> Count { get; } = new ReactiveProperty<int>() {

		Value=0
		
		};


		//public IArchitecture Architecture { get; set; }
	}

}
