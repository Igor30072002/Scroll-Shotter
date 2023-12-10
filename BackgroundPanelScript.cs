using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundPanelScript : MonoBehaviour
{
    [SerializeField] private RectTransform backgroundPanel;
    private bool isMovingLeft = true;
    private float speed = 60f;
    private float timer = 0f;
    private float duration = 15f;

    private void Update()
    {
        timer += Time.deltaTime;
        float direction = isMovingLeft ? -1f : 1f;
        float offset = direction * speed * Time.deltaTime;
        Vector2 anchoredPosition = backgroundPanel.anchoredPosition;
        anchoredPosition.x += offset;
        backgroundPanel.anchoredPosition = anchoredPosition;

        if (timer >= duration)
        {
            isMovingLeft = !isMovingLeft;
            timer = 0f;
        }
    }
}
