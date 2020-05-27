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

    private PlayerMonstersController playerMonstersController;

    // Start is called before the first frame update
    void Start()
    {
        playerMonstersController = playerMonstersObj.GetComponent<PlayerMonstersController>();
        activeMonsterName = playerMonstersController.ActiveMonsterModel.MonsterCardModel.MonsterName;
        setMonsterActionText();
    }

    // Update is called once per frame
    void Update()
    {
        string currentActiveMonsterName = playerMonstersController.ActiveMonsterModel.MonsterCardModel.MonsterName;
        if (!currentActiveMonsterName.Equals(activeMonsterName)){
            setMonsterActionText();
            activeMonsterName = currentActiveMonsterName;
        }
    }

    private void setMonsterActionText()
    {
        List<ActionCardModel> actions = playerMonstersController.ActiveMonsterModel.ActionCardModels;
        for (int i = 0; i < actions.Count; i++)
        {
            monsterActionTexts[i].text = actions[i].AttackName;
        }
    }
}
