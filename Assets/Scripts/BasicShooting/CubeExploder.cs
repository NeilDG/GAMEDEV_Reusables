using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeExploder : MonoBehaviour
{
    [SerializeField] private GameObject spawnCopy;
    [SerializeField] private List<GameObject> spawns;

    // Start is called before the first frame update
    void Start()
    {
        this.spawnCopy.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnDestroy()
    {
        for (int i = 0; i < this.spawns.Count; i++)
        {
            GameObject.Destroy(this.spawns[i]);
        }

        this.spawns.Clear();
    }

    void OnCollisionEnter(Collision other)
    {

        if (other.gameObject.name != this.name)
        {
            this.DestroyBehavior();
        }
    }

    private void DestroyBehavior()
    {
        //hide parent object
        this.gameObject.SetActive(false);

        //spawn multiple objects of smaller size
        int count = 75;
        for (int i = 0; i < count; i++)
        {
            Vector3 localPos = this.gameObject.transform.localPosition;
            //spread for cooler effect
            localPos.x += Random.Range(-0.2f, 0.2f);
            localPos.y += Random.Range(-0.2f, 0.2f);
            localPos.z += Random.Range(-0.2f, 0.2f);

            GameObject myObj = ObjectUtils.SpawnDefault(this.spawnCopy, this.transform.parent, localPos);
            myObj.SetActive(true);
            this.spawns.Add(myObj);
        }
    }
}
