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
    Rigidbody2D _rb;


    void Start()
    {
        _rb = gameObject.GetComponent<Rigidbody2D>();
    }    

    public void OnCollisionEnter2D(Collision2D collision)
    {
        switchOFF.gameObject.SetActive(true);
        isPowered = true;
        Debug.Log(isPowered);
       
    }


    public void OnCollisionExit2D(Collision2D collision)
    {

        switchOFF.gameObject.SetActive(false);

    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        parentAfterDrag = transform.parent;
        transform.SetParent(transform.root);
        transform.SetAsLastSibling();
        image.raycastTarget = false;
        //switchOFF.gameObject.SetActive(isPowered);
    }

    public void OnDrag(PointerEventData eventData)
    {
        
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.SetParent(parentAfterDrag);
        image.raycastTarget = true;
        //switchOFF.gameObject.SetActive(isPowered);
        
        
    }
}
