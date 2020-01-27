using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFood : MonoBehaviour {

    private GameHandler game;

    public Transform[] foodPrefab;
    public Transform foodObject;
    public Vector2Int foodIndex;

    // Use this for initialization
    void Start () {
        game = GetComponent<GameHandler>();

        SpwanFoods();
    }

    public void SpwanFoods()
    {
        Vector2Int newFoodPos = game.openIndexes[Random.Range(0, game.openIndexes.Count)];
        foodIndex = newFoodPos;
        foodObject = Instantiate(foodPrefab[Random.Range(0, foodPrefab.Length)], transform);
        foodObject.transform.position = game.coordinates[newFoodPos.x + newFoodPos.y * game.gridBounds.x];
    }
}
