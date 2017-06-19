Luke Fieldsend

Run:
Load in visual studio, select GSAHUB as startup project
	Select GSAHUB as run option not IISEXPRESS
	
	Runs on localHost:8000
		http://localhost:8000/api/monthly-capital/?strategies=Strategy1,Strategy2
		http://localhost:8000/api/cumulative-pnl/?startDate=2011-08-23
		http://localhost:8000/api/compound-daily-returns/strategy1

	
	Data:
	Data can be viewed in localdb via sql object browser in visualStudio after project initialy bootstraps
		Server=(localdb)
		mssqllocaldb
		Database=GSA1
	
	Import errorHandling:
	
	CsvHelper is quite recilent in building whole objects from from damaged or incorect csv, beyond the data type being unallowable to build the objects from I had trouble getting
	it to through read exceptions. The mechanism I envisioned for this, was upon throwing, the importer, would take the offending row, log it to core logging( to be picked up by an alert system like splunk)
	then to have the row appended to a seperate csv file to be looked at by an engineer or repaired by another service outside the scope of this project, then a reimported once correct
	due to time constraints and trouble invalidating data i have not implemented this fully.
	
	Currently both csvHelpers error callback and the row constructor method log errors but this is an area i think needs further work.
	
	Libraries: 
	CSVHelper - used to parse and transform csv files into logical objects. Abstracts away low level reading of csv,fluent object construction and handles ill formed csv rows
	linq- used for object transformation and entity queries. for scope of project i think it was the most readable and quick to develop approach.
		  On scale project with larger dataSet and demands would have used sql query language in repositories.
	
	TESTING:
	
	included is a small test runner used for tdd only, not a regression harness and does not cover all casses. only suitable while services are read only
	
	
	Archetechures:
	
	For the scope of the project I used a pretty shallow .netcore web api controller archecture to wrap a service layer.
	Having 3 logical groupings very closly linked I didn't believe believe it warrented specialied repositories when it could just be queried on the context.
	
	The Service layer to serve the api function in the spec leant itself to two logical groupings Strategy and Region. 
	All entities are linked by strategy, so a single strategyService could be used but in terms fo services acting of groupings for business logic and not domain entities i thought this was best.
	
	In terms of Api archecture poorly formed or incorrect query paremeters ruturn empty json collections rather then returned exceptions as most of them are filter paremeters
	and the routing system in place is attribute routing to allow for the mixed routing specified in the spec ,e.g dropping the countroler name and the mix of uri paremeters and query string
	
	I chose entity framework for the data because of the speed to bootstrap this limited scope project and the relation between strategy, capital and pnl is modeled nicely through it.
	Depending on further system requirment I might switch to a dapper repository archetechure for performance.
	
	API is not RESTFull due to constraints of spec functions and all calls are GET. 
	
	Assumptions:
	
	Service being up and running is better then complete datasets and can be corrected by other service or in in flight. ONly complete capital,strategy,pnl matches will be considered queriable
	
	duplicates of month are not in the data set but if provided Compound daily returns will agregate amount on month groupings
	
	data entities with such as strategies containing collections of associated pnl and capital will not grow in size further as to not be performant using linq
	
	No Custom api exception contract was required (empty collection and http codes will surfice);
	
	no authentication was required
	
	API is development grade so no need to remove default routing to lock  routing to only that specified in the spec
	
	Correct over incorrect CSV data handled by operations dev upon alert or other running service outside the scope of project
	
	no threaded event sourcing system was required for scope of project
	
	Any further csv partial imports would require further release of system, specifying file
	
	
	
	