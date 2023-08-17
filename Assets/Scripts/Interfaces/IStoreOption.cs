using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public interface IStoreOption
{
    Action<IStoreOption> OnSelected { get; set; }
    ProductSO.Type Type { get; set; }
    public void Select();
    public void Deselect();

}
