using UnityEngine;

public class InvenGridScript : MonoBehaviour {
    public GameObject[,] slotGrid;
    public GameObject slotPrefab;
    public IntVector2 gridSize;
    public float slotSize;
    public float edgePadding;
    

    public void Awake()
    {
        
        slotGrid = new GameObject[gridSize.x, gridSize.y];
        ResizePanel();
        CreateSlots();
        GetComponent<InvenGridManager>().gridSize = gridSize;
        transform.GetChild(0).SetAsLastSibling();
    }

    private void CreateSlots()
    {
        for (int y = 0; y < gridSize.y; y++)
        {
            for (int x = 0; x < gridSize.x; x++)
            {
                GameObject obj = (GameObject)Instantiate(slotPrefab);
                
                obj.transform.name = "slot[" + x + "," + y + "]";
                obj.transform.SetParent(this.transform);
                RectTransform rect = obj.transform.GetComponent<RectTransform>();
                rect.localPosition = new Vector3(x * slotSize + edgePadding, y * slotSize + edgePadding, 0);
                rect.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, slotSize);
                rect.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, slotSize);
                obj.GetComponent<RectTransform>().localScale = Vector3.one;
                obj.GetComponent<SlotScript>().gridPos = new IntVector2(x, y);
                slotGrid[x, y] = obj;
            }
        }
        GetComponent<InvenGridManager>().slotGrid = slotGrid;
    }

    private void ResizePanel()
    {
        float width, height;
        width = (gridSize.x * slotSize) + (edgePadding * 2);
        height = (gridSize.y * slotSize) + (edgePadding * 2);

        RectTransform rect = GetComponent<RectTransform>();
        rect.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, width);
        rect.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, height);
        rect.localScale = Vector3.one;
    }
}
