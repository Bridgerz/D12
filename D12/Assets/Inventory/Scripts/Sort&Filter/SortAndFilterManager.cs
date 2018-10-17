using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class SortAndFilterManager : MonoBehaviour {

    public ItemListManager listManager;
    private List<ItemDm> itemList;

    public List<GameObject> categoryButtons;
    private GameObject selectedCatButton;
    public int catFilterInt = 0;

    public Image qualityButtonImage;
    public Text qualityButtonText;

    private List<ItemDm> filteredList;
    public List<ItemDm> sortedList;
    private int sortTypeInt = 0;

    public GameObject ToolTip;

    private void Start()
    {
        selectedCatButton = categoryButtons[0];
        sortedList = SortList(listManager.startItemList);
        listManager.currentItemList = sortedList;
        listManager.PopulateList(sortedList);
        filteredList = sortedList;
        ToolTip.SetActive(false);
    }

    #region filter list
    private void FilterList(List<ItemDm> list)
    {
        filteredList = list;
        listManager.PopulateList(filteredList);
    }

    //used on classfilter buttons
    private void ClassFilterChange(int type)
    {
        if (selectedCatButton != categoryButtons[type])
        {
            catFilterInt = type;
            categoryButtons[type].GetComponent<CanvasGroup>().alpha = 1f;
            selectedCatButton.GetComponent<CanvasGroup>().alpha = 0.5f;
            selectedCatButton = categoryButtons[type];
            FilterList(sortedList);
        }
    }

    ////used on quality filter button
    //private void QualityButtonClick()
    //{
    //    switch (qualityFilterInt)
    //    {
    //        case 0: qualityFilterInt = 1; qualityButtonText.text = "Normal+"; break;
    //        case 1: qualityFilterInt = 2; qualityButtonText.text = "Magic+"; break;
    //        case 2: qualityFilterInt = 3; qualityButtonText.text = "Rare"; break;
    //        case 3: qualityFilterInt = 0; qualityButtonText.text = "All"; break;
    //        default:break;
    //    }
    //    switch (qualityFilterInt)
    //    {
    //        case 0: qualityButtonImage.color = Color.gray; break;
    //        case 1: qualityButtonImage.color = Color.white; break;
    //        case 2: qualityButtonImage.color = new Color(0.5f, 0.5f, 1f, 1f); break;
    //        case 3: qualityButtonImage.color = Color.yellow; break;
    //        default:break;
    //    }
    //    FilterList(sortedList);
    //}
    #endregion
    #region sortlist
    public void OnSortTypeChange(int index)//used on sortType dropdown
    {
        sortTypeInt = index;
        sortedList = SortList(listManager.currentItemList);
        listManager.currentItemList = sortedList;
        filteredList = SortList(filteredList);
        listManager.PopulateList(filteredList);
    }
    public List<ItemDm> SortList(List<ItemDm> list)
    {
        switch (sortTypeInt)
        {
            case 0: return list.OrderBy(x => x.GlobalID).ToList();
            case 1: return list.OrderByDescending(x => x.GlobalID).ToList();
            case 2: return list.OrderBy(x => x.Quality).ToList();
            case 3: return list.OrderByDescending(x => x.Quality).ToList();
            default: return list;
        }
    }
#endregion
    public void AddItemToList(ItemDm item)
    {
        listManager.currentItemList.Add(item);
        SortAndFilterList();
    }
    //add function add list to currentlist
    public void SortAndFilterList()//rework to use findindex then inset
    {
        sortedList = SortList(listManager.currentItemList);
        listManager.currentItemList = sortedList;
        FilterList(sortedList);
        listManager.PopulateList(filteredList);
    }
}
