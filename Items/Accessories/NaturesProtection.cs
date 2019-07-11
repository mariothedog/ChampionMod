using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChampionMod.Items.Accessories
{
    [AutoloadEquip(EquipType.Shield)] // To make it appear on the player
    class NaturesProtection : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Nature's Protection");
            Tooltip.SetDefault("Increases your defense by 5 and increases the regenerative ability of your teammates" +
                "\nYour regen is heavily nerfed and stops completely when moving");
        }

        public override void SetDefaults()
        {
            item.accessory = true;
            item.defense = 5;
            item.width = 40;
            item.height = 40;
            item.noUseGraphic = true; // So you don't see the item swing (and you just see the projectile)
            item.knockBack = 8;
            item.value = Item.sellPrice(silver : 2);
            item.rare = 1;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddRecipeGroup("Wood", 20);
            recipe.AddIngredient(mod.ItemType("VerdantLeaf"), 8);
            recipe.AddIngredient(ItemID.Acorn, 3);
            recipe.AddTile(TileID.LivingLoom);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<MyPlayer>().hasNaturesProtection = true;

            foreach (Player p in Main.player) // Goes through each player in the game
            {
                if (p.active) // If online (without this it would go through all 255 slots)
                {
                    if (p.GetModPlayer<MyPlayer>().hasNaturesProtection == false)
                    {
                        if (p.team == player.team && player.team != 0) // If they are in the same team and not in no team (white team)
                        {
                            if (Vector2.Distance(p.Center, player.Center) <= 1000)
                            {
                                //Main.NewText(p.name);
                                p.AddBuff(mod.BuffType("NaturesProtectionBuff"), 6000);
                                //p.GetModPlayer<MyPlayer>().NaturesProtectionBuff = true;
                            }
                        }
                    }
                }
            }
        }
    }
}