using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class LoadLootItems : MonoBehaviour
{
    public ItemListManager listManager;

    public TextAsset startItemsFile;
    public TextAsset presetItemsFile;
    public TextAsset saveFile;

    private List<ItemOm> startItemList = new List<ItemOm>();

    private void Start()
    {
        startItemList = LoadItems(startItemsFile); // create and initialize startItemList on listManager;
        listManager.startItemList = this.startItemList;
    }

    public List<ItemOm> LoadItems(TextAsset itemFile)
    {
        List<ItemOm> itemList = new List<ItemOm>();
        foreach (var item in listManager.itemDB.dbList)
        {
            var Om = new ItemOm(item, 1, Resources.Load<Sprite>("ItemImages/" + item.Title), new IntVector2(2, 2));
            itemList.Add(Om);
        }
        var list = itemList;
        return itemList;
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
