using System;
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
    private const float InvulnerabilityDuration = 1f;
    private const int BountyDifficultyStep = 700;

    private int _danger;
    private float _invulnerable;
    private int _qteSuccessCombo;
    private int _maxDangerSuccessCount;
    private int _totalBounty;

    void Start()
    {
        _danger = 0;
        _qteSuccessCombo = 0;
        _maxDangerSuccessCount = 0;
        _totalBounty = 0;
        WhenDangerChanges();
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

    public void SuccessfulQte(int bonusQteCount)
    {
        if (IsMaxDangerLevel())
        {
            _maxDangerSuccessCount++;
            DecreaseDanger(MaxDanger - DangerAfterMaxQteSuccess);
            WhenDangerChanges();
        }
        else
        {
            _qteSuccessCombo++;
            if (_qteSuccessCombo >= MaxComboToDecreaseDanger)
            {
                DecreaseDanger(ComboToDecreaseDangerCount);
                WhenDangerChanges();
            }
        }

        var bountyOnInverseDangerLevel = (int)Math.Floor((1F - _danger / (MaxDanger * 1F)) * 100);
        var bountyOnQte = bonusQteCount * 100 + bonusQteCount;
        
        var bounty = 300 + bountyOnQte + bountyOnInverseDangerLevel;
        _totalBounty += bounty;
        
        ChangeGameSpeed();
        
        GameObject.Find("UIUpdater").GetComponent<UIUpdater>().UpBounty(bounty);
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
        
        _invulnerable = InvulnerabilityDuration;
        
        WhenDangerChanges();
    }

    public void ForceDisableInvulnerability()
    {
        _invulnerable = 0;
    }

    private void WhenDangerChanges()
    {
        ChangeGameSpeed();
        GameObject.Find("UIUpdater").GetComponent<UIUpdater>().UpdateDanger(_danger);
    }

    private void ChangeGameSpeed()
    {
        var speedPenaltyMaxDanger = _maxDangerSuccessCount * 0.1F;
        var speedPenaltyDanger = (_danger / (MaxDanger * 1F));
        var speedDifficultyBounty = (_totalBounty / BountyDifficultyStep) * 0.05F;
        var f = Time.timeScale = 1F + speedPenaltyDanger * 0.5F + speedPenaltyMaxDanger + speedDifficultyBounty;
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
