using UnityEngine;
using System.Collections;

public class S_Charact_Madness : MonoBehaviour
{
    public static float Madness;

    public bool ControlInverted;
    public bool AxisInverted;

    void Start ()
    {
        Madness = 0.0f;
    }
	
	void Update ()
    {
        if( Madness > 0.0f )
            Madness -= 0.005f * Time.deltaTime;
        if( Madness > 1.0f )
            Madness = 1.0f;

        if( !m_ControleLoose && Madness > 0.8f && Time.realtimeSinceStartup > m_ControleLooseTimer)
            Start_Loose_Control( 8.0f );
        
        if ( m_ControleLoose && Time.realtimeSinceStartup > m_ControleLooseTimer )
        {
            m_ControleLoose = false;
            ControlInverted = false;
            AxisInverted = false;

            m_ControleLooseTimer += Random.Range( 35.0f, 55.0f );
        }
    }

    private void Start_Loose_Control(float _time)
    {
        m_ControleLoose = true;
        m_ControleLooseTimer = Time.realtimeSinceStartup + Random.Range( 4.0f, _time);

        if( RandomBool() )
            ControlInverted = true;
        if( RandomBool() )
            AxisInverted = true;

        Debug.Log( "Loose Control" + ControlInverted + AxisInverted );
    }

    private bool RandomBool()
    {
        return Random.value < .5 ? true : false;
    }

    private bool m_ControleLoose;
    private float m_ControleLooseTimer;
}
