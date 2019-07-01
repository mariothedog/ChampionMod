using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChampionMod.Items.Weapons
{
    public class RoyalBow : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Wielded by the Royal Archers");
        }

        public override void SetDefaults()
        {
            item.damage = 15;
            item.ranged = true;
            item.noMelee = true;
            item.width = 40;
            item.height = 20;
            item.useTime = 34;
            item.useAnimation = 34;
            item.useStyle = 5;
            item.knockBack = 4;
            item.value = 250000;
            item.rare = 1;
            item.UseSound = SoundID.Item5;
            item.autoReuse = true;
            item.shoot = 10;
            item.shootSpeed = 6f;
            item.useAmmo = AmmoID.Arrow;
            item.crit = 6;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("KingsGel"), 5);
            recipe.AddIngredient(ItemID.Gel, 100);
            recipe.AddRecipeGroup("ChampionMod:Tier4Bars", 10);
            recipe.AddTile(TileID.Solidifier);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            if (type == ProjectileID.WoodenArrowFriendly)
			{
				type = mod.ProjectileType("RoyalArrowProjectile");
			}
			return true;
        }

        public override Vector2? HoldoutOffset() // So player holds the handle
        {
            return new Vector2(3, 0);
        }
    }
}