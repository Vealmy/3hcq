using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagManager : ItemManagers {
	public List<Item> ItemDisList;
    protected BagCtr[] GridList;
    public string text;
    // Use this for initialization
    void Start () {
        //Debug.Log("1111");
		ItemDisList = new List<Item> ();
        for (int i = 0; i < ItemList.Count; i++)//将数量不为0的道具存到ItemDisList表中;
        {
            if (ItemList[i].Amount != 0) {
				ItemDisList.Add(ItemList[i]);
            }
        }
        GridList = GetComponentsInChildren<BagCtr>();//将物品下方Grid存入数组GridList中;
        for (int i = 0; i < ItemDisList.Count; i++)
        {
            BagCtr grid = FindEmptyGrid();
            if (grid != null) {
                grid.BuildIcon(ItemDisList[i]);
            }
        }
	}
    private BagCtr FindEmptyGrid()
    {
        foreach (BagCtr grid in GridList)
        {
            if (grid.transform.childCount == 0)
            {
                return grid;
            }
        }
        return null;
    }
    // Update is called once per frame
    void Update () {
		
	}
    
}
