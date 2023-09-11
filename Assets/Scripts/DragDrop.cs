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

    public void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.name == "ButtonBg")
        {

            switchOFF.gameObject.SetActive(true);
            
        }
        /*
        else
        {
            switchOFF.gameObject.SetActive(false);
        }
        */
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
        gameObject.GetComponent<BoxCollider2D>().enabled = false;

    }

    public void OnDrag(PointerEventData eventData)
    {
        
        transform.position = Input.mousePosition;
        
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.SetParent(parentAfterDrag);
        image.raycastTarget = true;
        //switchOFF.gameObject.SetActive(true);
        gameObject.GetComponent<BoxCollider2D>().enabled = true;


    }
}
