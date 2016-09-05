using UnityEngine;
using System.Collections;

public class S_Interact_Garbage : S_Interact
{
    
	void Start ()
    {
        Interact_Init();
    }

    protected override void On_Interact_Start(Collider _collision)
    {
        m_charact_controller.IsHidden = true;
    }

    protected override void On_Interact_Leave(Collider _collision)
    {
        m_charact_controller.IsHidden = false;
    }
}
