using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    public abstract void Interact(Player player);
    public abstract void StopInteracting(Player player);
}
