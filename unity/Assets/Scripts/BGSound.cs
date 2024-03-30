using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BGSound : MonoBehaviour
{
    //private static BGSound instance = null;
    public static BGSound instance;
    public AudioSource Audio;


    void Awake(){
        if(instance != null && instance != this){
            Destroy(this.gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(this);

    }

    private void Start(){
        Audio = GetComponent<AudioSource>();
    }
}
