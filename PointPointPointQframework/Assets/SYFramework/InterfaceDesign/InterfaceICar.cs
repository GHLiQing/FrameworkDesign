using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SYFramework.Design
{

	public class Car
	{
		public void Seat()
		{
			Debug.Log("五座 生产");
		}

		public void CarType()
		{
			Debug.Log("宝马 车标");
		}
	}

	public interface IFactoryICar
	{
		Car car { get; }
	}

	public interface IBMWFactory : IFactoryICar
	{

	}

	/// <summary>
	/// 静态扩展
	/// </summary>
	public static class IBMStaticExtance
	{
		public static void CreatBMWCar(this IBMWFactory self)
		{
			self.car.Seat();
		}
	}

	public class InterfaceICar : MonoBehaviour
	{

		public class BMW : IBMWFactory
		{
			public Car car =>new Car();
		}

		private void Awake()
		{
			BMW bMW = new BMW();
			bMW.CreatBMWCar();
			bMW.car.Seat();
		}
	}

}
