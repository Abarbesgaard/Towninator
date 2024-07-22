namespace TowninatorCLI.Utilities.Lists.Adjacent_To_Town_Descriptions
{
    public static class AdjHeath
    {
        public static string DescriptionGenerator()
        {
            var random = new Random();
            var descriptions = new string[]
            {
                "on the edge of a vast heath, where the landscape is dotted with heather and the air is filled with the scent of wild blooms.",
                "beside a gently rolling heathland, where the open expanses are broken only by patches of scrub and the occasional solitary tree.",
                "in a wide, open heath with a carpet of purple heather and tufts of tough grasses stretching to the horizon.",
                "near a small pond in the heart of the heath, where the water reflects the surrounding expanse of wild, open land.",
                "at the boundary of a sprawling heath, where the land transitions from rolling hills to the wild, untamed stretches of heathland.",
                "next to a wind-swept heath where the landscape is marked by hardy shrubs and the occasional burst of colorful wildflowers.",
                "on a grassy rise overlooking a heath, where the undulating terrain is covered in a blanket of heather and wild grasses.",
                "by a gorse-covered hill in the heath, where the sharp yellow blooms contrast with the deep green of the surrounding shrubbery.",
                "in the midst of a vast heathland, where the endless stretches of wild grasses and low shrubs create a sense of open freedom.",
                "beside a solitary stone marker in the heath, a remnant of ancient times standing against the backdrop of the open landscape.",
                "on a high point overlooking the heath, where the panoramic view stretches across the undulating terrain of wild, open land.",
                "at the edge of a heath with a small grove of hardy trees, offering a rare shade amidst the otherwise open and wild landscape.",
                "next to a path winding through the heath, where the trail is flanked by clusters of fragrant heather and resilient grasses.",
                "in a heathland clearing where the landscape opens up to reveal a patchwork of wildflowers and low-lying shrubs.",
                "on the edge of a misty heath at dawn, where the early morning fog gives the open land a mysterious and ethereal quality.",
                "by a small, seasonal stream that cuts through the heath, adding a touch of vitality to the otherwise dry and open landscape.",
                "near a cluster of wild berries growing amidst the heath, where the vibrant colors stand out against the subdued tones of the land.",
                "at a junction of heather-covered hills, where the landscape rolls gently and the scent of the wild blooms fills the air.",
                "in the heart of a heath where the land is open and rugged, dotted with hardy plants and shaped by the elements."
            };

            var description = descriptions[random.Next(descriptions.Length)];

            return description;
        }
    }
}
