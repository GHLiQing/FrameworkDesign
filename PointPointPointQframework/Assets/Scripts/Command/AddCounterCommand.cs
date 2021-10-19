using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SYFramework
{
	//加加 
	public class AddCounterCommand : AbstractCommand
	{
	
		public override void OnExecute()
		{
			GetArchitecture().GetModel<ICounterModel>().Count.Value++;
		}
	}

}
