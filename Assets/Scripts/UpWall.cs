using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpWall : Wall
{
    public GameObject upWallPrefab;
    public GameObject bottomWallPrefab;
    public GameObject pointLocationPrefab;
    private bool isApplicationQuitting;

    void OnApplicationQuit()
    {
        isApplicationQuitting = true;
    }

    public override void OnBecameInvisible()
    {
        base.OnBecameInvisible();
        if (!isApplicationQuitting)
        {
            createNewItems();
        }
    }

    private void createNewItems()
    {
        float upWallHeight = UnityEngine.Random.Range(1f, 5f);
        float wallsGap = UnityEngine.Random.Range(upWallHeight + 4f, 9.0f);
        float bottomWallHeight = 10f - wallsGap;
        float pointLocationHeight = 10f - (upWallHeight + bottomWallHeight);
        float pointLocationPosition = pointLocationHeight / 2 + bottomWallHeight -5f;
        float wallsPosition = UnityEngine.Random.Range(14f, 18f);
        createNewUpWall(upWallHeight, wallsPosition);
        createNewBottomWall(bottomWallHeight, wallsPosition);
        createNewPointLocation(pointLocationHeight, wallsPosition, pointLocationPosition);
    }

    private void createNewUpWall(float height, float wallsPosition)
    {
        GameObject upWallGameObject = Instantiate(upWallPrefab, new Vector3(wallsPosition, 5f, 0), Quaternion.identity);
        // manually setting the upWall prefab because the Prefab itself cannot have a reference to itself for some reason,
        // see https://forum.unity.com/threads/how-do-you-reference-an-objects-underlying-prefab.1184899/
        upWallGameObject.GetComponent<UpWall>().upWallPrefab = upWallPrefab;
        upWallGameObject.transform.localScale = new Vector3(1f, height * 2, 1f);
    }

    private void createNewBottomWall(float height, float wallsPosition)
    {
        GameObject bottomWallGameObject = Instantiate(bottomWallPrefab, new Vector3(wallsPosition, -5f, 0), Quaternion.identity);
        bottomWallGameObject.transform.localScale = new Vector3(1f, height * 2, 1f);
    }

    private void createNewPointLocation(float height, float wallsPosition, float pointLocationPosition)
    {
        GameObject pointLocationGameObject = Instantiate(pointLocationPrefab, new Vector3(wallsPosition, pointLocationPosition, 0), Quaternion.identity);
        pointLocationGameObject.transform.localScale = new Vector3(1f, height, 1f);
    }

}
