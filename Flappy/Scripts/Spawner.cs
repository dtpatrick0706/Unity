using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject pipePrefab;
    public GameObject marioPrefab;
    public float spawnRatePipe = 1f;
    public float minHeightPipe = -1f;
    public float maxHeightPipe = 1f;

    public float spawnRateMario = 1f;
    public float minHeightMario = 0f;
    public float maxHeightMario = 0f;

    private void OnEnable()
    {
        InvokeRepeating(nameof(SpawnPipes), spawnRatePipe, spawnRatePipe);
        InvokeRepeating(nameof(SpawnMario), spawnRateMario, spawnRateMario);

    }

    private void OnDisable()
    {
        CancelInvoke(nameof(SpawnPipes));
        CancelInvoke(nameof(SpawnMario));
    }

    private void SpawnPipes()
    {
        GameObject pipes = Instantiate(pipePrefab, transform.position, Quaternion.identity);
        pipes.transform.position += Vector3.left * 5;
        pipes.transform.position += Vector3.up * Random.Range(minHeightPipe, maxHeightPipe);
    }

    private void SpawnMario()
    {
        GameObject mario = Instantiate(marioPrefab, transform.position, Quaternion.identity);
        mario.transform.position = Vector3.up * Random.Range(minHeightMario, maxHeightMario);
    }
}
