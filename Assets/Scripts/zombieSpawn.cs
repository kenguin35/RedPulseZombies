using UnityEngine;
using System.Collections;

public class zombieSpawn : MonoBehaviour {
    public Transform zombie;
    float time;
    float uSpawnTime;
    float lSpawnTime;
    float spawnTime;
    double width;
    double length;
    // Use this for initialization
    void Start () {
        time = 0f;
        uSpawnTime = 2f;
        lSpawnTime = 1f;
        width = this.transform.lossyScale.x;
        length = this.transform.lossyScale.z;
        InvokeRepeating("createZombie", 2.0f, 0.1f);
        spawnTime = Random.Range(lSpawnTime, uSpawnTime);
    }
	
	void createZombie () {
        time += 0.1f;
        if(time>spawnTime)
        {
            Instantiate(zombie, new Vector3(this.transform.position.x, this.transform.position.y + 1, this.transform.position.z), Quaternion.identity);
            spawnTime = Random.Range(lSpawnTime, uSpawnTime);
            time = 0f;
        }

	}
}
