using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(UIProductController))]
public class ClothProduct : MonoBehaviour, IProduct, IPointerClickHandler
{
    [SerializeField] ProductSO productInfo;
    [SerializeField] UIProductController UIProductController;

    public Action<IProduct> onSelected;
    public WearablesManager wearablesManager => WearablesManager.Instance;

    public ProductSO ProductInfo { 
        get => productInfo;
    }
    public GameObject canvasObject => this.gameObject;
    public Action<IProduct> OnSelected
    {
        get => onSelected;
        set => onSelected = value;
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        Select();
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

    public void TryProduct()
    {
        wearablesManager.storeClothesMaterials[(int)productInfo.productType].
                    SetTexture("_MainTex", ProductInfo.productAtlas);
    }

  
}
