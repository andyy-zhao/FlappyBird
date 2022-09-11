using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // variable for prefab, reference it as a GameObject
    public GameObject prefab;
    public float spawnRate = 1f; // 1 second
    public float minHeight = -1.5f; // range to position pipes up or down
    public float maxHeight = 1.5f;

    // do spawning of pipes only while the spawning script is enabled. stop when disabled (when player loses)
    private void OnEnable()
    {
        InvokeRepeating(nameof(Spawn), spawnRate, spawnRate);
    }

    private void OnDisable()
    {
        CancelInvoke(nameof(Spawn));
    }

    private void Spawn()
    {
        // transform.position is referencing teh spawner's position
        GameObject pipes = Instantiate(prefab, transform.position, Quaternion.identity); // quaternion.identity is no rotation
        pipes.transform.position += Vector3.up * Random.Range(minHeight, maxHeight);
    }

}
