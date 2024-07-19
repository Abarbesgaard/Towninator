namespace TowninatorCLI.Utilities.Lists.Adjacent_To_Town_Descriptions
{
    public class AdjHighLand
    {
        public static string DescriptionGenerator()
        {
            var random = new Random();
            var descriptions = new string[]
    {
        "rolling gently under the open sky, offering expansive views.",
        "dotted with wildflowers and grazing animals, a tranquil sight.",
        "where paths wind through the slopes, revealing hidden vistas.",
        "covered in golden grasses swaying in the breeze.",
        "with its soft slopes perfect for hiking and leisurely walks.",
        "offering a gentle climb to admire the surrounding landscapes.",
        "where rocky outcrops add character to the undulating landscape.",
        "providing a peaceful retreat from the hustle and bustle below.",
        "where the breeze whispers through the tall grasses.",
        "with its slopes ideal for vineyards and orchards.",
        "where the hills meet the sky in a harmonious blend of land and air.",
        "offering a vantage point to watch the sunrise over distant peaks.",
        "where each hill offers a new perspective on the surrounding countryside.",
        "where quaint villages nestle in the folds of the rolling terrain.",
        "with its panoramic views stretching to the horizon.",
        "where the hills glow golden in the light of the setting sun.",
        "where wild herbs and aromatic plants scent the air.",
        "offering a natural amphitheater for enjoying the sounds of nature.",
        "where the hills embrace the warmth of the sun throughout the day.",
        "with its undulating slopes hiding surprises around every bend."    };

            var description = descriptions[random.Next(descriptions.Length)];

            return description;
        }
    }
}
