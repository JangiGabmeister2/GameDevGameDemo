using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonHighlight : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject penguin;

    private void OnEnable()
    {
        penguin.SetActive(false);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        penguin.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        penguin.SetActive(false);
    }
}
