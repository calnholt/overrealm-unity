using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMonstersController : MonoBehaviour
{
    [HideInInspector]
    public PlayerMonstersModel playerMonstersModel;
    private CardModel previousSelectedAction;

    void Start()
    {
        playerMonstersModel = GameObjectHelper.getScriptFromModel<PlayerMonstersModel>(gameObject);
    }

    void Update()
    {
        int id = previousSelectedAction ? previousSelectedAction.GetInstanceID() : -1;
        CardModel currentSelectedAction = playerMonstersModel.getSelectedActionModel(id);
        if (!currentSelectedAction) return;
        checkDifferentActionIsSelected(currentSelectedAction);
    }


    void checkDifferentActionIsSelected(CardModel currentSelectedAction)
    {
        if (!isCurrentSelectedDifferent(currentSelectedAction)) return;
        if (previousSelectedAction)
        {
            previousSelectedAction.GetComponent<IActionSelectable>().unselectAction();
        }
        previousSelectedAction = currentSelectedAction;
    }

    private bool isCurrentSelectedDifferent(CardModel currentSelectedAction)
    {
        if (!currentSelectedAction)
        {
            return false;
        }
        if (!previousSelectedAction)
        {
            return true;
        }
        return currentSelectedAction.GetInstanceID() != previousSelectedAction.GetInstanceID();
    }
}
