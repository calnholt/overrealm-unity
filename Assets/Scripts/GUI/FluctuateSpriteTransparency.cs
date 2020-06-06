using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FluctuateSpriteTransparency : MonoBehaviour
{
    private SpriteRenderer sr;
    [SerializeField]
    private float min;
    [SerializeField]
    private float max;
    [SerializeField]
    private float increment;
    private bool isFluctuatingUp = false;
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, (min + max) / 2);

    }

    void Update()
    {
        updateFluctuateFlg();
        fluctuateTransparency();
    }

    void fluctuateTransparency()
    {
        if (isFluctuatingUp)
        {
            sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, sr.color.a + increment);
        }
        else
        {
            sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, sr.color.a - increment);
        }
    }

    void updateFluctuateFlg()
    {
        float a = sr.color.a;
        if (isFluctuatingUp && a > max)
        {
            isFluctuatingUp = !isFluctuatingUp;
        }
        else if (!isFluctuatingUp && a < min)
        {
            isFluctuatingUp = !isFluctuatingUp;
        }
    }
}
