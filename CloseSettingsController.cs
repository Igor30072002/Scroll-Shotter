using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseSettingsController : MonoBehaviour
{
    [SerializeField] private RectTransform settingsPanel;

    public void Close()
    {
        settingsPanel.localScale = Vector3.zero;
    }
}
