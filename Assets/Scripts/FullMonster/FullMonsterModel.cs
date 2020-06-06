using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullMonsterModel : MonoBehaviour
{
    [SerializeField]
    private bool isActive;
    [SerializeField]
    private bool isLeft;

    private MonsterCardModel monsterCardModel;
    private List<ActionCardModel> actionCardModels;
    

    public bool IsActive { get => isActive; set => isActive = value; }
    public bool IsLeft { get => isLeft; set => isLeft = value; }
    public MonsterCardModel MonsterCardModel { get => monsterCardModel; set => monsterCardModel = value; }
    public List<ActionCardModel> ActionCardModels { get => actionCardModels; set => actionCardModels = value; }

    private void Start()
    {
        monsterCardModel = transform.parent.GetComponentInChildren<MonsterCardModel>();
        actionCardModels = GameObjectHelper.GetComponentsInChildrenList<ActionCardModel>(transform.parent.gameObject);
        //buffObjects.ForEach(b => buffCardModels.Add(GameObjectHelper.getModel<BuffCardModel>(b)));
    }

    public bool isMonsterActionSelected()
    {
        return actionCardModels.Find(a => a.IsSelected);
    }

    public CardModel getSelectedMonsterAction()
    {
        return actionCardModels.Find(a => a.IsSelected);
    }

}
