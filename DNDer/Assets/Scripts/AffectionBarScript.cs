using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class AffectionBarScript : MonoBehaviour
{
    [SerializeField] Image affBar;
    GameManagerScript gm;

    float lerpSpeed;

    // Update is called once per frame

    private void Start()
    {
        gm = GameObject.FindObjectOfType<GameManagerScript>();
    }

    void FixedUpdate()
    {
        lerpSpeed = 3f * Time.deltaTime;
        FillAffBar();
    }
    void FillAffBar()
    {
        affBar.fillAmount = Mathf.Lerp(affBar.fillAmount, (float)gm.lover.affection / (float)gm.lover.maxAffection, lerpSpeed);
    }
}
