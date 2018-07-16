using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttributeCtr : LoadData {

    public Text AttributeText;

    // Use this for initialization
    void Start () {
        AttributeText = transform.GetChild(1).GetComponent<Text>();
        AttributeText.text = string.Format("攻击力：{0} \n\n防御力：{1}", PlayerList[0].Attick, PlayerList[0].Defense);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    
}
