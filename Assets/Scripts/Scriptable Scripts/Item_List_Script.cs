using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DefaultName", menuName = "Equipment/Item List")]
public class Item_List_Script : ScriptableObject
{
    public List<Item_Class> itemList;
    public List<Item_Class> defaultItemList;

    public delegate void OnItemUpdateHandle();
    public event OnItemUpdateHandle OnItemUpdate;

    public void ItemAdd(Item_Class item)
    {
        itemList.Add(item);
        if (OnItemUpdate != null)
        {
            OnItemUpdate();
        }
    }

    public void ItemRemove(Item_Class item)
    {
        itemList.Remove(item);
        if (OnItemUpdate != null)
        {
            OnItemUpdate();
        }
    }

    public void FullItemRemove()
    {
        itemList = new List<Item_Class>();
    }
}
