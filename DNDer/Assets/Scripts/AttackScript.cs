using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackScript : MonoBehaviour
{
    public bool onPlayer = true;
    public int dmg = 0;
    public string animationTrigger = "attack";

    public virtual void effect(CharacterScript target)
    {
        return;
    }
}

