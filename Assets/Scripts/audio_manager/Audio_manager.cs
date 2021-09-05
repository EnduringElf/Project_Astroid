using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using System;
using UnityEngine;
using JetBrains.Annotations;

public class Audio_manager : MonoBehaviour
{
    public Sound[] sounds;
    public static Audio_manager instance;


    public GameObject player;
    private Transform playerpos;
    
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(this);

        foreach(Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.audioClip;
            s.source.volume = s.Volume;
            s.source.pitch = s.pitch;
        }
        player = GameObject.FindGameObjectWithTag("Player");
        playerpos = player.transform;
        
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayAstroidSFX(String name, float X, float Y)
    {
        
        Sound s = Array.Find(sounds, Sound => Sound.name == name);
        //s.Volume = FindDistancetoplayer(X, Y);
        //Debug.Log(FindDistancetoplayer(X, Y));
        //s.source.volume = FindDistancetoplayer(X, Y);
        s.source.Play();
    }

    //public float FindDistancetoplayer(float X, float Y)
    //{
    //    float playerX = playerpos.position.x;
    //    float playerZ = playerpos.position.z;
    //    float tempX = 0;
    //    float tempz = 0;
    //    float Distance = 0;
    //    if (playerX > X)
    //    {
    //        tempX = playerX;
    //    }
    //    else
    //    {
    //        tempX = X;
    //    }
    //    if(playerZ > Y)
    //    {
    //        tempz = playerZ;
    //    }
    //    else
    //    {
    //        tempz = Y;
    //    }
    //    Distance = Mathf.Sqrt(tempX * tempX + tempz * tempz);
    //    if(Distance !< 1)
    //    {
    //        return 0;
    //    }
    //    else
    //    {
    //        Distance = (Distance / 100);

    //        return Distance;
    //    }
        


}

