using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SYFramework
{
	public class A
	{

	}

	public struct B
	{
		public int value;
	}

	public class EventExample : MonoBehaviour
	{


		public ITypeEventSystem eventSystem = null;
		private void Awake()
		{
			eventSystem = new TypeEventSystem();

			eventSystem.Register<A>(ac =>
			{
				Debug.Log("注册");

			}).UnRegisterWhenGameObjectDsetroyed(gameObject);


			eventSystem.Register<B>(BCallbacke);

		}

		private void Update()
		{
			if (Input.GetMouseButtonDown(0))
			{
				eventSystem.Send<A>();
			}
			if (Input.GetKeyDown(KeyCode.Space))
			{
				eventSystem.Send<B>(new B() {

					value = 100
				});
			}
		}


		public void BCallbacke(B b)
		{
			Debug.Log("BBBBBBBBBBBBBBBBBBB"+":"+b.value);
		}


		private void OnDestroy()
		{
			eventSystem.UnRegister<B>(BCallbacke);
			eventSystem = null;

		}
	}

}

