using UnityEngine;
using System.Collections;

public class S_Interact_Building : S_Interact
{
    //[HideInInspector]
    public GameObject m_PortalTop, m_PortalBottom;

    void Start()
    {
        Interact_Init();

        m_PortalTopTransform = m_PortalTop.GetComponent<Transform>();
        m_PortalBottomTransform = m_PortalBottom.GetComponent<Transform>();
    }

    protected override void On_Interact_Start( Collider _collision )
    {
        m_charact_controller.IsHidden = true;

        if( m_CharTransform.position.z > m_PortalTopTransform.position.z )
        {
            m_CharTransform.position = new Vector3( m_CharTransform.position.x, m_CharTransform.position.y, m_PortalTopTransform.position.z );

            m_charact_controller.m_highlight.m_HighlightColor = new Color( 0, 0, 0, 0 );
        }
        else if( m_CharTransform.position.z < m_PortalBottomTransform.position.z )
        {
            m_CharTransform.position = new Vector3( m_CharTransform.position.x, m_CharTransform.position.y, m_PortalBottomTransform.position.z );

            m_charact_controller.m_highlight.m_HighlightColor = new Color( 1, 1, 1, 1 );
        }
    }

    protected override void On_Interact_Leave( Collider _collision )
    {
        m_charact_controller.IsHidden = false;
    }

    public Transform m_PortalTopTransform, m_PortalBottomTransform;
}
