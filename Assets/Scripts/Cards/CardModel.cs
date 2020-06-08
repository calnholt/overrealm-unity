using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardModel : MonoBehaviour
{
    protected bool isHovering = false;
    protected bool isSelected = false;
    protected bool isHoveringApplied = false;
    protected bool isManeuver = false;

    public bool IsSelected { get => isSelected; set => isSelected = value; }
    public bool IsHovering { get => isHovering; set => isHovering = value; }
    public bool IsHoveringApplied { get => isHoveringApplied; set => isHoveringApplied = value; }
    public bool IsManeuver { get => isManeuver; set => isManeuver = value; }
}
