using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {
private AsyncOperation async = null; // When assigned, load is in progress.
public string SceneName;
public Canvas loadingCanvas;
	public Image progressBar;

    public void StartLoading()
    {
        StartCoroutine("LoadScene");
    }
    
	IEnumerator LoadScene()
	{
		yield return null;

		async = SceneManager.LoadSceneAsync(SceneName);
		async.allowSceneActivation = false;

		while (! async.isDone)
		{
			// [0, 0.9] > [0, 1]
			float progress = Mathf.Clamp01(async.progress / 0.9f);
			progressBar.fillAmount = progress;
			progressBar.transform.GetChild (0).GetComponent<TMPro.TextMeshProUGUI> ().text = progress * 100 + "%";

			loadingCanvas.enabled = true;
            
			// Loading completed
			if (async.progress == 0.9f)
			{
				async.allowSceneActivation = true;
			}

			yield return null;
		}

		while (async.isDone)
		{
			loadingCanvas.enabled = false;
		}
	}
}