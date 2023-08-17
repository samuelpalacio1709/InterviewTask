using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


[RequireComponent(typeof(UIProductController))]
public class InventoryItem : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] UIProductController productUI;
    public Action<InventoryItem> OnSelected;
    public IWearable wearable;
    
    public void OnPointerClick(PointerEventData eventData)
    {
        OnSelected?.Invoke(this);
    }

    public void FillInfo(IWearable wearable)
    {
        this.wearable = wearable;
        productUI.UpdateUI(wearable.ProductInfo.productIcon);
    }

    public void Select()
    {
        productUI.ShowBorder(true);
    }
    public void Deselect()
    {
        productUI.ShowBorder(false);

    }

}
