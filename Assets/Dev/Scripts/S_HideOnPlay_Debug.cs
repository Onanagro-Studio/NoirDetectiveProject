using UnityEngine;
using System.Collections;

public class S_HideOnPlay_Debug : MonoBehaviour {

    private MeshRenderer m_Rend;
    
       
    void Awake()
    {
        m_Rend = GetComponent<MeshRenderer>();
        m_Rend.enabled = false;
    }

    
}
