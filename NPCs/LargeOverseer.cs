using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChampionMod.NPCs
{
    public class LargeOverseer : ModNPC
    {
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Overseer");
			Main.npcFrameCount[npc.type] = 5;
		}

		public override void SetDefaults()
		{
			npc.CloneDefaults(NPCID.Drippler);
			npc.width = 74;
			npc.height = 62;
			npc.damage = 52;
			npc.defense = 23;
			npc.lifeMax = 300;
			npc.value = Item.buyPrice(0, 0, 6, 0);
			npc.knockBackResist = Main.expertMode ? 0.38f : 0.4f;
			npc.aiStyle = -1;
			animationType = NPCID.Drippler;
			banner = mod.NPCType("LargeOverseer");
			bannerItem = mod.ItemType("OverseerBanner");
		}

		public override float SpawnChance(NPCSpawnInfo spawnInfo)
		{
			//return base.SpawnChance(spawnInfo);
			return SpawnCondition.OverworldNightMonster.Chance * (Main.hardMode ? 0.2f : 0f);
		}

		public override void NPCLoot()
		{
			Item.NewItem(npc.getRect(), mod.ItemType("PileOfEyes"), Main.rand.Next(1, 3));
			Item.NewItem(npc.getRect(), ItemID.Lens, Main.rand.Next(2, 5));
			if (Main.rand.NextFloat() < 0.06)
			{
				Item.NewItem(npc.getRect(), ItemID.BlackLens);
			}
		}

		// If anyone wants to translate this into comprehensible english, feel free.
		// This was ripped straight from vanilla.
		public override void AI()
		{
			Vector2 vector14;
			bool flag17;
			bool flag19;
			bool flag20;
			int num293;
			flag17 = false;
			if (npc.justHit)
			{
				npc.ai[2] = 0f;
			}
			if (!Main.dayTime)
			{
				if (npc.ai[2] >= 0f)
				{
					num293 = 16;
					flag19 = false;
					flag20 = false;
					if (npc.position.X > npc.ai[0] - (float)num293 && npc.position.X < npc.ai[0] + (float)num293)
					{
						flag19 = true;
					}
					else
					{
						if (npc.velocity.X < 0f && npc.direction > 0)
						{
							goto IL_e912;
						}
						if (npc.velocity.X > 0f && npc.direction < 0)
						{
							goto IL_e912;
						}
					}
					goto IL_e919;
				}

				npc.ai[2] += 1f;

				if (Main.player[npc.target].position.X + (float)(Main.player[npc.target].width / 2) > npc.position.X + (float)(npc.width / 2))
				{
					npc.direction = -1;
				}
				else
				{
					npc.direction = 1;
				}
			}
			goto IL_eb0b;
			IL_eb0b:
			int num1461 = (int)((npc.position.X + (float)(npc.width / 2)) / 16f) + npc.direction * 2;
			int num1462 = (int)((npc.position.Y + (float)npc.height) / 16f);
			bool flag101 = true;
			bool flag102 = false;
			int num1463 = 4;
			if (npc.target >= 0)
			{
				vector14 = Main.player[npc.target].Center - npc.Center;
				float num1485 = vector14.Length();
				num1485 /= 70f;
				if (num1485 > 8f)
				{
					num1485 = 8f;
				}
				num1463 += (int)num1485;
			}

			int num1486 = num1462;
			while (num1486 < num1462 + num1463)
			{
				if (Main.tile[num1461, num1486] == null)
				{
					Tile[,] tile35 = Main.tile;
					int num1487 = num1461;
					int num1488 = num1486;
					Tile tile36 = new Tile();
					tile35[num1487, num1488] = tile36;
				}
				if (Main.tile[num1461, num1486].nactive() && Main.tileSolid[Main.tile[num1461, num1486].type])
				{
					goto IL_f778;
				}
				if (Main.tile[num1461, num1486].liquid > 0)
				{
					goto IL_f778;
				}
				int num2 = num1486;
				num1486 = num2 + 1;
				continue;
				IL_f778:
				if (num1486 <= num1462 + 1)
				{
					flag102 = true;
				}
				flag101 = false;
				break;
			}
			if (Main.player[npc.target].npcTypeNoAggro[npc.type])
			{
				bool flag103 = false;
				int num1489 = num1462;
				while (num1489 < num1462 + num1463 - 2)
				{
					if (Main.tile[num1461, num1489] == null)
					{
						Tile[,] tile37 = Main.tile;
						int num1490 = num1461;
						int num1491 = num1489;
						Tile tile38 = new Tile();
						tile37[num1490, num1491] = tile38;
					}
					if (Main.tile[num1461, num1489].nactive() && Main.tileSolid[Main.tile[num1461, num1489].type])
					{
						goto IL_f886;
					}
					if (Main.tile[num1461, num1489].liquid > 0)
					{
						goto IL_f886;
					}
					int num2 = num1489;
					num1489 = num2 + 1;
					continue;
					IL_f886:
					flag103 = true;
					break;
				}
				npc.directionY = (!flag103).ToDirectionInt();
			}
			if (flag17)
			{
				flag102 = false;
				flag101 = true;
			}
			if (flag101)
			{
				npc.velocity.Y = npc.velocity.Y + 0.03f;
				if ((double)npc.velocity.Y > 0.75)
				{
					npc.velocity.Y = 0.75f;
				}
			}
			else
			{
				if ((npc.directionY < 0 && npc.velocity.Y > 0f) | flag102)
				{
					npc.velocity.Y = npc.velocity.Y - 0.075f;
				}
				if (npc.velocity.Y < -0.75f)
				{
					npc.velocity.Y = -0.75f;
				}
			}
			if (npc.collideX)
			{
				npc.velocity.X = npc.oldVelocity.X * -0.4f;
				if (npc.direction == -1 && npc.velocity.X > 0f && npc.velocity.X < 1f)
				{
					npc.velocity.X = 1f;
				}
				if (npc.direction == 1 && npc.velocity.X < 0f && npc.velocity.X > -1f)
				{
					npc.velocity.X = -1f;
				}
			}
			if (npc.collideY)
			{
				npc.velocity.Y = npc.oldVelocity.Y * -0.25f;
				if (npc.velocity.Y > 0f && npc.velocity.Y < 1f)
				{
					npc.velocity.Y = 1f;
				}
				if (npc.velocity.Y < 0f && npc.velocity.Y > -1f)
				{
					npc.velocity.Y = -1f;
				}
			}
			float num1495 = 1.5f;
			if (npc.direction == -1 && npc.velocity.X > 0f - num1495)
			{
				npc.velocity.X = npc.velocity.X - 0.1f;
				if (npc.velocity.X > num1495)
				{
					npc.velocity.X = npc.velocity.X - 0.1f;
				}
				else if (npc.velocity.X > 0f)
				{
					npc.velocity.X = npc.velocity.X + 0.05f;
				}
				if (npc.velocity.X < 0f - num1495)
				{
					npc.velocity.X = 0f - num1495;
				}
			}
			else if (npc.direction == 1 && npc.velocity.X < num1495)
			{
				npc.velocity.X = npc.velocity.X + 0.1f;
				if (npc.velocity.X < 0f - num1495)
				{
					npc.velocity.X = npc.velocity.X + 0.1f;
				}
				else if (npc.velocity.X < 0f)
				{
					npc.velocity.X = npc.velocity.X - 0.05f;
				}
				if (npc.velocity.X > num1495)
				{
					npc.velocity.X = num1495;
				}
			}
			num1495 = 1f;
			if (npc.directionY == -1 && npc.velocity.Y > 0f - num1495)
			{
				npc.velocity.Y = npc.velocity.Y - 0.04f;
				if (npc.velocity.Y > num1495)
				{
					npc.velocity.Y = npc.velocity.Y - 0.05f;
				}
				else if (npc.velocity.Y > 0f)
				{
					npc.velocity.Y = npc.velocity.Y + 0.03f;
				}
				if (npc.velocity.Y < 0f - num1495)
				{
					npc.velocity.Y = 0f - num1495;
				}
			}
			else if (npc.directionY == 1 && npc.velocity.Y < num1495)
			{
				npc.velocity.Y = npc.velocity.Y + 0.04f;
				if (npc.velocity.Y < 0f - num1495)
				{
					npc.velocity.Y = npc.velocity.Y + 0.05f;
				}
				else if (npc.velocity.Y < 0f)
				{
					npc.velocity.Y = npc.velocity.Y - 0.03f;
				}
				if (npc.velocity.Y > num1495)
				{
					npc.velocity.Y = num1495;
				}
			}
			return;
			IL_e912:
			flag19 = true;
			goto IL_e919;
			IL_e919:
			num293 += 24;
			if (npc.position.Y > npc.ai[1] - (float)num293 && npc.position.Y < npc.ai[1] + (float)num293)
			{
				flag20 = true;
			}
			if (flag19 & flag20)
			{
				npc.ai[2] += 1f;
				if (npc.ai[2] >= 30f && num293 == 16)
				{
					flag17 = true;
				}
				if (npc.ai[2] >= 60f)
				{
					npc.ai[2] = -200f;
					npc.direction *= -1;
					npc.velocity.X = npc.velocity.X * -1f;
					npc.collideX = false;
				}
			}
			else
			{
				npc.ai[0] = npc.position.X;
				npc.ai[1] = npc.position.Y;
				npc.ai[2] = 0f;
			}
			npc.TargetClosest(true);
			goto IL_eb0b;
		}

		public override void FindFrame(int frameHeight)
		{
			npc.frameCounter++;
			if (npc.frameCounter > 8)
			{
				npc.frameCounter = 0;
				Main.NewText(frameHeight);
				npc.frame.Y = (npc.frame.Y + frameHeight) % (5 * frameHeight);
			}
		}
	}
}