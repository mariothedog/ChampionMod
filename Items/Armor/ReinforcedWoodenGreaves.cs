using Terraria.ModLoader;

namespace ChampionMod.Items.Armor
{
    [AutoloadEquip(EquipType.Legs)]
    class ReinforcedWoodenGreaves : ModItem
    {
        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 18;
            item.defense = 1;
        }
    }
}
