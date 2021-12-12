using MusicApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicApp.Data
{
    public static class MusicRepository
    {
        private static List<Music> _Musics = null;

        static MusicRepository()
        {
            _Musics = new List<Music>()
            {
                new Music()
                {
                    Id=1,
                    Name="Taylor Swift",
                    Description="<p>Taylor Swift is the self-titled debut studio album by American singer-songwriter Taylor Swift. It was released through Big Machine Records in the US and Canada on October 24, 2006, and internationally on March 18, 2008. Swift had relocated from Pennsylvania to Tennessee in 2004, at fourteen years old, to pursue a career as a country singer-songwriter. She signed with Sony/ATV Tree publishing house, and Big Machine Records in 2005, to work on her debut album during her first high school year.</p>",
                    ImageUrl="1.jpg",
                    Singer = "Taylor Swift",
                    Songs ="Tim McGraw, Picture to Burn, Teardrops on My Guitar, A Place in This World, Cold as You, The Outside, Tied Together with a Smile, Stay Beautiful, Should've Said No, Mary's Song (Oh My My My), Our Song",
                    ReleaseDate= 2006,
                    Rate = 0.0
                },
                new Music() {
                    Id=2,
                    Name="Fearless",
                    Description="<p>Fearless is the second studio album by American singer-songwriter Taylor Swift. It was released on November 11, 2008, by Big Machine Records. Written largely by Swift while she was promoting her 2006 self-titled debut album in 2007–2008, the album features additional songwriting credits from Liz Rose, Hillary Lindsey, Colbie Caillat, and John Rich. Swift wrote seven of the thirteen songs on the standard edition by herself and, in her debut as a record producer, co-produced all songs with Nathan Chapman</p>",
                    ImageUrl="2.jpeg",
                    Singer = "Taylor Swift",
                    Songs = "Fearless, Fifteen, Love Story, Hey Stephen, White Horse, You Belong with Me, Breathe, Tell Me Why, You're Not Sorry, The Way I Loved You, Forever & Always, The Best Day, Change, Our Song, Teardrops On My Guitar, Should've Said No",
                    ReleaseDate = 2008,
                    Rate = 0.0
                },

                new Music() {
                    Id=3,
                    Name="Speak Now",
                    Description="<p>Speak Now, the third studio album to be recorded by American singer-songwriter Taylor Swift, was released on October 25, 2010, through Big Machine Records. Swift wrote the album in a two-year period while she was promoting her second studio album Fearless (2008). She developed Speak Now as a loose concept album about the confessions she wanted but never had a chance to make to people she had met.</p>",
                    ImageUrl="3.png",
                    Singer = "Taylor Swift",
                    Songs ="Mine, Sparks Fly, Back to December, Speak Now, Dear John, Mean, The Story of Us, Never Grow Up, Enchanted, Better Than Revenge, Innocent, Haunted, Last Kiss, Long Live",
                    ReleaseDate= 2010,
                    Rate = 0.0
                },
                new Music() {
                    Id=4,
                    Name="Red",
                    Description="<p>Red is the fourth studio album by American singer-songwriter Taylor Swift. It was released on October 22, 2012, by Big Machine Records. The album's title refers to the tumultuous, red emotions Swift experienced during the album's conception; its songs discuss the complex and conflicting feelings resulting from fading romance.</p>",
                    ImageUrl="4.jfif",
                    Singer = "Taylor Swift",
                    Songs = "State of Grace, Red, Treacherous, I Knew You Were Trouble, All Too Well, 22, I Almost Do, We Are Never Ever Getting Back Together, Stay Stay Stay, The Last Time, Holy Ground, Sad Beautiful Tragic, The Lucky One, Everything Has Changed, Starlight, Begin Again, The Moment I Knew, Come Back... Be Here, Girl at Home",
                    ReleaseDate = 2012 ,
                    Rate = 0.0
                },
                new Music() {
                    Id=5,
                    Name="1989",
                    Description="<p>1989 is the fifth studio album by American singer-songwriter Taylor Swift. It was released on October 27, 2014, by Big Machine Records. Following the release of her genre-spanning fourth studio album Red (2012), noted for its pop hooks and electronic accents, the media questioned the validity of Swift's status as a country artist. Inspired by 1980s synth-pop to create a record that shifted her sound and image from country to mainstream pop, Swift enlisted Max Martin as co-executive producer, and titled her fifth album after her birth year as a symbolic rebirth of her artistry.</p>",
                    ImageUrl="5.jpg",
                    Singer = "Taylor Swift",
                    Songs ="Welcome to New York, Blank Space, Style, Out of the Woods, All You Had to Do Was Stay, Shake It Off, I Wish You Would, Bad Blood, Wildest Dreams, How You Get the Girl, This Love, I Know Places, Clean ",
                    ReleaseDate= 2014,
                    Rate = 0.0
                },
                new Music() {
                    Id=6,
                    Name="Reputation",
                    Description="<p>Reputation (stylized in all lowercase) is the sixth studio album by American singer-songwriter Taylor Swift. It was released on November 10, 2017, by Big Machine Records. Following her fifth studio album 1989 (2014), Swift was involved in highly publicized disputes with multiple celebrities and became a subject of widespread tabloid scrutiny. She hence secluded herself from the press and social media, where she had maintained an active presence, and created Reputation as an effort to revamp her state of mind.</p>",
                    ImageUrl="6.png",
                    Singer = "Taylor Swift",
                    Songs ="...Ready for It?, End Game, I Did Something Bad, Don't Blame Me, Delicate, Look What You Made Me Do, So It Goes..., Gorgeous, Getaway Car, King of My Heart, Dancing with Our Hands Tied, Dress, This Is Why We Can’t Have Nice Things, Call It What You Want, New Year's Day",
                    ReleaseDate= 2017,
                    Rate = 0.0
                },
                new Music() {
                    Id=7,
                    Name="Lover",
                    Description="<p>Lover is the seventh studio album by American singer-songwriter Taylor Swift, released on August 23, 2019, via Republic Records. It is Swift's first album after parting ways with her former label, Big Machine Records. Motivated by her positive experience on her Reputation Stadium Tour (2018), Swift sought to make an album with bright and lighter tones focusing on the foundational strengths of her songcraft, recalibrating from the dark trope of its predecessor, Reputation (2017).</p>",
                    ImageUrl="7.png",
                    Singer = "Taylor Swift",
                    Songs ="I Forgot That You Existed, Cruel Summer, Lover, The Man, The Archer, I Think He Knows, Miss Americana & The Heartbreak Prince, Paper Rings, Cornelia Street, Death by a Thousand Cuts, London Boy, Soon You'll Get Better, False God, You Need To Calm Down, Afterglow, ME!,  It's Nice to Have a Friend, Daylight  ",
                    ReleaseDate= 2019,
                    Rate = 0.0
                },
                new Music() {
                    Id=8,
                    Name="Folklore",
                    Description="<p>Folklore (stylized in all lowercase) is the eighth studio album by American singer-songwriter Taylor Swift. It was a surprise album, released on July 24, 2020, via Republic Records. Swift conceived Folklore in quarantine during the COVID-19 pandemic as a collection of songs and stories that flowed like a stream of consciousness out of her imagination, and collaborated with producers Aaron Dessner and Jack Antonoff virtually.</p>",
                    ImageUrl="8.png",
                    Singer = "Taylor Swift",
                    Songs ="​the 1, cardigan, the last great american dynasty, exile,  ​my tears ricochet, mirrorball, ​seven, ​august, ​this is me trying, ​illicit affairs, ​invisible string, ​mad woman, ​epiphany, ​betty, ​hoax",
                    ReleaseDate= 2020,
                    Rate = 0.0
                },
                new Music() {
                    Id=9,
                    Name="Evermore",
                    Description="<p>Evermore (stylized in all lowercase) is the ninth studio album by American singer-songwriter Taylor Swift. It was released on December 11, 2020, through Republic Records, less than five months after the singer's eighth studio album, Folklore. Evermore was a spontaneous product of Swift's extended collaboration with her Folklore co-producer Aaron Dessner, with whom she developed a creative chemistry.</p>",
                    ImageUrl="9.jpg",
                    Singer = "Taylor Swift",
                    Songs ="​willow, champagne problems, ​gold rush, ​'tis the damn season, tolerate it, no body, no crime,  happiness, ​dorothea, ​coney island,  ​ivy, ​cowboy like me, ​l​ong story short, ​marjorie, ​closure, ​evermore ",
                    ReleaseDate= 2020,
                    Rate = 0.0
                }
            };
        }

        public static List<Music> Musics
        {
            get
            {
                return _Musics;
            }
        }

        public static void AddMusic(Music entity)
        {
            _Musics.Add(entity);
        }

        public static Music GetById(int id)
        {
            return _Musics.FirstOrDefault(i => i.Id == id);
        }


    }
}