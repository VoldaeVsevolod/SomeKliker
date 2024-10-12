using System.Collections.Generic;
using UnityEngine;
using YG;

public class lampsControl : MonoBehaviour
{
    [SerializeField] public List<TouchControl> lampsList = new();
    [SerializeField] private ChangeLamp changeLamp;
    [SerializeField] private GameObject buyButton;

    public void BuyButton()
    {
        if (YandexGame.savesData.coins >= lampsList[changeLamp.indexLamp].coins)
        {
            YandexGame.savesData.coins -= changeLamp.costs[changeLamp.indexLamp];
            changeLamp.enableFlag[changeLamp.indexLamp] = true;
            buyButton.SetActive(false);
        }
    }
}
