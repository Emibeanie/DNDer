using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class damagetestScript : MonoBehaviour
{
    public GameObject dmgText;

    // Update is called once per frame
    void Start()
    {
        DamageNumbersScript indicator = Instantiate(dmgText, transform.position, Quaternion.identity).GetComponent<DamageNumbersScript>();
        indicator.SetDamage(111);
    }
}
