using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChampionMod.Items.Materials
{
    public class VerdantLeaf : ModItem
    {
        public override void SetDefaults()
        {
            item.maxStack = 999;
            item.width = 26;
            item.height = 26;
            item.value = 5; // 1 Copper
        }
    }
}