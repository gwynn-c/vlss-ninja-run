using UnityEngine;
using UnityEngine.Serialization;
public class SpawnerController : MonoBehaviour
{
    [SerializeField] private GameObject[] groundEnemies;
    [SerializeField] private GameObject[] airEnemies;
    [SerializeField] private GameObject[] spawnPoints;
    
    [SerializeField] private GameObject[] powerUps;
    
    [SerializeField] private float timer;
    [SerializeField] private float timeBetweenSpawns;

    public float pickUpTotalChance = 0.1f;
    private void Start()
    {
        InvokeRepeating(nameof(SpawnEnemies), timer, timeBetweenSpawns);
    }
    private void SpawnEnemies()
    {
        var spawnPowerUp = CalculatePowerUpChance();
        //For each enemy add in a 5% chance;
        if (GameManager.Instance.isGameOver || !GameManager.Instance.isGameStarted) return;
        
        pickUpTotalChance += 0.05f;
        var randNum = Random.Range(0, spawnPoints.Length);
        if (spawnPoints[randNum].GetComponent<SpawnPoint>().spawnType == SpawnType.Ground && !spawnPowerUp)
        {
            // var randEnemy = Random.Range(0, groundEnemies.Length);
            var s = new Vector2(spawnPoints[randNum].transform.position.x, 1.4f);
            Instantiate(groundEnemies[0],s , Quaternion.identity);
        }
        else if(spawnPoints[randNum].GetComponent<SpawnPoint>().spawnType == SpawnType.Air && !spawnPowerUp)
        {
            // var randEnemy = Random.Range(0, airEnemies.Length);
            Instantiate(airEnemies[0], spawnPoints[randNum].transform.position, Quaternion.identity);
        }
        else if (spawnPowerUp)
        {
            pickUpTotalChance = 0.1f;
            Instantiate(powerUps[Random.Range(0, powerUps.Length)], spawnPoints[randNum].transform.position, Quaternion.identity);
        }
    }

    private bool CalculatePowerUpChance()
    {
        var currentPickupChance = 1 - pickUpTotalChance;
        var r = Random.Range(0, 1f);
        return r  > currentPickupChance;
    }
}