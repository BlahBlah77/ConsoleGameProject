using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory_Menu_UI : MonoBehaviour {

    public Text descText;
    public Text nameText;

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
