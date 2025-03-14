using UnityEngine;

[System.Serializable]
public class BarrierSet 
{
    public float lowerThreshold;     // Lower bound for this barrier set
    public float upperThreshold;     // Upper bound for this barrier set
    public BarrierControl[] barriers; // Array of barriers that belong to this set
}


