using UnityEngine;

public class Camera_Follow : MonoBehaviour
{
    public Transform carParent;
    public float smoothSpeed = 0.125f;
    public float rotationSmoothSpeed = 5.0f; // Smoothing speed for rotation
    public float distanceBehind = 10f;       // Distance behind the car
    public float heightAbove = 5f;           // Height above the car

    private Transform target;
    private GameObject followPoint;
    private Vector3 currentVelocity;         // Used by SmoothDamp for smooth position

    void Start()
    {
        // Create a dummy follow point to smooth camera's target position
        followPoint = new GameObject("CameraFollowPoint");
    }

    void Update()
    {
        // Find the currently active car as the target
        target = GetActiveCar();

        if (target != null)
        {
            // Position the follow point directly behind the car with smoothing
            Vector3 desiredPosition = target.position - target.forward * distanceBehind + Vector3.up * heightAbove;
            followPoint.transform.position = Vector3.SmoothDamp(followPoint.transform.position, desiredPosition, ref currentVelocity, smoothSpeed);
        }
    }

    private Transform GetActiveCar()
    {
        foreach (Transform child in carParent)
        {
            if (child.gameObject.activeSelf)
            {
                return child;
            }
        }
        return null;
    }

    void FixedUpdate()
    {
        if (target != null)
        {
            FollowTarget();
        }
    }

    private void FollowTarget()
    {
        // Smoothly move the camera to the follow point's position
        transform.position = Vector3.Lerp(transform.position, followPoint.transform.position, smoothSpeed);

        // Smoothly rotate the camera to look at the car
        Quaternion targetRotation = Quaternion.LookRotation(target.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSmoothSpeed * Time.deltaTime);
    }
}
