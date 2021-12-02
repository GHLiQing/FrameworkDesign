using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SYFramework
{
	public class TypeEventSystemExample : MonoBehaviour
	{

		/// <summary>
		/// 结构体类型
		/// </summary>
		struct EventA
		{

		}
		struct EventB
		{
			public int id;
		}

		/// <summary>
		/// 接口类型
		/// </summary>
		interface IEventSystem
		{

		}
		public class EventC : IEventSystem
		{
			public int id;
		}

		public class EventD : IEventSystem
		{

		}

		private ITypeEventSystem eventSystem = new TypeEventSystem();

		private void Awake()
		{
			eventSystem.Register<EventA>(_=> {
				Debug.Log("structA");

			}).UnRegisterWhenGameObjectDsetroyed(gameObject);

			eventSystem.Register<EventB>(_=> {
				Debug.Log("structB : "+_.id);

			}).UnRegisterWhenGameObjectDsetroyed(gameObject);

			eventSystem.Register<IEventSystem>(EventSystemCallbackC);

		}


		private void Update()
		{
			if (Input.GetKeyDown(KeyCode.Q))
			{
				eventSystem.Send<EventA>();
			}
			if (Input.GetKeyDown(KeyCode.W))
			{
				eventSystem.Send<EventB>(new EventB() {  id=10});
			}
			if (Input.GetKeyDown(KeyCode.E))
			{
				eventSystem.Send<IEventSystem>(new EventC() {  id=100});
			}

			if (Input.GetKeyDown(KeyCode.R))
			{
				eventSystem.Send<IEventSystem>(new EventD());
			}
		}

		private void EventSystemCallbackC(IEventSystem eventC)
		{
			if (eventC is EventC)
			{

				Debug.Log("这是c "+ (eventC as EventC).id);
			}
			if (eventC is EventD)
			{
				Debug.Log("这是D");
			}
		}
	}

}
