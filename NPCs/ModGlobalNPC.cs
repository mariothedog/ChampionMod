using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SingleSwordMod.NPCs
{
    public class SingleSwordMod : GlobalNPC
    {
        public override void NPCLoot(NPC npc)
        {
            if (npc.type == NPCID.IchorSticker)
            {
                if (Main.rand.Next(50) == 0) // 2% item rarity
                {
                    Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("IchorBlaster"));
                }
            }
        }
    }
}