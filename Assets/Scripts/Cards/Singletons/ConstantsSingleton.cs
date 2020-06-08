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

    [Header("Stat Colors")]
    [SerializeField]
    private Color positiveStat;
    [SerializeField]
    private Color negativeStat;

    [Header("Hover Punch Settings")]
    [SerializeField]
    private Vector3 hoverPunchVector;
    [SerializeField]
    private float hoverPunchDuration;
    [SerializeField]
    private int hoverPunchVibrato = 10;
    [SerializeField]
    private int hoverPunchElasticity = 1;

    public Color Fire { get => fire; set => fire = value; }
    public Color Water { get => water; set => water = value; }
    public Color Rock { get => rock; set => rock = value; }
    public Color Death { get => death; set => death = value; }
    public Color Electric { get => electric; set => electric = value; }
    public Color Leaf { get => leaf; set => leaf = value; }
    public Color PositiveStat { get => positiveStat; set => positiveStat = value; }
    public Color NegativeStat { get => negativeStat; set => negativeStat = value; }
    public Vector3 HoverPunchVector { get => hoverPunchVector; set => hoverPunchVector = value; }
    public float HoverPunchDuration { get => hoverPunchDuration; set => hoverPunchDuration = value; }
    public int HoverPunchVibrato { get => hoverPunchVibrato; set => hoverPunchVibrato = value; }
    public int HoverPunchElasticity { get => hoverPunchElasticity; set => hoverPunchElasticity = value; }

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
