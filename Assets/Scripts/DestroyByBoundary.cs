using UnityEngine;
using System.Collections;
/// <summary>
/// Destroys obejects when they collide with the boundary
/// </summary>
public class DestroyByBoundary : MonoBehaviour
{

    void OnTriggerExit(Collider other)
    {
        Destroy(other.gameObject);
    }

}
