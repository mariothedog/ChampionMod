using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChampionMod
{
    public class MyPlayer : ModPlayer
    {
        private const int saveVersion = 0;
        public bool Bunny = false;
        public static bool hasProjectile;
        public bool BunnyMinion;
        public float LastDeathX;
        public float LastDeathY;

        public override void ResetEffects()
        {
            Bunny = false;
            BunnyMinion = false;
        }

        public override void CatchFish(Item fishingRod, Item bait, int power, int liquidType, int poolSize, int worldLayer, int questFish, ref int caughtType, ref bool junk)
        {
            if (junk)
            {
                return;
            }

            if (player.ZoneJungle && NPC.downedGolemBoss && worldLayer != 1 && liquidType == 0) // If in jungle, Golem dead, not on surface and fishing in water
            {
                caughtType = mod.ItemType("MemoryFish");
            }
        }

        public override void Kill(double damage, int hitDirection, bool pvp, PlayerDeathReason damageSource)
        {
            LastDeathX = player.position.X;
            LastDeathY = player.position.Y;
        }

        /*public override void PostItemCheck()
        {
            if(player.inventory[player.selectedItem].type == mod.ItemType("DualFlareshot"))
            {
                if (player.direction == 1)
                {
                    player.itemLocation.X -= 70;
                    player.itemLocation.Y -= 20;
                }
                else
                {
                    player.itemLocation.X += 20;
                    player.itemLocation.Y -= 20;
                }
            }
        }*/

    }

}
