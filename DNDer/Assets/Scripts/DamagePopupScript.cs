using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DamagePopupScript : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI popText;
    public GameObject prefab;

    public void ShowDamageText(float damage, Vector3 position)
    {
        popText.text = "-" + damage.ToString();
        popText.rectTransform.position = position;
        //Canvas canvas = GameObject.FindWithTag("Bars and Damage Canvas").GetComponent<Canvas>();
        //Debug.Log("Canvas: " + canvas.name);
        //if (canvas != null && prefab != null)
        //{
        //    // Instantiate the damage text prefab as a child of the Canvas
        //    DamagePopupScript damagePopup = Instantiate(prefab, canvas.transform).GetComponent<DamagePopupScript>();
        //    damagePopup.transform.position = position;

        //    // Set the damage text content
        //    damagePopup.GetComponent<TextMeshProUGUI>().SetText("-" + damage.ToString());
        
    }
}
