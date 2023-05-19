namespace api.multitracks.com
{
    public class Song
    {
        public string AlbumTitle { get; set; }
        public string ArtistTitle { get; set; }
        public string SongTitle { get; set; }
        public double BPM { get; set; }
        public string TimeSignature { get; set; }
        public bool Multitracks { get; set; }
        public bool CustomMix { get;set; }
        public bool Chart { get; set; }
        public bool RehearsalMix { get; set; }
        public bool Patches { get; set; }
        public bool ProPresenter { get; set; }

        public Song(string albumTitle, string artistTitle, string songTitle, double bpm, string timeSignature, bool multitracks, bool customMix, bool chart, bool rehearsalMix, bool patches, bool proPresenter)
        {
            AlbumTitle = albumTitle;
            ArtistTitle = artistTitle;
            SongTitle = songTitle;
            BPM = bpm;
            TimeSignature = timeSignature;
            Multitracks = multitracks;
            CustomMix = customMix;
            Chart = chart;
            RehearsalMix = rehearsalMix;
            Patches = patches;
            ProPresenter = proPresenter;
        }
    }
}
