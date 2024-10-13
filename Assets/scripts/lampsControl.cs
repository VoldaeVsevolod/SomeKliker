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
            //Отнимаем монеты
            YandexGame.savesData.coins -= changeLamp.costs[changeLamp.indexLamp];

            //Разблокируем лампу
            YandexGame.savesData.openLevels[changeLamp.indexLamp] = true;
            changeLamp.enableFlag[changeLamp.indexLamp] = true;
            lampsList[changeLamp.indexLamp].lampImage.color = Color.white;
            lampsList[changeLamp.indexLamp].baseLampImage.color = Color.white;
            changeLamp.lamps[changeLamp.indexLamp].GetComponent<TouchControl>().enabled = true;
            changeLamp.lamps[changeLamp.indexLamp].GetComponent<BoxCollider>().enabled = true;
            YandexGame.savesData.addCoins = addMoneyList[changeLamp.indexLamp];

            //Удаляем кнопку покупки
            buyButton.SetActive(false);

            //Сохраняем изменения
            YandexGame.SaveProgress();
        }
    }
}
