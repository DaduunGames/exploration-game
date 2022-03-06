using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HotbarItemGUI : MonoBehaviour
{
    public Image image;

    public GameObject PAmount;
    public TextMeshProUGUI TAmmount;

    public GameObject PInfo;
    public TextMeshProUGUI TName;
    public TextMeshProUGUI TDesc;

    private Item prev;
    private Item item;

    private void Start()
    {
        PInfo.SetActive(false);
    }

    private void Update()
    {
        if (item)
        {
            TAmmount.text = item.amount.ToString();
            if (item.maxAmmount == 1 || item.amount == 1)
            { PAmount.SetActive(false); }
            else { PAmount.SetActive(true); }

            if (item != prev)
            {
                init();
            }
            prev = item;
        }
        else
        {
            item = GetComponent<Item>();
        }
    }

    private void init()
    {
        TName.text = item.Name;
        TDesc.text = item.Description;

        Sprite sp = Resources.Load<Sprite>(item.Image);
        image.sprite = sp;
    }
}
