using Godot;
using System;

public class MapGenerator : TileMap
{
	TileMap floorMap;

	[Export]
	PackedScene stair;

	[Export]
	PackedScene monster1;
	[Export]
	PackedScene monster2;
	[Export]
	PackedScene monster3;
	[Export]
	PackedScene boss;

	const int spriteSize = 16;
	const int size = 4;
	Room[,] roomsMap = new Room[size, size];
	Random randomizer = new Random();
	Player player;

	Vector2 entranceStair;
	Vector2 exitRoom;


	public override void _Ready()
	{
		GetChildNodes();

		InitRoom();
		RandomGenRoom();
		SpawnTiles();
		for (int i = 0; i < size; i++)
		{
			GD.Print(roomsMap[i, 0] + " " + roomsMap[i, 1] + " " + roomsMap[i, 2] + " " + roomsMap[i, 3]);
		}

		SpawnExitAndEntranceStair((int)exitRoom.x, (int)exitRoom.y);
		UpdateBitmaskRegion();	
		SpawnMonsterInEveryRoom(); 
	}

	private void GetChildNodes()
	{
		try
        {
			floorMap = (TileMap)GetNode("FloorMap");
			player = Global.GetPlayer();
		}
		catch
        {

        }
		
	}

	private void InitRoom()
	{
		for (int i = 0; i < size; i++)
		{
			for (int j = 0; j < size; j++)
			{
				roomsMap[i, j] = new Room1(false);
			}
		}
	}

	private void RandomGenRoom()
	{
		int startingRoomCol = RandomInt(0, 4);
		GenerateSolutionPath(startingRoomCol, 0);
		SetPlayerStartingPosition(startingRoomCol);
		SetLeftoverRooms();
	}

	private void SpawnTiles()
	{
		SpawnOuterWallAndFloor();
		SpawnSolutionPathRooms();

	}
	private void SpawnSolutionPathRooms()
	{
		for (int i = 0; i < size; i++)
		{
			for (int j = 0; j < size; j++)
			{
				SpawnRoom(roomsMap[i, j], j, i);
			}
		}
	}

	private void GenerateSolutionPath(int roomX, int roomY)
	{
		int nextRoomDirection = RandomDirection();
		switch (nextRoomDirection)
		{
			case 1:
			case 2:
				NextLeftRoom(roomX, roomY);
				break;
			case 3:
			case 4:
				NextRightRoom(roomX, roomY);
				break;
			case 5:
				NextBottomRoom(roomX, roomY);
				break;
		}
	}
	private void NextLeftRoom(int row, int col)
	{
		if (col - 1 <= 0)
			NextBottomRoom(row, col);
		else
		{
			SetRoomBasedOnAbove(row, col);
			GenerateSolutionPath(row, col - 1);
		}
	}
	private void NextRightRoom(int row, int col)
	{
		if (col + 1 >= size)
			NextBottomRoom(row, col);
		else
		{
			SetRoomBasedOnAbove(row, col);
			GenerateSolutionPath(row, col + 1);
		}
	}
	private void NextBottomRoom(int row, int col)
	{
		if (row + 1 >= size)
			SetExitRoom(row, col);
		else
		{
			SetExactRoomType(ref roomsMap[row, col], 2);
			GenerateSolutionPath(row + 1, col);
		}

	}
	private void SetExitRoom(int row, int col)
	{
		SetExactRoomType(ref roomsMap[row, col], RandomInt(0, 4));
		exitRoom = new Vector2(col, row);
	}

	private int RandomDirection()
	{
		int randomDir = randomizer.Next(1, 6);
		return randomDir;
	}
	private int RandomInt(int min, int max)
	{
		int randomInt = randomizer.Next(min, max);
		return randomInt;
	}
	private void SetRoomBasedOnAbove(int row, int col)
	{
		if (RoomAboveIsType2(row, col))
		{
			SetExactRoomType(ref roomsMap[row, col], 2);
		}
		else SetRandomRoomType(ref roomsMap[row, col], 1);
	}
	private bool RoomAboveIsType2(int row, int col)
	{
		if (row == 0)
			return false;
		else if (roomsMap[row - 1, col] is Room2)
			return true;
		return false;
	}
	private void SetRandomRoomType(ref Room room, int minType)
	{
		int randomType = RandomInt(minType, 4);
		SetExactRoomType(ref room, randomType);
	}
	private void SetExactRoomType(ref Room room, int type)
	{
		if (!room.IsSet)
		{
			switch (type)
			{
				case 0:
					room = new Room0(true);
					break;
				case 1:
					room = new Room1(true);
					break;
				case 2:
					room = new Room2(true);
					break;
				case 3:
					room = new Room3(true);
					break;
			}
		}

	}

	//Spawning Objects
	private void SpawnOuterWallAndFloor()
	{
		int mapWidth = size * Room.Width;
		int mapHeight = size * Room.Height;
		for (int i = -1; i <= mapWidth; i++)
		{
			for (int j = -1; j <= mapHeight; j++)
			{
				if (i == -1 || j == -1 || i == mapWidth || j == mapHeight)
				{
					SpawnWall(i, j);
				}
				else SpawnFloor(i, j);
			}
		}

	}
	private void SpawnRoom(Room room, int roomX, int roomY)
	{
		for (int i = 0; i < Room.Height; i++)
		{
			for (int j = 0; j < Room.Width; j++)
			{
				int cellPosX = j + Room.Width * roomX;
				int cellPosY = i + Room.Height * roomY;

				SpawnWall(cellPosX, cellPosY, room.Template[i, j]);
			}
		}
	}
	private void SpawnWall(int i, int j)
	{
		SetCell(i, j, TileSet.FindTileByName("wall"));
	}
	private void SpawnWall(int i, int j, int type)
	{
		if (type == 2)
		{
			if (ChanceCounter.Hit(TileSpawnChances.WallChance))
			{
				SetCell(i, j, TileSet.FindTileByName("wall"));
			}
			else SpawnFloor(i, j);
		}
		else if (type == 1)
			SpawnWall(i, j);
	}
	private void SpawnFloor(int i, int j)
	{
		floorMap.SetCell(i, j, TileSet.FindTileByName("floor"));
	}
	private void SpawnStairUp(int i, int j)
	{
		SetCellv(new Vector2(i, j), TileSet.FindTileByName("stairUp"));
	}
	private async void SpawnStairDown(int i, int j)
	{
		var timer = new Timer();
		AddChild(timer);
		timer.WaitTime = 0.1F;
		timer.Start();
		await ToSignal(timer, "timeout");

		StairDown exit = (StairDown)stair.Instance();
		Global.CurrentScene.AddChild(exit);
		exit.GlobalPosition = new Vector2(i * 16 + 8, j * 32 + 8);
		SetCell(i, j, TileSet.FindTileByName("stairDown"));
		GD.Print(exit.GlobalPosition);	
	}

	private void SetLeftoverRooms()
	{
		for (int i = 0; i < size; i++)
		{
			for (int j = 0; j < size; j++)
			{
				if (roomsMap[i, j].IsSet == false)
					SetRandomRoomType(ref roomsMap[i, j], 0);
			}
		}
	}
	private void SetPlayerStartingPosition(int startRoomX)
	{
		Vector2 startingPosition = new Vector2();
		int[,] template = roomsMap[startRoomX, 0].Template;
		for (int i = 0; i < Room.Height; i++)
		{
			for (int j = 0; j < Room.Width; j++)
			{
				if (template[i, j] == 0)
				{
					if (TileIsEmpty(i + 1, j, template))
						if (TileIsEmpty(i - 1, j, template))
							if (TileIsEmpty(i, j + 1, template))
								if (TileIsEmpty(i, j - 1, template))
								{
									int cellPosX = (j + Room.Width * startRoomX) * 16 + 8;
									int cellPosY = i * 32 + 16;
									startingPosition = new Vector2(cellPosX, cellPosY);
									entranceStair = new Vector2(i + Room.Width * startRoomX, i);
									player.GlobalPosition = startingPosition;
									return;
								}
				}
			}
		}
	}


	private bool TileIsEmpty(int i, int j, int[,] template)
	{
		if(i >= 0 && j >= 0 && i < Room.Height && j < Room.Width)
		{
			if (template[i, j] == 0)
				return true;
		}
		return false;
	}

	private void SpawnExitAndEntranceStair(int exitRoomX, int exitRoomY)
	{
		SpawnStairUp((int)entranceStair.x, (int)entranceStair.y);
		try
		{
			for (int i = 0; i < Room.Height; i++)
			{
				for (int j = 0; j < Room.Width; j++)
				{
					if (roomsMap[exitRoomX, exitRoomY].Template[i, j] == 0 && roomsMap[exitRoomX, exitRoomY].Template[i + 1, j] == 0)
					{
						int cellPosX = j + Room.Width * exitRoomX;
						int cellPosY = i + Room.Height * exitRoomY;
						SpawnStairDown(cellPosX, cellPosY);
						return;
					}
				}
			}
		}
		catch(Exception ex)
		{
			GD.Print(ex.Message);
		}
	}

	

	private void SpawnMonsterInEveryRoom()
	{
		for (int i = 0; i < size; i++)
		{
			for (int j = 0; j < size; j++)
			{
				SpawnMonster(monster1, i, j);
			}
		}
	}

	private async void SpawnMonster(PackedScene monster, int roomX, int roomY)
	{
		var timer = new Timer();
		AddChild(timer);
		timer.WaitTime = 0.05F;
		timer.Start();
		await ToSignal(timer, "timeout");
		for (int i = 0; i < 3; i++)
		{
			int randX = (RandomInt(2, 9) + Room.Width * roomX) * 16 + 8;
			int randY = (RandomInt(2, 7) + Room.Height * roomY) * 32 + 16;
			Global.SpawnMonster(monster, new Vector2(randX, randY));

			
		}

	}

}
