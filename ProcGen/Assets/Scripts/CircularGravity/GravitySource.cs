using UnityEngine;

public class GravitySource : MonoBehaviour
{
    [SerializeField] private float gravity;
    public float Gravity 
    { 
        get { return gravity; } 
        private set {  gravity = value; }
    }

    public Vector3 Origin 
    {
        get { return transform.position; } 
        private set { Origin = value; } 
    }

    public void ChangeGravity(float newGravity)
    {
        Gravity = newGravity;
    }
}
