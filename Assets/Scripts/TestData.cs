using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
using System.IO;

public class WriteData : PlayerManager {
    public PlayerManager playerManager;
	// Use this for initialization
	void Start () {
		LoadPlayerjs();
		DecodePlayerjs();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.A)) {
            playerData[0]["Blood"] = 100;
            string test1 = JsonMapper.ToJson(playerData);
           Debug.Log(test1);
            FileInfo file = new FileInfo(Application.persistentDataPath+ "file///Assets/Json/Player.json");
            Debug.Log(Application.persistentDataPath + "file///Assets/Json/Player.json");
            StreamWriter sw = file.CreateText();
            // byte[] bts = System.Text.Encoding.UTF8.GetBytes(test1);
            sw.WriteLine(test1);
            sw.Close();
            sw.Dispose();
            Debug.Log("151354");
        }
	}
}
