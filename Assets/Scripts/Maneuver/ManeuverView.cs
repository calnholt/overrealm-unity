using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ManeuverView : MonoBehaviour
{
    private TextMesh textMesh;
    private ManeuverModel model;
    private int previousNumberRemaining;

    [Header("Click Punch Settings")]
    [SerializeField]
    private Vector3 hoverPunchVector;
    [SerializeField]
    private float hoverPunchDuration;
    [SerializeField]
    private int hoverPunchVibrato = 10;
    [SerializeField]
    private int hoverPunchElasticity = 1;
    private Sequence seq;
    private bool isTweening = false;

    void Start()
    {
        model = GameObjectHelper.getScriptFromModel<ManeuverModel>(gameObject);
        textMesh = GetComponentInChildren<TextMesh>();
        previousNumberRemaining = model.NumberRemaining;
        seq = DOTween.Sequence();
    }

    void Update()
    {
        bool isUpdate = model.NumberRemaining != previousNumberRemaining;
        if (isUpdate)
        {
            updateNumberRemainingText();
            updateAnimation();
        }
        previousNumberRemaining = model.NumberRemaining;
    }

    void updateNumberRemainingText()
    {
        textMesh.text = model.NumberRemaining.ToString();
    }

    void updateAnimation()
    {
        if (isTweening) return;
        isTweening = true;
        seq.Kill();
        seq = DOTween.Sequence();
        seq.Append(transform.parent.DOPunchScale(hoverPunchVector, hoverPunchDuration, hoverPunchVibrato, hoverPunchElasticity));
        seq.AppendCallback(callback);
    }

    void callback()
    {
        isTweening = false;
    }
}
