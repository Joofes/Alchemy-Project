using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;

public class DragItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public int startParentID;

    public Transform parentAfterDrag;
    public void OnBeginDrag(PointerEventData eventData)
    {
        startParentID = transform.parent.GetComponent<PotionItemHolder>().id;
        parentAfterDrag = transform.parent;
        transform.SetParent(transform.root);
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
        
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.SetParent(parentAfterDrag);
    }
}
