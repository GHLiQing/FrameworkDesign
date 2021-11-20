using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
namespace SYFramework
{

	/// <summary>
	/// 响应式属性
	/// int  等类型
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public class BindableProprety<T> where T : IEquatable<T>
	{
		private T mValues;

		public T Valuse
		{
			get => mValues;
			set
			{
				if (!mValues.Equals(value))
				{
					mValues = value;
					OnValueChanged?.Invoke(value);
				}
			}
		}

		public Action<T> OnValueChanged;
	}

}
