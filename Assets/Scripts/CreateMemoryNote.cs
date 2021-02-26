using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateMemoryNote : MonoBehaviour
{
    public GameObject prefab;

    public void InstantiateMemoryNote() {
        Instantiate(prefab, new Vector3(0, 1, 0), Quaternion.identity);
    }
}
