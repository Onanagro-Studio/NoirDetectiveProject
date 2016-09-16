using UnityEngine;
using System.Collections;

public class S_Anim_Loop : MonoBehaviour
{
    public float m_speed = 0.1f;
    public string m_name;
    public int m_repeat = 0;

    public int m_startDelay;
    public float m_fadeInSpeed;

    public float m_fadeOutDelay;
    public float m_fadeOutSpeed;

    public bool m_autoStart;

    void Start ()
    {
        m_renderer = GetComponent<SpriteRenderer>();
        m_sprites = Resources.LoadAll<Sprite>( m_name );

        if (m_autoStart )
            Restart();
        else
            SetActive( false );
    }

    public void Restart()
    {
        m_frame = 0;

        if( m_fadeInSpeed != 0 )
        {
            m_fadeIn = true;
            m_alpha = 0;
            m_renderer.color = new Color( 1, 1, 1, m_alpha );
        }

        if( m_fadeOutSpeed != 0 )
        {
            m_fadeOut = true;
            m_alpha = 1.0f;
        }

        m_delayCount = 0;

        SetActive( true );
    }
	
	void Update ()
    {
        if ( m_active )
        {
            if( m_delayCount > m_startDelay )
            {
                if( m_fadeIn )
                {
                    m_alpha += m_fadeInSpeed;
                    m_renderer.color = new Color( 1, 1, 1, m_alpha );

                    if( m_alpha > 1 )
                        m_fadeIn = false;
                }

                if( Time.realtimeSinceStartup > m_frameTimer )
                {
                    m_frame++;

                    if( m_frame >= m_sprites.Length )
                    {
                        m_count++;
                        m_frame = 0;

                        if( m_count >= m_repeat && m_repeat != 0 )
                        {
                            
                        }
                    }

                    m_renderer.sprite = m_sprites[ m_frame ];
                    m_frameTimer = Time.realtimeSinceStartup + m_speed;
                }

            }

            if( m_fadeOut && m_delayCount > m_fadeOutDelay )
            {
                m_alpha -= m_fadeOutSpeed;
                m_renderer.color = new Color( 1, 1, 1, m_alpha );

                if( m_alpha < 0 )
                    m_fadeOut = false;
            }

            m_delayCount++;
        }
    }

    private void SetActive(bool _active)
    {
        m_active = _active;
        m_renderer.enabled = _active;
    }

    private int m_delayCount;

    private float m_alpha;
    private bool m_fadeIn;
    private bool m_fadeOut;

    private bool m_active;
    private Sprite [] m_sprites;
    private int m_count;
    private int m_frame;
    private float m_frameTimer;
    private SpriteRenderer m_renderer;
}
