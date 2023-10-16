using UnityEngine;

public class cameraBounds : MonoBehaviour
{
    public Vector2 upperLeft;
    public Vector2 bottomRight;
    public float followSpeed;
    public Transform targetTransform;
    private Vector3 movetoPos;

    public float power = 0.7f;
    float duration = 0.25f;
    public float slowDownAmount = 1.0f;

    Vector3 startPos;
    float intialDuratation = 0.25f;
    // Use this for initialization
    void Start()
    {
        startPos = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {


        this.transform.position = new Vector3(targetTransform.position.x, targetTransform.position.y, this.transform.position.z);

    }
    void FixedUpdate()
    {
        //Free follow camera


        movetoPos.z = this.transform.position.z;
        float step = followSpeed * Time.deltaTime;
        if (targetTransform == null)
        {
            PlayerMovement tar = FindObjectOfType(typeof(PlayerMovement)) as PlayerMovement;
            if (tar != null)
                targetTransform = tar.gameObject.transform;
        }
        if (targetTransform != null)
        {
            if (targetTransform.position.x <= upperLeft.x || targetTransform.position.x >= bottomRight.x)
            {
                if (targetTransform.position.x <= upperLeft.x)
                    movetoPos.x = upperLeft.x;
                if (targetTransform.position.x >= bottomRight.x)
                    movetoPos.x = bottomRight.x;
            }
            else
            {
                movetoPos.x = targetTransform.position.x;
            }
            if (targetTransform.position.y >= upperLeft.y || targetTransform.position.y <= bottomRight.y)
            {
                if (targetTransform.position.y >= upperLeft.y)
                    movetoPos.y = upperLeft.y;
                if (targetTransform.position.y <= bottomRight.y)
                    movetoPos.y = bottomRight.y;
            }
            else
            {
                movetoPos.y = targetTransform.position.y;
            }
            //Follow target

            this.transform.position = Vector3.MoveTowards(this.transform.position, movetoPos, step);
        }
    }
}
