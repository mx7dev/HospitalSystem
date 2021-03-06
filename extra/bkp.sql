USE [HospitalDB]
GO
/****** Object:  Table [dbo].[tb_appointment]    Script Date: 7/04/2021 21:16:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_appointment](
	[NIDAPPOINTMENT] [int] IDENTITY(1,1) NOT NULL,
	[NIDPATIENT] [int] NULL,
	[NIDDOCTOR] [int] NULL,
	[DAPPOINTMENT] [date] NULL,
	[SCOMENT] [varchar](200) NULL,
	[SACTIVE] [char](1) NULL,
	[NUSERREGISTER] [int] NULL,
	[DREGISTER] [date] NULL,
	[NUSERUPDATE] [int] NULL,
	[DUPDATE] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[NIDAPPOINTMENT] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_appointment_detail]    Script Date: 7/04/2021 21:16:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_appointment_detail](
	[NIDAPPOINTMENTDETAIL] [int] IDENTITY(1,1) NOT NULL,
	[NIDAPPOINTMENT] [int] NULL,
	[NIDCONFIGHORA] [int] NULL,
	[SACTIVE] [char](1) NULL,
	[NUSERREGISTER] [int] NULL,
	[DREGISTER] [date] NULL,
	[NUSERUPDATE] [int] NULL,
	[DUPDATE] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[NIDAPPOINTMENTDETAIL] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_config_horas]    Script Date: 7/04/2021 21:16:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_config_horas](
	[NIDCONFIGHORA] [int] IDENTITY(1,1) NOT NULL,
	[SVALUEINI] [varchar](50) NULL,
	[SVALUEFIN] [varchar](50) NULL,
	[SCOMENT] [varchar](200) NULL,
	[SACTIVE] [char](1) NULL,
	[NUSERREGISTER] [int] NULL,
	[DREGISTER] [date] NULL,
	[NUSERUPDATE] [int] NULL,
	[DUPDATE] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[NIDCONFIGHORA] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_doctor]    Script Date: 7/04/2021 21:16:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_doctor](
	[NIDDOCTOR] [int] IDENTITY(1,1) NOT NULL,
	[SFIRSTNAME] [varchar](50) NULL,
	[SSECONDNAME] [varchar](50) NULL,
	[SLASTNAME] [varchar](50) NULL,
	[SLASTNAME1] [varchar](50) NULL,
	[DBIRTHDATE] [date] NULL,
	[SGENDER] [char](1) NULL,
	[SSPECIALITY] [varchar](100) NULL,
	[NPHONE] [varchar](20) NULL,
	[SEMAIL] [varchar](200) NULL,
	[SWEBSITE] [varchar](200) NULL,
	[SABOUT] [varchar](500) NULL,
	[SPATHIMAGE] [varchar](500) NULL,
	[SACTIVE] [char](1) NULL,
	[DREGISTER] [date] NULL,
	[NUSERREGISTER] [int] NULL,
	[DUPDATE] [date] NULL,
	[NUSERUPDATE] [int] NULL,
 CONSTRAINT [PK__tb_docto__ED8D8299999FF2F1] PRIMARY KEY CLUSTERED 
(
	[NIDDOCTOR] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_patient]    Script Date: 7/04/2021 21:16:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_patient](
	[NIDPATIENT] [int] IDENTITY(1,1) NOT NULL,
	[SFIRSTNAME] [varchar](50) NULL,
	[SSECONDNAME] [varchar](50) NULL,
	[SLASTNAME] [varchar](50) NULL,
	[SLASTNAME1] [varchar](50) NULL,
	[DBIRTHDATE] [date] NULL,
	[SGENDER] [char](1) NULL,
	[SEMAIL] [varchar](200) NULL,
	[NPHONE] [varchar](20) NULL,
	[SDESCRIPTION] [varchar](500) NULL,
	[SPATHIMAGE] [varchar](500) NULL,
	[SACTIVE] [char](1) NULL,
	[DREGISTER] [date] NULL,
	[NUSERREGISTER] [int] NULL,
	[DUPDATE] [date] NULL,
	[NUSERUPDATE] [int] NULL,
 CONSTRAINT [PK__tb_patie__C661AD3B453AACD1] PRIMARY KEY CLUSTERED 
(
	[NIDPATIENT] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tb_user]    Script Date: 7/04/2021 21:16:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tb_user](
	[NIDUSER] [int] IDENTITY(1,1) NOT NULL,
	[SUSER] [varchar](100) NULL,
	[SPASSWORD] [varchar](1000) NULL,
	[NIDDOCTOR] [int] NULL,
	[SACTIVE] [char](1) NULL,
	[DREGISTER] [date] NULL,
	[NUSERREGISTER] [int] NULL,
	[DUPDATE] [date] NULL,
	[NUSERUPDATE] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[NIDUSER] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[tb_appointment]  WITH CHECK ADD FOREIGN KEY([NIDDOCTOR])
REFERENCES [dbo].[tb_doctor] ([NIDDOCTOR])
GO
ALTER TABLE [dbo].[tb_appointment]  WITH CHECK ADD FOREIGN KEY([NIDPATIENT])
REFERENCES [dbo].[tb_patient] ([NIDPATIENT])
GO
ALTER TABLE [dbo].[tb_appointment_detail]  WITH CHECK ADD FOREIGN KEY([NIDAPPOINTMENT])
REFERENCES [dbo].[tb_appointment] ([NIDAPPOINTMENT])
GO
ALTER TABLE [dbo].[tb_appointment_detail]  WITH CHECK ADD FOREIGN KEY([NIDCONFIGHORA])
REFERENCES [dbo].[tb_config_horas] ([NIDCONFIGHORA])
GO
ALTER TABLE [dbo].[tb_user]  WITH CHECK ADD  CONSTRAINT [FK__tb_user__NIDDOCT__3C69FB99] FOREIGN KEY([NIDDOCTOR])
REFERENCES [dbo].[tb_doctor] ([NIDDOCTOR])
GO
ALTER TABLE [dbo].[tb_user] CHECK CONSTRAINT [FK__tb_user__NIDDOCT__3C69FB99]
GO
/****** Object:  StoredProcedure [dbo].[sp_authenticate]    Script Date: 7/04/2021 21:16:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[sp_authenticate](@susername varchar(100), @spassword varchar(500))
as
begin
	
	--validar si existe usuario 
	if ((select count(1) from tb_user where SUSER = @susername and SACTIVE = 'A') = 0) begin
		select -1 as resultado, 'Usuario no encontrado' as mensaje, 0 as nidprocess 
	end
	else
	begin
		if ((select count(1) from tb_user where SUSER = @susername and SPASSWORD = @spassword and SACTIVE = 'A') > 0) begin
			
			select 0 as resultado, 'Autenticación Conforme' as mensaje, NIDDOCTOR as nidprocess
			from tb_user where SUSER = @susername
		end
		else
		begin
			select -1 as resultado, 'Contraseña Incorrecta' as mensaje, 0 as nidprocess 
		end
	end 
end
GO
/****** Object:  StoredProcedure [dbo].[sp_delete_appointment]    Script Date: 7/04/2021 21:16:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[sp_delete_appointment](@nidappointment int)

as
begin
	
	update tb_appointment
	set SACTIVE = 'I'
	where NIDAPPOINTMENT = @nidappointment

	update tb_appointment_detail
	set SACTIVE = 'I'
	where NIDAPPOINTMENT = @nidappointment

	select 0 as resultado, 'Se Elimino la Cita correctamente' as mensaje 
end
GO
/****** Object:  StoredProcedure [dbo].[sp_delete_doctor]    Script Date: 7/04/2021 21:16:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[sp_delete_doctor](@niddoctor int)

as
begin
	
	update tb_doctor
	set SACTIVE = 'I'
	where NIDDOCTOR = @niddoctor

	select 0 as resultado, 'Se Elimino el registro correctamente' as mensaje 
end
GO
/****** Object:  StoredProcedure [dbo].[sp_delete_patient]    Script Date: 7/04/2021 21:16:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[sp_delete_patient](@nidpatient int)

as
begin
	
	update tb_patient
	set SACTIVE = 'I'
	where NIDPATIENT = @nidpatient

	select 0 as resultado, 'Se Elimino el registro correctamente' as mensaje 
end
GO
/****** Object:  StoredProcedure [dbo].[spi_save_appointment]    Script Date: 7/04/2021 21:16:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[spi_save_appointment](
	@nidpattient		int,
	@niddoctor			int,
	@dappoitnment		date,
	@scomment			varchar(500)
)

as
begin

DECLARE @nresult int = 0;                   
DECLARE @smessage varchar(100);
		
		insert into tb_appointment
		values (
			@nidpattient,
			@niddoctor,
			cast(@dappoitnment as date),
			@scomment,
			'A',
			1,
			GETDATE(),
			null,
			null
		)
		
		set @nresult = @@identity;
		set @smessage = 'Cita Creada';	
	select @nresult as resultado, @smessage as mensaje
end
	

GO
/****** Object:  StoredProcedure [dbo].[spi_save_appointment_detail]    Script Date: 7/04/2021 21:16:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE procedure [dbo].[spi_save_appointment_detail](
	@nidappointment		int,
	@nidconfighora		int
)

as
begin

DECLARE @nresult int = 0;                   
DECLARE @smessage varchar(100);
	
		insert into tb_appointment_detail
		values (
			@nidappointment,
			@nidconfighora,
			'A',
			1,
			GETDATE(),
			null,
			null
		)
		
		
	select 1 as resultado, @smessage as mensaje
end
	


	
GO
/****** Object:  StoredProcedure [dbo].[spi_save_doctor]    Script Date: 7/04/2021 21:16:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[spi_save_doctor](
	@niddoctor		int,
	@sfirstname		varchar(50),
	@ssecondname	varchar(50),
	@slastname		varchar(50),
	@slastname1		varchar(50),
	@dbirthdate		date,
	@sgender		char(1),
	@sspeciality	varchar(100),
	@nphone			varchar(20),
	@semail			varchar(200),
	@swebsite		varchar(200),
	@sabout			varchar(500),
	@spathimage		varchar(500),
	@suser			varchar(200),
	@spassword		varchar(1000)
)

as
begin

DECLARE @nresult int = 0;                   
DECLARE @smessage varchar(100);
	
	if (@niddoctor <> 0) begin
		update tb_doctor 
		set	SFIRSTNAME		= @sfirstname,
			SSECONDNAME		= @ssecondname,
			SLASTNAME		= @slastname,
			SLASTNAME1		= @slastname1,
			DBIRTHDATE		= @dbirthdate,
			SGENDER			= @sgender,
			SSPECIALITY		= @sspeciality,
			NPHONE			= @nphone,
			SEMAIL			= @semail,
			SWEBSITE		= @swebsite,
			SABOUT			= @sabout,
			SPATHIMAGE		= @spathimage,
			NUSERUPDATE		= 1,
			DUPDATE	=	GETDATE()
		where NIDDOCTOR = @niddoctor;

		set @nresult = @niddoctor;
		set @smessage = 'La Información del Doctor ha sido actualizada';
	end
	else begin

			if ((select COUNT(1) from tb_user where upper(SUSER) = upper(@suser) and SACTIVE = 'A') > 0) begin
				set @nresult = 0;
				set @smessage = 'El usuario ingresado ya existe';
			end
			else begin
					insert into tb_doctor
					select @sfirstname	,
						   @ssecondname	,
						   @slastname	,
						   @slastname1	,
						   @dbirthdate	,
						   @sgender		,
						   @sspeciality	,
						   @nphone		,
						   @semail		,
						   @swebsite	,
						   @sabout		,
						   @spathimage	,
						   'A'			,
						   getdate()	,
						   1			,
						   null			,
						   null;

				set @nresult = @@identity;
				set @smessage = 'Información del Doctor creada exitosamente';

				if (@nresult <> 0) begin					
					insert into tb_user
					select @suser, @spassword, @nresult, 'A', getdate(), 1, null, null	
				end
			end		
	end	
	select @nresult as resultado, @smessage as mensaje
end
	
GO
/****** Object:  StoredProcedure [dbo].[spi_save_patient]    Script Date: 7/04/2021 21:16:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[spi_save_patient](
	@nidpatient		int,
	@sfirstname		varchar(50),
	@ssecondname	varchar(50),
	@slastname		varchar(50),
	@slastname1		varchar(50),
	@dbirthdate		date,
	@sgender		char(1),
	@nphone			varchar(20),
	@semail			varchar(200),
	@sdescription	varchar(200),
	@spathimage		varchar(500)
)

as
begin

DECLARE @nresult int = 0;                   
DECLARE @smessage varchar(100);
	
	if (@nidpatient <> 0) begin
		update tb_patient 
		set	SFIRSTNAME		= @sfirstname,
			SSECONDNAME		= @ssecondname,
			SLASTNAME		= @slastname,
			SLASTNAME1		= @slastname1,
			DBIRTHDATE		= @dbirthdate,
			SGENDER			= @sgender,
			SDESCRIPTION	= @sdescription,
			NPHONE			= @nphone,
			SEMAIL			= @semail,
			SPATHIMAGE		= @spathimage,
			NUSERUPDATE		= 1,
			DUPDATE	=	GETDATE()
		where NIDPATIENT = @nidpatient;

		set @nresult = @nidpatient;
		set @smessage = 'La Información del Doctor ha sido actualizada';
	end
	else begin

			insert into tb_patient
			select @sfirstname	,
				   @ssecondname	,
				   @slastname	,
				   @slastname1	,
				   @dbirthdate	,
				   @sgender		,
				   @semail		,
				   @nphone		,
				   @sdescription,
				   @spathimage	,
				   'A'			,
				   getdate()	,
				   1			,
				   null			,
				   null;

		set @nresult = @@identity;
		set @smessage = 'Información del Paciente creada exitosamente';	
	end	
	select @nresult as resultado, @smessage as mensaje
end
	
GO
/****** Object:  StoredProcedure [dbo].[sps_get_appointment]    Script Date: 7/04/2021 21:16:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE procedure [dbo].[sps_get_appointment](@nidappointment int)

as
begin
	
	select
		d.NIDAPPOINTMENT,
		CONCAT(p.SFIRSTNAME, ' ', isnull(p.SSECONDNAME, ''), ' ', p.SLASTNAME, ' ', p.SLASTNAME1) as SNAMEPATIENT,
		h.SVALUEINI,
		h.SVALUEFIN,
		a.SCOMENT
	from tb_appointment a 
	inner join tb_appointment_detail d on a.NIDAPPOINTMENT = d.NIDAPPOINTMENT
	inner join tb_config_horas h	   on h.NIDCONFIGHORA  = d.NIDCONFIGHORA
	inner join tb_patient p on p.NIDPATIENT = a.NIDPATIENT
	where a.NIDAPPOINTMENT = @nidappointment
end
GO
/****** Object:  StoredProcedure [dbo].[sps_get_doctor]    Script Date: 7/04/2021 21:16:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE procedure [dbo].[sps_get_doctor](@niddoctor int)

as
begin
	
	select
		doctor.NIDDOCTOR,
		SFIRSTNAME,
		SSECONDNAME,
		SLASTNAME,
		SLASTNAME1,
		DBIRTHDATE,
		SGENDER,
		SSPECIALITY,
		NPHONE,
		SEMAIL,
		SABOUT,
		SPATHIMAGE,
		SWEBSITE,
		doctor.DREGISTER,
		usr.SUSER
	from tb_doctor doctor left join tb_user usr on doctor.NIDDOCTOR = usr.NIDDOCTOR
	where doctor.NIDDOCTOR = @niddoctor
end
GO
/****** Object:  StoredProcedure [dbo].[sps_get_patient]    Script Date: 7/04/2021 21:16:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[sps_get_patient](@nidpatient int)

as
begin
	
	select
		p.NIDPATIENT,
		p.SFIRSTNAME,
		p.SSECONDNAME,
		p.SLASTNAME,
		p.SLASTNAME1,
		p.DBIRTHDATE,
		p.SGENDER,
		p.SDESCRIPTION,
		p.NPHONE,
		p.SEMAIL,
		p.SPATHIMAGE,
		p.DREGISTER
	from tb_patient p
	where SACTIVE = 'A' and
	NIDPATIENT = @nidpatient
end
GO
/****** Object:  StoredProcedure [dbo].[sps_get_userinfo]    Script Date: 7/04/2021 21:16:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[sps_get_userinfo](@susername varchar(200))

as
begin
	
	select
		doctor.NIDDOCTOR,
		usr.NIDUSER,
		doctor.SFIRSTNAME,
		doctor.SSECONDNAME,
		doctor.SLASTNAME,
		doctor.SLASTNAME1,
		doctor.SEMAIL,
		doctor.SPATHIMAGE,
		12 as NVISITS,
		13 as NPATIENTS,
		14 as PENDINGS
	from tb_doctor doctor inner join tb_user usr on doctor.NIDDOCTOR = usr.NIDDOCTOR
	where usr.SUSER = @susername
end
GO
/****** Object:  StoredProcedure [dbo].[sps_list_appointment]    Script Date: 7/04/2021 21:16:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[sps_list_appointment](@niddoctor int, @dappointment date)
as
begin	
	select
		a.NIDAPPOINTMENT,
		concat(p.SFIRSTNAME, ' ', p.SLASTNAME) as SPATIENTNAME,
		(select SVALUEINI from tb_config_horas 
		where NIDCONFIGHORA = (select min(NIDCONFIGHORA) 
								from tb_appointment_detail 
								where NIDAPPOINTMENT = a.NIDAPPOINTMENT)) as SINITAPPOINTMENT
		
	from tb_appointment a inner join tb_patient p on a.NIDPATIENT = p.NIDPATIENT
	where a.SACTIVE = 'A'
	and a.NIDDOCTOR = @niddoctor
	and cast(a.DAPPOINTMENT as date) = cast(@dappointment as date)
end


GO
/****** Object:  StoredProcedure [dbo].[sps_list_doctor]    Script Date: 7/04/2021 21:16:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[sps_list_doctor]

as
begin
	
	select
		NIDDOCTOR,
		SFIRSTNAME,
		SSECONDNAME,
		SLASTNAME,
		SLASTNAME1,
		DBIRTHDATE,
		SGENDER,
		SSPECIALITY,
		NPHONE,
		SEMAIL,
		SWEBSITE,
		DREGISTER
	from tb_doctor
	where SACTIVE = 'A'
end
GO
/****** Object:  StoredProcedure [dbo].[sps_list_hours]    Script Date: 7/04/2021 21:16:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[sps_list_hours](@nidpatient int, @niddoctor int, @ddate date)

as
begin	
	select 		
		hr.NIDCONFIGHORA,
		CONCAT(hr.SVALUEINI, ' - ', hr.SVALUEFIN) as SHORA,
		case
			when (select count(1) from tb_appointment a inner join tb_appointment_detail d
					on a.NIDAPPOINTMENT = d.NIDAPPOINTMENT
					and a.SACTIVE = 'A'and d.SACTIVE = 'A'
					and a.NIDDOCTOR = @niddoctor
					and cast(a.DAPPOINTMENT as date) = cast(@ddate as date)
					and d.NIDCONFIGHORA = hr.NIDCONFIGHORA) > 0			then			1
			when (select count(1) from tb_appointment a inner join tb_appointment_detail d
					on a.NIDAPPOINTMENT = d.NIDAPPOINTMENT
					and a.SACTIVE = 'A'and d.SACTIVE = 'A'
					and a.NIDPATIENT = @nidpatient
					and cast(a.DAPPOINTMENT as date) = cast(@ddate as date)
					and d.NIDCONFIGHORA = hr.NIDCONFIGHORA) > 0			then			1
			else	0
		end			as NDISABLED
	from tb_config_horas hr 
	where hr.SACTIVE = 'A'
end


GO
/****** Object:  StoredProcedure [dbo].[sps_list_patient]    Script Date: 7/04/2021 21:16:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[sps_list_patient]

as
begin
	
	select
		p.NIDPATIENT,
		p.SFIRSTNAME,
		p.SSECONDNAME,
		p.SLASTNAME,
		p.SLASTNAME1,
		p.DBIRTHDATE,
		p.SGENDER,
		p.SDESCRIPTION,
		p.NPHONE,
		p.SEMAIL,
		p.SPATHIMAGE,
		p.DREGISTER
	from tb_patient p
	where SACTIVE = 'A'
end
GO
