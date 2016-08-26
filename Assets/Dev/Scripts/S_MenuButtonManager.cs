using UnityEngine;
using System.Collections;

public class S_MenuButtonManager : MonoBehaviour {

    public void Menu_Start()
    {
        S_SceneManager.Load_Demo();
        Debug.Log( "Click Start" );
    }

    public void Menu_Restart()
    {
        S_SceneManager.Load_Demo();
        Debug.Log( "Click Restart" );
    }

    public void Menu_Continue()
    {
        // S_SceneManager.Load_Demo();
        Debug.Log( "Click Continue" );
    }
    public void Menu_MainMenu()
    {
        S_SceneManager.Load_Menu();
        Debug.Log( "Click Menu" );
    }

    public void Menu_Settings()
    {
        // S_SceneManager.Load_Settings();
        Debug.Log( "Click Settings" );
    }

    public void Menu_Credits()
    {
        // S_SceneManager.Load_Credits();
        Debug.Log( "Click Credits" );
    }

    public void Menu_Quit()
    {
        Debug.Log( "Click Quit" );
        Application.Quit();
    }

	
}
