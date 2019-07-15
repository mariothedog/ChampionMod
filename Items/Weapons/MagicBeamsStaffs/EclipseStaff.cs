using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

// Credit to Example Mod
// https://github.com/tModLoader/tModLoader/wiki/Advanced-Vanilla-Code-Adaption
namespace ChampionMod.Items.Weapons.MagicBeamsStaffs
{
    class EclipseStaff : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.staff[item.type] = true;
            Tooltip.SetDefault("Creates an eclipse beam that bounces off walls");
        }

        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.ShadowbeamStaff);
            item.shoot = mod.ProjectileType("EclipseStaffProjectile");
            item.damage = 62;
            item.mana = 8;
            item.useTime = 15;
            item.useAnimation = 15;
            item.value = 400000; // 8 gold
            item.rare = 8;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("SunStaff"));
            recipe.AddIngredient(mod.ItemType("MoonStaff"));
            recipe.AddIngredient(ItemID.LunarTabletFragment, 5);
            recipe.AddIngredient(ItemID.Ectoplasm, 5);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }

        public override Vector2? HoldoutOrigin() // HoldoutOrigin works with staffs unlike HoldoutOffset
        {
            return new Vector2(20, 20);
        }
    }
}
