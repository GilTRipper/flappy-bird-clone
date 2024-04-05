using UnityEngine;

public class BirdScript : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D _birdRigidBody;
    private Touch _touch;
    [SerializeField]
    private float _flapStrength;
    private LogicManagerScript _logic;
    private bool _isBirdAlive = true;

    // Start is called before the first frame update
    void KillBird()
    {
        _isBirdAlive = false;
        _logic.GameOver();
    }

    void Awake()
    {
        _logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicManagerScript>();

    }


    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0 && _isBirdAlive)
        {
            _touch = Input.GetTouch(0);
            if (_touch.phase == TouchPhase.Stationary)
            {
                _birdRigidBody.velocity = Vector2.up * _flapStrength;
            }
            if (_touch.phase == TouchPhase.Ended)
            {
                _birdRigidBody.velocity = Vector2.up * _flapStrength;
            }
        }

    }


    private void OnBecameInvisible()
    {
        KillBird();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        KillBird();
    }
}
