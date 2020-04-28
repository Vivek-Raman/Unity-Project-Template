using UnityEngine;
using UnityEngine.Audio;

public class SettingMusicVolume : MonoBehaviour, ISetting
{
    private readonly string label = "Setting_" + SettingType.AudioMusicVolume.ToString();
    private float value = 1f;

    public void LoadFromPrefs()
    {
        value = PlayerPrefs.GetFloat(label, 0.5f);
    }

    public void ApplyAndSetPrefs()
    {
        PlayerPrefs.SetFloat(label, value);
    }
}