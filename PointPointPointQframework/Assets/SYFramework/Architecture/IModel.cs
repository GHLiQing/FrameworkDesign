using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SYFramework
{
	public interface IModel:IBelongToArchitecture, ICanSetArchitecture,ICanGetUtility,ICanSendEvent
	{
		void Init();
	}
	public abstract class AbstractModel : IModel
    {
        private IArchitecture mArchitecture = null;
		/// <summary>
		/// 接口阉割 
		/// 显示接口实现的方法不能通过对象调用 必须通过接口调用
		/// 
		/// </summary>
		/// <returns></returns>
        IArchitecture IBelongToArchitecture. GetArchitecture()
        {
            return mArchitecture;
        }

		/// <summary>
		/// 接口阉割
		/// </summary>
		/// <param name="architecture"></param>
        void ICanSetArchitecture.SetArchitecture(IArchitecture architecture)
        {
            mArchitecture = architecture;
        }

        void IModel.Init()
        {
            OnInit();
        }

        protected abstract void OnInit();

    }

}
