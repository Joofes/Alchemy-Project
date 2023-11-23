using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionFire : MonoBehaviour
{
    Vector2 mouseDir;

    InventoryData inv;

    [SerializeField]
    float fireForce = 50.0f;


    public Potion equippedPot;
    public GameObject firePot;

    public GameObject menu;

    void Start()
    {
        inv = GetComponent<InventoryData>();
        equippedPot = inv.potions[0];       
    }

    // Update is called once per frame
    void Update()
    {
        MouseDirCalc();
        if (Input.GetMouseButtonDown(0) && inv.potions.Count > 0 && !menu.activeInHierarchy) // check if menu is open, don't fire if it is
        {
            
            GameObject pot = Instantiate(equippedPot.potionPrefab);
            inv.RemoveItem(equippedPot);
            pot.transform.position = transform.position;
            pot.GetComponent<Rigidbody2D>().AddForce(mouseDir * fireForce);
            if(inv.potions.Count > 0) //check if next potion exists after removing a potion
                equippedPot = inv.potions[0];
        }
    }

    void MouseDirCalc()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        mouseDir = (mousePosition - (Vector2)transform.position).normalized;
    }
}
