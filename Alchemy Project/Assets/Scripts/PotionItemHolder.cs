using UnityEngine.EventSystems;
using UnityEngine;

public class PotionItemHolder : MonoBehaviour, IDropHandler
{
    public int id;
    public GameObject itemDisplay;

    public InventoryData playerInv;

    public MenuInteraction menuScript;

    public SingleItemContainer currentItem;

    public void OnDrop(PointerEventData eventData)
    {
        GameObject droppedPot = eventData.pointerDrag;
        droppedPot.GetComponent<DragItem>().parentAfterDrag = transform;
        int oldID = droppedPot.GetComponent<DragItem>().startParentID;
        playerInv.UpdatePotionList(oldID, id);
        menuScript.LoadMenu();
    }

    void Start()
    {
        playerInv = GameObject.Find("Player").GetComponent<InventoryData>();
        itemDisplay = GetComponentInChildren<Transform>().gameObject;
    }

    private void Update()
    {
        if(currentItem != null)
        {
            //display sprite
            itemDisplay.SetActive(true);
        }
        else
        {
            //itemDisplay.SetActive(false);
        }
    }
}
