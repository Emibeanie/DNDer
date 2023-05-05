using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class attackBar : MonoBehaviour
{
    [SerializeField] float speed = 1f;
    [SerializeField] float minX ;
    [SerializeField] float maxX ;
    [SerializeField] RectTransform hitter;
    [SerializeField] Button button;
<<<<<<< HEAD

    [SerializeField] Sprite attackHitter;
    [SerializeField] Sprite defendHitter;
    [SerializeField] Color attackColor;
    [SerializeField] Color defendColor;
    public bool stopped = false;
=======
    bool stopped = false;
>>>>>>> parent of cd952df (Merge branch 'Sharron' into emily)

    private float dir = 1f;

    void Start()
    {
<<<<<<< HEAD
        hitter.anchoredPosition = new Vector2(hitter.anchoredPosition.x, minY);

    }
    private void OnEnable()
    {
        stopped = false;
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
=======
        hitter.anchoredPosition = new Vector2(minX, hitter.anchoredPosition.y);
>>>>>>> parent of cd952df (Merge branch 'Sharron' into emily)
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
    }
}
