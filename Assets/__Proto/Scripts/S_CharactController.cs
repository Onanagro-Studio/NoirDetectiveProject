using UnityEngine;
using System.Collections;

public class S_CharactController : MonoBehaviour
{
    
	void Start ()
    {
        m_transform = GetComponent<Transform>();
    }
	
	void Update ()
    {
        float dx = Input.GetAxis( "Horizontal" );

        m_transform.position += new Vector3( -dx, 0.0f, 0.0f ) * Time.deltaTime * 10.0f;

        if( dx > 0.0f )
            m_transform.localScale = new Vector3( -1.0f, 1, 1 );
        if( dx < 0.0f )
            m_transform.localScale = new Vector3( 1.0f, 1, 1 );
    }

    private Transform m_transform;
}
