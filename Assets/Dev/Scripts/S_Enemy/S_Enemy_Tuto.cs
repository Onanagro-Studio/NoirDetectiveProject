using UnityEngine;
using System.Collections;

public class S_Enemy_Tuto : MonoBehaviour
{
    public S_Charact_Controller Charact_Controller;
    public GameObject FlagPool;
    public bool m_goLeft;

    void Start ()
    {
        m_transform = GetComponent<Transform>();
        m_body = GetComponent<Rigidbody>();
        m_charactTransform = Charact_Controller.GetComponent<Transform>();
        m_enemy = GetComponent<S_Enemy>();
    }
	
	void Update ()
    {
        if( m_goLeft )
        {
            m_body.velocity = new Vector3( -5.0f, 0 );
            m_enemy.SetDirection( EnemyDirection.Left );
            Charact_Controller.Bloquer = true;

            if( transform.position.x < 0 )
            {
                Destroy( this.gameObject );
                Charact_Controller.Bloquer = false;
            }
        }
    }

    private S_Enemy m_enemy;
    private Transform m_transform;
    private Rigidbody m_body;
    private Transform m_charactTransform;
    private float m_lastX;
}
