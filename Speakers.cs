using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speakers : MonoBehaviour
{
    private AudioSource audioSource;
    private bool MicrofonoEncendido = false;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (MicrofonoEncendido == false)
            {
                Grabar();
            }
            else
            {
                Reproducir();
            }
        }
    }

    void Grabar()
    {
        audioSource.Stop();
        audioSource.clip = Microphone.Start(null, false, 10, 44100);
        MicrofonoEncendido = true;
    }

    void Reproducir()
    {
        Microphone.End(null);
        Debug.Log("Audio funciona");
        audioSource.Play();
        MicrofonoEncendido = false;
    }
}
