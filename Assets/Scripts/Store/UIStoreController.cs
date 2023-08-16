using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIStoreController : MonoBehaviour
{
    [SerializeField] TMP_Text priceText;
    [SerializeField] GameObject productPrefab;
    [SerializeField] Transform productShelf;
    [SerializeField] Button buyButton;

    public Button BuyButton { get => buyButton; set => buyButton = value; }

   
    public void SelectProductUI(IProduct product)
    {
        SetPriceText(product.ProductInfo.productPrice);
    }

    public void SetPriceText(float price)
    {
        priceText.text = price.ToString();
    }
    public GameObject CreateNewProduct()
    {
        GameObject newProduct = Instantiate(productPrefab, productShelf);
        return newProduct;
    }
    public void LaunchPromptToWearNewProduct()
    {
        
    }
}
