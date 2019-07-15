using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

// Credit to Example Mod
// https://github.com/tModLoader/tModLoader/wiki/Advanced-Vanilla-Code-Adaption
namespace ChampionMod.Items.Weapons.MagicBeamsStaffs
{
    class SunStaff : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.staff[item.type] = true;
        }

        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.ShadowbeamStaff);
            item.shoot = mod.ProjectileType("SunStaffProjectile");
            item.damage = 34;
            item.mana = 9;
            item.useTime = 23;
            item.useAnimation = 23;
            item.value = 27000; // 54 silver
            item.autoReuse = false;
            item.rare = 3;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddRecipeGroup("ChampionMod:Flares");
            recipe.AddIngredient(ItemID.HellstoneBar, 15);
            recipe.AddIngredient(ItemID.SunplateBlock, 30);
            recipe.AddIngredient(ItemID.Lens, 5);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

        public override Vector2? HoldoutOrigin() // HoldoutOrigin works with staffs unlike HoldoutOffset
        {
            return new Vector2(20, 20);
        }
    }
}
