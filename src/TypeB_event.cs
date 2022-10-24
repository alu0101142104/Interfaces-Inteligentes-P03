using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TypeB_event : MonoBehaviour
{
    private Transform typeBTransform;

    public Player_movement player;
    public TypeC_event typeC;

    public float size = 5.0f;
    private Color color = Color.green;

    void Start()
    {
        typeBTransform = GetComponent<Transform>();
        transform.GetComponent<Renderer>().material.color = color;
        player.OnTypeBEventCollision += IncreaseSize;
        typeC.NearTypeA += Orientation;
    }

    void Update()
    {
        
    }

    void FixedUpdate() {
    }

    void IncreaseSize() {
        size += 1.0f;
        typeBTransform.localScale = new Vector3(size, size, size);
    }

    void Orientation() {
        GameObject toOrientate = GameObject.Find("ToOrientate");
        transform.LookAt(toOrientate.transform);
        Debug.DrawRay(transform.position, toOrientate.transform.position - transform.position, Color.red);
    }
}
