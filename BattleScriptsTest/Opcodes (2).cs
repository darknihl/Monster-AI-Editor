using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleAIParserTest
{
    public enum SpellNumber : byte
    {
        //Black
        Fire = 0x00, Blizzard = 0x01, Thunder = 0x02, Poison = 0x03, Drain = 0x04, Fira = 0x05, Blizzara = 0x06, Thundara = 0x07, Bio = 0x08, Firaga = 0x09, Blizzaga = 0x0A, Thundata = 0x0B,
        Break = 0x0C, Death = 0x0D, Holy = 0x0E, Flare = 0x0F, Gravity = 0x10, Graviga = 0x11, Banish = 0x12, Meteor = 0x13, Ultima = 0x14, Quake = 0x15, Tornado = 0x16, Meltdown = 0x17,
        //Grey
        Libra = 0x18, Slow = 0x19, Rasp = 0x1A, Silence = 0x1B, Protect = 0x1C, Sleep = 0x1D, Confuse = 0x1E, Haste = 0x1F, Stop = 0x20, Berserk = 0x21, Float = 0x22, Imp = 0x23, Reflect = 0x24,
        Shell = 0x25, Vanish = 0x26, Hastega = 0x27, Slowga = 0x28, Syphon = 0x29, Teleport = 0x2A, Guard = 0x2B, Dispel = 0x2C,
        //White
        Cure = 0x2D, Cura = 0x2E, Curaga = 0x2F, Raise = 0x30, Arise = 0x31, Reraise = 0x32, Esuna = 0x33, Regen = 0x34, Regenga = 0x35,
        //Eidolons
        Ramuh = 0x36, Ifrit = 0x37, Shiva = 0x38, Siren = 0x39, Midgardsormr = 0x3A, Catoblepas = 0x3B, Madeen = 0x3C, Bismarck = 0x3D, CaitSith = 0x3E, Quetzalli = 0x3F, Valigarmanda = 0x40,
        Odin = 0x41, Raiden = 0x42, Bahamut = 0x43, Alexander = 0x44, Jihaad = 0x45, Ragnarok = 0x46, Kirin = 0x47, Zona_Seeker = 0x48, Carbuncle = 0x49, Phantom = 0x4A, Seraph = 0x4B, Golem = 0x4C,
        Unicorn = 0x4D, Fenrir = 0x4E, Lakshmi = 0x4F, Phoenix = 0x50,
        //Ninja scrolls
        Katon = 0x51, Suiton = 0x52, Raiton = 0x53,
        //Misc
        Snowstorm_ = 0x54,
        //Tachis
        Kiba = 0x55, Kuu = 0x56, Tora = 0x57, Mai = 0x58, Ryuu = 0x59, Getsu = 0x5A, Retsu = 0x5B, Dan = 0x5C,
        //Deathblows
        Raging_Fist = 0x5D, Aura_Cannon = 0x5E, Meteorain = 0x5F, Rising_Phoenix = 0x60, Chakra = 0x61, Razor_Gale = 0x62, Soul_Spiral = 0x63, Phantom_Rush = 0x64,
        //Dance abilities
        Wind_Slash = 0x65, Sun_Bath = 0x66, Leaf_Swirl = 0x67, Forest_Heal = 0x68, Sandstorm = 0x69, Antlion = 0x6A, Will_o_the_Wisp = 0x6B, Apparition = 0x6C, Rock_Slide = 0x6D, Sonic_Boom = 0x6E,
        El_Nino = 0x6F, Plasma = 0x70, Snare = 0x71, Cave_In = 0x72, Snowball = 0x73, Avalanche = 0x74, Cockatrice = 0x75, Wombat = 0x76, Meercat = 0x77, Tapir = 0x78, Boar_Brigade = 0x79,
        Raccoon = 0x7A, Poisonous_Frog = 0x7B, Arctic_Hare = 0x7C,
        //Tools
        Bioblaster = 0x7D, Flash = 0x7E,
        //Slots
        Chocobo_Stampede = 0x7F, Dive_Bomb = 0x80, Prismatic_Flash = 0x81, Megashock = 0x82,
        //Magitek
        Fire_Beam = 0x83, Thunder_Beam = 0x84, Blizzard_Beam = 0x85, Bioblaster2 = 0x86, Heal_Force = 0x87, Revive_Force = 0x88, Banisher = 0x89, Tek_Missile = 0x8A,
        //Lores
        Doom = 0x8B, Roulette = 0x8C, Tsunami = 0x8D, Aqua_Breath = 0x8E, Aero = 0x8F, Needles = 0x90, Mighty_Guard = 0x91, Revenge_Blast = 0x92, White_Wind = 0x93,
        Level_5_Doom = 0x94, Level_4_Flare = 0x95, Level_3_Confuse = 0x96, Reflect_ = 0x97, Level_2_Bioga = 0x98, Traveller = 0x99, Force_Field = 0x9A, Dischord = 0x9B, Bad_Breath = 0x9C,
        Transfusion = 0x9D, Rippler = 0x9E, Stone = 0x9F, Quasar = 0xA0, Grand_Delta = 0xA1, Self_Destruct = 0xA2,
        //Enemy only
        Imp_Song = 0xA3, Vanish_ = 0xA4, Venomist = 0xA5, Crypt_Dust = 0xA6, Scintillation = 0xA7, Lullaby = 0xA8, Acid_Rain = 0xA9, Confusion = 0xAA, Mega_Berserk = 0xAB, Silence_ = 0xAC,
        Net = 0xAD, Sticky_Goo = 0xAE, Delta_Attack = 0xAF, Entangle = 0xB0, Blaster = 0xB1, Cyclonic = 0xB2, Fireball = 0xB3, Atomic_Ray = 0xB4, Magitek_Laser = 0xB5, Diffusion_Laser = 0xB6,
        Wave_Cannon = 0xB7, Megavolt = 0xB8, Gigavolt = 0xB9, Snowstorm = 0xBA, Absolute_Zero = 0xBB, Magnitude_8 = 0xBC, Leech = 0xBD, Flash_Rain = 0xBE, Magitek_Barrier = 0xBF,
        Heartless_Angel = 0xC0, Barrier_Change = 0xC1, Flee = 0xC2, 50_Gs = 0xC3, Mind_Blast = 0xC4, Northern_Cross = 0xC5, Flare_Star = 0xC6, Overture = 0xC7, Grab = 0xC8, Reverse_Polarity = 0xC9,
        Targetting = 0xCA, Snort = 0xCB, Southern_Cross = 0xCC, Launcher = 0xCD, Entice = 0xCE, Freezing_Dust = 0xCF, Tentacle = 0xD0, Hyperdrive = 0xD1, Trine = 0xD2, Diabolic_Whistle = 0xD3, 
        Gravity_Bomb = 0xD4, Inhale = 0xD5, Disaster = 0xD6, Metal_Cutter = 0xD7, Bomblet = 0xD8, Unholy_Darkness = 0xD9, Fury = 0xDA, Release = 0xDB, Cloudy_Heaven = 0xDC, Missile = 0xDD,
        Forsaken = 0xDE, Meteo = 0xDF, Vengeance = 0xE0, Poltergeist = 0xE1, Dread_Gaze = 0xE2, Shockwave = 0xE3, Blaze = 0xE4, Soul_Extraction = 0xE5, Gale_Cut = 0xE6, Shamshir = 0xE7,
        Hailstone = 0xE8, Saintly_Beam = 0xE9, Humbaba_Breath = 0xEA, Lifeshaver = 0xEB, Dancing_Flame = 0xEC, Landslide = 0xED, Attack = 0xEE, Special = 0xEF,
        //Desperations and etc.
        Riot_Blade = 0xF0, Mirage_Dive = 0xF1, Tsubame_Gaeshi = 0xF2, Shadow_Fang = 0xF3, Royal_Shock = 0xF4, Tiger_Break = 0xF5, Spinning_Edge = 0xF6, Sabre_Soul = 0xF7, Star_Soul = 0xF8,
        Red_Card = 0xF9, Moogle_Rush = 0xFA, Punishing_Meteor = 0xFB, Takedown = 0xFC, Wild_Fang = 0xFD, Mysidian_Rabbit = 0xFE, Nothing = 0xFF

    }

    public class Opcodes
    {

    }
}
