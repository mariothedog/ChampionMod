using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.ModLoader;

namespace ChampionMod.Items
{
    class ItemGlobal : GlobalItem
    {
        public int originalValue;

        public override bool InstancePerEntity => true;

        public override bool CloneNewInstances => true;

        public override void SetDefaults(Item item)
        {
            originalValue = item.value;
        }

        public override void UpdateInventory(Item item, Player player)
        {
            bool hasLuckyCat = false;
            for (int i = 3; i < 8 + player.extraAccessorySlots; i++)
            {
                if (player.armor[i].type == mod.ItemType("LuckyCat"))
                {
                    hasLuckyCat = true;
                }
            }

            if (hasLuckyCat)
            {
                item.value = (int)(item.GetGlobalItem<ItemGlobal>().originalValue * 1.15);
            } else
            {
                item.value = originalValue;
            }
        }
    }
}