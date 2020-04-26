using System;
using UnityEngine;
using TMPro;

class SettingScreenMode : Setting<FullScreenMode>
{
    public void OnFullscreenModeChanged(Int32 selection)
    {
        value = (FullScreenMode)selection;
        Screen.fullScreenMode = value;
        Debug.Log("Set screen mode to " + value);
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