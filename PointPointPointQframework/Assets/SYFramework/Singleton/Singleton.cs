using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace SYFramework
{
    public class Singleton <T> where  T: Singleton<T>
    {

        protected static T mInstansce = null;

        public static T Instance
        {
            get
            {
                if (mInstansce==null)
                {
                    //获得限定的构造方法 非公共的 非实例的
                    var  ctors = typeof(T).GetConstructors(BindingFlags.Instance| BindingFlags.NonPublic);

                    //获取无参的构造方法
                    var cotr = Array.Find(ctors, c => c.GetParameters().Length == 0);

                    if (cotr==null)
                    {
                        throw new Exception("没有找到单例" + typeof(T).Name);
                    }

                   mInstansce=  cotr.Invoke(null) as T;
                }
                
                return mInstansce;
            }
            
            
        }


    }

}
