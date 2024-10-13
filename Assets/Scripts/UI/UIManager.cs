using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class UIManager : MonoBehaviour
{
    //Title Menu
    [Header("Title Menu")]
    [SerializeField] GameObject creditsPanel;

    private bool isCreditsPanelOpen = false;
/*
    //InGame Stuff
    [Header("In Game Menu")]
    [SerializeField] static GameObject levelEndPanel;
    [SerializeField] Image levelCleared;
    [SerializeField] Image levelFailed;
*/

    private void Start()
    {
        creditsPanel.SetActive(false);
        /*levelEndPanel.SetActive(false);*/
    }
    public void StartGame()
    {
        SceneManager.LoadScene("Level 1");
    }

    public void OpenCredits()
    {
        if (isCreditsPanelOpen == false)
        {
            creditsPanel.SetActive(true);
            isCreditsPanelOpen = true;
        }
    }

    public void CloseCredits()
    {
        if (isCreditsPanelOpen == true)
        {
            creditsPanel.SetActive(false);
            isCreditsPanelOpen = false;
        }
    }

    public static void OpenLevelEndPanel()
    {
        /*levelEndPanel.SetActive(true);*/
    }

    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("The game is now closing");
    }

    //InGame Menu
    public void PauseGame()
    {
        Time.timeScale = 0f;
    }

    public void PlayGame()
    {
        Time.timeScale = 1f;
    }

    public void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ExitToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
