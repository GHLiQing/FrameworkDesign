using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
namespace SYFramework
{
	public interface IArchitecture
	{
		//注册系统
		void RegisterSystem<T>(T instance) where T : ISystem;

		//注册model
		void RegisterModel<T>(T instance) where T : IModel;

		void RegisterUtility<T>(T instance) where T : IUtility; //注册工具


		/// <summary>
		/// 获取 Model
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <returns></returns>														
		T GetModel<T>() where T : class, IModel; // 新增
												
		//获取工具
		T GetUtility<T>() where T : class, IUtility;

		//增加获得系统层方法
		T GetSystem<T>() where T : class, ISystem;

		/// <summary>
		/// 发送命令
		/// </summary>
		/// <typeparam name="T"></typeparam>
		void SendCommand<T>() where T : ICommand, new();



		/// <summary>
		/// 发送命令
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="command"></param>
		void SendCommand<T>(T command) where T : ICommand;

		/// <summary>
		/// 发送事件
		/// </summary>
		/// <typeparam name="T"></typeparam>
		void SendEvent<T>() where T : new();

		/// <summary>
		/// 发送事件
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="e"></param>
		void SendEvent<T>(T e);

		/// <summary>
		/// 注册事件
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="onEvent"></param>
		/// <returns></returns>
		IUnRegister RegisterEvent<T>(Action<T> onEvent);

		/// <summary>
		/// 注销事件
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="onEvent"></param>
		void UnRegisterEvent<T>(Action<T> onEvent);

	}

}
