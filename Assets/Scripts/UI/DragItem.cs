using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragItem : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler, IDropHandler//, IPointerDownHandler
{
    [SerializeField] 
    private Canvas canvas;
    private CanvasGroup canvasGroup;

    private Image image;

    //private ItemInfoScriptableObject itemInfo;
    public ItemInfoScriptableObject item;

    private RectTransform rect;

    public bool isCrafting;

    private void Awake()
    {
        image = GetComponent<Image>();
        image.color = item.itemColor;
        
        rect = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();

        isCrafting = false;
    }

    //IBeginDragHandler, start to drag something
    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = .6f;
        canvasGroup.blocksRaycasts = false;
    }

    //IDragHandler, drag an object
    public void OnDrag(PointerEventData eventData)
    {
        //transform.position = eventData.position;
        rect.anchoredPosition += eventData.delta / canvas.scaleFactor;

        //if we are crafting then remove item
        if(isCrafting)
        {
            isCrafting = !isCrafting;
            UICraft.Instance.RemoveItem(item);
        }
    }

    //IEndDragHandler, stop dragging something
    public void OnEndDrag(PointerEventData eventData)
    {
        //image.color = Color.white;
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;
    }

    //IDropHandler, gets called when a draggable object gets dropped in this object
    public void OnDrop(PointerEventData eventData)
    {
        
    }

    //IPointerDownHandler, when you click and hold on the object
    //public void OnPointerDown(PointerEventData eventData)
    //{
    //    Debug.Log("On Pointer Down");
    //}
}
