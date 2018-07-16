using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemUI : MonoBehaviour {
    #region Data
	public Item Item { get;private set; }
    public int amount { get; set; }
    #endregion
    public Image Icon;
    public Text amountText;
    
    // Use this for initialization
    void Start () {
        amount = Item.Amount;
        this.transform.GetComponent<Image>().sprite = Resources.Load<Sprite>(Item.Sprite);
        //this.Item = item;
    }
    public void ChangeUI(Item item) {
        this.transform.GetComponent<Image>().sprite = Resources.Load<Sprite>(item.Sprite);
        this.Item = item;
    }

    public void SetUI(Item item) {
        Icon.sprite = Resources.Load<Sprite>(item.Sprite);
//        Debug.Log(item.Sprite);
        amountText.text = item.Amount.ToString();
		this.Item = item;
    }
    public void UpdateUI() {
        amount -= 1;
        if (amount > 0)
        {
//            Debug.Log(amount);
            amountText.text = (amount).ToString();
        }
        else if (amount <= 0) {
            Destroy(this.gameObject);
        } 
    }
}
