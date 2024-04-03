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
    private Vector2 rotDir;

    
    public void OnDrag(PointerEventData eventData)
    {
        Vector2 position = Vector2.zero;
        

        if(RectTransformUtility.ScreenPointToLocalPointInRectangle(treshold.rectTransform,
            eventData.position,eventData.pressEventCamera,out position))
            {
            
     
            float normalizedX = position.x / (treshold.rectTransform.sizeDelta.x * 0.5f);
            float normalizedY = position.y / (treshold.rectTransform.sizeDelta.y * 0.5f);

            
            normalizedX = Mathf.Clamp(normalizedX, -1f, 1f);
            normalizedY = Mathf.Clamp(normalizedY, -1f, 1f);

            
            inputDir = new Vector2(normalizedX, normalizedY);

            
            touch.rectTransform.anchoredPosition = new Vector3(inputDir.x * (treshold.rectTransform.sizeDelta.x / 2.5f),
                                                                inputDir.y * (treshold.rectTransform.sizeDelta.y / 2.5f));

            rotDir = new Vector2(inputDir.x, inputDir.y);
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        OnDrag(eventData);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        inputDir = Vector2.zero;
        touch.rectTransform.anchoredPosition = Vector2.zero;
    }

    
    void Start()
    {
        treshold = GetComponent<Image>();
        touch = transform.GetChild(0).GetComponent<Image>();
        inputDir = Vector2.zero;
    }

    public Vector2 GetMove()
    {
        return inputDir;
    }

    public Vector2 GetRotation()
    {
        return rotDir;
    }
}
