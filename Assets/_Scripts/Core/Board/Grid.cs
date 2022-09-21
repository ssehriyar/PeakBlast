using System;

[Serializable]
public struct Grid
{
	public int width;
	public int height;

	public Grid(int x, int y)
	{
		width = x;
		height = y;
	}
}