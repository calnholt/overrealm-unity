using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    }

    private void checkIfCardApplied()
    {
        if (buff.State == BuffCardState.appliedAsDrawThree)
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
        }
    }

    private void OnMouseUp()
    {
        if (!buff || monsterCardModel.AppliedCard) return;
        if (buff.State == BuffCardState.draggingOverDrawThreeApply)
        {
            buff.State = BuffCardState.appliedAsDrawThree;
        }
        else if (buff.State == BuffCardState.draggingOverSwitchLeftApply)
        {
            buff.State = BuffCardState.appliedAsSwitchLeft;
        }
        else if (buff.State == BuffCardState.draggingOverSwitchRightApply)
        {
            buff.State = BuffCardState.appliedAsSwitchRight;
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!monsterCardModel.isApplied())
        {
            buff = collision.transform.parent.GetComponentInChildren<BuffCardModel>();
            if (buff && buff.isDragging())
            {
                if (monsterCardModel.IsActive)
                {
                    buff.State = BuffCardState.draggingOverDrawThreeApply;

                }
                else if (monsterCardModel.IsLeft)
                {
                    buff.State = BuffCardState.draggingOverSwitchLeftApply;
                }
                else
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
            }
        }
    }
}
