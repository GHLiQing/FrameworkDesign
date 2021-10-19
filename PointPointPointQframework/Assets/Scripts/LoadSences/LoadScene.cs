using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
namespace SYFramework
{
	public class LoadScene : MonoBehaviour
	{
		public Button LoadSceneBtn;

		public Slider Slider;

		private void Awake()
		{
			LoadSceneBtn.onClick.AddListener(() => {
				LoadButton();

			});
		}


		private void LoadButton()
		{
			StartCoroutine(LoadSceneFun());
		}

		public IEnumerator LoadSceneFun()
		{
			yield return null;

			AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex+1);

			asyncOperation.allowSceneActivation = false;

			while (!asyncOperation.isDone)
			{
				//输出进度
				Debug.Log(asyncOperation.progress*100);
				Slider.value = asyncOperation.progress;
				if (asyncOperation.progress>=0.9f)
				{
					Debug.Log("完成");
					if (Input.anyKey)
						asyncOperation.allowSceneActivation = true;

				}

				yield return null;

			}
			
		}
	}

}
