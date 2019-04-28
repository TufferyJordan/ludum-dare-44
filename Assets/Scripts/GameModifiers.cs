using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameModifiers : MonoBehaviour
{
    private const int MaxDanger = 10;
    private const int DangerAfterMaxQteSuccess = 6;
    private const int MaxComboToDecreaseDanger = 3;
    private const int ComboToDecreaseDangerCount = 3;

    public Text dangerMeter;

    private int _danger;
    private float _invulnerable;
    private int _qteSuccessCombo;

    void Start()
    {
        _danger = 0;
        _qteSuccessCombo = 0;
        UpdateDangerView();
    }

    public enum DangerSource
    {
        OBSTACLE_COLLIDED,
        QTE_EXCEEDED_TIME_LIMIT,
        QTE_INPUTTED_IN_ERROR
    }
    
    public enum DangerLevel
    {
        NONE,
        ULTIMATE
    }

    public bool IsMaxDangerLevel()
    {
        return _danger == MaxDanger;
    }

    public void SuccessfulQte()
    {
        if (IsMaxDangerLevel())
        {
            DecreaseDanger(MaxDanger - DangerAfterMaxQteSuccess);
            UpdateDangerView();
        }
        else
        {
            _qteSuccessCombo++;
            if (_qteSuccessCombo >= MaxComboToDecreaseDanger)
            {
                DecreaseDanger(ComboToDecreaseDangerCount);
                UpdateDangerView();
                
            }
        }
    }

    private void DecreaseDanger(int amount)
    {
        _danger -= amount;
        if (_danger < 0)
        {
            _danger = 0;
        }
    }

    public void TakeDamage(DangerSource source)
    {
        if (_invulnerable > 0)
        {
            return;
        }

        if (source == DangerSource.QTE_INPUTTED_IN_ERROR || source == DangerSource.QTE_EXCEEDED_TIME_LIMIT)
        {
            _qteSuccessCombo = 0;
        }
        
        _danger++;
        if (_danger > MaxDanger)
        {
            _danger = MaxDanger;
        }
        
        _invulnerable = 1.5f;
        
        UpdateDangerView();
    }

    public void ForceDisableInvulnerability()
    {
        _invulnerable = 0;
    }

    private void UpdateDangerView()
    {
        Time.timeScale = 1F + (_danger / (MaxDanger * 1F)) * 0.5F;
        dangerMeter.text = "Danger: " + _danger;
    }

    void Update()
    {
        _invulnerable -= Time.fixedDeltaTime;
    }

    public bool IsInvulnerable()
    {
        return _invulnerable > 0;
    }

    public float GetInvulnerabilityRemainingDuration()
    {
        return _invulnerable;
    }
}
