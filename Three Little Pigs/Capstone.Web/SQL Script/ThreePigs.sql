Drop Table survey_result;
Drop Table house;

Create Table house
(
	houseCode varchar(20) not null,
	houseName varchar(20) not null,
	houseDescription varchar(500) not null,
	minPrice real not null,
	maxPrice real not null,
	minSquareFeet int not null,
	maxSquareFeet int not null,
	wolfProof bit not null,

	constraint pk_house primary key (houseCode)
);

CREATE TABLE survey_result
(
	surveyId int identity(1,1) not null,
	houseCode varchar(20) not null,
	emailAddress varchar(100) not null,
	state varchar(2) not null,
	wolfDangerLevel varchar(100) not null,
	
	constraint pk_survey_result primary key (surveyId),
	constraint fk_survey_result_park foreign key (houseCode) references house (houseCode)
);

Insert house Values('strawhouse', 'Straw Home', 'A good starter home for rustic settings.
 With a bright and cheery look, this home is perfect for those who love a home that blends
  into the surrounding environment. Provides little to no protection from the big bad wolf 
  but does feature quick construction times.', 5000 , 50000, 500, 1500, 0)
Insert house Values('stickhouse', 'Stick Home', 'A sturdy wood home that will fit into any 
neighborhood. Choose from 6 different wood types and includes the option of a full finished 
basement. Provides some protection from wolves but does not come with the Three Pigs construction 
company Wolfproof guarantee &trade', 25000, 150000, 800, 2000, 0)
Insert house Values('brickhouse', 'Brick Home', 'The ultimate in luxurious living. With a brick 
home you will have the piece of mind that comes with knowing that no wolf could possibly blow
your house down. Many additional amenitites are included such as your very own in-ground pool 
of mud. Please allow a year for construction.', 125000, 1000000, 1000, 5000, 1)

