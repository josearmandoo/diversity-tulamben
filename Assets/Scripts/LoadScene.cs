using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class LoadScene : MonoBehaviour
{
    public Image fadeImage; // Reference to the Image component used for the fade effect
    public float fadeDuration = 1.0f; // Duration of the fade effect
    public string sceneToLoad; // Name of the scene to load after fade in

    void Start()
    {
        // Ensure the image is visible and fully opaque at the start
        fadeImage.color = new Color(fadeImage.color.r, fadeImage.color.g, fadeImage.color.b, 1);
        fadeImage.gameObject.SetActive(true);

        // Start with fade out effect
        StartCoroutine(FadeOut());
    }

    public void FadeIn()
    {
        // Start the fade in coroutine
        StartCoroutine(FadeInCoroutine());
    }

    IEnumerator FadeInCoroutine()
    {
        // Ensure the image is visible
        fadeImage.gameObject.SetActive(true);

        // Gradually increase alpha over time
        for (float t = 0.0f; t < fadeDuration; t += Time.deltaTime)
        {
            Color color = fadeImage.color;
            color.a = Mathf.Lerp(0, 1, t / fadeDuration);
            fadeImage.color = color;
            yield return null;
        }

        // Ensure alpha is fully set to 1
        Color finalColor = fadeImage.color;
        finalColor.a = 1;
        fadeImage.color = finalColor;

        // Load the next scene
        SceneManager.LoadScene(sceneToLoad);
    }

    IEnumerator FadeOut()
    {
        // Gradually decrease alpha over time
        for (float t = 0.0f; t < fadeDuration; t += Time.deltaTime)
        {
            Color color = fadeImage.color;
            color.a = Mathf.Lerp(1, 0, t / fadeDuration);
            fadeImage.color = color;
            yield return null;
        }

        // Ensure alpha is fully set to 0
        Color finalColor = fadeImage.color;
        finalColor.a = 0;
        fadeImage.color = finalColor;

        // Optionally, disable the image
        fadeImage.gameObject.SetActive(false);
    }

    public void ExitGame()
    {
        #if UNITY_EDITOR
        // If running in the Unity Editor, stop playing
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        // If running in a build, quit the application
        Application.Quit();
        #endif
    }
}
