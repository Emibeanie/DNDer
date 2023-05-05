using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class AffectionBarScript : MonoBehaviour
{
    [SerializeField] Image affBar;
    [SerializeField] LoverScript lover;

    float lerpSpeed;

    // Update is called once per frame
    void FixedUpdate()
    {
        lerpSpeed = 3f * Time.deltaTime;
        FillAffBar();
    }
    void FillAffBar()
    {
        affBar.fillAmount = Mathf.Lerp(affBar.fillAmount, lover.affection / lover.maxAffection, lerpSpeed);
    }
}
