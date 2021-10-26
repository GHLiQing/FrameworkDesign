using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
namespace SYFramework
{
	/// <summary>
	/// 用于注销
	/// </summary>
	public interface IUnRegister
	{
		void UnRegister();
	}

	public interface ITypeEventSystem
	{
		/// <summary>
		/// 发送事件
		/// </summary>
		/// <typeparam name="T"></typeparam>
		void Send<T>() where T: new ();

		void Send<T>(T e);


		/// <summary>
		/// 注册事件
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="OnEvent"></param>
		/// <returns></returns>
		IUnRegister Register<T>(Action<T> OnEvent);


		/// <summary>
		/// 注销事件
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="OnEvent"></param>
		void UnRegister<T>(Action<T> OnEvent);
	}

	/// <summary>
	/// 注册接口实现
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public class TypeEventSystemUnRegister<T> : IUnRegister
	{
		public ITypeEventSystem TypeEventSystem { get; set; }

		public Action<T> OnEvent { get; set; }

		public void UnRegister()
		{
			TypeEventSystem.UnRegister(OnEvent);
			TypeEventSystem = null;
			OnEvent = null;
		}
	}

	/// <summary>
	/// 注销的触发器
	/// </summary>
	public class UnRegisterOnDestroyTrigger : MonoBehaviour
	{
		private HashSet<IUnRegister> mUnRegisters = new HashSet<IUnRegister>();

		public void AddUnRegister(IUnRegister unRegister)
		{
			mUnRegisters.Add(unRegister);
		}

		private void OnDestroy()
		{
			foreach (var item in mUnRegisters)
			{
				item.UnRegister();
			}
			mUnRegisters.Clear();
		}
	}

	public static class UnRegisterExtension
	{
		public static void UnRegisterWhenGameObjectDsetroyed(this IUnRegister unRegister,GameObject gameObject)
		{
			var trigger = gameObject.GetComponent<UnRegisterOnDestroyTrigger>();

			if (!trigger)
			{
				trigger = gameObject.AddComponent<UnRegisterOnDestroyTrigger>();
			}
			trigger.AddUnRegister(unRegister);
		}

	}

	public class TypeEventSystem : ITypeEventSystem
	{
		interface IRegistrations
		{

		}

		class Registrations<T> : IRegistrations
		{
			/// <summary>
			/// 因为委托本身就可以一对多注册
			/// </summary>
			public Action<T> OnEvent = obj => { };
		}

		private Dictionary<Type, IRegistrations> mEventRegistrations = new Dictionary<Type, IRegistrations>();

		public void Send<T>() where T : new()
		{
			var e = new T();
			Send<T>(e);
		}

		public void Send<T>(T e)
		{
			var type = typeof(T);
			IRegistrations eventRegistrations;

			if (mEventRegistrations.TryGetValue(type, out eventRegistrations))
			{
				(eventRegistrations as Registrations<T>)?.OnEvent.Invoke(e);
			}

		}

		public IUnRegister Register<T>(Action<T> onEvent)
		{
			var type = typeof(T);
			IRegistrations eventRegistrations;

			if (mEventRegistrations.TryGetValue(type, out eventRegistrations))
			{

			}
			else
			{
				eventRegistrations = new Registrations<T>();
				mEventRegistrations.Add(type, eventRegistrations);
			}

			(eventRegistrations as Registrations<T>).OnEvent += onEvent;

			return new TypeEventSystemUnRegister<T>()
			{
				OnEvent = onEvent,
				TypeEventSystem = this
			};
		}

		public void UnRegister<T>(Action<T> onEvent)
		{
			var type = typeof(T);
			IRegistrations eventRegistrations;

			if (mEventRegistrations.TryGetValue(type, out eventRegistrations))
			{
				(eventRegistrations as Registrations<T>).OnEvent -= onEvent;
			}
		}
	}
}

