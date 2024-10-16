using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using YG;

public class Reward : MonoBehaviour
{
    public YandexGame sdk;
    [SerializeField] private lampsControl lampsControl;
    [SerializeField] private ChangeLamp changeLamp;
    public Button but;

    public void RewardedAd()
    {
        sdk._RewardedShow(1);
    }

    public void RewardedAdCul()
    {
        lampsControl.lampsList[changeLamp.indexLamp].addCoins *= 2;
        Debug.Log(lampsControl.lampsList[changeLamp.indexLamp].addCoins);
        StartCoroutine(ButtonCooldown());
    }

    IEnumerator ButtonCooldown()
    {
        but.interactable = false;
        YandexGame.savesData.addCoins *= 2;
        yield return new WaitForSeconds(30);
        YandexGame.savesData.addCoins /= 2;
        YandexGame.SaveProgress();
        but.interactable = true;
    }
}

