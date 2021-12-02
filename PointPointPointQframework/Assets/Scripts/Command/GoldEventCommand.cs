using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SYFramework
{
	public class GoldEventCommand : AbstractCommand
	{
		public override void OnExecute()
		{
			this.GetModel<ICounterModel>().Gold.Valuse = Random.Range(-10, 10);
		}
	}

}
