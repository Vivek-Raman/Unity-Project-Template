using System;
using UnityEngine;
using TMPro;

class SettingScreenMode : MonoBehaviour, ISetting
{
    private readonly string label = "Settings_" + SettingType.DisplayFullscreenMode.ToString();
    private FullScreenMode toSet;
    private TMP_Dropdown dropdown = null;

    private void Awake()
    {
        toSet = Screen.fullScreenMode;
        dropdown = this.GetComponentInChildren<TMP_Dropdown>();
    }

    public void OnFullscreenModeChanged(Int32 selection)
    {
        toSet = (FullScreenMode)selection;
    }

    public void LoadFromPrefs()
    {
        int value = PlayerPrefs.GetInt(label, 0);
        toSet = (FullScreenMode) value;
        dropdown.value = value;
    }

    public void ApplyAndSetPrefs()
    {
        Screen.fullScreenMode = toSet;
        
        PlayerPrefs.SetInt(label, (int) toSet);
        Debug.Log("Set screen mode to " + toSet);
    }
}