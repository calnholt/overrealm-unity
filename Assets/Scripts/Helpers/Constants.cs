﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Constants
{
    public static class GameObjectStructure
    {
        public const int MODEL = 0;
        public const int VIEW = 1;
        public const int CONTROLLER = 2;
    }
    public enum Elements
    {
        Fire, Water, Rock, Leaf, Electric, Death
    }
    public enum Roles
    {
        Assassin, Tank, Warrior, Support, Tricky, Technical
    }
    public enum Timings
    {
        PreActions, WithAttack, PostActions
    }
}
