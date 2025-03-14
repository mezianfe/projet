using UnityEngine;

public class BarrierManager : MonoBehaviour
{
    public BarrierSet[] barrierSets;       // Array of barrier sets with individual weight ranges
    public WeightMeasure weightDetector;   // Reference to the WeightDetector script

    private BarrierSet currentActiveSet;   // Track the currently active barrier set

    void Update()
    {
        float carWeight = weightDetector.mass; // Access the stored weight
        BarrierSet newActiveSet = null;

        // Determine which barrier set should be active based on weight
        foreach (BarrierSet set in barrierSets)
        {
            if (carWeight >= set.lowerThreshold && carWeight < set.upperThreshold)
            {
                newActiveSet = set;
                break; // Exit loop once the first matching set is found
            }
        }

        // If there is a new active set and it's different from the current, switch sets
        if (newActiveSet != currentActiveSet)
        {
            // Close barriers of the previous set (if any)
            if (currentActiveSet != null)
            {
                CloseBarriers(currentActiveSet.barriers);
            }

            // Open barriers of the new active set (if any)
            if (newActiveSet != null)
            {
                OpenBarriers(newActiveSet.barriers);
            }

            currentActiveSet = newActiveSet; // Update the current active set
        }
    }

    // Helper function to open a set of barriers
    private void OpenBarriers(BarrierControl[] barriers)
    {
        foreach (BarrierControl barrier in barriers)
        {
            barrier.OpenBarrier(); // Call OpenBarrier on each barrier
        }
    }

    // Helper function to close a set of barriers
    private void CloseBarriers(BarrierControl[] barriers)
    {
        foreach (BarrierControl barrier in barriers)
        {
            barrier.CloseBarrier(); // Call CloseBarrier on each barrier
        }
    }
}
