using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop_Menu_UI : MonoBehaviour {

    [Header("Text UI")]
    public Text descText;
    public Text nameText;

    [Header("Item List")]
    public Item_List_Script shopList;
    public Item_List_Script inventoryList;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void AddText(Item_Class newItem)
    {
        if (newItem != null)
        {
            descText.text = newItem.itemDescription;
            nameText.text = newItem.itemName;
        }
    }

    public void RemoveText()
    {
        descText.text = "";
        nameText.text = "";
    }
}
