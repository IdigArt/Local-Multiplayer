using UnityEngine;
using CubeInput;

public class CubeMovement : MonoBehaviour
{
    CubeActionInput _input;

    private Rigidbody _rb;

    public float speed;

    private void Start()
    {
         _rb = GetComponent<Rigidbody>();
        _input = CubeActionInput.instance;
    }
    void Update()
    {
        var h = _input._moveInput.x;
        var v = _input._moveInput.y;

        var yValue = _input._yMovement.y;

        Vector3 m = new Vector3(h, yValue, v);
        transform.Translate(m * speed * Time.deltaTime);
        //_rb.MovePosition(_rb.position *_input._moveInput * speed * Time.deltaTime);
    }
}
