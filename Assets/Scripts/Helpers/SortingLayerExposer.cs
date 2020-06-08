﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class SortingLayerExposer : MonoBehaviour
{
    [SerializeField]
    private string SortingLayerName = "Default";

    [SerializeField]
    private int SortingOrder = 0;

    public void OnValidate()
    {
        apply();
    }

    public void OnEnable()
    {
        apply();
    }

    private void apply()
    {
        var meshRenderer = gameObject.GetComponent<MeshRenderer>();
        meshRenderer.sortingLayerName = SortingLayerName;
        meshRenderer.sortingOrder = SortingOrder;
    }
}