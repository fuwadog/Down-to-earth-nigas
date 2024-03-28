using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PlayerJoyStick : MonoBehaviour,IPointerDownHandler,IPointerUpHandler,IDragHandler
{

    private Image treshold;
    private Image touch;

    public Vector2 inputDir;

    
    public void OnDrag(PointerEventData eventData)
    {
        Vector2 position = Vector2.zero;

        if(RectTransformUtility.ScreenPointToLocalPointInRectangle(treshold.rectTransform,
            eventData.position,eventData.pressEventCamera,out position))
            {
                position.x = (position.x / treshold.rectTransform.sizeDelta.x);
                position.y = (position.y / treshold.rectTransform.sizeDelta.y);

                float x = (treshold.rectTransform.pivot.x == 1f) ? position.x * 2 + 1 : position.x * 2-1;
                float y = (treshold.rectTransform.pivot.y == 1f) ? position.y * 2 + 1 : position.y * 2-1;

                inputDir= new Vector3(x,y,0);
                inputDir = (inputDir.magnitude > 1) ? inputDir.normalized : inputDir;

                touch.rectTransform.anchoredPosition =  new Vector3(inputDir.x * (treshold.rectTransform.sizeDelta.x /2.5f),
                                                                    inputDir.y * (treshold.rectTransform.sizeDelta.y /2.5f));
                
            }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        OnDrag(eventData);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        inputDir = Vector3.zero;
        touch.rectTransform.anchoredPosition = Vector3.zero;
    }

    
    void Start()
    {
        treshold = GetComponent<Image>();
        touch = transform.GetChild(0).GetComponent<Image>();
        inputDir= Vector3.zero;
    }
}
