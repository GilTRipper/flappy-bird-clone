using UnityEngine;

public class MiddleColiderScript : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private LogicManagerScript _logic;
    void Awake()
    {
        _logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicManagerScript>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 3)
        {
            _logic.IncreaseScore(1);
        }
    }
}
