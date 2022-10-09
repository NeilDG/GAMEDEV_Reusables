using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootClicker : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    [SerializeField] private GameObject cubeProjectile;

    [SerializeField] private List<GameObject> spawnedObjects = new List<GameObject>();

    // Use this for initialization
    void Start()
    {
        this.cubeProjectile.SetActive(false);
        //this.StartCoroutine(this.CleanUpBehavior(3.0f));
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = this.mainCamera.ScreenPointToRay(Input.mousePosition);
            Debug.DrawRay(ray.origin, ray.direction - new Vector3(5.0f, 5.0f, 5.0f), Color.green, 3.0f);

            RaycastHit hit;
            if (Physics.Raycast(ray.origin, ray.direction, out hit))
            {
                Debug.Log("Raycast hit: " + hit.collider.gameObject.name + " point: " + hit.point);
                this.SpawnProjectile(ray.direction, ray.direction);
            }
        }
    }

    private void SpawnProjectile(Vector3 spawnPos, Vector3 forceDirection)
    {
        GameObject cubeSpawn = GameObject.Instantiate<GameObject>(this.cubeProjectile, this.transform);
        cubeSpawn.transform.localPosition = spawnPos;
        cubeSpawn.gameObject.SetActive(true);

        Rigidbody rb = cubeSpawn.GetComponent<Rigidbody>();
        rb.AddForce(forceDirection * 1000.0f);

        this.spawnedObjects.Add(cubeSpawn);
    }

    private IEnumerator CleanUpBehavior(float secs)
    {
        yield return new WaitForSeconds(secs);

        for (int i = 0; i < this.spawnedObjects.Count; i++)
        {
            GameObject.Destroy(this.spawnedObjects[i]);
        }
        this.spawnedObjects.Clear();;

        this.StartCoroutine(this.CleanUpBehavior(secs));
    }
}
