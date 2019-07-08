using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChampionMod.Items.Accessories
{
    class NaturesProtection : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Nature's Protection");
            Tooltip.SetDefault("Increases your defense by 5 and regenerates the health of the players around you by 2 every second" +
                "\nYour regen is heavily nerfed");
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
            recipe.AddIngredient(ItemID.BorealWood, 20);
            recipe.AddIngredient(ItemID.Silk, 5);
            recipe.AddRecipeGroup("ChampionMod:Tier3Bars", 6);
            recipe.AddIngredient(ItemID.IceTorch, 1);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            //player.allDamage += 19f; // increase all damage by 1900%
                                        /* Here are the individual weapon class bonuses.
                                        player.meleeDamage += 19f;
                                        player.thrownDamage += 19f;
                                        player.rangedDamage += 19f;
                                        player.magicDamage += 19f;
                                        player.minionDamage += 19f;
                                        */
            //player.endurance = 1f - 0.1f * (1f - player.endurance);
            player.GetModPlayer<MyPlayer>().NaturesProtection = true;
            //Main.NewText(player.lifeRegen);
            //Main.NewText(item.lifeRegen);
            //player.lifeRegen = -100;

            //player.statDefense = 0;
            //player.allDamage = 0.1f;
            //player.lifeRegen = -120;
        }
    }
}