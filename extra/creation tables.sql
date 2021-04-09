create table tb_doctor (
NIDDOCTOR		int identity(1,1),
SFIRSTNAME		varchar(50),
SSECONDNAME		varchar(50),
SLASTNAME		varchar(50),
SLASTNAME1		varchar(50),
DBIRTHDATE		date,
SGENDER			char(1),
SSPECIALITY		varchar(100),
NPHONE			varchar(20),
SEMAIL			varchar(200),
SWEBSITE		varchar(200),
SACTIVE			char(1),
DREGISTER		date,
NUSERREGISTER	int,
DUPDATE			date,
NUSERUPDATE		int,
PRIMARY KEY (NIDDOCTOR)
)


create table tb_patient(
NIDPATIENT		int identity(1,1),
SFIRSTNAME		varchar(50),
SSECONDNAME		varchar(50),
SLASTNAME		varchar(50),
SLASTNAME1		varchar(50),
DBIRTHDATE		date,
SGENDER			char(1),
SEMAIL			varchar(200),
NPHONE			varchar(20),
SDESCRIPTION	varchar(500),
SACTIVE			char(1),
DREGISTER		date,
NUSERREGISTER	int,
DUPDATE			date,
NUSERUPDATE		int,
PRIMARY KEY (NIDPATIENT)
)


create table tb_user(
NIDUSER			int identity(1,1),
SUSER			varchar(100),
SPASSWORD		varchar(1000),
NIDDOCTOR		int,
SACTIVE			char(1),
DREGISTER		date,
NUSERREGISTER	int,
DUPDATE			date,
NUSERUPDATE		int,
PRIMARY KEY (NIDUSER),
FOREIGN KEY (NIDDOCTOR) REFERENCES tb_doctor(NIDDOCTOR)
)



----isnerts 
select*from tb_doctor

set dateformat dmy
insert into tb_doctor values ('Junior', 'Smits', 'Espinoza', 'Lozano', '01/01/1990', 'M', 'Medicina General', '985962356', 'abc@gmail.com', null, 'A', getdate(), 1, null, null)

set dateformat dmy
insert into tb_doctor values ('Julio', '', 'Ramirez', 'Gutierrez', '01/03/1992', 'M', 'Medicina General', '985962356', 'abc@gmail.com', null, 'A', getdate(), 1, null, null)
insert into tb_doctor values ('Carlos', 'Renzo', 'Garcia', 'Ramos', '04/01/1993', 'M', 'Medicina General', '985962356', 'abc@gmail.com', null, 'A', getdate(), 1, null, null)
insert into tb_doctor values ('Jesus', '', 'Peña', 'Luna', '01/05/1993', 'M', 'Medicina General', '985962356', 'abc@gmail.com', null, 'A', getdate(), 1, null, null)
insert into tb_doctor values ('Josue', 'Antonio', 'Mendoza', 'Gonzales', '12/01/1990', 'M', 'Medicina General', '985962356', 'abc@gmail.com', null, 'A', getdate(), 1, null, null)
insert into tb_doctor values ('Raul', '', 'Lozano', 'Vasquez', '01/03/1980', 'M', 'Medicina General', '985962356', 'abc@gmail.com', null, 'A', getdate(), 1, null, null)
insert into tb_doctor values ('Percy', 'Carlos', 'Polo', 'Ricra', '12/01/1982', 'M', 'Medicina General', '985962356', 'abc@gmail.com', null, 'A', getdate(), 1, null, null)
insert into tb_doctor values ('Jorge', '', 'Leon', 'Calderon', '01/05/1983', 'M', 'Medicina General', '985962356', 'abc@gmail.com', null, 'A', getdate(), 1, null, null)
insert into tb_doctor values ('Ricardo', 'Felipe', 'Grados', 'Murillo', '07/01/1984', 'M', 'Medicina General', '985962356', 'abc@gmail.com', null, 'A', getdate(), 1, null, null)
insert into tb_doctor values ('Jherson', '', 'Perez', 'Gamio', '01/09/1970', 'M', 'Medicina General', '985962356', 'abc@gmail.com', null, 'A', getdate(), 1, null, null)
insert into tb_doctor values ('Joel', 'Gonzalo', 'Escobar', 'Revoredo', '21/01/1972', 'M', 'Medicina General', '985962356', 'abc@gmail.com', null, 'A', getdate(), 1, null, null)
insert into tb_doctor values ('Sergio', '', 'Vargas', 'Villavicencio', '01/11/1965', 'M', 'Medicina General', '985962356', 'abc@gmail.com', null, 'A', getdate(), 1, null, null)
insert into tb_doctor values ('Abner', 'Ricardo', 'Fernandez', 'Galan', '11/01/1960', 'M', 'Medicina General', '985962356', 'abc@gmail.com', null, 'A', getdate(), 1, null, null)
insert into tb_doctor values ('Adolfo', '', 'Asencio', 'Rosado', '01/12/1968', 'M', 'Medicina General', '985962356', 'abc@gmail.com', null, 'A', getdate(), 1, null, null)




create table tb_config_horas (
	NIDCONFIGHORA	INT IDENTITY(1,1),
	SVALUEINI		VARCHAR(50),
	SVALUEFIN		VARCHAR(50),
	SCOMENT			VARCHAR(200),
	SACTIVE			CHAR(1),
	NUSERREGISTER	INT,
	DREGISTER		DATE,
	NUSERUPDATE		INT,
	DUPDATE			INT,
	PRIMARY KEY (NIDCONFIGHORA)
)

insert into tb_config_horas values ('00:00', '01:00', '', 'I', 1, getdate(), null, null)
insert into tb_config_horas values ('01:00', '02:00', '', 'I', 1, getdate(), null, null)
insert into tb_config_horas values ('02:00', '03:00', '', 'I', 1, getdate(), null, null)
insert into tb_config_horas values ('03:00', '04:00', '', 'I', 1, getdate(), null, null)
insert into tb_config_horas values ('04:00', '05:00', '', 'I', 1, getdate(), null, null)
insert into tb_config_horas values ('05:00', '06:00', '', 'I', 1, getdate(), null, null)
insert into tb_config_horas values ('06:00', '07:00', '', 'I', 1, getdate(), null, null)
insert into tb_config_horas values ('07:00', '08:00', '', 'I', 1, getdate(), null, null)
insert into tb_config_horas values ('08:00', '09:00', '', 'A', 1, getdate(), null, null)
insert into tb_config_horas values ('09:00', '10:00', '', 'A', 1, getdate(), null, null)
insert into tb_config_horas values ('10:00', '11:00', '', 'A', 1, getdate(), null, null)
insert into tb_config_horas values ('11:00', '12:00', '', 'A', 1, getdate(), null, null)
insert into tb_config_horas values ('12:00', '13:00', '', 'A', 1, getdate(), null, null)
insert into tb_config_horas values ('13:00', '14:00', '', 'A', 1, getdate(), null, null)
insert into tb_config_horas values ('14:00', '15:00', '', 'A', 1, getdate(), null, null)
insert into tb_config_horas values ('15:00', '16:00', '', 'A', 1, getdate(), null, null)
insert into tb_config_horas values ('16:00', '17:00', '', 'A', 1, getdate(), null, null)
insert into tb_config_horas values ('17:00', '18:00', '', 'A', 1, getdate(), null, null)
insert into tb_config_horas values ('18:00', '19:00', '', 'A', 1, getdate(), null, null)
insert into tb_config_horas values ('19:00', '20:00', '', 'A', 1, getdate(), null, null)
insert into tb_config_horas values ('20:00', '21:00', '', 'I', 1, getdate(), null, null)
insert into tb_config_horas values ('21:00', '22:00', '', 'I', 1, getdate(), null, null)
insert into tb_config_horas values ('22:00', '23:00', '', 'I', 1, getdate(), null, null)
insert into tb_config_horas values ('23:00', '24:00', '', 'I', 1, getdate(), null, null)


select*from tb_config_horas

create table tb_appointment(
	NIDAPPOINTMENT		INT IDENTITY(1, 1),
	NIDPATIENT			INT,
	NIDDOCTOR			INT,
	--NIDCONFIGHORA		INT,
	DAPPOINTMENT		DATE,
	SCOMENT				VARCHAR(200),
	SACTIVE				CHAR(1),
	NUSERREGISTER		INT,
	DREGISTER			DATE,
	NUSERUPDATE			INT,
	DUPDATE				DATE,
	PRIMARY KEY (NIDAPPOINTMENT),
	FOREIGN KEY (NIDDOCTOR) REFERENCES tb_doctor(NIDDOCTOR),
	FOREIGN KEY (NIDPATIENT) REFERENCES tb_patient(NIDPATIENT),
	--FOREIGN KEY (NIDCONFIGHORA) REFERENCES tb_config_horas(NIDCONFIGHORA)
)


create table tb_appointment_detail(
	NIDAPPOINTMENTDETAIL		INT IDENTITY(1, 1),
	NIDAPPOINTMENT				INT,
	NIDCONFIGHORA				INT,
	SACTIVE						CHAR(1),
	NUSERREGISTER				INT,
	DREGISTER					DATE,
	NUSERUPDATE					INT,
	DUPDATE						DATE,
	PRIMARY KEY (NIDAPPOINTMENTDETAIL),
	FOREIGN KEY (NIDAPPOINTMENT) REFERENCES tb_appointment(NIDAPPOINTMENT),
	FOREIGN KEY (NIDCONFIGHORA) REFERENCES tb_config_horas(NIDCONFIGHORA)
)


