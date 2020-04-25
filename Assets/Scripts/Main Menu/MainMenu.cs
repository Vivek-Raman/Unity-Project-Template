using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private string gameScene = "SampleScene";

    public void UI_Navigation_BackToRoot()
    {
        
    }
    
    #region Root

    public void UI_Root_Play()
    {
        SceneManager.LoadScene(gameScene);
    }

    public void UI_Root_Options()
    {
        
    }

    public void UI_Root_About()
    {
        
    }

    public void UI_Root_Exit()
    {
        Application.Quit();
    }

    #endregion

    #region Options

    // TODO: Mouse Sensitivity
    // TODO: Mouse Y Invert
    // TODO: Music Volume
    // TODO: SFX Volume
    // TODO: Resolution
    // TODO: Fullscreen/Windowed
    // TODO: Controls
    
    #endregion
}
