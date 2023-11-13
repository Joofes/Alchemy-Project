using UnityEngine;

[CreateAssetMenu(fileName = "New Recipe", menuName = "Recipes/Recipe")]
public class Recipe : ScriptableObject
{
    public Item itemOne;
    public Item itemTwo;

    public Item outputItem;
}
