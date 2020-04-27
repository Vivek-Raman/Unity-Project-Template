using System;
using UnityEngine;
using TMPro;

public class SettingResolution : MonoBehaviour, ISetting
{
    private readonly string label = "Settings_" + SettingType.DisplayResolution.ToString();
    
    [SerializeField] private bool limitResolutionList = true;
    
    private Resolution toSet;
    private int toSetIndex = 0;
    private TMP_Dropdown dropdown = null;
    
    private void Awake()
    {
        toSet = Screen.currentResolution;
        dropdown = this.GetComponentInChildren<TMP_Dropdown>();
        PopulateDropdown();
    }
    
    public void SetResolution(Int32 selection)
    {
        toSetIndex = Screen.resolutions.Length - selection - 1;
        toSet = Screen.resolutions[toSetIndex];
    }

    public void LoadFromPrefs()
    {
        toSetIndex = PlayerPrefs.GetInt(label, -1);
        if (toSetIndex == -1)
        {
            Debug.Log("Value not set");
        }
        
        toSet = Screen.resolutions[toSetIndex];
        dropdown.value = Screen.resolutions.Length - toSetIndex - 1;
    }

    public void ApplyAndSetPrefs()
    {
        Screen.SetResolution(toSet.width,
            toSet.height,
            Screen.fullScreen);
        
        PlayerPrefs.SetInt(label, toSetIndex);
        Debug.Log("Set resolution to " + toSet.ToString());
    }
    
    private void PopulateDropdown()
    {
        int limit = limitResolutionList ? Screen.resolutions.Length - 15 : 0;
        dropdown.options.Clear();
        for (int i = Screen.resolutions.Length - 1; i >= limit; --i)
        {
            if (Screen.resolutions[i].Equals(toSet))
            {
                toSetIndex = i;
            }
            dropdown.options.Add(new TMP_Dropdown.OptionData(Screen.resolutions[i].ToString()));
        }
    }
}