using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Purchase
{
    
    public ProductSO productInfo;
    public Purchase(ProductSO productInfo)
    {
        this.productInfo = productInfo;
    }
}