using UnityEngine;
using System.Collections;

public class S_SplashCanvas : MonoBehaviour
{
    public CanvasRenderer m_LogoRenderer;
    public CanvasRenderer m_TechnociteRenderer;
    public float m_SplashSpeed = 0.6f;

    void Start ()
    {
        m_TechnociteRenderer.SetAlpha( 0.0f );
        m_LogoRenderer.SetAlpha( 0.0f );

        m_Technocite = true;
        m_Up = true;
        m_Alpha = -0.5f;
    }
	
	void Update ()
    {
        if( Input.anyKey )
            S_SceneManager.Load_Menu();

        if( m_Up )
        {
            if( m_Alpha < 1.6f )
            {
                m_Alpha += m_SplashSpeed * Time.deltaTime;

                if( m_Technocite )
                    m_TechnociteRenderer.SetAlpha( m_Alpha );
                else
                    m_LogoRenderer.SetAlpha( m_Alpha );
            }
            else
                m_Up = false;
        }
        else
        {
            if( m_Alpha > -0.5f )
            {
                m_Alpha -= m_SplashSpeed * 2 * Time.deltaTime;

                if( m_Technocite )
                    m_TechnociteRenderer.SetAlpha( m_Alpha );
                else
                    m_LogoRenderer.SetAlpha( m_Alpha );
            }
            else
            {
                if( m_Technocite )
                {
                    m_Technocite = false;
                    m_Alpha = 0;
                    m_Up = true;
                }
                else
                    S_SceneManager.Load_Menu();
            
            }
        }
    }

    private float m_Alpha;

    private bool m_Up;
    private bool m_Technocite;
}
