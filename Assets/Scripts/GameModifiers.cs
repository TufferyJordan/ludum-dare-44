using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameModifiers : MonoBehaviour
{
    private const int MaxDanger = 1;
    
    public Text dangerMeter; 
    
    private int _danger;
    private float _invulnerable;
    
    void Start()
    {
        _danger = 0;
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

    public void TakeDamage(DangerSource source)
    {
        if (_invulnerable > 0)
        {
            return;
        }
        
        _danger++;
        if (_danger > MaxDanger)
        {
            _danger = MaxDanger;
        }
        
        _invulnerable = 1.5f;
        
        // TODO danger view
        UpdateDangerView();
    }

    public void ForceDisableInvulnerability()
    {
        _invulnerable = 0;
    }

    private void UpdateDangerView()
    {
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
