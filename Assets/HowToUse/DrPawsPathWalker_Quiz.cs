using UnityEngine;
using System.Collections;

public class DrPawsPathWalker_Quiz : MonoBehaviour
{
    [Header("XR Socket Settings")]
<<<<<<< HEAD
public GameObject xrSocket;      // Assign your XR socket here
public GameObject boneObject;    // Assign the bone GameObject here


=======
    public GameObject xrSocket;      // Assign your XR socket here
    public GameObject boneObject;    // Assign the bone GameObject here
    public GameObject StomachObject;   
>>>>>>> 1d9e94275dfe260f498f0e4f2ee682b7432b9aea
    [Header("Path Settings")]
    public Transform[] pathPoints;
    [Range(0.1f, 5f)] public float speed = 1.2f;
    public float reachDistance = 0.2f;
    public float rotationSpeed = 2f;

    [Header("Animation Settings")]
    public Animator animator;

    private int currentPoint = 1;
    private bool isMoving = false;
    private bool canMove = false;
    private bool isPaused = false;

    void Start()
    {
        if (animator == null)
            animator = GetComponent<Animator>();

        if (pathPoints.Length > 0)
        {
            transform.position = pathPoints[0].position;
            Debug.Log($"✅ Starting at {pathPoints[0].name}");
        }
        else
        {
            Debug.LogWarning("⚠️ No path points assigned!");
        }

        animator?.SetBool("isWalking", false);
    }

    void Update()
    {
        if (!canMove || isPaused) return;

        if (pathPoints.Length == 0 || currentPoint >= pathPoints.Length)
        {
            if (isMoving)
            {
                isMoving = false;
                animator?.SetBool("isWalking", false);
                Debug.Log("🏁 Finished walking path!");
            }
            return;
        }

        Transform targetPoint = pathPoints[currentPoint];
        Vector3 direction = targetPoint.position - transform.position;
        float distance = direction.magnitude;

        if (distance > reachDistance)
        {
            // Move and rotate
            Vector3 moveDirection = direction.normalized;
            transform.position += moveDirection * speed * Time.deltaTime;

            if (moveDirection != Vector3.zero)
            {
                Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            }

            if (!isMoving)
            {
                isMoving = true;
                animator?.SetBool("isWalking", true);
                Debug.Log($"🚶 Walking toward {targetPoint.name}");
            }
        }
        else
        {
            Debug.Log($"✅ Reached {targetPoint.name}");
            StartCoroutine(HandlePointReachedWithDelay(currentPoint));
            currentPoint++;
        }
    }

    private IEnumerator HandlePointReachedWithDelay(int index)
    {
        isPaused = true;
        isMoving = false;
        animator?.SetBool("isWalking", false);

<<<<<<< HEAD
        Transform lookTarget = pathPoints[index]; // so Dr. Paws faces the current object
=======
        // Make Dr. Paws face the current object
        Transform lookTarget = pathPoints[index];
>>>>>>> 1d9e94275dfe260f498f0e4f2ee682b7432b9aea
        if (lookTarget != null)
        {
            Vector3 lookDirection = (lookTarget.position - transform.position).normalized;
            lookDirection.y = 0;
<<<<<<< HEAD
=======

>>>>>>> 1d9e94275dfe260f498f0e4f2ee682b7432b9aea
            if (lookDirection != Vector3.zero)
            {
                Quaternion lookRotation = Quaternion.LookRotation(lookDirection);
                transform.rotation = lookRotation;
            }
        }

        switch (index)
        {
<<<<<<< HEAD
        case 1:
    // 🦴 Play grab animation first
    animator.SetBool("isGrabBone", true);
    Debug.Log("🦴 Dr. Paws starts grabbing bone...");
    yield return new WaitForSeconds(1.2f); // wait before attaching
    
    // Attach bone mid-animation

    Debug.Log("🦴 Bone successfully attached.");

    yield return new WaitForSeconds(1.3f); // small delay to finish grab animation
    animator.SetBool("isGrabBone", false);
    break;


            case 2:


    break;
            case 3:
                    // 🐾 Put the bone
                animator.SetBool("isPuttingBone", true);
                Debug.Log("🐾 Dr. Paws puts the bone.");
                yield return new WaitForSeconds(3f);
                 animator.SetBool("isPuttingBone", false);
                // 🧩 Disable socket and physics control
    if (xrSocket != null)
    {
        xrSocket.SetActive(false); // disable XR socket
        Debug.Log("🧩 XR Socket disabled.");
    }

    // disable isKinematic so bone falls or stays released
    if (boneObject != null)
    {
        Rigidbody rb = boneObject.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.isKinematic = false;
            Debug.Log("💥 Bone physics re-enabled (isKinematic = false).");
        }
    }

    yield return new WaitForSeconds(1.5f);

      break;

          

            case 4:
                // 💤 Idle at final point
                animator.SetBool("isWalking", false);
                Debug.Log("😴 Dr. Paws goes idle at destination.");
                yield return new WaitForSeconds(2f);
                break;
=======

            case 1:
                break;

            case 2:
                Debug.Log("🦴 CHECKPOINT1");
                // 🦴 Play grab animation first
                animator.SetBool("isGrabBone", true);
                Debug.Log("🦴 Dr. Paws starts grabbing bone...");
                yield return new WaitForSeconds(1.2f);

                // Attach bone mid-animation
                Debug.Log("🦴 Bone successfully attached.");

                yield return new WaitForSeconds(1.3f); // Finish grab animation
                animator.SetBool("isGrabBone", false);
                break;

            case 3:
             Debug.Log("🦴 CHECKPOINT2");
                break;

            case 4:
                Debug.Log("🦴 CHECKPOINT3");
                animator.SetBool("isPuttingBone", true);
                Debug.Log("🐾 Dr. Paws puts the bone.");
                yield return new WaitForSeconds(3f);
                animator.SetBool("isPuttingBone", false);

                // 🧩 Disable socket and physics control
                if (xrSocket != null)
                {
                    xrSocket.SetActive(false);
                    Debug.Log("🧩 XR Socket disabled.");
                }

                if (boneObject != null)
                {
                    Rigidbody rb = boneObject.GetComponent<Rigidbody>();
                    if (rb != null)
                    {
                        rb.isKinematic = false;
                        Debug.Log("💥 Bone physics re-enabled (isKinematic = false).");
                    }
                }

                yield return new WaitForSeconds(1.5f);
                break;

            case 5:
                 
                xrSocket.SetActive(true);

                // 🦴 Play grab animation first
                animator.SetBool("isGrabBone", true);
                Debug.Log("🦴 Dr. Paws starts grabbing Stomach...");
                yield return new WaitForSeconds(1.2f);

                Debug.Log("🦴 Stomach successfully attached.");

                yield return new WaitForSeconds(1.3f); // Finish grab animation
                animator.SetBool("isGrabBone", false);

                break;

            case 6:
            Debug.Log("🦴 CHECKPOINT5");

                break;

            case 7:
                Debug.Log("🦴 CHECKPOINT6");
                animator.SetBool("isPuttingBone", true);
                Debug.Log("🐾 Dr. Paws puts the Stomach.");
                yield return new WaitForSeconds(3f);
                animator.SetBool("isPuttingBone", false);

            

                if (xrSocket != null)
                {
                    xrSocket.SetActive(false);
                    Debug.Log("🧩 XR Socket disabled.");
                }

                if (StomachObject != null)
                {
                    Rigidbody rb = StomachObject.GetComponent<Rigidbody>();
                    if (rb != null)
                    {
                        rb.isKinematic = false;
                        Debug.Log("💥 Bone physics re-enabled (isKinematic = false).");
                    }
                }
                break;
                
>>>>>>> 1d9e94275dfe260f498f0e4f2ee682b7432b9aea
        }

        // Resume walking if not finished
        if (index < pathPoints.Length - 1)
        {
            isPaused = false;
            animator?.SetBool("isWalking", true);
        }
        else
        {
            animator?.SetBool("isWalking", false);
<<<<<<< HEAD
            canMove = false; // stop permanently
=======
            canMove = false; // Stop permanently
>>>>>>> 1d9e94275dfe260f498f0e4f2ee682b7432b9aea
        }
    }

    // ✅ Timeline triggers
    public void StartWalkingFromTimeline()
    {
<<<<<<< HEAD
        canMove = true;
        animator?.SetBool("isWalking", true);
        animator.SetBool("isGrabBone", false);
        Debug.Log("🎬 Timeline Trigger: Dr. Paws starts moving!");
    }
  
=======
        animator.speed = 1f;
        canMove = true;
        animator?.SetBool("isWalking", true);
        animator.SetBool("isGrabBone", false);
        animator.SetBool("isSimpleGreetings", false);
        Debug.Log("🎬 Timeline Trigger: Dr. Paws starts moving!");
    }

>>>>>>> 1d9e94275dfe260f498f0e4f2ee682b7432b9aea
    public void StopWalkingFromTimeline()
    {
        canMove = false;
        isMoving = false;
        animator?.SetBool("isWalking", false);
        Debug.Log("⏸️ Timeline Trigger: Dr. Paws stops moving!");
    }
<<<<<<< HEAD
=======
  public void StartSimpleGreetings()
{
    animator.speed = 0.3f;
     animator.SetBool("isSimpleGreetings", true);
}


>>>>>>> 1d9e94275dfe260f498f0e4f2ee682b7432b9aea

    void OnDrawGizmos()
    {
        if (pathPoints == null || pathPoints.Length < 2) return;
<<<<<<< HEAD
=======

>>>>>>> 1d9e94275dfe260f498f0e4f2ee682b7432b9aea
        Gizmos.color = Color.cyan;
        for (int i = 0; i < pathPoints.Length - 1; i++)
        {
            if (pathPoints[i] != null && pathPoints[i + 1] != null)
                Gizmos.DrawLine(pathPoints[i].position, pathPoints[i + 1].position);
        }
    }
}
