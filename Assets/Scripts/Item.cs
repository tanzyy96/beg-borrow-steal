using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// RequireComponent attribute will automatically add the required component to the GameObject
// This is also the prefab gameobject of the collectable item
[RequireComponent(typeof(Rigidbody2D))]
public class Item : MonoBehaviour
{
    public ItemData data;

    // Since we already fetch it in the Awake method, we can hide it
    [HideInInspector] public Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
}
