using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpactReceiver : MonoBehaviour
{

    public float mass = 3.0f; // define the character mass

    Vector3 impact = Vector3.zero;
    CharacterController character;

    void Start()
    {
        character = GetComponent<CharacterController>();
    }

    public void AddImpact(Vector3 force)
    { // CharacterController version of AddForce
        impact = force / mass;
    }

    public void RestartImpact()
    {
        impact = Vector3.zero;
    }


    void Update()
    {
        // apply the impact effect:
        if (impact.magnitude > 0.2f)
        {
            character.Move(impact * Time.deltaTime);
        }
        // impact energy goes by over time:

        impact = Vector3.Lerp(impact, Vector3.zero, 5 * Time.deltaTime);
        
    }
}
