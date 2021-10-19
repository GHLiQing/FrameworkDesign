using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace SYFramework
{
    public class IOCExample : MonoBehaviour
    {
        private void Awake()
        {
            //创建一个ioc 容器
            IOCContainer iocContainer = new IOCContainer();
            
            //注册一个实例
            iocContainer.Regitser(new Mood());

            //获取一个实例
            Mood p1 = iocContainer.Get<Mood>();
			p1.Test();
        }
    }


    public class Mood
    {
        public void Sad()
        {
            Debug.Log("这个人不开心");
        }

		public void Test()
		{
			Debug.Log("测试代码 mood");
		}
    }
	
    
}
