using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _tapForce;
    [SerializeField] private float _speed;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _maxRotetionZ;
    [SerializeField] private float _minRotetionZ;
    
    private Rigidbody2D _rigidbody2D;
    private Quaternion _maxRotation;
    private Quaternion _minRotation;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _maxRotation = Quaternion.Euler(0, 0, _maxRotetionZ);
        _minRotation = Quaternion.Euler(0, 0, _minRotetionZ);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _rigidbody2D.velocity = new Vector2(_speed, _tapForce);
            transform.rotation = _maxRotation;
        }
        
        transform.rotation = Quaternion.Lerp(transform.rotation, _minRotation, _rotationSpeed * Time.deltaTime);
    }
}
