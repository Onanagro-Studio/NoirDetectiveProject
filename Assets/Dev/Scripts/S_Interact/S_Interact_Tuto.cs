using UnityEngine;
using System.Collections;

public class S_Interact_Tuto : S_Interact
{
    public S_Enemy_Tuto Enemy;
    public GameObject Tuto_Collider;

    void Start ()
    {
        Interact_Init();
    }

    protected override void On_Interact_Start(Collider _collision)
    {
        m_charact_controller.IsHidden = true;

        m_CharTransform.position = new Vector3( m_CharTransform.position.x, m_SpriteTransform.position.y, m_SpriteTransform.position.z - .1f );
    }

    protected override void On_Interact_Leave(Collider _collision)
    {
        m_charact_controller.IsHidden = false;

        m_CharTransform.position = new Vector3( m_CharTransform.position.x, 3.0f, 0.0f );
    }
}
