using UnityEngine;
using UnityEngine.UI;

public class UINotification : MonoBehaviour
{
    public Sprite spriteImg;
    public string title;
    [TextArea(15, 20)]
    public string description;


    public GameObject imageGob;
    public GameObject titleGob;
    public GameObject descriptionGob;


    // Start is called before the first frame update
    void Start()
    {
        imageGob.GetComponent<Image>().sprite = spriteImg;
        titleGob.GetComponent<Text>().text = title;
        //descriptionGob.GetComponent<Text>().text = description;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BountyRise(int bounty) {
        descriptionGob.GetComponent<Text>().text = "Your bounty is rising.\n+"+bounty+"$";
    }
}
