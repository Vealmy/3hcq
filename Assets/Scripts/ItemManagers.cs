using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System;

public class ItemManagers : MonoBehaviour
{
    public List<Item> ItemList;
    private JsonData Itemdata;
    public Item item;
    public List<Item> SaveItemList;
    bool isSave = false;
    void Awake()
    {
       LoadItemjs();
       DecodeItemjs();
	}
    

   public void LoadItemjs()
   {          //加载JSON文件
        if (this.ItemList == null)
    {
	    this.ItemList = new List<Item>();
    }
        this.Itemdata = JsonMapper.ToObject(File.ReadAllText(Application.persistentDataPath + "file///Assets/Json/Item.json", Encoding.UTF8));//, Encoding.GetEncoding("GB2312")
    }
    public void DecodeItemjs()
    {            //解析JSON文件
	    for (int i = 0; i < Itemdata.Count; i++)
	    {
		    int itemID = (int)this.Itemdata[i]["Id"];
		    string itemName = this.Itemdata[i]["Name"].ToString();
		    int itemAmount = (int)this.Itemdata[i]["Amount"];
		    string  itemDescription = this.Itemdata[i]["Description"].ToString();
		    int itemType = (int)this.Itemdata[i]["ItemType"];
		    int itemValue = (int)this.Itemdata[i]["Value"];
		    string itemSptrte = this.Itemdata[i]["Sprite"].ToString();
		    Item item = new Item(itemID, itemName, itemAmount, itemDescription, itemType, itemValue, itemSptrte);//,itemDescription,itemType,itemValue,itemSptrte
		    this.ItemList.Add(item);
	    }
	}
    public void  ClickIcon(int id) {
        for (int i = 0; i <ItemList.Count; i++) {
            if (ItemList[i].Id == id) {
                ItemList[i].Amount -= 1;
            }
        }
       
    }
    void Update()
    {
       
    }

    public void SaveItemData() {
        if (this.SaveItemList == null)
        {
            this.SaveItemList = new List<Item>();
        }
        Debug.Log(ItemList.Count);
        for (int y = 0; y < ItemList.Count; y++) {
            int id = ItemList[y].Id;
            string name = ItemList[y].Name;
            int amount =ItemList[y].Amount;
            string des = ItemList[y].Description;
            int type = ItemList[y].ItemType;
            int valu = ItemList[y].Value;
            string sprite = ItemList[y].Sprite;
            Item item1 = new Item(id, name, amount, des, type, valu, sprite);
            SaveItemList.Add(item1);
        }
       // Debug.Log(Itemdata.Count+"    2222");

        for (int j = 0; j <Itemdata.Count; j++)
        {
            //Itemdata[j]["Id"] = SaveItemList[j].Id; Debug.Log(SaveItemList [j].Id);
           // Itemdata[j]["Name"] = SaveItemList[j].Name;
            Itemdata[j]["Amount"] = SaveItemList[j].Amount; //Debug.Log(SaveItemList [j].Amount);
           // Itemdata[j]["Description"] = SaveItemList[j].Description;
            //Itemdata[j]["ItemType"] = SaveItemList[j].ItemType;
            //Itemdata[j]["Value"] = SaveItemList[j].Value;
            //Itemdata[j]["Sprite"] = SaveItemList[j].Sprite;
        }
        string test2= JsonMapper.ToJson(Itemdata);
        //Debug.Log(test2);
        Regex reg = new Regex(@"(?i)\\[uU]([0-9a-f]{4})");
        string modifyString = reg.Replace(test2, delegate (Match m) { return ((char)Convert.ToInt32(m.Groups[1].Value, 16)).ToString(); });
        Debug.Log(modifyString);
        FileStream file = new FileStream(Application.persistentDataPath  + "file///Assets/Json/Item.json", FileMode.Create);
        Debug.Log(Application.persistentDataPath  + "file///Assets/Json/Item.json");
        //StreamWriter sw = file.CreateText();
        byte[] bts = System.Text.Encoding.UTF8.GetBytes(modifyString);
        //bts = Encoding.Convert(Encoding.GetEncoding("UTF-8"), Encoding.GetEncoding("GB2312"), bts);
        file.Write(bts,0,bts.Length);
        file.Close();
        file.Dispose();

    }
   
}
