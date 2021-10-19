using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
namespace SYFramework
{
	public class BindableProprety<T> : IEquatable<T>
	{
		private T values;

		public T Valuse
		{
			get => values;
			set
			{
				if (!values.Equals(value))
				{
					values = value;
					onCallback?.Invoke(value);
				}
			}
		}


		public bool Equals(T other)
		{
			return false;
		}

		public Action<T> onCallback;
	}

}
