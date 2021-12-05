using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
namespace SYFramework
{

	/// <summary>
	/// 响应式属性
	/// int string  等类型
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public class BindableProprety<T>
	{
		private T mValues;

		public T Valuse
		{
			get => mValues;
			set
			{
				mValues = value;
				OnValueChanged?.Invoke(value);
			}
		}

		public Action<T> OnValueChanged=(v)=> { };

		/// <summary>
		/// 返回值用于调用UnRegister 方法取消注册 
		/// </summary>
		/// <param name="onValueChanged"></param>
		/// <returns></returns>
		public IUnRegister Register(Action<T> onValueChanged)
		{
			OnValueChanged += onValueChanged;
			return new BindablePropretyUnRegister<T>()
			{
				BindableProprety = this,
				OnValueChanged = onValueChanged
			};
		}

		
		public void UnRegisterOnValueChanged(Action<T> onValueChanged)
		{
			OnValueChanged -= onValueChanged;
		}

	}

	public class BindablePropretyUnRegister<T> : IUnRegister
	{
		public BindableProprety<T> BindableProprety { get; set; } //互相引用

		public Action<T> OnValueChanged { get; set; }

		public void UnRegister()
		{
			BindableProprety.UnRegisterOnValueChanged(OnValueChanged);
		}
	}

}
