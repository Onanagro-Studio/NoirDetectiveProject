using UnityEngine;
using System.Collections;

public class S_Charact_Collision : MonoBehaviour
{
    public Texture2D progressBarEmpty;
    public Texture2D progressBarFull;

    void Start()
    {
        m_charact = GetComponent<S_Charact_Controller>();
        m_madness = GetComponent<S_Charact_Madness>();
        m_animator = GetComponentInChildren<Animator>();
        m_highlight = GetComponent<S_HighlightObject>();

        m_hinted = false;
        m_isDead = false;
        m_life = 100.0f;
    }

    void OnGUI()
    {
        GUI.DrawTexture( new Rect( pos.x, pos.y, size.x, size.y ), progressBarEmpty );
        GUI.DrawTexture( new Rect( pos.x, pos.y, size.x * m_life / 100.0f, size.y ), progressBarFull );
    }
    
    void Update()
    {
        if ( m_isDead )
        {
            if (Time.realtimeSinceStartup > m_DeadTimer )
                S_SceneManager.Load_GameOver();
        }
        else
        {
            if( m_hinted && Time.realtimeSinceStartup > m_hintTimer )
            {
                m_hinted = false;

                m_highlight.m_HighlightColor = Color.white;
            }
            
            if( m_life < 100.0f && !m_isDead )
                m_life += 5f * Time.deltaTime;
        }
    }

    void OnTriggerEnter(Collider collision)
    {
        //On player Frapped
        if (collision.gameObject.layer == 14 && !m_isDead)
        {
            S_Charact_Madness.Madness += 0.05f;

            m_hinted = true;
            m_hintTimer = Time.realtimeSinceStartup + 0.1f;

            m_highlight.m_HighlightColor = Color.red;

            //Damage
            float enemyDamage = collision.GetComponentInParent<S_Enemy_AI_Attack>().Damage;
            m_life -= enemyDamage;

            if ( m_life > 0 )
            {
                m_animator.SetInteger( "TakeDamage", Random.Range( 0, 2 ) );
                m_animator.SetTrigger( "IsDamaged" );
            }
            else
                Kill();
        }
    }

    private void Kill()
    {
        m_charact.Bloquer = true;

        m_highlight.m_HighlightColor = new Color( 0, 0, 0, 0 );

        m_DeadTimer = Time.realtimeSinceStartup + 2.0f;

        m_isDead = true;
        m_animator.SetTrigger( "IsDead" );
    }

    private Vector2 pos = new Vector2(20,100);
    private Vector2 size = new Vector2(250,40);

    public static bool m_isDead;
    private float m_DeadTimer;

    private S_HighlightObject m_highlight;
    private Animator m_animator;
    private bool m_hinted;
    private float m_hintTimer;
    private S_Charact_Controller m_charact;
    private S_Charact_Madness m_madness;
    public static float m_life;
}
