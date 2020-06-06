using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActionBoardView : MonoBehaviour
{
    // TODO: do this dynamically
    [SerializeField]
    private GameObject playerMonstersObj;
    [SerializeField]
    private List<Text> monsterActionTexts;
    private string activeMonsterName;

    private PlayerMonstersModel playerMonstersModel;

    void Start()
    {
        playerMonstersModel = playerMonstersObj.GetComponent<PlayerMonstersModel>();
        activeMonsterName = playerMonstersModel.ActiveMonsterModel.MonsterCardModel.MonsterName;
        setMonsterActionText();
    }

    void Update()
    {
        string currentActiveMonsterName = playerMonstersModel.ActiveMonsterModel.MonsterCardModel.MonsterName;
        if (!currentActiveMonsterName.Equals(activeMonsterName)){
            setMonsterActionText();
            activeMonsterName = currentActiveMonsterName;
        }
    }

    private void setMonsterActionText()
    {
        List<ActionCardModel> actions = playerMonstersModel.ActiveMonsterModel.ActionCardModels;
        for (int i = 0; i < actions.Count; i++)
        {
            monsterActionTexts[i].text = actions[i].AttackName;
        }
    }
}
