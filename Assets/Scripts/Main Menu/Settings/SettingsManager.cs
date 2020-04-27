using System.Collections.Generic;
using UnityEngine;

public class SettingsManager : MonoBehaviour
{
    [SerializeField] private GameObject settingHolderParent = null;

    private List<ISetting> settings = null;
    
    private void Start()
    {
        settings = new List<ISetting>(
            settingHolderParent.GetComponentsInChildren<ISetting>());
        
    }

    public void UI_Load_Settings()
    {
        foreach (ISetting setting in settings)
        {
            setting.LoadFromPrefs();
        }
    }
    
    public void UI_Settings_Apply()
    {
        foreach (ISetting setting in settings)
        {
            setting.ApplyAndSetPrefs();
        }
        PlayerPrefs.Save();
    }

    [ContextMenu(nameof(DebugDeletePrefs))]
    private void DebugDeletePrefs()
    {
        PlayerPrefs.DeleteAll();
    }
}