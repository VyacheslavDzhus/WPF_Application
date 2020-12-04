USE master;
IF DB_ID('GameStore') IS NOT NULL
      DROP DATABASE GameStore;
CREATE DATABASE GameStore collate Ukrainian_CI_AS;

GO
USE GameStore ;
IF OBJECT_ID('Manufacturer', 'U') IS NOT NULL
   DROP TABLE Manufacturer;
CREATE TABLE dbo.Manufacturer
(
   ManufacturerId int not null IDENTITY(1,1) primary key,
   ManufacturerName NVARCHAR(20) NOT NULL
);
GO

SET IDENTITY_INSERT dbo.Manufacturer ON;

INSERT INTO dbo.Manufacturer (ManufacturerId, ManufacturerName) 

VALUES 
     (1, 'Rockstar Games'),
	 (2, 'ID Software'),
	 (3, 'CD Projekt RED'),
	 (4, 'Bethesda Softworks'),
	 (5, 'Electronic Arts'),
	 (6, 'Dontnod Etertainment'),
	 (7, 'Valve'),
	 (8, 'Facepunch Studios'),
	 (9, 'Mojang'),
	 (10, 'Overkill Software'),
	 (11, 'WB Games'),
	 (12, 'Devolver Digital'),
	 (13, 'Ubisoft'),
	 (14, '2K Czech'),
	 (15, 'GSG Game World'),
	 (16, 'Activision');
SET IDENTITY_INSERT dbo.Manufacturer OFF;

IF OBJECT_ID('Category', 'U') IS NOT NULL
   DROP TABLE Category;
CREATE TABLE dbo.Category
(
   CategoryId int not null IDENTITY(1,1) primary key,
   CategoryName NVARCHAR(20) NOT NULL
);
GO

SET IDENTITY_INSERT dbo.Category ON;

INSERT INTO dbo.Category (CategoryId, CategoryName) 
VALUES 
     (1, 'Shooter'),
	 (2, 'Advanture'),
	 (3, 'Action'),
	 (4, 'Racing'),
	 (5, 'RPG'),
	 (6, 'Simulator'),
	 (7, 'Puzzle'),
	 (8, 'Fighting');
SET IDENTITY_INSERT dbo.Category OFF;


IF OBJECT_ID('Game', 'U') IS NOT NULL
   DROP TABLE Game;
CREATE TABLE dbo.Game
(
   GameId int not null IDENTITY(1,1) primary key,
   GameName VARCHAR(100) NOT NULL,
   ManufacturerId int foreign key REFERENCES dbo.Manufacturer(ManufacturerId), 
   CategoryId int foreign key REFERENCES dbo.Category(CategoryId), 
   Price float not null default 0,
   [Description] TEXT not null,
   Popularity float not null,
   ReleaseDate VARCHAR(10) not null,
   ImagePath VARCHAR(100) NOT NULL
);
GO
SET IDENTITY_INSERT dbo.Game ON;

INSERT INTO dbo.Game (GameId, GameName, ManufacturerId, CategoryId, Price, [Description], Popularity,ReleaseDate,ImagePath) 
VALUES 
		(1, 'Grand Theft Auto V', 1 , 3 , 20 ,'When a young street hustler, a retired bank robber and a terrifying psychopath find themselves entangled with some of the most frightening and deranged elements of the criminal underworld, the U.S. government and the entertainment industry, they must pull off a series of dangerous heists to survive in a ruthless city in which they can trust nobody, least of all each other. ',8.8,'14.04.2015','/images/gta5.jpg'),
		(2, 'QUAKE II', 2 , 1 , 7 ,'Shortly after landing on an alien surface, you learn that hundreds of your people have been reduced to just a few. Now you must fight your way through the heavily fortified military structures, lower the city`s defenses and stop the enemy`s war machine. Only then will the fate of humanity be known.',10,'11.11.1997','/images/quake2.jpg'),
		(3, 'The Witcher 3: Wild Hunt', 3 , 5 , 19 ,'The Witcher: Wild Hunt is a story-driven open world RPG set in a visually stunning fantasy universe full of meaningful choices and impactful consequences. In The Witcher, you play as professional monster hunter Geralt of Rivia tasked with finding a child of prophecy in a vast open world rich with merchant cities, pirate islands, dangerous mountain passes, and forgotten caverns to explore.',9.4,'19.05.2015','/images/witcher3.jpg'),
		(4, 'Red Dead Redemption 2', 1 , 3 , 32 ,'America, 1899. Arthur Morgan and the Van der Linde gang are outlaws on the run. With federal agents and the best bounty hunters in the nation massing on their heels, the gang must rob, steal and fight their way across the rugged heartland of America in order to survive. As deepening internal divisions threaten to tear the gang apart, Arthur must make a choice between his own ideals and loyalty to the gang who raised him.',9.4,'26.10.2018','/images/rdr2.jpg'),
		(5, 'Cyberpunk 2077', 3 , 5 , 32 ,'Cyberpunk 2077 is an open-world, action-adventure story set in Night City, a megalopolis obsessed with power, glamour and body modification. You play as V, a mercenary outlaw going after a one-of-a-kind implant that is the key to immortality. You can customize your character`s cyberware, skillset and playstyle, and explore a vast city where the choices you make shape the story and the world around you.',9.2,'10.12.2020','/images/cyberpunk2077.jpg'),
		(6, 'The Elder Scrolls V: Skyrim', 4 , 5 , 25 ,'More than 200 years have passed since past events. The war between the Empire and the Thalmor ended with the signing of a humiliating peace treaty. Many rights have been violated, including the right to worship Talos. The empire rejoices and rules in its own way, and a humiliated group of Nords starts a new revolt. The civil war led by Wilfrick ends in success, but Wilfric Petrel himself goes to prison. Few people know what danger threatens the whole world. An ancient evil has awakened, and now all the inhabitants of the Empire are in mortal danger.',9.5,'11.11.2011','/images/skyrim.jpg'),
		(7, 'Need for Speed: Most Wanted', 5 , 4 , 32 ,'The open-world action in Need for Speed Most Wanted gives you the freedom to drive your way. Hit jumps and shortcuts, switch cars, lie low, or head for terrain that plays to your vehicle`s unique strengths. Fight your way past cops and rivals using skill, high-end car tech, and tons of nitrous. It`s all about you, your friends, and a wild selection of cars. Let`s see what you can do.',6.7,'10.03.2012','/images/nfsMostWanted.jpg'),
		(8, 'Life is Strange 2: Episode 1', 6 , 2 , 2 ,'The first episode of Life is Strange 2 tells us about the beginning of the story of Sean Diaz and his younger brother Daniel. Due to tragic circumstances, the brothers were forced to leave their native Seattle. Prepare to face many challenges on the way from Seattle to Mexico as 16-year-old Sean.',9.9,'27.09.2018','/images/lifeisstrange2.jpg'),
		(9, 'Portal 2', 7 , 7 , 6 ,'Portal 2 is a first-person puzzle computer game, a sequel to Portal (2007), developed by Valve Corporation. The sequel develops the gameplay of the first game, consisting of puzzles, built on the use of a special device to create portals , allowing the player to instantly move from one place to another.',7.9,'19.04.2011','/images/portal2.jpg'),
		(10, 'Grand Theft Auto Vice City', 1 , 3 , 5 ,'Welcome to the 1980s. From the decade of big hair, excess and pastel suits comes a story of one man`s rise to the top of the criminal pile. Vice City, a huge urban sprawl ranging from the beach to the swamps and the glitz to the ghetto, was one of the most varied, complete and alive digital cities ever created. Combining open-world gameplay with a character driven narrative, you arrive in a town brimming with delights and degradation and given the opportunity to take it over as you choose.',9.8,'12.05.2003','/images/gtaViceCity.jpg'),
		(11, 'The Sims 4', 5 , 6 , 42 ,'A life simulation game that will let you play with life like never before. Create and control new characters - their bodies, minds and hearts. Build unique homes. Guide and explore the lives of your characters for an unforgettable and amazing experience.',5.8,'09.04.2014','/images/sims4.jpg'),
		(12, 'RUST', 8 , 3 , 17 ,'The only aim in Rust is to survive. To do this you will need to overcome struggles such as hunger, thirst and cold. Build a fire. Build a shelter. Kill animals for meat. Protect yourself from other players, and kill them for meat. Create alliances with other players and form a town. Do whatever it takes to survive.',8.2,'02.08.2018','/images/rust.jpg'),
		(13, 'Minecraft', 9 , 6 , 25 ,'Minecraft is a sandbox arcade building game created by Markus Persson. In Creative mode, the game allows you to create and destroy various types of blocks in a three-dimensional environment, thus creating any kind of structure.',8.4,'18.11.2011','/images/minecraft.jpg'),
		(14, 'Fallout 4', 4 , 3 , 27 ,'As the sole survivor of Vault 111, you enter a world destroyed by nuclear war. Every second is a fight for survival, and every choice is yours. Only you can rebuild and determine the fate of the Wasteland. Welcome home.',8.7,'31.12.2015','/images/fallout4.jpg'),
		(15, 'Grand Theft Auto San Andreas', 1 , 3 , 5 ,'Five years ago Carl Johnson escaped from the pressures of life in Los Santos, San Andreas... a city tearing itself apart with gang trouble, drugs and corruption. Where filmstars and millionaires do their best to avoid the dealers and gangbangers. Now, it`s the early 90s. Carl`s got to go home. His mother has been murdered, his family has fallen apart and his childhood friends are all heading towards disaster. On his return to the neighborhood, a couple of corrupt cops frame him for homicide. CJ is forced on a journey that takes him across the entire state of San Andreas, to save his family and to take control of the streets.',8.5,'06.06.2005','/images/gtaSanAdreas.jpg'),
		(16, 'PayDay 2', 10 , 1 , 6 ,'PAYDAY 2 is an action-packed, four-player co-op shooter that once again lets gamers don the masks of the original PAYDAY crew - Dallas, Hoxton, Wolf and Chains - as they descend on Washington DC for an epic crime spree.',9.2,'16.08.2013','/images/payday2.jpg'),
		(17, 'Mortal Kombat X', 11 , 8 , 10 ,'For the first time in the history of the Mortal Kombat X series, it gives players the opportunity to choose between several variations of the same fighter, each with its own unique fighting style. Immerse yourself in the original story, in which you will encounter both characters from the series like Scorpion and Sub-Zero, and new fighters who personify the forces of good and evil.',9.3,'14.04.2015','/images/mortalcombatX.jpg'),
		(18, 'Mad Max', 11 , 3 , 10 ,'The plot tells the story of Mad Max, a dangerous man who can defeat almost anyone in hand-to-hand combat. Max and his partner Chumbucket must traverse the sun-scorched wasteland in search of Max`s lost car known as the Pursuit Special.',8.8,'01.09.2015','/images/madmax.jpg'),
		(19, 'Serious Sam 3: BFE', 12 , 3 , 17 ,'Events in Serious Sam 3 years during the last battle of the Earth against the legions of alien beasts and mercenaries of Mental. Set against the crumbling temples of ancient civilization and the crumbling cities of Egypt in the 22nd century, Serious Sam 3 combines the classic non-stop shooter with modern gameplay features.',9.2,'12.11.2011','/images/sam3.jpg'),
		(20, 'Far Cry 4', 13 , 3 , 16 ,'Hidden in the towering Himalayas lies Kyrat, a country steeped in tradition and violence. You are Ajay Ghale. Traveling to Kyrat to fulfill your mother`s dying wish, you find yourself caught up in a civil war to overthrow the oppressive regime of dictator Pagan Min. Explore and navigate this vast open world, where danger and unpredictability lurk around every corner. Here, every decision counts, and every second is a story. Welcome to Kyrat.',9.1,'20.11.2014','/images/farcry4.jpg'),
		(21, 'Prince of Persia: The Sands of Time', 13 , 3 , 5 ,'Amidst the scorched sands of ancient Persia, there is a legend spun in an ancient tongue. It speaks of a time borne by blood and ruled by deceit. Drawn to the dark powers of a magic dagger, a young Prince is led to unleash a deadly evil upon a beautiful kingdom. Aided by the wiles of a seductive princess and the absolute powers of the Sands of Time, the Prince stages a harrowing quest to reclaim the Palace`s cursed chambers and restore peace to his land.',8.5,'02.11.2003','/images/princeofperciaSand.jpg'),
		(22, 'Assassin`s Creed IV: Black Flag', 13 , 3 , 10 ,'The year is 1715. Pirates rule the Caribbean and have established their own lawless Republic where corruption, greediness and cruelty are commonplace. Among these outlaws is a brash young captain named Edward Kenway. His fight for glory has earned him the respect of legends like Blackbeard, but also drawn him into the ancient war between Assassins and Templars, a war that may destroy everything the pirates have built. Welcome to the Golden Age of Piracy.',9.3,'19.11.2013','/images/assassinBlackFlag.jpg'),
		(23, 'Mafia II', 14 , 2 , 19 ,'Vito Scaletta has started to make a name for himself on the streets of Empire Bay as someone who can be trusted to get a job done. Together with his buddy Joe, he is working to prove himself to the Mafia, quickly escalating up the family ladder with crimes of larger reward, status and consequence� the life as a wise guy isn�t quite as untouchable as it seems.',9.1,'27.08.2010','/images/mafia2.jpg'),
		(24, 'STALKER: Shadow of Chernobyl', 15 , 5 , 9 ,'In 1986, the world`s worst nuclear disaster occurred at the Chernobyl Nuclear Power Plant. Soviet authorities established an �Exclusion Zone� around, but a second explosion hit the reactor in 2006, creating The Zone as we know it � dangerous place, filled with mutated creatures, deadly radiation, and a strange, anomalous energy. The Zone was cordoned off by the military, who would shoot on sight anyone foolish enough to get inside.',9.7,'20.03.2007','/images/stalkerShadow.jpg'),
		(25, 'The Amazing Spider-Man 2', 16 , 3 , 3 ,'The plot of the game is based on the film of the same name, the hero of which fights evil on the streets of his hometown. Through a third-person perspective, Spider-Man uses acrobatic fighting techniques and unique abilities to fight his enemies.',8.2,'29.04.2014','/images/spiderman2.jpg');	
SET IDENTITY_INSERT dbo.Game OFF;
