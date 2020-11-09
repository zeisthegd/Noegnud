using System;
using Godot;

class Room0 : Room
{  	
	public Room0(bool isSet) :base(isSet)
	{
		
	}

	protected override void AddTemplates()
	{
		templates.Clear();
		templates.Add(template1);
		templates.Add(template2);
		templates.Add(template3);
		templates.Add(template4);
	}

	private int[,] template1 = new int[8, 10]{
		{1,2,1,2,1,2,1,2,0,2},
		{0,0,0,0,0,0,0,0,0,0},
		{1,1,0,0,0,0,0,0,1,1},
		{1,1,2,2,2,2,2,2,1,1},
		{1,1,1,1,1,1,1,1,1,1},
		{1,1,2,2,2,2,2,2,1,1},
		{2,2,0,0,0,0,0,0,2,2},
		{1,1,0,0,0,0,0,0,1,1}
	};

	private int[,] template2 = new int[8, 10]{
		{1,2,1,2,0,2,1,2,1,2},
		{0,0,0,2,1,1,2,0,0,0},
		{1,1,0,1,1,1,1,0,1,1},
		{1,1,0,2,1,1,2,0,1,1},
		{1,1,0,1,1,1,1,0,1,1},
		{1,1,0,1,2,2,1,0,1,1},
		{0,0,0,0,0,0,0,0,0,0},
		{1,1,1,1,0,2,1,1,1,1}
	};

	private int[,] template3 = new int[8, 10]{
		{1,2,1,2,0,2,1,2,1,2},
		{0,2,2,1,1,1,1,2,2,0},
		{0,0,2,1,1,1,1,2,0,0},
		{0,0,0,2,2,2,2,0,0,0},
		{0,0,0,2,2,2,2,0,0,0},
		{0,0,2,1,1,1,1,2,0,0},
		{0,2,2,1,1,1,1,2,2,0},
		{2,1,2,1,2,0,2,1,2,1}
	};

	private int[,] template4 = new int[8, 10]{
		{0,0,0,0,0,0,0,0,1,1},
		{0,0,2,2,2,2,2,0,0,0},
		{0,0,2,2,2,2,2,0,1,1},
		{0,0,2,2,2,2,2,0,1,2},
		{0,0,2,2,2,2,2,0,1,1},
		{0,0,2,2,2,2,2,0,1,1},
		{0,0,2,2,2,2,2,0,1,1},
		{1,1,1,1,1,1,1,1,1,1}
	};


	public override string ToString()
	{
		return "0";
	}
}

