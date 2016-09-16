using UnityEngine;
using System.Collections;

public class S_Fog : MonoBehaviour
{

	void Start ()
    {
        m_transform = GetComponent<Transform>();
        m_cameraTransform = Camera.main.GetComponent<Transform>();
    }
	
	void Update ()
    {
        m_transform.position = new Vector3( m_cameraTransform.position.x, m_transform.position.y, m_transform.position.z );
    }

    private Transform m_transform;
    private Transform m_cameraTransform;
}
