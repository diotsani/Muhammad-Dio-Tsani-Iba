using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public float x;
    public float y;
    public float z;

    public Rigidbody rb;
    public bool dragging = false;
    public float rotationSpeed;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        transform.Rotate(x, y, z * Time.deltaTime);
        Drag();
    }

    private void FixedUpdate()
    {
        if (dragging)
        {
            float x = Input.GetAxis("Mouse X") * rotationSpeed * Time.fixedDeltaTime;
            float y = Input.GetAxis("Mouse Y") * rotationSpeed * Time.fixedDeltaTime;

            rb.AddTorque(Vector3.down * x);
            rb.AddTorque(Vector3.right * y);
        }
    }

    private void OnMouseDrag()
    {
        dragging = true;
    }

    public void Controller()
    {
        // For Smartphone
        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.touches[0].position);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.tag == "Cube")
                {
                    dragging = true;
                }
            }
        }

//#if UNITY_EDITOR
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.tag == "Cube")
                {
                    dragging = true;
                }
            }
        }
//#endif
    }

    public void Drag()
    {
        // For Smartphone
        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            dragging = false;
        }

//#if UNITY_EDITOR
        if (Input.GetMouseButtonDown(0))
        {
            dragging = false;
        }
//#endif
    }
}
