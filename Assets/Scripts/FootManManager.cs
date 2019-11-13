using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootManManager : MonoBehaviour
{
    public Animator anim;
    public bool twoGiantsDead;
    private AudioManager audioManager;

    private bool perfomedFirstMeleeAttack = false;
    private bool perfomedSecondMeleeAttack = false;

    // Start is called before the first frame update
    void Start()
    {
        twoGiantsDead = false;
        audioManager = FindObjectOfType<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(twoGiantsDead && FindObjectOfType<Manager>().isAttacking && transform.position.z < 61)
        {
            anim.SetBool("isRunning", true);
            audioManager.Play("Game");
            audioManager.PlaySoundEffect("Run");
            FindObjectOfType<Manager>().meleeButton.SetActive(false);
            transform.Translate(0, 0, .09f);
        }
        if(twoGiantsDead && FindObjectOfType<Manager>().isAttacking && transform.position.z >= 61)
        {
            anim.SetBool("isRunning", false);
            anim.SetTrigger("isAttack");
            audioManager.PlaySoundEffect("Swords");
            FindObjectOfType<Manager>().isAttacking = false;
            anim.SetBool("isWinning", true);
            StartCoroutine(WaitBeforeCelebrating(2.5));

            // TODO Not sure of this line
            audioManager.Play("Game");
        }
        if (transform.position.x == -5.35f && twoGiantsDead && transform.position.z >= 57 && transform.position.z <= 58)
        {
            anim.SetBool("isIdle", true);
            anim.SetBool("isWalking", false);
            audioManager.StopSoundEffect("Walk");
            FindObjectOfType<Manager>().meleeButton.SetActive(true);
            audioManager.Play("Choice");
        }
        if (twoGiantsDead && transform.position.x == 6.65f)
        {
            transform.Translate(-12, 0, 0);
            anim.SetBool("isWalking", true);
            audioManager.PlaySoundEffect("Walk");
            anim.SetBool("isIdle", false);
            FindObjectOfType<Manager>().sideCamera.SetActive(false);
            FindObjectOfType<Manager>().frontCamera.SetActive(false);
            FindObjectOfType<Manager>().mainCamera.SetActive(true);
            audioManager.Play("Game");
        }
        if (twoGiantsDead && transform.position.x == -5.35f && transform.position.z < 57)
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
            audioManager.Play("Game");
            transform.Translate(0, 0, .09f);

            audioManager.PlaySoundEffect("Run");
        }
        else if (FindObjectOfType<Manager>().isGrenade)
        {
            FindObjectOfType<grenadeManager>().transform.Translate(-0.05f, 0, 0.09f);
        }
        else if (transform.position.x == 12.65f && transform.position.z < 58)
        {
            anim.SetBool("isRunning", true);
            audioManager.Play("Game");
            audioManager.PlaySoundEffect("Run");
            transform.Translate(0, 0, .09f);
        }
        else if(transform.position.x == 12.65f && transform.position.z >= 58)
        {
            anim.SetBool("isRunning", false);
        }
        else if(transform.position.x == 6.65f && transform.position.z >= 35 && !FindObjectOfType<Manager>().isGrenade)
        {
            anim.SetBool("isRunning", false);
            audioManager.Play("Choice");
            audioManager.StopSoundEffect("Run");
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
            audioManager.Play("Game");
            audioManager.PlaySoundEffect("Run");

        }
        else if(FindObjectOfType<Manager>().isAttacking && transform.position.x == -5.35f && transform.position.z >= 34){
            anim.SetBool("isRunning", false);
            anim.SetTrigger("isAttack");
            audioManager.PlaySoundEffect("Swords");
            anim.SetBool("isWinning", true);
            FindObjectOfType<Manager>().isAttacking = false;
            StartCoroutine(WaitBeforeCelebrating(2.5));

            // TODO Not sure of this line
            audioManager.Play("Game");
        }
        else if (transform.position.x == -5.35f && transform.position.z <= 26)
        {
            anim.SetBool("isIdle", false);
            audioManager.Play("Game");
            anim.SetBool("isWalking", true);
            audioManager.PlaySoundEffect("Walk");

            transform.Translate(0, 0, .05f);
        }
        else if(transform.position.x == -5.35f && transform.position.z >= 26)
        {
            anim.SetBool("isIdle", true);
            if (!perfomedFirstMeleeAttack)
            {
                audioManager.Play("Choice");
                perfomedFirstMeleeAttack = true;
            }
            anim.SetBool("isWalking", false);
            audioManager.StopSoundEffect("Walk");
        }
        else if (transform.position.z >= 6 && (transform.position.x == 0.65f || transform.position.x == -5.35f) && !FindObjectOfType<Manager>().isAttacking)
        {
            anim.SetBool("isIdle", true);

            if (!perfomedSecondMeleeAttack)
            {
                audioManager.Play("Choice");
                perfomedSecondMeleeAttack = true;
            }
            audioManager.StopSoundEffect("Walk");
        }
        else if(FindObjectOfType<Manager>().isAttacking && transform.position.z >= 13.91f)
        {
            anim.SetBool("isRunning", false);
            anim.SetTrigger("isAttack");
            audioManager.PlaySoundEffect("Swords");
            FindObjectOfType<Manager>().isAttacking = false;
            StartCoroutine("Hide");

            // TODO Not sure of this line
            audioManager.Play("Game");
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

    IEnumerator WaitBeforeCelebrating(double seconds)
    {
        yield return new WaitForSeconds((float) seconds);
        audioManager.PlaySoundEffect("Hero Celebrating");
    }

    IEnumerator WaitBeforeSwordsSoundEffect(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        audioManager.PlaySoundEffect("swords");
    }
}
