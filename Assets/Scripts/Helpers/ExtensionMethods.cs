using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public static class ExtensionMethods
{
    public static void HoverPunch(this Transform t)
    {
        ConstantsSingleton s = GameObjectHelper.getConstantsSingleton();
        t.DOPunchScale(s.HoverPunchVector, s.HoverPunchDuration, s.HoverPunchVibrato, s.HoverPunchElasticity);
    }

    public static bool IsTransformScaleDefault(this Transform t)
    {
        return t.localScale.x == 1 && t.localScale.y == 1;
    }
}
