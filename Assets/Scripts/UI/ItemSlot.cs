using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour, IDropHandler
{
    private UICraft craftTable;

    private void Start()
    {
        craftTable = GetComponentInParent<UICraft>();
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null && craftTable.table.Count < 5)
        {
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;

            //Add item to list
            craftTable.AddItem(eventData.pointerDrag.gameObject);

            //Debug.Log(eventData.pointerDrag.gameObject.name);
        }
    }
}
