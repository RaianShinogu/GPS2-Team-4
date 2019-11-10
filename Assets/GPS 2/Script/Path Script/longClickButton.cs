using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;
using UnityEngine.Events;

public class longClickButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    bool pointerDown;
    float pointerDownTimer;

    [SerializeField] private float holdTimeToActivate =0f;

    public UnityEvent onLongClick;

    [SerializeField] private Image fillImage;



    // Update is called once per frame
    void Update()
    {
        pointActive();
    }

    private void pointActive()
    {
      if(pointerDown)
        {
            pointerDownTimer += Time.deltaTime;
            if(pointerDownTimer >= holdTimeToActivate)
            {
                if (onLongClick != null)
                    onLongClick.Invoke();

                Reset();
            }
            fillImage.fillAmount = pointerDownTimer / holdTimeToActivate;
                  
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        pointerDown = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Reset();
    }

    private void Reset()
    {
        pointerDown = false;
        pointerDownTimer = 0;
        fillImage.fillAmount = pointerDownTimer / holdTimeToActivate;
    }

  
}
