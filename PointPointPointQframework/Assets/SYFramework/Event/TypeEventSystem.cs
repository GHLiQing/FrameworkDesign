using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
namespace SYFramework.Design
{

    public class TypeEventSystem
    {
        public interface IRegisteraction
        {
        
        }

        public class Registeraction<T> : IRegisteraction
        {
            public  Action<T> onEvent = obj => { };
        }


        public static Dictionary<Type, IRegisteraction> mTypeEventDic = new Dictionary<Type, IRegisteraction>();
        
        
        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="t"></param>
        /// <typeparam name="T"></typeparam>
        public static void Send<T>(T t)
        {
            Type type = typeof(T);
            IRegisteraction registeraction = null;
            if (mTypeEventDic.TryGetValue(type,out  registeraction))
            {
                var register = registeraction as Registeraction<T>;
                register.onEvent?.Invoke(t);
            }

        }


        /// <summary>
        /// 注册消息
        /// </summary>
        /// <param name="onRecive"></param>
        /// <typeparam name="T"></typeparam>
        public static void Register<T>(Action<T> onRecive)
        {
            Type type = typeof(T);
            IRegisteraction registeraction = null;

            if (mTypeEventDic.TryGetValue(type,out  registeraction))
            {
                var register = registeraction as Registeraction<T>;
                register.onEvent += onRecive;
            }
            else
            {
                var register = new Registeraction<T>();
                register.onEvent += onRecive;
                mTypeEventDic.Add(type,registeraction);
            }
        }



        /// <summary>
        /// 注销消息
        /// </summary>
        /// <param name="onRecive"></param>
        /// <typeparam name="T"></typeparam>
        public static void UnRegister<T>(Action<T> onRecive)
        {
            Type type = typeof(T);
            IRegisteraction registeraction = null;

            if (mTypeEventDic.TryGetValue(type,out  registeraction))
            {
                var register = registeraction as Registeraction<T>;
                register.onEvent -= onRecive;
            }
        }


    }

    
}
