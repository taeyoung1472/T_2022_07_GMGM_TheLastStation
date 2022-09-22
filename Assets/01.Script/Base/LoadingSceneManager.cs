using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingSceneManager : MonoBehaviour
{
    public static int nextScene;
    [SerializeField] Image progressBar;

    private void Start()
    {
        StartCoroutine(LoadScene());
    }

    public static void LoadScene(int sceneIndex)
    {
        /*Time.timeScale = 1;
        nextScene = sceneIndex;
        SceneManager.LoadScene("Loading");
        SceneChangeCanvas.Active();*/
        print($"·Îµù ¾À : {sceneIndex}");
        Time.timeScale = 1;
        nextScene = sceneIndex;
        SceneChangeCanvas.Active(() =>
        {
            SceneManager.LoadScene("Loading");
        });
    }

    IEnumerator LoadScene()
    {
        yield return null;
        print($"¾À ¹Ù²Ù´ÂÁß : {nextScene}");
        AsyncOperation op = SceneManager.LoadSceneAsync(nextScene);
        op.allowSceneActivation = false;
        float timer = 0.0f;
        while (!op.isDone)
        {
            yield return null;
            timer += Time.deltaTime;
            if (op.progress < 0.9f)
            {
                progressBar.fillAmount = Mathf.Lerp(progressBar.fillAmount, op.progress, timer);
                if (progressBar.fillAmount >= op.progress)
                {
                    timer = 0f;
                }
            }
            else
            {
                progressBar.fillAmount = Mathf.Lerp(progressBar.fillAmount, 1f, timer);
                if (progressBar.fillAmount == 1.0f)
                {
                    op.allowSceneActivation = true;
                    SceneChangeCanvas.DeActive();
                    yield break;
                }
            }
        }
    }
}
