using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SYFramework
{
	/// <summary>
	/// 事件扩展 
	/// 基类
	/// 使用方法：直接创建子类 继承即可
	/// </summary>
	/// <typeparam name="T"></typeparam>
    public class Event<T> where  T:Event<T>
    {
        public static Action mOnEventTrigger;

        public static void Register(Action onEvent)
        {
            mOnEventTrigger += onEvent;
        }

        public static void UnRegister(Action onEvent)
        {
            mOnEventTrigger -= onEvent;
        }

        public static void Trigger()
        {
            mOnEventTrigger?.Invoke();
        }
    }
    
}

