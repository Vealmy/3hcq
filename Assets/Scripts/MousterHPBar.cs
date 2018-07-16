using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MousterHPBar : LoadData {

    private Image HpBar;
    private Text HpText;
    /// <summary>
    /// start里要注释掉，因为两种怪物血量不同，要后调用
    /// </summary>
    // Use this for initialization
    void Start()
    {
        HpBar = transform.GetChild(0).GetComponent<Image>();
        HpText = transform.GetChild(0).transform.GetChild(0).GetComponent<Text>();
        HpText.text = string.Format("{0}/{1}", FightList[0].Blood, FightList[0].Blood);
        HpBar.fillAmount = 1;
    }
    
    public void LoadHpbar(int id)
    {
        HpText.text = string.Format("{0}/{1}", PlayerList[id].Blood, PlayerList[id].Blood);
        HpBar.fillAmount = 1;
    }
    /// <summary>
    /// id为怪物id hp为怪物当前血量
    /// </summary>
    /// <param name="i"></param>
    public void UpdateHpbar(int id,int hp)
    {
        //Debug.Log(PlayerList[0].HaveBlood);
        HpText.text = string.Format("{0}/{1}", hp, PlayerList[0].Blood);
        float i = (float)hp / (float)PlayerList[0].Blood;
        HpBar.fillAmount = i;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
