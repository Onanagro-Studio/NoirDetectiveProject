using UnityEngine;
using System.Collections;

public class S_Charact_Collision : MonoBehaviour
{
    void Start()
    {
        m_charact = GetComponent<S_Charact_Controller>();
        m_hinted = false;
        m_life = 100.0f;
    }

    void Update()
    {
        if( m_hinted && Time.realtimeSinceStartup > m_hintTimer )
        {
            m_hinted = false;
            m_charact.m_renderLeft.color = Color.white;
            m_charact.m_renderRight.color = Color.white;
        }

        if( m_life < 0 )
            S_SceneManager.Load_GameOver();

        if ( m_life < 100.0f)
            m_life +=  0.005f * Time.deltaTime;
    }

    void OnTriggerEnter(Collider collision)
    {
        //On player Frapped
        if (collision.gameObject.layer == 14 )
        {
            S_Charact_Madness.Madness += 0.05f;

            m_hinted = true;
            m_hintTimer = Time.realtimeSinceStartup + 0.1f;

            m_charact.m_renderLeft.color = Color.red;
            m_charact.m_renderRight.color = Color.red;

            //Damage
            float enemyDamage = collision.GetComponentInParent<S_Enemy_AI_Attack>().Damage;
            m_life -= enemyDamage;

            Debug.Log( "Player is Frapped !" );
        }
    }

    private bool m_hinted;
    private float m_hintTimer;
    private S_Charact_Controller m_charact;
    private float m_life;
}
