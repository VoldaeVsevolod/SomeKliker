using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using YG;

public class Reward : MonoBehaviour
{
    public YandexGame sdk;
    public TouchControl tControl;
    public Button but;
    //public GameObject countDownObject;
    //public Text countDownText;
    public int countDown = 5;

    public void RewardedAd()
    {
        sdk._RewardedShow(1);
    }

    public void RewardedAdCul()
    {
        tControl.addCoins *= 2;
        Debug.Log(tControl.addCoins);
        StartCoroutine(ButtonCooldown());
    }

    IEnumerator ButtonCooldown()
    {
        but.interactable = false;
        //countDownObject.SetActive(true);
        yield return new WaitForSeconds(30);
        but.interactable = true;
        //countDownObject.SetActive(false);
    }
}

