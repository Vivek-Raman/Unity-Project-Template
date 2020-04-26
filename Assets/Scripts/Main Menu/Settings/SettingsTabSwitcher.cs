using System.Collections.Generic;
using UnityEngine;

public class SettingsTabSwitcher : MonoBehaviour
{
    [SerializeField] private List<GameObject> rects = null;

    public void SwitchTo(int selection)
    {
        for (int i = 0; i < rects.Count; i++)
        {
            rects[i].SetActive(i == selection);
        }
    }
}
