using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardModel : MonoBehaviour
{
    protected bool isHovering = false;
    protected bool isSelected = false;

    public bool IsSelected { get => isSelected; set => isSelected = value; }
    public bool IsHovering { get => isHovering; set => isHovering = value; }

}
