/*
 * Created by: Qadeem Qureshi
 * Date Created: 1/31/2022
 * 
 * Last Edited by: Qadeem Qureshi
 * Last Edited: Jan 31, 2022
 * 
 * Description: Controls the movement of the AppleTree 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
    [Header("Set in Inspector")]
    public float speed = 5f;
    public float leftAndRightEdge = 25f;
    public GameObject applePrefab;
    public float secondsBetweenApplesDrops = 1f;
    public float chanceToChangeDirection = 0.99f;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("DropApple", 2f);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;

        if (pos.x < -leftAndRightEdge)
            speed = Mathf.Abs(speed);
        else if (pos.x > leftAndRightEdge)
            speed = -Mathf.Abs(speed);
    }
    
    void FixedUpdate()
    {
        if (1 - Random.value > chanceToChangeDirection)
            speed *= -1;
    }

    void DropApple()
    {
        GameObject appleObj = Instantiate(applePrefab);
        appleObj.transform.position = transform.position;
        Invoke("DropApple", secondsBetweenApplesDrops);
    }
}
