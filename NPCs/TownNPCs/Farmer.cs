using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace ChampionMod.NPCs.TownNPCs
{
    // [AutoloadHead] and npc.townNPC are extremely important and absolutely both necessary for any Town NPC to work at all.
    [AutoloadHead]
    public class Farmer : ModNPC
    {
        //public override string Texture => "ChampionMod/NPCs/TownNPCs/Farmer";

        //public override string[] AltTextures => new[] { "ChampionMod/NPCs/TownNPCs/ExamplePerson_Alt_1" };

        public override bool Autoload(ref string name)
        {
            name = "Farmer";
            return mod.Properties.Autoload;
        }

        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[npc.type] = 25;
            NPCID.Sets.ExtraFramesCount[npc.type] = 9;
            NPCID.Sets.AttackFrameCount[npc.type] = 4;
            NPCID.Sets.DangerDetectRange[npc.type] = 700;
            NPCID.Sets.AttackType[npc.type] = 0;
            NPCID.Sets.AttackTime[npc.type] = 90;
            NPCID.Sets.AttackAverageChance[npc.type] = 30;
            NPCID.Sets.HatOffsetY[npc.type] = 4;
        }

        public override void SetDefaults()
        {
            npc.townNPC = true;
            npc.friendly = true;
            npc.width = 18;
            npc.height = 40;
            npc.aiStyle = 7;
            npc.damage = 10;
            npc.defense = 15;
            npc.lifeMax = 250;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.knockBackResist = 0.5f;
            animationType = NPCID.Guide;
        }

        public override bool CanTownNPCSpawn(int numTownNPCs, int money)
        {
            List<int> plants = new List<int>()
            { ItemID.DaybloomSeeds, ItemID.BlinkrootSeeds, ItemID.DeathweedSeeds,
            ItemID.FireblossomSeeds, ItemID.MoonglowSeeds, ItemID.WaterleafSeeds,
            ItemID.ShiverthornSeeds, ItemID.PumpkinSeed,
            mod.ItemType("CornSeeds"), mod.ItemType("TomatoSeeds")};

            for (int k = 0; k < 255; k++)
            {
                Player player = Main.player[k];
                if (!player.active)
                {
                    continue;
                }

                foreach (Item item in player.inventory)
                {
                    if (plants.Contains(item.type))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public override string TownNPCName()
        {
            switch (WorldGen.genRand.Next(30))
            {
                case 0:
                    return "Joseph";
                case 1:
                    return "Flan";
                case 2:
                    return "Mario";
                case 3:
                    return "Jack";
                case 4:
                    return "Robert";
                case 5:
                    return "Thomas";
                case 6:
                    return "Albert";
                case 7:
                    return "John";
                case 8:
                    return "Zebadiah";
                case 9:
                    return "Noel";
                case 10:
                    return "Maurice";
                case 11:
                    return "George";
                case 12:
                    return "Butch";
                case 13:
                    return "Dean";
                case 14:
                    return "Barrett";
                case 15:
                    return "Beau";
                case 16:
                    return "Claude";
                case 17:
                    return "Paddy";
                case 18:
                    return "Sean";
                case 19:
                    return "Calhoun";
                case 20:
                    return "Rhett";
                case 21:
                    return "Edison";
                case 22:
                    return "Hudson";
                case 23:
                    return "Brady";
                case 24:
                    return "John Joe";
                case 25:
                    return "Brody";
                case 26:
                    return "Nash";
                case 27:
                    return "Grant";
                case 28:
                    return "Garret";
                default:
                    return "Walter";
            }
        }

        public override string GetChat()
        {
            int wizardNPC = NPC.FindFirstNPC(NPCID.Wizard);   //this make so when this npc is close to Wizard
            if (wizardNPC >= 0 && Main.rand.Next(4) == 0)    //has 1 in 3 chance to show this message
            {
                if (Main.rand.Next(2) == 0)
                {
                    return "Yes, " + Main.npc[wizardNPC].GivenName + " is a wizard, I'm as surprised as you are.";
                }
                else
                {
                    return "Hah, " + Main.npc[wizardNPC].GivenName + " thinks his magic can grow better crops than I ever could! What a joke.";
                }
            }

            int guideNPC = NPC.FindFirstNPC(NPCID.Guide); //this make so when this npc is close to the Guide
            if (guideNPC >= 0 && Main.rand.Next(4) == 0) //has 1 in 3 chance to show this message
            {
                return "Sure, you can ask " + Main.npc[guideNPC].GivenName + " how to farm, but he 'aint gonna give you no advice.";
            }

            int tavernkeepNPC = NPC.FindFirstNPC(NPCID.DD2Bartender);
            if (tavernkeepNPC >= 0 && Main.rand.Next(4) == 0)
            {
                return "Have ya tried " + Main.npc[tavernkeepNPC].GivenName + "'s Ale?";
            }

            int anglerNPC = NPC.FindFirstNPC(NPCID.Angler);
            if (anglerNPC >= 0 && Main.rand.Next(4) == 0)
            {
                return Main.npc[anglerNPC].GivenName + " thinks fishing's better than farming! Crazy, right?";
            }

            int witchdoctorNPC = NPC.FindFirstNPC(NPCID.WitchDoctor);
            if (witchdoctorNPC >= 0 && Main.rand.Next(4) == 0)
            {
                return "I don't trust that " + Main.npc[witchdoctorNPC].GivenName + " guy. Something's wrong 'bout him.";
            }

            int truffleNPC = NPC.FindFirstNPC(NPCID.Truffle);
            if (truffleNPC >= 0 && Main.rand.Next(4) == 0)
            {
                return "I'm sure " + Main.npc[truffleNPC].GivenName + " understands the value of good farmin'.";
            }

            int dryadNPC = NPC.FindFirstNPC(NPCID.Dryad);
            if (dryadNPC >= 0 && Main.rand.Next(4) == 0)
            {
                return "I wonder if " + Main.npc[dryadNPC].GivenName + " could help with the harvest?";
            }

            switch (Main.rand.Next(7))
            {
                case 0:
                    return "Hey, wanna buy somthin'?";
                case 1:
                    return "Whaddya want? I haven't got all day!";
                case 2:
                    return "Nice house ya got there.";
                case 3:
                    return "Where I'm from, you'd say a prayer for this here weather!";
                case 4:
                    return "I'm not old McDonald!";
                case 5:
                    return "If ya 'aint willin' to buy my crops, grow 'em yourself!";
                default:
                    return "Any good harvests lately?";
            }
        }

        public override void SetChatButtons(ref string button, ref string button2)
        {
            button = Language.GetTextValue("LegacyInterface.28");
        }

        public override void OnChatButtonClicked(bool firstButton, ref bool shop)
        {
            shop = true;
        }

        public override void SetupShop(Chest shop, ref int nextSlot)
        {
            shop.item[nextSlot].SetDefaults(mod.ItemType("CornSeeds"));
            nextSlot++;
            shop.item[nextSlot].SetDefaults(mod.ItemType("TomatoSeeds"));
            nextSlot++;
        }

        // Make this Town NPC teleport to the King and/or Queen statue when triggered.
        public override bool CanGoToStatue(bool toKingStatue)
        {
            return true;
        }

        // Make something happen when the npc teleports to a statue. Since this method only runs server side, any visual effects like dusts or gores have to be synced across all clients manually.
        public override void OnGoToStatue(bool toKingStatue)
        {
            if (Main.netMode == NetmodeID.Server)
            {
                ModPacket packet = mod.GetPacket();
                packet.Write((byte)npc.whoAmI);
                packet.Send();
            }
            else
            {
                StatueTeleport();
            }
        }

        // Create a square of pixels around the NPC on teleport.
        public void StatueTeleport()
        {
            for (int i = 0; i < 30; i++)
            {
                Vector2 position = Main.rand.NextVector2Square(-20, 21);
                if (Math.Abs(position.X) > Math.Abs(position.Y))
                {
                    position.X = Math.Sign(position.X) * 20;
                }
                else
                {
                    position.Y = Math.Sign(position.Y) * 20;
                }
            }
        }

        public override void TownNPCAttackStrength(ref int damage, ref float knockback)
        {
            damage = 20;
            knockback = 4f;
        }

        public override void TownNPCAttackCooldown(ref int cooldown, ref int randExtraCooldown)
        {
            cooldown = 30;
            randExtraCooldown = 30;
        }

        public override void TownNPCAttackProj(ref int projType, ref int attackDelay)
        {
            projType = mod.ProjectileType("FarmerPitchforkProjectile");
            attackDelay = 1;
        }

        public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset)
        {
            multiplier = 1f;
            randomOffset = 0f;
        }
    }
}