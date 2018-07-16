using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player  {

    public int Id;
    public int Blood;
    public int HaveBlood;
    public int Activity;
    public int HaveActivit;
    public int Attick;
    public int Defense;
    public int Item1;
    public int Item2;
    public int Item3;
    public int Item4;

    public Player(int id, int blood, int haveblood, int activity, int haveactivity, int attack, int defense,int item1,int item2,int item3,int item4)
    {
        this.Id = id;
        this.Blood = blood;
        this.HaveBlood = haveblood;
        this.Activity = activity;
        this.HaveActivit = haveactivity;
        this.Attick = attack;
        this.Defense = defense;
        this.Item1 = item1;
        this.Item2 = item2;
        this.Item3 = item3;
        this.Item4 = item4;
    }
}
