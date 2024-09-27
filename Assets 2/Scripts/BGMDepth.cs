using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMDepth : MonoBehaviour
{
    private GameObject GameSystemObj;
    private DepthMeter DepthScript;
    
    

    public AudioSource audioSource;
    public AudioClip music1;
    public AudioClip music2;
    public AudioClip music3;

    private float currentValue;
    private int currentInterval = -1;

    private Coroutine musicChangeCoroutine;

    public float fadeDuration = 1.0f;

    void Start()
    {
        GameSystemObj = GameObject.FindGameObjectWithTag("GameSystem");
        DepthScript = GameSystemObj.GetComponent<DepthMeter>();
        // Ensure the AudioSource is set
        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
        }
    }

    void Update()
    {
        // This is where you'd set the currentValue based on your game logic
        // For now, let's simulate it with a random value
        currentValue = DepthScript.depthInMeters * -1f;

        UpdateBackgroundMusic(currentValue);
    }

    void UpdateBackgroundMusic(float value)
    {
        int newInterval = DetermineInterval(value);

        if (newInterval != currentInterval && newInterval != 0)
        {
            currentInterval = newInterval;
            if (musicChangeCoroutine != null)
            {
                StopCoroutine(musicChangeCoroutine);
            }
            musicChangeCoroutine = StartCoroutine(ChangeMusicWithFade(newInterval));
        }
    }

    int DetermineInterval(float value)
    {
        if (value >= 0 && value <= 15)
        {
            return 1;
        }
        else if (value >= 21 && value <= 35)
        {
            return 2;
        }
        else if (value >= 41 && value <= 60)
        {
            return 3;
        }
        else
        {
            return 0; // No change
        }
    }

    IEnumerator ChangeMusicWithFade(int interval)
    {
        if (audioSource.isPlaying)
        {
            yield return StartCoroutine(FadeOut(audioSource, fadeDuration));
        }

        switch (interval)
        {
            case 1:
                audioSource.clip = music1;
                break;
            case 2:
                audioSource.clip = music2;
                break;
            case 3:
                audioSource.clip = music3;
                break;
            default:
                yield break;
        }

        audioSource.Play();
        yield return StartCoroutine(FadeIn(audioSource, fadeDuration));
    }

    IEnumerator FadeOut(AudioSource audioSource, float fadeDuration)
    {
        float startVolume = audioSource.volume;

        while (audioSource.volume > 0)
        {
            audioSource.volume -= startVolume * Time.deltaTime / fadeDuration;
            yield return null;
        }

        audioSource.Stop();
        audioSource.volume = startVolume;
    }

    IEnumerator FadeIn(AudioSource audioSource, float fadeDuration)
    {
        audioSource.volume = 0f;
        audioSource.Play();

        while (audioSource.volume < 1.0f)
        {
            audioSource.volume += Time.deltaTime / fadeDuration;
            yield return null;
        }
    }
}
