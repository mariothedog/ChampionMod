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
        public int timer = -1;

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

            if (Main.rand.Next(70) == 0 && player.ZoneJungle && NPC.downedGolemBoss && worldLayer != 1 && liquidType == 0) // 1/70 chance of catching if in jungle, Golem dead, not on surface and fishing in water
            {
                caughtType = mod.ItemType("MemoryFish");
            }
        }

        public override void Kill(double damage, int hitDirection, bool pvp, PlayerDeathReason damageSource)
        {
            LastDeathX = player.position.X;
            LastDeathY = player.position.Y;
        }

        public override void ModifyZoom(ref float zoom)
		{
            // If player holding Snowball Rifle
            if (player.inventory[player.selectedItem].type == mod.ItemType("SnowballRifle"))
            {
			    zoom = 0.2f;
            }
		}

        public override void PreUpdate()
        {
            if (timer > 0)
            {
                timer -= 1;
            }
            // Brackets are very important because without them only the "LastDeathY != 0" needs to be true
            else if (timer == 0 && (LastDeathX != 0 || LastDeathY != 0))
            {
                // So timer doesn't decrease or teleports player/spawns dust
                timer = -1;

                // Teleport player
                player.position.X = player.GetModPlayer<MyPlayer>().LastDeathX;
                player.position.Y = player.GetModPlayer<MyPlayer>().LastDeathY;

                for (int i = 0; i < 70; i++) // Spawn lots of dust
                {
                    Dust.NewDust(new Vector2(player.position.X, player.position.Y+10f), 4, 4, 27, 0f, 0f, 100, default(Color), 1.6f);
                }
            }
        }
    }
}
