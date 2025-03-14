using System.Collections;
using UnityEngine;

public class BarrierControl : MonoBehaviour
{
    public Transform rod;          // Reference to the rod child object
    private bool isOpen = false;   // Track if the barrier is currently open

    // Method to open the barrier
    public void OpenBarrier()
    {
        if (!isOpen)
        {
            StartCoroutine(RotateRodToOpen());
            isOpen = true; // Mark as opened
        }
    }

    // Method to close the barrier
    public void CloseBarrier()
    {
        if (isOpen)
        {
            StartCoroutine(RotateRodToClose());
            isOpen = false; // Mark as closed
        }
    }

    // Coroutine to rotate the rod to the open position (0 degrees on X-axis)
    private IEnumerator RotateRodToOpen()
    {
        Quaternion startRotation = Quaternion.Euler(-90, -90, 90); // Closed position
        Quaternion endRotation = Quaternion.Euler(0, -90, 90);     // Open position
        float duration = 1f;                                       // Duration of rotation in seconds
        float time = 0f;

        rod.localRotation = startRotation;

        while (time < duration)
        {
            rod.localRotation = Quaternion.Slerp(startRotation, endRotation, time / duration);
            time += Time.deltaTime;
            yield return null;
        }

        rod.localRotation = endRotation;
    }

    // Coroutine to rotate the rod to the closed position (-90 degrees on X-axis)
    private IEnumerator RotateRodToClose()
    {
        Quaternion startRotation = Quaternion.Euler(0, -90, 90);  // Open position
        Quaternion endRotation = Quaternion.Euler(-90, -90, 90);  // Closed position
        float duration = 1f;                                      // Duration of rotation in seconds
        float time = 0f;

        rod.localRotation = startRotation;

        while (time < duration)
        {
            rod.localRotation = Quaternion.Slerp(startRotation, endRotation, time / duration);
            time += Time.deltaTime;
            yield return null;
        }

        rod.localRotation = endRotation;
    }
}
