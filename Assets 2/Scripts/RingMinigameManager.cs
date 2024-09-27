using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;
using UnityEngine.UI;

public class RingMinigameManager : MonoBehaviour
{
    public GameObject ringPrefab;
    public float ringStartSize = 2f; // The initial size of the ring
    public Transform ringSpawnPoint; // Where the ring will be spawned

    public bool isTakingPhoto;
    public bool ringExist;

    public Slider Status;
    public GameObject StatusCanvas;
    public GameObject CurrentObjectOnPhoto;

    private Researchable CurrObjectScript;

    public AudioClip soundClip;
    public AudioSource audioSource;
    public AudioSource wrongSFX;
    private float initialPitch = 0.4f;
    private float currentPitch;
    void Start()
    {
        isTakingPhoto = false;
        ringExist = false;

        audioSource.clip = soundClip;
        currentPitch = initialPitch;
        audioSource.pitch = currentPitch;
    }

    public void OnRingClicked()
    {
        if (isTakingPhoto && CurrentObjectOnPhoto != null)
        {
            CurrObjectScript = CurrentObjectOnPhoto.GetComponent<Researchable>();
            CurrObjectScript.currPoint = CurrObjectScript.currPoint + 1;
        }

        PlaySoundWithIncreasingPitch();

        ringExist = false;
        Debug.Log("clicked");
    }

    public void OnRingMissed()
    {
        if (isTakingPhoto && CurrentObjectOnPhoto != null)
        {
            CurrObjectScript = CurrentObjectOnPhoto.GetComponent<Researchable>();
            CurrObjectScript.currPoint = CurrObjectScript.currPoint - 1;
        }

        
        wrongSFX.Play();

        ringExist = false;
        Debug.Log("Missed! Game Over.");
        // Optionally, you can restart the game or handle the game over state here
        // For simplicity, we just log the message and stop the game
    }

    public void SpawnNewRing()
    {
        ringExist = true;
        GameObject newRing = Instantiate(ringPrefab, ringSpawnPoint.position, Quaternion.identity);
        newRing.transform.localScale = Vector3.one * ringStartSize;
        RingMinigame ringScript = newRing.GetComponent<RingMinigame>();
        ringScript.gameManager = this;
        ringScript.framePos = ringSpawnPoint;
    }

    private void Update()
    {
        audioSource.pitch = currentPitch;

        if (isTakingPhoto && CurrentObjectOnPhoto != null)
        {
            StatusCanvas.SetActive(true);
            CurrObjectScript = CurrentObjectOnPhoto.GetComponent<Researchable>();
            Status.value = (float)CurrObjectScript.currPoint / (float)CurrObjectScript.goalPoint;
        }
        else
        {
            ResetPitch();
            StatusCanvas.SetActive(false);
        }

        if (!ringExist && isTakingPhoto)
        {
            SpawnNewRing();
        }
    }

    public void PlaySoundWithIncreasingPitch()
    {
        audioSource.pitch = currentPitch;
        audioSource.Play();
        currentPitch += 0.05f;
    }

    public void ResetPitch()
    {
        currentPitch = initialPitch;
        audioSource.pitch = currentPitch;
    }
}
