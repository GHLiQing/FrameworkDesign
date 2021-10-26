using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
namespace  SYFramework
{
    
    public class UI : MonoBehaviour,IController
    {

        private GameObject gameOverPanel;
        private void Awake()
        {
            gameOverPanel = transform.Find("GameOverPanel").gameObject;
          

			this.RegisterEvent<GameOverEevent>(GameOverCallback);
        }
        
        private void GameOverCallback(GameOverEevent gameOverEevent)
        {
            gameOverPanel.SetActive(true);
        }


		private void OnGUI()
		{
#if UNITY_EDITOR
			//测试代码
			var gamemodel = this.GetModel<IGameMode>();

			string countkill = "";
			gamemodel.KillCount.Subscribe(_ => { countkill = _.ToString(); }).AddTo(this);
			GUILayout.TextField("消灭的敌人数:"+countkill);
#endif

		}


		private void OnDestroy()
        {
			this.UnRegisterEvent<GameOverEevent>(GameOverCallback);
        }

		IArchitecture IBelongToArchitecture.GetArchitecture()
		{
			return PointGame.Interface;
		}
	}

}
