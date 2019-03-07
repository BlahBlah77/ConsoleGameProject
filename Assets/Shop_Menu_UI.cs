using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop_Menu_UI : MonoBehaviour {

    [Header("Text UI")]
    public Text descText;
    public Text nameText;
    public Text priceText;

    [Header("Item List")]
    public Item_List_Script shopList;
    public Item_List_Script inventoryList;

    [Header("Shop Slots")]
    [SerializeField] Shop_Slot[] slots;

    private void OnEnable()
    {
        slots = GetComponentsInChildren<Shop_Slot>();
        shopList.OnItemUpdate += UIChanger;
        UIChanger();
    }

    private void OnDestroy()
    {
        shopList.OnItemUpdate -= UIChanger;
    }

    void UIChanger()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < shopList.itemList.Count)
            {
                if (shopList == null) Debug.Log("Kill me");
                slots[i].AddItem(shopList.itemList[i]);
            }
            else
            {
                slots[i].RemoveItem();
            }
        }
    }

    public void AddText(Item_Class newItem)
    {
        if (newItem != null)
        {
            descText.text = newItem.itemDescription;
            nameText.text = newItem.itemName;
            priceText.text = "Price: " + newItem.itemValue;
        }
    }

    public void RemoveText()
    {
        descText.text = "";
        nameText.text = "";
        priceText.text = "";
    }
}
