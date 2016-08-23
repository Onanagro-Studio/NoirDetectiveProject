using UnityEngine;
using System.Collections;

public class S_Interact : MonoBehaviour
{
    
	void Start ()
    {
	    
	}
	
	void Update ()
    {
	    if ( m_CanInteract && Input.GetKeyDown(KeyCode.E))
        {
            //Debug.Log( "Interact" );
            GetComponent<Renderer>().material.color = new Color( 1, 0, 0 );
        }
	}
    
    void OnTriggerEnter(Collider collision)
    {
        m_CanInteract = true;
        GetComponent<Renderer>().material.color = new Color( 1, 1, 1 );
    }

    void OnTriggerExit(Collider collision)
    {
        m_CanInteract = false;
        GetComponent<Renderer>().material.color = new Color( 0, 0, 0 );
    }

    private bool m_CanInteract;
}
