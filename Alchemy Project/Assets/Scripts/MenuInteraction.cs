using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MenuInteraction : MonoBehaviour
{
    public KeyCode menuKey;

    public GameObject menuObject;

    Slots selectedSlot;
    public Item slotOneItem;
    public Item slotTwoItem;

    public InventoryData inv;

    //Ingredient Menu
    public Button[] igInvButtons;
    public GameObject igInvButtonHolder;

    public Transform[] potInvItems;
    public GameObject potGridContent;

    public Button baseButton; //ingredient handler
    public GameObject potItemHolder; //pot handler to allow rearrangement

    void Start()
    {
        igInvButtons = igInvButtonHolder.GetComponentsInChildren<Button>();
    }
    public enum Slots
    {
        One, 
        Two
    }

    
    public void SelectItem(SingleItemContainer itemContainer)
    {
        if (selectedSlot == Slots.One)
            slotOneItem = itemContainer.item;
        if (selectedSlot == Slots.Two)
            slotTwoItem = itemContainer.item;
    }
    public void SelectSlot(int slotNum)
    {
        if (slotNum == 1)
            selectedSlot = Slots.One;
        if (slotNum == 2)
            selectedSlot = Slots.Two;

    }
    public void CraftButton()
    {
        if (slotOneItem != null && slotTwoItem != null)
            inv.Craft(slotOneItem, slotTwoItem);
        LoadMenu();
    }

    public void LoadMenu() //Destroys and regenerates buttons, aligns to all items via for loop
    {
        //these lines are for cleanup and do not reappear in potion loading to save resources
        slotOneItem = null;
        slotTwoItem = null;
        inv.Trim(); //also updates item list
        #region Ingredient Loading
        igInvButtons = igInvButtonHolder.GetComponentsInChildren<Button>();
        for (int i = 0; i < igInvButtons.Length; i++)
        {
            DestroyImmediate(igInvButtons[i].gameObject);
        }   
        
        igInvButtons = igInvButtonHolder.GetComponentsInChildren<Button>();
        while (igInvButtons.Length < inv.ingredients.Count)
        {
            Instantiate(baseButton, igInvButtonHolder.transform);
            igInvButtons = igInvButtonHolder.GetComponentsInChildren<Button>();
        }
        for (int i = 0; i < inv.ingredients.Count; i++)
        {
            igInvButtons[i].name = inv.ingredients[i].itemName;
            igInvButtons[i].GetComponentInChildren<TextMeshProUGUI>().text = inv.ingredients[i].itemName;
            igInvButtons[i].GetComponent<SingleItemContainer>().item = inv.ingredients[i];
        }
        #endregion
        #region Potion Loading
        /*
        PotionItemHolder[] potInvItems = potGridContent.GetComponentsInChildren<PotionItemHolder>(); 
        for (int i = 0; i < potInvItems.Length; i++) // -1 to counter act +1 cuz of shitty scripting
        {
            DestroyImmediate(potInvItems[i].gameObject); // +1 so it does not destroy parent
        }
        potInvItems = potGridContent.GetComponentsInChildren<PotionItemHolder>();
        while (potInvItems.Length < inv.potions.Count)
        {
            Instantiate(potItemHolder, potGridContent.transform);
            potInvItems = potGridContent.GetComponentsInChildren<PotionItemHolder>();
        }
        for (int i = 0; i < inv.potions.Count; i++)
        {
            potInvItems[i].gameObject.name = inv.potions[i].itemName;
            potInvItems[i].gameObject.GetComponentInChildren<SingleItemContainer>().item = inv.potions[i];
            potInvItems[i].gameObject.GetComponent<PotionItemHolder>().id = i;
        }*/
        #endregion
    }
   
    void Update()
    {
        if(Input.GetKeyDown(menuKey))
        {
            OpenMenu();
        }
        if (Input.GetKeyUp(menuKey))
        {
            CloseMenu();
        }
        if(!Input.GetKey(menuKey))
        {
            CloseMenu();
        }
    }

    void OpenMenu()
    {
        LoadMenu();
        menuObject.SetActive(true);
    }
    void CloseMenu()
    {
        menuObject.SetActive(false);
    }
}
