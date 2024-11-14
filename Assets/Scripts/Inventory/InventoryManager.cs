using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : SingletonMonoBehaviour<InventoryManager>
{
    Dictionary<int, ItemDetails> itemDetailsDictionary;

    [SerializeField]SO_ItemList itemList;
    private void Start()
    {
        CreateItemDetailsDictionary();
    }

    private void CreateItemDetailsDictionary()
    {
        itemDetailsDictionary = new Dictionary<int, ItemDetails>();

        foreach(ItemDetails itemdetails in itemList.itemDetails)
        {
            itemDetailsDictionary.Add(itemdetails.itemCode, itemdetails);
        }
    }

    public ItemDetails GetItemDetails(int itemCode)
    {
        ItemDetails itemDetails;

        if(itemDetailsDictionary.TryGetValue(itemCode, out itemDetails))
        {
            return itemDetails;
        }
        else
        {
            return null;
        }
    }
}
