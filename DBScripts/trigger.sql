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