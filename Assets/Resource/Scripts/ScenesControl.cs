using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScenesControl : MonoBehaviour
{
    public Button tutorial;
    public Button level1;
    public Button level2;
    public Button level3;
    public Button level4;
    public Button level5;
    public Button quit;

    void Start()
    {
        tutorial.onClick.AddListener(() => LoadScene("Tutorial"));
        level1.onClick.AddListener(() => LoadScene("Level1"));
        level2.onClick.AddListener(() => LoadScene("Level2"));
        level3.onClick.AddListener(() => LoadScene("Level3"));
        level4.onClick.AddListener(() => LoadScene("Level4"));
        level5.onClick.AddListener(() => LoadScene("Level5"));
        quit.onClick.AddListener(QuitGame);
    }

    void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    void QuitGame()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}
