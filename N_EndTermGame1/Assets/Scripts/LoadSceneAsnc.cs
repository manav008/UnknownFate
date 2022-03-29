using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneAsnc : MonoBehaviour
{
    public void LoadLevel(int SceneIndex)
    {
        StartCoroutine(LoadAsynchronously(SceneIndex));
    }

    IEnumerator LoadAsynchronously(int SceneIndex)
    {
        AsyncOperation Operation = SceneManager.LoadSceneAsync(SceneIndex);
        while (!Operation.isDone)
        {
            float Progress = Mathf.Clamp01(Operation.progress / 0.9f);
            //Debug.Log(Progress);
            yield return null;
        }
    }
}
