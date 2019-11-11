using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootManManager : MonoBehaviour
{
    public Animator anim;
    public bool twoGiantsDead;
    // Start is called before the first frame update
    void Start()
    {
        twoGiantsDead = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(twoGiantsDead && FindObjectOfType<Manager>().isAttacking && transform.position.z < 61)
        {
            anim.SetBool("isRunning", true);
            FindObjectOfType<Manager>().meleeButton.SetActive(false);
            transform.Translate(0, 0, .09f);
        }
        if(twoGiantsDead && FindObjectOfType<Manager>().isAttacking && transform.position.z >= 61)
        {
            anim.SetBool("isRunning", false);
            anim.SetTrigger("isAttack");
            FindObjectOfType<Manager>().isAttacking = false;
            anim.SetBool("isWinning", true);
        }
        if(transform.position.x == -5.35f && twoGiantsDead && transform.position.z >= 57 && transform.position.z <= 58)
        {
            anim.SetBool("isIdle", true);
            anim.SetBool("isWalking", false);
            FindObjectOfType<Manager>().meleeButton.SetActive(true);
        }
        if (twoGiantsDead && transform.position.x == 6.65f)
        {
            transform.Translate(-12, 0, 0);
            anim.SetBool("isWalking", true);
            anim.SetBool("isIdle", false);
            FindObjectOfType<Manager>().sideCamera.SetActive(false);
            FindObjectOfType<Manager>().frontCamera.SetActive(false);
            FindObjectOfType<Manager>().mainCamera.SetActive(true);
        }
        if(twoGiantsDead && transform.position.x == -5.35f && transform.position.z < 57)
        {
            transform.Translate(0, 0, .05f);
        }
        if (FindObjectOfType<lastGiant>().transform.position.z <= 62.5)
        {
            StartCoroutine("die");
        }
        if(transform.position.x== 6.65f && transform.position.z < 35)
        {
            anim.SetBool("isRunning", true);
            transform.Translate(0, 0, .09f);
        }
        else if (FindObjectOfType<Manager>().isGrenade)
        {
            FindObjectOfType<grenadeManager>().transform.Translate(-0.05f, 0, 0.09f);
        }
        else if (transform.position.x == 12.65f && transform.position.z < 58)
        {
            anim.SetBool("isRunning", true);
            transform.Translate(0, 0, .09f);
        }
        else if(transform.position.x == 12.65f && transform.position.z >= 58)
        {
            anim.SetBool("isRunning", false);
        }
        else if(transform.position.x == 6.65f && transform.position.z >= 35 && !FindObjectOfType<Manager>().isGrenade)
        {
            anim.SetBool("isRunning", false);
            FindObjectOfType<Manager>().runButton.SetActive(true);
            FindObjectOfType<Manager>().grenadeButton.SetActive(true);
            FindObjectOfType<Manager>().frontCamera.SetActive(false);
            FindObjectOfType<Manager>().sideCamera.SetActive(false);
            FindObjectOfType<Manager>().mainCamera.SetActive(true);
        }
        else if ((FindObjectOfType<Manager>().isAttacking && transform.position.z < 13.91f) || (FindObjectOfType<Manager>().isAttacking && transform.position.x == -5.35f && transform.position.z < 34))
            {
                anim.SetBool("isRunning", true);
                transform.Translate(0, 0, .09f);
            }
        else if(FindObjectOfType<Manager>().isAttacking && transform.position.x == -5.35f && transform.position.z >= 34){
            anim.SetBool("isRunning", false);
            anim.SetTrigger("isAttack");
            anim.SetBool("isWinning", true);
            FindObjectOfType<Manager>().isAttacking = false;
        }
        else if (transform.position.x == -5.35f && transform.position.z <= 26)
        {
            anim.SetBool("isIdle", false);
            anim.SetBool("isWalking", true);
            transform.Translate(0, 0, .05f);
        }
        else if(transform.position.x == -5.35f && transform.position.z >= 26)
        {
            anim.SetBool("isIdle", true);
            anim.SetBool("isWalking", false);
        }
        else if (transform.position.z >= 6 && (transform.position.x == 0.65f || transform.position.x == -5.35f) && !FindObjectOfType<Manager>().isAttacking)
        {
            anim.SetBool("isIdle", true);
        }
        else if(FindObjectOfType<Manager>().isAttacking && transform.position.z >= 13.91f)
        {
            anim.SetBool("isRunning", false);
            anim.SetTrigger("isAttack");
            FindObjectOfType<Manager>().isAttacking = false;
            StartCoroutine("Hide");
        }
        else transform.Translate(0, 0, .05f);
    }

    IEnumerator Hide()
    {
        yield return (new WaitForSeconds(4));
        transform.Translate(-6, 0, 0);
        FindObjectOfType<Manager>().sideCamera.SetActive(false);
        FindObjectOfType<Manager>().frontCamera.SetActive(false);
        FindObjectOfType<Manager>().mainCamera.SetActive(true);
    }

    IEnumerator die()
    {
        yield return (new WaitForSeconds(1));
        anim.SetBool("isHit", true);
    }

}
