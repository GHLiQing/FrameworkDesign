using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UniRx;
namespace SYFramework
{
	public class EditorCounterApp : EditorWindow
	{
		
		[MenuItem("LQ/EditorcounterOpen")]
		public static void Open()
		{
			var editorwindow = GetWindow<EditorCounterApp>();

			editorwindow.position = new Rect(100, 100, 400, 500);
			editorwindow.name = nameof(EditorCounterApp).ToString();


			mCounterModel = CounterGame.Get<ICounterModel>();

			editorwindow.Show();

		}


		 static ICounterModel mCounterModel;

		private void OnGUI()
		{
			if (GUILayout.Button("+"))
			{
				new AddCounterCommand().OnExecute();
			}
	
			mCounterModel.Count.Subscribe(mcounter=>{
				GUILayout.Label(mcounter.ToString());
			});


			if (GUILayout.Button("-"))
			{
				new SubCounterCommand().OnExecute();
			}

		}
	}

}
