using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

namespace SYFramework
{
    public class Game : MonoBehaviour
    {
        private void Awake()
        {
            #region 注册 事件

            GameStartEvent.Register(GameStartEventCallback);

            #endregion
            
        }

        #region 回调 事件 
        private void GameStartEventCallback()
        {
           transform.Find("Enemris").gameObject.SetActive(true);
        }


        #endregion
       
        private void OnDestroy()
        {
            #region 取消注册
            GameStartEvent.UnRegister(GameStartEventCallback);
           
            #endregion
            
        }
    }
}

