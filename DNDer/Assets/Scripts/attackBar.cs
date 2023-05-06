using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class attackBar : MonoBehaviour
{
    [SerializeField] GameManagerScript gm;
    [SerializeField] float speed = 1f;
    [SerializeField] float minY ;
    [SerializeField] float maxY ;
    [SerializeField] RectTransform hitter;
    [SerializeField] Button button;

    [SerializeField] Sprite attackHitter;
    [SerializeField] Sprite defendHitter;
    [SerializeField] Color attackColor;
    [SerializeField] Color defendColor;
    public bool stopped = false;

    private float dir = 1f;

    void Start()
    {
        hitter.anchoredPosition = new Vector2(hitter.anchoredPosition.x, minY);

    }
    private void OnEnable()
    {
        stopped = false;
        button.enabled = true;
        if (gm.isAttacking())
        {
            button.GetComponent<Image>().color = attackColor;
            hitter.GetComponent<Image>().sprite = attackHitter;
            button.GetComponentInChildren<TextMeshProUGUI>().text = "HIT";
        }
        else
        {
            button.GetComponent<Image>().color = defendColor;
            hitter.GetComponent<Image>().sprite = defendHitter;
            button.GetComponentInChildren<TextMeshProUGUI>().text = "BLOCK";
        }
    }

    void Update()
    {
        if (!stopped) { 
            hitter.anchoredPosition += new Vector2(0f, dir * speed);
            if (hitter.anchoredPosition.y > maxY || hitter.anchoredPosition.y < minY) dir *= -1f;
        }
    }

    public void Stop()
    {
        stopped = true;
        button.enabled = false;
        gm.StrBar(Mathf.Abs((minY + maxY) / 2 - hitter.anchoredPosition.y) / (maxY-minY));
    }

    
}
