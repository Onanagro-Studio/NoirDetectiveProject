using UnityEngine;
using System.Collections;

public class S_Charact_Detect : MonoBehaviour
{
    
	void Start ()
    {

    }
    
    void OnTriggerEnter(Collider collision)
    {
        m_AI = collision.gameObject.GetComponent<S_Enemy_AI>();
        m_enemy = collision.gameObject.GetComponent<S_Enemy>();
    }
    
    public S_Enemy_AI m_AI;
    public S_Enemy m_enemy;
}
