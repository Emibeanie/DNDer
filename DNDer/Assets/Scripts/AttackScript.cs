using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackScript : MonoBehaviour
{
    public bool onPlayer = true;
    public int dmg = 0;

    public virtual void effect(CharacterScript target)
    {
        Debug.Log("effect");
        target.getHit(dmg);
        return;
    }
}

