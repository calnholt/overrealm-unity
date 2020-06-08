using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Constants;

public class ManeuverController : MonoBehaviour
{
    private ManeuverModel model;
    private PlayerMonstersModel playerMonstersModel;
    private CardModel cardWithAppliedManeuver;

    void Start()
    {
        model = GameObjectHelper.getScriptFromModel<ManeuverModel>(gameObject);
        playerMonstersModel = GameObjectHelper.getScriptFromTag<PlayerMonstersModel>(Tags.Player);
    }

    void Update()
    {
        checkIfSelectedActionChanged();
    }

    private void OnMouseDown()
    {
        if (model.IsApplied || model.NumberRemaining == 0) return;
        cardWithAppliedManeuver = playerMonstersModel.getCurrentSelectedAction();
        if (!cardWithAppliedManeuver) return;
        model.apply();
        cardWithAppliedManeuver.IsManeuver = true;
    }

    private void checkIfSelectedActionChanged()
    {
        if (!cardWithAppliedManeuver) return;
        CardModel currentSelection = playerMonstersModel.getCurrentSelectedAction();
        if (!currentSelection && model.IsApplied)
        {
            model.unapply();
            return;
        }
        if (!currentSelection) return;
        if (cardWithAppliedManeuver.GetInstanceID() != currentSelection.GetInstanceID())
        {
            cardWithAppliedManeuver = null;
            model.unapply();
        }
    }
}
