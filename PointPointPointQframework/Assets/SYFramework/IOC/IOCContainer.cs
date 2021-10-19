using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace SYFramework
{
    public class IOCContainer
    {
        public Dictionary<Type, object> mInstances = new Dictionary<Type, object>();
        
        /// <summary>
        /// 注册实例 
        /// </summary>
        /// <param name="instance"></param>
        /// <typeparam name="T"></typeparam>
        public void Regitser<T>(T instance) 
        {
            var type = typeof(T);

            if (mInstances.ContainsKey(type))
            {
                mInstances[type] = instance;
            }
            else
            {
                mInstances.Add(type,instance);
            }       
        }

        /// <summary>
        /// 获取实例
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T Get<T>() where  T: class
        {
            var type = typeof(T);
            object obj = null;
            if (mInstances.TryGetValue(type,out obj))
            {
                return obj as T;
            }

            return null;
        }
        
    }
}

