using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Music_Control : BaseSingletonWithMono<Music_Control>
{
    public AudioSource source;
    public Slider sceneone;
    public Slider scenetwo;
    public List<AudioClip> music = new List<AudioClip>();

    enum Scene { 
        sceneone,
        scene,
    };

    void Start()
    {
        //source = GetComponent<AudioSource>();       
    }

    private void Update()
    {
        Volume();
        Clip();
    }

    private Scene Check()
    {
        Scene scene;

        if(SceneManager.GetActiveScene().buildIndex == 0)
        {
            scene = Scene.sceneone;
        }
        else
        {
            scene = Scene.scene;
        }

        return scene;
    }

    public void Volume()
    {
        if (Check() == Scene.sceneone)
        {
            source.volume = sceneone.value;
        }

        if(Check() == Scene.scene)
        {
            source.volume = scenetwo.value;
        }
    }

    public void PlayVidio()
    {
        source.Play();
    }

    public void Clip()
    {
        if (Check() == Scene.sceneone)
        {
            source.clip = music[0];
        }

        if (Check() == Scene.scene)
        {
            switch (SceneManager.GetActiveScene().buildIndex - 1)
            {
                case 1:
                    source.clip = music[1];
                    break;
                case 2:
                    source.clip = music[2];
                    break;
                case 3:
                    source.clip = music[3];
                    break;
            }
        }
    }
}
