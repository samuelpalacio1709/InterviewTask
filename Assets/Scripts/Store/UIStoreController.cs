using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System;
using UnityEngine.UI;
using Unity.VisualScripting;

public class UIStoreController : MonoBehaviour
{
    [SerializeField] TMP_Text priceText;
    [SerializeField] TMP_Text productNameText;
    [SerializeField] Image productImage;
    [SerializeField] GameObject productPrefab;
    [SerializeField] Transform productShelf;
    [SerializeField] Button buyButton;
    [SerializeField] Button closeButton;
    [SerializeField] string onPurchasedItemText;
    [SerializeField] GameObject storeCanvasObject;
    public Button BuyButton { get => buyButton; set => buyButton = value; }
    private GlobalUIManager globalUIManager => GlobalUIManager.Instance;

    private void OnEnable()
    {
        buyButton.interactable = false;
        closeButton.onClick.AddListener(CloseStoreUI);
    }
    private void OnDisable()
    {
        closeButton.onClick.RemoveListener(CloseStoreUI);

    }
    public void SelectProductUI(IProduct product)
    {
        productImage.sprite = product.ProductInfo.productIcon;
        productNameText.text = product.ProductInfo.productName;
        buyButton.interactable = true;
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

    //Show propmt to ask the user if want to wear the purchased item
    public void LaunchPromptToWearNewProduct(IProduct product)
    {
        string message = onPurchasedItemText.Replace("@product", product.ProductInfo.productName);
        storeCanvasObject.SetActive(false);
        globalUIManager.ShowPrompt(message, product.ProductInfo.productIcon);
    }

    public void CloseStoreUI()
    {
        storeCanvasObject.SetActive(false);
    }
}
