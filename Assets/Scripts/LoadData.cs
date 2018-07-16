using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using LitJson;
using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
//using System.Text.RegularExpressions;

/// <summary>
/// Fight Scene里Json的解析都在这个脚本中进行
/// 进行解析的表有 Item.json,Player.json,Enemy.json;
/// </summary>

public class LoadData : MonoBehaviour {

    public List<Item> ItemList;
    public  JsonData Itemdata;
    public List<Item> SaveItemList;
    public List<Player> PlayerList;
    public List<Player> SaveList;
    public JsonData playerData;
    public List<Fight> FightList;
    public JsonData Fightdata;
    public bool issave=false;

    void Awake()
    {
        LoadItemjs();
        DecodeItemjs();
        LoadPlayerjs();
        DecodePlayerjs();
        LoadFightjs();
        DecodeFightjs();
    }
    public void LoadItemjs()
    {          //加载JSON文件
        if (this.ItemList == null)
        {
            this.ItemList = new List<Item>();
        }
        this.Itemdata = JsonMapper.ToObject(File.ReadAllText(Application.persistentDataPath  + "file///Assets/Json/Item.json", Encoding.UTF8));
    }
    public void DecodeItemjs()
    {            //解析JSON文件
        for (int i = 0; i < Itemdata.Count; i++)
        {
            int itemID = (int)this.Itemdata[i]["Id"];
            string itemName = this.Itemdata[i]["Name"].ToString();
            int itemAmount = (int)this.Itemdata[i]["Amount"];
            string itemDescription = this.Itemdata[i]["Description"].ToString();
            int itemType = (int)this.Itemdata[i]["ItemType"];
            int itemValue = (int)this.Itemdata[i]["Value"];
            string itemSptrte = this.Itemdata[i]["Sprite"].ToString();
            Item item = new Item(itemID, itemName, itemAmount, itemDescription, itemType, itemValue, itemSptrte);
            this.ItemList.Add(item);
        }
    }
    public void LoadPlayerjs()
    {          //加载JSON文件
        if (this.PlayerList == null)
        {
            this.PlayerList = new List<Player>();
        }
        this.playerData = JsonMapper.ToObject(File.ReadAllText(Application.persistentDataPath  + "file///Assets/Json/Player.json", Encoding.GetEncoding("GB2312")));
    }
    public void DecodePlayerjs()
    {            //解析JSON文件
        int playerId = (int)this.playerData[0]["Id"];
        int playerBlood = (int)this.playerData[0]["Blood"];
        int playerHaveblood = (int)this.playerData[0]["HaveBlood"];
        int playerActivity = (int)this.playerData[0]["Activity"];
        int playerHaveactivity = (int)this.playerData[0]["HaveActivity"];
        int playerAttack = (int)this.playerData[0]["Attack"];
        int playerDefense = (int)this.playerData[0]["Defense"];
        int playerItem1 = (int)this.playerData[0]["Item1"];
        int playerItem2 = (int)this.playerData[0]["Item2"];
        int playerItem3 = (int)this.playerData[0]["Item3"];
        int playerItem4 = (int)this.playerData[0]["Item4"];
        Player player = new Player(playerId, playerBlood, playerHaveblood, playerActivity, playerHaveactivity, playerAttack, playerDefense, playerItem1, playerItem2, playerItem3, playerItem4);
        this.PlayerList.Add(player);
    }
    public void LoadFightjs()
    {          //加载JSON文件
        if (this.FightList == null)
        {
            this.FightList = new List<Fight>();
        }
        this.Fightdata = JsonMapper.ToObject(File.ReadAllText(Application.persistentDataPath + "file///Assets/Json/Fight.json", Encoding.GetEncoding("GB2312")));//Encoding.UTF8
    }
    public void DecodeFightjs()
    {            //解析JSON文件
        for (int i = 0; i < Fightdata.Count; i++)
        {
            int fightID = (int)this.Fightdata[i]["Id"];
            string fightName = this.Fightdata[i]["Name"].ToString();
            string fightDes = this.Fightdata[i]["Des"].ToString();
            int fightBlood = (int)this.Fightdata[i]["Blood"];
            int fightSkill1 = (int)this.Fightdata[i]["Skill1"];
            int fightSkill2= (int)this.Fightdata[i]["Skill2"];
            int fightSkill3 = (int)this.Fightdata[i]["Skill3"];
            Fight fight = new Fight(fightID,fightName,fightDes,fightBlood,fightSkill1,fightSkill2,fightSkill3);
            this.FightList.Add(fight);
        }
    }
   

    // Use this for initialization
    void Start () {
        Debug.Log(ItemList[1].Description);
        Debug.Log(PlayerList[0].Activity);
        Debug.Log(FightList[0].Name);
	}
	
	// Update is called once per frame
	void Update () {
       
        //if (issave) {
        //    Debug.Log("1111111");
           
        //    issave = false;
        //}
	}
}
