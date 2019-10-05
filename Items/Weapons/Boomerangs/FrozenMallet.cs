using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
 
namespace ChampionMod.Items.Weapons.Boomerangs
{
    public class FrozenMallet : ModItem
    {
		public override void SetDefaults() {
            item.damage = 46;            
            item.melee = true;
            item.width = 40;
            item.height = 40;
            item.useTime = 24;
            item.useAnimation = 24;
            item.noUseGraphic = true;
            item.useStyle = 1;
            item.knockBack = 7;
            item.value = Item.sellPrice(silver : 2);
            item.rare = 5;
            item.shootSpeed = 10f;
            item.shoot = mod.ProjectileType ("FrozenMalletProjectile");
            item.UseSound = SoundID.Item1;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("WhimsicalShard"), 5);
            recipe.AddIngredient(ItemID.FrostCore);
            recipe.AddIngredient(ItemID.BorealWoodHammer);
            recipe.AddIngredient(ItemID.IceBlock, 25);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

        public override bool CanUseItem(Player player)     
        {
            for (int i = 0; i < 1000; ++i)
            {
                if (Main.projectile[i].active && Main.projectile[i].owner == Main.myPlayer && Main.projectile[i].type == item.shoot)
                {
                    return false;
                }
            }
            return true;
        }
    }
}