using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class TextureHandler
{
	public static void ChangePlayerTexture(Sprite spriteSheet, string spriteSheetPath)
	{
		var playerTexture = (Texture)ResourceLoader.Load(spriteSheetPath);
		spriteSheet.Texture = playerTexture;
	}


}

