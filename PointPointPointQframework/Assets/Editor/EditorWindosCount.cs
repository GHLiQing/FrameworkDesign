using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UniRx;
namespace SYFramework
{
	public class EditorWindosCount : EditorWindow,IController
	{
		[MenuItem("EditorCountApp/Open")]
		public static void OpenEditorWindow()
		{

			CounterGame.OnRegsiterPath += architecture => {

				//architecture

			};


			var editorwindoscount = GetWindow<EditorWindow>();

			editorwindoscount.name = nameof(EditorWindosCount);

			editorwindoscount.position = new Rect(100, 100, 400, 600);

			editorwindoscount.Show();
		}

		public IArchitecture GetArchitecture()
		{
			return CounterGame.Interface;
		}

		private void OnGUI()
		{
			if (GUILayout.Button("+"))
			{
				//new AddKillCountCommand().OnExecute();
				GetArchitecture().SendCommand<AddKillCountCommand>();
			}
			var gameModel = this.GetModel<ICounterModel>();
			string count="";
			gameModel.Count.Subscribe(countvalues => {
				count = countvalues.ToString();
			});

			GUILayout.Label(count);

			if (GUILayout.Button("-"))
			{
				//new AddKillCountCommand().OnExecute();
				GetArchitecture().SendCommand<SubCounterCommand>();
			}
		}
	}

}
