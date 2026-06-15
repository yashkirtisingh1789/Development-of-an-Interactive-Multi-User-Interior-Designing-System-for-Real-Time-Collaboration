using UnityEngine;
using Photon.Pun;

public class ObjectSpawner : MonoBehaviour
{
    public GameObject[] spawnPrefabs;
    public Transform spawnPoint;

    public void SpawnObject(int index)
    {
        // 🔥 IMPORTANT CHECK
        if (!PhotonNetwork.InRoom)
        {
            Debug.LogError("Not in room yet!");
            return;
        }

        if (index < 0 || index >= spawnPrefabs.Length) return;

        GameObject obj = spawnPrefabs[index];

        PhotonNetwork.Instantiate(
            obj.name,
            spawnPoint.position,
            spawnPoint.rotation
        );
    }
}