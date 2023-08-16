using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System;
using UnityEngine.UI;

public class UIStoreController : MonoBehaviour
{
    [SerializeField] TMP_Text priceText;
    [SerializeField] GameObject productPrefab;
    [SerializeField] Transform productShelf;
    [SerializeField] Button buyButton;
    [SerializeField] string onPurchasedItemText;
    [SerializeField] GameObject storeCanvasObject;
    public Button BuyButton { get => buyButton; set => buyButton = value; }
    private GlobalUIManager globalUIManager => GlobalUIManager.Instance;

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

    //Show propmt to encorage user to wear the purchased item
    public void LaunchPromptToWearNewProduct(IProduct product)
    {
        string message = onPurchasedItemText.Replace("@product", product.ProductInfo.productName);
        storeCanvasObject.SetActive(false);
        globalUIManager.ShowPrompt(message, product.ProductInfo.productIcon);
    }
}
