using UnityEngine;
using System.Collections;

public class S_Interact_Hideout : S_Interact
{
    
   

	void Start ()
    {
        Interact_Init();
    }

    protected override void On_Interact_Start(Collider _collision)
    {
        m_charact_controller.IsHidden = true;

        m_CharSpriteLeftTransform.position = new Vector3( m_CharSpriteLeftTransform.position.x, m_SpriteTransform.position.y, m_SpriteTransform.position.z - .1f );
        m_CharSpriteRightTransform.position = new Vector3( m_CharSpriteRightTransform.position.x, m_SpriteTransform.position.y, m_SpriteTransform.position.z - .1f );
    }

    protected override void On_Interact_Leave(Collider _collision)
    {
        m_charact_controller.IsHidden = false;

        m_CharSpriteLeftTransform.position = new Vector3( m_CharSpriteLeftTransform.position.x, 3.0f, 0.0f );
        m_CharSpriteRightTransform.position = new Vector3( m_CharSpriteRightTransform.position.x, 3.0f, 0.0f );
    }

    
}
