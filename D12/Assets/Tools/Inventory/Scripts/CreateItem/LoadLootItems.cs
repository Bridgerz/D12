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
        // grab all items in DB (later will just be things the WB allows players to see)
        return itemDB.dbList;
    }
}
