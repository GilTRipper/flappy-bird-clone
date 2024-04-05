using UnityEngine;

public class PipeScipt : MonoBehaviour
{

    [SerializeField]
    private float _moveSpeed = 5;
    [SerializeField]
    private float _deadZone = -35;

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + (Vector3.left * _moveSpeed) * Time.deltaTime;
        if (transform.position.x < _deadZone)
        {
            Destroy(gameObject);
        }
    }

}
