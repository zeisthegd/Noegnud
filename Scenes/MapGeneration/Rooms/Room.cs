using System;
using System.Collections.Generic;
using Godot;

abstract class Room
{
    private static int width = 10;
    private static int height = 8;
    private bool isSet = false;

    protected int[,] chosenTemplate;

    protected List<int[,]> templates;

    public Room(bool isSet)
    {
        this.isSet = isSet;
        templates = new List<int[,]>();
        AddTemplates();
        ChooseRandomTemplate();
    }

    protected abstract void AddTemplates();

    private void ChooseRandomTemplate()
    {
        try
        {
            int randomTemplateIndex = Convert.ToInt32(GD.Randi() % (templates.Count - 1));
            chosenTemplate = templates[randomTemplateIndex];
        }
        catch(Exception ex)
        {
            GD.Print(ex.Message);
        }
    }


    public static int Width { get => width;}
    public static int Height { get => height; }
    public bool IsSet { get => isSet; }
    public int[,] Template { get => chosenTemplate; }

    //0: Empty
    //1: Wall
    //2: Wall/Empty 50/50
}

