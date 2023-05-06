using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPBarScript : MonoBehaviour
{
    [SerializeField] Image HPBar;
    GameManagerScript gm;

    float lerpSpeed;

    private void Start()
    {
        gm = GameObject.FindObjectOfType<GameManagerScript>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        lerpSpeed = 3f * Time.deltaTime;
        FillHPBar();
    }
    void FillHPBar()
    {
        HPBar.fillAmount = Mathf.Lerp(HPBar.fillAmount, (float)gm.player.currentHP / (float)gm.player.maxHP, lerpSpeed);
    }
}
