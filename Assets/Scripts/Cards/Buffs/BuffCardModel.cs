using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Constants;

public enum BuffCardState
{
    inHand,                     // in hand, not moving
    appliedAsBuff,              // applied to an aciton as a buff
    appliedAsDiscard,           // applied to an aciton as a discard
    appliedAsSwitchLeft,
    appliedAsSwitchRight,
    appliedAsDrawThree,
    appliedAsCounter,
    draggingOverDrawThreeApply,
    draggingOverDiscardApply,   // while card is being dragged over possible discard spot
    draggingOverBuffApply,      // while card is being dragged over possible buff spot
    draggingOverSwitchLeftApply,
    draggingOverSwitchRightApply,
    dragging,                   // being dragged
    fanning,                    // cards moving in hand, shifting positions
    movingToHand,               // either from deck or back to hand
    hoveringInHandMovingUp,     // when hovered over in hand, tweening up
    hoveringInHandMovingDown,   // when stop hovering in hand, tweening down
    hoveringInHandFullyUp,      // when stop hovering over in hand, not dragging
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
    public BuffCardState state = BuffCardState.movingToHand;
    private bool hoveringOverApplied = false;

    public Timings Timing { get => timing; set => timing = value; }
    public bool CritFlg { get => critFlg; set => critFlg = value; }
    public bool FlipEventFlg { get => flipEventFlg; set => flipEventFlg = value; }
    public BuffCardState State { get => state; set => state = value; }
    public bool HoveringOverApplied { get => hoveringOverApplied; set => hoveringOverApplied = value; }

    private void Update()
    {
    }

    public Draggable getDraggable()
    {
        return transform.parent.GetComponentInChildren<Draggable>();
    }

    public bool isDragging()
    {
        return getDraggable().Dragging;
    }

    public bool isApplied()
    {
        return state == BuffCardState.appliedAsBuff
            || state == BuffCardState.appliedAsDiscard
            || state == BuffCardState.appliedAsCounter
            || state == BuffCardState.appliedAsDrawThree
            || state == BuffCardState.appliedAsSwitchLeft
            || state == BuffCardState.appliedAsSwitchRight;
    }

    public bool isDraggingOverApplied()
    {
        return state == BuffCardState.draggingOverBuffApply
            || state == BuffCardState.draggingOverDiscardApply
            || state == BuffCardState.draggingOverSwitchLeftApply
            || state == BuffCardState.draggingOverSwitchRightApply
            || state == BuffCardState.draggingOverDrawThreeApply;
    }

    public bool isDraggable()
    {
        return (state == BuffCardState.inHand ||
            state == BuffCardState.hoveringInHandFullyUp ||
            state == BuffCardState.hoveringInHandMovingDown ||
            state == BuffCardState.hoveringInHandMovingUp);
    }

    public bool isHandHovering()
    {
        return state == BuffCardState.hoveringInHandFullyUp
            || state == BuffCardState.hoveringInHandMovingDown
            || state == BuffCardState.hoveringInHandMovingUp;
    }

    public bool isAppliedToMonster()
    {
        return state == BuffCardState.appliedAsDrawThree
            || state == BuffCardState.appliedAsSwitchLeft
            || state == BuffCardState.appliedAsSwitchRight;
    }

}
