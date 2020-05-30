using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Constants;

public enum BuffCardState
{
    inHand,                     // in hand, not moving
    applied,                    // applied to an aciton, either buff or discard
    draggingOverApply,          // while card is being dragged over possible apply spot
    dragging,                   // being dragged
    fanning,                   // cards moving in hand, shifting positions
    movingToHand,               // either from deck or back to hand
    hoveringInHandMovingUp,   // when hovered over in hand
    hoveringInHandMovingDown,
    hoveringInHandFullyUp           // when stop hovering over in hand, not dragging
}

public class BuffCardModel : CardModel
{
    [SerializeField]
    private string name;
    [SerializeField]
    private Timings timing;
    [SerializeField]
    private bool critFlg;
    [SerializeField]
    private bool flipEventFlg;
    private BuffCardState state = BuffCardState.movingToHand;

    private bool appliedFlg = false;


    public Timings Timing { get => timing; set => timing = value; }
    public bool CritFlg { get => critFlg; set => critFlg = value; }
    public bool FlipEventFlg { get => flipEventFlg; set => flipEventFlg = value; }
    public bool AppliedFlg { get => appliedFlg; set => appliedFlg = value; }
    public BuffCardState State { get => state; set => state = value; }

    private void Update()
    {
        Debug.Log(name + ": " + state);
    }

    public Draggable getDraggable()
    {
        return transform.parent.GetComponentInChildren<Draggable>();
    }

    public bool isDragging()
    {
        return getDraggable().Dragging;
    }

}
