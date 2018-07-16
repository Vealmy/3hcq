using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
using System.IO;
using System.Text;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour {


    public List<Player> PlayerList;
    public JsonData playerData;
    public Text playerText;
    public bool islock = false;

    void Awake()
    {
        LoadPlayerjs();
        DecodePlayerjs();
    }
    #region playerData
    public Player player { get; set; }
    #endregion
    void Start()
    {
		
        //ShowText();
    }

    public void LoadPlayerjs()
    {          //加载JSON文件
        if (this.PlayerList == null)
        {
            this.PlayerList = new List<Player>();
        }
        //Debug.Log("1");
		this.playerData = JsonMapper.ToObject(File.ReadAllText(Application.persistentDataPath  + "file///Assets/Json/Player.json", Encoding.GetEncoding("GB2312")));//, Encoding.GetEncoding("GB2312")
       // Debug.Log("2");
    }
    public void DecodePlayerjs()
    {            //解析JSON文件
        int playerId = (int)this.playerData[0]["Id"];
        int playerBlood=(int)this.playerData[0]["Blood"];
        int playerHaveblood= (int)this.playerData[0]["HaveBlood"];
        int playerActivity= (int)this.playerData[0]["Activity"];
        int playerHaveactivity= (int)this.playerData[0]["HaveActivity"];
        int playerAttack= (int)this.playerData[0]["Attack"];
        int playerDefense= (int)this.playerData[0]["Defense"];
        int playerItem1 = (int)this.playerData[0]["Item1"];
        int playerItem2 = (int)this.playerData[0]["Item2"];
        int playerItem3 = (int)this.playerData[0]["Item3"];
        int playerItem4 = (int)this.playerData[0]["Item4"];
        //Debug.Log(playerId+" " +playerBlood+" "+playerActivity+" "+ playerAttack+" "+playerDefense);
        Player player = new Player(playerId, playerBlood, playerHaveblood,playerActivity, playerHaveactivity,playerAttack, playerDefense,playerItem1,playerItem2,playerItem3,playerItem4);
        this.PlayerList.Add(player);
    } 
    public void ShowText() {
        
        playerText.text = string.Format( "生命：{4}/{0}\n法力：{5}/{1}\n攻击：{2}\n防御：{3}",PlayerList[0].Blood,PlayerList[0].Activity,PlayerList[0].Attick,PlayerList[0].Defense,PlayerList[0].HaveBlood,PlayerList[0].HaveActivit); //"11111111";//
    }
	public void Load(){
		LoadPlayerjs();
		DecodePlayerjs();
		playerText =GameObject.Find("Value").GetComponent<Text>();
		ShowText();
        
    }
    public void ChangeData(Item item)
    {
        int type = item.ItemType;
        int value = item.Value;
        switch (type)
        {
            case 0:
                int haveblood = PlayerList[0].HaveBlood;
                int blood = PlayerList[0].Blood;
                haveblood = haveblood + value;
                if (haveblood <= blood)
                {
                    PlayerList[0].HaveBlood = haveblood;
                }
                else
                {
                    PlayerList[0].HaveBlood = blood;
                }
                break;
            case 1:
                int haveactivity = PlayerList[0].HaveActivit;
                int actrvity = PlayerList[0].Activity;
                haveactivity = haveactivity + value;
                if (haveactivity <=actrvity )
                {
                    PlayerList[0].HaveActivit = haveactivity;
                }
                else
                {
                    PlayerList[0].HaveActivit = actrvity;
                }
                break;
            case 3:
                //int attack = PlayerList[0].Attick;
                int defense = PlayerList[0].Defense;
                int child1Id = PlayerList[0].Item1;
                int child2Id = PlayerList[0].Item2;
                int child3Id = PlayerList[0].Item3;
                int clickId = item.Id;
              
                if (clickId == 5 && child1Id == 100)
                {
                    PlayerList[0].Defense += value;
                    PlayerList[0].Item1 = 5;
                    GameObject.Find("Shose").GetComponent<PlayerIcon>().BuildPlayerIcon(item);
                    islock = false; //Debug.Log("false");
                }
                else if(clickId==5&&child1Id!=100){
                    islock = true; //Debug.Log("true");
                    //PlayerList[0].Defense;
                }
                if (clickId == 6 && child2Id == 100)
                {
                    PlayerList[0].Defense += value;
                    PlayerList[0].Item2 = 6;
                    GameObject.Find("kuijia").GetComponent<PlayerIcon>().BuildPlayerIcon(item);
                    islock = false;// Debug.Log("false");
                }
                else if (clickId == 6 && child2Id != 100)
                {
                    islock = true;// Debug.Log("true");
                }
                if (clickId == 7 && child3Id == 100)
                {
                    PlayerList[0].Defense += value;
                    PlayerList[0].Item3 = 7;
                    GameObject.Find("Head").GetComponent<PlayerIcon>().BuildPlayerIcon(item);
                    islock = false; //Debug.Log("false");
                }
                else if (clickId == 7 && child3Id != 100) {
                    islock = true;
                    //Debug.Log("true");
                }
               
                break;
            case 4:
                int child4Id = PlayerList[0].Item4;
                int clickId1 = item.Id;
                if (clickId1 == 9 && child4Id == 100)
                {
                    PlayerList[0].Item4 = 9;
                    int attack = PlayerList[0].Attick;
                    PlayerList[0].Attick += value;
                    GameObject.Find("Weapone").GetComponent<PlayerIcon>().BuildPlayerIcon(item);
                    islock = false; //Debug.Log("false");
                }
                else if (clickId1 == 9 && child4Id == 9)
                {
                    islock = true; //Debug.Log("true");
                    //PlayerList[0].Defense;
                }
                else if (clickId1 == 9 && child4Id == 10) {
                    Debug.Log("10");
                    PlayerList[0].Item4 = 10;
                    int attack = PlayerList[0].Attick;
                    int deattack = transform.GetComponent<ItemManagers>().ItemList[10].Value;
                    PlayerList[0].Attick -= deattack;
                    PlayerList[0].Attick += value;
                    Destroy(GameObject.Find("Weapone").transform.GetChild(0).gameObject);
                    this.transform.GetComponent<ItemManagers>().ItemList[10].Amount += 1;
                    GameObject.Find("Weapone").GetComponent<PlayerIcon>().BuildPlayerIcon(item);
                    islock = false;
                }

                if (clickId1 == 10 && child4Id == 100)
                {
                    PlayerList[0].Item4 = 10;
                    int attack = PlayerList[0].Attick;
                    PlayerList[0].Attick += attack;
                    GameObject.Find("Weapone").GetComponent<PlayerIcon>().BuildPlayerIcon(item);
                    islock = false; //Debug.Log("false");
                }
                else if (clickId1 == 10 && child4Id == 10)
                {
                    islock = true; //Debug.Log("true");
                    //PlayerList[0].Defense;
                }
                else if (clickId1 == 10 && child4Id == 9)
                {
                    Debug.Log("10");
                    PlayerList[0].Item4 = 9;
                    int attack = PlayerList[0].Attick;
                    int deattack = transform.GetComponent<ItemManagers>().ItemList[9].Value;
                    PlayerList[0].Attick -= deattack;
                    PlayerList[0].Attick += value;
                    Destroy(GameObject.Find("Weapone").transform.GetChild(0).gameObject);
                    this.transform.GetComponent<ItemManagers>().ItemList[9].Amount += 1;
                    GameObject.Find("Weapone").GetComponent<PlayerIcon>().BuildPlayerIcon(item);
                    islock = false;
                }
                break;
        }
        //Debug.Log(PlayerList[0].HaveBlood);
        if (playerText != null)
        {
            ShowText();
        }
    }
    public virtual bool LockAmount() {
        bool Locked = false;
        if (islock)
        {
            Locked = true;
        }
        else {
            Locked = false;
                }
        return Locked;
    }
}
