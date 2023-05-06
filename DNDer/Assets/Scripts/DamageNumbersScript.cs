using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DamageNumbersScript : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI txt;
    [SerializeField] float lifeTime = 0.6f;
    [SerializeField] float minDist = 2f;
    [SerializeField] float maxDist = 2f;

    private Vector3 iniPos;
    private Vector3 targetPos;
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        transform.LookAt(2 * transform.position - Camera.main.transform.position);
        float dir = Random.rotation.eulerAngles.z;
        iniPos = transform.position;
        float dist = Random.Range(minDist, maxDist);
        targetPos = iniPos + (Quaternion.Euler(0, 0, dir) * new Vector3(dist, dist, 0f));
        transform.localPosition = Vector3.zero;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        timer += Time.deltaTime;
        float fraction = lifeTime / 2;
        if (timer > lifeTime) Destroy(gameObject);
        else if (timer > fraction)
        {
            txt.color = Color.Lerp(txt.color, Color.clear, (timer - fraction) / (lifeTime - fraction));
        }

        transform.position = Vector3.Lerp(iniPos, targetPos, Mathf.Sin(timer / lifeTime));
        transform.localScale = Vector3.Lerp(Vector3.zero, Vector3.one, Mathf.Sin(timer / lifeTime));
    }
    public void SetDamageText(int dmg)
    {
        txt.text = "100";
        txt.color = Color.red;
        //txt.text = dmg.ToString();
    }
}
