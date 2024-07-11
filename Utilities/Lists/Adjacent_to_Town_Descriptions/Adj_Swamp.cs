namespace TowninatorCLI
{
    public class Adj_Swamp
    {
        public string DescriptionGenerator()
        {
            var random = new Random();
            string[] descriptions = new string[]
    {
        "where murky waters hide ancient secrets beneath the surface.",
        "with twisted trees and tangled vines creating an eerie atmosphere.",
        "where fog blankets the ground, adding to the mysterious ambiance.",
        "where the air is thick with humidity and the calls of unseen creatures.",
        "with its labyrinth of channels and pools, a maze for the unwary.",
        "where exotic plants thrive in the damp soil, untouched by sunlight.",
        "with its tangled roots and spongy ground, challenging to traverse.",
        "where the smell of decay mingles with the scent of damp earth.",
        "with its shallow pools reflecting the twisted forms of gnarled trees.",
        "where every step sinks into the soft, sucking mud of the marsh.",
        "with its still waters mirroring the overhanging canopy of leafy vines.",
        "where the silence is broken only by the occasional splash or croak.",
        "with its dense foliage creating a barrier between land and water.",
        "where the swamp meets the edge of civilization, a border of mystery.",
        "with its muddy banks providing a haven for creatures of the night.",
        "where the murky depths conceal the remnants of a forgotten past.",
        "with its ghostly mists rising from the surface of stagnant waters.",
        "where the calls of swamp birds echo through the misty air.",
        "with its tangled growth offering both concealment and danger.",
        "where the swampy terrain challenges even the most experienced traveler."
    };
            string description = descriptions[random.Next(descriptions.Length)];

            return description;
        }
    }
}
