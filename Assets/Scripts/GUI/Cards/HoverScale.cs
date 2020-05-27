using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverScale : MonoBehaviour
{
    [SerializeField]
    private float scaleFactor;
    private Vector3 originalScale;
    private SpriteRenderer sprite;

    void Start()
    {
        originalScale = this.transform.localScale;
        sprite = gameObject.GetComponentInChildren<SpriteRenderer>();
    }

    private void OnMouseEnter()
    {
        Vector3 newScale = new Vector3(originalScale.x * scaleFactor, originalScale.y * scaleFactor, originalScale.z * scaleFactor);
        Vector3 p = transform.position;
        this.transform.localScale = newScale;
        this.transform.position = new Vector3(p.x, p.y, p.z + 50);
        sprite.sortingOrder = 1;
    }

    private void OnMouseExit()
    {
        this.transform.localScale = originalScale;
        Vector3 p = transform.position;
        this.transform.position = new Vector3(p.x, p.y, 0);
        sprite.sortingOrder = 0;
    }
}
