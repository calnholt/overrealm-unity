using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MonsterCardController : MonoBehaviour
{
    private MonsterCardModel monsterCardModel;
    private BuffCardModel buff;

    void Start()
    {
        monsterCardModel = GameObjectHelper.getScriptFromModel<MonsterCardModel>(gameObject);
    }

    void Update()
    {
        if (!buff) return;
        checkIfCardApplied();
        checkIfBuffBecomesUnapplied();
        checkIfIsCounter();
    }

    private void checkIfCardApplied()
    {
        if (buff.isAppliedToMonster())
        {
            monsterCardModel.AppliedCard = buff;
            Vector3 monsterPosition = monsterCardModel.transform.parent.position;
            //TODO: use const for 1.47f - its the same distance below as applied buffs for actions
            buff.transform.parent.localPosition = new Vector3(monsterPosition.x, monsterPosition.y - 1.47f, monsterPosition.z);
        }
    }

    private void checkIfBuffBecomesUnapplied()
    {
        if (buff.State == BuffCardState.movingToHand && monsterCardModel.AppliedCard)
        {
            monsterCardModel.AppliedCard = null;
            monsterCardModel.unselectAction();
        }
    }

    // manages applied buff's state depending on manuever
    private void checkIfIsCounter()
    {
        if (monsterCardModel.isActionSelected()
            && monsterCardModel.IsManeuver
            && monsterCardModel.State == MonsterCardState.active
            && monsterCardModel.AppliedCard.State != BuffCardState.appliedAsCounter)
        {
            monsterCardModel.AppliedCard.State = BuffCardState.appliedAsCounter;
        }
        else if (monsterCardModel.isActionSelected()
            && !monsterCardModel.IsManeuver
            && monsterCardModel.State == MonsterCardState.active
            && monsterCardModel.AppliedCard.State != BuffCardState.appliedAsDrawThree)
        {
            monsterCardModel.AppliedCard.State = BuffCardState.appliedAsDrawThree;
        }
    }

    private void OnMouseEnter()
    {
        monsterCardModel.IsHovering = true;
    }

    private void OnMouseExit()
    {
        monsterCardModel.IsHovering = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!monsterCardModel.isApplied())
        {
            buff = collision.transform.parent.GetComponentInChildren<BuffCardModel>();
            if (buff && buff.isDragging())
            {
                //transform.parent.HoverPunch();
                monsterCardModel.IsHoveringApplied = true;
                if (monsterCardModel.State == MonsterCardState.active)
                {
                    buff.State = BuffCardState.draggingOverDrawThreeApply;

                }
                else if (monsterCardModel.State == MonsterCardState.left)
                {
                    buff.State = BuffCardState.draggingOverSwitchLeftApply;
                }
                else if (monsterCardModel.State == MonsterCardState.right)
                {
                    buff.State = BuffCardState.draggingOverSwitchRightApply;
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!monsterCardModel.isApplied())
        {
            buff = collision.transform.parent.GetComponentInChildren<BuffCardModel>();
            if (buff && buff.isDraggingOverApplied())
            {
                buff.State = BuffCardState.dragging;
                buff = null;
                monsterCardModel.IsHovering = false;
                monsterCardModel.IsHoveringApplied = false;
            }
        }
    }
}
