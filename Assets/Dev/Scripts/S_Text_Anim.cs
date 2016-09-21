using UnityEngine;
using System.Collections;

public class S_Text_Anim : MonoBehaviour
{
    public float m_speed = 80.0f;

	void Start ()
    {
        m_transform = GetComponent<Transform>();
    }
	
	void Update ()
    {
        m_transform.position += m_transform.up * m_speed * Time.deltaTime;
	}

    private Transform m_transform;
}
