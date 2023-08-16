using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(UIStoreController))]
public class StoreController : MonoBehaviour
{
    [SerializeField] UIStoreController UIStore;
    [SerializeField] ProductSO[] AllProductsInfo;

    private PurchaseManager purchaseManager => PurchaseManager.Instance;
    private List<IProduct> products = new List<IProduct>();
    private IProduct selectedProduct;
    private void Start()
    {
        OpenStore();
    }
    public void BuyProduct()
    {
        purchaseManager.CreatePurchase(selectedProduct.ProductInfo);
        UIStore.LaunchPromptToWearNewProduct();
    }
    public void SelectProduct(ProductSO product)
    {
        UIStore.SetPriceText(product.productPrice);
    }

    public void OpenStore()
    {
        CreateProducts();
        if(products.Count > 0)
        {
            SelectProduct(products[0]); //Always select the first product from the list
            UIStore.BuyButton.onClick.AddListener(BuyProduct);
        }
       
    }
  
    public void CreateProducts()
    {
        foreach (var productInfo in AllProductsInfo)
        {
            GameObject newProduct = UIStore.CreateNewProduct();
            IProduct productCreated;
            newProduct.TryGetComponent<IProduct>(out productCreated);

            if (newProduct == null) continue;

            AddProductInfo(productCreated, productInfo);
            SubscribeToProductEvents(productCreated);
            products.Add(productCreated);
        }

    }

    private void  AddProductInfo(IProduct productCreated, ProductSO productInfo)
    {
        productCreated.ProductInfo = productInfo;
    }

    private void SubscribeToProductEvents(IProduct product)
    {
        product.OnSelected += SelectProduct;
    }

    private void SelectProduct(IProduct product)
    {
        selectedProduct = product;
        UIStore.SelectProductUI(product);
    }

}


