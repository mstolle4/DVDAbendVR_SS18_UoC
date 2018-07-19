﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class Dvdanimation : MonoBehaviour {

    public GameObject AnimierteDVD;
    static public int szenenauswahl;
    public GameObject Strudelvideo;
    public VideoPlayer Strudel;
    public int timeToStopStrudel;
    public GameObject objToTP;
    public Transform neuePosition;

    static public void SetDvdAuswahl (int value)
    {
        szenenauswahl = value;
    }

    static public int GetAusgewaehlteDVD()
    {
        return szenenauswahl;
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayableDirector pd = AnimierteDVD.GetComponent<PlayableDirector>();
        
        if (pd != null)
        {
            pd.Play();
            SetDvdAuswahl(0);
            /*1408 ist Zimmer 0
             * Dieschone ist Zimmer 1
             * House of Cards ist Zimmer 2
             * EntertheVoid ist Zimmer 3*/
        }

    }
    // Use this for initialization
    void Start () {
		
	}

    // Update is called once per frame
    void Update() {
        
        if (Dvdanimation.GetAusgewaehlteDVD()==0)
        {

                if (Input.GetButtonDown("Fire1"))
                {
                    GameObject[] gameObjectArray = GameObject.FindGameObjectsWithTag("Hintergrundmusik");
                    /*Das Skript transportiert den User in den schwarzen Raum und ändert die Skybox zu schwarz
             * */
                    foreach (GameObject go in gameObjectArray)
                    {
                        go.SetActive(false);
                    }
                    /*setzt Player in den schwarzen Raum*/
                    objToTP.transform.position = neuePosition.transform.position;

                    Strudel.Play();
                    Destroy(Strudel, timeToStopStrudel);
                    StartCoroutine(CoFunktion());
                }
            }
        }
    IEnumerator CoFunktion()
    {
        /*Das Skript lädt den Raum nach Abschluss neu
         * */
        yield return new WaitForSeconds(timeToStopStrudel);
        SceneManager.LoadScene("zimmer1408");
    }
}