using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SettingResolution : Setting<Resolution>
{
    [SerializeField] private bool stopAt768P = true;
    
    private TMP_Dropdown dropdown = null;
    
    private void Awake()
    {
        dropdown = this.GetComponentInChildren<TMP_Dropdown>();
        dropdown.options.Clear();
        int limit = stopAt768P ? Screen.resolutions.Length - 15 : 0;
        for (int i = Screen.resolutions.Length - 1; i >= limit; --i)
        {
            dropdown.options.Add(new TMP_Dropdown.OptionData(Screen.resolutions[i].ToString()));
        }
        
    }

    public void SetResolution(Int32 selection)
    {
        value = Screen.resolutions[Screen.resolutions.Length - selection - 1];
        Screen.SetResolution(value.width,
            value.height,
            Screen.fullScreen);
        
        Debug.Log("Set resolution to " + value.ToString());
    }

    public override void WriteToPrefs()
    {
        throw new NotImplementedException();
    }

    public override void LoadFromPrefs()
    {
        throw new NotImplementedException();
    }
}