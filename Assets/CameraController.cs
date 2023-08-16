using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] float smoothness=0.1f;
    private GameManager gameManager => GameManager.Instance;
    private Transform playerTransform;
    private void Start()
    {
        playerTransform = gameManager.playerTranform;
    }
    private void FixedUpdate()
    {
        Vector3 newCameraPosition = new Vector3(
            playerTransform.position.x, 
            playerTransform.position.y, 
            this.transform.position.z);

        this.transform.position = Vector3.Lerp(transform.position, newCameraPosition, smoothness);
    }
}
