using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClothWearable: IWearable
{
    ProductSO productInfo;

    public ClothWearable(ProductSO productInfo)
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
        materials[(int)productInfo.productType].
                    SetTexture("_MainTex", productInfo.productAtlas);
    }

    public void UnEquip(Material[] materials, Texture blank)
    {
        var actualTexture = materials[(int)productInfo.productType].GetTexture("_MainTex");
        if(actualTexture == ProductInfo.productAtlas)
        {
            materials[(int)productInfo.productType].
                  SetTexture("_MainTex", blank);
        }
    }

}
