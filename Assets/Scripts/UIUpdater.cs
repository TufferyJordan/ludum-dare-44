﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIUpdater : MonoBehaviour
{
    public GameObject notification;
    public GameObject bountyText;
    public GameObject dangerBar;

    public Color[] dangerZone;

    private int _totalBounty;
    private int _bountyToGo;
    private int _incrementSteps;

    // Start is called before the first frame update
    void Start()
    {
        _totalBounty = 0;
        bountyText.GetComponent<Text>().text = _totalBounty.ToString();
        dangerBar.GetComponent<Image>().color = dangerZone[0];
    }

    // Update is called once per frame
    void Update()
    {
        if(_totalBounty < _bountyToGo)
        {
            _totalBounty+=_incrementSteps;
            bountyText.GetComponent<Text>().text = _totalBounty.ToString();
        }
        else
        {
            _totalBounty = _bountyToGo;
            bountyText.GetComponent<Text>().text = _totalBounty.ToString();
        }
    }

    private IEnumerator HideBounty(float waitTime)
    {
        // suspend execution for 2 seconds
        yield return new WaitForSeconds(waitTime);
        notification.SetActive(false);
    }

    public void UpBounty(int value)
    {
        var notif = notification.GetComponent<UINotification>();
        notif.BountyRise(value);
        notification.SetActive(true);
        StartCoroutine(HideBounty(2.0f));
        AudioManager.instance.EarReward();

        _bountyToGo += value;
        _incrementSteps += (int) Mathf.Round(value / 10);
    }

    public void UpdateDanger(int dangerValue)
    {
        for(int i=0;i<11;i++)
        {
            if (dangerValue == i)
            {
                dangerBar.GetComponent<Image>().color = dangerZone[i];
            }
        }
    }
}
