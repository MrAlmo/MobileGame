using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Teleport_Room : MonoBehaviour
{
    [SerializeField] private Transform teleportTarget;
    [SerializeField] private string playerTag = "Player";
    [SerializeField] private CameraSwitch CameraSwitch;
    [SerializeField] private GameObject fadeCanvas;

    private GameObject player;

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag(playerTag))
        {
            player = other.gameObject;
            StartCoroutine(FadeTeleport(player, teleportTarget.position));

        }
    }

    private IEnumerator FadeTeleport(GameObject player, Vector3 position)
    {
        fadeCanvas.gameObject.SetActive(true);
        yield return FadeController.Instance.StartCoroutine("Fade", 1f);
        player.transform.position = position;
        CameraSwitch.SwitchToMainCamera();
        yield return FadeController.Instance.StartCoroutine("Fade", 0f);
        fadeCanvas.gameObject.SetActive(false);
    }

}
