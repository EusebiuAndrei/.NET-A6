using System.Xml;
using System;
using System.Security.Principal;
using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options) {}

        public DbSet<News> News { get; set; }
        public DbSet<NewsTopic> NewsTopic { get; set; }
        public DbSet<Topic> Topic { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /*modelBuilder.Entity<News>()
                .Property(n => n.Id).IsRequired();
            modelBuilder.Entity<NewsTopic>()
                .Property(nt => nt.Id).IsRequired();
            modelBuilder.Entity<Topic>()
                .Property(t => t.Id).IsRequired();
            base.OnModelCreating(modelBuilder);*/

            modelBuilder.Entity<News>().HasData(
                new News
                {
                    Id = 1,
                    Title = "Donald Trump Sends Out Embarrassing New Year’s Eve Message; This is Disturbing",
                    Date = new DateTime(2017, 12, 31),
                    Text = "Donald Trump just couldn t wish all Americans a Happy New Year and leave it at that. Instead, he had to give a shout out to his enemies, haters and  the very dishonest fake news media.  The former reality show star had just one job to do and he couldn t do it. As our Country rapidly grows stronger and smarter, I want to wish all of my friends, supporters, enemies, haters, and even the very dishonest Fake News Media, a Happy and Healthy New Year,  President Angry Pants tweeted.  2018 will be a great year for America! As our Country rapidly grows stronger and smarter, I want to wish all of my friends, supporters, enemies, haters, and even the very dishonest Fake News Media, a Happy and Healthy New Year. 2018 will be a great year for America!  Donald J. Trump (@realDonaldTrump) December 31, 2017Trump s tweet went down about as welll as you d expect.What kind of president sends a New Year s greeting like this despicable, petty, infantile gibberish? Only Trump! His lack of decency won t even allow him to rise above the gutter long enough to wish the American citizens a happy new year!  Bishop Talbert Swan (@TalbertSwan) December 31, 2017no one likes you  Calvin (@calvinstowell) December 31, 2017Your impeachment would make 2018 a great year for America, but I ll also accept regaining control of Congress.  Miranda Yaver (@mirandayaver) December 31, 2017Do you hear yourself talk? When you have to include that many people that hate you you have to wonder? Why do the they all hate me?  Alan Sandoval (@AlanSandoval13) December 31, 2017Who uses the word Haters in a New Years wish??  Marlene (@marlene399) December 31, 2017You can t just say happy new year?  Koren pollitt (@Korencarpenter) December 31, 2017Here s Trump s New Year s Eve tweet from 2016.Happy New Year to all, including to my many enemies and those who have fought me and lost so badly they just don t know what to do. Love!  Donald J. Trump (@realDonaldTrump) December 31, 2016This is nothing new for Trump. He s been doing this for years.Trump has directed messages to his  enemies  and  haters  for New Year s, Easter, Thanksgiving, and the anniversary of 9/11. pic.twitter.com/4FPAe2KypA  Daniel Dale (@ddale8) December 31, 2017Trump s holiday tweets are clearly not presidential.How long did he work at Hallmark before becoming President?  Steven Goodine (@SGoodine) December 31, 2017He s always been like this . . . the only difference is that in the last few years, his filter has been breaking down.  Roy Schulze (@thbthttt) December 31, 2017Who, apart from a teenager uses the term haters?  Wendy (@WendyWhistles) December 31, 2017he s a fucking 5 year old  Who Knows (@rainyday80) December 31, 2017So, to all the people who voted for this a hole thinking he would change once he got into power, you were wrong! 70-year-old men don t change and now he s a year older.Photo by Andrew Burton/Getty Images.",
                    SourceLink = "www.kaggle.com",
                    ClassifiedAs = 0
                },
                new News
                {
                    Id = 2,
                    Title = "Drunk Bragging Trump Staffer Started Russian Collusion Investigation",
                    Date = new DateTime(2017, 12, 31),
                    Text = "House Intelligence Committee Chairman Devin Nunes is going to have a bad day. He s been under the assumption, like many of us, that the Christopher Steele-dossier was what prompted the Russia investigation so he s been lashing out at the Department of Justice and the FBI in order to protect Trump. As it happens, the dossier is not what started the investigation, according to documents obtained by the New York Times.Former Trump campaign adviser George Papadopoulos was drunk in a wine bar when he revealed knowledge of Russian opposition research on Hillary Clinton.On top of that, Papadopoulos wasn t just a covfefe boy for Trump, as his administration has alleged. He had a much larger role, but none so damning as being a drunken fool in a wine bar. Coffee boys  don t help to arrange a New York meeting between Trump and President Abdel Fattah el-Sisi of Egypt two months before the election. It was known before that the former aide set up meetings with world leaders for Trump, but team Trump ran with him being merely a coffee boy.In May 2016, Papadopoulos revealed to Australian diplomat Alexander Downer that Russian officials were shopping around possible dirt on then-Democratic presidential nominee Hillary Clinton. Exactly how much Mr. Papadopoulos said that night at the Kensington Wine Rooms with the Australian, Alexander Downer, is unclear,  the report states.  But two months later, when leaked Democratic emails began appearing online, Australian officials passed the information about Mr. Papadopoulos to their American counterparts, according to four current and former American and foreign officials with direct knowledge of the Australians  role. Papadopoulos pleaded guilty to lying to the F.B.I. and is now a cooperating witness with Special Counsel Robert Mueller s team.This isn t a presidency. It s a badly scripted reality TV show.Photo by Win McNamee/Getty Images.",
                    SourceLink = "www.kaggle.com",
                    ClassifiedAs = 0
                },
                new News{
                    Id = 3,
                    Title = "Sheriff David Clarke Becomes An Internet Joke For Threatening To Poke People ‘In The Eye’",
                    Date = new DateTime(2017,12, 30),
                    Text = "On Friday, it was revealed that former Milwaukee Sheriff David Clarke, who was being considered for Homeland Security Secretary in Donald Trump s administration, has an email scandal of his own.In January, there was a brief run-in on a plane between Clarke and fellow passenger Dan Black, who he later had detained by the police for no reason whatsoever, except that maybe his feelings were hurt. Clarke messaged the police to stop Black after he deplaned, and now, a search warrant has been executed by the FBI to see the exchanges.Clarke is calling it fake news even though copies of the search warrant are on the Internet. I am UNINTIMIDATED by lib media attempts to smear and discredit me with their FAKE NEWS reports designed to silence me,  the former sheriff tweeted.  I will continue to poke them in the eye with a sharp stick and bitch slap these scum bags til they get it. I have been attacked by better people than them #MAGA I am UNINTIMIDATED by lib media attempts to smear and discredit me with their FAKE NEWS reports designed to silence me. I will continue to poke them in the eye with a sharp stick and bitch slap these scum bags til they get it. I have been attacked by better people than them #MAGA pic.twitter.com/XtZW5PdU2b  David A. Clarke, Jr. (@SheriffClarke) December 30, 2017He didn t stop there.BREAKING NEWS! When LYING LIB MEDIA makes up FAKE NEWS to smear me, the ANTIDOTE is go right at them. Punch them in the nose & MAKE THEM TASTE THEIR OWN BLOOD. Nothing gets a bully like LYING LIB MEDIA S attention better than to give them a taste of their own blood #neverbackdown pic.twitter.com/T2NY2psHCR  David A. Clarke, Jr. (@SheriffClarke) December 30, 2017The internet called him out.This is your local newspaper and that search warrant isn t fake, and just because the chose not to file charges at the time doesn t mean they won t! Especially if you continue to lie. Months after decision not to charge Clarke, email search warrant filed https://t.co/zcbyc4Wp5b  KeithLeBlanc (@KeithLeBlanc63) December 30, 2017I just hope the rest of the Village People aren t implicated.  Kirk Ketchum (@kirkketchum) December 30, 2017Slaw, baked potatoes, or French fries? pic.twitter.com/fWfXsZupxy  ALT- Immigration   (@ALT_uscis) December 30, 2017pic.twitter.com/ymsOBLjfxU  Pendulum Swinger (@PendulumSwngr) December 30, 2017you called your police friends to stand up for you when someone made fun of your hat  Chris Jackson (@ChrisCJackson) December 30, 2017Is it me, with this masterful pshop of your hat, which I seem to never tire of. I think it s the steely resolve in your one visible eye pic.twitter.com/dWr5k8ZEZV  Chris Mohney (@chrismohney) December 30, 2017Are you indicating with your fingers how many people died in your jail? I think you re a few fingers short, dipshit  Ike Barinholtz (@ikebarinholtz) December 30, 2017ROFL. Internet tough guy with fake flair. pic.twitter.com/ulCFddhkdy  KellMeCrazy (@Kel_MoonFace) December 30, 2017You re so edgy, buddy.  Mrs. SMH (@MRSSMH2) December 30, 2017Is his break over at Applebees?  Aaron (@feltrrr2) December 30, 2017Are you trying to earn your  still relevant  badge?  CircusRebel (@CircusDrew) December 30, 2017make sure to hydrate, drink lots of water. It s rumored that prisoners can be denied water by prison officials.  Robert Klinc (@RobertKlinc1) December 30, 2017Terrill Thomas, the 38-year-old black man who died of thirst in Clarke s Milwaukee County Jail cell this April, was a victim of homicide. We just thought we should point that out. It can t be repeated enough.Photo by Spencer Platt/Getty Images.",
                    SourceLink = "www.kaggle.com",
                    ClassifiedAs = 0
                },
                new News{
                    Id = 4,
                    Title = "Trump Is So Obsessed He Even Has Obama’s Name Coded Into His Website (IMAGES)",
                    Date = new DateTime(2017,12,29),
                    Text = "On Christmas day, Donald Trump announced that he would  be back to work  the following day, but he is golfing for the fourth day in a row. The former reality show star blasted former President Barack Obama for playing golf and now Trump is on track to outpace the number of golf games his predecessor played.Updated my tracker of Trump s appearances at Trump properties.71 rounds of golf including today s. At this pace, he ll pass Obama s first-term total by July 24 next year. https://t.co/Fg7VacxRtJ pic.twitter.com/5gEMcjQTbH  Philip Bump (@pbump) December 29, 2017 That makes what a Washington Post reporter discovered on Trump s website really weird, but everything about this administration is bizarre AF. The coding contained a reference to Obama and golf:  Unlike Obama, we are working to fix the problem   and not on the golf course.  However, the coding wasn t done correctly.The website of Donald Trump, who has spent several days in a row at the golf course, is coded to serve up the following message in the event of an internal server error: https://t.co/zrWpyMXRcz pic.twitter.com/wiQSQNNzw0  Christopher Ingraham (@_cingraham) December 28, 2017That snippet of code appears to be on all https://t.co/dkhw0AlHB4 pages, which the footer says is paid for by the RNC? pic.twitter.com/oaZDT126B3  Christopher Ingraham (@_cingraham) December 28, 2017It s also all over https://t.co/ayBlGmk65Z. As others have noted in this thread, this is weird code and it s not clear it would ever actually display, but who knows.  Christopher Ingraham (@_cingraham) December 28, 2017After the coding was called out, the reference to Obama was deleted.UPDATE: The golf error message has been removed from the Trump and GOP websites. They also fixed the javascript  =  vs  ==  problem. Still not clear when these messages would actually display, since the actual 404 (and presumably 500) page displays a different message pic.twitter.com/Z7dmyQ5smy  Christopher Ingraham (@_cingraham) December 29, 2017That suggests someone at either RNC or the Trump admin is sensitive enough to Trump s golf problem to make this issue go away quickly once people noticed. You have no idea how much I d love to see the email exchange that led us here.  Christopher Ingraham (@_cingraham) December 29, 2017 The code was f-cked up.The best part about this is that they are using the  =  (assignment) operator which means that bit of code will never get run. If you look a few lines up  errorCode  will always be  404          (@tw1trsux) December 28, 2017trump s coders can t code. Nobody is surprised.  Tim Peterson (@timrpeterson) December 28, 2017Donald Trump is obsessed with Obama that his name was even in the coding of his website while he played golf again.Photo by Joe Raedle/Getty Images.",
                    SourceLink = "www.kaggle.com",
                    ClassifiedAs = 0
                },
                new News{
                    Id = 5,
                    Title = "Pope Francis Just Called Out Donald Trump During His Christmas Speech",
                    Date = new DateTime(2017, 12, 25),
                    Text = "Pope Francis used his annual Christmas Day message to rebuke Donald Trump without even mentioning his name. The Pope delivered his message just days after members of the United Nations condemned Trump s move to recognize Jerusalem as the capital of Israel. The Pontiff prayed on Monday for the  peaceful coexistence of two states within mutually agreed and internationally recognized borders. We see Jesus in the children of the Middle East who continue to suffer because of growing tensions between Israelis and Palestinians,  Francis said.  On this festive day, let us ask the Lord for peace for Jerusalem and for all the Holy Land. Let us pray that the will to resume dialogue may prevail between the parties and that a negotiated solution can finally be reached. The Pope went on to plead for acceptance of refugees who have been forced from their homes, and that is an issue Trump continues to fight against. Francis used Jesus for which there was  no place in the inn  as an analogy. Today, as the winds of war are blowing in our world and an outdated model of development continues to produce human, societal and environmental decline, Christmas invites us to focus on the sign of the Child and to recognize him in the faces of little children, especially those for whom, like Jesus,  there is no place in the inn,  he said. Jesus knows well the pain of not being welcomed and how hard it is not to have a place to lay one s head,  he added.  May our hearts not be closed as they were in the homes of Bethlehem. The Pope said that Mary and Joseph were immigrants who struggled to find a safe place to stay in Bethlehem. They had to leave their people, their home, and their land,  Francis said.  This was no comfortable or easy journey for a young couple about to have a child.   At heart, they were full of hope and expectation because of the child about to be born; yet their steps were weighed down by the uncertainties and dangers that attend those who have to leave their home behind. So many other footsteps are hidden in the footsteps of Joseph and Mary,  Francis said Sunday. We see the tracks of entire families forced to set out in our own day. We see the tracks of millions of persons who do not choose to go away, but driven from their land, leave behind their dear ones. Amen to that.Photo by Christopher Furlong/Getty Images.",
                    SourceLink = "www.kaggle.com",
                    ClassifiedAs = 0
                },
                new News{
                    Id = 6,
                    Title = "Racist Alabama Cops Brutalize Black Boy While He Is In Handcuffs (GRAPHIC IMAGES)",
                    Date = new DateTime(2017, 12, 25),
                    Text = "The number of cases of cops brutalizing and killing people of color seems to see no end. Now, we have another case that needs to be shared far and wide. An Alabama woman by the name of Angela Williams shared a graphic photo of her son, lying in a hospital bed with a beaten and fractured face, on Facebook. It needs to be shared far and wide, because this is unacceptable.It is unclear why Williams  son was in police custody or what sort of altercation resulted in his arrest, but when you see the photo you will realize that these details matter not. Cops are not supposed to beat and brutalize those in their custody. In the post you are about to see, Ms. Williams expresses her hope that the cops had their body cameras on while they were beating her son, but I think we all know that there will be some kind of convenient  malfunction  to explain away the lack of existence of dash or body camera footage of what was clearly a brutal beating. Hell, it could even be described as attempted murder. Something tells me that this young man will never be the same. Without further ado, here is what Troy, Alabama s finest decided was appropriate treatment of Angela Williams  son:No matter what the perceived crime of this young man might be, this is completely unacceptable. The cops who did this need to rot in jail for a long, long time   but what you wanna bet they get a paid vacation while the force  investigates  itself, only to have the officers returned to duty posthaste?This, folks, is why we say BLACK LIVES MATTER. No way in hell would this have happened if Angela Williams  son had been white. Please share far and wide, and stay tuned to Addicting Info for further updates.Featured image via David McNew/Stringer/Getty Images",
                    SourceLink = "www.kaggle.com",
                    ClassifiedAs = 0
                },
                new News{
                    Id = 7,
                    Title = "Fresh Off The Golf Course, Trump Lashes Out At FBI Deputy Director And James Comey",
                    Date = new DateTime(2017, 12, 23),
                    Text = "Donald Trump spent a good portion of his day at his golf club, marking the 84th day he s done so since taking the oath of office. It must have been a bad game because just after that, Trump lashed out at FBI Deputy Director Andrew McCabe on Twitter following a report saying McCabe plans to retire in a few months. The report follows McCabe s testimony in front of congressional committees this week, as well as mounting criticism from Republicans regarding the Russia probe.So, naturally, Trump attacked McCabe with a lie. How can FBI Deputy Director Andrew McCabe, the man in charge, along with leakin  James Comey, of the Phony Hillary Clinton investigation (including her 33,000 illegally deleted emails) be given $700,000 for wife s campaign by Clinton Puppets during investigation?  Trump tweeted.How can FBI Deputy Director Andrew McCabe, the man in charge, along with leakin  James Comey, of the Phony Hillary Clinton investigation (including her 33,000 illegally deleted emails) be given $700,000 for wife s campaign by Clinton Puppets during investigation?  Donald J. Trump (@realDonaldTrump) December 23, 2017He didn t stop there.FBI Deputy Director Andrew McCabe is racing the clock to retire with full benefits. 90 days to go?!!!  Donald J. Trump (@realDonaldTrump) December 23, 2017Wow,  FBI lawyer James Baker reassigned,  according to @FoxNews.  Donald J. Trump (@realDonaldTrump) December 23, 2017With all of the Intel at Trump s disposal, he s getting his information from Fox News. McCabe spent most of his career in the fight against terrorism and now he s being attacked by the so-called president. Trump has been fact-checked before on his claim of his wife receiving $700,000 for her campaign.Politifact noted in late July that Trump s  tweet about Andrew McCabe is a significant distortion of the facts. And the implication that McCabe got Clinton off as a political favor doesn t make much sense when we look at the evidence. His July tweet was rated  mostly false.  But Trump repeats these lies because he knows his supporters will believe them without bothering to Google. It s still a lie, though.Photo by Zach Gibson   Pool/Getty Images.",
                    SourceLink = "www.kaggle.com",
                    ClassifiedAs = 0
                },
                new News{
                    Id = 8,
                    Title = "Trump Said Some INSANELY Racist Stuff Inside The Oval Office, And Witnesses Back It Up",
                    Date = new DateTime(2017, 12, 23),
                    Text = "In the wake of yet another court decision that derailed Donald Trump s plan to bar Muslims from entering the United States, the New York Times published a report on Saturday morning detailing the president s frustration at not getting his way   and how far back that frustration goes.According to the article, back in June, Trump stomped into the Oval Office, furious about the state of the travel ban, which he thought would be implemented and fully in place by then. Instead, he fumed, visas had already been issued to immigrants at such a rate that his  friends were calling to say he looked like a fool  after making his broad pronouncements.It was then that Trump began reading from a document that a top advisor, noted white supremacist Stephen Miller, had handed him just before the meeting with his Cabinet. The page listed how many visas had been issued this year, and included 2,500 from Afghanistan (a country not on the travel ban), 15,000 from Haiti (also not included), and 40,000 from Nigeria (sensing a pattern yet?), and Trump expressed his dismay at each.According to witnesses in the room who spoke to the Times on condition of anonymity, and who were interviewed along with three dozen others for the article, Trump called out each country for its faults as he read: Afghanistan was a  terrorist haven,  the people of Nigeria would  never go back to their huts once they saw the glory of America, and immigrants from Haiti  all have AIDS. Despite the extensive research done by the newspaper, the White House of course denies that any such language was used.But given Trump s racist history and his advisor Stephen Miller s blatant white nationalism, it would be no surprise if a Freedom of Information Act request turned up that the document in question had the statements printed inline as commentary for the president to punctuate his anger with. It was Miller, after all, who was responsible for the  American Carnage  speech that Trump delivered at his inauguration.This racist is a menace to America, and he doesn t represent anything that this country stands for. Let s hope that more indictments from Robert Mueller are on their way as we speak.Featured image via Chris Kleponis/Pool/Getty Images",
                    SourceLink = "www.kaggle.com",
                    ClassifiedAs = 0
                },
                new News{
                    Id = 9,
                    Title = " Former CIA Director Slams Trump Over UN Bullying, Openly Suggests He’s Acting Like A Dictator (TWEET)",
                    Date = new DateTime(2017, 12, 22),
                    Text = "Many people have raised the alarm regarding the fact that Donald Trump is dangerously close to becoming an autocrat. The thing is, democracies become autocracies right under the people s noses, because they can often look like democracies in the beginning phases. This was explained by Republican David Frum just a couple of months into Donald Trump s presidency, in a piece in The Atlantic called  How to Build an Autocracy. In fact, if you really look critically at what is happening right now   the systematic discrediting of vital institutions such as the free press and the Federal Bureau of Investigation as well the direct weaponization of the Department of Justice in order to go after Trump s former political opponent, 2016 Democratic nominee Hillary Clinton, and you have the makings of an autocracy. We are more than well on our way. Further, one chamber of Congress, the House of Representatives, already has a rogue band of Republicans who are running a parallel investigation to the official Russian collusion investigation, with the explicit intent of undermining and discrediting the idea that Trump could have possibly done anything wrong with the Russians in order to swing the 2016 election in his favor.All of that is just for starters, too. Now, we have Trump making United Nations Ambassador Nikki Haley bully and threaten other countries in the United Nations who voted against Trump s decision to change U.S. policy when it comes to recognition of Jerusalem as the capital of the Jewish State. Well, one expert, who is usually quite measured, has had enough of Trump s autocratic antics: Former CIA Director John O. Brennan. The seasoned spy took to Trump s favorite platform, Twitter, and blasted the decision:Trump Admin threat to retaliate against nations that exercise sovereign right in UN to oppose US position on Jerusalem is beyond outrageous. Shows @realDonaldTrump expects blind loyalty and subservience from everyone qualities usually found in narcissistic, vengeful autocrats.  John O. Brennan (@JohnBrennan) December 21, 2017Director Brennan is correct, of course. Trump is behaving just like an autocrat, and so many people in the nation are asleep when it comes to this dangerous age, in which the greatest threat to democracy and the very fabric of the republic itself is the American president. Fellow Americans, we know the GOP-led Congress will not be the check on Trump that they are supposed to be. It s time to get out and flip the House and possibly the Senate in 2018, and resist in the meantime, if we want to save our country from devolving into something that looks more like Russia or North Korea than the America we have always know. We re already well on our way.Featured image via BRENDAN SMIALOWSKI/AFP/Getty Images",
                    SourceLink = "www.kaggle.com",
                    ClassifiedAs = 0
                },
                new News{
                    Id = 10,
                    Title = "WATCH: Brand-New Pro-Trump Ad Features So Much A** Kissing It Will Make You Sick",
                    Date = new DateTime(2017, 12, 21),
                    Text = "Just when you might have thought we d get a break from watching people kiss Donald Trump s ass and stroke his ego ad nauseam, a pro-Trump group creates an ad that s nothing but people doing even more of those exact things. America First Policies is set to release this ad, called  Thank You, President Trump,  on Christmas Day and, well, we threw up a little in our mouths trying to watch this.Basically, the spot is nothing but people fawning all over Trump for all the stuff he hasn t actually done. The ad includes a scene with a little girl thanking Trump for bringing back  Merry Christmas,  which never went away (there are even videos of President Obama saying  Merry Christmas  himself). A man thanks him for cutting his taxes. And America First says that everyday Americans everywhere are thanking Trump for being such a great and awesome president.The best president.Nobody s ever done what he s done. He s breaking all kinds of records every day.Believe us.Anyway, the word  propaganda  comes to mind when watching this. That s what it is   literal propaganda promoting someone who shouldn t need this kind of promotion anymore. Watch this ad bullshit below:The way the MAGAs are kowtowing to Orange Hitler is both disgusting and frightening. The man has done nothing, and his policies will harm the very same Americans who are thanking him. Unfortunately, it will take an obscene amount of pain before they ll open their eyes and see they ve been duped by a con man with a bad hairdo.And his ongoing need for this kind of adoration is, at best, unbecoming of his office. This ad is vile.Featured image via Al Drago-Pool/Getty Images",
                    SourceLink = "www.kaggle.com",
                    ClassifiedAs = 0
                },
                new News{
                    Id = 11,
                    Title = "Papa John’s Founder Retires, Figures Out Racism Is Bad For Business",
                    Date = new DateTime(2017, 12, 21),
                    Text = "A centerpiece of Donald Trump s campaign, and now his presidency, has been his white supremacist ways. That is why so many of the public feuds he gets into involve people of color. One of his favorite targets, is, of course, the players in the National Football League who dare to exercise their First Amendment rights by kneeling during the national anthem in protest of racist police brutality. Well, there is one person who has figured out that racism is bad for business, even if it did get the orange overlord elected: The founder of the pizza chain Papa John s.This is a man who has never been on the right side of history on any number of issues, and plus his pizza sucks. But, when he decided to complain about the players protesting, his sales really dropped. Turns out racism doesn t pay, and we all know that corporations are all about the bottom line. Therefore, Papa John Schnatter will no longer be CEO of the hack pizza chain.BREAKING: Papa John's founder John Schnatter to step down as CEO; announcement comes weeks after he criticized NFL over protests.  AP Business News (@APBusiness) December 21, 2017The thing is, while people are certainly allowed to have political opinions, they have to realize that those opinions can often come with dire consequences   especially if one is in the business of trying to garner sales and support from any and all people, which one would presume is the goal of all CEO s. No one knows whether or not the pressure from his shareholders, the public outcry or boycotts, or even the NFL itself had anything to do with his stepping down. As of right now, all we know is that he will be gone, and perhaps the future CEO will run a company that is inclusive of the diverse fabric that we call America. After all, the guiding symbol of this nation will always be the Statue of Liberty, and bigots like Trump and Schnatter are the past. The rest of us are the future. We just have to survive the present to get there.Featured image via Rob Kim/Getty Images",
                    SourceLink = "www.kaggle.com",
                    ClassifiedAs = 0
                },
                new News{
                    Id = 12,
                    Title = "WATCH: Paul Ryan Just Told Us He Doesn’t Care About Struggling Families Living In Blue States",
                    Date = new DateTime(2017, 12, 21),
                    Text = "Republicans are working overtime trying to sell their scam of a tax bill to the public as something that directly targets middle-class and working-class families with financial relief. Nothing could be further from the truth, and they re getting hammered on that repeatedly. Speaking on CNBC, Paul Ryan was going full throttle, trying to convince us that the paltry savings we re getting is actually wait for it big money.But he didn t just go with the usual talking points. With a smug look that only someone who grew up in a wealthy family can muster when talking about that which he does not know, Ryan claimed that the $2,059 more per year that families living paycheck-to-paycheck will see is extremely significant. Then he decided he had to amend that to say such savings might be nothing to a family earning $600,000 per year (true), or for people living in New York or California (false).Those are the same two states that Trump s loyal subjects insist on stripping from the 2016 vote totals to claim that Trump actually won the popular vote. Watch Ryan completely dismiss all the struggling families living in blue states below:If you re living paycheck-to-paycheck which is more than half of the people in this country and you got #2059more from a tax cut next year, that s not nothing. pic.twitter.com/8TKtrMqRa1  Paul Ryan (@SpeakerRyan) December 21, 2017Someone needs to reach through their computer or television and wipe that smugness off his face. It is the height of arrogance and insult to imply that there are no struggling families in either of those two states.Featured image via Mark Wilson/Getty Images",
                    SourceLink = "www.kaggle.com",
                    ClassifiedAs = 0
                },
                new News{
                    Id = 13,
                    Title = "Bad News For Trump — Mitch McConnell Says No To Repealing Obamacare In 2018",
                    Date = new DateTime(2017, 12, 21),
                    Text = "Republicans have had seven years to come up with a viable replacement for Obamacare but they failed miserably. After taking a victory lap for gifting the wealthy with a tax break on Wednesday, Donald Trump looked at the cameras and said,  We have essentially repealed Obamacare and we will come up with something that will be much better. Obamacare has been repealed in this bill,  he added. Well, like most things Trump says, that s just not true. But, if the former reality show star could have done that in order to eradicate former President Obama s signature legislation, he would have and without offering an alternative.Senate Majority Leader Mitch McConnell told NPR that  This has not been a very bipartisan year. I hope in the new year, we re going to pivot here and become more cooperative. An Obamacare repeal in 2018 is DOA. Well, we obviously were unable to completely repeal and replace with a 52-48 Senate,  the Kentucky Republican said.  We ll have to take a look at what that looks like with a 51-49 Senate. But I think we ll probably move on to other issues. NPR reports:McConnell hopes to focus instead on stabilizing the insurance marketplaces to keep premiums from skyrocketing in the early months of 2018, a promise he made to moderate Republican Sen. Susan Collins of Maine to get her support for the tax bill.On top of that McConnell broke with House Speaker Paul Ryan, R-Wis., on the approach to paring back spending on programs like Medicaid and food stamps. McConnell told NPR he is  not interested  in using Senate budget rules to allow Republicans to cut entitlements without consultation with Democrats. I think entitlement changes, to be sustained, almost always have to be bipartisan,  McConnell said.  The House may have a different agenda. If our Democratic friends in the Senate want to join us to tackle any kind of entitlement reform. I d be happy to take a look at it. This is coming from Mitch McConnell. He knows Donald Trump is destroying the GOP. It doesn t matter, Sen. McConnell. We still recall him saying that his  number one priority is making sure president Obama s a one-term president. Well, we re hoping that Trump doesn t last a full term. Funny how that works.Photo by Chip Somodevilla/Getty Images",
                    SourceLink = "www.kaggle.com",
                    ClassifiedAs = 0
                },
                new News{
                    Id = 14,
                    Title = "WATCH: Lindsey Graham Trashes Media For Portraying Trump As ‘Kooky,’ Forgets His Own Words",
                    Date = new DateTime(2017, 12, 20),
                    Text = "The media has been talking all day about Trump and the Republican Party s scam of a tax bill; as well as the sheer obsequiousness of Trump s cabinet, and then members of Congress, after their tax scam was all but passed. But the media isn t quite saying what Trump wants. They ve been doing analysis and discussion all day long rather than praising it for the grand achievement Trump believes it is. The GOP has increasingly sounded exactly like Trump when it comes to media coverage, and coverage of the tax scam is no different. Coverage of Trump in general hasn t changed.Today, Lindsey Graham went after the media for portraying Trump as a  kook,  and unfit for office (they wouldn t be doing their job if they weren t telling the truth, though). Graham said: You know what concerns me about the American press is this endless, endless attempt to label the guy as some kind of kook; not fit to be president. Jake Tapper notes that he himself has never labeled Trump that way. But then he points out something rather odd about Graham s opinion. Take a look at the short video clip below:Lindsey Graham today: I m concerned by the media s attempt to label Trump as a kook or not fit to be President.Lindsey Graham in 2016:  I think he s a kook. I think he s crazy. I think he s unfit for office.  pic.twitter.com/hIxs3DciO8  Tomthunkit  (@TomthunkitsMind) December 17, 2017There it is, out of Graham s own mouth. He parroted himself. In 2016, he used the exact words to describe Trump that he said the media is using today. Freudian slip?Featured image via video screen capture",
                    SourceLink = "www.kaggle.com",
                    ClassifiedAs = 0
                },
                new News{
                    Id = 15,
                    Title = "Heiress To Disney Empire Knows GOP Scammed Us – SHREDS Them For Tax Bill",
                    Date = new DateTime(2017, 12, 20),
                    Text = "Abigail Disney is an heiress with brass ovaries who will profit from the GOP tax scam bill but isn t into f-cking poor people over. Ms. Disney penned an op-ed for USA Today in which she rips the GOP a new one because she has  always been cognizant of income and wealth inequality.  In other words, she is not Donald Trump, Paul Ryan or Bob Corker. Or Mitch McConnell. She is Abigail Disney, dammit. Since the election of Ronald Reagan, the gap between rich and poor has grown dramatically and  trickle down  economics has turned out to cause more of a trickle up,  she writes.  But nothing has brought the problem of inequality into sharper focus for me than the current proposals by Republicans to overhaul the tax system. Disney says that this proposal will be burdensome to the middle class while decreasing  the responsibility of the wealthy to contribute to the common good. And then she dropped a truth bomb. (We like truth bombs.)Republicans insist this plan will cut taxes for the middle class, but the truth is that any meager savings will be offset by losses elsewhere   in deductions no longer allowed, loss of Medicaid and Medicare coverage, and less funding for education, all of which are on the chopping block in order to provide a tax cut for a few very wealthy people like me. There is even a tax break to private jet owners. This bill will give me this tax cut while also killing health insurance for over 13 million people,  Disney wrote.  It will let me pass over $20 million to my children, tax-free. And all my friends with private jets? They get a tax cut too. With a suffocating education system, a dying infrastructure and a national debt that will be at least $1.5 trillion bigger, that social mobility will be far out of reach for people like you,  Disney continued.  But I will be able to stay comfortably right where I am. Does that strike you as fair? No, it does not, thankyouverymuch. But given how this bill was written, I think it s looking a lot like a nightmare from Pirates of the Caribbean,  Disney wrote.  Have I made you angry yet? I really hope I ve made you angry. You should be. No one who votes for this tax bill will be voting with your life in mind. But you will pay for it. Watch:This Disney heiress is taking a stand against the GOP tax bill  even though she s going to benefit from it pic.twitter.com/E5bmcI83mU  NowThis (@nowthisnews) December 20, 2017 If democracy is just a bunch of people advocating for their own self-interest instead of the interests of the greater good, then we re not a democracy, we re anarchy,  Disney added.  We need to start voting and acting as citizens as though the common good matters more than our own personal well-being. This isn t tax reform. It s a heist.Photo by Ralph Orlowski/Getty Images for Burda Media.",
                    SourceLink = "www.kaggle.com",
                    ClassifiedAs = 0
                },
                new News{
                    Id = 16,
                    Title = "Tone Deaf Trump: Congrats Rep. Scalise On Losing Weight After You Almost Died",
                    Date = new DateTime(2017, 12, 20),
                    Text = "Donald Trump just signed the GOP tax scam into law. Of course, that meant that he invited all of his craven, cruel GOP sycophants down from their perches on Capitol Hill to celebrate in the Rose Garden at the White House. Now, that part is bad enough   celebrating tax cuts for a bunch of rich hedge fund managers and huge corporations at the expense of everyday Americans. Of course, Trump is beside himself with glee, as this represents his first major legislative win since he started squatting in the White House almost a year ago. Thanks to said glee, in true Trumpian style, he gave a free-wheeling address, and a most curious subject came up as Trump was thanking the goons from the Hill. Somehow, Trump veered away from tax cuts, and started talking about the Congressional baseball shooting that happened over the summer.In that shooting, Rep. Steve Scalise, who is also the House Majority Whip, was shot and almost lost his life. Thanks to this tragic and stunning act of political violence, Scalise had a long recovery; in fact he is still in physical therapy. But, of course, vain and looks-obsessed Trump decided that he would congratulate Scalise, not on his survival and on his miraculous recovery, but on the massive amount of weight Scalise lost while he was practically dying. And make no mistake   Scalise is VERY lucky to be alive. According to doctors, when he arrived at the hospital, Scalise was actually, quote, in  imminent risk of death.  Here is the quote, via Twitter:How stunningly tone deaf does one have to be to say something like that? I never thought I d say this about a Republican that I, by all reasonable accounts, absolutely loathe, but I feel sorry for him. I am sorry he got shot, and I am even sorrier that he now has to stand there and listen to that orange buffoon talk about him like that.I am sure that Scalise is a much tougher man than Trump, though. I am equally sure that he also knows that Trump is an international embarrassment and a crazy man who never should have been allowed anywhere near the White House.Featured image via Alex Wong/Getty Images",
                    SourceLink = "www.kaggle.com",
                    ClassifiedAs = 0
                },
                new News{
                    Id = 17,
                    Title = "The Internet Brutally Mocks Disney’s New Trump Robot At Hall Of Presidents",
                    Date = new DateTime(2017, 12, 19),
                    Text = "A new animatronic figure in the Hall of Presidents at Walt Disney World was added, where every former leader of the republic is depicted in an  audio-animatronics show.  The figure which supposedly resembles Jon Voight Donald Trump was added to the collection and it s absolutely horrifying. The internet noticed that, too.Here s a few more pictures of the Donald Trump animatronic. #HallOfPresidents pic.twitter.com/a45En9Jwys  WDW News Today (@WDWNT) December 19, 2017Trump robot in the Hall of Presidents looks like a 71-year-old Chucky doll. pic.twitter.com/yLCBmhpNvG  John Cohen (@JohnCohen1) December 19, 2017Breaking: 7 Disney Princesses and a Storm Trooper have come forward alleging Hall of Presidents Trump made lewd comments to them  Brohibition Now (@OhNoSheTwitnt) December 19, 2017Trump s animatronic figure for the Disney Hall of Presidents looks like it was carved out of Play-Doh and left out in the Florida heat, where it was discovered by a dying albino squirrel who settled atop its head and has been left there to decompose. pic.twitter.com/3vMZUTEylx  Elizabeth M. (@_ElizabethMay) December 19, 2017In a time w/ so many heavy items, thank you to Disney for the laugh. They did so much so well in the @realDonaldTrump animatronic.  Little hands, check   Absurdly long tie, check   Horrifying face, checkmateWhen Trump is impeached, can they move this to the Haunted Mansion? https://t.co/XrOvu32EV8  State of Resistance (@AltStateDpt) December 19, 2017all the other presidents in Disney s new Hall of Presidents look like they can t believe Donald Trump is president either pic.twitter.com/eMP9UX1bM8  Matt Binder (@MattBinder) December 18, 2017Disney unveiled Trump figure at the Hall of Presidents. To save production costs, they pulled the animated hands off of a retired figurine from the Its a Small World ride.  Tim Hanlon (@TimfromDa70s) December 19, 2017The best part of Donald Trump being in Disney s Hall of Presidents will be when they remove him from the Hall of Presidents and put him in the Pirates of the Caribbean ride s jail. pic.twitter.com/XViyKFQCET  Rex Huppke (@RexHuppke) December 19, 2017Comment today by local news channel anchor in Orlando:  Donald Trump robot just added to Disney s Hall of Presidents. I hope they programmed all the former presidents to not roll their eyes and shake their heads while he s talking.  Mark Hertling (@MarkHertling) December 19, 2017NPR: Disney World Adds Trump Animatronic Figure, But Likeness Is Lacking. But who REALLY wants to look at an accurate Donald? The man is about as presidential looking as a fucking Pokemon. https://t.co/HFYJRkefJ1  Stephen (@Harvest_This) December 19, 2017Could we put the animatronic version in the White House and the  real  one in Disney World? Asking for 7.6 billion people and the future of the planet. https://t.co/65FhbQHuV4 #Disney #Trump #JonVoight  David Schmid (@DavidSchmid1) December 19, 2017We re pretty sure Disney is trolling Trump.Image via Twitter.",
                    SourceLink = "www.kaggle.com",
                    ClassifiedAs = 0
                },
                new News{
                    Id = 18,
                    Title = "Mueller Spokesman Just F-cked Up Donald Trump’s Christmas",
                    Date = new DateTime(2017, 12, 17),
                    Text = "Trump supporters and the so-called president s favorite network are lashing out at special counsel Robert Mueller and the FBI. The White House is in panic-mode after Mueller obtained tens of thousands of transition team emails as part of the Russian probe. Ironically, it will quite possibly be emails that brings Trump down.A lawyer for the Trump transition team is claiming that the emails had been illegally turned over by the General Services Administration because the account owners never received notification of the request and he s claiming that they were  privileged communications. In a letter, Trump s attorney requested that Congress  act immediately to protect future presidential transitions from having their private records misappropriated by government agencies, particularly in the context of sensitive investigations intersecting with political motives. Mueller spokesman Peter Carr defended the special counsel s work in a statement issued just past midnight on Sunday, several hours after claims of   unlawful conduct  by Trump s attorney were made, according to Politico. When we have obtained emails in the course of our ongoing criminal investigation, we have secured either the account owner s consent or appropriate criminal process,  he said.The words that pop out in the statement are  criminal investigation,  the  account owner s consent  and  criminal process. While on the campaign trail, Donald Trump asked Russians to hack Hillary Clinton s emails. After the election, Trump s team is claiming that Mueller obtained the transition teams  emails illegally, even though that s not the truth. We see a pattern here.Team Trump thought Mueller was on a fishing expedition. Turns out, he was actually reeling in the fish. The White House was not aware at the time that he had the emails. Mueller got them through GSA so that team Trump could not selectively leave any out if they were requested.Merry Christmas, Mr. Trump.Photo by Ann Heisenfelt/Getty Images.",
                    SourceLink = "www.kaggle.com",
                    ClassifiedAs = 0
                },
                new News{
                    Id = 19,
                    Title = "SNL Hilariously Mocks Accused Child Molester Roy Moore For Losing AL Senate Race (VIDEO)",
                    Date = new DateTime(2017, 12, 17),
                    Text = "Right now, the whole world is looking at the shocking fact that Democrat Doug Jones beat Republican Roy Moore in the special election to replace Attorney General Jeff Sessions in the United States Senate. Of course, Moore s candidacy was rocked by allegations of sexually harassing and even molesting teenage girls   and being banned from the mall in his hometown of Gadsden, Alabama for doing so.Even before that, Moore was an incendiary character in Alabama politics, having been removed as Chief Justice of the Alabama Supreme Court not once but twice, and having made statements such as Muslims should not be allowed in Congress and homosexuality should be illegal. Hell, he even said that the last time America was great was when we had slavery. Therefore, he was an extraordinarily damaged candidate as it was. However, despite all of this, Alabama is a deep red state, with many voters agreeing with some of Moore s more extreme positions, and some even insisting that the allegations of sexual misconduct were simply not true. That is why it was such a shock that Doug Jones pulled out a win for that Senate seat.Well, there is one entity that could not resist going all in on the fact that Roy Moore lost this race: Saturday Night Live. While doing a caricature of the results, SNL began, with its Weekend Update host Colin Jost brutally mocking Moore s alleged proclivities fore teen girls: Congratulations to Alabama s newest Senator   not Roy Moore. Doug Jones has become the first Democrat to win a Senate seat in Alabama in over 20 years. Said Roy Moore:  gross, over 20 years? Jost then got in a dig at Trump, for whom Moore s loss was  a humiliating failure, remind everyone what Trump said of Jones  win: The Republicans will have another shot at this seat in a very short period of time. It never ends! Indeed. If the sane people of America have anything to say about it, it will be a very, very long time after 2018 before the GOP is allowed to control anything. Jost continued mocking Trump: That s it? You just went all in for an accused pedophile and when he lost, [you re] just like,  well, we had fun! He could be removed from office tonight and tweet:  Congratulations to Robert Mueller on a great investigation. Had a fun time being president. Catch you on the flippity-flop! #DietCokeTime . Oh, if only that could be our reality, to have Trump congratulating Mueller for removing him and his entire treasonous, criminal administration. Until then, we ll have to stick to  Weekend Update  and the rest of SNL, and hope for the best.Watch the video below:Featured image via Scott Olson/Getty Images",
                    SourceLink = "www.kaggle.com",
                    ClassifiedAs = 0
                },
                new News{
                    Id = 20,
                    Title = "Republican Senator Gets Dragged For Going After Robert Mueller",
                    Date = new DateTime(2017, 12, 16),
                    Text = "Senate Majority Whip John Cornyn (R-TX) thought it would be a good idea to attack Special Counsel Robert Mueller over the Russia probe. As Mueller s noose tightens, Republicans are losing their sh-t and attacking Mueller and the FBI in order to protect probably the most corrupt  president  ever.Former Attorney General Eric Holder tweeted on Friday,  Speaking on behalf of the vast majority of the American people, Republicans in Congress be forewarned: any attempt to remove Bob Mueller will not be tolerated. Cornyn retweeted Holder to say,  You don t. You don t https://t.co/7lHYkIloyz  Senator JohnCornyn (@JohnCornyn) December 16, 2017Bloomberg s Steven Dennis tweeted on Saturday that  [Cornyn] s beef is with Holder, not Mueller,  but Cornyn responded to say,  But Mueller needs to clean house of partisans. But Mueller needs to clean house of partisans https://t.co/g8SwgAKtfH  Senator JohnCornyn (@JohnCornyn) December 16, 2017The Washington Post s Greg Sargent asked Cornyn,  Will you accept the findings of the Mueller probe as legitimate, @JohnCornyn? Makes sense to me to wait to see what they are first,  Cornyn responded.Makes sense to me to wait to see what they are first https://t.co/9lCqpYujKN  Senator JohnCornyn (@JohnCornyn) December 16, 2017Republicans are trying to discredit Mueller and Twitter users took notice.If you even THINK of firing Mueller I ll make it my life s mission to make sure this is your last term, buddy.  Mrs. SMH (@MRSSMH2) December 16, 2017Carrollton, TX here Ready and willing to help get Cruz and Cornyn out  Jules012 (@JulesLorey1) December 16, 2017Garland, TX here Same! Bye Bye   TDK (@ejkmom1998) December 16, 2017Austin, TX. #IStandWithMueller. Cronyn is a fake representative. He represents his own interests and anything to profit himself  Vj (@Tex92eye) December 16, 2017I stand with Mueller!   Kenneth Shipp (@shipp_kenneth) December 16, 2017He speaks for me Its BS how you cover up for a Russia pawn If Trump not gulity why would Mueller be fired to cover up  Ellen Reeher Morris (@EllenMorris1222) December 16, 2017@EricHolder speaks for 69% of Americans according to recent polling. That s  vast majority  in my book. You were around for the Saturday Night Massacre @JohnCornyn. Firing Mueller would be X100!  Lori Winters (@LoriW66) December 16, 2017Country over party. pic.twitter.com/NXEX9rGBgu  PittieBoo (@PittieBoo) December 16, 2017He speaks for me, @JohnCornyn , and he speaks for the vast majority of American citizens who, you should remember, vote. See you in 2018.  Andrew Silver (@standsagreenoak) December 16, 2017I might just move to Texas to get those cronies tossed out of office. Blue wave is coming for the corrupt.  Ollie (@marciebp) December 16, 2017Good try, John. History will not be kind to you.Photo by Ann Heisenfelt/Getty Images",
                    SourceLink = "www.kaggle.com",
                    ClassifiedAs = 0
                },
                new News{
                    Id = 21,
                    Title = "In A Heartless Rebuke To Victims, Trump Invites NRA To Xmas Party On Sandy Hook Anniversary",
                    Date = new DateTime(2017, 12, 16),
                    Text = "It almost seems like Donald Trump is trolling America at this point. In the beginning, when he tried to gaslight the country by insisting that the crowd at his inauguration was the biggest ever   or that it was even close to the last couple of inaugurations   we all kind of scratched our heads and wondered what kind of bullshit he was playing at. Then when he started appointing people to positions they had no business being in, we started to worry that this was going to go much worse than we had expected.After 11 months of Donald Trump pulling the rhetorical equivalent of whipping his dick out and slapping it on every table he gets near, I think it s time we address what s happening: Dude is a straight-up troll. He gets pleasure out of making other people uncomfortable or even seeing them in distress. He actively thinks up ways to piss off people he doesn t like.Let s set aside just for a moment the fact that that s the least presidential  behavior anyone s ever heard of   it s dangerous.His latest stunt is one of the grossest yet.Everyone is, by now, used to Trump not talking about things he doesn t want to talk about, and making a huge deal out of things that not many people care about. So it wasn t a huge surprise when the president didn t discuss the Sandy Hook shooting of 2012 on the fifth anniversary of that tragic event. What was a huge surprise was that he not only consciously decided not to invite the victims  families to the White House Christmas party this year   as they have been invited every year since the massacre took place, along with others who share those concerns.In each of the past 4 years, President Obama invited gun violence prevention activists, gun violence survivors (including the Sandy Hook families) and supportive lawmakers to his Christmas party. Zero gun lobbyists were in attendance. pic.twitter.com/QePW9FtbSh  Shannon Watts (@shannonrwatts) December 15, 2017The last sentence of that tweet is important, because that s exactly who Donald Trump did invite to the White House Christmas party. Instead of victims. On the anniversary day.Yesterday was the 5 year mark of the mass shooting at Sandy Hook School, which went unacknowledged by the President. On the same day, he hosted a White House Christmas party to which he invited @NRA CEO Wayne LaPierre. Here he is at the party with @DanPatrick. pic.twitter.com/mUbKCIWGxB  Shannon Watts (@shannonrwatts) December 15, 2017Wayne LaPierre is the man who, in response to the Sandy Hook massacre, finally issued a statement that blamed gun violence on music, movies, and video games, and culminated with perhaps the greatest bit of irony any man has ever unintentionally conceived of: Isn t fantasizing about killing people as a way to get your kicks really the filthiest form of pornography? Yes. Yes, it is, Wayne.Anyway, Happy Holidays Merry Christmas from Donald Trump, everyone!Featured image via Alex Wong/Getty Images",
                    SourceLink = "www.kaggle.com",
                    ClassifiedAs = 0
                },
                new News{
                    Id = 22,
                    Title = "KY GOP State Rep. Commits Suicide Over Allegations He Molested A Teen Girl (DETAILS)",
                    Date = new DateTime(2017, 12, 13),
                    Text = "In this #METOO moment, many powerful men are being toppled. It spans many industries, from entertainment, to journalism, to politics and beyond. Any man that ever dared to abuse his power to sexually harass, molest, or assault women better brace himself for being rooted out, publicly shamed, and forced into early retirement.Well, unfortunately, the latest bombshell story has actually resulted in the suicide of a lawmaker. Kentucky State Representative Dan Johnson left a suicide note on Facebook and then shot himself on a bridge, according to reports from local authorities. Bullitt County Sheriff Donnie Tinnell reported to local station WDRB that Johnson s body was found after his suicide note from Facebook was reported to the local police. Here is that note:Now, nobody wants to celebrate a suicide. This man should have resigned gracefully and faced his accuser, who was a friend of his daughter s, who says that Johnson molested her while she was passed out drunk in his home. Apparently, Johnson, who referred to himself as some kind of  pope,  routinely engaged in parties with plenty of alcohol with minors. Johnson s home was called the  Pope s House,  and he was the preacher at the Heart of Fire City Church, where the alleged molestation took place.Now, innocent until proven guilty and all of that, but if someone commits suicide, it s likely there could be some merit there. That s a rather extreme measure to take. Further, by all accounts, this guy was no saint. He was heavily pro-gun, opposed any and all abortion rights, and has referred to President Barack Obama and First Lady Michelle Obama as monkeys on his Facebook page, among other racist messages and images.Again, we re not glad the man is dead. But, it is important for people to remember him for exactly who he was. We grieve for the loss his children, wife, and grandchildren suffered, for nobody deserves such a loss. However, methinks the people of Kentucky are much better off. Sad to say, but true.Featured image via screen capture",
                    SourceLink = "www.kaggle.com",
                    ClassifiedAs = 0
                },
                new News{
                    Id = 23,
                    Title = "Meghan McCain Tweets The Most AMAZING Response To Doug Jones’ Win In Deep-Red Alabama",
                    Date = new DateTime(2017, 12, 12),
                    Text = "As a Democrat won a Senate seat in deep-red Alabama, social media offered up everyone s opinion because that s what social media does. Democrat Doug Jones narrowly defeated accused pedophile and serial sexual assaulter Roy Moore in a special election for the Senate seat vacated by Jeff Sessions when he was appointed Attorney General. And some Republicans aren t exactly heartbroken about this.Take Meghan McCain   John McCain s daughter. She went right after one of Trump s biggest supporters Steve Bannon as soon as the election results were announced:Suck it, Bannon  Meghan McCain (@MeghanMcCain) December 13, 2017Three simple words. It s amazing what three simple words can say.Steve Bannon spoke at Moore s election night rally, which we assume was supposed to be a night of celebration. Bannon endorsed Moore early on, against Luther Strange, whom Donald Trump himself campaigned for earlier this year. Bannon s support for Moore remained steadfast even in the wake of multiple allegations surfaced against him of sexual assault, harassment and even pedophilia. Bannon even said,  There s a special place in hell  for those who refuse to support Moore.On Dec. 12, the people of Alabama rejected Roy Moore s penchant for pursuing, even assaulting, teenage girls. They rejected his hate and bigotry. They rejected an asshat who has been removed from Alabama s Supreme Court twice for violating federal court orders, thus demonstrating he has no respect for the rule of law. And they sent a message to the Republican Party that this bullshit will no longer be tolerated. If deep-red Alabama can elect a Democrat, then anyone can. And that should have Republicans scared out of their minds.Well, we re going there, along with Meghan McCain and anyone else who believed Moore shouldn t ever hold public office. Even Republicans have their limits, it seems.Featured image via Frederick M. Brown/Getty Images",
                    SourceLink = "www.kaggle.com",
                    ClassifiedAs = 0
                },
                new News{
                    Id = 24,
                    Title = "CNN CALLS IT: A Democrat Will Represent Alabama In The Senate For The First Time In 25 Years",
                    Date = new DateTime(2017, 12, 12),
                    Text = "Alabama is a notoriously deep red state. It s a place where Democrats always think that we have zero chances of winning   especially in statewide federal elections. However, that is just what happened on Tuesday night in the Special Election to replace Senator Jeff Sessions. Doug Jones, the Democratic Senate candidate who is known in the state for prosecuting the Ku Klux Klan members who bombed a church during the Civil Rights Movement and killed four little African American girls, will be the next Senator from Alabama. CNN has just called the race, as there seems no more GOP-leaning counties out there.To contrast, Roy Moore had been twice removed from the Alabama Supreme Court as Chief Justice for violating the law, and was also credibly accused of being a sexual predator toward teen girls. Despite all of that, though, the race was a nail biter, because Moore has a long history and a deep base in Alabama. Of course, decent people   including Republicans   were horrified at the idea of a man like Roy Moore going to the Senate. Despite the allegations of sexual predation, Moore also had said many incendiary things, such as putting forth the idea that Muslims shouldn t be allowed in Congress, that homosexuality should be illegal, and that America was great when slavery was legal. And that s just for starters, too.Thank you Alabama, for letting sanity prevail in this race. Oh, and a message to Democrats   this is proof we can compete everywhere. Get a fifty state strategy going so we can blow the GOP outta the water in 2018.Featured image via Justin Sullivan/Getty Images",
                    SourceLink = "www.kaggle.com",
                    ClassifiedAs = 0
                },
                new News{
                    Id = 25,
                    Title = "White House: It Wasn’t Sexist For Trump To Slut-Shame Sen. Kirsten Gillibrand (VIDEO)",
                    Date = new DateTime(2017, 12, 12),
                    Text = "A backlash ensued after Donald Trump launched a sexist rant against Kirsten Gillibrand Thursday morning, saying that the Democratic Senator  would do anything  for a campaign contribution. Trump was calling Gillibrand a whore.White House press secretary Sarah Huckabee Sanders somehow denied that Trump s tweet was sexist. There is no way that is sexist at all,  Sanders told reporters.Then Sanders tried to explain what Trump really meant (we all know what he really meant). According to Sanders, Trump was merely accusing Gillibrand of being  controlled by contributions,  and hammering home his pledge to  drain the swamp  in Washington, according to The Hill. I think that the president is very obvious,  she said.  This is the same sentiment the president has expressed many times before when he has exposed the corruption of the entire political system. Sanders claims that Trump does not owe Gillibrand an apology if his words were taken as sexist. I think only if your mind is in the gutter you would have read it that way, so no,  she said.Watch:Gillibrand called on Trump to resign after Trump s accusers came back into the spotlight by hosting a press conference in which they called for an investigation into his past behavior. Lightweight Senator Kirsten Gillibrand, a total flunky for Chuck Schumer and someone who would come to my office  begging  for campaign contributions not so long ago (and would do anything for them), is now in the ring fighting against Trump. Very disloyal to Bill & Crooked-USED!  Trump tweeted this morning.Gillibrand responded to Trump s attack, saying that she won t be silenced. You cannot silence me or the millions of women who have gotten off the sidelines to speak out about the unfitness and shame you have brought to the Oval Office,  she tweeted.Yeah, Trump, you called her a whore.Image via screen capture.",
                    SourceLink = "www.kaggle.com",
                    ClassifiedAs = 0
                },
                new News{
                    Id = 26,
                    Title = "As U.S. budget fight looms, Republicans flip their fiscal script",
                    Date = new DateTime(2017, 12, 31),
                    Text = "WASHINGTON (Reuters) - The head of a conservative Republican faction in the U.S. Congress, who voted this month for a huge expansion of the national debt to pay for tax cuts, called himself a “fiscal conservative” on Sunday and urged budget restraint in 2018. In keeping with a sharp pivot under way among Republicans, U.S. Representative Mark Meadows, speaking on CBS’ “Face the Nation,” drew a hard line on federal spending, which lawmakers are bracing to do battle over in January. When they return from the holidays on Wednesday, lawmakers will begin trying to pass a federal budget in a fight likely to be linked to other issues, such as immigration policy, even as the November congressional election campaigns approach in which Republicans will seek to keep control of Congress. President Donald Trump and his Republicans want a big budget increase in military spending, while Democrats also want proportional increases for non-defense “discretionary” spending on programs that support education, scientific research, infrastructure, public health and environmental protection. “The (Trump) administration has already been willing to say: ‘We’re going to increase non-defense discretionary spending ... by about 7 percent,’” Meadows, chairman of the small but influential House Freedom Caucus, said on the program. “Now, Democrats are saying that’s not enough, we need to give the government a pay raise of 10 to 11 percent. For a fiscal conservative, I don’t see where the rationale is. ... Eventually you run out of other people’s money,” he said. Meadows was among Republicans who voted in late December for their party’s debt-financed tax overhaul, which is expected to balloon the federal budget deficit and add about $1.5 trillion over 10 years to the $20 trillion national debt. “It’s interesting to hear Mark talk about fiscal responsibility,” Democratic U.S. Representative Joseph Crowley said on CBS. Crowley said the Republican tax bill would require the  United States to borrow $1.5 trillion, to be paid off by future generations, to finance tax cuts for corporations and the rich. “This is one of the least ... fiscally responsible bills we’ve ever seen passed in the history of the House of Representatives. I think we’re going to be paying for this for many, many years to come,” Crowley said. Republicans insist the tax package, the biggest U.S. tax overhaul in more than 30 years,  will boost the economy and job growth. House Speaker Paul Ryan, who also supported the tax bill, recently went further than Meadows, making clear in a radio interview that welfare or “entitlement reform,” as the party often calls it, would be a top Republican priority in 2018. In Republican parlance, “entitlement” programs mean food stamps, housing assistance, Medicare and Medicaid health insurance for the elderly, poor and disabled, as well as other programs created by Washington to assist the needy. Democrats seized on Ryan’s early December remarks, saying they showed Republicans would try to pay for their tax overhaul by seeking spending cuts for social programs. But the goals of House Republicans may have to take a back seat to the Senate, where the votes of some Democrats will be needed to approve a budget and prevent a government shutdown. Democrats will use their leverage in the Senate, which Republicans narrowly control, to defend both discretionary non-defense programs and social spending, while tackling the issue of the “Dreamers,” people brought illegally to the country as children. Trump in September put a March 2018 expiration date on the Deferred Action for Childhood Arrivals, or DACA, program, which protects the young immigrants from deportation and provides them with work permits. The president has said in recent Twitter messages he wants funding for his proposed Mexican border wall and other immigration law changes in exchange for agreeing to help the Dreamers. Representative Debbie Dingell told CBS she did not favor linking that issue to other policy objectives, such as wall funding. “We need to do DACA clean,” she said.  On Wednesday, Trump aides will meet with congressional leaders to discuss those issues. That will be followed by a weekend of strategy sessions for Trump and Republican leaders on Jan. 6 and 7, the White House said. Trump was also scheduled to meet on Sunday with Florida Republican Governor Rick Scott, who wants more emergency aid. The House has passed an $81 billion aid package after hurricanes in Florida, Texas and Puerto Rico, and wildfires in California. The package far exceeded the $44 billion requested by the Trump administration. The Senate has not yet voted on the aid. ",
                    SourceLink = "www.kaggle.com",
                    ClassifiedAs = 1
                },
                new News{
                    Id = 3,
                    Title = "",
                    Date = new DateTime(),
                    Text = "",
                    SourceLink = "www.kaggle.com",
                    ClassifiedAs = 0
                }
            );

            modelBuilder.Entity<NewsTopic>().HasData(
                new NewsTopic
                {
                    Id = 1,
                    NewsId = 1,
                    TopicId = 1
                },
                new NewsTopic
                {
                    Id = 2,
                    NewsId = 2,
                    TopicId = 1
                },
                new NewsTopic
                {
                    Id = 3,
                    NewsId = 3,
                    TopicId = 1
                },
                new NewsTopic
                {
                    Id = 4,
                    NewsId = 4,
                    TopicId = 1
                },
                new NewsTopic
                {
                    Id = 5,
                    NewsId = 5,
                    TopicId = 1
                },
                new NewsTopic
                {
                    Id = 6,
                    NewsId = 6,
                    TopicId = 1
                },
                new NewsTopic
                {
                    Id = 7,
                    NewsId = 7,
                    TopicId = 1
                },
                new NewsTopic
                {
                    Id = 8,
                    NewsId = 8,
                    TopicId = 1
                },
                new NewsTopic
                {
                    Id = 9,
                    NewsId = 9,
                    TopicId = 1
                },
                new NewsTopic
                {
                    Id = 10,
                    NewsId = 10,
                    TopicId = 1
                },
                new NewsTopic
                {
                    Id = 11,
                    NewsId = 11,
                    TopicId = 1
                },
                new NewsTopic
                {
                    Id = 12,
                    NewsId = 12,
                    TopicId = 1
                },
                new NewsTopic
                {
                    Id = 13,
                    NewsId = 13,
                    TopicId = 1
                },
                new NewsTopic
                {
                    Id = 14,
                    NewsId = 14,
                    TopicId = 1
                },
                new NewsTopic
                {
                    Id = 15,
                    NewsId = 15,
                    TopicId = 1
                },
                new NewsTopic
                {
                    Id = 16,
                    NewsId = 16,
                    TopicId = 1
                },
                new NewsTopic
                {
                    Id = 17,
                    NewsId = 17,
                    TopicId = 1
                },
                new NewsTopic
                {
                    Id = 18,
                    NewsId = 18,
                    TopicId = 1
                },
                new NewsTopic
                {
                    Id = 19,
                    NewsId = 19,
                    TopicId = 1
                },
                new NewsTopic
                {
                    Id = 20,
                    NewsId = 20,
                    TopicId = 1
                },
                new NewsTopic
                {
                    Id = 21,
                    NewsId = 21,
                    TopicId = 1
                },
                new NewsTopic
                {
                    Id = 22,
                    NewsId = 22,
                    TopicId = 1
                },
                new NewsTopic
                {
                    Id = 23,
                    NewsId = 23,
                    TopicId = 1
                },
                new NewsTopic
                {
                    Id = 24,
                    NewsId = 24,
                    TopicId = 1
                },
                new NewsTopic
                {
                    Id = 25,
                    NewsId = 25,
                    TopicId = 1
                },
                new NewsTopic
                {
                    Id = 26,
                    NewsId = 26,
                    TopicId = 2
                }
            );

            modelBuilder.Entity<Topic>().HasData(
                new Topic
                {
                    Id = 1,
                    Name = "News"
                },
                new Topic
                {
                    Id = 2,
                    Name = "politicsNews"
                }
            );
        }
    }
}