
using UnityEngine;

public class GroundTile : MonoBehaviour
{
    GroundSpawner groundSpawner;
    [SerializeField] GameObject coinPrefab;
    [SerializeField] GameObject obstcalePrefab;
    [SerializeField] GameObject radarPrefab;


    // Start is called before the first frame update
    private void Start()
    {
        groundSpawner = GameObject.FindObjectOfType<GroundSpawner>();


    }

    private void OnTriggerExit(Collider other)
    {
        groundSpawner.SpawnTile(true);
        Destroy(gameObject, 2);

    }
    // Update is called once per frame
    private void Update()
    {

    }




    public void SpawnObstcale()
    {
        //choose a random point to spawn the obstcale
        int obstcaleSpawnIndex = Random.Range(2, 5);
        Transform spawnPoint = transform.GetChild(obstcaleSpawnIndex).transform;

        //spawn the obstcale at the position
        Instantiate(obstcalePrefab, spawnPoint.position, Quaternion.identity, transform);
    }

    public void SpawnRadar() {

        //choose a random point to spawn the obstcale
        int radarSpawnIndex = Random.Range(5, 8);
        Transform spawnPoint = transform.GetChild(radarSpawnIndex).transform;

        //spawn the obstcale at the position
        Instantiate(radarPrefab, spawnPoint.position, Quaternion.identity, transform);
    }
    


        public void SpawnCoins()
    {
        int coinsTospawn = 3;
        for( int i =0; i< coinsTospawn; i++)
        {
          GameObject temp =   Instantiate(coinPrefab, transform);
            temp.transform.position = GetRandomPointInCollider(GetComponent<Collider>());
        }

    }

    Vector3 GetRandomPointInCollider(Collider collider)
    {
        Vector3 point = new Vector3(
            Random.Range(collider.bounds.min.x, collider.bounds.max.x),
            Random.Range(collider.bounds.min.y, collider.bounds.max.y),
            Random.Range(collider.bounds.min.z, collider.bounds.max.z));
        if (point != collider.ClosestPoint(point))
        {
            point = GetRandomPointInCollider(collider);
        }

        point.y = 1;
        return point;
    }
}
