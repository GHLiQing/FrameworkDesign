using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SYFramework
{

	/// <summary>
	/// 接口 ----抽象类----实现类
	/// </summary>
	public interface ICar
	{
		void Start();
		void Updata();
		void Destroy();
	}

	public abstract class FactoryCar : ICar
	{

		public bool isStart { get; set; }

		public bool isDestroy { get; set; }

		void ICar.Destroy()
		{
			isStart = false;
			isDestroy = true;
			OnDestroy();
		}

		void ICar.Updata()
		{
			OnUpdata();
		}

		void ICar.Start()
		{
			isStart = true;
			isDestroy = false;
			OnStart();
		}

		public abstract void OnStart();

		public abstract void OnUpdata();

		public abstract void OnDestroy();
	}

	public class BMW : FactoryCar
	{
		public override void OnDestroy()
		{
			Debug.Log("宝马 OnDestroy");
		}

		public override void OnStart()
		{
			Debug.Log("宝马 OnStart");
		}

		public override void OnUpdata()
		{
			Debug.Log("宝马 OnUpdata");
		}
	}

	public class InterfaceStuctExample : MonoBehaviour
	{
		private void Awake()
		{
			var bmw = new BMW();//直接new对象
			bmw.OnStart();
			bmw.OnUpdata();
			bmw.OnDestroy();
		}
	}

}
