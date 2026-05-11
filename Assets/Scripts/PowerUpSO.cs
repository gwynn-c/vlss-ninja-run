using UnityEngine;

[CreateAssetMenu(menuName = "Power Up/New Power Up")]
public class PowerUpSO : ScriptableObject
{
    public string powerUpName;
    public float powerUpDuration;
    public GameObject powerUpPrefab;

}
