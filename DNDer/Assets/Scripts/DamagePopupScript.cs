using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DamagePopupScript : MonoBehaviour
{
    [SerializeField] Animator fadeAnimation;
    [SerializeField] TextMeshProUGUI popText;
    [SerializeField] private float duration; 
    public GameObject prefab;

    public void ShowDamageText(float damage, Vector3 position)
    {
        //popText.enabled = true;
        float startTime = Time.time;
        fadeAnimation.SetBool("isHit", true);
        popText.text = "-" + damage.ToString();
        // Convert the world position to a screen position
        Vector2 screenPoint = RectTransformUtility.WorldToScreenPoint(Camera.main, position);

        // Convert the screen position to a position relative to the canvas
        RectTransform canvasRectTransform = popText.canvas.GetComponent<RectTransform>();
        Vector2 canvasPoint;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasRectTransform, screenPoint, null, out canvasPoint);

        // Set the UI element's position
        popText.rectTransform.anchoredPosition = canvasPoint;

        fadeAnimation.Play("AnimDamageText");
        //if (Time.time - startTime < duration) fadeAnimation.StopPlayback();
        fadeAnimation.SetBool("isHit", false);

        //popText.enabled = false;
        //StartCoroutine(FadeOut());
    }

}
