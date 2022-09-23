
public enum GameState
{
	Loading,
	Play,
	Win,
	Fail,
}

public enum MatchType
{
	None,
	Red,
	Green,
	Blue,
	Yellow,
	Purple,
	Special,
}

public enum ItemType
{
	RedCube,
	GreenCube,
	BlueCube,
	YellowCube,
	PurpleCube,
	Balloon,
	Duck,
	LeftRocket,
	RightRocket,
	None,
}

public enum Direction
{
	Left = 0,
	Up = 1,
	Right = 2,
	Down = 3
}

public enum AudioType
{
	CubeCollect,
	CubeExplode,
	Balloon,
	Duck,
}