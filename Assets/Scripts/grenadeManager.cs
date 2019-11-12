using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grenadeManager : MonoBehaviour
{
    public bool hide;
    private AudioManager audioManager;
    private bool grenadeSoundPlayed = false;
    // Start is called before the first frame update
    void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();   
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z >= 49)
        {
            if (!grenadeSoundPlayed)
            {
                audioManager.Play("Grenade", false);
                grenadeSoundPlayed = true;
            }
            transform.Translate(0, -50, 0);

        }
    }
}
