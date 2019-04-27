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
    public PlayerController playerController;

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
    }

    private void PromptSuccessful()
    {
        _qteRemaining--;
        if (_qteRemaining <= 0)
        {
            End();
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
        GeneratePrompt();
        _qteRemaining = 2 + Random.Range(0, 5);
    }

    private void GeneratePrompt()
    {
        _promptFor = NextPrompt();
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
    }

    private static QteAction NextPrompt()
    {
        var actions = Enum.GetValues(typeof(QteAction));
        return (QteAction)actions.GetValue((int) Math.Floor((double)Random.Range(0, actions.Length)));
    }

    public bool IsQteRunning() {
        return _isQteRunning;
    }
}
