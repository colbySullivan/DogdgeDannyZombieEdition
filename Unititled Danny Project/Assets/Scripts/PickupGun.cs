using UnityEngine.Events;
using UnityEngine;

public class PickupGun : MonoBehaviour
{
    public UnityEvent pickUp;

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Hit " + collision.transform.name);
        if (collision.gameObject.tag == "Player")
        {
            //Debug.Log("Hit " + collision.transform.name);
            pickUp?.Invoke();
        }
    }
}
