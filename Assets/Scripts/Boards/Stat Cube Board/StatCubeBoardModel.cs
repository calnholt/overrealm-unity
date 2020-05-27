using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatCubeBoardModel : MonoBehaviour
{
    private int attack = 2;
    private int speed = -2;
    private int defense = 0;

    public int Attack { get => attack; set => attack = value; }
    public int Speed { get => speed; set => speed = value; }
    public int Defense { get => defense; set => defense = value; }
}
