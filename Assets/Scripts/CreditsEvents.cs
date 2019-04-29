using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsEvents : MonoBehaviour
{
    public void OnAnimationEnd()
    {
        SceneManager.LoadScene(0);
    }
}
