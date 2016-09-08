using UnityEngine;
using System.Collections;

class S_AudioManager
{

    public static int GlobalVolume = 50;
    public static int MusicVolume = 100;
    public static int FXVolume = 100;
    public static int DialogVolume = 100;

    public static void Set_GlobalVol(int _vol )
    {
        GlobalVolume = _vol;
    }

    public static void Set_MusicVol( int _vol )
    {
        MusicVolume = _vol;
    }

    public static void Set_FXVol( int _vol )
    {
        FXVolume = _vol;
    }

    public static void Set_DialogVol( int _vol )
    {
        DialogVolume = _vol;
    }

    public static void Init_Vol()
    {
        GlobalVolume = PlayerPrefs.GetInt( "GlobalVolume", 50 );
        MusicVolume = PlayerPrefs.GetInt( "MusicVolume", 50 );
        FXVolume = PlayerPrefs.GetInt( "FXVolume", 50 );
        DialogVolume = PlayerPrefs.GetInt( "DialogVolume", 50 );

        Debug.Log( "" + GlobalVolume + "  " + MusicVolume + "  " + FXVolume + "  " + DialogVolume );
    }

    public static void SaveAll_Vol()
    {
        PlayerPrefs.SetInt( "GlobalVolume", GlobalVolume );
        PlayerPrefs.SetInt( "MusicVolume", MusicVolume );
        PlayerPrefs.SetInt( "FXVolume", FXVolume  );
        PlayerPrefs.SetInt( "DialogVolume", DialogVolume );
    }

}
