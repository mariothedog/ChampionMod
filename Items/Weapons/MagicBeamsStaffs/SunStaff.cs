using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

// Credit to Example Mod
// https://github.com/tModLoader/tModLoader/wiki/Advanced-Vanilla-Code-Adaption
namespace ChampionMod.Items.Weapons.MagicBeamsStaffs
{
    class SunStaff : ModItem // WIP
    {
        public override void SetStaticDefaults()
        {
            Item.staff[item.type] = true;
        }

        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.ShadowbeamStaff);
            item.shoot = mod.ProjectileType("SunStaffProjectile");
        }
    }
}
