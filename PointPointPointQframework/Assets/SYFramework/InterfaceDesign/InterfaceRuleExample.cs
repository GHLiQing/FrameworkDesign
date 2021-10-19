using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SYFramework
{
	public class CanDoEveryThing
	{
		public void DoSomthing1()
		{
			Debug.Log("DoSomthing1");
		}
		public void DoSomthing2()
		{
			Debug.Log("DoSomthing2");
		}

		public void DoSomthing3()
		{
			Debug.Log("DoSomthing3");
		}
	}

	public interface IHasEveryThing
	{
		CanDoEveryThing CanDoEveryThing { get; }
	}

	public interface ICanDoSometing1 : IHasEveryThing
	{
		
	}

	/// <summary>
	/// 静态扩展
	/// </summary>
	public static class ICanDoSomeThing1Extensions
	{
		public static void DoSomething1(this ICanDoSometing1 self)
		{
			self.CanDoEveryThing.DoSomthing1();
		}
	}
	public interface ICanDoSomething2 : IHasEveryThing
	{
		
	}
	/// <summary>
	/// 静态扩展
	/// </summary>
	public static class ICanDoSomeThing2Extensions
	{
		public static void DoSomething2(this ICanDoSomething2 self)
		{
			self.CanDoEveryThing.DoSomthing2();
		}
	}

	public interface ICanDoSomething3 : IHasEveryThing
	{
		
	}
	/// <summary>
	/// 静态扩展
	/// </summary>
	public static class ICanDoSomeThing3Extensions
	{
		public static void DoSomething3(this ICanDoSomething3 self)
		{
			self.CanDoEveryThing.DoSomthing3();
		}
	}



	public class InterfaceRuleExample : MonoBehaviour
	{

		public class OnlyCanDo1 : ICanDoSometing1
		{
			CanDoEveryThing IHasEveryThing.CanDoEveryThing { get; } = new CanDoEveryThing();
		}

		public class OnlyCanDo23 : ICanDoSomething2, ICanDoSomething3
		{
			CanDoEveryThing IHasEveryThing.CanDoEveryThing { get; } = new CanDoEveryThing();
		}


		private void Awake()
		{
			var onlyCanDo1 = new OnlyCanDo1();
			//可以直接调用
			onlyCanDo1.DoSomething1();

			// 不能调用 DoSomething2 和 3 会报编译错误
			// onlyCanDo1.DoSomething2();
			// onlyCanDo1.DoSomething3();


			var onlyCanDo23 = new OnlyCanDo23();
			// 不可以调用 DoSomething1 会报编译错误
			// onlyCanDo23.DoSomething1();
			// 可以调用 DoSomething2 和 3
			onlyCanDo23.DoSomething2();
			onlyCanDo23.DoSomething3();
		}
	}

}
