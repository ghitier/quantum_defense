using UnityEngine;

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
		InitGrid();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
