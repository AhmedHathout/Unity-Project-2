using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeButtonManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (FindObjectOfType<FootManManager>().transform.position.z == 6.010013f)
            gameObject.SetActive(true);
    }
}
