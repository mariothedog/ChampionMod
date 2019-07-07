using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChampionMod.NPCs
{
    public class TileGlobal : GlobalTile
    {
        public override bool Drop(int i, int j, int type)
        {
            // i is the X position in blocks and each block is 16 pixels wide so you need to multiply it by 16 to get the X position
            // j is the Y position in blocks and each block is 16 pixels tall so you need to multiply it by 16 to get the Y position

            if (type == TileID.Trees && Main.rand.Next(2) == 0)
            {
                Item.NewItem(new Vector2(i*16, j*16), mod.ItemType("LivingLeaf"));
            }

            return true; // True to drop the default items
        }
    }
}