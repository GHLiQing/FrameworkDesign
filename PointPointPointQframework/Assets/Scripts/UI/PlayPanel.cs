using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace  SYFramework
{
    public class PlayPanel : MonoBehaviour,IController
    {
        //持有引用 孩子
        private Button start_Btn;

		

		private void Awake()
        {
            start_Btn = transform.Find("Start_Btn").GetComponent<Button>();
            
            start_Btn.onClick.AddListener(() =>
            {
                
                gameObject.SetActive(false);

				//无参的事件  跨模块 使用事件 解耦合

				this.SendCommand<GameStartEventCommand>();
            });
        }

		IArchitecture IBelongToArchitecture. GetArchitecture()
		{
			return PointGame.Interface;
		}
	}

}
