using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullMonsterController : MonoBehaviour
{
    private FullMonsterModel fullMonsterModel;
    void Start()
    {
        fullMonsterModel = GameObjectHelper.getScriptFromModel<FullMonsterModel>(gameObject);
    }

    void Update()
    {
        
    }


}
