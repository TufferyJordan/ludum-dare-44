using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScript : MonoBehaviour
{

    public void OnStartClick()
    {
        SceneManager.LoadScene(1);
    }

    public void OnCreditsClick()
    {
        // TODO: Credits Click
    }

    public void OnExitClick()
    {
        Application.Quit();
    }

}
