using UnityEngine;

public class CameraController : MonoBehaviour
{
    private float _baseSpeed;
    [SerializeField] private float _fastSpeed;

    [SerializeField] private float _speed = 0.5f;

    [SerializeField] private float _movementTime = 3f; // how much it lerps

    [SerializeField] private Vector3 _newPosition; // serialize field for debugging. remove later

    private void Awake()
    {
        // set the initial values in case forget to set in the editor
        if (_speed == 0)
            _speed = 1f;

        if (_movementTime == 0)
            _movementTime = 5f;

        if (_fastSpeed == 0)
            _fastSpeed = _speed * 3f;

        _baseSpeed = _speed;
    }

    // Start is called before the first frame update
    void Start()
    {
        _newPosition = this.transform.position;  // set the camera position to the base rig position
    }

    private void LateUpdate()
    {
        HandleInput();
    }

    void HandleInput()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            _speed = _fastSpeed;
        }
        else
        {
            _speed = _baseSpeed;
        }

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            _newPosition += (transform.forward * _speed);
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            _newPosition += (transform.forward * -_speed);
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            _newPosition += (transform.right * _speed);
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            _newPosition += (transform.right * -_speed);
        }

        transform.position = Vector3.Lerp(transform.position, _newPosition, Time.deltaTime * _movementTime);
    }
}
