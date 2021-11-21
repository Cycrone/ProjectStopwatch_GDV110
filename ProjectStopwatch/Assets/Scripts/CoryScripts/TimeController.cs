using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeController : MonoBehaviour
{
    public float slowMotionTimeScale = 0.5f;
    public bool slowMotionEnabled = false;
    public float slowMoTime = 0;
    [SerializeField] public GameObject ScreenEffect;
    [SerializeField] public float slowMoTimer = 5;

    [System.Serializable]
    public class AudioSourceData
    {
        public AudioSource audioSource;
        public float defaultPitch;
    }

    AudioSourceData[] audioSources;

    // Start is called before the first frame update
    void Start()
    {
        //Find all AudioSources in the Scene and save their default pitch values
        AudioSource[] audios = FindObjectsOfType<AudioSource>();
        audioSources = new AudioSourceData[audios.Length];

        for (int i = 0; i < audios.Length; i++)
        {
            AudioSourceData tmpData = new AudioSourceData();
            tmpData.audioSource = audios[i];
            tmpData.defaultPitch = audios[i].pitch;
            audioSources[i] = tmpData;
        }

        SlowMotionEffect(slowMotionEnabled);
    }

    void Update()
    {
        //Slowmo activation
        if (Input.GetKeyDown(KeyCode.Q))
        {
            slowMotionEnabled = !slowMotionEnabled;
            SlowMotionEffect(slowMotionEnabled);
            
        }
        if (slowMotionEnabled)
        {
            slowMoTime -= Time.deltaTime;
            ScreenEffect.SetActive(true);
            if (slowMoTime <= 0)
            {
                SlowMotionEffect(false);
                slowMotionEnabled = false;
            }
        }
        else
        {
            if (slowMoTime < slowMoTimer)
            {
                slowMoTime += Time.deltaTime;
                if (slowMoTime > slowMoTimer)
                {
                    slowMoTime = slowMoTimer;
                }
            }
            ScreenEffect.SetActive(false);

        }

    }

    //Time scale and audio distortion/slowmo effect
    void SlowMotionEffect(bool enabled)
    {
        Time.timeScale = enabled ? slowMotionTimeScale : 1;
        for (int i = 0; i < audioSources.Length; i++)
        {
            if (audioSources[i].audioSource)
            {
                audioSources[i].audioSource.pitch = audioSources[i].defaultPitch * Time.timeScale;
            }
        }
    }
}
