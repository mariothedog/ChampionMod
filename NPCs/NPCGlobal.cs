using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChampionMod.NPCs
{
    public class NPCGlobal : GlobalNPC
    {
        readonly static List<int> bloodMoonEnemies = new List<int>() // Enemies that spawn during a blood moon
        { NPCID.TheGroom, NPCID.TheBride, NPCID.BloodZombie, NPCID.Drippler, // Common
        NPCID.CorruptBunny, NPCID.CorruptGoldfish, NPCID.CorruptPenguin, // Corruption
        NPCID.CrimsonBunny, NPCID.CrimsonGoldfish, NPCID.CrimsonPenguin, // Crimson
        NPCID.Clown}; // Hardmode
		
		readonly static List<int> sporeEnemies = new List<int>() { NPCID.FungiBulb, NPCID.ZombieMushroom, NPCID.AnomuraFungus, NPCID.MushiLadybug, NPCID.ZombieMushroomHat, NPCID.GiantFungiBulb, NPCID.FungoFish };

        public override void NPCLoot(NPC npc)
        {
            if (npc.type == NPCID.KingSlime)
            {
                if (!Main.expertMode) // If it is expert it will drop from the bag anyway, see BossBags.cs
                {
                    // Only if not expert (5-15 inclusive)
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("KingsGel"), Main.rand.Next(5, 16));
                }
            }

            if (npc.type == NPCID.EyeofCthulhu && NPC.downedBoss2)
            {
                if (!Main.expertMode)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("OpticalResidue"));
                }
            }

            if (npc.type == NPCID.BrainofCthulhu)
            {
                if (!Main.expertMode)
                {
                    if (Main.rand.Next(2) == 0)
                    {
                        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("BaronsBlade"));
                    }
                }
            }
	    
	    if (npc.type == NPCID.Harpy)
            {
                if (Main.rand.Next(50) == 0)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("SkyBlue"));
                }
            }

            if (npc.type == NPCID.IchorSticker)
            {
                if (Main.rand.Next(50) == 0) // 2% item rarity
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("IchorBlaster"));
                }
            }
			
			if (npc.type == NPCID.BoneSerpentHead)
            {
                if (Main.rand.Next(50) == 0) // 2% item rarity
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("SerpentsSpine"));
                }
            }


            if (npc.type == NPCID.GoblinSummoner)
            {
                if (Main.expertMode)
                {
                    if (Main.rand.Next(3) == 0) // 33.3% drop chance
                    {
                        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ShadowflameSkullStaff"));
                    }
                }
                else
                {
                    if (Main.rand.Next(6) == 0) // 16.7% drop chance
                    {
                        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ShadowflameSkullStaff"));
                    }
                }
            }

            if (npc.type == NPCID.IceElemental)
            {
                if (Main.rand.Next(2) == 0)
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("WhimsicalShard"));
                }
            }

            if (bloodMoonEnemies.Contains(npc.type))
            {
                if (Main.expertMode)
                {
                    if (Main.rand.Next(200) == 0) // 0.5% drop chance
                    {
                        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("AgonyBearer"));
                    }
                }
                else
                {
                    if (Main.rand.Next(400) == 0) // 0.25% drop chance
                    {
                        Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("AgonyBearer"));
                    }
                }
            }

            if (sporeEnemies.Contains(npc.type))
            {
                if (Main.rand.Next(50) == 0)
                {
                    Item.NewItem(npc.getRect(), mod.ItemType("Mushblade"));
                }
            }
        }

        public override void SetupShop(int type, Chest shop, ref int nextSlot)
        {
            // downedBoss1 - Eye of Cthulhu
            // downedBoss2 - Eater of Worlds/Brain of Cthulhu
            // downedBoss3 - Skeletron
            // downedMechBoss1 - The Destroyer
            // downedMechBoss2 - The Twins
            // downedMechBoss3 - Skeletron Prime

            if (type == NPCID.ArmsDealer && (Main.LocalPlayer.ZoneDesert || Main.LocalPlayer.ZoneUndergroundDesert) && NPC.downedBoss2)
            {
                shop.item[nextSlot].SetDefaults(mod.ItemType("RiskRevolver"));
                nextSlot++;
            }

            if (type == NPCID.WitchDoctor && NPC.downedBoss3)
            {
                shop.item[nextSlot].SetDefaults(mod.ItemType("DevilsKnife"));
                nextSlot++;
            }
        }

        public override bool? CanBeHitByItem(NPC npc, Player player, Item item)
        {
            if (item.type == mod.ItemType("DevilsKnife"))
            {
                return true;
            }

            return base.CanBeHitByItem(npc, player, item);
        }

        public override void ModifyHitByItem(NPC npc, Player player, Item item, ref int damage, ref float knockback, ref bool crit)
        {
            if (npc.friendly && item.type == mod.ItemType("DevilsKnife"))
            {
                damage = npc.life; // Kills NPC
                knockback = 0;
                crit = true;
                player.AddBuff(BuffID.Cursed, 300); // Cursed debuff for 5 seconds
            }
        }
    }
}