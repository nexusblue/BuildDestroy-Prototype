using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioControl : MonoBehaviour
{

    public static AudioClip collectSound;
    static AudioSource collectScr;

    public static AudioClip gunSound;
    static AudioSource gunScr;

    // Start is called before the first frame update
    void Start()
    {
        collectSound = Resources.Load<AudioClip>("PowerUpSFX2");
        collectScr = GetComponent<AudioSource>();

        gunSound = Resources.Load<AudioClip>("GunshotSFX2");
        gunScr = GetComponent<AudioSource>();

    }

    public static void playCollectSound() {
        collectScr.PlayOneShot(collectSound);
    }

    public static void playGunSound(){
        gunScr.PlayOneShot(gunSound);
    }



    }
