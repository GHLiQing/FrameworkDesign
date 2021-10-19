using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SYFramework
{
	public interface IArchitecture
	{
		//注册系统
		void RegisterSystem<T>(T instance) where T : ISystem;

		//注册model
		void RegisterModel<T>(T instance) where T : IModel;

		/// <summary>
		/// 获取 Model
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <returns></returns>
		T GetModel<T>() where T : class, IModel; // 新增
												
		void RegisterUtility<T>(T instance) where T:IUtility; //注册工具

		//获取工具
		T GetUtility<T>() where T : class, IUtility;

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
	}

}
