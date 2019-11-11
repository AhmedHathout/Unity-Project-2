using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiantManager : MonoBehaviour
{
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (FindObjectOfType<SpearManager>().hitted && FindObjectOfType<FootManManager>().transform.position.x==0.65f)
        {
            anim.SetBool("isHitted", true);
            FindObjectOfType<SpearManager>().hitted = false;
        }
    }
}
