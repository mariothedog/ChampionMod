using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.GameContent.Generation;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.World.Generation;

namespace ChampionMod
{
    class ChampionWorld : ModWorld
    {
        public override void ModifyWorldGenTasks(List<GenPass> tasks, ref float totalWeight)
        {
            //int genIndex = tasks.FindIndex(genpass => genpass.Name.Equals("Micro Biomes"));
            int genIndex = tasks.FindIndex(genpass => genpass.Name.Equals("Jungle Trees"));
            tasks.Insert(genIndex + 1, new PassLegacy("ThunderRavagedPlateau", ThunderPlateau));
        }

        public void ThunderPlateau(GenerationProgress progress)
        {
            progress.Message = "Placing a plateau in the jungle";

            /*int jungleCloseX = 0;
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
                if (!Main.tile[jungleMiddleX, y].active()) // If air
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

            //for (int x = baseStartX; x < baseEndX; x++)
            //{
            //    for (int y = jungleSurfaceY; y > baseEndY; y--)
            //    {
            //        //Main.tile[x, y].type = (ushort)mod.TileType("PlateauBrickTile");
            //        WorldGen.PlaceTile(x, y, mod.TileType("PlateauBrickTile"));
            //    }
            //}
            //Main.tile[jungleMiddleX, jungleSurfaceY].type = (ushort)mod.TileType("PlateauBrickTile");
            for (int y = jungleSurfaceY; y > jungleSurfaceY - 100; y--)
            {
                Main.tile[jungleMiddleX, y].type = (ushort)mod.TileType("PlateauBrickTile");
                //if (Main.tile[jungleMiddleX, y].type != (ushort)mod.TileType("PlateauBrickTile"))
                //{
                //    WorldGen.PlaceTile(jungleMiddleX, y, mod.TileType("PlateauBrickTile"));
                //}
            }

            for (int x = baseStartX; x < baseEndX; x++)
            {
                Main.tile[x, jungleSurfaceY].type = (ushort)mod.TileType("PlateauBrickTile");
                //if (Main.tile[x, jungleSurfaceY].type != (ushort)mod.TileType("PlateauBrickTile"))
                //{
                //    WorldGen.PlaceTile(x, jungleSurfaceY, mod.TileType("PlateauBrickTile"));
                //}
            }*/
        }
    }
}
