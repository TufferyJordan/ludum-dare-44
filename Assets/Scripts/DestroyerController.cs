using UnityEngine;

public class DestroyerController : MonoBehaviour
{
    public GameObject player;

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("opponent")) {
            Destroy(collision.gameObject);
        }
    }

    private void Update()
    {
        transform.position = new Vector3(player.transform.position.x - 44, player.transform.position.y, player.transform.position.z);
    }
}
