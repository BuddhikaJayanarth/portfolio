
CREATE TABLE Login (

	Username varchar(20) NOT NULL ,
	Name varchar (30),
	Password char (12),
	Clearancelevel int,
	UserLevel varchar (50),
	CONSTRAINT Log_pk PRIMARY KEY(Username)
	 
)

INSERT INTO Login VALUES('owner','Chariht Indika Gamage','owner1234567',3,'Owner')
INSERT INTO Login VALUES('manager','Saman ','manager12345',2,'Manager')
INSERT INTO Login VALUES('deo','Naditha','deo123456789',1,'DEO')

CREATE TABLE Notification (

	ID INT NOT NULL IDENTITY(1,1),
	Notification VARCHAR(100),
	Category VARCHAR(50),
	Clearancelevel int, 
)

CREATE TABLE Position(

	PositionID INT NOT NULL IDENTITY(1,1) ,
	PosName varchar(20) UNIQUE,
	Salary float,
	OTRate float,
	CONSTRAINT Pos_pk PRIMARY KEY (PositionID) 
)

--INSERT INTO Position VALUES ('Owner',100000,2)
INSERT INTO Position VALUES ('Manager',50000.00,1000.00)
INSERT INTO Position VALUES ('Driver',20000,250)
INSERT INTO Position VALUES ('Machanic',25000,250)
INSERT INTO Position VALUES ('Trainee',10000,200)
INSERT INTO Position VALUES ('Contract Basis',20000,200)
INSERT INTO Position VALUES ('Supervisor',28000,300)
INSERT INTO Position VALUES ('Customer Coordinator',20000,200)

CREATE TABLE Employee
(
	EmployeeID INT NOT NULL IDENTITY(1,1),
	Name varchar(70),
	Address varchar(255),
	Email varchar(50),
	DOB datetime,
	NIC char(10) UNIQUE,
	Home char(10) ,
	Mobile char (10) UNIQUE,
	Sex char(1) ,
	MaritalStatus char (1),
	Position int,
	BasicSalary float,
	PastExperience varchar (500),
	Qualification varchar (500),
	JoinDate datetime,
	
	CONSTRAINT Em_pk PRIMARY KEY (EmployeeID),
	CONSTRAINT Em_fk FOREIGN KEY (Position) References Position (PositionID) ON UPDATE CASCADE
)

INSERT INTO Employee VALUES ('Nipun','Gampaha','nipun@gmail.com','1999-02-28','051234567V','033729729','0712345678','M','M',4,10000,'None','None','2016-08-17')
INSERT INTO Employee VALUES ('Buddhika','Makola','buddhika@gmail.com','2000-04-01','001234567V','033733733','0712345679','M','S',2,100000,'None','None','2016-08-17')
INSERT INTO Employee VALUES ('Tharaka','Abalangoda','tharaka@gmail.com','1989-01-01','891234567V','023733733','0712345689','F','M',5,100,'None','None','2016-08-18')
INSERT INTO Employee VALUES ('Eshan','Dehiwala','eshan@gmail.com','1995-03-08','951234567V','011733733','0772345679','M','S',1,1000000,'None','None','2016-08-15')
INSERT INTO Employee VALUES ('Naditha','Horana','naditha@gmail.com','1994-04-01','941234567V','044733733','0712355679','M','S',3,100000,'None','None','2016-08-17')

INSERT INTO Employee VALUES ('Jake','Gampaha','Jake@gmail.com','1999-02-28','991234567V','033657729','0714565678','M','M',3,10000,'None','None','2016-08-17')
INSERT INTO Employee VALUES ('Fiona','Makola','Fiona@gmail.com','2000-04-01','881234567V','033789733','0778945679','F','S',2,100000,'None','None','2016-08-17')
INSERT INTO Employee VALUES ('Marceline','Abalangoda','Marcy@gmail.com','1989-01-01','771234567V','026893733','0745645689','F','M',3,100,'None','None','2016-08-18')
INSERT INTO Employee VALUES ('Finn','Dehiwala','Finn@gmail.com','1995-03-08','661234567V','011689733','0764545679','M','S',2,1000000,'None','None','2016-08-15')
INSERT INTO Employee VALUES ('Magaret','Horana','Magaret@gmail.com','1994-04-01','551234567V','04479733','0716575679','F','S',3,100000,'None','None','2016-08-17')

INSERT INTO Employee VALUES ('Anushka','Malabe','Anush@gmail.com','1995-04-06','666534567V','017649733','0789645679','F','S',6,1000000,'None','None','2016-08-7')
INSERT INTO Employee VALUES ('Gayantha','Horana','Gayantha@gmail.com','1993-04-01','588654567V','08569733','0786475679','M','S',6,100000,'None','None','2016-08-4')
INSERT INTO Employee VALUES ('Asun','Gampaha','Asun@gmail.com','1999-02-01','778544567V','028343733','0867645689','M','M',6,100,'None','None','2016-08-18')
INSERT INTO Employee VALUES ('Gihan','Dehiwala','Gihan@gmail.com','1996-05-08','668464567V','078389733','0846545679','M','S',6,1000000,'None','None','2016-09-15')
INSERT INTO Employee VALUES ('Sunela','Kaluthara','Gihan@gmail.com','1994-06-01','556894567V','07569733','0867575679','F','M',6,100000,'None','None','2016-08-17')
INSERT INTO Employee VALUES ('Arnald','Seeduwa','Arnal@gmail.com','1993-01-01','731234567V','0864763375','0878425689','M','M',6,100,'None','None','2016-08-15')

INSERT INTO Employee VALUES ('Bimal Manahara','12,Horana','bimal@gmail.com','1978-08-01','786534534V','0114787874','0715454545','M','M',2,20000,'None','None','2016-02-15')
INSERT INTO Employee VALUES ('Sunil Perera','12/7,Balapitiya,Ambalangoda','sunil@gmail.com','1980-03-21', '801245445V',	'0912245789','0775454578','M','M',2,20000,'None','None','2015-02-13')
INSERT INTO Employee VALUES ('Samantha Arawwala','12,Wakwalla,Galle','samantha@gmail.com','1990-02-02','904578788V','0912254787','0763457854','M','S',2,20000,'None','None','2011-03-03' )

CREATE TABLE Leave (
 
	EmployeeID int NOT NULL ,
	StartDate date,
	EndDate date,
	Reason varchar (500),
	LeaveType varchar(10),
	Session char(7),
	Casual float,
	Annual float,
	Medical int,
	Halfday int,
	Other float,
	Duration float,
	ApproveStatus bit,
	CONSTRAINT Le_pk PRIMARY KEY (EmployeeID,StartDate),
	CONSTRAINT Le_fk FOREIGN KEY(EmployeeID) REFERENCES Employee(EmployeeID) ON DELETE CASCADE ON UPDATE CASCADE	
)



CREATE TABLE Allowances (

	AllowanceID INT NOT NULL IDENTITY(1,1) ,
	Name varchar (20) UNIQUE,
	CONSTRAINT All_pk PRIMARY KEY (AllowanceID),

)

INSERT INTO Allowances VALUES  ('Fuel')
INSERT INTO Allowances VALUES  ('Medical')
INSERT INTO Allowances VALUES  ('Transport')
INSERT INTO Allowances VALUES  ('Education')
INSERT INTO Allowances VALUES  ('Accommodation')

CREATE TABLE Promotion (

	EmployeeID int NOT NULL ,
	Date dateTime NOT NULL ,
	Reason varchar (200),
	Old_Position varchar(30),
	New_Position varchar (30),
	Old_Salary float,
	New_Salary float,
	CONSTRAINT Pro_pk PRIMARY KEY (EmployeeID,Date ),
	CONSTRAINT Pro_fk FOREIGN KEY(EmployeeID) REFERENCES Employee(EmployeeID) ON DELETE CASCADE ON UPDATE CASCADE
)



CREATE TABLE OT (
	
	EmployeeID int NOT NULL ,
	Date date,
	No_Of_Hours int,
	CONSTRAINT Ot_pk PRIMARY KEY (EmployeeID,Date),
	CONSTRAINT Ot_fk FOREIGN KEY(EmployeeID) REFERENCES Employee(EmployeeID) ON DELETE CASCADE ON UPDATE CASCADE
	
)

INSERT INTO OT VALUES  (1,'2016-08-25',2)
INSERT INTO OT VALUES  (2,'2016-08-26',2)
INSERT INTO OT VALUES  (3,'2016-08-25',4)
INSERT INTO OT VALUES  (4,'2016-08-24',3)
INSERT INTO OT VALUES  (5,'2016-08-31',1)

CREATE TABLE Position_Allowance(

	PositionID int NOT NULL,
	AllowanceID int NOT NULL,
	Amount float,
	CONSTRAINT PA_pk PRIMARY KEY (PositionID,AllowanceID),
	CONSTRAINT PA_fk FOREIGN KEY (PositionID) REFERENCES Position (PositionID) ON DELETE CASCADE ON UPDATE CASCADE,
	CONSTRAINT PA_fk1 FOREIGN KEY (AllowanceID)  REFERENCES Allowances(AllowanceID) ON DELETE CASCADE ON UPDATE CASCADE
)

INSERT INTO Position_Allowance VALUES  (1,1,1000)
INSERT INTO Position_Allowance VALUES  (1,2,3000)
INSERT INTO Position_Allowance VALUES  (1,3,5000)
INSERT INTO Position_Allowance VALUES  (2,1,6000)
INSERT INTO Position_Allowance VALUES  (3,1,10000)



CREATE TABLE Attendance(
	EmployeeID int NOT NULL,
	Date date NOT NULL,
	timeIn time(0) NOT NULL,
	Late time(0) DEFAULT '00:00:00',
	timeOut time(0) DEFAULT '00:00:00',
	status char(2),

	CONSTRAINT Att_pk PRIMARY KEY (EmployeeID,Date),
	CONSTRAINT Att_fk FOREIGN KEY (EmployeeID) REFERENCES Employee (EmployeeID) ON DELETE CASCADE ON UPDATE CASCADE
	
)


CREATE TABLE Paid_Salary(

	EmployeeID INT,
	Date Date, 
	Salary float,
	ETF float,
	EpfEmployee float,
	EpfEmployer float,
	
	CONSTRAINT Ps_pk PRIMARY KEY (EmployeeID,Date),
	CONSTRAINT Ps_Fk FOREIGN KEY (EmployeeID) REFERENCES Employee (EmployeeID) ON DELETE CASCADE ON UPDATE CASCADE
)

insert  into Paid_Salary values ('1','2016-08-04 ','200000',500,600,1000)
insert  into Paid_Salary values ('2','2016-08-05 ','200000',500,600,1000)
insert  into Paid_Salary values ('3','2016-09-04 ','400000',500,600,1000)
insert  into Paid_Salary values ('4','2016-10-04 ','100000',500,600,1000)
insert  into Paid_Salary values ('5','2016-11-03 ','300000',500,600,1000)


CREATE TABLE EmployeeAdditionalPayments (
	id INT NOT NULL IDENTITY(1,1),
	EmployeeID int NOT NULL,
	Date date NOT NULL,
	Reason VARCHAR(20),
	Amount float,
	
	CONSTRAINT EAP_Pk PRIMARY KEY (id),
	CONSTRAINT EAP_Fk FOREIGN KEY (EmployeeID) REFERENCES Employee (EmployeeID) ON DELETE CASCADE ON UPDATE CASCADE
)


--Customer

CREATE TABLE Customer (

	NIC char(10)NOT NULL,
	Name varchar (50),
	Email varchar (30),
	Address varchar (50),
	Rate int,
	CustomerType varchar (20),
	CONSTRAINT Cus_pk PRIMARY KEY(NIC),
	 
);


insert into Customer values('985645451v','Liyanage T.M.','tharakamadushanki@gmail.com','110,New Kandy Rd,Malabe',0,'Loyalty')
insert into Customer values('788552411v','Shashi D.N.','shashydb@gmail.com','12,Delgoda Rd,Gampaha',0,'Regular')
insert into Customer values('934141328v','Naditha D.D.N.','ddn.harshana@gmail.com','45,Yalagala rd,Horana',0,'Loyalty')
insert into Customer values('923456789v','Pooja T.W','psathsaranee@gmail.com','56,Morakatiya,Pannipitiya',0,'Regular')
insert into Customer values('523456789v','Nipun K.L.','nipun@gmail.com','110/1,wijaya Rd,Gampaha',0,'Loyalty')
insert into Customer values('925679324v','Sahan L.P','sahan@gmail.com','45,dodangoda,Kaluthara',0,'Regular')
insert into Customer values('936591478v','Bimal E.R','bimal@gmail.com','11, gamunu mawatha,Anuradhapura',0,'Loyalty')
insert into Customer values('915482674v','Sajith S.L','sajitha@gmail.com','78,wijerama mawatha,Nugegoda',0,'Loyalty')
insert into Customer values('957816458v','Thulakshi C.M','thulakshi@gmail.com','9,pitipana,pannipitiya',0,'Regular')
insert into Customer values('945873157v','Kaweesha L.m','kaweesha@gmail.com','56,Galle Rd,Galle',0,'Regular')
insert into Customer values('934552621v','Gawesh T.J.','gawesh@gmail.com','NewKandy Rd,Kaduwela',0,'Loyalty')

CREATE TABLE CustomerContact (

	NIC char (10)NOT NULL ,
	ContactNo char (10)NOT NULL ,
	CONSTRAINT CusCon_pk PRIMARY KEY(NIC,ContactNO),
	CONSTRAINT CusCon_fk FOREIGN KEY(NIC) REFERENCES Customer(NIC)ON DELETE CASCADE,
	
);

insert into  CustomerContact values('985645451v','0774787514')
insert into  CustomerContact values('788552411v','0715456521')
insert into  CustomerContact values('934141328v','0769868652')
insert into  CustomerContact values('923456789v','0713224498')
insert into  CustomerContact values('523456789v','0715828580')
insert into  CustomerContact values('925679324v','0774490430')
insert into  CustomerContact values('936591478v','0777546890')
insert into  CustomerContact values('915482674v','0766124588')
insert into  CustomerContact values('957816458v','0718355253')
insert into  CustomerContact values('945873157v','0776464212')
insert into  CustomerContact values('934552621v','0775454545')

CREATE TABLE CustomerLoyalatyCard (

	NIC char (10) ,
	Card_No varchar(50) unique ,
	Card_Points int default 0,
	CardType  varchar (10),
	CONSTRAINT CusLo_pk PRIMARY KEY(NIC),
	CONSTRAINT CusLo_fk FOREIGN KEY(NIC) REFERENCES Customer(NIC)ON DELETE CASCADE,
	
);

insert into CustomerLoyalatyCard values('523456789v','GO523456789',0,'BRONZE')
insert into CustomerLoyalatyCard values('915482674v','GO915482674',0,'SILVER')
insert into CustomerLoyalatyCard values('934141328v','SI934141328',0,'BRONZE')
insert into CustomerLoyalatyCard values('934552621v','SI934552621',0,'BRONZE')
insert into CustomerLoyalatyCard values('936591478v','SI936591478',0,'BRONZE')
insert into CustomerLoyalatyCard values('985645451v','BR985645451',0,'BRONZE')
--insert into CustomerLoyalatyCard values('934552621v','BR934552621',0,'Bronze') duplication of ID

--Inventory

CREATE TABLE Inventory( 

	InventoryID varchar(10)NOT NULL ,
	ProductType varchar(30),
	Make varchar(30),
	Model varchar(30),
	BuyingPrice float,
	SellingPrice float,
	Quantity int,	
	CONSTRAINT Inve_pk PRIMARY KEY(InventoryID),

);

insert into Inventory values('AIRGL1','Air Conditioner','Green Aircon','LSNS1Q',54000,58500,15)
insert into Inventory values('REFAG1','Refregerator','ATCO','GRD35FBG',60000,64800,10)
insert into Inventory values('RADMP1','Radiator','Motor Parts','P001RDFC',55000,60000,15)
insert into Inventory values('BATDG1','Battery Cable','Duralast','GT2234I',1000,1500,15)
insert into Inventory values('STAGS1','Static Condensor','Green Free','SCT1NS',2000,4900, 10)
insert into Inventory values('COMNC1','Compressor ','NLA','COR1ND',5000,6500, 15)
insert into Inventory values('DEFTD1','Defrost Heater','TEEMS','DFH1NS',4000,5300, 15)
insert into Inventory values('RECLR1','Receiver Dryer','Linda','REDEDS',5000,5900, 13)
insert into Inventory values('COMAC1','Compressor','Aluna','COU1NS',5000,6900, 15)
insert into Inventory values('AIRGL2','Air Conditioner','Green Aircon','LSNS1Q',55000,59600,15)


CREATE TABLE Supplier( 

	SupplierID varchar(10)NOT NULL ,
	Name varchar(30),
	Address varchar(50),
	email varchar(50),
	CONSTRAINT Sup_pk PRIMARY KEY(SupplierID)

);

insert into Supplier values('SU0001','Green Aircon','12,Parakumba Place,Colombo','greenair@gmail.com')
insert into Supplier values('SU0002','ATCO Refregeration','271,Stanly Thilakaratne Mawatha,Colombo2','atcorefre@gmail.com')
insert into Supplier values('SU0003','Lanka Real(Pvt)Ltd','23,Main Road,Kaluthara','lankareal@gmail.com')
insert into Supplier values('SU0004','US Motor Spare Parts','223,Main Road,Gampaha','us_motor@gmail.com')
insert into Supplier values('SU0005','Semini Motors(Pvt)Ltd','23/1,Jaya Street,Galle','semini_mtr@gmail.com')
insert into Supplier values('SU0006','Singer','10,Parakumba Place,Colombo','singer@gmail.com')
insert into Supplier values('SU0007','B&P Distributors','271,Main Road,Colombo2','bpd@gmail.com')
insert into Supplier values('SU0008','Lanka Auto Parts(Pvt)Ltd','23/1,Old Road,Kaluthara','lankapp@gmail.com')
insert into Supplier values('SU0009','Motor Spare Parts','22/2,Main Road,Gampaha','motorss@gmail.com')
insert into Supplier values('SU0010','Sagara Motors(Pvt)Ltd','11,Main Road,Galle','sagaramtr@gmail.com')

CREATE TABLE SupplierContact (

	SupplierID varchar (10)NOT NULL ,
	ContactNo char (10)NOT NULL ,
	CONSTRAINT SuppCon_pk PRIMARY KEY(SupplierID,ContactNO),
	CONSTRAINT SuppCon_fk FOREIGN KEY(SupplierID) REFERENCES Supplier(SupplierID),
    
);

insert into SupplierContact values('SU0001','0712345678')
insert into SupplierContact values('SU0002','0112568903')
insert into SupplierContact values('SU0003','0347829479')
insert into SupplierContact values('SU0004','0778936423')
insert into SupplierContact values('SU0005','0913648378')
insert into SupplierContact values('SU0006','0714345678')
insert into SupplierContact values('SU0007','0112668903')
insert into SupplierContact values('SU0008','0347499479')
insert into SupplierContact values('SU0009','0778356423')
insert into SupplierContact values('SU0010','0913548378')

CREATE TABLE InventoryReorder(

	ProductType varchar(30),
	Make varchar(30),
	Model varchar(30),
	Re_orderLevel int,
	TotalQuantity int,
	CONSTRAINT InvRe_pk PRIMARY KEY(ProductType,Make,Model)

);

insert into InventoryReorder values('Air Conditioner','Green Aircon','LSNS1Q',7,30)
insert into InventoryReorder values('Refregerator','ATCO','GRD35FBG',10,10)
insert into InventoryReorder values('Radiator','Motor Parts','P001RDFC',8,15)
insert into InventoryReorder values('Battery Cable','Duralast','GT2234I',8,15)
insert into InventoryReorder values('Static Condensor','Green Free','SCT1NS',8,10)
insert into InventoryReorder values('Compressor','NLA','COR1ND',8,15)
insert into InventoryReorder values('Defrost Heater','TEEMS','DFH1NS',9,15)
insert into InventoryReorder values('Receiver Dryer','Linda','REDEDS',10,13)
insert into InventoryReorder values('Compressor','Aluna','COU1NS',10,15)

CREATE TABLE Supplies( 

	SupplierID varchar(10)NOT NULL ,
	InventoryID varchar(10)NOT NULL ,
	TotallyPaidAmount float default 0,
	CONSTRAINT Supp_pk PRIMARY KEY(SupplierID,InventoryID),
	CONSTRAINT Sups_fk1 FOREIGN KEY(InventoryID) REFERENCES Inventory(InventoryID),
	CONSTRAINT Sups_fk2 FOREIGN KEY(SupplierID) REFERENCES Supplier(SupplierID)

);

insert into Supplies values('SU0001','AIRGL1',75000)
insert into Supplies values('SU0002','REFAG1',60000)
insert into Supplies values('SU0003','RADMP1',80000)
insert into Supplies values('SU0004','BATDG1',100000)
insert into Supplies values('SU0005','STAGS1',80000)
insert into Supplies values('SU0006','COMNC1',100000)
insert into Supplies values('SU0007','DEFTD1',80000)
insert into Supplies values('SU0008','RECLR1',100000)
insert into Supplies values('SU0009','COMAC1',102000)
insert into Supplies values('SU0010','AIRGL2',100000)
--delete from Supplies where SupplierID='SU0010' and InventoryID='AIRGL2'

CREATE TABLE SupplierPayment( 

	SupplierID varchar(10)NOT NULL ,
	InventoryID varchar(10)NOT NULL ,
	Date date,
	PaidAmount float,
	CONSTRAINT SupPm_pk PRIMARY KEY(SupplierID,InventoryID,Date),
	CONSTRAINT SuppPm_fk1 FOREIGN KEY(InventoryID) REFERENCES Inventory(InventoryID),
	CONSTRAINT SuppPm_fk2 FOREIGN KEY(SupplierID) REFERENCES Supplier(SupplierID)

);

insert into SupplierPayment values('SU0001','AIRGL1','2016-01-02',35000)
insert into SupplierPayment values('SU0002','REFAG1','2016-01-08',60000)
insert into SupplierPayment values('SU0003','RADMP1','2016-02-02',80000)
insert into SupplierPayment values('SU0001','AIRGL1','2016-02-09',40000)
insert into SupplierPayment values('SU0004','BATDG1','2016-02-12',50000)
insert into SupplierPayment values('SU0004','BATDG1','2016-03-19',50000)
insert into SupplierPayment values('SU0005','STAGS1','2016-04-01',80000)
insert into SupplierPayment values('SU0006','COMNC1','2016-04-08',20000)
insert into SupplierPayment values('SU0006','COMNC1','2016-04-12',35000)
insert into SupplierPayment values('SU0007','DEFTD1','2016-04-20',80000)
insert into SupplierPayment values('SU0006','COMNC1','2016-05-01',45000)
insert into SupplierPayment values('SU0008','RECLR1','2016-05-08',60000)
insert into SupplierPayment values('SU0009','COMAC1','2016-05-13',102000)
insert into SupplierPayment values('SU0008','RECLR1','2016-05-20',40000)
insert into SupplierPayment values('SU0010','AIRGL2','2016-06-08',90000)
insert into SupplierPayment values('SU0010','AIRGL2','2016-08-08',10000)


--Repair ----

CREATE TABLE Repair_Job (

	JobID int NOT NULL IDENTITY(1,1),
	Type varchar (20),
	JobStartDate datetime,
	JobEndDate datetime,
	Details varchar (1000),
	CustomerNIC char(10),
	Supervisor int,
	
	CONSTRAINT Rep_pk PRIMARY KEY(JobID ),
	CONSTRAINT Rep_fk FOREIGN KEY(CustomerNIC) references Customer(NIC) ON DELETE CASCADE,
	CONSTRAINT Rep_fk1 FOREIGN KEY(Supervisor) references Employee(EmployeeID),
	
) ;

INSERT INTO Repair_Job VALUES ('PRO', '2017-04-01', '2017-04-06', 'A Refrigerator', '985645451v', 2)
INSERT INTO Repair_Job VALUES ('VEH', '2017-03-02', '2017-03-06', 'Air Conditioning System','788552411v', 3)
INSERT INTO Repair_Job VALUES ('PRO', '2017-07-08', '2017-08-09', 'A Refrigerator', '934141328v', 4)
INSERT INTO Repair_Job VALUES ('PRO', '2017-07-09', '2017-07-20', 'Air Conditioner', '923456789v', 5)
INSERT INTO Repair_Job VALUES ('PRO', '2017-08-01', '2017-10-09', 'A Refrigerator', '523456789v', 2)
INSERT INTO Repair_Job VALUES ('VEH', '2017-04-30', '2017-11-09', 'Air Conditioning System', '925679324v', 1)
INSERT INTO Repair_Job VALUES ('PRO', '2016-10-31', '2016-12-19', 'Air Conditioner', '936591478v', 3)
INSERT INTO Repair_Job VALUES ('PRO', '2016-10-31', '2016-11-12', 'A Refrigerator', '915482674v', 5)
INSERT INTO Repair_Job VALUES ('PRO', '2017-4-23', '2017-5-12', 'A Refrigerator', '915482674v', 4)
INSERT INTO Repair_Job VALUES ('PRO', '2017-10-31', '2017-11-12', 'A Refrigerator', '957816458v', 2)


CREATE TABLE Employee_Repair_Job (

	EmployeeID int NOT NULL ,
	JobID int NOT NULL ,
	CONSTRAINT EmRep_pk PRIMARY KEY(EmployeeID,JobID ),
	CONSTRAINT EmRep_fk FOREIGN KEY(EmployeeID) REFERENCES Employee(EmployeeID) ,
	CONSTRAINT EmRep_fk1 FOREIGN KEY(JobID) REFERENCES Repair_Job (JobID) ON DELETE CASCADE
	
)

INSERT INTO Employee_Repair_Job VALUES (1,2)
INSERT INTO Employee_Repair_Job VALUES (5,4)
INSERT INTO Employee_Repair_Job VALUES (4,5)
INSERT INTO Employee_Repair_Job VALUES (3,1)
INSERT INTO Employee_Repair_Job VALUES (2,3)
INSERT INTO Employee_Repair_Job VALUES (1,6)
INSERT INTO Employee_Repair_Job VALUES (5,7)
INSERT INTO Employee_Repair_Job VALUES (4,10)
INSERT INTO Employee_Repair_Job VALUES (3,8)
INSERT INTO Employee_Repair_Job VALUES (2,9)


CREATE TABLE Repair_Inventory (

	InventoryID varchar (10)NOT NULL ,
	JobID int NOT NULL ,
	ItemNo varchar (50),
	SellingPrice float,
	CONSTRAINT RepIn_pk PRIMARY KEY(InventoryID,JobID ,ItemNo),
	CONSTRAINT RepIn_fk FOREIGN KEY(InventoryID) REFERENCES Inventory(InventoryID) ON DELETE CASCADE,
	CONSTRAINT RepIn_fk1 FOREIGN KEY(JobID) REFERENCES Repair_Job (JobID)ON DELETE CASCADE,	
)

INSERT INTO Repair_Inventory VALUES ('STAGS1', 1, '1001XXXXX',4900)
INSERT INTO Repair_Inventory VALUES ('RECLR1', 2, '300XXXXX',5900)
INSERT INTO Repair_Inventory VALUES ('DEFTD1', 3, '101XXXXX', 5300)
INSERT INTO Repair_Inventory VALUES ('COMAC1', 4, '302XXXXX', 6900)
INSERT INTO Repair_Inventory VALUES ('COMNC1', 5, '104XXXXX', 6500)
INSERT INTO Repair_Inventory VALUES ('COMAC1', 6, '1024XXXX', 6900)
INSERT INTO Repair_Inventory VALUES ('RECLR1', 7, '107XXXXX', 5900)
INSERT INTO Repair_Inventory VALUES ('DEFTD1', 8, '108XXXXX', 5300)
INSERT INTO Repair_Inventory VALUES ('STAGS1', 9, '102XXXXX', 4900)
INSERT INTO Repair_Inventory VALUES ('COMNC1', 10,'105XXXXX',6500)



--SALES
create table Invoice(
	
	InvoiceID int NOT NULL IDENTITY(1,1),
	Amount float,
	NIC char(10),
	Date dateTime,
	deliveryStatus varchar(20),
	CONSTRAINT  sa_pk PRIMARY KEY(InvoiceID ),
	--CONSTRAINT sa_fk1 FOREIGN KEY(NIC) REFERENCES Customer(NIC)ON DELETE NO ACTION
	
);
INSERT INTO Invoice VALUES(5000,'985645451v','2016-09-05 20:24:22.000','Processing')
INSERT INTO Invoice VALUES(75000,'788552411v','2016-09-06 10:00:22.000','Done')
INSERT INTO Invoice VALUES(25000,'934141328v','2016-09-06 20:25:21.000','W')
INSERT INTO Invoice VALUES(89500,'923456789v','2016-09-07 13:00:35.000','Processing')
INSERT INTO Invoice VALUES(78000,'523456789v','2016-09-09 15:32:12.000','NW')
INSERT INTO Invoice VALUES(12000,'925679324v','2016-09-09 10:00:59.000','Processing')
INSERT INTO Invoice VALUES(36000,'936591478v','2016-09-10 21:00:26.000','W')
INSERT INTO Invoice VALUES(87000,'915482674v','2016-08-11 20:24:43.000','Processing')
INSERT INTO Invoice VALUES(75000,'957816458v','2016-09-12 10:35:42.000','W')
INSERT INTO Invoice VALUES(75000,'945873157v','2016-09-12 12:07:22.000','W')
INSERT INTO Invoice VALUES(15000,'945873157v','2016-08-12 12:07:22.000','Done')
INSERT INTO Invoice VALUES(25000,'945873157v','2016-08-20 12:07:22.000','NW')
INSERT INTO Invoice VALUES(85000,'945873157v','2016-08-20 12:07:22.000','Processing')



CREATE TABLE PurchaseItems(
	InvoiceID int NOT NULL,
	InventoryID varchar(10) NOT NULL,
	SerialKey varchar(20),
	idx int IDENTITY(1,1),

	constraint InPur_pk Primary key (InvoiceID,InventoryID,SerialKey),
	constraint InPur_fk1 foreign key (InventoryID) References Inventory(InventoryID)ON DELETE CASCADE,
	constraint InPur_fk2 foreign key (InvoiceID) references Invoice(InvoiceID)ON DELETE CASCADE
 );


CREATE TABLE ServiceInvoice(
	JobID int not null,
	NIC char(10),
	CustomerName char(30),
	Date dateTime NOT NULL,
	Mobile char(10),
	GrandTotal int,
	
	CONSTRAINT si_pk PRIMARY KEY(JobID),
	--CONSTRAINT si_fk1 FOREIGN KEY(NIC) REFERENCES Customer(NIC)ON DELETE CASCADE,
	--CONSTRAINT si_fk2 FOREIGN KEY(JobID) REFERENCES Repair_Job(JobID)ON DELETE CASCADE,
);



insert into ServiceInvoice VALUES (1,'985645451v','Liyanage T.M.','2016-09-19 00:00:00.000','0719551627',25000)
insert into ServiceInvoice values (2,'788552411v','Shashi D.N.','2016-09-20 00:00:00.000','0719551645',25000)
insert into ServiceInvoice values (3,'934141328v','Naditha D.D.N.','2016-09-21 00:00:00.000','0719565627',25000)
insert into ServiceInvoice values (4,'923456789v','Pooja T.W','2016-09-30 00:00:00.000','0772651674',25000)
insert into ServiceInvoice values (5,'523456789v','Nipun K.L.','2016-10-01 00:00:00.000','0721231954',25000)
--insert into ServiceInvoice values (6,'936591478v','Bimal E.R','2016-10-02 00:00:00.000','07565451847',25000)
insert into ServiceInvoice values (7,'915482674v','Sajith S.L','2016-10-03 00:00:00.000','0775556527',25000)
insert into ServiceInvoice values (8,'915482674v','Sajith S.L','2016-10-05 00:00:00.000','0715658474',25000)
insert into ServiceInvoice values (9,'957816458v','thulakshi C.M','2016-08-10 00:00:00.000','0714843284',25000)


--DELIVERY

CREATE TABLE Vehicles(

	VehicleNo varchar (10)NOT NULL ,
	Vehicle_Type varchar (10),
	Capacity varchar(10),
	Make varchar (15),
	Model varchar(15),
	Status varchar (15),
	Description varchar(100),
	CONSTRAINT Veh_pk PRIMARY KEY(VehicleNo),
	
);

insert into Vehicles (VehicleNo,Vehicle_Type,Capacity,Make,Model,Status,Description) values ('CAA-5641','SUV','750KG','Toyota','Fortuner','A','Srevice is Done...')
insert into Vehicles (VehicleNo,Vehicle_Type,Capacity,Make,Model,Status,Description) values ('LY-6655','Lorry','10000KG','Toyota','Canter','A','Srevice is Not Done...')
insert into Vehicles (VehicleNo,Vehicle_Type,Capacity,Make,Model,Status,Description) values ('PB-8913','CruCab','1750KG','Nissan','LiteAce','A','Srevice is Done...')
insert into Vehicles (VehicleNo,Vehicle_Type,Capacity,Make,Model,Status,Description) values ('255-6745','Lorry','2750KG','Mazda','Bongo','A','Srevice is Done...')
insert into Vehicles (VehicleNo,Vehicle_Type,Capacity,Make,Model,Status,Description) values ('LA-6739','FlatBed','5000KG','Laylend','XV100','Av','Srevice is Done...')
insert into Vehicles (VehicleNo,Vehicle_Type,Capacity,Make,Model,Status,Description) values ('56-7829','Lorry','2750KG','Toyota','Canter','NA','Srevice is Done...')
insert into Vehicles (VehicleNo,Vehicle_Type,Capacity,Make,Model,Status,Description) values ('LF-6720','Crucab','1750KG','Mitshubishi','liteace','A','Srevice is Done...')
insert into Vehicles (VehicleNo,Vehicle_Type,Capacity,Make,Model,Status,Description) values ('LE-8476','Lorry','4500KG','FUSO','AU500','Ae','Srevice is Done...')
insert into Vehicles (VehicleNo,Vehicle_Type,Capacity,Make,Model,Status,Description) values ('63-6729','VAN','1750KG','Toyota','townace','A','Srevice is Done...')
insert into Vehicles (VehicleNo,Vehicle_Type,Capacity,Make,Model,Status,Description) values ('PB-5573','SingleCab','1750KG','Mitsubishi','L200','NA','Srevice is Done...')

CREATE TABLE Delivery (

	DeliveryNo varchar(10)NOT NULL ,
	Description varchar(200),
	Status varchar(20),
	VehicleNo varchar(10),
	EmpID int,
	NIC char(10),
	From1 varchar(30),
	To1 varchar(30),
	distance float,
	rate float,
	Cost money,
	InvoiceID int,
	DiliveryDate date,
		
	CONSTRAINT Del_pk PRIMARY KEY(DeliveryNo),
	CONSTRAINT delivery_fk1 FOREIGN KEY(EmpID) REFERENCES Employee(EmployeeID)ON DELETE CASCADE,
	CONSTRAINT delivery_fk2 FOREIGN KEY(InvoiceID) REFERENCES Invoice(InvoiceID)ON DELETE CASCADE,
	CONSTRAINT delivery_fk3 FOREIGN KEY(NIC) REFERENCES Customer(NIC)ON DELETE CASCADE,
	CONSTRAINT delivery_fk4 FOREIGN KEY(VehicleNo ) REFERENCES Vehicles(VehicleNo )ON DELETE CASCADE,
	
)



insert into dbo.Delivery(DeliveryNo,Description,Status,VehicleNo,EmpID,NIC,From1,To1,distance,rate,cost,InvoiceID,DiliveryDate) values ('LY195022','done','Processing','LY-6655',3,'985645451v','horana','kaluthara',35.0,25.0,875.00,1,'2016 september 15')
insert into dbo.Delivery(DeliveryNo,Description,Status,VehicleNo,EmpID,NIC,From1,To1,distance,rate,cost,InvoiceID,DiliveryDate) values ('LF352345','done','Not Deliverd','LF-6720',3,'523456789v','malabe','horana',32.0,25.0,825.00,3,'2016 september 16')
insert into dbo.Delivery(DeliveryNo,Description,Status,VehicleNo,EmpID,NIC,From1,To1,distance,rate,cost,InvoiceID,DiliveryDate) values ('LE592345','done','Deliverd','LE-8476',3,'923456789v','ambalangoda','mathara',60.0,25.0,1500.00,5,'2016 september 17')
insert into dbo.Delivery(DeliveryNo,Description,Status,VehicleNo,EmpID,NIC,From1,To1,distance,rate,cost,InvoiceID,DiliveryDate) values ('56212348','done','Processing','56-7829',3,'915482674v','rathnapura','malabe',105.0,25.0,2625.00,2,'2016 september 18')
insert into dbo.Delivery(DeliveryNo,Description,Status,VehicleNo,EmpID,NIC,From1,To1,distance,rate,cost,InvoiceID,DiliveryDate) values ('PB193455','done','Deliverd','PB-5573',3,'934552621v','galle','hambanthota',75.0,25.0,1875.00,10,'2016 august 19')
--delete from Delivery where 	DeliveryNo='PB193455'
CREATE TABLE EmpDriver (

	driverNo int,
	Name varchar (70),
	status varchar(30),
	CONSTRAINT driver_pk1 PRIMARY KEY(driverNo),
	CONSTRAINT driver_fk1 FOREIGN KEY(driverNo) REFERENCES Employee(EmployeeID)ON DELETE CASCADE,

);



insert into EmpDriver values (3,'Naditha','A')

--Insert INTO EmpDriver (DriverNo, Status) Values
--(2, 'Available'),
--(7, 'Not Available'),
--(9, 'Not Available');

CREATE TABLE Vehicle_Service (

	VehicleNo varchar (10)NOT NULL ,
	Servise_Des varchar (200)NOT NULL ,
	Last_Service_Date datetime NOT NULL ,
	Last_Service_Millage float NOT NULL ,
	Next_Service_Date datetime,
	Next_Service_Millage float,
	CONSTRAINT VehS_pk PRIMARY KEY(VehicleNo,Servise_Des,Last_Service_Date,Last_Service_Millage),
	CONSTRAINT VehS_fk FOREIGN KEY(VehicleNo) REFERENCES Vehicles(VehicleNo)ON DELETE CASCADE
	
)



insert into dbo.Vehicle_Service(VehicleNo,Servise_Des,Last_Service_Date,Last_Service_Millage,Next_Service_Date,Next_Service_Millage) Values ('CAA-5641','Done','2016 september 07',14000.00,'2017 march 07',19000.00)
insert into dbo.Vehicle_Service(VehicleNo,Servise_Des,Last_Service_Date,Last_Service_Millage,Next_Service_Date,Next_Service_Millage) Values ('LY-6655','Done','2016 August 17',25000.00,'2017 february 17',30000.00)
insert into dbo.Vehicle_Service(VehicleNo,Servise_Des,Last_Service_Date,Last_Service_Millage,Next_Service_Date,Next_Service_Millage) Values ('PB-8913','Done','2016 june 22',37000.00,'2016 december 22',42000.00)
insert into dbo.Vehicle_Service(VehicleNo,Servise_Des,Last_Service_Date,Last_Service_Millage,Next_Service_Date,Next_Service_Millage) Values ('255-6745','Done','2016 september 26',155000.00,'2017 march 26',160000.00)
--insert into dbo.Vehicle_Service(VehicleNo,Servise_Des,Last_Service_Date,Last_Service_Millage,Next_Service_Date,Next_Service_Millage) Values ('LA-6739','Done','2016 april 16',166000.00,'2016 octomber 16',171000.00)
--insert into dbo.Vehicle_Service(VehicleNo,Servise_Des,Last_Service_Date,Last_Service_Millage,Next_Service_Date,Next_Service_Millage) Values ('56-7829','Done','2016 may 09',280000.00,'2016 november 09',285000.00)
--insert into dbo.Vehicle_Service(VehicleNo,Servise_Des,Last_Service_Date,Last_Service_Millage,Next_Service_Date,Next_Service_Millage) Values ('LF-6720','Done','2016 july 13',122000.00,'2017 january 13',127000.00)
--insert into dbo.Vehicle_Service(VehicleNo,Servise_Des,Last_Service_Date,Last_Service_Millage,Next_Service_Date,Next_Service_Millage) Values ('LE-8476','Done','2016 april 29',57000.00,'2016 octomber 29',62000.00)
--insert into dbo.Vehicle_Service(VehicleNo,Servise_Des,Last_Service_Date,Last_Service_Millage,Next_Service_Date,Next_Service_Millage) Values ('63-6729','Done','2016 september 30',258000.00,'2017 march 30',263000.00)
--insert into dbo.Vehicle_Service(VehicleNo,Servise_Des,Last_Service_Date,Last_Service_Millage,Next_Service_Date,Next_Service_Millage) Values ('PB-5573','Done','2016 August 18',175000.00,'2016 february 18',180000.00)


CREATE TABLE Delivery_Vehicle (

	VehicleNo varchar (10)NOT NULL ,
	DeliveryNo varchar (10),
	DeliveryDescription varchar(200),
	Driver int,
	CONSTRAINT DelVeh_pk PRIMARY KEY(VehicleNo,DeliveryNo),
	CONSTRAINT DelVeh_fk1 FOREIGN KEY(VehicleNo) REFERENCES Vehicles(VehicleNo)ON DELETE CASCADE,
	CONSTRAINT DelVeh_fk2 FOREIGN KEY(Driver) REFERENCES EmpDriver(driverNo)ON DELETE CASCADE
)



insert into dbo.Delivery_Vehicle(VehicleNo,DeliveryNo,DeliveryDescription,Driver) values ('LY-6655','LY195022','Processing',3)
insert into dbo.Delivery_Vehicle(VehicleNo,DeliveryNo,DeliveryDescription,Driver) values ('LF-6720','LF352345','Not Deliverd',3)
insert into dbo.Delivery_Vehicle(VehicleNo,DeliveryNo,DeliveryDescription,Driver) values ('LE-8476','LE592345','Deliverd',3)
insert into dbo.Delivery_Vehicle(VehicleNo,DeliveryNo,DeliveryDescription,Driver) values ('56-7829','56212348','Processing',3)
insert into dbo.Delivery_Vehicle(VehicleNo,DeliveryNo,DeliveryDescription,Driver) values ('PB-5573','PB193455','Deliverd',3)

CREATE TABLE Rented_Vehicle (

	RentVehicalNo varchar (10) ,
	Date datetime  ,
	Duration int  ,
	Ownername varchar (30),
	Vehical_Type varchar (10),
	CONSTRAINT RentVehi_pk PRIMARY KEY(RentVehicalNo,Date)
	
	
)

CREATE TABLE Delivery_Rented_Vehical(

	VehicalNo varchar (10)NOT NULL ,
	RentedDate datetime,
	DeliveryNo varchar (10)NOT NULL ,
	CONSTRAINT DeRent_pk PRIMARY KEY(VehicalNo,RentedDate,DeliveryNo),
	CONSTRAINT DeRent_fk FOREIGN KEY(VehicalNo,RentedDate) REFERENCES Rented_Vehicle(RentVehicalNo,Date)ON DELETE CASCADE,
	CONSTRAINT DeRent_fk1 FOREIGN KEY(DeliveryNo) REFERENCES Delivery(DeliveryNo)ON DELETE CASCADE

)



--OFFSITE

CREATE TABLE OffSiteJob
(
JobID int NOT NULL IDENTITY(1,1),
JobType char(2) NOT NULL,
JobStatus char (2),
Startdate datetime,
Enddate datetime,
JobDescription varchar (255),
CustomerNIC varchar (10),
Supervisor int,
PRIMARY KEY (JobID)
)


INSERT INTO OffsiteJob (JobType, JobStatus, Startdate, Enddate, JobDescription, CustomerNIC, Supervisor) VALUES
('PJ', 'ON', '20160101', NULL, 'No56 Ford Mw Gampola Hotel installation', '985645451v', 5),
('RJ', 'FN', '20160103', '20160103', 'no98 Welliwita road', '788552411v', 10),
('PJ', 'FN', '20151209', '20151215', 'no345/6 makola road small job', '934141328v', 5),
('PJ', 'ON', '20160502', NULL, 'Independence square renovation', '923456789v', 10),
('PJ', 'ON', '20160104', NULL, 'Sencond floor of Empire Cinemas', '523456789v', 5),
('RJ', 'FN', '20160104', '20160104', '3 storey privatre residance in Horton Place', '925679324v', 5),
('PJ', 'FN', '20151205', '20160115', 'BMICH new hall', '936591478v', 5),
('PJ', 'ON', '20160505', NULL, 'no765 Alley Road in Horana', '915482674v', 10),
('RJ', 'FN', '20151205', '20151205', 'Horizon School Malabe', '957816458v', 5),
('PJ', 'ON', '20160505', NULL, 'Barista new cafe location Galle road', '945873157v', 5);

CREATE TABLE Reserves
(
JobID int NOT NULL,
InventoryID varchar (10)  NOT NULL,
ItemNo char(10),
ReserveStatus char (2),

PRIMARY KEY (JobID, InventoryID, ItemNo),
FOREIGN KEY(JobID) references OffSiteJob(JobID)ON DELETE CASCADE,
FOREIGN KEY(InventoryID) references Inventory(InventoryID)ON DELETE CASCADE,
)

INSERT INTO Reserves (JobID, InventoryID, ItemNo, ReserveStatus ) VALUES
(4, 'AIRGL1', 'EVE1234567', 'RS'),
(2, 'REFAG1', 'EVE2234567', 'RS'),
(6, 'RADMP1', 'EVE3234567', 'RS'),
(8, 'BATDG1', 'EVE4234567', 'RS'),
(10, 'STAGS1', 'EVE5234567', 'RS'),
(10, 'COMNC1', 'EVE6234567', 'RS'),
(4, 'DEFTD1', 'EVE7234567', 'RS'),
(1, 'RECLR1', 'EVE8234567', 'RS'),
(2, 'COMAC1', 'EVE9234567', 'RS'),
(7, 'AIRGL2', 'EVE0234567', 'RS');


CREATE TABLE EmployeeOffsiteJob
(
JobID int NOT NULL,
EmpID int  NOT NULL,

PRIMARY KEY (JobID, EmpID),
FOREIGN KEY(JobID) references OffSiteJob(JobID)ON DELETE CASCADE,
FOREIGN KEY(EmpID) references Employee(EmployeeID)ON DELETE CASCADE,
)

Insert INTO EmployeeOffsiteJob (JobID, EmpID) Values
(1, 1),
(5, 2),
(5, 3),
(9, 5);

CREATE TABLE OffsiteJobVehicle
(
JobID int NOT NULL,
VehicleNo varchar(10)  NOT NULL,

PRIMARY KEY (JobID, VehicleNo),
FOREIGN KEY(JobID) references OffSiteJob(JobID)ON DELETE CASCADE,
FOREIGN KEY(VehicleNo) references Vehicles(VehicleNo)ON DELETE CASCADE,
)

INSERT INTO OffsiteJobVehicle (JobID, VehicleNo) VALUES
(1, 'CAA-5641'),
(3, 'LA-6739'),
(7, '56-7829'),
(3, '63-6729'),
(1, 'LY-6655'),
(4, '255-6745'),
(4, 'LE-8476'),
(7, 'LF-6720'),
(8, 'PB-5573'),
(2, 'PB-8913');

CREATE TABLE EmployeeWorkDates
(
	EmpID int,
	WorkDate datetime,
	JobType char(2),
	JobID int,
	DeliveryID int,
	Primary Key (EmpID,WorkDate),
	FOREIGN KEY(EmpID) references Employee(EmployeeID)ON DELETE CASCADE,
)

INSERT INTO EmployeeWorkDates  VALUES ('1','2016-01-01 00:00:00.000','PJ','1', NULL)
INSERT INTO EmployeeWorkDates  VALUES ('2','2016-01-04 00:00:00.000','PJ','5', NULL)
INSERT INTO EmployeeWorkDates  VALUES ('3','2016-01-04 00:00:00.000','PJ','5', NULL)
INSERT INTO EmployeeWorkDates  VALUES ('5','2016-05-05 00:00:00.000','PJ','8', NULL)



CREATE TABLE VehicleWorkDates
(
	VehicleNo varchar (10),
	WorkDate datetime,
	JobType char(2),
	JobID int,
	DeliveryID int,
	Primary Key (VehicleNo,WorkDate),
	FOREIGN KEY(VehicleNo) references Vehicles(VehicleNo)ON DELETE CASCADE,
)
INSERT INTO VehicleWorkDates  VALUES ('CAA-5641','2016-01-01 00:00:00.000','PJ','1', NULL)
INSERT INTO VehicleWorkDates  VALUES ('LA-6739','2015-12-09 00:00:00.000','PJ','3', NULL)
INSERT INTO VehicleWorkDates  VALUES ('56-7829','2015-12-05 00:00:00.000','PJ','7', NULL)
INSERT INTO VehicleWorkDates  VALUES ('63-6729','2015-12-09 00:00:00.000','PJ','3', NULL)
INSERT INTO VehicleWorkDates  VALUES ('LY-6655','2016-01-01 00:00:00.000','PJ','1', NULL)
INSERT INTO VehicleWorkDates  VALUES ('255-6745','2016-05-02 00:00:00.000','PJ','4', NULL)
INSERT INTO VehicleWorkDates  VALUES ('LE-8476','2016-05-02 00:00:00.000','PJ','4', NULL)
INSERT INTO VehicleWorkDates  VALUES ('LF-6720','2015-12-05 00:00:00.000','PJ','7', NULL)
INSERT INTO VehicleWorkDates  VALUES ('PB-5573','2015-12-05 00:00:00.000','RJ','9', NULL)
INSERT INTO VehicleWorkDates  VALUES ('PB-8913','2016-01-04 00:00:00.000','PJ','6', NULL)


--ACCOUNT

CREATE TABLE Expenditure(

	ExpenditureID int NOT NULL IDENTITY(1,1),
	Description varchar (500),
	Date dateTime,
	Amount float ,
	Category varchar (50),
	CONSTRAINT Ex_pk PRIMARY KEY(ExpenditureID),
	)

		
INSERT INTO Expenditure VALUES ('NULL','1999-02-28','1200','Marketing cost')
INSERT INTO Expenditure VALUES ('NULL','1990-02-28','1300','Marketing cost')
INSERT INTO Expenditure VALUES ('NULL','1991-02-28','1400','Traveling cost')
INSERT INTO Expenditure VALUES ('NULL','1992-02-28','12000','Payroll')
INSERT INTO Expenditure VALUES ('NULL','1993-02-28','100','Payroll')
INSERT INTO Expenditure VALUES ('NULL','2016-08-28','10000','Payroll')
INSERT INTO Expenditure VALUES ('NULL','2016-08-29','20000','Marketing cost')
INSERT INTO Expenditure VALUES ('NULL','2016-08-18','80000','Traveling cost')
INSERT INTO Expenditure VALUES ('NULL','2016-08-17','10000','Insurancecost')
INSERT INTO Expenditure VALUES ('NULL','2016-08-01','3000','Other')
INSERT INTO Expenditure VALUES ('NULL','2016-08-03','2000','Water Bill')
INSERT INTO Expenditure VALUES ('NULL','2016-08-25','10000','Miselenius cost')
INSERT INTO Expenditure VALUES ('NULL','2016-08-26','70000','Elecity Bill')
INSERT INTO Expenditure VALUES ('NULL','2016-08-17','10000','Insurance cost')
INSERT INTO Expenditure VALUES ('NULL','2016-08-17','20000','Insurance cost')


CREATE TABLE Taxes (
	
	TaxID int NOT NULL IDENTITY(1,1),
	TaxFileNo int,
	Date dateTime,
	Description varchar (100),
	Amount float,

	CONSTRAINT Tax_pk PRIMARY KEY(TaxID),
	)

INSERT INTO Taxes  VALUES ('3000','1999-02-28','incomeTax','1000')
INSERT INTO Taxes  VALUES ('3001','1991-02-28','incomeTax','2000')
INSERT INTO Taxes  VALUES ('3004','1992-02-28','Property Tax','1500')
INSERT INTO Taxes  VALUES ('3005','1993-02-28','Payroll Tax','1200')
INSERT INTO Taxes  VALUES ('3003','2016-08-25','PayrollTax','7000')
INSERT INTO Taxes  VALUES ('3006','2016-08-28','incomeTax','800')
INSERT INTO Taxes  VALUES ('3007','2016-08-20','Property Tax','900')

create table budget
(
	Year int ,
	Month Varchar (10),
	Total_Budget float,
	Payroll_Amn float,
	Marketing_Amn float,
	Insurance_Amn float,
	Travel_Amn float,
	Miselenius_Amn float,
	Other_Amn float,
	Payroll_Pres float,
	Marketing_pres float,
	Insurance_pres float,
	Travel_pres float,
	Miselenius_pres float,
	Other_pres  float,
	
	CONSTRAINT Bud_pk PRIMARY KEY(Year,Month)
)
INSERT INTO budget  VALUES ('2000','January','200000','1000','40000','20000','10000','8000','10000','15','33','10','15','25','5')
INSERT INTO budget  VALUES ('2000','February','200000','1000','40000','20000','10000','8000','10000','15','33','10','15','25','5')
INSERT INTO budget  VALUES ('2000','March','200000','1000','40000','20000','10000','8000','10000','15','33','10','15','25','5')
INSERT INTO budget  VALUES ('2000','May','200000','1000','40000','20000','10000','8000','10000','15','33','10','15','25','5')
INSERT INTO budget  VALUES ('2000','June','200000','1000','40000','20000','10000','8000','10000','15','33','10','15','25','5')
INSERT INTO budget  VALUES ('2000','July','200000','1000','40000','20000','10000','8000','10000','15','33','10','15','25','5')

create table GrossProfit (

	GPID int NOT NULL IDENTITY(1,1),
	Month varchar (10),
	Product_Sales float,
	Order_cost float,
	Repair_Service float,
	Offsite_Service float,
	Total_Revenu float,
	Gross_Profit float,
	CONSTRAINT Gross_pk PRIMARY KEY(GPID),
	
);
alter table GrossProfit
add  Delivery_Servises float

alter table GrossProfit
add  Date DateTime


alter table GrossProfit
add  Year int

insert into GrossProfit values ('August','35000.00','20000.00','50000.00','60000.00','80000.00','2000.00','2000.00','2016-08-28','2016')
	insert into GrossProfit values ('August','35000.00','20000.00','50000.00','60000.00','80000.00','2000.00','2000.00','2016-01-28','2016')
	insert into GrossProfit values ('August','35000.00','20000.00','50000.00','60000.00','80000.00','2000.00','2000.00','2016-02-28','2016')
	insert into GrossProfit values ('August','35000.00','20000.00','50000.00','60000.00','80000.00','2000.00','2000.00','2016-03-28','2016')
	insert into GrossProfit values ('August','35000.00','20000.00','50000.00','60000.00','80000.00','2000.00','2000.00','2016-04-28','2016')
	insert into GrossProfit values ('August','35000.00','20000.00','50000.00','60000.00','80000.00','2000.00','2000.00','2016-05-28','2016')
	insert into GrossProfit values ('August','35000.00','20000.00','50000.00','60000.00','80000.00','2000.00','2000.00','2016-06-28','2016')
	insert into GrossProfit values ('August','35000.00','20000.00','50000.00','60000.00','80000.00','2000.00','2000.00','2016-07-28','2016')
	insert into GrossProfit values ('August','35000.00','20000.00','50000.00','60000.00','80000.00','2000.00','2000.00','2016-08-28','2016')
	insert into GrossProfit values ('August','35000.00','20000.00','50000.00','60000.00','80000.00','2000.00','2000.00','2016-09-28','2016')

create table NetProfit(

	NID int NOT NULL IDENTITY(1,1),
	Month varchar (10),
	Payroll float,
	Marketing float,
	Insurance float,
	Travel float,
	Misallaneous float,
	Bill float,
	Tax float,
	Other float,
	Net_profit float,
	CONSTRAINT Net_pk PRIMARY KEY(NID),
		
);


alter table NetProfit
add  Total_Expes float

alter table NetProfit
add  Year int

alter table NetProfit
add  Date Datetime

insert into NetProfit values ('August','35000.00','20000.00','50000.00','60000.00','80000.00','2000.00','2000.00','20000.00','10000.00','10000.00','2016','2016-08-28')
	insert into NetProfit values ('August','35000.00','20000.00','50000.00','60000.00','80000.00','2000.00','2000.00','30000.00','20000.00','20000.00','2016','2016-01-28')
	insert into NetProfit values ('August','35000.00','20000.00','50000.00','60000.00','80000.00','2000.00','2000.00','40000.00','30000.00','30000.00','2016','2016-02-28')
	insert into NetProfit values ('August','35000.00','20000.00','50000.00','60000.00','80000.00','2000.00','2000.00','70000.00','40000.00','40000.00','2016','2016-03-28')
	insert into NetProfit values ('August','35000.00','20000.00','50000.00','60000.00','80000.00','2000.00','2000.00','60000.00','50000.00','60000.00','2016','2016-04-28')
	insert into NetProfit values ('August','35000.00','20000.00','50000.00','60000.00','80000.00','2000.00','2000.00','88000.00','60000.00','50000.00','2016','2016-05-28')
	insert into NetProfit values ('August','35000.00','20000.00','50000.00','60000.00','80000.00','2000.00','2000.00','90000.00','70000.00','70000.00','2016','2016-06-28')
	insert into NetProfit values ('August','35000.00','20000.00','50000.00','60000.00','80000.00','2000.00','2000.00','50000.00','80000.00','80000.00','2016','2016-07-28')
	insert into NetProfit values ('August','35000.00','20000.00','50000.00','60000.00','80000.00','2000.00','2000.00','40000.00','90000.00','9000.00','2016','2016-08-28')
	insert into NetProfit values ('August','35000.00','20000.00','50000.00','60000.00','80000.00','2000.00','2000.00','20000.00','10000.00','10000.00','2016','2016-09-28')

create table AnnualProfit(
	AID int NOT NULL IDENTITY(1,1),
	Year int,
	TotalProduct float,
	TotalService float,
	TotalIncome float,
	TotalExpences float,
	AnnualGrossProfit float,
	AnnualNetProfit float,
	CONSTRAINT A_pk PRIMARY KEY(AID),
)

  insert into AnnualProfit values(2006,'20000.00','30000.00','20000.00','25500.00','20000.00','20000.00');
  insert into AnnualProfit values(2007,'40000.00','70000.00','70000.00','35000.00','60000.00','20000.00');
  insert into AnnualProfit values(2008,'50000.00','10000.00','50000.00','40000.00','20000.00','20000.00');
  insert into AnnualProfit values(2009,'20000.00','20000.00','60000.00','45000.00','20000.00','70000.00');
  insert into AnnualProfit values(2010,'50000.00','40000.00','75000.00','35000.00','20000.00','70000.00');
  insert into AnnualProfit values(2011,'30000.00','90000.00','25000.00','20000.00','20000.00','75000.00');
  insert into AnnualProfit values(2012,'70000.00','30000.00','26000.00','2750000.00','20000.00','45000.00');
  insert into AnnualProfit values(2013,'90000.00','70000.00','27000.00','66600.00','20000.00','82000.00');
  insert into AnnualProfit values(2014,'10000.00','50000.00','25000.00','20000.00','20000.00','45000.00');
  insert into AnnualProfit values(2015,'80000.00','60000.00','53000.00','20000.00','20000.00','79000.00');
