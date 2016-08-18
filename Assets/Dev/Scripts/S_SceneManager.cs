using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

class S_SceneManager
{
    public static int CurrentScene = 0;

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

    public static void Load_GameOver()
    {
        Load_Scene( 30 );
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
