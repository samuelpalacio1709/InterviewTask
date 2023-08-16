using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadWearable: IWearable
{
    ProductSO productInfo;

    public HeadWearable(ProductSO productInfo)
    {
        ProductInfo = productInfo;
    }

    public ProductSO ProductInfo
    {
        get
        {
            return productInfo;
        }
        set
        {
            productInfo = value;
        }
    }

    public void Wear(Material[]  materials)
    {
        materials[0].SetTexture("_BaseMap", productInfo.productAtlas);
    }

}
