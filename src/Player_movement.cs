using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_movement : MonoBehaviour
{
    [Header("Player")]
    [Tooltip("Move speed of the character in m/s")]
    public float moveSpeed = 20.0f;
    private Color color = Color.red;

    private Transform playerTransform;

    public delegate void mensaje();
    public event mensaje OnTypeAEventCollision;
    public event mensaje OnTypeBEventCollision;

    void Start()
    {
        playerTransform = GetComponent<Transform>();
        playerTransform.GetComponent<Renderer>().material.color = color;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.W)) {
            playerTransform.position += Vector3.forward * moveSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S)) {
            playerTransform.position += Vector3.back * moveSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A)) {
            playerTransform.position += Vector3.left * moveSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D)) {
            playerTransform.position += Vector3.right * moveSpeed * Time.deltaTime;
        }
    }

    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag == "Type B") {
            OnTypeAEventCollision();
        }
        if (collision.gameObject.tag == "Type A") {
            OnTypeBEventCollision();
        }
    }

}
