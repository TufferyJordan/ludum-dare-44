using UnityEngine;

public class DestroyerController : MonoBehaviour
{
    public GameObject player;

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(collision.gameObject);
    }

    private void Update()
    {
        transform.position = new Vector3(player.transform.position.x - 24, player.transform.position.y, player.transform.position.z);
    }
}
