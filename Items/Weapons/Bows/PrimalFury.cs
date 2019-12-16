using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ChampionMod.Items.Weapons.Bows
{
    public class PrimalFury : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Fires a ghostly arrow behind the equipped arrow when shot");
        }

        public override void SetDefaults()
        {
            item.damage = 32;
            item.ranged = true;
            item.noMelee = true;
            item.width = 40;
            item.height = 20;
            item.useTime = 25;
            item.useAnimation = 25;
            item.useStyle = 5;
            item.knockBack = 5;
            item.value = 30000;
            item.rare = 3;
            item.UseSound = SoundID.Item5;
            item.shoot = 10;
            item.shootSpeed = 9f;
            item.useAmmo = AmmoID.Arrow;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddRecipeGroup("ChampionMod:DemonBow");
            recipe.AddIngredient(ItemID.MoltenFury);
            recipe.AddIngredient(mod.ItemType("OpticalResidue"));
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

        /*public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            if (type == ProjectileID.WoodenArrowFriendly)
			{
				type = mod.ProjectileType("RoyalArrowProjectile");
			}
			return true;
        }*/

        /*public override Vector2? HoldoutOffset() // So player holds the handle
        {
            return new Vector2(3, 0);
        }*/
    }
}