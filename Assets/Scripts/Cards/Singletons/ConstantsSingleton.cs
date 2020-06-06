using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Constants;

public class ConstantsSingleton : GenericSingletonClass<ConstantsSingleton>
{
    [Header("Element Colors")]
    [SerializeField]
    private Color fire;
    [SerializeField]
    private Color water;
    [SerializeField]
    private Color rock;
    [SerializeField]
    private Color death;
    [SerializeField]
    private Color electric;
    [SerializeField]
    private Color leaf;

    public Color Fire { get => fire; set => fire = value; }
    public Color Water { get => water; set => water = value; }
    public Color Rock { get => rock; set => rock = value; }
    public Color Death { get => death; set => death = value; }
    public Color Electric { get => electric; set => electric = value; }
    public Color Leaf { get => leaf; set => leaf = value; }

    public Color getColor(Elements element)
    {
        switch (element)
        {
            case Elements.Death:
                return death;
            case Elements.Electric:
                return electric;
            case Elements.Fire:
                return fire;
            case Elements.Leaf:
                return leaf;
            case Elements.Rock:
                return rock;
            case Elements.Water:
                return water;
            default:
                return new Color();
        }
    }
}
