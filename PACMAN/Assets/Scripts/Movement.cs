using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Movement : MonoBehaviour
{
    public float speed = 8f;
    public float speedMultiplier = 1f;
    public Vector3 initialDirection;
    public LayerMask obstacleLayer;

    public new Rigidbody rigidbody { get; private set; }
    public Vector3 direction { get; private set; }
    public Vector3 nextDirection { get; private set; }
    public Vector3 startingPosition { get; private set; }

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
        startingPosition = transform.position;
    }

    private void Start()
    {
        ResetState();
    }

    public void ResetState()
    {
        speedMultiplier = 1f;
        direction = initialDirection;
        nextDirection = Vector3.zero;
        transform.position = startingPosition;
        rigidbody.isKinematic = false;
        //enabled = true;
    }

    private void Update()
    {
        Vector3 position = rigidbody.position;
        Vector3 translation = direction * speed * speedMultiplier * Time.fixedDeltaTime;

        rigidbody.MovePosition(position + translation);
    }

    public void SetDirection(Vector3 direction, bool forced = false)
    {
        this.direction = direction;
        nextDirection = Vector3.zero;
        
    }

}
