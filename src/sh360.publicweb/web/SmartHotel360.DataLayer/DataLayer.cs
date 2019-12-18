using System;
using System.Collections.Generic;
using SmartHotel360.DataLayer.Models;
using System.Linq;

namespace SmartHotel360.DataLayer
{
	public class DataLayer
	{
		public List<CityModel> cities { get; set; }
		public List<HotelModel> hotels { get; set; }
		private List<ServiceModel> availableServices;
		private List<string> _names;
		private List<string> _reviewsList;
		private static List<string> _streets;

		public DataLayer()
		{

			cities = new List<CityModel>();
			hotels = new List<HotelModel>();

			BuildReferences();
			BuildData();
		}

		private void BuildReferences()
		{
			availableServices = new List<ServiceModel>();

			availableServices.Add(new ServiceModel() { id = 1, name = "Free Wi-fi", type = "common" });
			availableServices.Add(new ServiceModel() { id = 2, name = "Parking", type = "common"  });
			availableServices.Add(new ServiceModel() { id = 3, name = "TV", type = "common"  });
			availableServices.Add(new ServiceModel() { id = 4, name = "Air conditioning", type = "common"  });
			availableServices.Add(new ServiceModel() { id = 5, name = "Dryer", type = "common"  });
			availableServices.Add(new ServiceModel() { id = 6, name = "Indoor fireplace", type = "common"  });
			availableServices.Add(new ServiceModel() { id = 8, name = "Breakfast", type = "common"  });
			availableServices.Add(new ServiceModel() { id = 10, name = "Airport shuttle", type = "common"  });
			availableServices.Add(new ServiceModel() { id = 13, name = "Gym", type = "common"  });
			availableServices.Add(new ServiceModel() { id = 15, name = "Restaurant", type = "common"  });
			availableServices.Add(new ServiceModel() { id = 16, name = "Wheelchair accessible", type = "common"  });
			availableServices.Add(new ServiceModel() { id = 17, name = "Elevator", type = "common"  });         
			availableServices.Add(new ServiceModel() { id = 12, name = "Fitness centre", type = "luxury"  });
			availableServices.Add(new ServiceModel() { id = 11, name = "Swimming pool", type = "spa"  });
			availableServices.Add(new ServiceModel() { id = 14, name = "Hot tub", type = "spa"  });
			availableServices.Add(new ServiceModel() { id = 7, name = "Laptop workspace", type = "business"  });
			availableServices.Add(new ServiceModel() { id = 9, name = "Kid friendly", type = "family"  });

			_reviewsList = new List<string> {
                "Excellent hotel. Lobby and restaurant are impressive. Breakfast and dinner are really good. Service is great and one of the best in London. Try also de club downstairs and the Punch Room",
                "The restaurant and bar is wonderful! Lively enough, and excellent for business lunches as well. Try the Ham and Cheese toastie- delicious! We did not care for our room; however, too spartan.",
                "I really like this place with it's clean and tablet-controlled rooms, with a great movie selection (perfect after a long day in the office) and most importantly their always friendly staff...",
                "Hotel located just behind the Tate, with great breakfast spots and Borough Market nearby. Two people stay for the same price as one, so bring a friend. Whom you would share a double bed with.",
                "love this hotel: great bar downstairs, the rooms were a wee bit bigger than the ones at schiphol, and it's right around the corner from the gate modern...will definitely stay here again",
                "Trendy hotel with the best lounge area I've ever seen. Cozy place with comfy beds. Rooms are small but all right. Funny high-tech comfort.",
                "Great concept. Modern without being too clean. Super comfy beds. Samsung tablet which controls everything in your room is more of a gimmick than being a handy tool.",
                "From the moment you step in, you can perfectly understand why this hotel has been short listed for the annual World Architecture Festival Awards...",
                "Unbelievable everything! Mere words can not describe the staff grounds or rooms. The Spa is top notch the decor refined elegant and as beautiful as everyone who works their.",
                "antastic Hotel great service lovely environment upmarket but not pretentious at all superb food rooms are amongst the best I have stayed in. Well recommended folks",
                "Great cocktail bar with live music. Staff are amazing and attentive without being annoying.",
                "Have some work to do? Grab a good Full English and sit on one of their comfortable sofas with your laptop. Great wifi signal and plenty of outlets available.",
                "Brings together the integrity and character of a historic building with a simple, sophisticated design. Boasts 173 rooms, a restaurant, two bars, an event space, meeting rooms and an inviting lobby.",
            };

            _names = new List<string>
        {
            "Sophie Stevenson", "Louisa Lane", "Jim McKenzie", "Micheal Estrada", "Bessie Swanson", "Ray Garner", "Lydia Obrien", "Jacob Powers", "Ryan Dunn", "Alexander Harrington", "Nathaniel Fitzgerald", "Olivia Cohen", "Martin Todd", "Darrell Russell", "Russell Stevenson", "Jason McCoy", "Elijah Rodriquez", "Augusta Meyer", "Hattie Baker", "Joe Fitzgerald", "Christina Gregory", "Elizabeth Lowe", "Tillie Hopkins", "Barry Hawkins", "Dorothy Roberts", "Bradley Ross", "Florence Collins", "Olive Buchanan", "Viola Graham", "Gary Murray", "Mike Porter", "Vera Gilbert", "Harold Roy", "Marcus Watson", "Adelaide Sparks", "Steven Martin", "Pauline Wallace", "Devin Stone", "Roy Marshall", "Curtis Wilkerson", "Callie Gonzalez", "Emma Bryant", "Bertie Russell", "Glenn Manning", "Barbara Reid", "Millie Strickland", "Estella Hammond", "Tommy Nguyen", "Billy Moss", "Nelle Greene", "Helena Hernandez", "Louis Cooper", "Mathilda Yates", "Marcus Hodges", "Lou Bishop", "Randall Dawson", "Edgar Snyder", "Estelle Leonard", "Lizzie Keller", "Elizabeth Guerrero", "Ida Banks", "Herman Tyler", "Mollie Spencer", "Mollie Patterson", "Clifford Munoz", "Edwin Phelps", "Rhoda Powers", "Maurice Munoz", "Marc Lee", "Corey Cobb", "Sally McBride", "Lena Stevens", "Susie Franklin", "Gordon Rhodes", "Elizabeth Douglas", "Sarah Rogers", "Elizabeth Greer", "Jeffrey Diaz", "Mason Fuller", "Ollie Cook", "Lester Grant", "Jeremy Norris", "Alejandro Fowler", "Johanna Castillo", "Isaac Burke", "Lucile Kelley", "Ethel Armstrong", "Curtis Watts", "Olivia Chapman", "Ora Casey", "Iva Rhodes", "Vincent Wilkerson", "Johanna Dunn", "Eleanor Hammond", "Arthur Townsend", "Lettie Sandoval", "Susan Gomez", "Trevor Adkins", "Annie Dean", "Eric McGuire", "Dominic Brock", "Gary Hammond", "Bernice Stewart", "Maria Gordon", "Rosa Gonzalez", "Lettie Griffin", "Jessie Burton", "Susie Rodgers", "Jorge Powers", "Charlie Foster", "Owen Gray", "Lettie Dunn", "Dorothy Martinez", "Grace Lane", "Kate Erickson", "Nathaniel Reyes", "Fanny Morton", "Edith Hernandez", "Anne Fowler", "Francis Fox", "Rhoda Schwartz", "Stella Schultz", "Shawn Strickland", "Louis Mullins", "Adeline Collier", "Jim Turner", "Peter Bowers", "Eugene Frank", "Sylvia Wright", "Martha Gregory", "Nettie Morton", "Dorothy Douglas", "Ralph Harvey", "Josephine Collins", "Logan Moreno", "Albert Lindsey", "Jared Cobb", "Christine Oliver", "Troy Osborne", "Loretta Carpenter", "Sue Holmes", "Caroline Allen", "Della Day", "Delia Keller", "Adelaide Yates", "Jorge Schwartz", "Ina Dennis", "Rena Welch", "Marcus Palmer", "Cole Henderson", "Annie Blair", "Don Strickland", "Alfred Tucker", "Ernest Thomas", "Jay Buchanan", "Donald Brock", "Owen Gonzalez", "Ola Singleton", "Lewis Silva", "Ray Owen", "Corey Greer", "Leon Harrington", "Lilly Garcia", "Winifred Hale", "Adeline Greene", "Elnora Castro", "Amy Hart", "Eugenia McGee", "Ryan Silva", "Chris May", "Etta Harrison", "Ivan Nguyen", "Aaron Swanson", "Birdie Hill", "Virginia Parks", "James Lawson", "Fred Franklin", "Lillie Goodwin", "Alexander Snyder", "Cora Hines", "Cecelia McDaniel", "Martha Duncan", "Ella Kennedy", "Craig Padilla", "Hannah Black", "Frances Swanson", "Ada Floyd", "Ruth Neal", "Bernice Hawkins", "Fanny Payne", "Christian Floyd", "Clayton Mann", "Amy Berry", "Caroline Carter", "Alvin Lopez", "Jared Swanson", "Seth Spencer", "Dennis Dixon", "Michael Harvey", "Augusta Hansen", "Jay Weaver", "Lela Pittman", "Amanda Steele", "Winnie Wong", "Amanda Atkins", "Marc Vasquez", "Janie Gonzalez", "Lewis Wagner", "Marie Norman", "Charles Anderson", "Lloyd Knight", "Callie Ruiz", "Gertrude Parsons", "Derek Day", "George Sharp", "Russell Salazar", "Matthew Fox", "Ollie Soto", "Jessie Holmes", "Louis Rivera", "Hunter Delgado", "Nellie Cummings", "Chad Jefferson", "Ronnie Barber", "Jayden Brewer", "Timothy Wolfe", "Gordon Terry", "Cole Cohen", "Loretta McKinney", "Joe Mitchell", "Rachel Brown", "Violet Kennedy", "Dustin Garza", "Florence Benson", "Justin Henderson", "Jesse Christensen", "Christopher Johnson", "Charles Lee", "Garrett Campbell", "Andrew Griffith", "Mamie Barker", "Aiden Brock", "Cecilia Estrada", "Hallie Cobb", "Olga Watts", "Nannie Graham", "Louise Day", "Ethel Simmons", "Lester Moss", "Lizzie Collier", "Kyle Long", "Ruth Flowers", "Theresa Lambert", "Roy Blair", "Michael Soto", "William Davis", "Minnie Schultz", "Mitchell Curry", "Martha Jennings", "Sophie Cannon", "Cody Riley", "Lily Weber", "Eunice Goodman", "Howard French", "Chris Saunders", "Raymond Mendez", "Estella Soto", "Jorge Gill", "Luis Wade", "Katie Farmer", "Nelle Patton", "Sylvia Bush", "Olga Glover", "Agnes Tyler", "Herman Fisher", "Miguel Wallace", "Philip Barber", "Jonathan Ortiz", "Fanny Perez", "Sue Fletcher", "Iva Woods", "Leona Hodges", "Michael Ellis", "Emily Rodriguez", "Amy Coleman", "Isabella Sims", "Charlotte Lamb", "Mabel Parsons", "Aiden Harvey", "Annie McCarthy", "Jessie Hunter", "Ellen Fowler", "Billy Foster", "Callie West", "Susan Quinn", "Matilda Gibson", "Leah Garza", "Theresa Hayes", "Lucas Johnston", "Effie Allen", "Luella Mendez", "Sally Walker", "Isabella Schultz", "Sarah Roy", "Kevin Nelson", "Henry Taylor", "Katherine Fuller", "Marie McCormick", "Connor Weber", "Kathryn Cook", "Caroline Hampton", "Harriett Black", "Lawrence Doyle", "Verna Parsons", "Barry Christensen", "Adele Goodman", "Duane Wilson", "Alberta Wilson", "Hettie Davis", "Augusta Gross", "Eva Barton", "Kevin Saunders", "Isabella Russell", "Warren Adams", "Craig Crawford", "Robert Hernandez", "Milton Hampton", "Phoebe Harper", "Jerome Johnston", "Blake Smith", "Lettie Willis", "Ruby Stevenson", "Olga Larson", "Claudia Burns", "Barbara Perez", "Jane Bailey", "David Huff", "Josie Wise", "Leo Lawson", "Christine Yates", "Ida Reynolds", "Stanley Vega", "Mina Estrada", "Stephen Goodman", "Callie Love", "Josie Lynch", "Roy Hale", "Richard Hart", "Ryan Quinn", "Harriett Estrada", "Celia Walsh", "Isabella Bell", "Walter Hubbard", "Alan Garner", "Cornelia Hudson", "Caroline Lambert", "Randall Stephens", "Brandon Castro", "Pearl Evans", "Tommy Joseph", "Jacob French", "Sophia Frank", "Lucile Jennings", "Kenneth Cook", "Bruce Cummings", "Adrian Bishop", "Mildred Reynolds", "Lilly Reyes", "Francis Coleman", "Sarah Becker", "Roger Lowe", "Mitchell Dennis", "Sue Fuller", "Manuel Hardy", "Ann Miles", "Howard Hamilton", "Devin Romero", "Isabelle Harris", "Timothy Fletcher", "Connor Smith", "Virgie Marshall", "Janie Meyer", "Lola Patrick", "Nell Saunders", "Willie Green", "Daisy Stewart", "Stanley Austin", "Lloyd Meyer", "Jacob Jacobs", "Lettie Perry", "Isabella Fleming", "Viola Weber", "Lois Palmer", "Harvey Maldonado", "Effie Doyle", "Kathryn Cummings", "Nell Carlson", "Cornelia Cross", "Leila Carroll", "Sally Fields", "Leah Doyle", "Jane Boyd", "Georgie Copeland", "Eva Massey", "Jacob Schmidt", "Lelia Chandler", "Hilda Mullins", "Adrian Estrada", "Erik Evans", "Susan Medina", "Jeff Cobb", "Katharine Day", "Ricky Sullivan", "Dennis Kennedy", "Lulu Mullins", "Troy Vega", "Hunter Henry", "Ricky Doyle", "David Walton", "Kyle Stanley", "Mayme Dunn", "Timothy Shelton", "Mitchell Cobb", "Randy Watkins", "Delia Hughes", "Nina Terry", "Edna Harrison", "Tom Owen", "Matilda Gardner", "Sylvia Cunningham", "Carrie Torres", "Mattie Hughes", "Sean Adkins", "Glen Marshall", "Devin Austin", "Gertrude Castillo", "Edward Rodgers", "Maurice Norris", "Carrie Garrett", "Eliza Newton", "Alan Lowe", "Leona Benson", "Chester Fletcher", "Isabelle Reed", "Leroy Ramos", "Roger Hawkins", "Maria Elliott", "Albert Glover", "Andre Welch", "Cynthia Simpson", "Julian Lewis", "Charlotte Wise", "Gertrude Stewart", "Sara Rodgers", "Barry Pearson", "Susie Vega", "Randall Bell", "Helen Carr", "Miguel Lindsey", "Jeff Lamb", "Laura Jackson", "Leah Reeves", "Jayden Tyler", "Nancy Ball", "Ralph Garner", "Bruce Henderson", "Walter Burgess", "Isabel Castillo", "Brett Hart", "Gabriel Holt", "Herbert Barton", "Genevieve Miles", "Phillip Hodges", "Oscar Paul", "Della Meyer", "Brian Lindsey", "Jane Pratt", "Micheal Simon", "Ophelia Harmon", "Juan Ball", "Ruth Hicks", "Dale Caldwell", "Frank Summers", "Leroy West", "Mildred Palmer", "Jean Gomez", "Roy Day", "Keith Schneider", "Aiden McKenzie", "Vincent Rowe", "Caroline French", "Eliza Ward", "Jimmy Cortez", "Leon Warner", "Mable McGee", "Christian Johnson", "Millie Summers", "Gabriel Phelps", "Allie Sims", "Ronnie Santiago", "Charles Barnett", "Ryan Jennings", "Linnie Mason", "Eugene Kennedy", "Gene McCarthy", "Nettie Hamilton", "Ora Townsend", "Fred Tran", "Beulah Reid", "Richard Owens", "Rose Francis", "Willie Mason", "Edward May", "Troy Figueroa", "Cecelia Marshall", "Ophelia May", "Lula Hampton", "Leila Hart", "Lenora Collins", "Jackson Walters", "Henry Swanson", "Bernard Park", "Eddie Gonzales", "Mayme Hanson", "Estelle Green", "Amanda Barker", "Olive Rhodes", "Richard Reynolds", "Paul Holt", "Amelia Manning", "Mario Watson", "Walter Dennis", "Jeff West", "Roger Fernandez", "Grace Dean", "Katherine Pearson", "Carrie Reid", "Antonio Ortiz", "Minerva Graves", "Eugene Wilson", "Alice Hubbard", "Russell Shelton", "Mabelle Pierce", "Jon Crawford", "Nina Carpenter", "Austin McGee", "Carl Allen", "Belle Collier", "Lena Norman", "Belle Holt", "Ella Munoz", "Lucinda Lee", "Leah Chavez", "Lilly Gonzales", "Shane Fox", "Mamie Taylor", "Elva Elliott", "Howard King", "Floyd Page", "Edith Cross", "Cameron Murray", "Cora Wright", "Anthony Newman", "Daniel Park", "Sean Holt", "Stephen Green", "Derek Fox", "Rena Erickson", "Alex Matthews", "Cole Carpenter", "Nina Watson", "Maurice Pearson", "Georgia Simon", "Allen Bell", "Charlie Rose", "Violet Burton", "Hannah Stephens", "Iva Patrick", "Pearl Chandler", "Andre Summers", "Leroy Ryan", "Charlotte Scott", "Samuel Lyons", "Phoebe Cox", "Violet Saunders", "Glenn Cannon", "Mabelle Griffin", "Hattie Miller", "Nancy Cruz", "Calvin Martinez", "Gene Hale", "Winnie Mills", "Miguel Hamilton", "Lottie Watkins", "Mitchell Barrett", "Terry Anderson", "Sophia Delgado", "Chase Henry", "Stella Caldwell", "Amanda Garrett", "Mamie Jensen", "Blake Alexander", "Ann Alvarez", "Derrick Greer", "Ann Henderson", "Madge Berry", "Clyde Aguilar", "Myrtie Greene", "Cora Copeland", "Lewis Santiago", "Eleanor Sherman", "Marvin Burton", "Chad Wells", "Janie Pope", "Ruby Rodriguez", "Mitchell Neal", "Elva Brooks", "Barry Burns", "Sally Rice", "Derek Newton", "Evelyn Butler", "Marcus Scott", "Mae Powers", "Rebecca Holmes", "Owen Reed", "Phillip Wade", "Louis Gomez", "Ralph Ruiz", "Mason Robbins", "Dustin Gonzales", "Bobby Hamilton", "Luella Spencer", "Trevor May", "Maud Barker", "Barry Medina", "Effie Atkins", "Jim Porter", "Violet Gill", "Anne Williams", "Alice Webster", "Luke Potter", "Francis Fowler", "Carolyn Murphy", "Bobby Wilson", "Don Bailey", "Lucinda Gilbert", "Teresa Carr", "Jeremy Zimmerman", "Matilda Lynch", "Dora Ingram", "Nathan Carson", "Mabelle Reynolds", "Hallie Parsons", "Eliza Gilbert", "Lillian Ryan", "Charles Dean", "Etta Sparks", "Walter Robbins", "Wayne Joseph", "Inez Stokes", "Ronnie Graham", "Lettie Parker", "Stella Reyes", "Edgar Schwartz", "Micheal McGee", "Cody Jennings", "Lee Watts", "Mattie Jensen", "Garrett Bass", "Gary Little", "Keith Beck", "Viola Robinson", "Alejandro Roberson", "Elizabeth Fletcher", "Milton McGuire", "Belle Gutierrez", "Ida Mack", "Mabelle Bailey", "Roy Harper", "Virgie Gonzales", "Esther Osborne", "Mason Smith", "Rosa Obrien", "Trevor Gonzales", "Ricky Jensen", "Verna Barnett", "Adelaide Poole", "Nicholas Stevenson", "Norman Alvarado", "Johnny Kim", "Timothy Lucas", "Steve Hubbard", "Ella Cortez", "Ricardo Sharp", "Cornelia Wilkerson", "Gregory Murphy", "Dustin Osborne", "Leona Shelton", "Bertie Hughes", "Virgie Beck", "Laura Sparks", "Carrie Griffith", "Ray Burgess", "Sophia Erickson", "Marian Tyler", "Jerry Thompson", "Jorge Byrd", "Hunter Howard", "Mabelle Barker", "Lora Collier", "Stanley Warren", "Viola Ray", "Mario Myers", "Harold French", "Joe Santiago", "Effie Parsons", "Aaron Morton", "Frank Nelson", "Justin Turner", "Don Cobb", "Luis Terry", "Rena Simon", "Isabelle Valdez", "Chad Lane", "Rodney Zimmerman", "Jeanette Ward", "Eddie Evans", "Ronnie Lopez", "Katie Massey", "Willie Wong", "Sean Castillo", "Clayton Castillo", "Lura Kennedy", "Mollie Reynolds", "Callie Drake", "Lizzie Murphy", "Rose Weaver", "Zachary Guzman", "Hettie Love", "Evelyn Manning", "Dollie Welch", "Ellen Parsons", "Derrick Martin", "Lucas McLaughlin", "Eugenia Love", "Jim Bennett", "Lillie Jacobs", "Isabel Benson", "Jon Moran", "Adrian Russell", "Derek Pearson", "Russell Burns", "Mike Berry", "Gabriel Olson", "May Scott", "Emily Hale", "Isabella Lane", "Lloyd Armstrong", "Johnny Welch", "Calvin Gibson", "Louise Paul", "Lula Matthews", "Etta George", "Allen Lamb", "Brian Stone", "Chester Chapman", "Amy Crawford", "Clara Clayton", "Winnie Nash", "Richard Moran", "William Powell", "Lizzie Clarke", "Jacob Benson", "Franklin Fletcher", "May Manning", "Kenneth Snyder", "Harvey Fisher", "Lillie Bennett", "Myrtle Thompson", "Howard Byrd", "Jose Johnston", "Christopher Hunt", "Lula Becker", "Jerry Gilbert", "Austin Hernandez", "Logan Lawrence", "Carl Snyder", "Janie Mann", "Calvin Jefferson", "Leona Stokes", "Shawn Flowers", "Ruby Curtis", "Sam Wilkerson", "Viola Norton", "Melvin Mitchell", "Rosa Fernandez", "Jordan Munoz", "Elva Castillo", "Gary Ramsey", "Ricky Carlson", "Philip Jensen", "Juan Rodgers", "Jordan Holloway", "Ina Ortega", "Christian Peterson", "Winnie Cox", "Georgia Freeman", "Elnora Becker", "Bernard Lee", "Margaret Maxwell", "Russell Chambers", "Winifred Chapman", "Douglas Warren", "Jason Bowers", "Lina Cunningham", "Dean Swanson", "Rosalie Tyler", "Gary Ingram", "Ollie Farmer", "Nannie Maldonado", "Irene Thornton", "Pauline Swanson", "Amy Singleton", "Alta Robbins", "Emily Freeman", "Blanche Moreno", "Jennie Herrera", "Josephine Kennedy", "Winnie Swanson", "Jorge Richards", "Lela Webb", "Nathaniel Weaver", "Kate Hill", "Evan Norton", "Charlie May", "Ernest Bates", "Steve Waters", "Jayden Brock", "Antonio Ortega", "Jack Hunt", "Augusta Jordan", "Christian Ellis", "Mitchell Alvarez", "Willie Munoz", "Mittie Bell", "Mike Murray", "Henry Sullivan", "Steve Fox", "Lillie Bass", "Johanna Sparks", "Betty Keller", "Noah Houston", "Ida Hughes", "Philip Wilkerson", "Robert Gonzalez", "Alvin Alvarez", "Betty Jordan", "Lena McGuire", "Tyler Houston", "Charlotte Adkins", "Margaret Hall", "Estelle Butler", "Mattie Harrison", "Oscar Taylor", "Olga Boone", "Marie Harris", "Della Howell", "Mario Ball", "Barbara Ramos", "Vernon Alvarez", "Nancy Cole", "Isabel Ballard", "Lenora Moore", "Josephine Ellis", "Robert Parker", "Bertha Davidson", "Lilly Terry", "Abbie McCarthy", "Joshua Davis", "Henrietta Montgomery", "Clara Aguilar", "Harriet Tucker", "Chad Rhodes", "Adelaide Vaughn", "Adam Cruz", "Mary James", "Virgie Page", "Bruce Adams", "Jeremy Flowers", "James Harvey", "Birdie Rios", "Aiden Williams", "Willie Tucker", "Luke Gardner", "Johnny Riley", "Mitchell Davidson", "Minerva Moran", "Linnie Rodriguez", "Carlos Todd", "Edna Hill", "Daisy Carroll", "Minerva Cohen", "Della Sharp", "Anthony Townsend", "Kathryn Phelps", "Ella Atkins", "Clyde Simpson", "Rebecca Logan", "Lela Holland", "Alfred Morris", "Mason Daniel", "Maggie Grant", "Sophia Campbell", "Sam Brooks", "Lily Rodriguez", "Jennie Hubbard", "Leila Ball", "Eugene Davidson", "Walter Aguilar", "Beulah Baldwin", "Charles Aguilar", "Estelle Austin", "Georgie Davis", "Theresa Mullins", "Jerry Cortez", "Evan Mendez", "Annie Chandler", "Rose Patterson", "Noah Simon", "Barry Sharp", "Daisy Williamson", "Melvin Wise", "Herbert Silva", "Oscar Payne", "Lucinda Hogan", "Joe Stanley", "Tyler Wagner", "Susie French", "Eugenia Thomas", "Cynthia Lane", "Billy Nelson", "Alan Lewis", "Elnora Nichols", "Martin Hunt", "Rhoda Lyons", "Phoebe Marshall", "Edward Munoz", "Terry Moreno", "Mollie Schmidt", "Jay Dennis", "Lulu Brown", "Bradley Simpson", "Sallie Owens", "Francis Atkins", "Alexander Cortez", "Hester Pena", "Bradley Anderson", "Harriett Mendez", "Phillip Chavez", "Olive Newman", "Eleanor Jimenez", "Steven Norman", "Grace Leonard", "Birdie Schultz", "Daisy McCarthy", "Cole Black", "Nannie Maxwell", "Ricardo Robertson", "Eva Peters", "Henrietta Arnold", "Rachel McKenzie", "Mina Gardner", "Floyd Silva", "Howard Malone", "Sam Richardson", "Jorge Dunn", "Jack Strickland", "Ruby Curry", "Essie Brady", "Jeffrey Taylor", "Emily Flores", "Bernard Blair", "Lillian Rhodes", "Bertie Gutierrez", "Hettie Watson", "Derrick Patterson", "Harriet Johnson", "Eddie Morgan", "Agnes Ward", "Georgie Jenkins", "Brent Thompson", "Brett McGuire", "Susan Simmons", "Joel Malone", "Jared Lindsey", "Rosalie Francis", "Hannah Day", "Manuel Bradley"
        };

			_streets = new List<string>
        {
            "1127 Eraad Lane",
            "1720 Fogug Boulevard",
            "830 Wapcig View",
            "67 Wuhenu Street",
            "512 Tadta Pass",
            "1399 Hoca Key",
            "1201 Botdip Court",
            "750 Hafek Center",
            "483 Dunzek Road",
            "56 Zinun Trail",
            "655 Zivi Pike",
            "1367 Zicsu Boulevard",
            "1319 Abcus Lane",
            "502 Hulnek Street",
            "1132 Sakohe Boulevard",
            "1208 Bifi Plaza",
            "1966 Vuvwu Glen",
            "681 Fikkep Grove",
            "1916 Pinut Drive",
            "1374 Epoeca Center",
            "1285 Ijapa River",
            "1868 Fonnub Plaza",
            "737 Nabha Turnpike",
            "492 Osise Court",
            "56 Tokpuh Manor",
            "1835 Bobvu Grove",
            "972 Adleb Heights",
            "1593 Notuz Parkway",
            "1560 Nume Grove",
            "998 Humzi Square",
            "281 Ibama Path",
            "841 Wope Point",
            "1128 Jaspi Trail",
            "1047 Depi Parkway",
            "613 Pamic Pike",
            "982 Onhip Ridge",
            "876 Sovep Park",
            "281 Ijiife Turnpike",
            "661 Wafor Circle",
            "91 Raama Grove",
            "1694 Cavele Circle",
            "1260 Efmu Pike",
            "1248 Hazi Extension",
            "1640 Hinfuw Avenue",
            "494 Nigo Parkway",
            "517 Morfe Point",
            "2000 Bedev Road",
            "1988 Jukev River",
            "24 Sofani Parkway",
            "267 Esutid Ridge",
            "84 Juzav Boulevard",
            "1745 Matik Pike",
            "808 Mazob Circle",
            "903 Topobi Lane",
            "1096 Cufow Highway",
            "875 Givad Pike",
            "863 Ufasa Way",
            "588 Dici View",
            "1840 Getev Key",
            "1543 Tezve Way",
            "260 Zeaz Glen",
            "303 Waobi Court",
            "54 Samaj Ridge",
            "1921 Inbu Way",
            "500 Riduca Square",
            "845 Feri Loop",
            "534 Zujoza Drive",
            "23 Vazse Grove",
            "1491 Tino Key",
            "1508 Hepik Junction",
            "1919 Bijse Key",
            "1231 Huko Street",
            "320 Hacer Extension",
            "1335 Najte Mill",
            "1327 Getfeb Heights",
            "912 Dekgi Street",
            "154 Kupso View",
            "1327 Utlom Turnpike",
            "1739 Bagfac Heights",
            "825 Dotfo Park",
            "1394 Oluha Trail",
            "61 Utbol Circle",
            "109 Wijrud Point",
            "1072 Awja Heights",
            "1018 Obevir Extension",
            "10 Gobfil Place",
            "1080 Golac River",
            "1182 Pevtak Pike",
            "1138 Uzpu Road",
            "1076 Viero Key",
            "1468 Jifab Key",
            "1662 Vuhcen View",
            "941 Osotu Junction",
            "1171 Magika Trail",
            "1491 Okosun Road",
            "530 Vakep Path",
            "1447 Suco Trail",
            "1358 Ikeku Circle",
            "1810 Gejah Extension",
            "678 Apecuc Heights",
            "1869 Mavuga Trail",
            "882 Emevo Key",
            "562 Mokice View",
            "385 Akuehe Trail",
            "732 Wufi Drive",
            "439 Koplim Street",
            "1449 Majcu View",
            "1646 Oriro Loop",
            "378 Bihdu Highway",
            "501 Ucgaj Turnpike",
        };
		}

		private void BuildData()
		{

			#region Cities
			cities.Add(new CityModel
			{
				id = 1,
				name = "Seattle",
				country = "United States"
			});

			cities.Add(new CityModel
			{
				id = 2,
				name = "Seville",
				country = "Spain"
			});

			cities.Add(new CityModel
			{
				id = 10,
				name = "New York",
				country = "United States"
			});

			cities.Add(new CityModel
			{
				id = 11,
				name = "New Orleans",
				country = "United States"
			});

			cities.Add(new CityModel
			{
				id = 12,
				name = "Newark",
				country = "United States"
			});

			cities.Add(new CityModel
			{
				id = 13,
				name = "New Haven",
				country = "United States"
			});


			cities.Add(new CityModel
			{
				id = 20,
				name = "Barcelona",
				country = "Spain"
			});

			cities.Add(new CityModel
			{
				id = 21,
				name = "Barrie",
				country = "Canada"
			});

			cities.Add(new CityModel
			{
				id = 22,
				name = "Bari",
				country = "Italy"
			});

			cities.Add(new CityModel
			{
				id = 30,
				name = "Rome",
				country = "Italy"
			});

			cities.Add(new CityModel
			{
				id = 31,
				name = "Rockford",
				country = "United States"
			});


			cities.Add(new CityModel
			{
				id = 40,
				name = "Westminster",
				country = "United States"
			});

			cities.Add(new CityModel
			{
				id = 41,
				name = "West Covina",
				country = "United States"
			});

			cities.Add(new CityModel
			{
				id = 42,
				name = "Welligton",
				country = "New Zealand"
			});
			#endregion

			#region Seattle Hotel
			hotels.Add(new HotelModel()
			{
				id = 1,
				city = "Seattle, United States",
				cityId = 1,
				name = "Sh360 Platinum Seattle",
				numPhotos = 1,
				picture = "pichotels/10_1.png",
				price = 300,
				rating = 4,
				checkInTime = "13:00:00",
				checkOutTime = "12:00:00",
				defaultPicture = "pichotels/20_default.png",
				description = "",
				latitude = "",
				longitude = "",
				pricePerNight = 300,
				street = ""            
			});

			hotels.Add(new HotelModel()
			{
				id = 2,
                city = "Seattle, United States",
				cityId = 1,
				name = "Sh360 Spa Seattle",
				numPhotos = 1,
				picture = "pichotels/11_1.png",
				price = 280,
				rating = 5,
				checkInTime = "13:00:00",
				checkOutTime = "12:00:00",
				defaultPicture = "pichotels/20_default.png",
				description = "",
				latitude = "",
				longitude = "",
				pricePerNight = 280,
				street = ""
			});

			hotels.Add(new HotelModel()
			{
				id = 3,
                city = "Seattle, United States",
				cityId = 1,
				name = "Sh360 Business Seattle",
				numPhotos = 1,
				picture = "pichotels/12_1.png",
				price = 250,
				rating = 4,
				checkInTime = "13:00:00",
				checkOutTime = "12:00:00",
				defaultPicture = "pichotels/20_default.png",
				description = "",
				latitude = "",
				longitude = "",
				pricePerNight = 250,
				street = ""
			});

			hotels.Add(new HotelModel()
			{
				id = 4,
                city = "Seattle, United States",
				cityId = 1,
				name = "Sh360 Family Seattle",
				numPhotos = 1,
				picture = "pichotels/13_1.png",
				price = 210,
				rating = 4,
				checkInTime = "13:00:00",
				checkOutTime = "12:00:00",
				defaultPicture = "pichotels/20_default.png",
				description = "",
				latitude = "",
				longitude = "",
				pricePerNight = 210,
				street = ""
			});

			hotels.Add(new HotelModel()
			{
				id = 5,
                city = "Seattle, United States",
				cityId = 1,
				name = "Sh360 Economy Seattle",
				numPhotos = 1,
				picture = "pichotels/14_1.png",
				price = 180,
				rating = 5,
				checkInTime = "13:00:00",
				checkOutTime = "12:00:00",
				defaultPicture = "pichotels/20_default.png",
				description = "",
				latitude = "",
				longitude = "",
				pricePerNight = 180,
				street = ""
			});
			#endregion

			#region Seville Hotel
            hotels.Add(new HotelModel()
            {
				id = 6,
                city = "Seville, United States",
                cityId = 2,
				name = "Sh360 Platinum Seville",
                numPhotos = 1,
				picture = "pichotels/15_1.png",
                price = 300,
                rating = 3,
                checkInTime = "13:00:00",
                checkOutTime = "12:00:00",
                defaultPicture = "pichotels/20_default.png",
                description = "",
                latitude = "",
                longitude = "",
                pricePerNight = 300,
                street = ""
            });

            hotels.Add(new HotelModel()
            {
				id = 7,
                city = "Seville, United States",
                cityId = 2,
				name = "Sh360 Spa Seville",
                numPhotos = 1,
				picture = "pichotels/16_1.png",
                price = 280,
                rating = 5,
                checkInTime = "13:00:00",
                checkOutTime = "12:00:00",
                defaultPicture = "pichotels/20_default.png",
                description = "",
                latitude = "",
                longitude = "",
                pricePerNight = 280,
                street = ""
            });

            hotels.Add(new HotelModel()
            {
				id = 8,
                city = "Seville, United States",
                cityId = 2,
				name = "Sh360 Business Seville",
                numPhotos = 1,
				picture = "pichotels/17_1.png",
                price = 250,
                rating = 4,
                checkInTime = "13:00:00",
                checkOutTime = "12:00:00",
                defaultPicture = "pichotels/20_default.png",
                description = "",
                latitude = "",
                longitude = "",
                pricePerNight = 250,
                street = ""
            });

            hotels.Add(new HotelModel()
            {
				id = 9,
                city = "Seville, United States",
                cityId = 2,
				name = "Sh360 Family Seville",
                numPhotos = 1,
				picture = "pichotels/18_1.png",
                price = 210,
                rating = 5,
                checkInTime = "13:00:00",
                checkOutTime = "12:00:00",
                defaultPicture = "pichotels/20_default.png",
                description = "",
                latitude = "",
                longitude = "",
                pricePerNight = 210,
                street = ""
            });

            hotels.Add(new HotelModel()
            {
				id = 10,
                city = "Seville, United States",
                cityId = 1,
				name = "Sh360 Economy Seville",
                numPhotos = 1,
				picture = "pichotels/19_1.png",
                price = 180,
                rating = 4,
                checkInTime = "13:00:00",
                checkOutTime = "12:00:00",
                defaultPicture = "pichotels/20_default.png",
                description = "",
                latitude = "",
                longitude = "",
                pricePerNight = 180,
                street = ""
            });
            #endregion

			#region New York Hotel
            hotels.Add(new HotelModel()
            {
				id = 11,
                city = "New York, United States",
                cityId = 10,
				name = "Sh360 Platinum New York",
                numPhotos = 1,
				picture = "pichotels/20_1.png",
                price = 300,
                rating = 5,
                checkInTime = "13:00:00",
                checkOutTime = "12:00:00",
				defaultPicture = "pichotels/20_default.png",
                description = "",
                latitude = "",
                longitude = "",
                pricePerNight = 300,
				street = ""
					
            });

			hotels[hotels.Count - 1].pictures.Add("pichotels/20_1.png");

            hotels.Add(new HotelModel()
            {
				id = 12,
                city = "New York, United States",
                cityId = 10,
				name = "Sh360 Spa New York",
                numPhotos = 1,
				picture = "pichotels/21_1.png",
                price = 280,
                rating = 5,
                checkInTime = "13:00:00",
                checkOutTime = "12:00:00",
                defaultPicture = "pichotels/21_default.png",
                description = "",
                latitude = "",
                longitude = "",
                pricePerNight = 280,
                street = ""
            });

			hotels[hotels.Count - 1].pictures.Add("pichotels/21_1.png");

            hotels.Add(new HotelModel()
            {
				id = 13,
                city = "New York, United States",
                cityId = 10,
				name = "Sh360 Business New York",
                numPhotos = 1,
                 picture = "pichotels/28_1.png",
                price = 250,
                rating = 4,
                checkInTime = "13:00:00",
                checkOutTime = "12:00:00",
                defaultPicture = "pichotels/28_default.png",
                description = "",
                latitude = "",
                longitude = "",
                pricePerNight = 250,
                street = ""
            });

			hotels[hotels.Count - 1].pictures.Add("pichotels/28_1.png");

            hotels.Add(new HotelModel()
            {
				id = 14,
                city = "New York, United States",
                cityId = 10,
				name = "Sh360 Family New York",
                numPhotos = 1,
                 picture = "pichotels/23_1.png",
                price = 210,
                rating = 4,
                checkInTime = "13:00:00",
                checkOutTime = "12:00:00",
                defaultPicture = "pichotels/23_default.png",
                description = "",
                latitude = "",
                longitude = "",
                pricePerNight = 210,
                street = ""
            });
			hotels[hotels.Count - 1].pictures.Add("pichotels/23_1.png");

            hotels.Add(new HotelModel()
            {
				id = 15,
                city = "New York, United States",
                cityId = 10,
				name = "Sh360 Economy New York",
                numPhotos = 1,
                 picture = "pichotels/24_1.png",
                price = 180,
                rating = 5,
                checkInTime = "13:00:00",
                checkOutTime = "12:00:00",
                defaultPicture = "pichotels/24_default.png",
                description = "",
                latitude = "",
                longitude = "",
                pricePerNight = 180,
                street = ""
            });
			hotels[hotels.Count - 1].pictures.Add("pichotels/24_1.png");
            #endregion

			#region New Orleans Hotel
            hotels.Add(new HotelModel()
            {
				id = 16,
                city = "New Orleans, United States",
                cityId = 11,
				name = "Sh360 Platinum New Orleans",
                numPhotos = 1,
                 picture = "pichotels/25_1.png",
                price = 300,
                rating = 3,
                checkInTime = "13:00:00",
                checkOutTime = "12:00:00",
                defaultPicture = "pichotels/25_default.png",
                description = "",
                latitude = "",
                longitude = "",
                pricePerNight = 300,
                street = ""
            });
			hotels[hotels.Count - 1].pictures.Add("pichotels/25_1.png");

            hotels.Add(new HotelModel()
            {
				id = 17,
                city = "New Orleans, United States",
                cityId = 11,
				name = "Sh360 Spa New Orleans",
                numPhotos = 1,
                 picture = "pichotels/26_1.png",
                price = 280,
                rating = 5,
                checkInTime = "13:00:00",
                checkOutTime = "12:00:00",
                defaultPicture = "pichotels/26_default.png",
                description = "",
                latitude = "",
                longitude = "",
                pricePerNight = 280,
                street = ""
            });
			hotels[hotels.Count - 1].pictures.Add("pichotels/26_1.png");

            hotels.Add(new HotelModel()
            {
				id = 18,
                city = "New Orleans, United States",
                cityId = 11,
				name = "Sh360 Business New Orleans",
                numPhotos = 1,
                 picture = "pichotels/27_1.png",
                price = 250,
                rating = 3,
                checkInTime = "13:00:00",
                checkOutTime = "12:00:00",
                defaultPicture = "pichotels/27_default.png",
                description = "",
                latitude = "",
                longitude = "",
                pricePerNight = 250,
                street = ""
            });
			hotels[hotels.Count - 1].pictures.Add("pichotels/27_1.png");

            hotels.Add(new HotelModel()
            {
				id = 19,
                city = "New Orleans, United States",
                cityId = 11,
				name = "Sh360 Family New Orleans",
                numPhotos = 1,
                 picture = "pichotels/28_1.png",
                price = 210,
                rating = 5,
                checkInTime = "13:00:00",
                checkOutTime = "12:00:00",
                defaultPicture = "pichotels/28_default.png",
                description = "",
                latitude = "",
                longitude = "",
                pricePerNight = 210,
                street = ""
            });

			hotels[hotels.Count - 1].pictures.Add("pichotels/28_1.png");

            hotels.Add(new HotelModel()
            {
				id = 20,
                city = "New Orleans, United States",
                cityId = 11,
				name = "Sh360 Economy New Orleans",
                numPhotos = 1,
                 picture = "pichotels/29_1.png",
                price = 180,
                rating = 3,
                checkInTime = "13:00:00",
                checkOutTime = "12:00:00",
                defaultPicture = "pichotels/29_default.png",
                description = "",
                latitude = "",
                longitude = "",
                pricePerNight = 180,
                street = ""
            });

			hotels[hotels.Count - 1].pictures.Add("pichotels/29_1.png");
            #endregion


            //21 - 30


			#region Newark Hotel
            hotels.Add(new HotelModel()
            {
				id = 21,
				city = "Newark, United States",
                cityId = 12,
				name = "Sh360 Platinum Newark",
                numPhotos = 1,
                 picture = "pichotels/30_1.png",
                price = 300,
                rating = 5,
                checkInTime = "13:00:00",
                checkOutTime = "12:00:00",
                defaultPicture = "pichotels/30_default.png",
                description = "",
                latitude = "",
                longitude = "",
                pricePerNight = 300,
                street = ""
            });
			hotels[hotels.Count - 1].pictures.Add("pichotels/30_1.png");

            hotels.Add(new HotelModel()
            {
				id = 22,
                city = "Newark, United States",
                cityId = 12,
				name = "Sh360 Spa Newark",
                numPhotos = 1,
                 picture = "pichotels/10_1.png",
                price = 280,
                rating = 5,
                checkInTime = "13:00:00",
                checkOutTime = "12:00:00",
                defaultPicture = "pichotels/10_default.png",
                description = "",
                latitude = "",
                longitude = "",
                pricePerNight = 280,
                street = ""
            });
			hotels[hotels.Count - 1].pictures.Add("pichotels/10_1.png");

            hotels.Add(new HotelModel()
            {
				id = 23,
                city = "Newark, United States",
                cityId = 12,
				name = "Sh360 Business Newark",
                numPhotos = 1,
                 picture = "pichotels/11_1.png",
                price = 250,
                rating = 3,
                checkInTime = "13:00:00",
                checkOutTime = "12:00:00",
                defaultPicture = "pichotels/11_default.png",
                description = "",
                latitude = "",
                longitude = "",
                pricePerNight = 250,
                street = ""
            });
			hotels[hotels.Count - 1].pictures.Add("pichotels/11_1.png");

            hotels.Add(new HotelModel()
            {
				id = 24,
                city = "Newark, United States",
                cityId = 12,
				name = "Sh360 Family Newark",
                numPhotos = 1,
                 picture = "pichotels/12_1.png",
                price = 210,
                rating = 4,
                checkInTime = "13:00:00",
                checkOutTime = "12:00:00",
                defaultPicture = "pichotels/12_default.png",
                description = "",
                latitude = "",
                longitude = "",
                pricePerNight = 210,
                street = ""
            });
			hotels[hotels.Count - 1].pictures.Add("pichotels/12_1.png");

            hotels.Add(new HotelModel()
            {
				id = 25,
                city = "Newark, United States",
                cityId = 12,
				name = "Sh360 Economy Newark",
                numPhotos = 1,
                 picture = "pichotels/13_1.png",
                price = 180,
                rating = 5,
                checkInTime = "13:00:00",
                checkOutTime = "12:00:00",
                defaultPicture = "pichotels/13_default.png",
                description = "",
                latitude = "",
                longitude = "",
                pricePerNight = 180,
                street = ""
            });
			hotels[hotels.Count - 1].pictures.Add("pichotels/13_1.png");
            #endregion

			#region New Haven Hotel
            hotels.Add(new HotelModel()
            {
				id = 26,
				city = "New Haven, United States",
                cityId = 13,
				name = "Sh360 Platinum New Haven",
                numPhotos = 1,
                 picture = "pichotels/14_1.png",
                price = 300,
                rating = 4,
                checkInTime = "13:00:00",
                checkOutTime = "12:00:00",
                defaultPicture = "pichotels/14_default.png",
                description = "",
                latitude = "",
                longitude = "",
                pricePerNight = 300,
                street = ""
            });
			hotels[hotels.Count - 1].pictures.Add("pichotels/14_1.png");

            hotels.Add(new HotelModel()
            {
				id = 27,
                city = "New Haven, United States",
                cityId = 13,
				name = "Sh360 Spa New Haven",
                numPhotos = 1,
                 picture = "pichotels/15_1.png",
                price = 280,
                rating = 5,
                checkInTime = "13:00:00",
                checkOutTime = "12:00:00",
                defaultPicture = "pichotels/15_default.png",
                description = "",
                latitude = "",
                longitude = "",
                pricePerNight = 280,
                street = ""
            });
			hotels[hotels.Count - 1].pictures.Add("pichotels/15_1.png");

            hotels.Add(new HotelModel()
            {
				id = 28,
                city = "New Haven, United States",
                cityId = 13,
				name = "Sh360 Business New Haven",
                numPhotos = 1,
                 picture = "pichotels/16_1.png",
                price = 250,
                rating = 5,
                checkInTime = "13:00:00",
                checkOutTime = "12:00:00",
                defaultPicture = "pichotels/16_default.png",
                description = "",
                latitude = "",
                longitude = "",
                pricePerNight = 250,
                street = ""
            });
			hotels[hotels.Count - 1].pictures.Add("pichotels/16_1.png");

            hotels.Add(new HotelModel()
            {
				id = 29,
                city = "New Haven, United States",
                cityId = 13,
				name = "Sh360 Family New Haven",
                numPhotos = 1,
                 picture = "pichotels/17_1.png",
                price = 210,
                rating = 5,
                checkInTime = "13:00:00",
                checkOutTime = "12:00:00",
                defaultPicture = "pichotels/17_default.png",
                description = "",
                latitude = "",
                longitude = "",
                pricePerNight = 210,
                street = ""
            });
			hotels[hotels.Count - 1].pictures.Add("pichotels/17_1.png");

            hotels.Add(new HotelModel()
            {
				id = 30,
                city = "New Haven, United States",
                cityId = 13,
				name = "Sh360 Economy New Haven",
                numPhotos = 1,
                 picture = "pichotels/18_1.png",
                price = 180,
                rating = 4,
                checkInTime = "13:00:00",
                checkOutTime = "12:00:00",
                defaultPicture = "pichotels/18_default.png",
                description = "",
                latitude = "",
                longitude = "",
                pricePerNight = 180,
                street = ""
            });
			hotels[hotels.Count - 1].pictures.Add("pichotels/18_1.png");
            #endregion

            //31-40

			#region Barcelona Hotel
            hotels.Add(new HotelModel()
            {
				id = 31,
                city = "Barcelona, Spain",
                cityId = 20,
				name = "Sh360 Platinum Barcelona",
                numPhotos = 1,
                 picture = "pichotels/19_1.png",
                price = 300,
                rating = 4,
                checkInTime = "13:00:00",
                checkOutTime = "12:00:00",
                defaultPicture = "pichotels/19_default.png",
                description = "",
                latitude = "",
                longitude = "",
                pricePerNight = 300,
                street = ""
            });
			hotels[hotels.Count - 1].pictures.Add("pichotels/19_1.png");

            hotels.Add(new HotelModel()
            {
				id = 32,
                city = "Barcelona, Spain",
				cityId = 20,
				name = "Sh360 Spa Barcelona",
                numPhotos = 1,
                 picture = "pichotels/20_1.png",
                price = 280,
                rating = 5,
                checkInTime = "13:00:00",
                checkOutTime = "12:00:00",
                defaultPicture = "pichotels/20_default.png",
                description = "",
                latitude = "",
                longitude = "",
                pricePerNight = 280,
                street = ""
            });
			hotels[hotels.Count - 1].pictures.Add("pichotels/20_1.png");

            hotels.Add(new HotelModel()
            {
				id = 33,
                city = "Barcelona, Spain",
				cityId = 20,
				name = "Sh360 Business Barcelona",
                numPhotos = 1,
                 picture = "pichotels/21_1.png",
                price = 250,
                rating = 4,
                checkInTime = "13:00:00",
                checkOutTime = "12:00:00",
                defaultPicture = "pichotels/21_1.png",
                description = "",
                latitude = "",
                longitude = "",
                pricePerNight = 250,
                street = ""
			});
			hotels[hotels.Count - 1].pictures.Add("pichotels/21_1.png");


            hotels.Add(new HotelModel()
            {
				id = 34,
                city = "Barcelona, Spain",
				cityId = 20,
				name = "Sh360 Family Barcelona",
                numPhotos = 1,
                 picture = "pichotels/29_1.png",
                price = 210,
                rating = 5,
                checkInTime = "13:00:00",
                checkOutTime = "12:00:00",
                defaultPicture = "pichotels/29_default.png",
                description = "",
                latitude = "",
                longitude = "",
                pricePerNight = 210,
                street = ""
            });
			hotels[hotels.Count - 1].pictures.Add("pichotels/29_1.png");

            hotels.Add(new HotelModel()
            {
				id = 35,
                city = "Barcelona, Spain",
                cityId = 20,
				name = "Sh360 Economy Barcelona",
                numPhotos = 1,
                 picture = "pichotels/23_1.png",
                price = 180,
                rating = 5,
                checkInTime = "13:00:00",
                checkOutTime = "12:00:00",
                defaultPicture = "pichotels/23_default.png",
                description = "",
                latitude = "",
                longitude = "",
                pricePerNight = 180,
                street = ""
            });
			hotels[hotels.Count - 1].pictures.Add("pichotels/23_1.png");
            #endregion

			#region Barrie Hotel
            hotels.Add(new HotelModel()
            {
				id = 36,
                city = "Barrie, Canada",
				cityId = 21,
				name = "Sh360 Platinum Barrie",
                numPhotos = 1,
                 picture = "pichotels/24_1.png",
                price = 300,
                rating = 5,
                checkInTime = "13:00:00",
                checkOutTime = "12:00:00",
                defaultPicture = "pichotels/24_default.png",
                description = "",
                latitude = "",
                longitude = "",
                pricePerNight = 300,
                street = ""
            });
			hotels[hotels.Count - 1].pictures.Add("pichotels/24_1.png");

            hotels.Add(new HotelModel()
            {
				id = 37,
                city = "Barrie, Canada",
				cityId = 21,
				name = "Sh360 Spa Barrie",
                numPhotos = 1,
                 picture = "pichotels/25_1.png",
                price = 280,
                rating = 3,
                checkInTime = "13:00:00",
                checkOutTime = "12:00:00",
                defaultPicture = "pichotels/25_default.png",
                description = "",
                latitude = "",
                longitude = "",
                pricePerNight = 280,
                street = ""
            });
			hotels[hotels.Count - 1].pictures.Add("pichotels/25_1.png");

            hotels.Add(new HotelModel()
            {
				id = 38,
                city = "Barrie, Canada",
				cityId = 21,
				name = "Sh360 Business Barrie",
                numPhotos = 1,
                 picture = "pichotels/26_1.png",
                price = 250,
                rating = 5,
                checkInTime = "13:00:00",
                checkOutTime = "12:00:00",
                defaultPicture = "pichotels/26_default.png",
                description = "",
                latitude = "",
                longitude = "",
                pricePerNight = 250,
                street = ""
            });
			hotels[hotels.Count - 1].pictures.Add("pichotels/26_1.png");

            hotels.Add(new HotelModel()
            {
				id = 39,
                city = "Barrie, Canada",
				cityId = 21,
				name = "Sh360 Family Barrie",
                numPhotos = 1,
                 picture = "pichotels/27_1.png",
                price = 210,
                rating = 5,
                checkInTime = "13:00:00",
                checkOutTime = "12:00:00",
                defaultPicture = "pichotels/27_default.png",
                description = "",
                latitude = "",
                longitude = "",
                pricePerNight = 210,
                street = ""
            });
			hotels[hotels.Count - 1].pictures.Add("pichotels/27_1.png");

            hotels.Add(new HotelModel()
            {
				id = 40,
                city = "Barrie, Canada",
                cityId = 21,
				name = "Sh360 Economy Barrie",
                numPhotos = 1,
                 picture = "pichotels/28_1.png",
                price = 180,
                rating = 3,
                checkInTime = "13:00:00",
                checkOutTime = "12:00:00",
                defaultPicture = "pichotels/28_default.png",
                description = "",
                latitude = "",
                longitude = "",
                pricePerNight = 180,
                street = ""
            });
			hotels[hotels.Count - 1].pictures.Add("pichotels/28_1.png");
            #endregion

			//41 -50

			#region Bari Hotel
            hotels.Add(new HotelModel()
            {
				id = 41,
                city = "Bari, Italy",
				cityId = 22,
				name = "Sh360 Platinum Bari",
                numPhotos = 1,
                 picture = "pichotels/29_1.png",
                price = 300,
                rating = 4,
                checkInTime = "13:00:00",
                checkOutTime = "12:00:00",
                defaultPicture = "pichotels/29_default.png",
                description = "",
                latitude = "",
                longitude = "",
                pricePerNight = 300,
                street = ""
            });
			hotels[hotels.Count - 1].pictures.Add("pichotels/29_1.png");

            hotels.Add(new HotelModel()
            {
				id = 42,
                city = "Bari, Italy",
				cityId = 22,
				name = "Sh360 Spa Bari",
                numPhotos = 1,
                 picture = "pichotels/30_1.png",
                price = 280,
                rating = 5,
                checkInTime = "13:00:00",
                checkOutTime = "12:00:00",
                defaultPicture = "pichotels/30_default.png",
                description = "",
                latitude = "",
                longitude = "",
                pricePerNight = 280,
                street = ""
            });
			hotels[hotels.Count - 1].pictures.Add("pichotels/30_1.png");

            hotels.Add(new HotelModel()
            {
				id = 43,
                city = "Bari, Italy",
				cityId = 22,
				name = "Sh360 Business Bari",
                numPhotos = 1,
                 picture = "pichotels/10_1.png",
                price = 250,
                rating = 4,
                checkInTime = "13:00:00",
                checkOutTime = "12:00:00",
                defaultPicture = "pichotels/10_default.png",
                description = "",
                latitude = "",
                longitude = "",
                pricePerNight = 250,
                street = ""
            });
			hotels[hotels.Count - 1].pictures.Add("pichotels/10_1.png");

            hotels.Add(new HotelModel()
            {
				id = 44,
                city = "Bari, Italy",
				cityId = 22,
				name = "Sh360 Family Bari",
                numPhotos = 1,
                 picture = "pichotels/11_1.png",
                price = 210,
                rating = 5,
                checkInTime = "13:00:00",
                checkOutTime = "12:00:00",
                defaultPicture = "pichotels/11_default.png",
                description = "",
                latitude = "",
                longitude = "",
                pricePerNight = 210,
                street = ""
            });
			hotels[hotels.Count - 1].pictures.Add("pichotels/11_1.png");

            hotels.Add(new HotelModel()
            {
				id = 45,
                city = "Bari, Italy",
                cityId = 22,
				name = "Sh360 Economy Bari",
                numPhotos = 1,
                 picture = "pichotels/12_1.png",
                price = 180,
                rating = 5,
                checkInTime = "13:00:00",
                checkOutTime = "12:00:00",
                defaultPicture = "pichotels/12_default.png",
                description = "",
                latitude = "",
                longitude = "",
                pricePerNight = 180,
                street = ""
            });
			hotels[hotels.Count - 1].pictures.Add("pichotels/12_1.png");
            #endregion

			#region Rome Hotel
            hotels.Add(new HotelModel()
            {
				id = 46,
                city = "Rome, Italy",
				cityId = 30,
				name = "Sh360 Platinum Rome",
                numPhotos = 1,
                 picture = "pichotels/13_1.png",
                price = 300,
                rating = 5,
                checkInTime = "13:00:00",
                checkOutTime = "12:00:00",
                defaultPicture = "pichotels/13_default.png",
                description = "",
                latitude = "",
                longitude = "",
                pricePerNight = 300,
                street = ""
            });
			hotels[hotels.Count - 1].pictures.Add("pichotels/13_1.png");

            hotels.Add(new HotelModel()
            {
				id = 47,
                city = "Rome, Italy",
				cityId = 30,
				name = "Sh360 Spa Rome",
                numPhotos = 1,
                 picture = "pichotels/14_1.png",
                price = 280,
                rating = 5,
                checkInTime = "13:00:00",
                checkOutTime = "12:00:00",
                defaultPicture = "pichotels/14_default.png",
                description = "",
                latitude = "",
                longitude = "",
                pricePerNight = 280,
                street = ""
            });
			hotels[hotels.Count - 1].pictures.Add("pichotels/14_1.png");

            hotels.Add(new HotelModel()
            {
				id = 48,
                city = "Rome, Italy",
				cityId = 30,
				name = "Sh360 Business Rome",
                numPhotos = 1,
                 picture = "pichotels/15_1.png",
                price = 250,
                rating = 5,
                checkInTime = "13:00:00",
                checkOutTime = "12:00:00",
                defaultPicture = "pichotels/15_default.png",
                description = "",
                latitude = "",
                longitude = "",
                pricePerNight = 250,
                street = ""
            });
			hotels[hotels.Count - 1].pictures.Add("pichotels/15_1.png");

            hotels.Add(new HotelModel()
            {
				id = 49,
                city = "Rome, Italy",
				cityId = 30,
				name = "Sh360 Family Rome",
                numPhotos = 1,
                 picture = "pichotels/16_1.png",
                price = 210,
                rating = 4,
                checkInTime = "13:00:00",
                checkOutTime = "12:00:00",
                defaultPicture = "pichotels/16_default.png",
                description = "",
                latitude = "",
                longitude = "",
                pricePerNight = 210,
                street = ""
            });
			hotels[hotels.Count - 1].pictures.Add("pichotels/16_1.png");

            hotels.Add(new HotelModel()
            {
				id = 50,
                city = "Rome, Italy",
                cityId = 30,
				name = "Sh360 Economy Rome",
                numPhotos = 1,
                 picture = "pichotels/17_1.png",
                price = 180,
                rating = 3,
                checkInTime = "13:00:00",
                checkOutTime = "12:00:00",
                defaultPicture = "pichotels/17_default.png",
                description = "",
                latitude = "",
                longitude = "",
                pricePerNight = 180,
                street = ""
            });
			hotels[hotels.Count - 1].pictures.Add("pichotels/17_1.png");
            #endregion


            //51-60

            #region Rockford Hotel
            hotels.Add(new HotelModel()
            {
				id = 51,
				city = "Rockford, United States",
				cityId = 31,
				name = "Sh360 Platinum Rockford",
                numPhotos = 1,
                 picture = "pichotels/18_1.png",
                price = 300,
                rating = 4,
                checkInTime = "13:00:00",
                checkOutTime = "12:00:00",
                defaultPicture = "pichotels/18_default.png",
                description = "",
                latitude = "",
                longitude = "",
                pricePerNight = 300,
                street = ""
            });
			hotels[hotels.Count - 1].pictures.Add("pichotels/18_1.png");

            hotels.Add(new HotelModel()
            {
				id = 52,
                city = "Rockford, United States",
				cityId = 31,
				name = "Sh360 Spa Rockford",
                numPhotos = 1,
                 picture = "pichotels/19_1.png",
                price = 280,
                rating = 4,
                checkInTime = "13:00:00",
                checkOutTime = "12:00:00",
                defaultPicture = "pichotels/19_default.png",
                description = "",
                latitude = "",
                longitude = "",
                pricePerNight = 280,
                street = ""
			});
			hotels[hotels.Count - 1].pictures.Add("pichotels/19_1.png");

            hotels.Add(new HotelModel()
            {
				id = 53,
                city = "Rockford, United States",
				cityId = 31,
				name = "Sh360 Business Rockford",
                numPhotos = 1,
                 picture = "pichotels/20_1.png",
                price = 250,
                rating = 4,
                checkInTime = "13:00:00",
                checkOutTime = "12:00:00",
                defaultPicture = "pichotels/20_default.png",
                description = "",
                latitude = "",
                longitude = "",
                pricePerNight = 250,
                street = ""
            });
			hotels[hotels.Count - 1].pictures.Add("pichotels/20_1.png");

            hotels.Add(new HotelModel()
            {
				id = 54,
                city = "Rockford, United States",
				cityId = 31,
				name = "Sh360 Family Rockford",
                numPhotos = 1,
                 picture = "pichotels/21_1.png",
                price = 210,
                rating = 4,
                checkInTime = "13:00:00",
                checkOutTime = "12:00:00",
                defaultPicture = "pichotels/21_1.png",
                description = "",
                latitude = "",
                longitude = "",
                pricePerNight = 210,
                street = ""
            });
			hotels[hotels.Count - 1].pictures.Add("pichotels/29_1.png");

            hotels.Add(new HotelModel()
            {
				id = 55,
                city = "Rockford, United States",
                cityId = 31,
				name = "Sh360 Economy Rockford",
                numPhotos = 1,
                 picture = "pichotels/29_1.png",
                price = 180,
                rating = 4,
                checkInTime = "13:00:00",
                checkOutTime = "12:00:00",
                defaultPicture = "pichotels/29_default.png",
                description = "",
                latitude = "",
                longitude = "",
                pricePerNight = 180,
                street = ""
            });
			hotels[hotels.Count - 1].pictures.Add("pichotels/29_1.png");
            #endregion
            
			#region Westminster Hotel
            hotels.Add(new HotelModel()
            {
				id = 56,
				city = "Westminster, United States",
				cityId = 40,
				name = "Sh360 Platinum Westminster",
                numPhotos = 1,
				picture = "pichotels/23_1.png",
                price = 300,
                rating = 5,
                checkInTime = "13:00:00",
                checkOutTime = "12:00:00",
                defaultPicture = "pichotels/23_default.png",
                description = "",
                latitude = "",
                longitude = "",
                pricePerNight = 300,
                street = ""
            });
			hotels[hotels.Count - 1].pictures.Add("pichotels/23_1.png");

            hotels.Add(new HotelModel()
            {
				id = 57,
                city = "Westminster, United States",
				cityId = 40,
				name = "Sh360 Spa Westminster",
                numPhotos = 1,
				picture = "pichotels/24_1.png",
                price = 280,
                rating = 4,
                checkInTime = "13:00:00",
                checkOutTime = "12:00:00",
                defaultPicture = "pichotels/24_default.png",
                description = "",
                latitude = "",
                longitude = "",
                pricePerNight = 280,
                street = ""
            });
			hotels[hotels.Count - 1].pictures.Add("pichotels/24_1.png");

            hotels.Add(new HotelModel()
            {
				id = 58,
                city = "Westminster, United States",
				cityId = 40,
				name = "Sh360 Business Westminster",
                numPhotos = 1,
				picture = "pichotels/25_1.png",
                price = 250,
                rating = 3,
                checkInTime = "13:00:00",
                checkOutTime = "12:00:00",
                defaultPicture = "pichotels/20_default.png",
                description = "",
                latitude = "",
                longitude = "",
                pricePerNight = 250,
                street = ""
            });
			hotels[hotels.Count - 1].pictures.Add("pichotels/25_1.png");

            hotels.Add(new HotelModel()
            {
				id = 59,
                city = "Westminster, United States",
				cityId = 40,
				name = "Sh360 Family Westminster",
                numPhotos = 1,
				picture = "pichotels/26_1.png",
                price = 210,
                rating = 5,
                checkInTime = "13:00:00",
                checkOutTime = "12:00:00",
                defaultPicture = "pichotels/26_default.png",
                description = "",
                latitude = "",
                longitude = "",
                pricePerNight = 210,
                street = ""
            });
			hotels[hotels.Count - 1].pictures.Add("pichotels/26_1.png");

            hotels.Add(new HotelModel()
            {
				id = 60,
                city = "Westminster, United States",
                cityId = 40,
				name = "Sh360 Economy Westminster",
                numPhotos = 1,
				picture = "pichotels/27_1.png",
                price = 180,
                rating = 5,
                checkInTime = "13:00:00",
                checkOutTime = "12:00:00",
                defaultPicture = "pichotels/27_default.png",
                description = "",
                latitude = "",
                longitude = "",
                pricePerNight = 180,
                street = ""
            });
			hotels[hotels.Count - 1].pictures.Add("pichotels/27_1.png");
            #endregion

			//61-70

			#region West Covina Hotel
            hotels.Add(new HotelModel()
            {
				id = 61,
				city = "West Covina, United States",
                cityId = 41,
				name = "Sh360 Platinum West Covina",
                numPhotos = 1,
                 picture = "pichotels/21_1.png",
                price = 300,
                rating = 5,
                checkInTime = "13:00:00",
                checkOutTime = "12:00:00",
				defaultPicture = "pichotels/28_1.png",
                description = "",
                latitude = "",
                longitude = "",
                pricePerNight = 300,
                street = ""
            });
			hotels[hotels.Count - 1].pictures.Add("pichotels/28_1.png");

            hotels.Add(new HotelModel()
            {
				id = 62,
                city = "West Covina, United States",
				cityId = 41,
				name = "Sh360 Spa West Covina",
                numPhotos = 1,
				picture = "pichotels/29_1.png",
                price = 280,
                rating = 5,
                checkInTime = "13:00:00",
                checkOutTime = "12:00:00",
                defaultPicture = "pichotels/29_default.png",
                description = "",
                latitude = "",
                longitude = "",
                pricePerNight = 280,
                street = ""
            });
			hotels[hotels.Count - 1].pictures.Add("pichotels/29_1.png");

            hotels.Add(new HotelModel()
            {
				id = 63,
                city = "West Covina, United States",
				cityId = 41,
				name = "Sh360 Business West Covina",
                numPhotos = 1,
				picture = "pichotels/30_1.png",
                price = 250,
                rating = 4,
                checkInTime = "13:00:00",
                checkOutTime = "12:00:00",
                defaultPicture = "pichotels/30_default.png",
                description = "",
                latitude = "",
                longitude = "",
                pricePerNight = 250,
                street = ""
            });
			hotels[hotels.Count - 1].pictures.Add("pichotels/30_1.png");

            hotels.Add(new HotelModel()
            {
				id = 64,
                city = "West Covina, United States",
				cityId = 41,
				name = "Sh360 Family West Covina",
                numPhotos = 1,
				picture = "pichotels/10_1.png",
                price = 210,
                rating = 3,
                checkInTime = "13:00:00",
                checkOutTime = "12:00:00",
                defaultPicture = "pichotels/10_default.png",
                description = "",
                latitude = "",
                longitude = "",
                pricePerNight = 210,
                street = ""
            });
			hotels[hotels.Count - 1].pictures.Add("pichotels/10_1.png");

            hotels.Add(new HotelModel()
            {
				id = 65,
                city = "West Covina, United States",
				cityId = 41,
				name = "Sh360 Economy West Covina",
                numPhotos = 1,
				picture = "pichotels/11_1.png",
                price = 180,
                rating = 3,
                checkInTime = "13:00:00",
                checkOutTime = "12:00:00",
                defaultPicture = "pichotels/11_default.png",
                description = "",
                latitude = "",
                longitude = "",
                pricePerNight = 180,
                street = "" 
            });
			hotels[hotels.Count - 1].pictures.Add("pichotels/11_1.png");
            #endregion

            #region Welligton Hotel
            hotels.Add(new HotelModel()
            {
				id = 66,
				city = "Welligton, New Zealand",
				cityId = 42,
				name = "Sh360 Platinum Welligton",
                numPhotos = 1,
				picture = "pichotels/12_1.png",
                price = 300,
                rating = 5,
                checkInTime = "13:00:00",
                checkOutTime = "12:00:00",
                defaultPicture = "pichotels/12_default.png",
                description = "",
                latitude = "",
                longitude = "",
                pricePerNight = 300,
                street = ""
            });
			hotels[hotels.Count - 1].pictures.Add("pichotels/12_1.png");

            hotels.Add(new HotelModel()
            {
				id = 67,
                city = "Welligton, New Zealand",
				cityId = 42,
				name = "Sh360 Spa Welligton",
                numPhotos = 1,
				picture = "pichotels/13_1.png",
                price = 280,
                rating = 4,
                checkInTime = "13:00:00",
                checkOutTime = "12:00:00",
                defaultPicture = "pichotels/13_default.png",
                description = "",
                latitude = "",
                longitude = "",
                pricePerNight = 280,
                street = ""
            });
			hotels[hotels.Count - 1].pictures.Add("pichotels/13_1.png");

            hotels.Add(new HotelModel()
            {
				id = 68,
                city = "Welligton, New Zealand",
				cityId = 42,
				name = "Sh360 Business Welligton",
                numPhotos = 1,
				picture = "pichotels/14_1.png",
                price = 250,
                rating = 4,
                checkInTime = "13:00:00",
                checkOutTime = "12:00:00",
                defaultPicture = "pichotels/14_default.png",
                description = "",
                latitude = "",
                longitude = "",
                pricePerNight = 250,
                street = ""
            });
			hotels[hotels.Count - 1].pictures.Add("pichotels/14_1.png");

            hotels.Add(new HotelModel()
            {
				id = 69,
                city = "Welligton, New Zealand",
				cityId = 42,
				name = "Sh360 Family Welligton",
                numPhotos = 1,
				picture = "pichotels/15_1.png",
                price = 210,
                rating = 3,
                checkInTime = "13:00:00",
                checkOutTime = "12:00:00",
                defaultPicture = "pichotels/15_default.png",
                description = "",
                latitude = "",
                longitude = "",
                pricePerNight = 210,
                street = ""
            });
			hotels[hotels.Count - 1].pictures.Add("pichotels/15_1.png");

            hotels.Add(new HotelModel()
            {
				id = 70,
                city = "Welligton, New Zealand",
                cityId = 42,
				name = "Sh360 Economy Welligton",
                numPhotos = 1,
				picture = "pichotels/16_1.png",
                price = 180,
                rating = 5,
                checkInTime = "13:00:00",
                checkOutTime = "12:00:00",
                defaultPicture = "pichotels/16_default.png",
                description = "",
                latitude = "",
                longitude = "",
                pricePerNight = 180,
                street = ""
            });
			hotels[hotels.Count - 1].pictures.Add("pichotels/16_1.png");
			#endregion

			foreach (var t in hotels)
			{
				t.rooms.Add(new RoomModel()
				{
					badgeSymbol = "$",
					discountApplied = 0,
					localOriginalRoomPrice = t.price,
					localRoomPrice = t.price,
					roomName = "Deluxe",
					roomId = t.id,
					roomPrice = t.price
				});

				t.street = _streets[hotels.IndexOf(t)];

				if (t.name.Contains("Platinum"))
				{
					t.services = availableServices.Where(x => x.type == "luxury" || x.type == "common").ToList();
				}
				else if (t.name.Contains("family"))
				{
					t.services = availableServices.Where(x => x.type == "family" || x.type == "common").ToList();
				}
				else if (t.name.Contains("business"))
                {
                    t.services = availableServices.Where(x => x.type == "business" || x.type == "common").ToList();
                }
				else if (t.name.Contains("spa"))
                {
                    t.services = availableServices.Where(x => x.type == "spa" || x.type == "common").ToList();
				}
				else 
                {
                    t.services = availableServices.Where(x => x.type == "common").ToList();
                }

				t.description = "Is a " + t.rating + "-Star luxury hotel located in " + t.city + ". It has quality rooms and a modern, well equipped conference area which can host events of every kind for up to 100 persons. Its an ideal stopover on your journey. Is set in the heart of the lush is perfect for holiday or business. If you just wish to relax there are many walks, cycle rides or car excursions to local quaint and historical villages and towns in picturesque surroundings. If you don't feel like outdoor exercise you can relax either in our Finnish sauna, bio sauna, infrared sauna, jacuzzi. Or, if your feeling up to it, why not work out gently in the gym. After a relaxing dinner and a quiet drink in our Bistro bar sleep should be no problem in one of our cosy and comfortable rooms. Our young and friendly staff are here to welcome and serve you. Hope to see you soon!";
			}
		}


		public List<ReviewModel> GenerateReviews()
        {
			List<ReviewModel> reviews = new List<ReviewModel>();
			Random rand = new Random();
            

			for (var count = 0; count < 10; count++) {
				ReviewModel review = new ReviewModel();
                
				review.user = _names[rand.Next(0, (_names.Count - 1))];
				review.message = _reviewsList[rand.Next(0, (_reviewsList.Count - 1))];
				review.room = (rand.Next(1,10) % 2 == 1) ? "Single" : "Double";
				review.date = DateTime.Now.AddDays(rand.Next(-30, -1));
				review.rating = rand.Next(3, 5);

				reviews.Add(review);
			}

			return reviews.OrderByDescending(x => x.date).ToList();
        }
        
	}


}
