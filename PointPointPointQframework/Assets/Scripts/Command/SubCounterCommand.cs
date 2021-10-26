using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SYFramework
{
	public class SubCounterCommand : AbstractCommand
	{

		/// <summary>
		/// 减操作
		/// </summary>
		public override void OnExecute()
		{
			this.GetModel<ICounterModel>().Count.Value--;
		}
	}

}
