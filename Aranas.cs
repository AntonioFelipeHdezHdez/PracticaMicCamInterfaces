using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aranas : MonoBehaviour
{
    private GameObject zombie;
    bool mover = false;
    bool dentro = false;
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        Sillas.OnZombieCercaSilla += MoverAranas;
        ObjectController.OnTablonMirado += AlejarAranas;

        zombie = GameObject.FindWithTag("Zombie");
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        // mover aranas a zombie
        if (mover)
        {
            Vector3 direccion = GameObject.Find("Zombie").transform.position - this.transform.position;
            this.transform.position += direccion.normalized * Time.deltaTime * 2.0f;
        }

        // PRACTICA MICROFONO Y CAMARA
        // añadimos un audiosurce a las arañas, importamos los sonidos del aula virtual y más este código funciona
        if (Vector3.Distance(zombie.transform.position, transform.position) < 2.0f && dentro == false)
        {
            audioSource.Play();
            Debug.Log("Audio funciona");
            dentro = true;
        } else if (Vector3.Distance(zombie.transform.position, transform.position) > 2.0f)
        {
            dentro = false;
        }

    }

    private void MoverAranas()
    {
        mover = true;
    }

    private void AlejarAranas()
    {
        Vector3 direccion = GameObject.Find("Zombie").transform.position - this.transform.position;
        this.transform.position -= direccion.normalized * 2.0f;
    }
}
