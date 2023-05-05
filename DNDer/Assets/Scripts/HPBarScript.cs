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
        //System.Console.ReadKey(true);
        player.getHit(2);
        player.Heal(1);
    }
    void FillHPBar()
    {
        HPBar.fillAmount = Mathf.Lerp(HPBar.fillAmount, player.currentHP / player.maxHP, lerpSpeed);
    }
}
