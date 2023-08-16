using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Product", menuName = "Products/Create a new product")]
public class ProductSO : ScriptableObject
{
    public string iD;
    public string productName;
    public float productPrice;
    public Sprite productIcon;
    public Texture productAtlas;
    public Type productType;
    public enum Type
    {
        Head,
        Chest,
        Legs,
        Foot
    }
}
