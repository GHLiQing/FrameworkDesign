using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SYFramework
{
    public class Enemy : PointPointGame
    {
		
		private void OnMouseDown()
        {
            Destroy(gameObject);

			//进行了一层封装
			
			this.SendCommand<AddKillCountCommand>();
        }
    }
}

