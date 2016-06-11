using UnityEngine;

[System.Serializable]
public class Map : MonoBehaviour {

	public const int ASTEROID_ID = -1;
	public const int NO_ID = -2;
	public const int EMPTY_ID = 0; 
	public int tile_size_x;
	public int tile_size_y;
	public int width;
	public int height;
	public Vec2i begin;
	public Vec2i end;
    public new string name;
	public Vec2i[] asteroids;
	private int[][] grid;
	private GameObject[][] tileGrid;
	public GameObject asteroidTile;
	public GameObject emptyTile;
	public GameObject bg;
	public GameObject camObj;
	private Camera cam;

	void updateBgScaling() {
		SpriteRenderer sr = bg.GetComponent<SpriteRenderer>();

 		float worldScreenHeight = cam.orthographicSize * 2;
 		float worldScreenWidth = worldScreenHeight / Screen.height * Screen.width;
         
		 bg.GetComponent<Transform>().localScale = new Vector3(
     	worldScreenWidth / sr.sprite.bounds.size.x,
     	worldScreenHeight / sr.sprite.bounds.size.y, 1);
	}

	public bool IsAsteroid(int x, int y) {
		if (asteroids != null) {
			foreach (Vec2i tmp in asteroids) {
				if (tmp.x == x && tmp.y == y)
					return (true);
			}
		}
		return false;
	}

	private void InitGrid() {
		grid = new int[this.height][];
		for (int y = 0; y < this.height; ++y) {
			grid[y] = new int[this.width];
			for (int x = 0; x < this.width; ++x) {
				if (IsAsteroid(x, y) == true)
					grid[y][x] = ASTEROID_ID;
				else
					grid[y][x] = EMPTY_ID;
			}
		}
	}


	private void InitTileGrid() {
		tileGrid = new GameObject[this.height][];
		for (int y = 0; y < this.height; ++y) {
			tileGrid[y] = new GameObject[this.width];
			for (int x = 0; x < this.width; ++x) {
				if (IsAsteroid(x, y) == true)
					tileGrid[y][x] = (GameObject) Object.Instantiate(asteroidTile, new Vector3(x * tile_size_x, y * tile_size_y, 0.0f), Quaternion.identity);
				else
					tileGrid[y][x] = (GameObject) Object.Instantiate(emptyTile, new Vector3(x * tile_size_x, y *tile_size_y, 0.0f), Quaternion.identity);
			}
		}
	}

	private void InitBg() {
		bg = (GameObject) Object.Instantiate(bg, new Vector3(0, 0, 0), Quaternion.identity);
	}

	public int GetIdAt(int x, int y) {
		return (grid[y][x]);
	}

	public bool IsCellFree(int x, int y) {
		return (grid[y][x] == EMPTY_ID);
	}

	public Vec2i getIdPos(int id)
	{
		for (int y = 0 ; y < height ; ++y)
		{
			for (int x = 0 ; x < width ; ++x)
			{
				if (grid[y][x] == id)
					return (new Vec2i(x, y));
			}
		}
		return null;
	}

    // Use this for initialization
    void Start () {
		cam = camObj.GetComponent<Camera>();
		float newHeight = 4.8f;
    	// If the camera is less than 8:4.8 (= 5:3) wide
    	if (Screen.width / ((float)Screen.height) < 5f / 3f)
        	newHeight = Screen.height / ((float)Screen.width) * 8;
     	cam.orthographicSize = newHeight / 2;
		updateBgScaling();
		InitGrid();
		InitTileGrid();
		InitBg();
	}
	
	// Update is called once per frame
	void Update () {
		bool isUpdate = false;

		if (Input.GetKey(KeyCode.UpArrow)) {
			cam.transform.Translate(0, .1f, 0);
			bg.transform.Translate(0, .1f, 0);
			isUpdate = true;
		}
		if (Input.GetKey(KeyCode.DownArrow)) {
			cam.transform.Translate(0, -.1f, 0);
			bg.transform.Translate(0, -.1f, 0);
			isUpdate = true;
		}
		if (Input.GetKey(KeyCode.LeftArrow)) {
			cam.transform.Translate(-.1f, 0, 0);
			bg.transform.Translate(-.1f, 0, 0);
			isUpdate = true;
		}
		if (Input.GetKey(KeyCode.RightArrow)) {
			cam.transform.Translate(.1f, 0, 0);
			bg.transform.Translate(.1f, 0, 0);
			isUpdate = true;
		}
	    if (Input.GetKey(KeyCode.PageUp)) {
        	cam.orthographicSize -= .1f;
			isUpdate = true;
		}
        if (Input.GetKey(KeyCode.PageDown)) {
    		cam.orthographicSize += .1f;
			isUpdate = true;
		}
		if (isUpdate == true)
			updateBgScaling();
	}
}
