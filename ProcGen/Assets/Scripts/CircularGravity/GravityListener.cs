using UnityEngine;
using UnityEngine.EventSystems;

public class GravityListener : MonoBehaviour
{
    [SerializeField] private GravitySource source;

    [Header("Physics")]
    [SerializeField] private float mass;
    [SerializeField] private Vector2 drag;

    [Header("Ground check")]
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private float groundCheckLength = 1.1f;

    private bool isGrounded;

    private Vector2 velocity;
    private Vector2 externalForce;

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, -transform.up, groundCheckLength, groundMask);

        if (hit.collider != null) { isGrounded = true; }
        else { isGrounded = false; }

        ApplyForce(transform.right, 5);
        UpdateListener();
    }

    public void ApplyForce(Vector2 direction, float strength)
    {
        //externalForce = direction * transform.right * strength;
        //Debug.Log($"External force: {externalForce}");
        Vector2 dir = VectorUtils.GetPerpendicular2D(transform.position, source.Origin);
        dir = dir + direction;
        rb.AddForce(direction * strength);
    }

    private Vector2 CalculateGravityDirection()
    {
        return VectorUtils.GetDirection2D(transform.position, source.Origin).normalized;
    }

    private Vector2 CalculateGravity()
    {
        if(isGrounded)
        {
            return Vector2.zero;
        }

        Vector2 gDir = CalculateGravityDirection();
        return -source.Gravity * gDir *  mass;
    }

    private Vector2 CalculateDrag()
    {
        //if(isGrounded) { return Vector2.one * 999; }

        float xDrag = drag.x * velocity.x;
        float yDrag = drag.y * velocity.y;
        return new Vector2(-xDrag, -yDrag);
    }

    private void UpdateRotation()
    {
        Vector2 direction = VectorUtils.GetPerpendicular2D(transform.position, source.Origin);

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.MoveRotation(angle);
        //transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    private void UpdateListener()
    {
        UpdateRotation();

        Vector2 totalForce = CalculateGravity() + externalForce;
        rb.AddForce(totalForce, ForceMode2D.Force);

        //externalForce = Vector2.zero;

        //velocity = totalForce * (Time.deltaTime * Time.deltaTime) / mass;

        //Vector3 newPosition = VectorUtils.V3ToV2(transform.position) + (velocity /* speed */);
        //rb.MovePosition(newPosition);
        //transform.position = newPosition;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, -transform.up * groundCheckLength);
    }
}
