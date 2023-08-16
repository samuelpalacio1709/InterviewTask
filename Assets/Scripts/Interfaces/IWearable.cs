using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IWearable
{
    ProductSO ProductInfo { get; set; }
    public void Wear(Material[] materials);
}
