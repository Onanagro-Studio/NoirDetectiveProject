using UnityEngine;
using System.Collections;
using HighlightingSystem;

public class S_Interact_SafeZone : S_Interact
{

	void Start ()
    {
        Interact_Init();
    }

    protected override void On_Interact_Start(Collider _collision)
    {
        S_MadnessBar.progress = 0.0f;
    }

    protected override void On_Interact_Leave(Collider _collision)
    {

    }
}
