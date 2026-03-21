using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    GameObject player;

    private Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        // offset = transform.position - player.transform.position;

        offset = new Vector3(0, 0, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        // GameObject go = GameObject.Find("Player");

        transform.position = Vector3.Lerp(transform.position, player.transform.position + offset, Time.deltaTime);
    }
}
