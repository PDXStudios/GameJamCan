using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{

    [HideInInspector] public Transform parentAfterDrag;
    public Image image;
    [SerializeField] Image switchOFF;
    CanvasGroup canvasGroup;
    private bool isPowered;
    

    public void IsCurrentlyPowered()
    {
        gameObject.GetComponent<BoxCollider2D>();
        Debug.Log(gameObject.GetComponent<BoxCollider2D>());
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        parentAfterDrag = transform.parent;
        transform.SetParent(transform.root);
        transform.SetAsLastSibling();
        image.raycastTarget = false;
        switchOFF.gameObject.SetActive(isPowered);
    }

    public void OnDrag(PointerEventData eventData)
    {
        
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.SetParent(parentAfterDrag);
        image.raycastTarget = true;
        switchOFF.gameObject.SetActive(isPowered);
        
        
    }
}
