using UnityEngine;
using System.Collections;

public class S_CheatCode : MonoBehaviour
{
    public Transform m_charactTransform;

    void Start ()
    {
        Debug.Log( "Cheat Code Start ..." );
        m_entry = "";
    }
    
    void OnEnable()
    {
        Debug.Log( "Cheat Code Start ..." );
        m_entry = "";
    }

    void Update ()
    {
	    if (Input.GetButtonDown( "Joy0_Kill" ) )
        {
            m_entry += "B";
            m_entryTimer = Time.realtimeSinceStartup + 0.8f;
        }
        
        if( Input.GetButtonDown( "Joy0_A" ) )
        {
            m_entry += "A";
            m_entryTimer = Time.realtimeSinceStartup + 0.8f;
        }

        if ( Input.GetAxis("Joy0_Move_Y") > 0.6f )
        {
            if ( !m_lastUp )
            {
                m_lastUp = true;
                m_entry += "Up";
                m_entryTimer = Time.realtimeSinceStartup + 0.8f;
            }
        }
        else
        {
            m_lastUp = false;
        }
        
        if( Input.GetAxis( "Joy0_Move_Y" ) < -0.6f )
        {
            if( !m_lastDown )
            {
                m_lastDown = true;
                m_entry += "Down";
                m_entryTimer = Time.realtimeSinceStartup + 0.8f;
            }
        }
        else
        {
            m_lastDown = false;
        }
        
        if( Input.GetAxis( "Joy0_Move_X" ) > 0.6f )
        {
            if( !m_lastRight )
            {
                m_lastRight = true;
                m_entry += "Right";
                m_entryTimer = Time.realtimeSinceStartup + 0.8f;
            }
        }
        else
        {
            m_lastRight = false;
        }


        if( Input.GetAxis( "Joy0_Move_X" ) < -0.6f )
        {
            if( !m_lastLeft )
            {
                m_lastLeft = true;
                m_entry += "Left";
                m_entryTimer = Time.realtimeSinceStartup + 0.8f;
            }
        }
        else
        {
            m_lastLeft = false;
        }

        if ( m_entry.Contains( "UpUpDownDownLeftRightLeftRightBA" ) )
        {
            Debug.Log( "Konami Code" );
            m_charactTransform.position = new Vector3( 850.0f, m_charactTransform.position.y, m_charactTransform.position.z);
            m_entry = "";
        }

        if( Time.realtimeSinceStartup > m_entryTimer )
        {
            m_entry = "";
        }
    }

    private bool m_lastLeft;
    private bool m_lastRight;
    private bool m_lastUp;
    private bool m_lastDown;
    private float m_entryTimer;
    private string m_entry; 
}
