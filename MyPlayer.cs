using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace SingleSwordMod
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
            /*if (player.ZoneBeach && player.FindBuffIndex(BuffID.BabySlime) > -1 && liquidType == 0 && Main.dayTime && questFish == mod.ItemType("CustomFishingQuest") && Main.rand.Next(1) == 0)   // layer.ZoneBeach (is the zone required to catch the fish(zonebeach is the ocean biome))|||||||||| (player.FindBuffIndex(BuffID.BabySlime) > -1 defines the codition(example: if the player has that buff then you can catch that fish otherwise you can't)||||, the liquid where type where you can catch the fish (== 0 is water, 1 is lava, 2 is honey)||||, the time(if it's day or night to be able to catch the fish(Main.dayTime is day and !Main.dayTime is night))|||||, questFish == mod.ItemType("CustomFishingQuest") this tells the game that you need to have the customquestfish to be able to cath the fish||||, and  Main.rand.Next(1) == 0) is the chatch % chance to catch the customfish
            {
                caughtType = mod.ItemType("CustomFishingQuest"); //what fish to catch under these conditions.
            }
            if (player.ZoneJungle && liquidType == 2 && Main.dayTime && Main.rand.Next(1) == 0)   //and this is an example of how to add a fish to be able to catch it witout the quest like the crates or other fishes|||| player.ZoneJungle (is the zone required to catch the fish(ZoneJungle is the jungle biome))|||||  (player.FindBuffIndex(BuffID.BabySlime) > -1 defines the codition(example: if the player has that buff then you can catch that fish otherwise you can't)||||, the liquid where type where you can catch the fish (== 0 is water, 1 is lava, 2 is honey)||||, the time(if it's day or night to be able to catch the fish(Main.dayTime is day and !Main.dayTime is night))||||||||, and  Main.rand.Next(1) == 0) is the chatch % chance to catch the customfish
            {
                caughtType = mod.ItemType("CustomFishingQuest"); //what fish/item to catch under these conditions.
            }*/

            if (player.FindBuffIndex(BuffID.BabySlime) > -1 && liquidType == 0) // If using a slime summon and fishing in water
            {
                caughtType = mod.ItemType("OrangeFish");
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

    }

}