using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelChanger : MonoBehaviour
{
    
    public Button Story;
    public Button Credits;
    public Button Exit;
    public Button MainMenu;
    public Button Options;

    void Start()
    {
        if (GameObject.Find("Story") != null)
        {
            Button btn1 = Story.GetComponent<Button>();
            btn1.onClick.AddListener(StoryTask);
        }

        if (GameObject.Find("Credits") != null)
        {
            Button btn2 = Credits.GetComponent<Button>();
            btn2.onClick.AddListener(CreditsTask);
        }

        if (GameObject.Find("Exit") != null)
        {
            Button btn3 = Exit.GetComponent<Button>();
            btn3.onClick.AddListener(ExitTask);
        }

        if (GameObject.Find("MainMenu") != null)
        {
            Button btn4 = MainMenu.GetComponent<Button>();
            btn4.onClick.AddListener(MainMenuTask);
        }
        if (GameObject.Find("Options") != null)
        {
            Button btn5 = Options.GetComponent<Button>();
            btn5.onClick.AddListener(OptionsTask);
        }
    }

    void StoryTask()
    {
        Application.LoadLevel("HeroSelection");
    }

    void CreditsTask()
    {
        Application.LoadLevel("Credits");
    }

    void ExitTask()
    {
        Application.Quit();
    }
    void MainMenuTask()
    {
        Application.LoadLevel("MainMenu");
    }
    void OptionsTask()
    {
        Application.LoadLevel("Options");
    }
}

