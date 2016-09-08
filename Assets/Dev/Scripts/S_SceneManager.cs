using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

class S_SceneManager
{
    public static int CurrentScene = 0;

    public static MenuState CurrentMenu = MenuState.Main;

    public static void Init_All()
    {
        S_AudioManager.Init_Vol();

        S_VideoManager.Init_Video();

        // TODO: 
        //          Init_Video
        //          Init_Inputs
    }

    public static void Load_SplashScreen()
    {           
        Load_Scene( 0 );
    }

    public static void Load_Menu()
    {
        Load_Scene( 1 );
    }

    public static void Load_Demo()
    {
        Load_Scene( 2 );
    }

    public static void Load_MainMenu()
    {
        CurrentMenu = MenuState.Main;
        Load_Menu();
    }

    public static void Load_GameOver()
    {

        CurrentMenu = MenuState.GameOver;
        Load_Menu();        

    }

    public static void Load_Next()
    {
        Load_Scene( CurrentScene + 1 );
    }

    public static void Load_Scene(int _index)
    {
        CurrentScene = _index;
        SceneManager.LoadScene( _index );
    } 

}

public enum MenuState
{
    Main,
    Settings,
    SettingsAudio,
    SettingsVideo,
    SettingsInputs,
    Credits,
    GameOver
}
