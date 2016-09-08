using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class S_InputManager : MonoBehaviour
{
    public static List<string> m_connectedController;

	void Start ()
    {
        m_connectedController = new List<string>();
        CheckJoystickState();
    }

    void Update()
    {
        if ( Time.realtimeSinceStartup > m_updatetimer )
            CheckJoystickState();
    }

    private void CheckJoystickState()
    {
        string[] joystick_names = Input.GetJoystickNames();
        int lenght = m_connectedController.Count;

        m_connectedController = new List<string>();
        
        for( int i = 0; i < joystick_names.Length; i++ )
        {
            if ( joystick_names[ i ] != "")
            {
                if( i > lenght - 1 )
                    OnJoystickAdd( joystick_names[ i ] );

                m_connectedController.Add( joystick_names[ i ] );
            }
        }

        if( m_connectedController.Count < lenght )
            OnJoystickRemove();

        m_updatetimer = Time.realtimeSinceStartup + 1.5f;
    }

    private void OnJoystickAdd(string _name)
    {
        Debug.Log( "S_InpuManager: " + _name + " added !" );
    }
    
    private void OnJoystickRemove()
    {
        Debug.Log( "S_InpuManager: a joystick have been removed !" );
    }

    float m_updatetimer;
}
