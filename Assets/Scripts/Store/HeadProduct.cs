using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(UIProductController))]
public class HeadProduct : MonoBehaviour, IProduct
{
    public Action<IProduct> onSelected;
    [SerializeField] ProductSO productInfo;
    [SerializeField] Button button;
    [SerializeField] UIProductController UIProductController;
    public ProductSO ProductInfo { 
        get => productInfo;
    }

    public Action<IProduct> OnSelected
    {
        get => onSelected;
        set => onSelected = value;
    }


    private void OnEnable()
    {
        button.onClick.AddListener(Select);
    }
    public void Wear()
    {
        throw new System.NotImplementedException();
    }

    public void Select()
    {
        Debug.Log("Selected");
        OnSelected?.Invoke(this);
        UIProductController.ShowBorder(true);
    }
    public void Deselect()
    {
        Debug.Log("Deselected");
        UIProductController.ShowBorder(false);

    }

    public void FillInfo(ProductSO productInfo)
    {
        this.productInfo=productInfo;
        UIProductController.UpdateUI(productInfo.productIcon);

    }





}
