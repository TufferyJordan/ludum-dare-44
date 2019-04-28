using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class QteRule : MonoBehaviour
{
    private QteAction _promptFor;
    private int _qteRemaining;
    private QteAction? _actionThisTick;

    public Text qteButtonUI;
    public Text qteTimeRemainingUI;
    public GameModifiers gameModifiers;
    
    private float _timeRemainingForCurrentPrompt;
    private float _qteDuration;

    public GameObject notification;

    public enum QteAction
    {
        UP, DOWN, LEFT, RIGHT
    }
    
    void Start()
    {
    }

    void Update()
    {
        if (!isActiveAndEnabled)
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
                TimeLimitFailure();
            }
        }
    }

    private void PromptSuccessful()
    {
        _qteRemaining--;
        if (_qteRemaining <= 0)
        {
            End();
            gameModifiers.SuccessfulQte();
            ShowBountyNotification();
        }
        else
        {
            GeneratePrompt();
        }
    }

    private void TimeLimitFailure()
    {
        gameModifiers.TakeDamage(GameModifiers.DangerSource.QTE_EXCEEDED_TIME_LIMIT);
        End();
    }

    private void PromptFailure()
    {
        gameModifiers.TakeDamage(GameModifiers.DangerSource.QTE_INPUTTED_IN_ERROR);
        End();
    }

    public void Input(QteAction action)
    {
        if (!isActiveAndEnabled)
        {
            return;
        }

        _actionThisTick = action;
    }

    private void End()
    {
        enabled = false;
        HidePrompt();
    }

    public void Begin()
    {
        if (isActiveAndEnabled)
        {
            return;
        }

        enabled = true;
        if (gameModifiers.IsMaxDangerLevel())
        {
            _qteRemaining = 10;
            _qteDuration = 1F;
        }
        else
        {
            _qteRemaining = 2 + Random.Range(0, 5);
            _qteDuration = 1F;
        }
        
        gameModifiers.ForceDisableInvulnerability();
        GeneratePrompt();
    }

    private void GeneratePrompt()
    {
        _promptFor = NextPrompt();
        _timeRemainingForCurrentPrompt = _qteDuration;
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
        return isActiveAndEnabled;
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
