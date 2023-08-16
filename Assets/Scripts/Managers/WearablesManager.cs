using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WearablesManager : Singleton<WearablesManager>
{
    public List<ProductSO> products;
    private Dictionary<string, ProductSO> allProductsDictionary = new Dictionary<string, ProductSO>();
    public Dictionary<string, IWearable> wearablesDictionary = new Dictionary<string, IWearable>();
    public Material[] clothsMaterials;
    public Texture blankTexture;


    private void Awake()
    {
        foreach (var item in products)
        {
            allProductsDictionary.Add(item.iD, item);
        }
    }

    public ProductSO GetProductInfo(string id)
    {
        ProductSO product;
        allProductsDictionary.TryGetValue(id, out product);
        Debug.Log(product.name);
        return product;
    }

    public IWearable GetWearable(string id)
    {
        IWearable wearable;
        wearablesDictionary.TryGetValue(id, out wearable);
        return wearable;
    }

    public void CreateWearable(string id)
    {
        ProductSO productInfo = GetProductInfo(id);
        IWearable wearable = null;
        switch(productInfo.productType)
        {
            case ProductSO.Type.Head:
                wearable = new HeadWearable(productInfo);
                break;
        }
        wearablesDictionary.Add(productInfo.iD,wearable);

    }

    private void OnDisable()
    {
        foreach (var item in clothsMaterials)
        {
            item.SetTexture("_BaseMap", blankTexture);
        }
    }



    public void UseWearable(string id)
    {
        GetWearable(id).Wear(clothsMaterials);
    }
}
