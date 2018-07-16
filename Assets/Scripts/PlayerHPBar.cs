using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHPBar : LoadData {

    private Image HpBar;
    private Text HpText;
	// Use this for initialization
	void Start () {
        HpBar = transform.GetChild(0).GetComponent<Image>();
        HpText = transform.GetChild(0).transform.GetChild(0).GetComponent<Text>();
        HpText.text = string.Format("{0}/{1}",PlayerList[0].HaveBlood,PlayerList[0].Blood);
        float i = (float)PlayerList[0].HaveBlood /(float) PlayerList[0].Blood;
        HpBar.fillAmount = i;
    }

    public void  UpdateHpbar(int hp) {
        HpText.text = string.Format("{0}/{1}", hp, PlayerList[0].Blood);
        float i = (float)hp / (float)PlayerList[0].Blood;
        HpBar.fillAmount = i;
    }

	// Update is called once per frame
	void Update () {
		
	}
}
