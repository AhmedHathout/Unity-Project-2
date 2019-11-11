using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public bool isAttacking;
    public GameObject meleeButton;
    public GameObject skeleton;
    public GameObject runButton;
    public GameObject giant;
    public GameObject giant1;
    public GameObject lastGiant;
    public GameObject grenadeButton;
    public GameObject grenadeObject;
    public GameObject lastSkeleton;
    public GameObject mainCamera;
    public GameObject sideCamera;
    public GameObject frontCamera;
    public bool isGrenade;
    // Start is called before the first frame update
    void Start()
    {
        mainCamera.SetActive(true);
        sideCamera.SetActive(false);
        frontCamera.SetActive(false);
        isAttacking = false;
        meleeButton.SetActive(false);
        skeleton.SetActive(false);
        lastSkeleton.SetActive(false);
        runButton.SetActive(false);
        giant.SetActive(false);
        grenadeButton.SetActive(false);
        grenadeObject.SetActive(false);
        giant1.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(FindObjectOfType<FootManManager>().transform.position.z >= 19 && FindObjectOfType<FootManManager>().transform.position.x == 6.65f){
            giant.SetActive(true);
            giant1.SetActive(true);
        }
        if ((FindObjectOfType<FootManManager>().transform.position.z >= 6 && FindObjectOfType<FootManManager>().transform.position.z < 6.1 && FindObjectOfType<FootManManager>().transform.position.x == 0.65f) || (FindObjectOfType<FootManManager>().transform.position.z == 26.02988f))
        {
            meleeButton.SetActive(true);
            if(FindObjectOfType<FootManManager>().transform.position.x==0.65f)
                runButton.SetActive(true);
        }
        else if (FindObjectOfType<FootManManager>().transform.position.z >= 14 && FindObjectOfType<FootManManager>().transform.position.x == -5.35f)
        {
            if (FindObjectOfType<FootManManager>().transform.position.z > 26.5f)
                meleeButton.SetActive(false);
            if (!FindObjectOfType<FootManManager>().twoGiantsDead)
                skeleton.SetActive(true);
            else
                lastSkeleton.SetActive(true);
        }
        else
        {
            meleeButton.SetActive(false);
            runButton.SetActive(false);
            grenadeButton.SetActive(false);
        }
    }

    public void meleeAttack()
    {
        isAttacking= true;
        mainCamera.SetActive(false);
        frontCamera.SetActive(false);
        sideCamera.SetActive(true);
    }
    public void run()
    {
        FindObjectOfType<FootManManager>().transform.Translate(6, 0, 0);
        mainCamera.SetActive(false);
        sideCamera.SetActive(false);
        frontCamera.SetActive(true);
    }

    public void grenade()
    {
        grenadeObject.SetActive(true);
        runButton.SetActive(false);
        grenadeButton.SetActive(false);
        isGrenade = true;
        FindObjectOfType<grenadeManager>().transform.position = new Vector3(7.69f, 1.01f, 37);
        mainCamera.SetActive(false);
        frontCamera.SetActive(false);
        sideCamera.SetActive(true);
    }
}
