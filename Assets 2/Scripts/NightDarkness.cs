using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NightDarkness : MonoBehaviour
{
    public int targetValue = 17;
    public int checkValue;
    public Image imageToChange;
    public float fadeDuration = 30.0f; // Duration of the fade in seconds

    private bool shouldFade = false;
    private float targetAlpha = 160f / 255f;

    private GameObject GameSystemObj;
    private TimeSystem TimeSystemScript;

    private void Start()
    {
        GameSystemObj = GameObject.FindGameObjectWithTag("GameSystem");
        TimeSystemScript = GameSystemObj.GetComponent<TimeSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        checkValue = TimeSystemScript.gameHours;
        if (checkValue == targetValue && !shouldFade)
        {
            shouldFade = true;
            StartCoroutine(FadeToTargetAlpha());
        }
    }

    private IEnumerator FadeToTargetAlpha()
    {
        Color originalColor = imageToChange.color;
        float elapsedTime = 0f;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            float newAlpha = Mathf.Lerp(originalColor.a, targetAlpha, elapsedTime / fadeDuration);
            imageToChange.color = new Color(originalColor.r, originalColor.g, originalColor.b, newAlpha);
            yield return null;
        }

        // Ensure the target alpha is set at the end
        imageToChange.color = new Color(originalColor.r, originalColor.g, originalColor.b, targetAlpha);
        shouldFade = false;
    }
}
