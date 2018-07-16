using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIcon : MonoBehaviour {
    public GameObject IconPrefab;
    public List<Item> UIitemList;
    public Item item1;
	// Use this for initialization
	void Start () {
        int itemid1 = GameObject.Find("EventSystem").GetComponent<PlayerManager>().PlayerList[0].Item1;
        int itemid2 = GameObject.Find("EventSystem").GetComponent<PlayerManager>().PlayerList[0].Item2;
        int itemid3 = GameObject.Find("EventSystem").GetComponent<PlayerManager>().PlayerList[0].Item3;
        int itemid4 = GameObject.Find("EventSystem").GetComponent<PlayerManager>().PlayerList[0].Item4;
        if (itemid1 != 100)
        {
            if (transform.tag == "Shose")
            {
                GameObject itemGameObject = Instantiate(IconPrefab) as GameObject;
                itemGameObject.transform.SetParent(this.transform);
                itemGameObject.transform.localPosition = Vector3.zero;
                itemGameObject.transform.localScale = Vector3.one;
                //Debug.Log(itemid1);
                if(this.UIitemList == null)
                {
                    this.UIitemList = new List<Item>();
                }
                //Debug.Log(itemid1); Debug.Log(GameObject.Find("EventSystem").GetComponent<ItemManagers>().ItemList.Count);
                for (int j = 0; j <GameObject.Find("EventSystem").GetComponent<ItemManagers>().ItemList.Count; j++)
                {
                    
                    this.UIitemList.Add(GameObject.Find("EventSystem").GetComponent<ItemManagers>().ItemList[j]);
                   
                }

                for (int i = 0; i < UIitemList.Count; i++)
                {
                    if (UIitemList[i].Id == itemid1)
                    {
                        item1 = UIitemList[i];
                    }
                }
                itemGameObject.transform.GetComponent<ItemUI>().SetUI(item1);
            }
        }
        if (itemid2 != 100)
        {
            if (transform.tag == "Head")
            {
                GameObject itemGameObject = Instantiate(IconPrefab) as GameObject;
                itemGameObject.transform.SetParent(this.transform);
                itemGameObject.transform.localPosition = Vector3.zero;
                itemGameObject.transform.localScale = Vector3.one;
                this.UIitemList = new List<Item>();
                UIitemList = GameObject.Find("EventSystem").transform.GetComponent<ItemManagers>().ItemList;

                for (int i = 0; i <UIitemList.Count; i++)
                {
                    if (UIitemList[i].Id == itemid2)
                    {
                        item1 = UIitemList[i];
                    }
                }
                itemGameObject.transform.GetComponent<ItemUI>().SetUI(item1);
            }
        }
        if (itemid3 != 100)
        {
            if (transform.tag == "kuijia")
            {
                GameObject itemGameObject = Instantiate(IconPrefab) as GameObject;
                itemGameObject.transform.SetParent(this.transform);
                itemGameObject.transform.localPosition = Vector3.zero;
                itemGameObject.transform.localScale = Vector3.one;
                this.UIitemList = new List<Item>();
                UIitemList = GameObject.Find("EventSystem").transform.GetComponent<ItemManagers>().ItemList;

                for (int i = 0; i < UIitemList.Count; i++)
                {
                    if (UIitemList[i].Id == itemid3)
                    {
                        item1 = UIitemList[i];
                    }
                }
                itemGameObject.transform.GetComponent<ItemUI>().SetUI(item1);
            }
        }
        if (itemid4 != 100)
        {
            if (transform.tag == "Weapone")
            {
                GameObject itemGameObject = Instantiate(IconPrefab) as GameObject;
                itemGameObject.transform.SetParent(this.transform);
                itemGameObject.transform.localPosition = Vector3.zero;
                itemGameObject.transform.localScale = Vector3.one;
                this.UIitemList = new List<Item>();
                UIitemList = GameObject.Find("EventSystem").transform.GetComponent<ItemManagers>().ItemList;

                for (int i = 0; i < UIitemList.Count; i++)
                {
                    if (UIitemList[i].Id == itemid4)
                    {
                        item1 = UIitemList[i];
                    }
                }
                itemGameObject.transform.GetComponent<ItemUI>().SetUI(item1);
            }
        }
    }
    
    public void BuildPlayerIcon(Item item) {
        
            GameObject itemGameObject = Instantiate(IconPrefab) as GameObject;
            itemGameObject.transform.SetParent(this.transform);
            itemGameObject.transform.localPosition = Vector3.zero;
            itemGameObject.transform.localScale = Vector3.one;
        
        
        int itemid;
        if (transform.tag == "Shose")
        {
            itemid = GameObject.Find("EventSystem").GetComponent<PlayerManager>().PlayerList[0].Item1;
            //Item item = GameObject.Find("EventSystem").GetComponent<ItemManagers>().ItemList[itemid];
            itemGameObject.transform.GetComponent<ItemUI>().SetUI(item);
        }
        else if (transform.tag == "Head") {
            itemid = GameObject.Find("EventSystem").GetComponent<PlayerManager>().PlayerList[0].Item2;
           // Item item = GameObject.Find("EventSystem").GetComponent<ItemManagers>().ItemList[itemid];
            itemGameObject.transform.GetComponent<ItemUI>().SetUI(item);
        }
        else if (transform.tag == "kuijia")
        {
            itemid = GameObject.Find("EventSystem").GetComponent<PlayerManager>().PlayerList[0].Item3;
            //Item item = GameObject.Find("EventSystem").GetComponent<ItemManagers>().ItemList[itemid];
            itemGameObject.transform.GetComponent<ItemUI>().SetUI(item);
        }
        else if (transform.tag == "Weapone")
        {
            
            itemid = GameObject.Find("EventSystem").GetComponent<PlayerManager>().PlayerList[0].Item4;
            //Item item = GameObject.Find("EventSystem").GetComponent<ItemManagers>().ItemList[itemid];
            itemGameObject.transform.GetComponent<ItemUI>().SetUI(item);
        }
    }
    public void ChangeIcon(Item item) {
        int itemid;
        
        if (transform.tag == "Weapone")
        {
            itemid = GameObject.Find("EventSystem").GetComponent<PlayerManager>().PlayerList[0].Item4;
            //Item item = GameObject.Find("EventSystem").GetComponent<ItemManagers>().ItemList[itemid];
            IconPrefab.transform.GetComponent<ItemUI>().SetUI(item);
        }
    }
	
}
