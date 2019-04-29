using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIUpdater : MonoBehaviour
{
    public GameObject notification;
    public GameObject bountyText;

    private int _totalBounty;

    // Start is called before the first frame update
    void Start()
    {
        _totalBounty = 0;
        bountyText.GetComponent<Text>().text = _totalBounty.ToString();
    }

    // Update is called once per frame
    void Update()
    {

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

        _totalBounty += value;
        bountyText.GetComponent<Text>().text = "" + _totalBounty;
        Debug.Log(_totalBounty);
    }
            
}
