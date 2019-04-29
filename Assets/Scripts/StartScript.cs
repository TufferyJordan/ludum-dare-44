using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScript : MonoBehaviour
{

    void Start()
    {
        AudioManager.instance.StartIntro();
    }

    public void OnStartClick()
    {
        AudioManager.instance.StopAll();
        SceneManager.LoadScene(1);
    }

    public void OnCreditsClick()
    {
        SceneManager.LoadScene(2);
    }

    public void OnExitClick()
    {
        Application.Quit();
    }

}
