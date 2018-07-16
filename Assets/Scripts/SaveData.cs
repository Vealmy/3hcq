using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
using System.IO;


public class SaveData :PlayerManager
{
   // public JsonData playersaveData;
    public List<Player> SaveList;
    // Use this for initialization
    void Start()
    {

        //LoadPlayerjs();
        //DecodePlayerjs();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            this.transform.GetComponent<ItemManagers>().SaveItemData();
            if (this.SaveList == null)
            {
                this.SaveList = new List<Player>();
            }
            int id = transform.GetComponent<PlayerManager>().PlayerList[0].Id;
            int blood = transform.GetComponent<PlayerManager>().PlayerList[0].Blood;
            int haveblood = transform.GetComponent<PlayerManager>().PlayerList[0].HaveBlood;
            int activity = transform.GetComponent<PlayerManager>().PlayerList[0].Activity;
            int haveactivity = transform.GetComponent<PlayerManager>().PlayerList[0].HaveActivit;
            int attick = transform.GetComponent<PlayerManager>().PlayerList[0].Attick;
            int defense = transform.GetComponent<PlayerManager>().PlayerList[0].Defense;
            int item1 = transform.GetComponent<PlayerManager>().PlayerList[0].Item1;
            int item2 = transform.GetComponent<PlayerManager>().PlayerList[0].Item2;
            int item3 = transform.GetComponent<PlayerManager>().PlayerList[0].Item3;
            int item4 = transform.GetComponent<PlayerManager>().PlayerList[0].Item4;
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
           // Debug.Log(test1);
           
            FileInfo file = new FileInfo(Application.persistentDataPath  + "file///Assets/Json/Player.json");
            Debug.Log(Application.persistentDataPath  + "file///Assets/Json/Player.json");
            StreamWriter sw = file.CreateText();
            // byte[] bts = System.Text.Encoding.UTF8.GetBytes(test1);
            sw.WriteLine(test1);
            sw.Close();
            sw.Dispose();

        }
        //SavePlayerData();
        
    }
    }
    //public void SavePlayerData() {
        

