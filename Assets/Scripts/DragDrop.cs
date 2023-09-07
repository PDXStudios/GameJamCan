using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{ 

    Vector3 offset;
    CanvasGroup canvasGroup;
    string destinationTag = "DropArea";

    void Awake()
    {
        if (gameObject.GetComponent<CanvasGroup>() == null)
            gameObject.GetComponent<CanvasGroup>();
        canvasGroup = gameObject.GetComponent<CanvasGroup>();
    }


    public void OnDrag(PointerEventData eventData)
    {

        transform.position = Input.mousePosition + offset;

    }
    
    

    public void OnPointerDown(PointerEventData eventData)
    {

        offset = transform.position - Input.mousePosition;
        canvasGroup.alpha = 0.5f;
        canvasGroup.blocksRaycasts = false;

    }

    public void OnPointerUp(PointerEventData eventData)
    {

        RaycastResult raycastResult = eventData.pointerCurrentRaycast;
        if(raycastResult.gameObject?.tag == destinationTag)
        {
            transform.position = raycastResult.gameObject.transform.position;
        }
        canvasGroup.alpha = 1;
        canvasGroup.blocksRaycasts = true;
    }


}
