using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IProduct 
{
    public Action<IProduct> OnSelected { get; set; }
    public GameObject canvasObject{ get; }
    ProductSO ProductInfo { get; }

    public void Select();
    public void Deselect();
    public abstract void TryProduct();
    public void FillInfo(ProductSO productInfo);

}
