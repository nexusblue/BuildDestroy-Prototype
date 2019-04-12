using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThirdPersonController : MonoBehaviour
{

    public float speed;
    //private Animator anim;
    public float bulletSpd = 100;
    public float runMultiplier = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        //anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();
        //PlayerShoot();
    }

    private void PlayerShoot()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //AudioControl.playGunSound();
            transform.LookAt(GameObject.FindGameObjectWithTag("Player").transform.position);
            GameObject projectile = Instantiate(Resources.Load("PlayerBullet"), transform.position, transform.rotation) as GameObject;
            projectile.GetComponent<Rigidbody>().AddForce(transform.forward * bulletSpd);
        }
    }

    private void PlayerMove()
    {

        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");
        if (ver > 0 && Input.GetKeyDown(KeyCode.LeftShift)) {
            Vector3 playerMovement = new Vector3(hor, 0f, ver) * speed * Time.deltaTime * runMultiplier;
            transform.Translate(playerMovement, Space.Self);
            //anim.SetFloat("Blend", 1);
        }
        else if (ver > 0) {
            Vector3 playerMovement = new Vector3(hor, 0f, ver) * speed * Time.deltaTime;
            transform.Translate(playerMovement, Space.Self);
            //anim.SetFloat("Blend", 1);
        }
        else {
            //anim.SetFloat("Blend", 0);
        }

    }



}
