using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TypeA_event : MonoBehaviour
{   
    private Transform typeATransform;
    private Rigidbody rb;

    public Player_movement player;
    public TypeC_event typeC;

    private bool isGrounded = true;
    private Color color = Color.blue;

    void Start()
    {
        typeATransform = GetComponent<Transform>();
        transform.GetComponent<Renderer>().material.color = color;
        player.OnTypeAEventCollision += ClosetToTypeC;
        typeC.NearTypeA += NearAction;
        typeC.NotNearTypeA += ResetGrounded;
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
    }

    void FixedUpdate() {
    }

    void ClosetToTypeC(){
        typeATransform.position = Vector3.MoveTowards(typeATransform.position, typeC.transform.position, 3.0f);
    }

    void NearAction() {
        if (isGrounded && typeATransform.position.y < 5.5f) {
            rb.AddForce(Vector3.up * 10, ForceMode.Impulse);
            ChangeColor();
            isGrounded = false; 
        }
    }

    void ChangeColor() {
        color = new Color(Random.value, Random.value, Random.value, 1.0f);
        GetComponent<Renderer>().material.color = color;
    }

    void ResetGrounded(){
        isGrounded = true;
    }
}
