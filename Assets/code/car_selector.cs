using UnityEngine;
using UnityEngine.UI;

public class car_selector : MonoBehaviour
{
    int currentcar;
    [SerializeField] private Button previous;
    [SerializeField] private Button next;

    private Vector3[] initialPositions; // Array to store initial positions of cars
    private Quaternion[] initialRotations; // Array to store initial rotations of cars

    private void Awake()
    {
        int childCount = transform.childCount; // Get the number of children
        initialPositions = new Vector3[childCount]; // Initialize array for positions
        initialRotations = new Quaternion[childCount]; // Initialize array for rotations

        // Store the initial position and rotation of each child (car)
        for (int i = 0; i < childCount; i++)
        {
            initialPositions[i] = transform.GetChild(i).position; // Store each child's initial position
            initialRotations[i] = transform.GetChild(i).rotation; // Store each child's initial rotation
        }

        select_car(0); // Select the first car at startup
    }

    // Method to select and show the car at the specified index
    private void select_car(int _index)
    {
        previous.interactable = (_index != 0); // Enable/disable previous button
        next.interactable = (_index != transform.childCount - 1); // Enable/disable next button

        // Activate the selected car and reset its position and rotation
        for (int i = 0; i < transform.childCount; i++)
        {
            GameObject car = transform.GetChild(i).gameObject;
            car.SetActive(i == _index); // Activate only the selected car

            if (i == _index) // If this is the selected car
            {
                // Reset the position and rotation of the selected car to its initial state
                car.transform.position = initialPositions[i];
                car.transform.rotation = initialRotations[i];
            }
        }
    }

    // Method to change the current car index
    public void changecar(int change)
    {
        currentcar += change; // Update the current car index

        // Clamp the index to ensure it's within valid bounds
        currentcar = Mathf.Clamp(currentcar, 0, transform.childCount - 1);
        select_car(currentcar); // Select the new car
    }
}
