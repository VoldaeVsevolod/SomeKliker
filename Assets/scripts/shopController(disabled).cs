using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class shopController : MonoBehaviour
{
    [SerializeField] private GameObject shop;
    [SerializeField] private Button closeShop;
    [SerializeField] private Button openShop;

    [SerializeField] private static int selectedSkin;
    [SerializeField] private int skinNum;
    [SerializeField] private Button buyButton;
    [SerializeField] private Image lampImage;

    [SerializeField] private List<GameObject> lamps = new List<GameObject>();
    private int indexLamp = 0;

    void Start()
    {
        shop.SetActive(false);
    }

    public void Click()
    {
        lampImage.color = Color.white;
    }

    public void Open()
    {
        shop.SetActive(true);
    }
    public void Close()
    {
        shop.SetActive(false);
    }
}
