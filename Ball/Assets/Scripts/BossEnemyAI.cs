using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossEnemyAI : MonoBehaviour
{
    //public AIBaseState currentState;
    private float changeDirTime = 1;
    private float timeUntilChangeDir = 0f;
    private bool changeDirDone = false;
    Vector3 finalPosition = Vector3.zero;
    public Transform pos;

    public Player player;
    
    public Rigidbody rb;
    public Transform target;
    public float speed;
    public float turnSpeed;

    private Vector3 dir;
    public NavMeshAgent navigator;

    public float sightRange;
    public float closeRange;

    public AIBaseState currentState;
    public BossStateIdle idleState = new BossStateIdle();
    public BossStateChase chaseState = new BossStateChase();
    public BossStateCharge chargeState = new BossStateCharge();


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        pos = GetComponent<Transform>();
        navigator = gameObject.GetComponent<NavMeshAgent>();
        ChangeState(idleState);
    }

    // Update is called once per fram
    void FixedUpdate()
    {
        currentState.Update(this);
        //transform.forward.z
        //Move();
        Debug.Log(pos);
        /*AIBaseState returnState = currentState?.Update(this);

        if (returnState != currentState)
        {
            ChangeState(returnState);
        }*/

        if (target != null)
        {
            RotateTowards(target);
        }
        //currentState.Update(this);
    }

    public void Move()
    {
        navigator.SetDestination(target.position);

        rb.velocity = transform.forward * speed * Time.deltaTime;
    }
    public void RoamAround()
    {
        timeUntilChangeDir = changeDirDone ? changeDirTime : timeUntilChangeDir - Time.fixedDeltaTime;
        changeDirDone = (timeUntilChangeDir <= 0);
        if (changeDirDone)
        {
            navigator.SetDestination(RandomNavmeshLocation(pos, 25f));

            rb.velocity = transform.forward * speed * Time.deltaTime;

            changeDirTime = UnityEngine.Random.Range(0.8f, 1.3f);
            
        }

        /*if (inputManager.navigator.path.corners.Length >= 2)
        {
            var node = inputManager.navigator.path.corners[1];
            var dirVector = (node - inputManager.GetCharacter().transform.position).normalized;
            aimTo = ExtensionMethods.DirectionFromVector(dirVector);
        }*/
        //navigator.SetDestination(RandomNavmeshLocation(inputManager.GetCharacter().transform, 25f));
    }

    public void RotateTowards(Transform target)
    {
        Vector3 direction = (target.position - transform.position).normalized;
        /*Quaternion lookRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed);*/

        //Debug.Log("dir: " + direction + " " + "lookrot: " + lookRotation);
        //Debug.Log(lookRotation.y);
        dir = direction;
    }
    public void ChangeState(AIBaseState state)
    {
        currentState = state;
        currentState.EnterState(this);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            player.Knockback(dir + new Vector3(0, 1, 0), 1000);
            //Debug.Log(dir);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, sightRange);
        Gizmos.DrawWireSphere(transform.position, closeRange);
    }

    public Vector3 RandomNavmeshLocation(Transform transform, float radius)
    {
        Vector3 randomDirection = UnityEngine.Random.insideUnitSphere * radius;
        randomDirection += transform.position;
        NavMeshHit hit;

        NavMesh.SamplePosition(randomDirection, out hit, radius, 1);

        finalPosition = hit.position;

        return finalPosition;
    }
}
