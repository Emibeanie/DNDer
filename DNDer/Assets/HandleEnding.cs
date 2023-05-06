using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HandleEnding : MonoBehaviour
{
    SceneMemoryScript sm;
    public SpriteRenderer drakonica;
    public SpriteRenderer princeLeo;
    public SpriteRenderer karen;
    // Start is called before the first frame update
    void Start()
    {
        sm = GameObject.FindAnyObjectByType<SceneMemoryScript>();
        string loverName = sm.lovers[sm.character_index].name;
        switch(loverName)
        {
            case "Drakonica":
                drakonica.gameObject.SetActive(true);
                break;
            case "Prince Leo":
                princeLeo.gameObject.SetActive(true);
                break;
            case "Karen":
                karen.gameObject.SetActive(true);
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
