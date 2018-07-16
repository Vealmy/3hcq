using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class FightItem : FightManager,IPointerEnterHandler,IPointerExitHandler,IPointerClickHandler {

    public Text ItemAmount;
    public int item1;
    public int item2;
    public int item3;
    public int item4;

    // Use this for initialization
    void Start () {
        ItemAmount = transform.GetChild(0).GetComponent<Text>();
        if (this.transform.tag == "HP1") {
            item1 = ItemList[0].Amount;
            ItemAmount.text = item1.ToString();
        }else if (this.transform.tag == "HP2")
        {
            item3 = ItemList[2].Amount;
            ItemAmount.text=item3.ToString();
        }else if (this.transform.tag == "MP2")
        {
            item4 = ItemList[3].Amount;
            ItemAmount.text = item4.ToString();
        }else if (this.transform.tag == "MP1")
        {
            item2 = ItemList[1].Amount;
            ItemAmount.text = item2.ToString();
        }
    }
	
	
    public void OnPointerClick(PointerEventData eventData)
    {

        if (this.transform.tag == "HP1")
        {
            if (item1 > 0)
            {
                item1 -= 1;
                ItemAmount.text = item1.ToString();
                UpdateData(20,item1);
            }
        }
        else if (this.transform.tag == "HP2")
        {
            if (item3 > 0)
            {
                item3 -= 1;
                ItemAmount.text = item1.ToString();
                UpdateData(50, item3);
            }
        }
        else if (this.transform.tag == "MP2")
        {
            if (item4 > 0)
            {
                item4 -= 1;
                ItemAmount.text = item1.ToString();
                UpdateData(0, item4);
            }
        }
        else if (this.transform.tag == "MP1")
        {
            if (item2 > 0)
            {
                if (item4 > 0)
                {
                    item2 -= 1;
                    ItemAmount.text = item1.ToString();
                    UpdateData(0, item2);
                }
            }
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        
    }
}
