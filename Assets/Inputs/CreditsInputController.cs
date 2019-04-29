using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsInputController : MonoBehaviour
{
    private Controls controls;

    private void Awake()
    {
        //Init controls
        controls = new Controls();

        //Adds listeners
        controls.CreditsControls.QuitCredits.performed += context =>
        {
            SceneManager.LoadScene(0);
        };
    }

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }
}
