using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HotbarController : MonoBehaviour
{
    public int HotbarSlotSize => gameObject.transform.childCount;
    private List<Image> hotbarSlots = new List<Image>();
    private int currentIndex = 0;

    KeyCode[] hotbarKeys = new KeyCode[] {KeyCode.Alpha1, KeyCode.Alpha2, KeyCode.Alpha3};

    private void Start()
    {
        SetUpHotbarSlots();
    }

    private void Update()
    {
        checkForKey();
        return;
    }

    private void checkForKey()
    {

        if (Input.GetKeyDown(hotbarKeys[0]))
        {
            hotbarSlots[0].transform.GetChild(0).GetComponent<Image>().color = Color.yellow;
            hotbarSlots[1].transform.GetChild(1).GetComponent<Image>().color = Color.green;
            hotbarSlots[2].transform.GetChild(2).GetComponent<Image>().color = Color.green;
        }
        if (Input.GetKeyDown(hotbarKeys[1]))
        {
            hotbarSlots[1].transform.GetChild(1).GetComponent<Image>().color = Color.yellow;

            hotbarSlots[0].transform.GetChild(0).GetComponent<Image>().color = Color.green;
            hotbarSlots[2].transform.GetChild(2).GetComponent<Image>().color = Color.green;
        }
        if (Input.GetKeyDown(hotbarKeys[2]))
        {
            hotbarSlots[2].transform.GetChild(2).GetComponent<Image>().color = Color.yellow;
            hotbarSlots[1].transform.GetChild(1).GetComponent<Image>().color = Color.green;
            hotbarSlots[0].transform.GetChild(0).GetComponent<Image>().color = Color.green;
        }
        
    }

    private void SetUpHotbarSlots()
    {
        for(int i = 0; i < HotbarSlotSize; i++)
        {
            Image slot = gameObject.transform.GetComponent<Image>();
            hotbarSlots.Add(slot);
        }
    }
}
