using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPBarScript : MonoBehaviour
{
    [SerializeField] Image HPBar;
    [SerializeField] PlayerScript player;

    float lerpSpeed;

    // Update is called once per frame
    void FixedUpdate()
    {
        lerpSpeed = 3f * Time.deltaTime;
        FillHPBar();
    }
    void FillHPBar()
    {
        HPBar.fillAmount = Mathf.Lerp(HPBar.fillAmount, (float)player.currentHP / (float)player.maxHP, lerpSpeed);
    }
}
