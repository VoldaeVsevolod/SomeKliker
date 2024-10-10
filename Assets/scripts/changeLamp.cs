using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ChangeLamp : MonoBehaviour
{
    [SerializeField] private List<int> costs = new();
    [SerializeField] private List<bool> enableFlag = new();

    [SerializeField] private List<GameObject> lamps = new();
    private int indexLamp = 0;

    [SerializeField] private TouchControl touchControl;
    [SerializeField] private Button rightBut;
    [SerializeField] private Button leftBut;
    [SerializeField] private GameObject baseLamp;
    [SerializeField] private Text costLabel;
    [SerializeField] private GameObject buyButton;

    private void Start()
    {
        for (int i = 0; i < lamps.Count; i++)
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

    public void RightClick()
    {
        lamps[indexLamp].SetActive(false);

        if (indexLamp < lamps.Count-1)
        {
            indexLamp++;
        }
        else
        {
            indexLamp = 0;
        }

        lamps[indexLamp].SetActive(true);

        if (!enableFlag[indexLamp])
        {
            buyButton.SetActive(true);
            costLabel.text = costs[indexLamp].ToString();
            lamps[indexLamp].GetComponent<Image>().color = Color.black;
            baseLamp.GetComponent<Image>().color = Color.black;
        }
        else
        {
            buyButton.SetActive(false);
            lamps[indexLamp].GetComponent<TouchControl>().enabled = true;
            lamps[indexLamp].GetComponent<BoxCollider>().enabled = true;
            baseLamp.GetComponent<Image>().color = Color.white;
        }


    }

    public void LeftClick()
    {
        lamps[indexLamp].SetActive(false);
        if (indexLamp > 0)
        {
            indexLamp--;
        }
        else
        {
            indexLamp = lamps.Count-1;
        }

        lamps[indexLamp].SetActive(true);

        if (!enableFlag[indexLamp])
        {
            buyButton.SetActive(true);
            costLabel.text = costs[indexLamp].ToString();
            lamps[indexLamp].GetComponent<Image>().color = Color.black;
            baseLamp.GetComponent<Image>().color = Color.black;
        }
        else
        {
            buyButton.SetActive(false);
            lamps[indexLamp].GetComponent<TouchControl>().enabled = true;
            lamps[indexLamp].GetComponent<BoxCollider>().enabled = true;
            baseLamp.GetComponent<Image>().color = Color.white;
        }
    }

    public void BuyButton()
    {
        if (touchControl.coins >= costs[indexLamp])
        {
            touchControl.coins -= costs[indexLamp];
            enableFlag[indexLamp] = true;
            buyButton.SetActive(false);
        }
    }
}
