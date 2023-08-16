using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IProduct 
{
    public Action<IProduct> OnSelected { get; set; }

    ProductSO ProductInfo { get; set; }
    public void Wear();

}
