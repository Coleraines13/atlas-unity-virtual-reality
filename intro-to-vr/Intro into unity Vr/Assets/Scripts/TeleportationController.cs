using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportationController : MonoBehaviour
{
    // Adjust the speed and distance according to your preference
    public float teleportSpeed = 3f;
    public float teleportDistance = 10f;

    private void Update()
    {
        // this adds raycasting logic 
        if (Input.GetButtonDown("TeleportButton"))
        {
            Teleport();
        }
    }

    private void Teleport()
    {
        // this implements raycasting logic
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, teleportDistance))
        {
            // this calculates the teleport destination
            Vector3 teleportPosition = hit.point;

            // this moves the player to the teleport destination
            StartCoroutine(MovePlayer(teleportPosition));
        }
    }

    private IEnumerator MovePlayer(Vector3 destination)
    {
        // this implements smooth movement to the destination
        float startTime = Time.time;
        Vector3 startPos = transform.position;

        while (Time.time < startTime + 1 / teleportSpeed)
        {
            transform.position = Vector3.Lerp(startPos, destination, (Time.time - startTime) * teleportSpeed);
            yield return null;
        }
    }
}