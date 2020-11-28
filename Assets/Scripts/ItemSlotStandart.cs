using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class ItemSlotStandart : MonoBehaviour
{
    public RectTransform image;

    private void Awake()
    {
        image = GetComponent<RectTransform>();
    }

    public Vector2 PositionStandart()
    {
        return image.anchoredPosition;
    }


}
