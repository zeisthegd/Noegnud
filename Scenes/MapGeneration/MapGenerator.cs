using Godot;
using System;

public class MapGenerator : Node2D
{
	TileMap tileMap;


	const int spriteSize = 16;
	const int size = 4;
	Room[,] roomsMap = new Room[size, size];
	Random randomizer = new Random();

	public override void _Ready()
	{
		tileMap = (TileMap)GetNode("TileMap");
		InitRoom();
		RandomGenRoom();
		SpawnTiles();
		for (int i = 0; i < size; i++)
		{
			GD.Print(roomsMap[i, 0] + " " + roomsMap[i, 1] + " " + roomsMap[i, 2] + " " + roomsMap[i, 3]);
		}

		tileMap.UpdateBitmaskRegion();
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
		GenerateSolutionPath(0, startingRoomCol);
	}

	private void SpawnTiles()
	{
		SpawnOuterWallAndFloor();
		SpawnInnerRooms();
	}

	private void SpawnInnerRooms()
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
		SetExactRoomType(ref roomsMap[row, col], -1);
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

	private bool RoomAboveIsType2(int row, int col)
	{
		if (row == 0)
			return false;
		else if (roomsMap[row - 1, col] is Room2)
			return true;
		return false;
	}

	private void SetRoomBasedOnAbove(int row, int col)
	{
		if (RoomAboveIsType2(row, col))
		{		
			SetRandomRoomType(ref roomsMap[row, col], 2);		
		}   
		else SetRandomRoomType(ref roomsMap[row, col], 1);
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
					tileMap.SetCell(i, j, tileMap.TileSet.FindTileByName("wall"));
				}
				else tileMap.SetCell(i, j, tileMap.TileSet.FindTileByName("floor"));
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
				if (room.Template[i, j] == 1)
				{
					tileMap.SetCell(cellPosX, cellPosY, tileMap.TileSet.FindTileByName("wall"));
				}
			}
		}
	}

	private void SetRandomRoomType(ref Room room, int minType)
	{
		int randomType = RandomInt(minType, 4);
		SetExactRoomType(ref room, randomType);
	}
}
