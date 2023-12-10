using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenSettingsController : MonoBehaviour
{
    [SerializeField] private RectTransform settingsPanel;

    public void Click()
    {
        settingsPanel.localScale = Vector3.one;
    }
}
