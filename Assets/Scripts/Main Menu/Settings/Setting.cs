using System;
using UnityEngine;

public abstract class Setting<T> : MonoBehaviour
{
    public SettingType label = SettingType.Null;
    public T value;

    public abstract void WriteToPrefs();
    public abstract void LoadFromPrefs();
}