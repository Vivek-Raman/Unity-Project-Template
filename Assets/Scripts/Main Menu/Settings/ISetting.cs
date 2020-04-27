using System;
using UnityEngine;

public interface ISetting
{
    void LoadFromPrefs();
    void ApplyAndSetPrefs();
}