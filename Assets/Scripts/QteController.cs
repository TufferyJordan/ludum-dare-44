using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class QteController : MonoBehaviour
{
    private bool _isQteRunning;
    private QteAction _promptFor;
    private int _qteRemaining;
    private QteAction? _actionThisTick;

    public Text qteButtonUI;
    public Text qteTimeRemainingUI;
    public PlayerController playerController;
    private float _timeRemainingForCurrentPrompt;

    public GameObject notification;

    public enum QteAction
    {
        UP, DOWN, LEFT, RIGHT
    }
    
    void Start()
    {
        _isQteRunning = false;
    }

    void Update()
    {
        if (!_isQteRunning)
        {
            return;
        }

        if (_actionThisTick != null)
        {
            if (_actionThisTick == _promptFor)
            {
                PromptSuccessful();
            }
            else
            {
                PromptFailure();
            }

            _actionThisTick = null;
        }
        else
        {
            _timeRemainingForCurrentPrompt -= Time.deltaTime;
            if (_timeRemainingForCurrentPrompt > 0)
            {
                qteTimeRemainingUI.text = new String('.', 1 + (int)Math.Floor(_timeRemainingForCurrentPrompt * 50));
            }
            else
            {
                PromptFailure();
            }
        }
    }

    private void PromptSuccessful()
    {
        _qteRemaining--;
        if (_qteRemaining <= 0)
        {
            End();
            ShowBountyNotification();
        }
        else
        {
            GeneratePrompt();
        }
    }

    private void PromptFailure()
    {
        playerController.IncrementDanger();
        End();
    }

    public void Input(QteAction action)
    {
        if (!_isQteRunning)
        {
            return;
        }

        _actionThisTick = action;
    }

    private void End()
    {
        _isQteRunning = false;
        HidePrompt();
    }

    public void Begin()
    {
        if (_isQteRunning)
        {
            return;
        }


        _isQteRunning = true;
        _qteRemaining = 2 + Random.Range(0, 5);
        
        playerController.ForceDisableInvulnerability();
        GeneratePrompt();
    }

    private void GeneratePrompt()
    {
        _promptFor = NextPrompt();
        _timeRemainingForCurrentPrompt = 1;
        ShowPrompt();
    }

    private void ShowPrompt()
    {
        switch (_promptFor)
        {
            case QteAction.UP:
                qteButtonUI.text = "↑";
                break;
            case QteAction.DOWN:
                qteButtonUI.text = "↓";
                break;
            case QteAction.LEFT:
                qteButtonUI.text = "←";
                break;
            case QteAction.RIGHT:
                qteButtonUI.text = "→";
                break;
        }
    }

    private void HidePrompt()
    {
        qteButtonUI.text = "";
        qteTimeRemainingUI.text = "";
    }

    private static QteAction NextPrompt()
    {
        var actions = Enum.GetValues(typeof(QteAction));
        return (QteAction)actions.GetValue((int) Math.Floor((double)Random.Range(0, actions.Length)));
    }

    public bool IsQteRunning() {
        return _isQteRunning;
    }

    private void ShowBountyNotification()
    {
        var notif = notification.GetComponent<UINotification>();
        notif.BountyRise(Random.Range(1000,10000));
        notification.SetActive(true);
        StartCoroutine(HideBounty(2.0f));
    }

    private IEnumerator HideBounty(float waitTime)
    {
        // suspend execution for 2 seconds
        yield return new WaitForSeconds(waitTime);
        notification.SetActive(false);
        Debug.Log("HELLO");
    }
}
