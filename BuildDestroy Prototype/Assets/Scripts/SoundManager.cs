using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip collectSound;
    static AudioSource collectScr;

    public static AudioClip jumpSound;
    static AudioSource jumpSrc;


    // Start is called before the first frame update
    void Start(){

        collectSound = Resources.Load<AudioClip>("Collect");
        collectScr = GetComponent<AudioSource>();

        jumpSound = Resources.Load<AudioClip>("JumpYell");
        jumpSrc = GetComponent<AudioSource>();
    }

    public static void playCollectSound(){
        collectScr.PlayOneShot(collectSound);
    }

    public static void playJumpYell(){
        jumpSrc.PlayOneShot(jumpSound);
    }


}
