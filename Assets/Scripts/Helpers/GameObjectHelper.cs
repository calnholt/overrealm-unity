using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Constants;

public static class GameObjectHelper
{
    public static SCRIPT getScriptFromModel<SCRIPT>(GameObject gameObject)
    {
        return gameObject.transform.parent.GetChild(GameObjectStructure.MODEL).GetComponent<SCRIPT>();
    }

    public static UIController getUIController()
    {
        return GameObject.FindGameObjectWithTag("UI").transform.GetComponent<UIController>();
    }
    public static SCRIPT getModel<SCRIPT>(GameObject gameObject)
    {
        return gameObject.transform.GetChild(GameObjectStructure.MODEL).GetComponent<SCRIPT>();
    }
    public static List<SCRIPT> GetComponentsInChildrenList<SCRIPT>(GameObject gameObject)
    {
        return new List<SCRIPT>(gameObject.GetComponentsInChildren<SCRIPT>());
    }
    public static SCRIPT getScriptFromTag<SCRIPT>(Tags tag)
    {
        return GameObject.FindGameObjectWithTag(tag.ToString()).GetComponentInChildren<SCRIPT>();
    }
    public static ConstantsSingleton getConstantsSingleton()
    {
        return GameObjectHelper.getScriptFromTag<ConstantsSingleton>(Tags.Singleton);
    }
}
