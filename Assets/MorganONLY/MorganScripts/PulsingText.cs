using UnityEngine;
using System.Collections; // Add this for IEnumerator
using UnityEngine.UI; // Include this if using UI components

public class PulsingText : MonoBehaviour
{
    public RectTransform uiElement; // Reference to the UI element's RectTransform
    public float pulseSpeed = 2.0f; // Speed of the pulsing effect
    public float minScale = 0.8f; // Minimum scale of the pulsing effect
    public float maxScale = 1.2f; // Maximum scale of the pulsing effect

    private void Start()
    {
        // Start the pulsing effect
        StartCoroutine(Pulse());
    }

    private IEnumerator Pulse()
    {
        Vector3 originalScale = uiElement.localScale;
        while (true)
        {
            float lerpTime = Mathf.PingPong(Time.time * pulseSpeed, 1);
            float scale = Mathf.Lerp(minScale, maxScale, lerpTime);
            uiElement.localScale = originalScale * scale;

            yield return null; // Wait for the next frame
        }
    }
}
