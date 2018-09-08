using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class LoadLootItems : MonoBehaviour
{
    public LoadItemDatabase itemDB;
    public ItemListManager listManager;

    public TextAsset startItemsFile;
    public TextAsset presetItemsFile;
    public TextAsset saveFile;

    private List<ItemDm> startItemList = new List<ItemDm>();

    private void Start()
    {
        startItemList = LoadItems(startItemsFile); // create and initialize startItemList on listManager;
        listManager.startItemList = this.startItemList;
    }

    public List<ItemDm> LoadItems(TextAsset itemFile)
    {
        // grab all items in DB
        return itemDB.dbList;
    }










    public void SaveItemsToFile(List<ItemOm> itemList, TextAsset file)
    {
        BinaryFormatter vb = new BinaryFormatter();
        FileStream saveFile = File.Open(Application.persistentDataPath + "/inventoryInfo.dat", FileMode.Open);

        foreach (var item in itemList)
        {
           // var itemSaveOm = new ItemSaveOm(item.GlobalID, item.location, item.Qu);
        }
    }

}
