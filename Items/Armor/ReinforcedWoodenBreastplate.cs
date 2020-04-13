using Terraria;
using Terraria.ModLoader;

namespace ChampionMod.Items.Armor
{
    [AutoloadEquip(EquipType.Body)]
    class ReinforcedWoodenBreastplate : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("4% increased damage");
        }
        public override void SetDefaults()
        {
            item.width = 18;
            item.height = 18;
            item.defense = 2;
        }
        public override void UpdateEquip(Player player)
        {
            player.allDamage += 0.04f;
        }
    }
}
