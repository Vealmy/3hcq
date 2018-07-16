using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fight  {
    public int Id;
    public string Name;
    public string Des;
    public int Blood;
    public int Skill1;
    public int Skill2;
    public int Skill3;

    public Fight(int id, string name, string des, int blood, int skill1, int skill2, int skill3) {
        this.Id = id;
        this.Name = name;
        this.Des = des;
        this.Blood = blood;
        this.Skill1 = skill1;
        this.Skill2 = skill2;
        this.Skill3 = skill3;
    }	
}
