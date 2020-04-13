using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace ChampionMod.Items.Armor
{
    [AutoloadEquip(EquipType.Body)]
    class ReinforcedWoodenBreastplate : ModItem
    {
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            Tooltip.SetDefault("4% increased damage");
        }
        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.WoodBreastplate);
            item.defense = 2;
        }
        public override void UpdateEquip(Player player)
        {
            base.UpdateEquip(player);
            player.allDamage += 0.04f;
        }
    }
}
