using UnityEngine;
using System.Collections;

public class S_Charact_Collision : MonoBehaviour
{
    void Start()
    {
        m_charact = GetComponent<S_Charact_Controller>();
        m_hinted = false;
    }

    void Update()
    {
        if( m_hinted && Time.realtimeSinceStartup > m_hintTimer )
        {
            m_hinted = false;
            m_charact.m_renderLeft.color = Color.white;
            m_charact.m_renderRight.color = Color.white;
        }
    }

    void OnTriggerEnter(Collider collision)
    {
        //On player Frapped
        if (collision.gameObject.layer == 14 )
        {
            S_MadnessBar.progress += 0.05f;

            m_hinted = true;
            m_hintTimer = Time.realtimeSinceStartup + 0.1f;

            m_charact.m_renderLeft.color = Color.red;
            m_charact.m_renderRight.color = Color.red;

            Debug.Log( "Player is Frapped !" );
        }
    }

    private bool m_hinted;
    private float m_hintTimer;
    private S_Charact_Controller m_charact;
}
