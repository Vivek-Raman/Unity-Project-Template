using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private string sceneToLoadOnPlay = "SampleScene";

    [Header("Panels")]
    [SerializeField] private GameObject rootPanel = null;
    [SerializeField] private GameObject optionsPanel = null;
    [SerializeField] private GameObject aboutPanel = null;

    private void Awake()
    {
        ActivatePanel(1);
    }

    public void UI_Navigation_BackToRoot()
    {
        ActivatePanel(1);
    }
    
    public void UI_Root_Play()
    {
        SceneManager.LoadScene(sceneToLoadOnPlay);
    }

    public void UI_Root_Options()
    {
        ActivatePanel(2);
    }

    public void UI_Root_About()
    {
        ActivatePanel(3);
    }

    public void UI_Root_Exit()
    {
        Application.Quit();
    }
    
    private void ActivatePanel(int choice)
    {
        switch (choice)
        {
            case 1:
                rootPanel.SetActive(true);
                optionsPanel.SetActive(false);
                aboutPanel.SetActive(false);
                break;
            
            case 2:
                rootPanel.SetActive(false);
                optionsPanel.SetActive(true);
                aboutPanel.SetActive(false);
                break;
            
            case 3:
                rootPanel.SetActive(false);
                optionsPanel.SetActive(false);
                aboutPanel.SetActive(true);
                break;
        }
    }
}
