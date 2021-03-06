using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChampionMod.Items.Materials.Fish
{
    public class MemoryFish : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Memory Fish");
        }

        public override void SetDefaults()
        {
            item.maxStack = 999;
            item.width = 26;
            item.height = 26;
            item.rare = 7;
            item.value = 150000;
        }
    }
}