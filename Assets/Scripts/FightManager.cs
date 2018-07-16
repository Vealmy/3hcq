using System.Collections;
using System.Collections.Generic;
using LitJson;
using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class FightManager :LoadData{
   
    public int additemid;
    private GameObject startView;
    private GameObject waitView;
    public GameObject hideView;
    private string startViewPath = "Prefabs/StartView";
    private string waitViewPath = "Prefabs/WaitView";
    private float invoketime = 2f;
    private int fightId;
    private int skill;
    private int a;
    private int esc;
    private bool builded = false;
    private bool isplayer = true;
    
	// Use this for initialization
	void Start () {
        fightId = 0;
        startView=Instantiate(Resources.Load(startViewPath, typeof(GameObject))) as GameObject;
        startView.transform.parent = GameObject.Find("Canvas").gameObject.transform;
        startView.GetComponent<RectTransform>().localPosition = new Vector3(0, 0, 0);
        Destroy(startView, 2.5f);
	}

    public void onButton1Click() {
        FightList[fightId].Blood -= (5 + (PlayerList[0].Attick/2));
        if (FightList[fightId].Blood <= 0)
        {
            waitView.SetActive(true);
            GameObject.Find("HPBar2").GetComponent<MousterHPBar>().UpdateHpbar(fightId, FightList[fightId].Blood);
            additemid= UnityEngine.Random.Range(0, 10);
            ItemList[additemid].Amount += 1;
            SaveItemData();
            SavePlayerData();
            waitView.transform.GetChild(0).GetComponent<Text>().text = "击败怪物,即将返回城镇";
            SceneManager.LoadScene(1);
        }
        else
        {
            GameObject.Find("HPBar2").GetComponent<MousterHPBar>().UpdateHpbar(fightId, FightList[fightId].Blood);
            BuildView();
        }
    }
    public void onButton2Click()
    {
        FightList[fightId].Blood -= (10 + (PlayerList[0].Attick/2));
        if (FightList[fightId].Blood <= 0)
        {
            waitView.SetActive(true);
            GameObject.Find("HPBar2").GetComponent<MousterHPBar>().UpdateHpbar(fightId, FightList[fightId].Blood);
            additemid = UnityEngine.Random.Range(0, 10);
            ItemList[additemid].Amount += 1;
            SaveItemData();
            SavePlayerData();
            waitView.transform.GetChild(0).GetComponent<Text>().text = "击败怪物,即将返回城镇";
            SceneManager.LoadScene(1);
        }
        else
        {
            GameObject.Find("HPBar2").GetComponent<MousterHPBar>().UpdateHpbar(fightId, FightList[fightId].Blood);
            BuildView();
        }
    }
    public void onButton3Click()
    {
        FightList[fightId].Blood -= (20 + (PlayerList[0].Attick/2));
        if (FightList[fightId].Blood <= 0)
        {
            waitView.SetActive(true);
            GameObject.Find("HPBar2").GetComponent<MousterHPBar>().UpdateHpbar(fightId, FightList[fightId].Blood);
            additemid = UnityEngine.Random.Range(0, 10);
            ItemList[additemid].Amount += 1;
           SaveItemData();
            SavePlayerData();
           // GameObject.Find("FightView").GetComponent<LoadData>().issave = true;
           // Debug.Log(additemid);
            waitView.transform.GetChild(0).GetComponent<Text>().text = "击败怪物,即将返回城镇";
            SceneManager.LoadScene(1);
        }
        else
        {
            GameObject.Find("HPBar2").GetComponent<MousterHPBar>().UpdateHpbar(fightId, FightList[fightId].Blood);
            BuildView();
        }
    }
    public void onButton4Click() {
        esc = UnityEngine.Random.Range(0,1);
        Debug.Log(esc);
        if (esc == 0)
        {
            // BuildView();
            waitView.SetActive(true);
            waitView.transform.GetChild(0).GetComponent<Text>().text = "成功逃离战斗，即将返回城镇";
            SaveItemData();
            SavePlayerData();
            SceneManager.LoadScene(1);
        }
        else {
            BuildView();
            waitView.transform.GetChild(0).GetComponent<Text>().text = "逃离失败";
        }
    }
    public void BuildView() {
        if (!builded)
        {
            waitView = Instantiate(Resources.Load(waitViewPath, typeof(GameObject))) as GameObject;
            waitView.transform.parent = GameObject.Find("Canvas").gameObject.transform;
            waitView.GetComponent<RectTransform>().localPosition = new Vector3(0, 0, 0);
        }
        else {
            waitView.SetActive(true);
        }
            if (isplayer)
            {
            waitView.transform.GetChild(0).GetComponent<Text>().text = "敌人的回合";
            Invoke("HideView", invoketime);
            Invoke("MounsterAttick", invoketime*1.5f);
            builded = true;
            isplayer = false;
            }
            else {
            GameObject.Find("MonsterImage").GetComponent<Animator>().SetBool("monster", false);
            waitView.transform.GetChild(0).GetComponent<Text>().text = "玩家的回合";
                Invoke("HideView", invoketime);
                hideView.SetActive(false);
                isplayer = true;
            }
       
    }

    public void HideView() {
        waitView.SetActive(false);
        if (!isplayer)
        {
            hideView.SetActive(true);
        }
        else {
            hideView.SetActive(false);
        }
    }

    public void MounsterAttick() {
        GameObject.Find("MonsterImage").GetComponent<Animator>().SetBool("monster", true);
        skill = UnityEngine.Random.Range(1, 4);
        if (skill == 1) {
            a = (FightList[fightId].Skill1 - (1/PlayerList[0].Defense/2));
            if (a <= 0) a = 1;
            PlayerList[0].HaveBlood -= a;
            GameObject.Find("HPBar").GetComponent<PlayerHPBar>().UpdateHpbar(PlayerList[0].HaveBlood);
            //isplayer
            BuildView();
        }else if (skill == 2)
        {
            a = (FightList[fightId].Skill2 - ( PlayerList[0].Defense/2));
            if (a <= 0) a = 1;
            PlayerList[0].HaveBlood -= a;
            GameObject.Find("HPBar").GetComponent<PlayerHPBar>().UpdateHpbar(PlayerList[0].HaveBlood);
            BuildView();
        }
        else if (skill == 3)
        {
            a = (FightList[fightId].Skill3 - (PlayerList[0].Defense / 2));
            if (a <= 0) a = 1;
            PlayerList[0].HaveBlood -= a;
            GameObject.Find("HPBar").GetComponent<PlayerHPBar>().UpdateHpbar(PlayerList[0].HaveBlood);
            BuildView();
        }
    }
    public void SaveItemData()
    {
        if (this.SaveItemList == null)
        {
            this.SaveItemList = new List<Item>();
        }
        // Debug.Log(ItemList.Count);
        for (int y = 0; y < ItemList.Count; y++)
        {
            int id = ItemList[y].Id;
            string name = ItemList[y].Name;
            int amount = ItemList[y].Amount;
            string des = ItemList[y].Description;
            int type = ItemList[y].ItemType;
            int valu = ItemList[y].Value;
            string sprite = ItemList[y].Sprite;
            Item item1 = new Item(id, name, amount, des, type, valu, sprite);
            SaveItemList.Add(item1);
        }
        for (int j = 0; j < Itemdata.Count; j++)
        {
            Itemdata[j]["Amount"] = SaveItemList[j].Amount;
        }
        string test2 = JsonMapper.ToJson(Itemdata);
        Regex reg = new Regex(@"(?i)\\[uU]([0-9a-f]{4})");
        string modifyString = reg.Replace(test2, delegate (Match m) { return ((char)Convert.ToInt32(m.Groups[1].Value, 16)).ToString(); });
        Debug.Log(modifyString);
        FileStream file = new FileStream(Application.persistentDataPath + "file///Assets/Json/Item.json", FileMode.Create);
        // Debug.Log(Application.dataPath + "/Json/Item.json");
        byte[] bts = System.Text.Encoding.UTF8.GetBytes(modifyString);
        file.Write(bts, 0, bts.Length);
        file.Close();
        file.Dispose();

    }
    public void SavePlayerData()
    {
        if (this.SaveList == null)
        {
            this.SaveList = new List<Player>();
        }
        int id = PlayerList[0].Id;
        int blood = PlayerList[0].Blood;
        int haveblood = PlayerList[0].HaveBlood;
        int activity = PlayerList[0].Activity;
        int haveactivity = PlayerList[0].HaveActivit;
        int attick = PlayerList[0].Attick;
        int defense = PlayerList[0].Defense;
        int item1 = PlayerList[0].Item1;
        int item2 = PlayerList[0].Item2;
        int item3 = PlayerList[0].Item3;
        int item4 = PlayerList[0].Item4;
        Player player = new Player(id, blood, haveblood, activity, haveactivity, attick, defense, item1, item2, item3, item4);
        SaveList.Add(player);
        //Debug.Log(SaveList[0].HaveBlood);
        //JsonData playersaveData;
        //this.playersaveData=new JsonData();
        playerData[0]["Id"] = SaveList[0].Id;
        playerData[0]["Blood"] = SaveList[0].Blood;
        playerData[0]["HaveBlood"] = SaveList[0].HaveBlood; Debug.Log(SaveList[0].HaveBlood);
        playerData[0]["Activity"] = SaveList[0].Activity;
        playerData[0]["HaveActivity"] = SaveList[0].HaveActivit;
        playerData[0]["Attack"] = SaveList[0].Attick;
        playerData[0]["Defense"] = SaveList[0].Defense;
        playerData[0]["Item1"] = SaveList[0].Item1;
        playerData[0]["Item2"] = SaveList[0].Item2;
        playerData[0]["Item3"] = SaveList[0].Item3;
        playerData[0]["Item4"] = SaveList[0].Item4;

        string test1 = JsonMapper.ToJson(playerData);
        Debug.Log(test1);

        FileInfo file = new FileInfo(Application.persistentDataPath + "file///Assets/Json/Player.json");
        // Debug.Log(Application.dataPath + "/Json/Player.json");
        StreamWriter sw = file.CreateText();
        // byte[] bts = System.Text.Encoding.UTF8.GetBytes(test1);
        sw.WriteLine(test1);
        sw.Close();
        sw.Dispose();

    }
    public void UpdateData(int hp,int amount) {
        PlayerList[0].HaveBlood += hp;
        if (PlayerList[0].HaveBlood > PlayerList[0].Blood)
        {
            PlayerList[0].HaveBlood = PlayerList[0].Blood;
        }
        Debug.Log(PlayerList[0].HaveBlood);
        //amount -= 1;
        ItemList[0].Amount = amount;
        
        GameObject.Find("HPBar").GetComponent<PlayerHPBar>().UpdateHpbar(PlayerList[0].HaveBlood);
    }
    // Update is called once per frame
    void Update () {
		
	}
}
