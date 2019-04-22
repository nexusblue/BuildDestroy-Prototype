using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class GameManagerScript : MonoBehaviour
{
    public GameObject builder;
    public GameObject wolf;
    public Text puffText;
    public Slider puffGauge;
    public Canvas builderCanvas;
    public AudioSource builderMusic;
    public AudioSource wolfMusic;


    private void Start()
    {
        wolf.gameObject.SetActive(false);
        puffText.gameObject.SetActive(false);
        puffGauge.gameObject.SetActive(false);
        wolfMusic.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            builder.gameObject.SetActive(false);
            wolf.gameObject.SetActive(true);
            puffText.gameObject.SetActive(true);
            puffGauge.gameObject.SetActive(true);
            builderCanvas.gameObject.SetActive(false);
            wolfMusic.gameObject.SetActive(true);
            builderMusic.gameObject.SetActive(false);
        }
    }
}
