using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManeuverView : MonoBehaviour
{
    private TextMesh textMesh;
    private ManeuverModel model;

    void Start()
    {
        model = GameObjectHelper.getScriptFromModel<ManeuverModel>(gameObject);
        textMesh = GetComponentInChildren<TextMesh>();
    }

    void Update()
    {
        textMesh.text = model.NumberRemaining.ToString();
    }
}
