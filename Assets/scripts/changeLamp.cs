using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeLamp : MonoBehaviour
{
    [SerializeField] public List<int> costs = new();
    [SerializeField] public List<bool> enableFlag = new();

    [SerializeField] private List<GameObject> lamps = new();
    public int indexLamp = 0;
   
    [SerializeField] private Button rightBut;
    [SerializeField] private Button leftBut;
    [SerializeField] private GameObject baseLamp;
    [SerializeField] private Text costLabel;
    [SerializeField] public GameObject buyButton;

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

    private void Change() 
    {
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
        Change();
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
        Change();
    }

}
