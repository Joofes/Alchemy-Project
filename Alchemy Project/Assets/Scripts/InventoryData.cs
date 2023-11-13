using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InventoryData : MonoBehaviour
{
    public List<Item> allItems = new List<Item>();

    public List<Potion> potions = new List<Potion>();
    public List<Ingredient> ingredients = new List<Ingredient>();

    public RecipeDatabase database;

    private void Start()
    {
        Trim(); //recombine items
    }
    void AddItem(Item item)
    {
        if (item is Potion)
            potions.Add((Potion)item);
        if (item is Ingredient)
            ingredients.Add((Ingredient)item);
        //recombines all items
        allItems = new List<Item>(potions);
        allItems.AddRange(ingredients);
    }
    public void RemoveItem(Item item)
    {
        if (item is Potion)
            potions.Remove((Potion)item);
        if (item is Ingredient)
            ingredients.Remove((Ingredient)item);
        //recombines all items
        allItems = new List<Item>(potions);
        allItems.AddRange(ingredients);
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            Trim();
        }
    }
    public void Trim() //cleans up lists and recombines allitems
    {
        potions.RemoveAll(item => item == null);
        ingredients.RemoveAll(item => item == null);
        allItems = new List<Item>(potions);
        allItems.AddRange(ingredients);
    }
    public void UpdatePotionList(int idOld, int idNew)
    {
        Potion oldItem = potions[idOld];
        Potion newItem = potions[idNew];

        potions[idOld] = newItem;
        potions[idNew] = oldItem;
        Trim();
    }
    public void Craft(Item itemOne, Item itemTwo)
    {
        foreach(Recipe recipe in database.recipes)
        {
            if (recipe.itemOne == itemOne && recipe.itemTwo == itemTwo)
            {
                AddItem(recipe.outputItem);
                RemoveItem(itemOne);
                RemoveItem(itemTwo);
            }
            else if (recipe.itemOne == itemTwo && recipe.itemTwo == itemOne) //works recipes backwards
            {
                AddItem(recipe.outputItem);
                RemoveItem(itemOne);
                RemoveItem(itemTwo);
            }
        }
    }
}

