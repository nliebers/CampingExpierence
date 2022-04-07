using UnityEngine;
using System.Collections;
using TMPro;
 
public class WanderingAI : MonoBehaviour {
 
    public float wanderRadius;
    public float wanderTimer;
	public bool dead = false;
    public GameObject player;
	public TextMeshProUGUI fishingTask;
    private GameObject deadFish;
	private GameObject TaskManager;
    private GameObject table;
 
    private Transform target;
	private Animation movingAnim;
    private UnityEngine.AI.NavMeshAgent agent;
    private bool beingHunted = false;
    private float timer;
 
	private void Start() {
		movingAnim = transform.GetComponent<Animation>();
		TaskManager = GameObject.Find("TaskManager");
		movingAnim.Play("fin");
        deadFish = GameObject.Find("TailorsculptedLOD0WithAnim");
        table = GameObject.Find("FishTable");
	}
 
    void OnEnable () {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent> ();
        timer = wanderTimer;
    }
 
    void Update () {
        timer += Time.deltaTime;

        if (Vector3.Distance(player.transform.position, transform.position) <= 2.0f)
        {
            beingHunted = true;
        }
        else {
            beingHunted = false;
            agent.speed = 0.1f;
        }

        if (timer >= wanderTimer && !dead && !beingHunted)
        {
            Vector3 newPos = RandomNavSphere(transform.position, wanderRadius, -1);
            FaceTarget(newPos);
            agent.SetDestination(newPos);
            timer = 0;
        }
        else if (beingHunted) {
            Debug.Log("being hunted");
            agent.speed = 2.5f;
            Vector3 newPos = player.transform.forward * 7.0f;
            FaceTarget(newPos);
            agent.SetDestination(newPos);
        }
    }
	
	private void FaceTarget(Vector3 destination)
	{
		Vector3 lookPos = agent.destination - transform.position;
		lookPos.y = 0;
		Quaternion rotation = Quaternion.LookRotation(lookPos);
		transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 0.1f);  
	}
 
    public static Vector3 RandomNavSphere(Vector3 origin, float dist, int layermask) {
        Vector3 randDirection = Random.insideUnitSphere * dist;
 
        randDirection += origin;
 
        UnityEngine.AI.NavMeshHit navHit;
 
        UnityEngine.AI.NavMesh.SamplePosition (randDirection, out navHit, dist, layermask);
 
        return navHit.position;
    }
	
	public void setDeathDestination(){
		Vector3 dest = transform.position + new Vector3(0.0f, 1.0f, 0.0f);
		fishingTask.text = "<s>-  Catch Fish</s>";
		TaskManager.GetComponent<TaskManager>().fish = true;
		movingAnim.Stop("fin");
		movingAnim.Play("dead");
		agent.ResetPath();
		agent.SetDestination(dest);
        Vector3 locationOnTable = new Vector3(Random.Range(table.transform.position.x - .6f, table.transform.position.x + .6f), table.transform.position.y + 1.5f, Random.Range(table.transform.position.z - .6f, table.transform.position.z + .6f));
        Instantiate(deadFish, locationOnTable, Quaternion.identity * Quaternion.Euler(90f, 0f, 0f));
	}
}
