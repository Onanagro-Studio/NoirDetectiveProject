using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class S_MenuButtonManager : MonoBehaviour
{

    public GameObject m_Menu, m_Settings, m_AudioSet, m_VideoSet, m_InputsSet, m_Credits, m_GameOver;
    public Slider m_SliderGlobal, m_SliderMusic, m_SliderFX, m_SliderDialog;

    public Dropdown m_DropdownResolutions;
    public Toggle m_ToggleFullScreen, m_ToggleStats;

    private Resolution[] m_Res;
    private Resolution actualRes = new Resolution();

    private int m_globalVol, m_musicVol, m_FXVol, m_DialogVol;

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
        Settings_Audio();

        //m_Settings.SetActive( true );
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
        int defaultRes = -1;
        
        actualRes.width = S_VideoManager.ResolutionWidth;
        actualRes.height = S_VideoManager.ResolutionHeight;
        actualRes.refreshRate = S_VideoManager.ResolutionRefreshRate;

        m_Settings.SetActive( false );
        m_VideoSet.SetActive( true );

        m_Res = Screen.resolutions;
        m_DropdownResolutions.options.Clear();


        int count = 0;
        for( int i = 0 ; i < m_Res.Length; i++ )
        {
            if( m_Res[ i ].Equals( actualRes ) )
            {
                defaultRes = i;
            }

            m_DropdownResolutions.options.Add( new Dropdown.OptionData( m_Res[ i ].ToString() ) );
            m_DropdownResolutions.value = i;

            count = i;
        }

        if(defaultRes != -1 )
        {
            m_DropdownResolutions.value = count;
        }
        else
        {
            m_DropdownResolutions.options.Add( new Dropdown.OptionData( actualRes.ToString() ) );
            m_DropdownResolutions.value = count +1;
        }

        m_ToggleFullScreen.isOn = S_VideoManager.FullScreen;
        m_ToggleStats.isOn = S_VideoManager.Stats;

        Debug.Log( "Click Settings_Video" );
    }

    public void Settings_Audio()
    {
        m_Settings.SetActive( false );
        m_AudioSet.SetActive( true );

        m_globalVol = S_AudioManager.GlobalVolume;
        m_musicVol = S_AudioManager.MusicVolume;
        m_FXVol = S_AudioManager.FXVolume;
        m_DialogVol = S_AudioManager.DialogVolume;

        m_SliderGlobal.value = (float)m_globalVol / 100f;
        m_SliderMusic.value = (float)m_musicVol / 100f;
        m_SliderFX.value = (float)m_FXVol / 100f;
        m_SliderDialog.value = (float)m_DialogVol / 100f;

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

        m_globalVol = S_AudioManager.GlobalVolume;
        m_musicVol = S_AudioManager.MusicVolume;
        m_FXVol = S_AudioManager.FXVolume;
        m_DialogVol = S_AudioManager.DialogVolume;

        S_AudioManager.SaveAll_Vol();

        Debug.Log( "Click AudioSet_Save" );
    }

    public void AudioSet_Back()
    {
        m_AudioSet.SetActive( false );
        //   m_Settings.SetActive( true );
        Settings_Back();

        S_AudioManager.Set_GlobalVol( m_globalVol );
        S_AudioManager.Set_MusicVol( m_musicVol  );
        S_AudioManager.Set_FXVol( m_FXVol );
        S_AudioManager.Set_DialogVol( m_DialogVol );

        Debug.Log( "Click AudioSet_Back" );
    }

    public void On_GlobalVolChange()
    {
        int vol = (int)( m_SliderGlobal.value * 100 );
        S_AudioManager.Set_GlobalVol( vol );
    }

    public void On_MusicVolChange()
    {
        int vol = (int)( m_SliderMusic.value * 100 );
        S_AudioManager.Set_MusicVol( vol );
    }

    public void On_FXVolChange()
    {
        int vol = (int)(  m_SliderFX.value * 100 );
        S_AudioManager.Set_FXVol( vol );
    }

    public void On_DialogVolChange()
    {
        int vol = (int)(  m_SliderDialog.value * 100 );
        S_AudioManager.Set_DialogVol( vol );
    }

    #endregion

    #region Settings_Video

    public void VideoSet_Save()
    {
        // TODO: Save settings

        int actualResCount = m_DropdownResolutions.value;

        if(actualResCount < m_Res.Length )
        {
            S_VideoManager.ResolutionWidth = m_Res[ actualResCount ].width;
            S_VideoManager.ResolutionHeight = m_Res[ actualResCount ].height;
            S_VideoManager.ResolutionRefreshRate = m_Res[ actualResCount ].refreshRate;
        }
        else
        {
            S_VideoManager.ResolutionWidth = actualRes.width;
            S_VideoManager.ResolutionHeight = actualRes.height;
            S_VideoManager.ResolutionRefreshRate = actualRes.refreshRate;
        }



        Debug.Log( S_VideoManager.ResolutionWidth );

        S_VideoManager.FullScreen = m_ToggleFullScreen.isOn;
        S_VideoManager.Stats = m_ToggleStats.isOn;

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

    void Start()
    {
        switch( S_SceneManager.CurrentMenu )
        {
            case MenuState.Main:
                break;

            case MenuState.Settings:
                break;

            case MenuState.SettingsAudio:
                break;

            case MenuState.SettingsVideo:
                break;

            case MenuState.SettingsInputs:
                break;

            case MenuState.Credits:
                break;

            case MenuState.GameOver:

                m_Menu.SetActive( false );
                m_GameOver.SetActive( true );
                m_fadeIn = true;
                m_alpha = 0.0f;
                m_canvasRenderer.SetAlpha( m_alpha );

                break;

            default:
                break;
        }
    }

    void Update()
    {
        if ( m_fadeIn )
        {
            m_alpha += 0.8f * Time.deltaTime;
            m_canvasRenderer.SetAlpha( m_alpha );

            if( m_alpha > 1.0f )
                m_fadeIn = false;
        }
    }

    private float m_alpha;
    public CanvasRenderer m_canvasRenderer;
    private bool m_fadeIn;
}
