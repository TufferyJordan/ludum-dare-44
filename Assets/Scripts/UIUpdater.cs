using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIUpdater : MonoBehaviour
{
    public GameObject notification;
    public GameObject bountyText;
    public GameObject dangerBar;

    public Color dangerZone1;
    public Color dangerZone2;
    public Color dangerZone3;
    public Color dangerZone4;

    private int _totalBounty;
    private int _bountyToGo;
    private int _incrementSteps;

    // Start is called before the first frame update
    void Start()
    {
        _totalBounty = 0;
        bountyText.GetComponent<Text>().text = _totalBounty.ToString();
        dangerBar.GetComponent<Image>().color = dangerZone1;
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
        if (dangerValue <= 3)
        {
            dangerBar.GetComponent<Image>().color = dangerZone1;
        }
        else if (dangerValue <= 6)
        {
            dangerBar.GetComponent<Image>().color = dangerZone2;
        }
        else if (dangerValue <= 9)
        {
            dangerBar.GetComponent<Image>().color = dangerZone3;
        }
        else
        {
            dangerBar.GetComponent<Image>().color = dangerZone4;
        }
    }
}
