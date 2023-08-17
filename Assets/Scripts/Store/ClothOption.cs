using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ClothOption : MonoBehaviour, IStoreOption , IPointerClickHandler
{
    public Image clothImage;
    public Action<IStoreOption> onSelected;
    public ProductSO.Type type;

    public Action<IStoreOption> OnSelected 
    { 
        get => onSelected;
        set => onSelected=value;
    
    }
    public ProductSO.Type Type { get => type; set => type=value; }

    public void OnPointerClick(PointerEventData eventData)
    {
        OnSelected?.Invoke(this);
    }

    public void Select()
    {
        clothImage.color = Color.gray;
    }

    public void Deselect()
    {
        clothImage.color = Color.white;

    }

}
