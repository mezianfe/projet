using UnityEngine;
using TMPro;

public class WeightMeasure : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI massDisplay;
    [SerializeField]public float mass;

    void OnTriggerEnter(Collider other)
    {
        // Check if the colliding object has a Rigidbody component
        Rigidbody collidingRigidbody = other.GetComponentInParent<Rigidbody>();
        mass = collidingRigidbody.mass;

        if (collidingRigidbody != null && massDisplay != null)
        {
            
            massDisplay.text = $"Mass: {collidingRigidbody.mass} kg";
        }
    }

    void OnTriggerExit(Collider other)
    {
        // Reset the display text to "Mass: 0 kg" when the object exits the trigger
        if (massDisplay != null)
        {
            massDisplay.text = "Mass: 0 kg";
        }
    }
}
