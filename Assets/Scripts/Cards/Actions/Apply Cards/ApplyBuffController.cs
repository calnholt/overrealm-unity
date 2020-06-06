using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplyBuffController : MonoBehaviour
{
    private ActionCardModel actionCardModel;
    private GameObject buffToApply;
    private BuffCardModel buffCardModel;

    void Start()
    {
        actionCardModel = GameObjectHelper.getScriptFromModel<ActionCardModel>(gameObject.transform.parent.gameObject);
    }

    void Update()
    {
        checkIfBuffBecomesUnapplied();
        if (!buffToApply) return;
        if (buffCardModel.State == BuffCardState.appliedAsBuff)
        {
            this.actionCardModel.BuffsToApply.Add(buffToApply);
            buffToApply = null;
        }
    }

    private void checkIfBuffBecomesUnapplied()
    {
        int index = actionCardModel.BuffsToApply.FindIndex(buff => buff.transform.GetComponentInChildren<BuffCardModel>().State == BuffCardState.movingToHand);
        if (index >= 0)
        {
            actionCardModel.BuffsToApply.RemoveAt(index);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        buffCardModel = GameObjectHelper.getScriptFromModel<BuffCardModel>(collision.gameObject);
        if (buffCardModel && buffCardModel.State == BuffCardState.dragging && actionCardModel.canApplyBuff())
        {
            buffToApply = collision.transform.parent.gameObject;
            buffCardModel.State = BuffCardState.draggingOverBuffApply;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        buffCardModel = GameObjectHelper.getScriptFromModel<BuffCardModel>(collision.gameObject);
        if (buffCardModel && buffCardModel.State == BuffCardState.draggingOverBuffApply)
        {
            buffToApply = null;
            buffCardModel.State = BuffCardState.dragging;
        }
    }
}
