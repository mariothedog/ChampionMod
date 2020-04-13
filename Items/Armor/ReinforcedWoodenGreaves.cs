using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace ChampionMod.Items.Armor
{
    [AutoloadEquip(EquipType.Legs)]
    class ReinforcedWoodenGreaves : ModItem
    {
        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.WoodGreaves);
            item.defense = 1;
        }
    }
}
