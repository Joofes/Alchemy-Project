using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Items/Item")]
public class Item : ScriptableObject
{
    public string itemName;
    public Sprite itemIcon;
    public int quantity;
    public string description;
}
[CreateAssetMenu(fileName = "New Ingredient", menuName = "Items/Ingredient")]
public class Ingredient : Item
{}
[CreateAssetMenu(fileName = "New Item", menuName = "Items/Potion")]
public class Potion : Item
{
    public GameObject potionPrefab;
}