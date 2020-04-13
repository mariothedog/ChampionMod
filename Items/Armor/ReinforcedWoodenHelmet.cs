using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace ChampionMod.Items.Armor
{
    [AutoloadEquip(EquipType.Head)]
    class ReinforcedWoodenHelmet : ModItem
    {
        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.WoodHelmet);
            item.defense = 2;
        }
        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ItemType<ReinforcedWoodenBreastplate>() && legs.type == ItemType<ReinforcedWoodenGreaves>();
        }
        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = "+1 defense" +
                "\nIncreases armor penetration by 5";
            player.armorPenetration += 5;
            //player.statDefense += 1; //Not sure why but it automatically increases defense by 1 without this for me. If it doesn't for you, add this back in, might just be a small issue on my side.
        }
    }
}
