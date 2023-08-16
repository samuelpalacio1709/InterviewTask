using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IProduct 
{
    public Action<IProduct> OnSelected { get; set; }

    ProductSO ProductInfo { get; }

    public void Select();
    public void Deselect();
    public void FillInfo(ProductSO productInfo);

}
