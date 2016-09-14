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
        m_hinted = false;
        m_life = 100.0f;
    }

    void OnGUI()
    {
        GUI.DrawTexture( new Rect( pos.x, pos.y, size.x, size.y ), progressBarEmpty );
        GUI.DrawTexture( new Rect( pos.x, pos.y, size.x * m_life / 100.0f, size.y ), progressBarFull );
    }
    
    void Update()
    {
        if( m_hinted && Time.realtimeSinceStartup > m_hintTimer )
        {
            m_hinted = false;

            //Todo
            //End Hint
            //m_charact.m_renderLeft.color = Color.white;
            //m_charact.m_renderRight.color = Color.white;
        }

        if( m_life < 0 )
            S_SceneManager.Load_GameOver();

        if( m_life < 0.0f )
            m_life = 0.0f;

        if( m_life < 100.0f)
            m_life +=  5f * Time.deltaTime;
    }

    void OnTriggerEnter(Collider collision)
    {
        //On player Frapped
        if (collision.gameObject.layer == 14 )
        {
            S_Charact_Madness.Madness += 0.05f;

            m_hinted = true;
            m_hintTimer = Time.realtimeSinceStartup + 0.1f;

            //Todo Hinted
            //m_charact.m_renderLeft.color = Color.red;
            //m_charact.m_renderRight.color = Color.red;

            //Damage
            float enemyDamage = collision.GetComponentInParent<S_Enemy_AI_Attack>().Damage;
            m_life -= enemyDamage;

            Debug.Log( "Player is Frapped !" );
        }
    }

    private Vector2 pos = new Vector2(20,100);
    private Vector2 size = new Vector2(250,40);

    private bool m_hinted;
    private float m_hintTimer;
    private S_Charact_Controller m_charact;
    private S_Charact_Madness m_madness;
    private float m_life;
}
