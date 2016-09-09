using UnityEngine;
using System.Collections;

public class S_Charact_Madness : MonoBehaviour
{
    public static float Madness;

    public bool ControlInverted;
    public bool AxisInverted;

    public float TimeCrazy_Min = 2.0f, TimeCrazy_Max = 7.0f;
    public float TimeSanity_Min = 40.0f, TimeSanity_Max = 120.0f;

    void Start ()
    {
        Madness = 0.0f;
    }
	
	void Update ()
    {
        Madness = Mathf.Clamp01( Madness );

        if( Madness > 0.0f )
            Madness -= 0.005f * Time.deltaTime;

        //if ( Madness < 0.8f)
        //{
        //    ControlInverted = false;
        //    AxisInverted = false;
        //    m_isCrazy = false;
        //}

        //if( Time.realtimeSinceStartup > m_sanityTimer )
        //{
        //    m_sanityTimer = Time.realtimeSinceStartup + Random.Range( TimeSanity_Min, TimeSanity_Max );
        //}
    }

    private bool RandomBool()
    {
        return Random.value < .5 ? true : false;
    }

    private bool m_isCrazy;
    private bool m_isSain;

    private float m_crazyTimer;
    private float m_sanityTimer;
}
