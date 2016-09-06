using UnityEngine;
using System.Collections;

public class S_MenuButtonManager : MonoBehaviour
{

    public GameObject m_Menu, m_Settings, m_AudioSet, m_VideoSet, m_InputsSet, m_Credits, m_GameOver;

    #region Menu

    public void Menu_Start()
    {
        S_SceneManager.Load_Demo();
        Debug.Log( "Click Menu_Start" );
    }

    public void Menu_Continue()
    {
        // TODO: Load actual Game
        Debug.Log( "Click Menu_Continue" );
    }


    public void Menu_Settings()
    {
        m_Menu.SetActive( false );
        m_Settings.SetActive( true );
        Debug.Log( "Click Menu_Settings" );
    }

    public void Menu_Credits()
    {
        m_Menu.SetActive( false );
        m_Credits.SetActive( true );
        Debug.Log( "Click Menu_Credits" );
    }

    public void Menu_Quit()
    {
        Debug.Log( "Click Menu_Quit" );
        Application.Quit();
    }

    #endregion

    #region Settings

    public void Settings_Video()
    {
        m_Settings.SetActive( false );
        m_VideoSet.SetActive( true );
        Debug.Log( "Click Settings_Video" );
    }

    public void Settings_Audio()
    {
        m_Settings.SetActive( false );
        m_AudioSet.SetActive( true );
        Debug.Log( "Click Settings_Audio" );
    }

    public void Settings_Inputs()
    {
        m_Settings.SetActive( false );
        m_InputsSet.SetActive( true );
        Debug.Log( "Click Settings_Inputs" );
    }

    public void Settings_Back()
    {
        m_Settings.SetActive( false );
        m_Menu.SetActive( true );
        Debug.Log( "Click Settings_Back" );
    }

    #endregion

    #region Settings_Audio

    public void AudioSet_Save()
    {
        // TODO: Save settings
        Debug.Log( "Click AudioSet_Save" );
    }

    public void AudioSet_Back()
    {
        m_AudioSet.SetActive( false );
        m_Settings.SetActive( true );
        Debug.Log( "Click AudioSet_Back" );
    }

    #endregion

    #region Settings_Video

    public void VideoSet_Save()
    {
        // TODO: Save settings
        Debug.Log( "Click VideoSet_Save" );
    }

    public void VideoSet_Back()
    {
        m_VideoSet.SetActive( false );
        m_Settings.SetActive( true );
        Debug.Log( "Click VideoSet_Back" );
    }

    #endregion

    #region Settings_Inputs

    public void InputsSet_Save()
    {
        // TODO: Save settings
        Debug.Log( "Click InputsSet_Save" );
    }

    public void InputsSet_Back()
    {
        m_InputsSet.SetActive( false );
        m_Settings.SetActive( true );
        Debug.Log( "Click InputsSet_Back" );
    }

    #endregion

    #region Credits

    public void Credits_Back()
    {
        m_Credits.SetActive( false );
        m_Menu.SetActive( true );
        Debug.Log( "Click VideoSet_Back" );
    }

    #endregion

    #region GameOver

    public void GameOver_Restart()
    {
        S_SceneManager.Load_Demo();
        Debug.Log( "Click GameOver_Restart" );
    }

    public void GameOver_MainMenu()
    {
        m_GameOver.SetActive( false );
        m_Menu.SetActive( true );
        Debug.Log( "Click GameOver_MainMenu" );
    }

    public void GameOver_Quit()
    {
        Debug.Log( "Click GameOver_Quit" );
        Application.Quit();
    }

    #endregion



    public void Menu_MainMenu()
    {
        S_SceneManager.Load_Menu();
        Debug.Log( "Load Menu" );
    }

    public void Menu_GameOver()
    {
        S_SceneManager.Load_Menu();

        m_Menu.SetActive( false );
        m_GameOver.SetActive( true );
        Debug.Log( "Load GameOver" );
    }




}
