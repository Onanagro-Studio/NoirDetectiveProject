using UnityEngine;
using System.Collections;

public class S_Press_A : MonoBehaviour
{
    public S_Charact_Controller m_charactController;
    public CanvasRenderer m_FadeInRenderer;

	void Start ()
    {
        m_alpha = 1.0f;
        m_fadeIn = false;
    }
	
	void Update ()
    {
	    if (Input.GetButtonDown("Joy0_A"))
        {
            this.gameObject.SetActive( false );
            m_charactController.Bloquer = false;
        }

        if ( !m_fadeIn )
        {
            m_alpha -= 1.0f * Time.deltaTime;
            m_FadeInRenderer.SetAlpha( m_alpha );
            
            if( m_alpha < 0.0f )
                m_fadeIn = true;
        }
    }

    private bool m_fadeIn;
    private float m_alpha;
}
