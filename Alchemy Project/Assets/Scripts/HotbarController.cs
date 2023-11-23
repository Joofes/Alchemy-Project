using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HotbarController : MonoBehaviour
{
    public int HotbarSlotSize => gameObject.transform.childCount;
    private List<Image> hotbarSlots = new List<Image>();

    KeyCode[] hotbarKeys = new KeyCode[] {KeyCode.Alpha1, KeyCode.Alpha2, KeyCode.Alpha3 };

    private void Start()
    {
        SetUpHotbarSlots();
    }

    private void Update()
    {
        for (int i = 0; i < hotbarKeys.Length; i++)
        {
            if (Input.GetKeyDown(hotbarKeys[i]))
            {
                Debug.Log("Use item: " + i);
                return;
            }
        }
    }

    private void SetUpHotbarSlots()
    {
        for(int i = 0; i < HotbarSlotSize; i++)
        {
            Image slot = gameObject.GetComponentInChildren<Image>();
            hotbarSlots.Add(slot);
        }
    }
}
