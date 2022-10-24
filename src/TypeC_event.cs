using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TypeC_event : MonoBehaviour
{
    public Player_movement player;
    public TypeA_event typeA;

    private float perimeter = 30.0f;
    private Color color = Color.yellow;

    public delegate void mensaje();
    public event mensaje NearTypeA;
    public event mensaje NotNearTypeA;

    void Start()
    {
        transform.GetComponent<Renderer>().material.color = color;
    }

    void Update()
    {
        float distance_player = Vector3.Distance(player.transform.position, transform.position);
        if (distance_player < perimeter) {
            NearTypeA();
        } else {
            NotNearTypeA();
        }
    }
}
    