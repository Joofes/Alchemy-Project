using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "Recipe Database", menuName = "Recipes/Recipe Database")]
public class RecipeDatabase : ScriptableObject
{
    public List<Recipe> recipes = new List<Recipe>();
}