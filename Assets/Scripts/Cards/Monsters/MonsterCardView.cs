using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterCardView : MonoBehaviour
{
    public Text hpText;
    private MonsterCardModel monsterModel;
    void Start()
    {
        monsterModel = GameObjectHelper.getScriptFromModel<MonsterCardModel>(this.gameObject);
        hpText.text = monsterModel.Hp.ToString();
    }

    void Update()
    {
        
    }
}
