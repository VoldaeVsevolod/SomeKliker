using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using YG;

public class TouchControl : MonoBehaviour
{
    [SerializeField] private Transform lamp;
    [SerializeField] public Image lampImage;
    [SerializeField] public Image baseLampImage;
    [SerializeField] private Text coinsText;
    [SerializeField] private Text textBuyButton;
    [SerializeField] private GameObject buyButton;
    [SerializeField] private Text addMoneyText;

    private int clickNum;
    public float coins = 1;
    public int addCoins = 15;
    private bool flag = true;
    
    public List<Sprite> images = new();
    public List<Sprite> lamps = new();

    public void Start()
    {
        if (YandexGame.SDKEnabled == true)
        {
            LoadSceneCloud();
        }
    }

    public void OnEnable() => YandexGame.GetDataEvent += LoadSceneCloud;
    public void OnDisable() => YandexGame.GetDataEvent -= LoadSceneCloud;


    public void LoadSceneCloud()
    {
        addCoins = YandexGame.savesData.addCoins;
        coins = YandexGame.savesData.coins;
    }

    public void MySave()
    {
        YandexGame.savesData.addCoins = addCoins;
        YandexGame.savesData.coins = coins;
        YandexGame.SaveProgress();
    }

    public void OnMouseDown()
    {
        if (flag)
        {
            lampImage.sprite = images[0];
            baseLampImage.sprite = lamps[0];
            lamp.position += Vector3.up;
            flag = false;
        }
        else
        {
            lampImage.sprite = images[1];
            baseLampImage.sprite = lamps[1];
            lamp.position += Vector3.down;
            flag = true;
        }
        YandexGame.savesData.coins += YandexGame.savesData.addCoins;
        clickNum++;
        YandexGame.SaveProgress();
    }

    public void Update()
    {
        //Math.Round(YandexGame.savesData.coins/1000, 3, MidpointRounding.AwayFromZero)
        if (YandexGame.savesData.coins >= 1000) coinsText.text =
                Math.Round(YandexGame.savesData.coins / 1000, 2, MidpointRounding.AwayFromZero).ToString() + "K";
        if (YandexGame.savesData.coins >= 10000) coinsText.text =
                Math.Round(YandexGame.savesData.coins / 1000, 1, MidpointRounding.AwayFromZero).ToString() + "K";
        else coinsText.text = YandexGame.savesData.coins.ToString();
        addMoneyText.text = YandexGame.savesData.addCoins.ToString() + "    / клик";
    }
}
