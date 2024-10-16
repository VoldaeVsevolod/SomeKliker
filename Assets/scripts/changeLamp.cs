using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using YG;

public class ChangeLamp : MonoBehaviour
{
    [SerializeField] public List<int> costs = new();
    [SerializeField] public List<bool> enableFlag = new();

    [SerializeField] public List<GameObject> lamps = new();
    public int indexLamp = -1;

    [SerializeField] private ChangeLamp changeLamp;
    [SerializeField] private Button rightBut;
    [SerializeField] private Button leftBut;
    [SerializeField] private GameObject baseLamp;
    [SerializeField] private Text costLabel;
    [SerializeField] public GameObject buyButton;

    private void Start()
    {
        //—читаем последнюю купленную лампу, чтобы показать еЄ
        for(int j = 0; j < YandexGame.savesData.openLevels.Length; j++)
        {
            if (YandexGame.savesData.openLevels[j]) indexLamp++;
        }

        for (int i = 0; i < YandexGame.savesData.openLevels.Length; i++)
        {
            buyButton.SetActive(true);
            lamps[i].SetActive(false);
            lamps[i].GetComponent<TouchControl>().enabled = false;
            lamps[i].GetComponent<BoxCollider>().enabled = false;

        }
        buyButton.SetActive(false);
        lamps[indexLamp].SetActive(true);
        lamps[indexLamp].GetComponent<TouchControl>().enabled = true;
        lamps[indexLamp].GetComponent<BoxCollider>().enabled = true;
    }

    public void Change() 
    {
    	lamps[indexLamp].SetActive(true);

        if (!YandexGame.savesData.openLevels[indexLamp])
        {
            buyButton.SetActive(true);
            costLabel.text = costs[indexLamp].ToString();
            lamps[indexLamp].GetComponent<Image>().color = Color.black;
            baseLamp.GetComponent<Image>().color = Color.black;
            lamps[indexLamp].GetComponent<TouchControl>().enabled = false;
            lamps[indexLamp].GetComponent<BoxCollider>().enabled = false;
        }
        else
        {
            buyButton.SetActive(false);
            lamps[indexLamp].GetComponent<TouchControl>().enabled = true;
            lamps[indexLamp].GetComponent<BoxCollider>().enabled = true;
            baseLamp.GetComponent<Image>().color = Color.white;
        }
    }

    public void RightClick()
    {
        lamps[indexLamp].GetComponent<TouchControl>().enabled = false;
        lamps[indexLamp].GetComponent<BoxCollider>().enabled = false;
        lamps[indexLamp].SetActive(false);


        if (indexLamp < lamps.Count-1)
        {
            indexLamp++;
        }
        else
        {
            indexLamp = 0;
        }
        Change();
    }

    public void LeftClick()
    {
        lamps[indexLamp].GetComponent<TouchControl>().enabled = false;
        lamps[indexLamp].GetComponent<BoxCollider>().enabled = false;
        lamps[indexLamp].SetActive(false);

        if (indexLamp > 0)
        {
            indexLamp--;
        }
        else
        {
            indexLamp = lamps.Count-1;
        }
        Change();
    }

}
