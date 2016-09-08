using UnityEngine;
using System.Collections;

public class S_VideoManager
{

    
    public static int ResolutionWidth = 1280;
    public static int ResolutionHeight = 720;
    public static int ResolutionRefreshRate = 60;
    public static bool FullScreen = true;
    // public static bool VSync = true;
    public static bool Stats = true;

    public static void Init_Video()
    {
        Resolution defaultRes = Screen.currentResolution;

        ResolutionWidth = PlayerPrefs.GetInt( "ResolutionWidth", defaultRes.width );
        ResolutionHeight = PlayerPrefs.GetInt( "ResolutionHeight", defaultRes.height );
        ResolutionRefreshRate = PlayerPrefs.GetInt( "ResolutionRefreshRate", defaultRes.refreshRate );

        FullScreen = PlayerPrefs.GetInt( "FullScreen", 1 ) == 1 ? true : false;
        //  VSync = PlayerPrefs.GetInt( "VSync", 1 ) == 1 ? true : false;
        Stats = PlayerPrefs.GetInt( "Stats", 1 ) == 1 ? true : false;

        Screen.SetResolution( ResolutionWidth, ResolutionHeight, FullScreen, ResolutionRefreshRate );
       

    }

    public static void SaveAll_Video()
    {
        PlayerPrefs.SetInt( "ResolutionWidth", ResolutionWidth );
        PlayerPrefs.SetInt( "ResolutionHeight", ResolutionHeight );
        PlayerPrefs.SetInt( "ResolutionRefreshRate", ResolutionRefreshRate );
        PlayerPrefs.SetInt( "FullScreen", FullScreen ? 1 : 0 );
        // PlayerPrefs.SetInt( "VSync", VSync ? 1 : 0 );
        PlayerPrefs.SetInt( "Stats", Stats ? 1 : 0 );
    }


}
