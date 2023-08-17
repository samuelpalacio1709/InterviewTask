using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadProduct : ClothProduct
{
    public override void TryProduct()
    {
        Debug.Log("Try");

        ProductInfo.materialGroup.headMaterial.
                    SetTexture("_MainTex", ProductInfo.productAtlas);
    }

}
