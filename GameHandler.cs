using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour {

    public List<Vector2> coordinates = new List<Vector2>();
    public List<Vector2Int> openIndexes = new List<Vector2Int>();

    List<Vector2Int> snakeIndexes = new List<Vector2Int>();
    Queue<Transform> snakeSegment = new Queue<Transform>();

    public Transform snakeSegmentPrefab;
    public Transform snakeSegmentHolder;
    public GameObject streakUI;
    
    public int gridSize;
    public int excessLength;
    public int foodScore;

    public float updatePerSeconds;
    public float gridSpacing;
    public float nodeSize;

    public Vector2Int gridBounds;
    public Vector2Int snakeHeadIndex;
    public Vector2Int direction;
    public Vector2Int oldDir;

    public bool alive;
    public Material snakeMaterial;

    private SpawnFood food;

	// Use this for initialization
	void Start () {
        food = FindObjectOfType<SpawnFood>();
        alive = true;
        snakeMaterial.SetColor("_Color", Color.white);
        
        snakeSegmentPrefab.localScale = Vector3.one * nodeSize;
        gridBounds = new Vector2Int();
        direction = Vector2Int.up;

        for (float y = -gridSize / 2f; y < (gridSize / 2f) + gridSpacing; y += gridSpacing)
        {
            gridBounds += new Vector2Int(1, 1);
            for (float x = -gridSize / 2f; x < (gridSize / 2f) + gridSpacing; x += gridSpacing)
            {
                coordinates.Add(new Vector2(x, y));
            }
        }

        for (int i = 0; i < gridBounds.x; i++)
        {
            for (int j = 0; j < gridBounds.y ; j++)
            {
                openIndexes.Add(new Vector2Int(i, j));
            }
        }

        snakeHeadIndex = new Vector2Int(gridBounds.x / 2, gridBounds.y / 2);
        snakeIndexes.Add(snakeHeadIndex);
        openIndexes.Remove(snakeHeadIndex);

        snakeSegment.Enqueue(Instantiate(snakeSegmentPrefab, coordinates[snakeHeadIndex.x + snakeHeadIndex.y * gridBounds.x], Quaternion.identity, snakeSegmentHolder));
        
        StartCoroutine(MovementUpdater());
	}

    // Update is called once per frame
    void Update () {

        Vector2Int newDir = direction;
        if(Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            newDir = Vector2Int.up;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            newDir = Vector2Int.right;
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            newDir = Vector2Int.left;
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
        {
            newDir = Vector2Int.down;
        }

        if (Mathf.Abs(newDir.y) != Mathf.Abs(direction.y) && Mathf.Abs(newDir.y) != Mathf.Abs(oldDir.y))
        {
            direction = newDir;
        }
    }

    IEnumerator MovementUpdater()
    {
        while(alive)
        {
            yield return new WaitForSeconds(1f / updatePerSeconds);
            MoveSnakeHead(snakeHeadIndex + direction);
        }
    }

    public void MoveSnakeHead(Vector2Int newPos)
    {
        if(!alive)
        {
            return;
        }
        oldDir = direction;
        if (newPos.x < 0 || newPos.x >= gridBounds.x || newPos.y < 0 || newPos.y >= gridBounds.y || snakeIndexes.Contains(newPos))
        {
            alive = false;
            snakeMaterial.SetColor("_Color", Color.red);
            return;
        }

        if (newPos == food.foodIndex)
        {
            excessLength += foodScore;
            Destroy(food.foodObject.gameObject);

            streakUI.SetActive(true);
            GameManager.AddStreak();

            Score.AddScore();

            food.SpwanFoods();
        }
        Transform lastSegment = null;
        if (excessLength <= 0)
        {
            excessLength = 0;
            lastSegment = snakeSegment.Dequeue();
            openIndexes.Add(snakeIndexes[0]);
            snakeIndexes.RemoveAt(0);
        }
        else
        {
            excessLength--;
            lastSegment = Instantiate(snakeSegmentPrefab, coordinates[snakeHeadIndex.x + snakeHeadIndex.y * gridBounds.x], Quaternion.identity, snakeSegmentHolder);
        }

        snakeHeadIndex = newPos;
        snakeIndexes.Add(newPos);
        openIndexes.Remove(newPos);

        lastSegment.position = coordinates[snakeHeadIndex.x + snakeHeadIndex.y * gridBounds.x];
        snakeSegment.Enqueue(lastSegment);
    }

    
}
