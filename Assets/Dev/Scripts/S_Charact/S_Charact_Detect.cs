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
    }
    
    public S_Enemy_AI m_AI;
}
