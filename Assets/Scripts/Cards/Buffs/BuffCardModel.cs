using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Constants;

public class BuffCardModel : MonoBehaviour
{
    [SerializeField]
    private Timings timing;
    [SerializeField]
    private bool critFlg;
    [SerializeField]
    private bool flipEventFlg;

    public Timings Timing { get => timing; set => timing = value; }
    public bool CritFlg { get => critFlg; set => critFlg = value; }
    public bool FlipEventFlg { get => flipEventFlg; set => flipEventFlg = value; }
}
