using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SYFramework
{
	public interface IModel:IBelongToArchitecture, ICanSetArchitecture
	{
		void Init();
	}
	public abstract class AbstractModel : IModel
    {
        private IArchitecture mArchitecture = null;
        public IArchitecture GetArchitecture()
        {
            return mArchitecture;
        }

        public void SetArchitecture(IArchitecture architecture)
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
