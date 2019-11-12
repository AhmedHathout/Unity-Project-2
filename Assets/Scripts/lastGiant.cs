using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lastGiant : MonoBehaviour
{
    public Animator anim;
    public bool appear;
    private AudioManager audioManager;
    // Start is called before the first frame update
    void Start()
    {
        appear = false;
        audioManager = FindObjectOfType<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(FindObjectOfType<FootManManager>().transform.position.z >= 56 && FindObjectOfType<FootManManager>().transform.position.x == 12.65f && !appear)
        {
            transform.position = new Vector3(12.83f, -0.4200754f, 67.45f);
            appear = true;
            FindObjectOfType<Manager>().frontCamera.SetActive(false);
            FindObjectOfType<Manager>().mainCamera.SetActive(false);
            FindObjectOfType<Manager>().sideCamera.SetActive(true);
        }
        if (transform.position.z <= 62.5f)
        {
            anim.SetBool("isRunning", false);
            anim.SetBool("isAttack", true);
            //audioManager.PlaySoundEffect("Swords");
            //StartCoroutine(WaitBeforePlayingSoundEffect(1, "Swords"));
            StartCoroutine(WaitBeforePlayingSoundEffect(2, "Giant Celebrating"));
        }
        else if (FindObjectOfType<FootManManager>().transform.position.z >= 58 && FindObjectOfType<FootManManager>().transform.position.x == 12.65f)
        {
            anim.SetBool("isRunning", true);
            transform.Translate(0, 0, 0.1f);
        }
    }

    public IEnumerator WaitBeforePlayingSoundEffect(int seconds, string soundEffectName)
    {
        yield return new WaitForSeconds(seconds);
        audioManager.PlaySoundEffect(soundEffectName);
    }
}
