using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace SYFramework
{
	interface ICanSayHello
	{
		void SayHello();
		void SayOther();
	}

	public class InterfaceDesignExample : MonoBehaviour, ICanSayHello
	{
		///// <summary>
		///// 接口的隐私调用
		///// </summary>
		public void SayHello()
		{
			Debug.Log("说 你好");
		}
		void ICanSayHello.SayOther()
		{
			Debug.Log("说 other");
		}


		private void Awake()
		{
			// 直接调用 通过对象调用
			this.SayHello();

			//必须转换之后才可以调用 必须通过接口对象调用
			(this as ICanSayHello).SayOther();
		}

		
	}

}
