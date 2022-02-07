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
            //move object with cursor
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
            
            //set crafting to true since we placed an item on the slot
            eventData.pointerDrag.GetComponent<DragItem>().isCrafting = true;

            //Add item to list
            ItemInfoScriptableObject tempItem = eventData.pointerDrag.GetComponent<DragItem>().item;
            craftTable.AddItem(tempItem);

            //Debug.Log(eventData.pointerDrag.gameObject.name);
        }
    }
}
