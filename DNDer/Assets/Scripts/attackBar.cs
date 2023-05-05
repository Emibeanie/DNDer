using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class attackBar : MonoBehaviour
{
    [SerializeField] GameManagerScript gm;
    [SerializeField] float speed = 1f;
    [SerializeField] float minX ;
    [SerializeField] float maxX ;
    [SerializeField] RectTransform hitter;
    [SerializeField] Button button;
    bool stopped = false;

    private float dir = 1f;

    void Start()
    {
        hitter.anchoredPosition = new Vector2(minX, hitter.anchoredPosition.y);
    }

    void Update()
    {
        if (!stopped) { 
            hitter.anchoredPosition += new Vector2(dir * speed, 0f);
            if (hitter.anchoredPosition.x > maxX || hitter.anchoredPosition.x < minX) dir *= -1f;
        }
    }

    public void Stop()
    {
        stopped = true;
        gm.StrBar(Mathf.Abs((minX + maxX) / 2 - hitter.anchoredPosition.x));
    }
}
