using UnityEngine;

public class PipeSpawnerScript : MonoBehaviour
{
    [SerializeField]
    private GameObject _pipe;

    [SerializeField]
    private float _spawnRate = 2;
    private float _timer;
    [SerializeField]
    private float _heightOffset = 10;
    // Start is called before the first frame update

    void SpawnPipe()
    {
        float highestPoint = transform.position.y + _heightOffset;
        float lowestPoint = transform.position.y - _heightOffset;
        Instantiate(_pipe, new Vector3(transform.position.x, Random.Range(highestPoint, lowestPoint)), transform.rotation);
    }
    void Start()
    {
        SpawnPipe();
    }

    // Update is called once per frame
    void Update()
    {
        if (_timer < _spawnRate)
        {
            _timer += Time.deltaTime;
        }
        else
        {
            SpawnPipe();
            _timer = 0;
        }
    }
}
