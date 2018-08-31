using Assets.Inventory.Scripts.ItemObject;
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using System.Text;

[Serializable]
public class LoadItemDatabase : MonoBehaviour {

    public TextAsset dbFile;
    public List<string> TypeNameList = new List<string>();

    private string FilePath;

    private void Awake()
    {
        FilePath = Application.dataPath + "/StreamingAssets/data.json";
        LoadCSVDb(dbFile);
    }
    [Serializable]
    public class ItemData
    {
        public int GlobalID;
        public Category Category;
        public int TypeID;
        public string TypeName;
        public IntVector2 Size;
        public Sprite Icon;
    }


    public List<ItemData> dbList = new List<ItemData>();

    private void LoadCSVDb(TextAsset csvFile)
    {
        string[][] grid = CsvReadWrite.LoadTextFile(csvFile);
        for (int i = 1; i < grid.Length; i++)
        {
            Int32 num = Int32.Parse(grid[i][0]);
            ItemData row = new ItemData();
            row.GlobalID = Int32.Parse(grid[i][0]);
            row.Category = (Category) Enum.Parse(typeof(Category), grid[i][1]);
            row.TypeID = Int32.Parse(grid[i][3]);
            row.TypeName = grid[i][4];
            TypeNameList.Add(row.TypeName);
            row.Size = new IntVector2(Int32.Parse(grid[i][5]), Int32.Parse(grid[i][6]));
            row.Icon = Resources.Load<Sprite>("ItemImages/" + grid[i][4]);
            dbList.Add(row);
        }
    }

    public void PassItemData(ref ItemClass item)
    {
        int ID = item.GlobalID;
        item.Category = dbList[ID].Category;
        item.TypeID = dbList[ID].TypeID;
        item.TypeName = dbList[ID].TypeName;
        item.Size = dbList[ID].Size;
        item.Icon = dbList[ID].Icon;
    }



    //create find item funtions later

    //*from CsvParser2*
    //public Row Find_ItemTypeID(string find)
    //{
    //	return rowList.Find(x => x.GlobalID.ToString() == find);
    //}
    //public List<Row> FindAll_ItemTypeID(string find)
    //{
    //	return rowList.FindAll(x => x.GlobalID.ToString() == find);
    //}
    //public Row Find_ItemTypeName(string find)
    //{
    //	return rowList.Find(x => x.TypeName == find);
    //}
    //public List<Row> FindAll_ItemTypeName(string find)
    //{
    //	return rowList.FindAll(x => x.TypeName == find);
    //}
    //public Row Find_SizeX(string find)
    //{
    //	return rowList.Find(x => x.SizeX == find);
    //}
    //public List<Row> FindAll_SizeX(string find)
    //{
    //	return rowList.FindAll(x => x.SizeX == find);
    //}
    //public Row Find_SizeY(string find)
    //{
    //	return rowList.Find(x => x.SizeY == find);
    //}
    //public List<Row> FindAll_SizeY(string find)
    //{
    //	return rowList.FindAll(x => x.SizeY == find);
    //}

}
