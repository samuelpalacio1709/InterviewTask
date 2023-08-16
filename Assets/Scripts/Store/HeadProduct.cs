using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HeadProduct : MonoBehaviour, IProduct
{
    public Action<IProduct> onSelected;
    [SerializeField] ProductSO productInfo;
    [SerializeField] Button button;

    public ProductSO ProductInfo { 
        get => productInfo;
        set => productInfo = value; }

    public Action<IProduct> OnSelected
    {
        get => onSelected;
        set => onSelected = value;
    }


    private void OnEnable()
    {
        button.onClick.AddListener(SelectInStore);
    }
    public void Wear()
    {
        throw new System.NotImplementedException();
    }

    public void SelectInStore()
    {
        Debug.Log("Selected");
        OnSelected?.Invoke(this);
    }


    

  
}
