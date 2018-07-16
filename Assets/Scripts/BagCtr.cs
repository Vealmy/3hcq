using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class BagCtr : ItemManagers, IPointerEnterHandler, IPointerExitHandler,IPointerClickHandler {

    public GameObject itemPrefab;
   
    public List<Item> ItemDisList;
    private ToopTip toolTip;
    public string text;


    void Start() {
    }

    public void BuildIcon(Item item) {
        GameObject itemGameObject = Instantiate(itemPrefab) as GameObject;
                    itemGameObject.transform.SetParent(this.transform);
                    itemGameObject.transform.localPosition = Vector3.zero;
                    itemGameObject.transform.localScale = Vector3.one;
                    itemGameObject.transform.GetComponent<ItemUI>().SetUI(item);
    }
	

	// Update is called once per frame
	void Update () {
        
    }

    public void OnPointerEnter(PointerEventData eventData)//鼠标放到物品上时，加载详情界面
    {
        if (transform.childCount > 0)
        {
               
			text=transform.GetChild(0).GetComponent<ItemUI>().Item.UIText();
            ToopTip.Instance.Show(text);
            //Debug.Log("1255555");
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (transform.childCount > 0)
        {
            //Debug.Log("出去了");
            ToopTip.Instance.Hide();
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("点了一下");
        Item item=transform.GetChild(0).GetComponent<ItemUI>().Item;
        int type = item.ItemType;
        switch (type)
        {
            case 0:
                //ItemManagers.Instantiate.ChangeData();
                GameObject.Find("EventSystem").GetComponent<PlayerManager>().ChangeData(item);// += value;
                //Debug.Log(value);
                //GameObject.Find("EventSystem").GetComponent<ItemManagers>().ClickIcon(id);
                transform.GetChild(0).GetComponent<ItemUI>().UpdateUI();
                GameObject.Find("EventSystem").GetComponent<ItemManagers>().ClickIcon(item.Id);
                break;
            case 1:
                GameObject.Find("EventSystem").GetComponent<PlayerManager>().ChangeData(item);
                transform.GetChild(0).GetComponent<ItemUI>().UpdateUI();
                GameObject.Find("EventSystem").GetComponent<ItemManagers>().ClickIcon(item.Id);
                break;
            case 2:
                break;
            case 3:
                
                GameObject.Find("EventSystem").GetComponent<PlayerManager>().ChangeData(item);
                bool locked=GameObject.Find("EventSystem").GetComponent<PlayerManager>().LockAmount();
                GameObject.Find("EventSystem").GetComponent<ItemManagers>().ClickIcon(item.Id);
                if (!locked)
                {
                    transform.GetChild(0).GetComponent<ItemUI>().UpdateUI();
                    
                }
                break;
            case 4:
                 GameObject.Find("EventSystem").GetComponent<PlayerManager>().ChangeData(item);
                bool locked1 = GameObject.Find("EventSystem").GetComponent<PlayerManager>().LockAmount();
                GameObject.Find("EventSystem").GetComponent<ItemManagers>().ClickIcon(item.Id);

                if (!locked1)
                {
                    transform.GetChild(0).GetComponent<ItemUI>().UpdateUI();

                }
                break;

        }
    }
}
