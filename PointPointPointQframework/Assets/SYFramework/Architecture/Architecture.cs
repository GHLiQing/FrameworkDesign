using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


namespace SYFramework
{
	
	/// <summary>
	/// 架构
	/// </summary>
	/// ioc 套在里面
	/// <typeparam name="T"></typeparam>
    public abstract class Architecture<T>: IArchitecture where T: Architecture<T>,new()
    {
		#region 单例写法
		private static T mArchitecture;

		public static IArchitecture Interface
		{
			get
			{
				if (mArchitecture == null)
				{
					
					MakeSureArchitecture();
				}
				return mArchitecture;
			}
		}
		#endregion

		#region model and system
		/// <summary>
		/// 是否已经初始化完成
		/// </summary>
		private bool mInited = false;

		/// <summary>
		/// 用于初始化的 Systems 的缓存
		/// </summary>
		private List<ISystem> mSystems = new List<ISystem>(); // 新增

		// 提供一个注册 Model 的 API
		public void RegisterSystem<T>(T instance) where T : ISystem // 新增
		{
			// 需要给 Model 赋值一下
			instance.SetArchitecture (this); //互相持有

			mContainer.Regitser<T>(instance); //注册到ioc中

			// 如果初始化过了
			if (mInited)
			{
				instance.Init();
			}
			else
			{
				// 添加到 Model 缓存中，用于初始化
				mSystems.Add(instance);
			}
		}

		///// <summary>
		///// 用于初始化的 Models 的缓存
		///// </summary>
		private List<IModel> mModels = new List<IModel>();

		public void RegisterModel<T>(T instance) where T : IModel
		{
			// 需要给 Model 赋值一下
			instance.SetArchitecture(this);

			mContainer.Regitser<T>(instance);
			
			//如果初始化过了
			if (mInited)
			{
				
				instance.Init();
			}
			else
			{
				//添加到model 缓存中 用于初始化  SY:在没有初始化的时候先加入到集合中 然后在MakeSureArchitecture 中初始化
				mModels.Add(instance);
				
			}

		}

		/// <summary>
		/// 提供一个system层访问Model层api
		/// 
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <returns></returns>
		public T GetModel<T>() where T : class, IModel
		{
			return mContainer.Get<T>();
		}


		public T GetSystem<T>() where T:class,ISystem
		{
			return mContainer.Get<T>();
		}

		#endregion 类似于单例模式 尽在内部访问

		#region Utility

		/// <summary>
		/// 注册Utility
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="instance"></param>
		public void RegisterUtility<T>(T instance) where T : IUtility
		{
			mContainer.Regitser<T>(instance);
		}


		/// <summary>
		/// 获取 工具类
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <returns></returns>
		public T GetUtility<T>() where T : class, IUtility
		{
			return mContainer.Get<T>();
		}
		#endregion

		#region Command
		/// <summary>
		/// 发送命令
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		public void SendCommand<T>() where T : ICommand, new()
		{
			var command = new T();
			command.SetArchitecture(this);
			command.Execute();
		}
		/// <summary>
		/// 发送命令
		/// </summary>
		/// <typeparam name="T1"></typeparam>
		/// <param name="command"></param>
		public void SendCommand<T>(T command) where T : ICommand
		{
			command.SetArchitecture(this);
			command.Execute();
		}
		#endregion

		

		//增加注册
		public static Action<T> OnRegsiterPath = architeture => { };


        /// <summary>
        /// 确保Container 是有实例
		/// 类似于单例 仅在内部访问
        /// </summary>
        static void MakeSureArchitecture()
        {
			
            if (mArchitecture==null)
            {
			
				mArchitecture = new T();
                mArchitecture.Init();//调用注册的model system utility

				//调用
				OnRegsiterPath?.Invoke(mArchitecture);

				//初始化model
				foreach (var architectureModel in mArchitecture.mModels)
				{
					
					architectureModel.Init();
				}

				mArchitecture.mModels.Clear();
				mArchitecture.mInited = true;

				foreach (var architectureSystem in mArchitecture.mSystems) // 新增
				{
					
					architectureSystem.Init();
				}

				// 清空 System
				mArchitecture.mSystems.Clear(); // 新增

				mArchitecture.mInited = true;

			}
        }

		#region 事件

		private ITypeEventSystem typeEventSystem = new TypeEventSystem();
		public void SendEvent<T>() where T : new()
		{
			typeEventSystem.Send<T>();
		}

		public void SendEvent<T>(T e)
		{
			typeEventSystem.Send<T>(e);
		}

		public IUnRegister RegisterEvent<T>(Action<T> onEvent)
		{
			return typeEventSystem.Register<T>(onEvent);
		}

		public void UnRegisterEvent<T>(Action<T> onEvent)
		{
			typeEventSystem.UnRegister<T>(onEvent);
		}

		#endregion

		#region IOC

		/// <summary>
		/// ioc容器
		/// </summary>
		private IOCContainer mContainer = new IOCContainer();

		/// <summary>
		/// 用于初始化操作  
		/// 这里操作是 调用模块的时候
		/// </summary>
        protected  abstract void Init();

        /// <summary>
        /// 注册模块
        /// </summary>
        /// <param name="instance"></param>
        /// <typeparam name="T"></typeparam>
        public static void Register<T>(T instance)
        {
            MakeSureArchitecture();
            mArchitecture.mContainer.Regitser(instance);
        }

		
		/// <summary>
		/// 丢弃
		/// 获取模块 
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <returns></returns>
		private  static  T Get<T>() where  T: class
        {
            MakeSureArchitecture();
            return mArchitecture.mContainer.Get<T>();
        }

		


		#endregion

	}
}

