using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;


namespace SYFramework
{
	public class CountPanelViewController : MonoBehaviour,IController
	{

		//获得数据
		private ICounterModel mCounterModel;

		private Button add_Btn;

		private Button sub_Btn;

		private Text count_Txt;

		private void Awake()
		{
			Find();
			Register();
			ModelDate();
		}

		private void Find()
		{
			add_Btn = transform.Find("Add_Btn").GetComponent<Button>() ;
			sub_Btn = transform.Find("Sub_Btn").GetComponent<Button>();
			count_Txt = transform.Find("Count_Txt").GetComponent<Text>();

			
		}

		private void ModelDate()
		{
			
			mCounterModel = this.GetModel<ICounterModel>();

			//表现逻辑
			mCounterModel.Count.Subscribe(counter =>
			{
				count_Txt.text = counter.ToString();
			});

		
			mCounterModel.Gold.Register(gold => {

				Debug.Log("Golde:" + gold);
			}).UnRegisterWhenGameObjectDsetroyed(gameObject);


			mCounterModel.Name.OnValueChanged = name =>
			{

				Debug.Log(name);
			};
		}

		private void Register()
		{
			add_Btn.onClick.AddListener(()=> {

				//交互逻辑
				this.SendCommand<AddCounterCommand>();

				this.GetModel<ICounterModel>().Name.Valuse = "小红";
			});

			sub_Btn.onClick.AddListener(() => {
				//交互逻辑
				this.SendCommand<SubCounterCommand>();

				this.SendCommand<GoldEventCommand>();

			});

		}

		/// <summary>
		/// 接口阉割
		/// </summary>
		/// <returns></returns>
		IArchitecture IBelongToArchitecture. GetArchitecture() // 修改
		{
			
			return CounterGame.Interface;
		}
	}

}

