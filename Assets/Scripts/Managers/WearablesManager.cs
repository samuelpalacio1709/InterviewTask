using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WearablesManager : Singleton<WearablesManager>
{
    public List<ProductSO> products;
    private Dictionary<string, ProductSO> allProductsDictionary = new Dictionary<string, ProductSO>();
    public Dictionary<string, IWearable> wearablesDictionary = new Dictionary<string, IWearable>();
    public Material[] characterClothesMaterials;
    public Material[] storeClothesMaterials;
    public Texture blankTexture;
    private string textureName = "_MainTex";

    private void Awake()
    {
        Init();
    }
    private void Init()
    {
        foreach (var item in products)
        {
            allProductsDictionary.Add(item.iD, item);
        }
        ResetMaterials();
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
        IWearable wearable = new ClothWearable(productInfo);
        wearablesDictionary.Add(productInfo.iD,wearable);

    }

    private void ResetMaterials()
    {
        foreach (var item in characterClothesMaterials)
        {
            item.SetTexture(textureName, blankTexture);
        }
        foreach (var item in storeClothesMaterials)
        {
            item.SetTexture(textureName, blankTexture);
        }
    }

    public void MatchClothes()
    {
        for (int i = 0; i < storeClothesMaterials.Length; i++)
        {
            var characterMainTexture = characterClothesMaterials[i].
                                            GetTexture(textureName);

            storeClothesMaterials[i].SetTexture(textureName, characterMainTexture);

        }
    }

    private void OnApplicationQuit()
    {
        ResetMaterials();
    }

    public void UseWearable(string id)
    {
        GetWearable(id).Wear(characterClothesMaterials);
    }
}
