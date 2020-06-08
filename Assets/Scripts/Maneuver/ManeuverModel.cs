using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManeuverModel : MonoBehaviour
{
    private int numberRemaining = 3;
    private bool isApplied = false;

    public int NumberRemaining { get => numberRemaining; set => numberRemaining = value; }
    public bool IsApplied { get => isApplied; set => isApplied = value; }

    public void apply()
    {
        if (numberRemaining == 0) return;
        numberRemaining--;
        isApplied = true;
    }

    public void unapply()
    {
        numberRemaining++;
        isApplied = false;
    }
}
