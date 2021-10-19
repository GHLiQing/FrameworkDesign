using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SYFramework
{
    public class Enemy : MonoBehaviour,IController
    {
		public IArchitecture GetArchitecture()
		{
			return PointGame.Interface;
		}

		private void OnMouseDown()
        {
            Destroy(gameObject);

			//进行了一层封装
			 //new AddKillCountCommand().OnExecute(); //3 
			GetArchitecture().SendCommand<AddKillCountCommand>();
        }
    }
}

