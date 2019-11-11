using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class twoGiantsManager : MonoBehaviour
{
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (FindObjectOfType<Manager>().isGrenade)
        {
            StartCoroutine("die");
        }
    }
    IEnumerator die()
    {
        yield return (new WaitForSeconds(2f));
        anim.SetBool("isHitted", true);
        FindObjectOfType<FootManManager>().twoGiantsDead = true;
    }
}
