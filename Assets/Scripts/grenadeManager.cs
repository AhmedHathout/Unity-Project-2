using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grenadeManager : MonoBehaviour
{
    public bool hide;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z >= 49)
            transform.Translate(0, -50, 0);
    }
}
