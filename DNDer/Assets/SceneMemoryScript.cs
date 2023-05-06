using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneMemoryScript : MonoBehaviour
{
    // Start is called before the first frame update
    public int character_index = 0;
    public LoverScript[] lovers;
    void Start()
    {
        DontDestroyOnLoad(this);
    }
}
