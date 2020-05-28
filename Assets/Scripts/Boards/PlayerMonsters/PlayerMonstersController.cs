using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMonstersController : MonoBehaviour
{
    private FullMonsterModel activeMonsterModel;
    private FullMonsterModel leftInactiveMonster;
    private FullMonsterModel rightInactiveMonster;

    public FullMonsterModel ActiveMonsterModel { get => activeMonsterModel; set => activeMonsterModel = value; }
    public FullMonsterModel LeftInactiveMonster { get => leftInactiveMonster; set => leftInactiveMonster = value; }
    public FullMonsterModel RightInactiveMonster { get => rightInactiveMonster; set => rightInactiveMonster = value; }

    // Start is called before the first frame update
    void Start()
    {
        List<FullMonsterModel> models = GameObjectHelper.GetComponentsInChildrenList<FullMonsterModel>(gameObject);
        this.activeMonsterModel = models.Find(model => model.IsActive);
        this.leftInactiveMonster = models.Find(model => model.IsLeft);
        this.rightInactiveMonster = models.Find(model => !model.IsLeft && !model.IsActive);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
