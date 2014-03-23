CREATE SEQUENCE public.sq_object_structure;
CREATE TABLE public.object_structure
(
 id     integer NOT NULL DEFAULT NEXTVAL('public.sq_object_structure'),
 number_trading_floor integer NOT NULL,            --номер торговой площадки
 description varchar(255) NOT NULL,		   --описание(название) торговой площадки
 max_count_section integer NOT NULL DEFAULT 20,		   --
 max_count_module integer NOT NULL DEFAULT 100,
 CONSTRAINT   pk_object_structure PRIMARY KEY (id),
 CONSTRAINT ntf_group UNIQUE (number_trading_floor),
 CONSTRAINT dscr_group UNIQUE (description)
);
COMMENT ON TABLE public.object_structure IS 'Структура объекта (рынка)';

INSERT INTO public.object_structure (number_trading_floor,description,max_count_section,max_count_module) VALUES (1,'Площадка №1',10,100);
INSERT INTO public.object_structure (number_trading_floor,description,max_count_section,max_count_module) VALUES (2,'Площадка №2',10,100);
INSERT INTO public.object_structure (number_trading_floor,description,max_count_section,max_count_module) VALUES (3,'Площадка №3',10,100);
INSERT INTO public.object_structure (number_trading_floor,description,max_count_section,max_count_module) VALUES (4,'Площадка №4',10,100);
INSERT INTO public.object_structure (number_trading_floor,description,max_count_section,max_count_module) VALUES (5,'Площадка №5',10,100);
INSERT INTO public.object_structure (number_trading_floor,description,max_count_section,max_count_module) VALUES (6,'Площадка №6',10,100);
INSERT INTO public.object_structure (number_trading_floor,description,max_count_section,max_count_module) VALUES (7,'Площадка №7',10,100);
INSERT INTO public.object_structure (number_trading_floor,description,max_count_section,max_count_module) VALUES (8,'Площадка №8',10,100);

CREATE SEQUENCE public.sq_sql_errors;
CREATE TABLE public.sql_errors
(
 id           integer NOT NULL DEFAULT NEXTVAL('public.sq_sql_errors'),
 func_name    varchar(50) NOT NULL,
 error_time   timestamp without time zone NOT NULL,
 error_text   text,
 CONSTRAINT   pk_sql_errors PRIMARY KEY (id)
);
COMMENT ON TABLE public.sql_errors IS 'Диагностическая таблица ошибок запросов к СУБД';

CREATE SEQUENCE public.sq_usergroups;
CREATE TABLE public.usergroups
(
 id          integer NOT NULL DEFAULT nextval('public.sq_usergroups'),
 description varchar(255) NOT NULL,
 low_access  smallint NOT NULL,
 high_access smallint NOT NULL,
 visible     boolean NOT NULL DEFAULT true,
 CONSTRAINT  pk_usergroups PRIMARY KEY (id),
 CONSTRAINT descr_group UNIQUE (description),
 CONSTRAINT  ch_usergroups CHECK (low_access >= 0 AND low_access <= high_access AND high_access < 1000)
);
COMMENT ON TABLE public.usergroups IS 'Группы пользователей';
INSERT INTO public.usergroups (description,low_access,high_access) VALUES ('Разработчики',0,10);
INSERT INTO public.usergroups (description,low_access,high_access) VALUES ('Администраторы',11,99);
INSERT INTO public.usergroups (description,low_access,high_access) VALUES ('Инженеры',100,199);
INSERT INTO public.usergroups (description,low_access,high_access) VALUES ('Диспетчеры',200,299);
INSERT INTO public.usergroups (description,low_access,high_access) VALUES ('Гости',300,399);

CREATE SEQUENCE public.sq_users;
CREATE TABLE public.users
(
  id           integer NOT NULL DEFAULT NEXTVAL('public.sq_users'),
  id_group     integer NOT NULL,
  name         varchar(255) NOT NULL,
  login        varchar(50) NOT NULL,
  password     varchar(50) NOT NULL,
  levelaccess  integer NOT NULL DEFAULT 0,
  del          boolean NOT NULL DEFAULT false,
  CONSTRAINT pk_users PRIMARY KEY (id),
  CONSTRAINT fk_grpusr FOREIGN KEY (id_group)
   REFERENCES public.usergroups (id) MATCH SIMPLE
   ON UPDATE CASCADE ON DELETE NO ACTION,
  CONSTRAINT cu_users UNIQUE (login)
);
COMMENT ON TABLE public.users IS 'Таблица пользователей';
INSERT INTO public.users (id_group,name,login,password,levelaccess,del) VALUES (1,'Разработчик','UKRASUTP','Q1w2e3r4',0,false);

CREATE SEQUENCE public.sq_ElectricitySupplyRef;
CREATE TABLE public.ElectricitySupplyRef
(
  id           integer NOT NULL DEFAULT NEXTVAL('public.sq_ElectricitySupplyRef'), 
  description  varchar(255) NOT NULL,  
  levelaccess  integer NOT NULL,      
  CONSTRAINT pk_esr PRIMARY KEY (id)
);
COMMENT ON TABLE public.ElectricitySupplyRef IS 'Справочник групп электроснабжения';

CREATE SEQUENCE public.sq_abonents;
CREATE TABLE public.abonents
(
  id           integer NOT NULL DEFAULT NEXTVAL('public.sq_abonents'), 	--идентификатор абонента
  description  varchar(255) NOT NULL,                		      	--описание абонента	      
  levelaccess  integer NOT NULL,  				      	--уровень доступа
  number_trading_floor integer NOT NULL,			    	-- номер торговой площадки
  number_sector integer NOT NULL,				   	-- номер сектора
  number_module integer NOT NULL,					--номер иодуля	
  id_group_electricity_supply integer NOT NULL, 		     	--идентификатор группы электроснабжения
  polling_time   timestamp without time zone NOT NULL,			--время последнего опроса
  mode varchar(50) NOT NULL DEFAULT 'не определен',			--текущий режим управления
  amount_electricity_consumed float NOT NULL DEFAULT 0.0,		--количество потр. электроэнергии кВт.ч
  power_consumption float NOT NULL DEFAULT 0.0,				--мгновенная потребляемая мощность
  CONSTRAINT pk_abonents PRIMARY KEY (id),
  CONSTRAINT fk_ges FOREIGN KEY (id_group_electricity_supply)
   REFERENCES public.ElectricitySupplyRef (id) MATCH SIMPLE
   ON UPDATE CASCADE ON DELETE NO ACTION
);
COMMENT ON TABLE public.abonents IS 'Таблица абонентов';

CREATE SEQUENCE public.sq_customer;
CREATE TABLE public.customer
(
  id           integer NOT NULL DEFAULT NEXTVAL('public.sq_customer'), 	--идентификатор клиента
  id_abonent   integer NOT NULL,
  name         varchar(50) NOT NULL,					--имя
  surname      varchar(100) NOT NULL,					--фамилия
  patronymic   varchar(100) NOT NULL,					--отчество
  phone        varchar(50) NOT NULL,					--контактный телефон
  email        varchar(100),
  CONSTRAINT pk_customer PRIMARY KEY (id),
  CONSTRAINT fk_abnnt FOREIGN KEY (id_abonent)
  REFERENCES public.abonents (id) MATCH SIMPLE
   ON UPDATE CASCADE ON DELETE NO ACTION
);
COMMENT ON TABLE public.customer IS 'Таблица клиентов';
--ТАБЛИЦЫ, ОПИСЫВАЮЩИЕ СОБЫТИЯ

CREATE SEQUENCE public.sq_event_group_ref;
CREATE TABLE public.Event_Group_Ref 
{
id           integer NOT NULL DEFAULT NEXTVAL('public.sq_eventhistory'), --идентификатор типа события
description	varchar NOT NULL,					--текстовое описание 
CONSTRAINT pk_event_group_ref PRIMARY KEY (id)
};
COMMENT ON TABLE public.abonents IS 'Таблица - справочник групп событий';
INSERT INTO public.Event_Group_Ref (description) VALUES('Системные события');
INSERT INTO public.Event_Group_Ref (description) VALUES('События абонента');
INSERT INTO public.Event_Group_Ref (description) VALUES('Команды диспетчера');
INSERT INTO public.Event_Group_Ref (description) VALUES('События связи');


CREATE SEQUENCE public.sq_event_ref;
CREATE TABLE public.Event_Ref 
(
  id           integer NOT NULL DEFAULT NEXTVAL('public.sq_eventhistory'), --идентификатор строки
  id_group integer NOT NULL,					   --идентификатор группы события
  Ident  varchar(20) NOT NULL,
  description	varchar NOT NULL,					--текстовое описание события	
  warning boolean DEFAULT false,								--признак предупреждения
  alarm boolean   DEFAULT false,								--признак аварии
  CONSTRAINT pk_event_ref PRIMARY KEY (id),
  CONSTRAINT fk_event_ref FOREIGN KEY (id_group)
   REFERENCES public.Event_Type_Ref (id) MATCH SIMPLE
   ON UPDATE CASCADE ON DELETE NO ACTION
};
COMMENT ON TABLE public.abonents IS 'Таблица - справочник событий';

CREATE SEQUENCE public.sq_eventhistory;
CREATE TABLE public.EventHistory
(
  id           integer NOT NULL DEFAULT NEXTVAL('public.sq_eventhistory'), --идентификатор строки
  event_time   timestamp without time zone NOT NULL,			   --время формирования события
  id_abonent   integer DEFAULT NULL,					   --идентификатор абонента
  id_event      integer NOT NULL,					   --идетификатор события
  accesslevel  integer NOT NULL,       					   --уровень доступа
  CONSTRAINT pk_EventHistory PRIMARY KEY (id),
  CONSTRAINT fk_id_ab FOREIGN KEY (id_abonent)
   REFERENCES public.abonents (id) MATCH SIMPLE
   ON UPDATE CASCADE ON DELETE NO ACTION,
  CONSTRAINT fk_ev_ref FOREIGN KEY (id_event)
   REFERENCES public.Event_Ref (id) MATCH SIMPLE
   ON UPDATE CASCADE ON DELETE NO ACTION 
);
COMMENT ON TABLE public.EventHistory IS 'История событий';
--COMMENT ON COLUMN table.column IS ... ;
--ТАБЛИЦЫ КОМАНД
CREATE SEQUENCE public.sq_command_ref;
CREATE TABLE public.Command_Ref
(
  id           integer NOT NULL DEFAULT NEXTVAL('public.sq_eventhistory'), --идентификатор команды
  description	varchar NOT NULL,					--текстовое описание 	
  CONSTRAINT pk_command_ref PRIMARY KEY (id),
}

CREATE SEQUENCE public.sq_update_tbl_log;
CREATE TABLE public.update_tbl_log
(
 id           integer NOT NULL DEFAULT NEXTVAL('public.sq_update_tbl_log'),
 event_time   timestamp without time zone NOT NULL,	--время изменений в таблице
 tbl_name varchar(50) NOT NULL,		   		--имя таблицы
 CONSTRAINT pk_update_tbl_log PRIMARY KEY (id)
 );
COMMENT ON TABLE public.update_tbl_log IS 'Журнал фиксации изменений в таблицах';


CREATE OR REPLACE FUNCTION __update_change_table_log () RETURNS TRIGGER AS $$
DECLARE
tbl_id integer = -1;
update_time timestamp;
BEGIN
SELECT id INTO tbl_id FROM public.sq_update_tbl_log WHERE tbl_name = TG_RELNAME;
IF tbl_id >= 0 THEN
	EXECUTE 'UPDATE public.update_tbl_log SET event_time = '||NOW()||' WHERE id = '||tbl_id;
ELSE
	EXECUTE 'INSERT INTO public.update_tbl_log(event_time, tbl_name) VALUES ('||NOW()||','||TG_RELNAME||')';
END IF;
END;
$$ LANGUAGE plpgsql;
COMMENT ON FUNCTION public.__update_change_table_log() IS 'Триггерная функция - обновляет время обновления данных в таблицах';

CREATE TRIGGER t_change_abonents
AFTER INSERT OR UPDATE OR DELETE ON abonents FOR EACH ROW EXECUTE PROCEDURE __update_change_table_log ();
CREATE TRIGGER t_change_events
AFTER INSERT OR UPDATE OR DELETE ON eventhistory FOR EACH ROW EXECUTE PROCEDURE __update_change_table_log ();

--вытаскивает выводимае на форме поля таблицы (3 параметра)
CREATE OR REPLACE FUNCTION __displayed_fields_of_abonents(
  in_number_trading_floor integer ,   --number trading floor
  in_number_sector integer ,    --number sector
  in_number_module integer      --number module
)
RETURNS TABLE (
  id integer,
  amount_electricity_consumed float,
  power_consumption float,
  id_group_electricity_supply integer
)
AS
$$
  SELECT id,amount_electricity_consumed,power_consumption,id_group_electricity_supply 
  from abonents 
  where 
   number_trading_floor = in_number_trading_floor AND 
   number_sector = in_number_sector AND 
   number_module=in_number_module
  order by id;  
$$ LANGUAGE sql;

--вытаскивает выводимае на форме поля таблицы (2 параметра)
CREATE OR REPLACE FUNCTION __displayed_fields_of_abonents(
  in_number_trading_floor integer ,   --number trading floor
  in_number_sector integer    --number sector
)
RETURNS TABLE (
  id integer,
  amount_electricity_consumed float,
  power_consumption float,
  id_group_electricity_supply integer
)
AS
$$
  SELECT id,amount_electricity_consumed,power_consumption,id_group_electricity_supply 
  from abonents 
  where 
   number_trading_floor = in_number_trading_floor AND 
   number_sector = in_number_sector
  order by id;  
$$ LANGUAGE sql;

--вытаскивает выводимае на форме поля таблицы (1 параметр)
CREATE OR REPLACE FUNCTION __displayed_fields_of_abonents(
  in_number_trading_floor integer   --number trading floor
)
RETURNS TABLE (
  id integer,
  amount_electricity_consumed float,
  power_consumption float,
  id_group_electricity_supply integer
)
AS
$$
  SELECT id,amount_electricity_consumed,power_consumption,id_group_electricity_supply 
  from abonents 
  where 
   number_trading_floor = in_number_trading_floor
  order by id;  
$$ LANGUAGE sql;

--вытаскивает выводимае на форме поля таблицы (0 параметров)
CREATE OR REPLACE FUNCTION __displayed_fields_of_abonents()
RETURNS TABLE (
  id integer,
  amount_electricity_consumed float,
  power_consumption float,
  id_group_electricity_supply integer
)
AS
$$
  SELECT id,amount_electricity_consumed,power_consumption,id_group_electricity_supply 
  from abonents 
  order by id;  
$$ LANGUAGE sql;


