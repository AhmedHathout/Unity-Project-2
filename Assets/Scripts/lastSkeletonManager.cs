using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lastSkeletonManager : MonoBehaviour
{
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (FindObjectOfType<FootManManager>().transform.position.z >= 61 && FindObjectOfType<FootManManager>().transform.position.x == -5.35f)
        {
            StartCoroutine("Hide");
        }
    }
    IEnumerator Hide()
    {
        yield return (new WaitForSeconds(1.5f));
        anim.SetBool("isDamage", true);
    }
}
