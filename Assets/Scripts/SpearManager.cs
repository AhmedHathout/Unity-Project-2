using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearManager : MonoBehaviour
{
    public bool hitted;
    // Start is called before the first frame update
    void Start()
    {
        hitted = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z >= 14)
            hitted = true;
        else
            hitted = false;
    }
}
