using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item { 
    public int Id;
    public string Name;
    public int Amount;
    public string Description;
    public int ItemType;//1 血瓶，2 蓝瓶，0 钥匙
    public int Value;
    public string Sprite;

    public string uiText;
    
    public  Item(int id, string name, int amount,string description,int itemtype,int value,string sprite)
    {
        this.Id = id;
        this.Name = name;
        this.Amount = amount;
        this.Description = description;
        this.ItemType = itemtype;
        this.Value = value;
        this.Sprite = sprite;
    }
    public virtual string UIText()
    {
        switch (ItemType) {
            case 0:
             uiText = string.Format("<size=25>{0}</size>\n物品类型:消耗品  \n回复生命值:{1}\n\n描述:{2}  \n", Name,  Value, Description);
            //uiText = "名称" + Name+ "物品类型" + ItemType + "+" + Value + "详情" + Description;
            break;
            case 1:
                uiText = string.Format("<size=25>{0}</size>\n物品类型:消耗品  \n回复魔力值:{1}\n\n描述:{2}  \n", Name,  Value, Description);
                //uiText = "名称" + Name+ "物品类型" + ItemType + "+" + Value + "详情" + Description;
                break;
            case 2:
                uiText = string.Format("<size=25>{0}</size>\n物品类型:门票\n\n描述:{1}  \n", Name,  Description);
                //uiText = "名称" + Name+ "物品类型" + ItemType + "+" + Value + "详情" + Description;
                break;
            case 3:
                uiText = string.Format("<size=25>{0}</size>\n物品类型:装备  \n防御力:{1}\n\n描述:{2}  \n", Name, Value, Description);
                //uiText = "名称" + Name+ "物品类型" + ItemType + "+" + Value + "详情" + Description;
                break;
            case 4:
                uiText = string.Format("<size=25>{0}</size>\n物品类型:材料 \n攻击力{2}\n描述:{1}  \n", Name,   Description,Value);
                //uiText = "名称" + Name+ "物品类型" + ItemType + "+" + Value + "详情" + Description;
                break;
            case 5:
                uiText = string.Format("<size=25>{0}</size>\n物品类型:材料 \n\n描述:{1}  \n", Name, Description);
                //uiText = "名称" + Name+ "物品类型" + ItemType + "+" + Value + "详情" + Description;
                break;
        }
        return uiText;
    }
}
