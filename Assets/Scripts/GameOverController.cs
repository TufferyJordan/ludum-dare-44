using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour
{
    public bool isGameOver = false;

    public void OnGameOver()
    {
        isGameOver = true;
        AudioManager.instance.StopAll();
        AudioManager.instance.Play("Intro");
        gameObject.SetActive(true);
    }

    public void OnRetryButton()
    {
        AudioManager.instance.StopAll();
        SceneManager.LoadScene(1);
    }

    public void OnGoBackButton()
    {
        SceneManager.LoadScene(0);
    }
}
