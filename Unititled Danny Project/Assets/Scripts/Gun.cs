using UnityEngine.Events;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public UnityEvent OnGunShoot;
    public UnityEvent OnGunStop;
    public UnityEvent reloading;
    public float FireCooldown;

    // default is semi
    public bool Automatic;

    private float CurrentCooldown;


    // Start is called before the first frame update
    void Start()
    {
        CurrentCooldown = FireCooldown;
    }

    // Update is called once per frame
    void Update()
    {
        if (Automatic)
        {
            if (Input.GetMouseButton(0))
            {
                if (CurrentCooldown <= 0f)
                {
                    OnGunShoot?.Invoke();
                    CurrentCooldown = FireCooldown;
                }
            }
            else if (Input.GetMouseButtonUp(0))
                OnGunStop?.Invoke();
        }
        else
        {
            if (CurrentCooldown <= 0f)
            {
                OnGunStop?.Invoke();
                if (Input.GetMouseButtonDown(0))
                {
                    OnGunShoot?.Invoke();
                    CurrentCooldown = FireCooldown;
                }
            }
               if (CurrentCooldown > 0f)
                    reloading?.Invoke();   
        }   
        CurrentCooldown -= Time.deltaTime;
    }
}
