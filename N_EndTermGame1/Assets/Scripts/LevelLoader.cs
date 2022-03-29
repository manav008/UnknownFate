using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class LevelLoader : MonoBehaviour
{
    public GameObject MenuUI;
    public GameObject LoadingScreen;
    public Slider Sliderbar;
    public TextMeshProUGUI ProgressText;
    public void LoadLevel(int SceneIndex)
    {
        StartCoroutine(LoadAsynchronously(SceneIndex));       
    }

    IEnumerator LoadAsynchronously(int SceneIndex)
    {
        AsyncOperation Operation = SceneManager.LoadSceneAsync(SceneIndex);
        MenuUI.SetActive(false);
        LoadingScreen.SetActive(true);
        while (!Operation.isDone)
        {                
            float Progress = Mathf.Clamp01(Operation.progress/0.9f);
            Sliderbar.value = Progress;
            ProgressText.text = Progress * 100f + "%";
            //Debug.Log(Progress);
            yield return null;
        }
    }  
}
