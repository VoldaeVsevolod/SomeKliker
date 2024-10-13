using System.Collections.Generic;
using UnityEngine;
using YG;

public class lampsControl : MonoBehaviour
{
    [SerializeField] public List<TouchControl> lampsList = new();
    [SerializeField] private int[] addMoneyList = new int[0];
    [SerializeField] private ChangeLamp changeLamp;
    [SerializeField] private GameObject buyButton;

    public void BuyButton()
    {
        if (YandexGame.savesData.coins >= lampsList[changeLamp.indexLamp].coins)
        {
            //�������� ������
            YandexGame.savesData.coins -= changeLamp.costs[changeLamp.indexLamp];

            //������������ �����
            YandexGame.savesData.openLevels[changeLamp.indexLamp] = true;
            changeLamp.enableFlag[changeLamp.indexLamp] = true;
            lampsList[changeLamp.indexLamp].lampImage.color = Color.white;
            lampsList[changeLamp.indexLamp].baseLampImage.color = Color.white;
            changeLamp.lamps[changeLamp.indexLamp].GetComponent<TouchControl>().enabled = true;
            changeLamp.lamps[changeLamp.indexLamp].GetComponent<BoxCollider>().enabled = true;
            YandexGame.savesData.addCoins = addMoneyList[changeLamp.indexLamp];

            //������� ������ �������
            buyButton.SetActive(false);

            //��������� ���������
            YandexGame.SaveProgress();
        }
    }
}
