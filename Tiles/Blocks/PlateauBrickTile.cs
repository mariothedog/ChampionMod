﻿using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChampionMod.Tiles.Blocks
{
    class PlateauBrickTile : ModTile
    {
        public override void SetDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileMergeDirt[Type] = true;
            Main.tileBlockLight[Type] = true;
            Main.tileLighted[Type] = true;
            drop = mod.ItemType("PlateauBrick");
            AddMapEntry(new Color(113, 150, 139)); // Color of the tile on the map
        }

        public override void PlaceInWorld(int i, int j, Item item)
        {
            int jungleCloseX = 0;
            int Y = Main.spawnTileY + 200; // + 200 (down 200) in case spawn is higher than the jungle

            // Find jungle position

            // Jungle X position that is closest to spawn
            bool isDungeonLeft = Main.dungeonX < Main.spawnTileX; // The jungle spawns on the opposite side of the dungeon
            // If the dungeon is on the left then it must look right and vice versa
            for (int x = Main.spawnTileX;
                (isDungeonLeft ? x < Main.maxTilesX : x > 0) && jungleCloseX == 0;
                x += isDungeonLeft ? 1 : -1)
            {
                if (Main.tile[x, Y].type == TileID.JungleGrass)
                {
                    jungleCloseX = x;
                }
            }

            // Jungle X position that is farthest away from spawn
            int jungleFarX = 0;
            for (int x = isDungeonLeft ? Main.maxTilesX - 1 : 0;
                (isDungeonLeft ? x > Main.spawnTileX : x < Main.spawnTileX) && jungleFarX == 0;
                x += isDungeonLeft ? -1 : 1)
            {
                if (Main.tile[x, Y].type == TileID.JungleGrass)
                {
                    jungleFarX = x;
                }
            }

            // Middle of the jungle
            int jungleMiddleX = (jungleCloseX + jungleFarX) / 2;

            // Find jungle surface
            int jungleSurfaceY = 0;
            int length = 0;
            for (int y = Y; y > 0 && length < 100; y--)
            {
                /*if (t == TileID.Grass || t == TileID.JungleGrass || t == TileID.JunglePlants || t == TileID.JunglePlants2 || t == TileID.JungleThorns || t == TileID.JungleVines || t == TileID.Trees)
                {
                    Main.NewText(t);
                }*/
                int type = Main.tile[jungleMiddleX, y].type;
                if (!Main.tile[jungleMiddleX, y].active() || type == TileID.Trees || type == TileID.Grass || type == TileID.JungleGrass || type == TileID.JunglePlants || type == TileID.JunglePlants2 || type == TileID.JungleThorns || type == TileID.JungleVines)
                {
                    if (length == 0) // So it gets the bottom air tile of the "air chain"
                    {
                        jungleSurfaceY = y;
                    }
                    length += 1;
                }
                else
                {
                    length = 0;
                }
            }
            //jungleSurfaceY += 50;

            int baseWidth = 80;
            int baseStartX = jungleMiddleX - baseWidth / 2;
            int baseEndX = jungleMiddleX + baseWidth / 2;
            int baseHeight = 60;
            int baseEndY = jungleSurfaceY - baseHeight;

            /*for (int x = baseStartX; x < baseEndX; x++)
            {
                for (int y = jungleSurfaceY; y > baseEndY; y--)
                {
                    //Main.tile[x, y].type = (ushort)mod.TileType("PlateauBrickTile");
                    WorldGen.PlaceTile(x, y, mod.TileType("PlateauBrickTile"));
                }
            }*/
            //Main.tile[jungleMiddleX, jungleSurfaceY].type = (ushort)mod.TileType("PlateauBrickTile");
            //Main.NewText(mod.TileType("PlateauBrickTile"));
            //Main.NewText((ushort)mod.TileType("PlateauBrickTile"));
            //Main.NewText(" ");

            /*for (int y = jungleSurfaceY; y > jungleSurfaceY - 100; y--)
            {
                //Main.tile[jungleMiddleX, y].type = (ushort)mod.TileType("PlateauBrickTile");
                Main.tile[jungleMiddleX, y].ResetToType((ushort)mod.TileType("PlateauBrickTile"));
                //Main.NewText(Main.tile[jungleMiddleX, y].active());
                //if (Main.tile[jungleMiddleX, y].type != (ushort)mod.TileType("PlateauBrickTile"))
                //{
                //    WorldGen.PlaceTile(jungleMiddleX, y, mod.TileType("PlateauBrickTile"));
                //}
            }

            for (int x = baseStartX; x < baseEndX; x++)
            {
                //Main.tile[x, jungleSurfaceY].type = (ushort)mod.TileType("PlateauBrickTile");
                Main.tile[x, jungleSurfaceY].ResetToType((ushort)mod.TileType("PlateauBrickTile"));
                //Main.NewText(Main.tile[x, jungleSurfaceY].active());
                //if (Main.tile[x, jungleSurfaceY].type != (ushort)mod.TileType("PlateauBrickTile"))
                //{
                //    WorldGen.PlaceTile(x, jungleSurfaceY, mod.TileType("PlateauBrickTile"));
                //}
            }*/

            for (int x = baseStartX; x < baseEndX; x++)
            {
                for (int y = jungleSurfaceY; y > baseEndY; y--)
                {
                    //Main.tile[x, y].type = (ushort)mod.TileType("PlateauBrickTile");
                    //WorldGen.PlaceTile(x, y, mod.TileType("PlateauBrickTile"));

                    //Main.tile[x, y].ResetToType((ushort)mod.TileType("PlateauBrickTile"));
                }
            }
        }
    }
}