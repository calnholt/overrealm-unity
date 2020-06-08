using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMonstersModel : MonoBehaviour
{
    private FullMonsterModel activeMonsterModel;
    private FullMonsterModel leftInactiveMonster;
    private FullMonsterModel rightInactiveMonster;
    List<CardModel> cardModels;

    public FullMonsterModel ActiveMonsterModel { get => activeMonsterModel; set => activeMonsterModel = value; }
    public FullMonsterModel LeftInactiveMonster { get => leftInactiveMonster; set => leftInactiveMonster = value; }
    public FullMonsterModel RightInactiveMonster { get => rightInactiveMonster; set => rightInactiveMonster = value; }

    // Start is called before the first frame update
    void Start()
    {
        List<FullMonsterModel> models = GameObjectHelper.GetComponentsInChildrenList<FullMonsterModel>(transform.parent.gameObject);
        this.activeMonsterModel = models.Find(model => model.IsActive);
        this.leftInactiveMonster = models.Find(model => model.IsLeft);
        this.rightInactiveMonster = models.Find(model => !model.IsLeft && !model.IsActive);
        setCardModels();
    }

    public CardModel getNewestSelectedActionModel(int id)
    {
        // set id to -1 when not trying to locate by id
        if (id == -1)
        {
            if (leftInactiveMonster.MonsterCardModel.isActionSelected())
            {
                return leftInactiveMonster.MonsterCardModel;
            }
            if (rightInactiveMonster.MonsterCardModel.isActionSelected())
            {
                return rightInactiveMonster.MonsterCardModel;
            }
            if (activeMonsterModel.MonsterCardModel.isActionSelected())
            {
                return activeMonsterModel.MonsterCardModel;
            }
            if (activeMonsterModel.isMonsterActionSelected())
            {
                return activeMonsterModel.getSelectedMonsterAction();
            }
            return null;
        }
        CardModel selectedAction = cardModels.Find(cardModel =>
        {
            int instanceId = cardModel.GetInstanceID();
            return instanceId != id && cardModel.GetComponent<IActionSelectable>().isActionSelected();
        });
        return selectedAction;
    }

    public CardModel getCurrentSelectedAction()
    {
        return cardModels.Find(cardModel => cardModel.GetComponent<IActionSelectable>().isActionSelected());
    }

    private void setCardModels()
    {
        cardModels = new List<CardModel>();
        cardModels.AddRange(activeMonsterModel.ActionCardModels);
        cardModels.Add(leftInactiveMonster.MonsterCardModel);
        cardModels.Add(rightInactiveMonster.MonsterCardModel);
        cardModels.Add(activeMonsterModel.MonsterCardModel);
    }

}
