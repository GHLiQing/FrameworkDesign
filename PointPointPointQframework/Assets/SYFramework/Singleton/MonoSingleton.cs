using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace  SYFramework
{
    public abstract class MonoSingleton<T> : MonoBehaviour where  T : MonoSingleton<T>
    {
        protected static T mInstance = null;

        public static T Instance
        {
            get
            {
                if (mInstance==null)
                {
                      mInstance= FindObjectOfType<T>();
                      if (FindObjectsOfType<T>().Length>0)  //查找场景所有的当前单例
                      {
                          Debug.Log("不止一个 当前单例:"+typeof(T).Name );
                          return mInstance;
                      }
                      if (mInstance==null)
                      {
                          var mInstanceName= typeof(T).Name;
                          Debug.Log("实例化"+mInstanceName);
                          var mInsatanceObj = GameObject.Find(mInstanceName);
                          if (mInsatanceObj==null)
                              mInsatanceObj = new GameObject(mInstanceName);
                          mInstance=mInsatanceObj.AddComponent<T>(); 
                          DontDestroyOnLoad(mInstance);
                              
                          Debug.LogFormat("添加一个单例：{0}",typeof(T).Name);

                      }
                      else
                      {
                          Debug.LogError("已经存在当前单例"+typeof(T).Name);
                      }
                }

                return mInstance;


            }
        }

        protected virtual void OnDestroy()
        {
            mInstance = null;
        }
    }

}
