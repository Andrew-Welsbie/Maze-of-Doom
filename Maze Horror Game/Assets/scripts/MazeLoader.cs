using UnityEngine;
using System.Collections;

public class MazeLoader : MonoBehaviour {
	public int mazeRows, mazeColumns;
	public GameObject wall;
	public GameObject floor;
	public float size = 2f;
	//public int[] entranceValues = { }; 

	private MazeCell[,] mazeCells;
	public Transform ParentGameObject;

	// Use this for initialization
	void Start () {
		InitializeMaze ();

		MazeAlgorithm ma = new HuntAndKillMazeAlgorithm (mazeCells);
		ma.CreateMaze ();
	}
	
	// Update is called once per frame
	void Update () {
	}

	private void InitializeMaze() {

		
		mazeCells = new MazeCell[mazeRows,mazeColumns];

		for (int r = 0; r < mazeRows; r++) {
			for (int c = 0; c < mazeColumns; c++) {
				mazeCells [r, c] = new MazeCell ();

				// For now, use the same wall object for the floor!
				mazeCells [r, c] .floor = Instantiate (floor, new Vector3 (r*size, -(size/2f), c*size), Quaternion.identity) as GameObject;
				mazeCells [r, c] .floor.name = "Floor " + r + "," + c;
				//mazeCells [r, c] .floor.transform.Rotate (Vector3.right, 90f);
				mazeCells[r, c].floor.transform.parent = ParentGameObject;

				if (c == 0) {
					mazeCells[r,c].westWall = Instantiate (wall, new Vector3 (r*size, 0, (c*size) - (size/2f)), Quaternion.identity) as GameObject;
					mazeCells [r, c].westWall.name = "West Wall " + r + "," + c;
					mazeCells[r, c].westWall.transform.parent = ParentGameObject;
				}

				mazeCells [r, c].eastWall = Instantiate (wall, new Vector3 (r*size, 0, (c*size) + (size/2f)), Quaternion.identity) as GameObject;
				mazeCells [r, c].eastWall.name = "East Wall " + r + "," + c;
				mazeCells[r, c].eastWall.transform.parent = ParentGameObject;

				if (r == 0) {
					mazeCells [r, c].northWall = Instantiate (wall, new Vector3 ((r*size) - (size/2f), 0, c*size), Quaternion.identity) as GameObject;
					mazeCells [r, c].northWall.name = "North Wall " + r + "," + c;
					mazeCells [r, c].northWall.transform.Rotate (Vector3.up * 90f);
					mazeCells[r, c].northWall.transform.parent = ParentGameObject;
				}

				mazeCells[r,c].southWall = Instantiate (wall, new Vector3 ((r*size) + (size/2f), 0, c*size), Quaternion.identity) as GameObject;
				mazeCells [r, c].southWall.name = "South Wall " + r + "," + c;
				mazeCells [r, c].southWall.transform.Rotate (Vector3.up * 90f);
				mazeCells[r, c].southWall.transform.parent = ParentGameObject;

				addEntrance(r, c);
			}
		}
	}

	private void addEntrance (int r, int c)
    {
		if (r < mazeRows && c < mazeColumns)
        {
			if (r == mazeRows / 2 && c == 0)
			{
				GameObject.Destroy(mazeCells[r, c].northWall);
				GameObject.Destroy(mazeCells[r, c].eastWall);
				GameObject.Destroy(mazeCells[r, c].southWall);
				GameObject.Destroy(mazeCells[r, c].westWall);
			}
		}
    }
}


