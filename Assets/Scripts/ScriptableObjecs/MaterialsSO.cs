using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MaterialGroup", menuName = "MaterialGroups/Create a material group")]

public class MaterialsSO : ScriptableObject
{
    public Material headMaterial;
    public Material torsoMaterial;
    public Material legsMaterial;
    public Material footMaterial;
}
