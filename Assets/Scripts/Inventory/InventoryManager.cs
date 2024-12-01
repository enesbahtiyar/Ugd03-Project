using System;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : SingletonMonoBehaviour<InventoryManager>
{
    public List<InventoryItem>[] inventoryLists;

    [HideInInspector]
    public int[] inventoryListCapacityIntArray;

    Dictionary<int, ItemDetails> itemDetailsDictionary;

    [SerializeField]SO_ItemList itemList;

    private int[] selectedInventoryItem;

    protected override void Awake()
    {
        base.Awake();

        //inventory listleri oluşturalım
        CreateInventoryList();

        selectedInventoryItem = new int[(int)InventoryLocation.count];

        for(int i = 0; i< selectedInventoryItem.Length; i++)
        {
            selectedInventoryItem[i] = -1;
        }
    }
    private void Start()
    {
        CreateItemDetailsDictionary();
    }

    public void SetSelectedInventoryItem(InventoryLocation inventoryLocation, int itemCode)
    {
        selectedInventoryItem[(int)inventoryLocation] = itemCode;
    }

    public void ClearSelectedInventoryItem(InventoryLocation inventoryLocation)
    {
        selectedInventoryItem[(int)inventoryLocation] = -1;
    }

    private void CreateInventoryList()
    {
        inventoryLists = new List<InventoryItem>[(int)InventoryLocation.count];

        for (int i = 0; i < (int)InventoryLocation.count; i++)
        {
            inventoryLists[i] = new List<InventoryItem>();
        }

        inventoryListCapacityIntArray = new int[(int)InventoryLocation.count];

        inventoryListCapacityIntArray[(int)InventoryLocation.player] = Settings.playerStartInventoryCapacity;
        inventoryListCapacityIntArray[(int)InventoryLocation.chest] = Settings.playerMaximumuInventoryCapacity;
    }

    public void AddItem(InventoryLocation location, Item item, GameObject toBeDestroyedObject)
    {
        AddItem(location, item);

        Destroy(toBeDestroyedObject);
    }

    private void AddItem(InventoryLocation inventoryLocation, Item item)
    {
        int itemCode = item.ItemCode;
        List<InventoryItem> inventoryList = inventoryLists[(int)inventoryLocation];

        int itemPosition = FindItemInInventory(inventoryLocation, itemCode);

        if(itemPosition != -1)
        {
            //bu eğer eklemek istediğimiz item envanterde varsa çalışacak olan kısım 
            AddItemAtPosition(inventoryList, itemCode, itemPosition);
        }
        else
        {
            //bu da eğer eklemek istediğimiz item envanterde yoksa listenin en sonuna ekle
            AddItemAtPosition(inventoryList, itemCode);
        }

        EventHandler.CallInventoryUpdatedEvent(inventoryLocation, inventoryLists[(int)inventoryLocation]);
    }

    /// <summary>
    /// bu method eğer eklemek istediğimiz item zaten envanterde varsa çalışan method
    /// </summary>
    /// <param name="inventoryList"></param>
    /// <param name="itemCode"></param>
    /// <param name="itemPosition"></param>
    private void AddItemAtPosition(List<InventoryItem> inventoryList, int itemCode, int itemPosition)
    {
        InventoryItem item = new InventoryItem();

        int quantity = inventoryList[itemPosition].itemQuantity + 1;
        item.itemQuantity = quantity;
        item.itemCode = itemCode;
        inventoryList[itemPosition] = item;
    }

    /// <summary>
    /// bu method eğer eklemek istediğimiz item envanterde yoksa eklemek istediğimiz itemi envanterin sonuna ekleyen method
    /// </summary>
    /// <param name="inventoryList"></param>
    /// <param name="itemCode"></param>
    private void AddItemAtPosition(List<InventoryItem> inventoryList, int itemCode)
    {
        InventoryItem item = new InventoryItem();

        item.itemCode = itemCode;
        item.itemQuantity = 1;
        inventoryList.Add(item);
    }

    public int FindItemInInventory(InventoryLocation inventoryLocation, int itemCode)
    {
        List<InventoryItem> inventoryList = inventoryLists[(int)inventoryLocation];
        
        for(int i = 0; i < inventoryList.Count; i++)
        {
            if (inventoryList[i].itemCode == itemCode)
            {
                return i;
            }
        }

        return -1;
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

    internal void RemoveItem(InventoryLocation inventoryLocation, int itemCode)
    {
        List<InventoryItem> inventoryList = inventoryLists[(int)inventoryLocation];

        int itemPosition = FindItemInInventory(inventoryLocation, itemCode);

        if(itemPosition != -1)
        {
            RemoveAtPosition(inventoryList, itemPosition, itemCode);
        }


        EventHandler.CallInventoryUpdatedEvent(inventoryLocation, inventoryLists[(int)inventoryLocation]);
    }

    private void RemoveAtPosition(List<InventoryItem> inventoryList, int itemPosition, int itemCode)
    {
        InventoryItem inventoryItem = new InventoryItem();

        int quantity = inventoryList[itemPosition].itemQuantity - 1;

        if(quantity > 0)
        {
            inventoryItem.itemQuantity = quantity;
            inventoryItem.itemCode = itemCode;

            inventoryList[itemPosition] = inventoryItem;
        }
        else
        {
            inventoryList.RemoveAt(itemPosition);
        }
    }

    internal void SwapInventoryItems(InventoryLocation inventoryLocation, int fromItem, int toItem)
    {
        if(fromItem < inventoryLists[(int)inventoryLocation].Count && toItem < inventoryLists[(int)inventoryLocation].Count 
            && fromItem != toItem && fromItem >= 0 && toItem >= 0)
        {
            InventoryItem fromInventoryItem  = inventoryLists[(int)inventoryLocation][fromItem];
            InventoryItem toInventoryItem = inventoryLists[(int)inventoryLocation][toItem];


            inventoryLists[(int)inventoryLocation][toItem] = fromInventoryItem;
            inventoryLists[(int)inventoryLocation][fromItem] = toInventoryItem;


            EventHandler.CallInventoryUpdatedEvent(inventoryLocation, inventoryLists[(int)inventoryLocation]);
        }
    }

    public string GetItemTypeDescription(ItemType itemType)
    {
        string itemTypeDescription;

        switch(itemType)
        {
            case ItemType.Breaking_Tool:
                itemTypeDescription = Settings.BreakingTool;
                break;

            case ItemType.Chopping_Tool:
                itemTypeDescription = Settings.ChoppingTool;
                break;

            case ItemType.Hoeing_Tool:
                itemTypeDescription = Settings.HoeingTool;
                break;

            case ItemType.Reaping_Tool:
                itemTypeDescription = Settings.ReapingTool;
                break;

            case ItemType.Watering_Tool:
                itemTypeDescription = Settings.WateringTool;
                break;

            case ItemType.Collecting_Tool:
                itemTypeDescription = Settings.CollectingTool;
                break;

            default:
                itemTypeDescription = itemType.ToString();
                break;
        }

        return itemTypeDescription;
    }
}
